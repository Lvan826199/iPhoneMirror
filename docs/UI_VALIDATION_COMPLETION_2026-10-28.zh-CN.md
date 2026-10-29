# UI 审查缺项补验记录

日期：2026-10-28。对应 [原审查与修复记录](FULL_UI_RESOURCE_AUDIT_2026-10-28.zh-CN.md)。
本轮补齐可自动化的受阻项，并连接真实 iPhone 验证 USB 投屏和控制。
原先 Core/bridge 缺失、首次设置失败、检查清单预览未退出等记录保留，最终结论使用下表列出的复跑证据。

## 最终自动化结果

证据根目录：`outputs/ui-validation-complete/`（Git 忽略目录）。

| 范围 | 结果 | 最终证据（相对此根目录） |
|---|---|---|
| 完整托管运行时构建 | 正常 Release 构建，0 错误、0 警告，未使用 UI 专用载荷跳过目标 | `live-build-final.log` |
| USB bridge | 隔离环境构建真实 PyInstaller 负载；依赖与功能自检通过 | `bridge-build-isolated.log` |
| Python 测试 | 499/499 通过 | `python-tests.log` |
| 原生测试 | CTest 18/18 通过 | `native-tests.log` |
| 应用逻辑与驱动管理器测试 | 两套均通过；原 UxPlay 断言失败已由后续完整成功日志取代 | `logic.log`、`driver-tests.log` |
| 静态五语本地化与安装器消息 | 0 错误、0 警告，包含安装器基础语言文件 | `localization-full.log` |
| 主工作区大文字布局 | 五语言，共 370 组；0 失败、0 布局告警、0 绑定错误；实际正文 26 DIP | `workspace-final-summary.json`、`matrix-final-*/workspace-layout/runtime-results.json` |
| 首次设置 | 五语言 × 两主题 × 两窗口宽度 × 100%/200% 文字，共 920 组页面布局通过；另含 256 组混合设备路线及取消、恢复、回退、持久化失败等分支 | `setup-verified/results.json`、`setup-verified/first-run.log` |
| 设置检查清单 | 五语言、两主题，修复导航、针对性检查、异步关闭与所有权释放通过 | `assessment-verified/results.json`、`assessment-verified/assessment.log` |
| 错误呈现、托盘、映射 | 错误专项、托盘与启动主题、映射列表及五步向导均通过 | `specialists/results.json` 中对应成功项；托盘以 `updated-specialists/results.json` 的 `tray` 为准 |
| UI 动画与工作区性能 | 两专项通过；工作区切换中位数 7.10ms、p95 86.30ms；预览空闲布局次数为 0 | `specialists/ui-performance.log`、`specialists/workspace-performance.log` |
| 工作区状态回归 | 通过 | `specialists/workspace-regression.log` |
| 原生预览外壳 | 五语言、两主题、两种外壳，共 20 组，0 失败、0 绑定诊断 | `native-final/native-preview.log`、`native-final/native-preview/preview-shell-results.json` |
| UI 资源回归 | 动态字号、本地化异常、高对比度资源对、减少动画通过 | `native-final/resources.log` |
| 可访问性提供器 | 实际首次设置外壳 20/20；200% 标题、正反高对比度资源、键盘导航、UIA 名称/Invoke 和关闭确认通过 | `setup-verified/accessibility/results.json` |
| 应用发布与安装器编译 | 正常 self-contained 发布，使用真实 Core、bridge 与驱动管理器负载，完整五语 Inno 编译成功 | `app-publish-final.log`、`installer-final.log` |

性能数据来自本机、预览夹具和该次采样；不等同于真实视频解码的延迟或其他电脑的性能保证。
映射和错误专项使用模拟传输/状态注入；真实输入通道的证据单独列在下一节。
`specialists/results.json`、`updated-specialists/results.json` 中仍含早期失败项，不能整份计为通过；
`effective-results.json` 将 14 个 UI 专项与各自最终证据合并，保留原始失败日志。

## 真实设备结果

设备：iPhone 12 mini（`iPhone13,1`），iOS 18.7.8。
按用户授权，通过项目自带驱动管理器安装 Apple USB 支持和当前设备采集过滤驱动，用户拔插后再测试。

