# UI 审计覆盖清单

基于 `scripts/audit_ui.py` 生成的 42 个带 `x:Class` 的 XAML 入口维护。
新增界面时同时更新本清单、对应测试工厂和实际组合数报告。测试通过只代表输出 JSON
中实际列出的组合，不把 native 负载缺失、未运行专项或静态检查记作运行通过。

受支持语言：`SupportedUiCultures.All`（托管测试），`audit_localization.LANGUAGES`
（Python 静态审计）。两者为简中、香港繁中、台湾繁中、英语、日语。

| XAML 入口 | 常规矩阵或专项入口 | 前置条件与覆盖 |
|---|---|---|
| 主程序 `App.xaml` | `--localization-audit`、`--control-states` | 实际编译资源、字体切换、控件状态 |
| 主程序 `MainWindow` | `--ui-audit` | 需要 Core；包含投屏、设备、应用设置、输出、工具栏 |
| `AboutWindow`、`DeveloperToolsWindow`、`DeviceBindingWindow`、`ImageSettingsWindow`、`MediaOutputSettingsWindow`、`ProjectionSettingsWindow`、`ReverseControlStatusWindow`、`ShortcutSettingsWindow`、`UpdateWindow`、`UsbProjectionModeInfoWindow`、`CaptureStatusNoticeWindow` | `--ui-audit` | 需要 Core；通过开发者只读预览与模拟状态，包含错误和长文案 |
| `AdvancedSettingsWindow`、`AppPromptWindow`、`AirPlayDeviceSelectionWindow`、`BluetoothClientBindingWindow`、`BluetoothConnectionWindow`、`BluetoothControlNoticeWindow`、`CaptureRecoveryWindow`、`ComponentDownloadWindow`、`InstanceConflictWindow`、`ProtectedContentNoticeWindow`、`StartupErrorWindow`、`TextInputWindow`、`WindowStyleSettingsWindow` | `--standalone-ui-audit` | 无需 Core；五语言 × 两主题 × 100%/200% 文字；无设备发现和下载 |
| `KeyboardMappingEditorWindow` 与 `MappingWizard/KeySelectionStep`、`ActionSelectionStep`、`ParameterStep`、`PositionStep`、`ConfirmationStep` | `--standalone-ui-audit` | 同一五语矩阵，通过已验证草稿依次进入全部五步；无键盘注入 |
| `KeyboardMappingWindow` | `--keyboard-mapping` / `--keyboard-mapping-wizard` | 需要 Core；列表、编辑、草稿和向导交互专项 |
| `FirstRunSetupWindow` | `--first-run-setup` | 需要 Core；五语言、两主题、两窗口宽度、100%/200% 文字、各设置分支；检查清单与恢复流程另有 `--setup-assessment`；`--setup-assessment-preview` 是持续展示窗口的人工预览，不可用于自动测试 |
| `TrayPanelWindow` | `--tray-mode` / `--tray-startup-theme` | 需要 Core；托盘持久化、主题和入口行为 |
| 驱动程序 `App.xaml` | `--driver-localization-audit <driver.dll>` | 实际资源格式化与操作结果翻译 |
| 驱动 `MainWindow`、`DeviceTrustWindow`、`FailureHelpWindow`、`ParentDriverWindow`、`PromptWindow`、`RequiredActionWindow` | `--driver-ui-audit <root> <driver.dll> <output>` | 五语言 × 两主题 × 100%/200%；简洁/高级页、状态和长文案夹具；不枚举 PnP、不修改驱动 |

`--standalone-ui-audit <output> --culture ja-JP` 和驱动矩阵的同名后缀支持单独审计日语。
独立矩阵输出 `expectedCombinations` / `actualCombinations` 与每个语言、主题、文字大小、
窗口的实际结果。驱动矩阵输出 `combinations`，并断言标题实际字号与模拟文字大小一致。
工作区矩阵保留 `IPHONE_MIRROR_UI_AUDIT_TEXT_SCALE=2` 的定向执行方式，报告记录模拟
倍率和实际正文字号；不要混淆文字放大与 `ExerciseWorkAreaSizes` 模拟的可用工作区。

`--ui-resource-regressions <output>` 检查已本地化业务拒绝与未知异常、动态文字大小、
正反高对比度资源对、两方向滚动条悬停和运行中关闭动画。高对比度资源模拟不会改变
Windows 系统设置，也不能代替系统高对比度桌面下的人工验收。

`--framework-ja <self-contained-output>` 读取发布目录实际日语框架卫星资源，校验
剪切、复制、粘贴的日语菜单文本。主程序只有完整 Core/bridge 负载的正式发布才可作为
可交付应用；用于 UI 检查的缺载荷输出不能作为发布包。

新增自动补验入口：

```powershell
./scripts/verify_ui_validation.ps1 -RuntimeDirectory <完整运行时测试目录> -OutputDirectory <证据目录>
./scripts/verify_ui_validation.ps1 -RuntimeDirectory <完整运行时测试目录> -OutputDirectory <证据目录> -Check workspace-layout -Culture ja-JP -TextScale 2
```

脚本检查真实 Core 载荷，逐个运行专项、记录退出码与耗时，对超时子进程树进行清理，并在
`results.json` 中汇总实际结果；不会把未执行、超时、预览窗口或非零退出算作通过。
默认包含首次设置、检查清单、错误呈现、托盘、映射、工作区/动画、原生窗口、资源和可访问性。

`--ui-accessibility-audit <output>` 使用实际首次设置窗口，执行五语言 × 两主题 × 两种
正反高对比度资源对共 20 组，检查真实外壳背景/前景、200% 实际标题大小、键盘导航、
UI Automation 名称/Invoke 模式及关闭确认。结果记录本机实际 DPI、工作区及系统偏好。
此项是 UIA 提供器自动测试，不能替代 Narrator 的语音输出或多屏实际 DPI 切换验收。

显式实机入口 `--live-capture-validation <UDID> <output>` 使用真实 Core 连续执行两轮
USB 启动、持续帧增长、像素读回与停止检查，并输出包含 `passed`、实际完成轮数和失败信息的 JSON。
`--device-control-live <bridge绝对路径> <UDID> usb|wireless` 验证实际 HID ACK、停止与重启，
仅发送空键盘释放报告。这些入口不加入默认 UI 套件。最终运行结果与未完成的人工范围见
[缺项补验记录](UI_VALIDATION_COMPLETION_2026-10-28.zh-CN.md)。

滚动条位置专项：`--scrollbar-layout-audit <output>`（统一脚本 `-Check scrollbars`，已加入默认套件）。
五语言 × 两主题 × 两字号 × 两宽度 × 九种场景，共 360 组（含内容放得下时不出现多余滚动条），检查真实滚动条矩形与内容视口分离、
容器边界、分页/拖动和末尾可达性；实际窗口矩阵、首次设置与下拉菜单也执行同一边界检查。
最终结果见 [全项目滚动条位置检查](SCROLLBAR_LAYOUT_AUDIT_2026-10-28.zh-CN.md)。

`--balanced-ui <output>` / `-Check balanced` 检查五语言 × 两主题 × 两文字倍率 × 四个实际窗口，
确认左右对称、滚动条外侧留白、关闭动作固定及阅读字号范围。最新字号规则和证据见
[对称布局与字号复核](BALANCED_LAYOUT_TYPOGRAPHY_2026-10-28.zh-CN.md)；此前报告中的字号数值保留为当轮历史记录。
