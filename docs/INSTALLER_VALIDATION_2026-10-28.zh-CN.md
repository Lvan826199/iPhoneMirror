# 完整安装包验证（2026-10-28）

结论：`1.8.5-pre3` 标准安装包在 Windows 当前用户安装模式下，通过构建、安装、升级流程、安装后功能回归、启动和卸载验证。本轮没有发现安装载荷缺失或安装后功能回归失败。

## 验证对象

- 工作区基础提交：`43d7a83`，包含本地未提交的逻辑修复及打包时已有的 UI 修改。
- 冻结载荷：主应用 DLL 的生成时间为北京时间 **2026-10-28 10:44:09**。另一条聊天随后继续修改 UI；本报告不覆盖之后未重新打包的源码。
- 标准发布配置：自包含 .NET、原生核心、原始无线接收端、驱动管理器、USB 桥接器、两套 DDI 和 FFmpeg。UxPlay 为在线可选组件，本包未离线内置。
- 安装 EXE：`outputs/installer-validation-2026-10-28/releases/iPhoneMirror-Setup-v1.8.5-pre3-x64.exe`。
- 大小：**139,211,412 字节**（139.2 MB）。超过项目 100 MB 的提示目标；发布脚本未启用硬性体积限制，保留完整运行组件。
- SHA-256：`97942477594d6eb69603d16a869e8faa2118bfa910f10f05385b12b3c0fe054b`。
- 文件清单：`outputs/installer-validation-2026-10-28/payload-manifest.json`，覆盖 **1,328 个文件**。

## 结果

| 项目 | 实际执行及结果 |
| --- | --- |
| 正式构建 | `build.ps1 -Configuration Release -OmitUxPlayRuntime` 成功；没有跳过测试，没有使用临时 UI 编译目标。 |
| 基础回归 | 18 项原生测试、499 项 Python 测试、App.Logic.Tests、App.Runtime.Tests、自动化生命周期、DriverInstaller.Tests 及运行库验证全部通过。 |
| USB 桥接与 DDI | PyInstaller 实际打包；桥接器依赖及功能检查通过；两种 DDI 共 8 个文件通过固定大小、SHA-256 和版本校验。 |
| 发布压缩 | 使用实际发布配置 `lzma2/ultra64`；安装 EXE、便携 ZIP、SHA256SUMS 已生成。 |
| 隔离安装与升级 | 使用同一 ISS 和完整载荷，独立 AppId、注册信息和数据目录；从 1.8.4 安装元数据升级到 1.8.5-pre3；升级成功关闭已运行的驱动管理器。 |
| 安装一致性 | 升级后 1,328 个文件与发布载荷逐一比较 SHA-256，全部一致；包括桥接器私有 libusb0、.NET DAC、原生依赖和延迟加载资源。 |
| 安装后组件功能 | 在安装目录中加载应用及其运行组件，通过完整性、运行库加载、本地 HTTP/HLS 传输、转封装、三次重启和音频解码测试。 |
| 安装后音频兼容 | 18 种格式通过实际 HTTP 解码，输出非静音 48 kHz 双声道 PCM，与参考 FFmpeg 一致，停止后清理正常。 |
| 本轮逻辑修复 | 安装目录内执行 `--retry-fallback-regressions`、`--capture-review`，全部通过；覆盖 Wi-Fi 锁释放、USB 清理重试和所有权、HLS 退出码、Original 启动保护、设备恢复及采集拆除顺序。 |
| 注册与快捷方式 | 升级版本号、App Paths、AppUserModelID、图标及开始菜单快捷方式检查通过。 |
| 两种卸载路径 | 隔离安装分别验证保留用户数据、重新安装后删除隔离用户数据，均通过。 |
| 最终 EXE 实装 | 直接运行最终发布 EXE，以 `/CURRENTUSER` 安装至临时目录；安装返回 0，再次逐一验证全部 1,328 个文件；安装后的桥接器运行时检查通过。 |
| 最终应用启动 | 从最终 EXE 的安装目录启动真实主程序；必需运行组件缺失列表为空；观察到主界面、1.8.5-pre3 版本、设置面板和 Original 接收端 Ready。 |
| 正常退出与最终卸载 | 通过应用既有单实例退出 IPC 正常关闭，应用日志记录 `session_end exit_code=0`；随后运行该安装的卸载器，返回 0。注册信息、开始菜单和安装文件均清理完成，保留真实用户数据。 |

## 证据与复现

证据目录为 `outputs/installer-validation-2026-10-28/`：

- `build.log`、`build-result.json`、`native-tests.log`：构建与基础测试。
- `package.log`、`releases/SHA256SUMS.txt`：发布打包与校验和。
- `isolated/result.json` 及五份安装、升级、卸载日志：隔离生命周期结果。
- `final-setup-install-result.json`、`final-setup-install.log`：最终 EXE 安装与载荷比对。
- `final-installed-bridge.log`：最终安装目录内的桥接器运行时检查。
- `final-app-startup-result.json`、`final-app-runtime.log`：真实应用启动、设置面板、接收端 Ready 和正常退出。
- `final-setup-uninstall-result.json`、`final-setup-uninstall.log`：最终 EXE 卸载与残留检查。

安装回归脚本已补充 `-EvidenceDirectory`，保留清理前的安装日志和 JSON 结果，并在实际安装目录增加本轮重试、回退与采集修复的回归入口。复现命令：

```powershell
./scripts/test_installer.ps1 -Version 1.8.5-pre3 -PreviousVersion 1.8.4 `
  -RuntimeTestDirectory src/App.Runtime.Tests/bin/Release/net10.0-windows10.0.19041.0/win-x64 `
  -UseReleaseCompression -EvidenceDirectory outputs/installer-validation-repeat
```

## 范围边界

- 安装和卸载实测采用当前用户模式，没有验证管理员提权、系统级防火墙规则及 Bonjour 服务配置。
- 升级测试的旧版使用当前载荷和旧安装版本元数据，验证安装器升级行为；没有安装历史正式版二进制验证数据迁移。
- 未执行真实驱动安装/卸载、iPhone 实机投屏或控制、跨设备网络发现、慢启动故障注入。本机主程序显示需要 Apple USB 通道，不能据此宣称实机功能通过。
- 首次启动期间 Windows 曾显示防火墙权限窗口；助手没有操作该安全权限窗口。之后窗口不再遮挡，主界面及设置检查继续完成。
- 临时安装和隔离测试目录均已清理，发布产物和证据保留。未提交代码或发布远程 Release。