| 流程 | 实际结果 | 证据 |
|---|---|---|
| Apple USB 支持安装 | 首次 MSI 返回 1622；取消可选详细日志后重试返回 0，服务运行；采集过滤驱动安装返回 0 | `hardware/driver-install.log`、`hardware/service-state.json` |
| 重连与信任状态 | USB 枚举、配对及 lockdown 可用 | `hardware/device-after-reconnect.json` |
| USB 投屏 | 两轮启动、持续取帧、完整像素读回、停止并再次启动通过；均为 1082×2340，首帧准备约 2.29s/1.52s，最终视频帧 310/309、音频包各 238，像素读回各 10,127,520 字节 | `hardware/usb-capture/capture-results.json`、`hardware/usb-capture-managed.log` |
| USB 控制 | 两轮启动，每轮三次空键盘释放报告均收到实际 HID ACK，随后停止与重启通过；未输入文本或触发手机应用动作 | `hardware/usb-control-live.log` |
| 无线控制 | **受阻，未通过**。尝试实际无线连接后返回 `wireless_remote_pairing_required`；现有 Wi-Fi Sync/开发者设置检查通过，但不能证明 RemotePairing 凭据完整 | `hardware/bridge-wireless-setup.json`、`hardware/wireless-control-live.log` |

USB 投屏测试静音运行；音频包到达不等同于扬声器播放质量、音画同步或录音验收。
无线控制的首次调用记录保留为实际环境受阻，不能用 USB 成功或静态前置检查覆盖。

## 补验发现并处理的问题

- 200% 文字下设备管理页外层高度不能随内容增长，导致区域挤压；增加可增长的外层滚动布局、内容最小高度和标题换行。
- 工作区设备标题、映射管理入口长文案，以及首次设置语言卡片的固定高度导致放大裁切；改为换行和可增长布局。
- 首次设置恢复草稿早于初始化窗口和设置 `SetupActive`，会触发由尚未显示的设置窗口承载的无线质量提示；提前初始化并建立设置流程标志，完整路线复验通过。
- 原工作区检查把麦克风动作滚到页面末尾，在大文字下可能越过目标；改为将目标控件带入可见范围后再断言。
- 自动脚本误用持续展示的 `--setup-assessment-preview`；改用会正常结束的 `--setup-assessment`。
- Apple MSI 无法创建详细日志时返回 1622；仅对该返回码取消可选日志重试一次。签名、哈希、文件锁及提权校验仍由原调用路径执行。新增测试覆盖 0、1622、1603、1619、1223、3010，其他失败和取消不重试。
- Python 诊断结构遗漏原生状态中的三个错误字段；补齐 ABI，并允许显式指定真实运行目录和重复启动次数。实机投屏结论使用托管宿主，避免 Python 进程目录影响原生辅助程序定位。

## 可复跑入口

```powershell
# 无真实手机操作的完整 UI 专项；要求目录含真实 Core。
./scripts/verify_ui_validation.ps1 -RuntimeDirectory <Runtime.Tests运行目录> -OutputDirectory <证据目录>

# 定向运行日语、大文字工作区。
./scripts/verify_ui_validation.ps1 -RuntimeDirectory <Runtime.Tests运行目录> -OutputDirectory <证据目录> -Check workspace-layout -Culture ja-JP -TextScale 2

# 以下显式入口会连接指定真实手机，必须使用实际 UDID 和完整 bridge 路径。
<Runtime.Tests.exe> --live-capture-validation <UDID> <证据目录>
<Runtime.Tests.exe> --device-control-live <iUsbBridge.exe绝对路径> <UDID> usb
<Runtime.Tests.exe> --device-control-live <iUsbBridge.exe绝对路径> <UDID> wireless
```

自动脚本逐项记录退出码、超时和耗时，隔离运行时注入环境；超时清理子进程树。
实机入口不加入默认 UI 套件，防止普通界面检查意外连接手机。

## 仍未完成的人工或环境验收

1. 无线控制的 RemotePairing 配置完成后的成功连接与断线恢复；本次实机尝试受上述前置条件阻塞。
2. 手机上的 AirPlay 屏幕镜像选择、真实音视频与蓝牙配对/断连端到端验收。本轮覆盖对应界面、状态和错误自动测试，未完成这些实际手机流程。
3. Windows 实际高对比度桌面、Narrator 语音输出、系统关闭动画后的整机交互，以及不同 DPI 多屏之间的窗口拖动。本机仅单屏、实际 DPI 比例 1.5；资源注入和 UIA 通过不能替代这些人工结果。
4. 安装器完成本次五语编译；本轮未安装/卸载主应用或做升级回滚。安装器生命周期另见 [安装验证记录](INSTALLER_VALIDATION_2026-10-28.zh-CN.md)，其证据独立。

上述项目保持未完成，不记为通过。原审查因 Core/bridge 缺失而受阻的主工作区、首次设置、原生外壳、错误呈现、性能和安装器编译项，已由本轮实际运行证据补齐。
