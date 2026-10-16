# pre3 反控准备失败排查（2026-10-16）

多位用户反馈 pre3 在“准备设备支持文件”阶段提示无法挂载开发者镜像，pre2 正常。
目前没有这些用户的机型、iOS 版本或诊断日志，尚不能确认所有反馈的共同根因。
截图对应 `UsbControlFailureImageMount`，可能来自 `developer_image_bundle_invalid`
或 `developer_image_mount_failed`，不能仅凭截图确定所走的镜像路径。

## 发布载荷核对

- 从本地 pre2 发布 ZIP 读取实际桥接器，与已发布 pre3 ZIP 中的桥接器比较。
- 下载的 pre3 ZIP SHA-256 为
  `bd8642a0d755246e6703c6313525d79b520ea1216b761b537b8574e26cce99dc`，
  与 GitHub Release 的资产摘要一致。
- pre2 ZIP 没有内置 DDI；pre3 内置的 8 个 Personalized/Cryptex 文件的大小和
  SHA-256 均与 `config/ddi-bundles.json` 一致。未发现便携包内镜像缺失或损坏。
- 两版实际桥接器中的上游 Personalized 挂载方法相同；pre2 的缓存、下载、候选挂载
  和镜像 inventory 方法也与当前源码一致。
- pre3 新增按 iOS 主版本 27 选择 Cryptex 的分支，并在准备失败时直接结束启动。
  其他 iOS 主版本仍走 Personalized 分支。

## 本次修复

确认并用故障注入复现了一种回归条件：Cryptex 准备被拒绝时，即使 pre2 的
Personalized 路径仍能准备或复用镜像，pre3 也不会尝试它。

现在仅针对 Cryptex 镜像拒绝、镜像不兼容、无效镜像或服务不可用尝试原有路径，
共用原来的准备总期限，并以 `developer_image_cryptex_fallback` 保留首个错误码。
设备锁定、信任、身份不符、连接、网络、超时和安装验证失败仍直接报告原错误。
两个恢复入口都禁止自动卸载 iOS 27 已有镜像，因为旧 inventory 也可能暴露 Cryptex。
准备成功后仍需通过真实 HID 检查才能报告反控可用。

## 验证与限制

全部 Python 测试 **457 项通过**，包含新增的 9 项回归：复用/挂载、错误范围、取消、
原总期限、双错误诊断、有线/无线恢复不卸载、准备隧道释放后才回退，以及真实固定版本 CryptexdService
经模拟传输返回设备错误后进入 Personalized 复用的路径。

桥接器已从当前源码重新生成，冻结归档中的准备方法与当前源码字节码一致，运行时自检
通过。本地化字典、其他本地化界面检查和 SRS HTTP 回归也通过。

这些测试未访问 Apple 签名服务或真实手机。没有受影响用户日志，不能将本修复等同于
这些用户的问题已解决；尤其 iOS 26 等系统不会进入该新增回退分支。
本次未发布新的 ZIP/Setup。受影响用户目前可暂用已知正常的 pre2。
