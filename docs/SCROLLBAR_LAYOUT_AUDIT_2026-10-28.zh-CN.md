# 全项目滚动条位置检查

日期：2026-10-28。检查目标：滚动条及其鼠标命中区与文字、输入框、按钮和列表内容分开布局，不能通过覆盖内容或移出容器来定位。

后续截图审查发现了框架最小滚动条宽度、单侧扣宽、关闭动作随页滚动和大字号比例等问题；最新修复与复核以
[对称布局与字号复核](BALANCED_LAYOUT_TYPOGRAPHY_2026-10-28.zh-CN.md) 为准。下方保留前两轮记录，不能用它们替代最新结果。

## 后续视觉调整

原修复解决了遮挡，但整窗滚动条贴近圆角、内容区重复留白，视觉上仍不协调。本次进一步调整：

- 内容滚动条两端内缩 6 DIP，并为横向滚动采用对称间距；独立槽位保留，悬停仍不会侵入内容。
- 整窗滚动条两端内缩 18 DIP、距外侧边缘内缩 8 DIP，避开圆角；普通内容区和整窗采用各自的间距资源。
- 收紧主工作区设置卡片旁的重复留白，移除设备详情和 USB 模式说明的额外右侧补偿。
- 设备管理页把页面边距交由滚动区内边距承担，避免“最小视口高度 + 外边距”产生不必要的整页滚动条。

本次证据目录为 `outputs/scrollbar-refinement/`；下方 `outputs/scrollbar-audit/` 保留为上一轮结果。
已通过：滚动场景 360 组（包含 40 组内容放得下时不显示滚动条）、资源/减少动画回归、首次设置 920 组、日语驱动页 64 组。
页面第一轮日语大字号 74 组通过；设备页内边距修正后的重点页面按正常/放大字号再次复核，共 16 组，0 失败、0 布局告警、0 绑定诊断。
最终设备页正常字号截图确认内容放得下时不显示整窗滚动条；大字号需要滚动时仍保留向内收进、避开圆角的滑块。
证据分别为 `verified/results.json`、`driver-ja/driver-results.json`、`final-pages-1/runtime-results.json` 和 `final-pages-2/runtime-results.json`。

## 检查与修复

静态清点主程序、驱动管理器和共享控件中 38 个 XAML 文件的 66 个滚动相关入口，另检查首次设置中动态创建的检查结果滚动列表。
包含普通页面、对话框外层、嵌套列表、输入框、横向工具栏、统计区、FlowDocument 更新日志和 ComboBox 下拉菜单。
清单保存在 `outputs/scrollbar-audit/inventory.json`。

实际渲染确认 WPF-UI 默认滚动模板将内容区域跨越两行两列，内容与滚动条共享空间。
即使滑块较细，其命中区域仍可能盖住靠右或靠下的文字和控件。另有局部右移滚动条和负边距定位。

本次处理：

- 共享 `ContentScrollViewerStyle` 为内容、纵向滚动条和横向滚动条分别安排独立网格单元；滚动条与内容间保留 4 DIP 间距，双向同时滚动时两个滑块也不相交。
- 普通 ScrollViewer、DialogViewport、WPF-UI PassiveScrollViewer/DynamicScrollViewer 使用同一模板，覆盖列表、编辑器和下拉菜单中的模板内部滚动区；横向工具栏也复用该布局。
- 保留 6 DIP 的滚动条布局宽度，滑块悬停只在该槽内变化，不挤压或覆盖内容。
- `ContentEdgeScrollBarStyle` 移除横向平移，快捷键设置页移除右侧 -25 DIP 负边距；滚动条留在所属滚动区内。
- ComboBox 明确采用纵向自动滚动条和禁用横向滚动，避免长列表可以滚动却没有可见滑块。

## 验证

证据根目录：`outputs/scrollbar-audit/`（Git 忽略目录）。

| 检查 | 结果 | 证据 |
|---|---|---|
| 主程序/运行时测试及驱动管理器 Release 构建 | 0 错误、0 警告 | `../scrollbar-build.log`、`driver-build.log` |
| 滚动条专项 | 320/320 组，410 条可见滚动条，0 问题；分页、滑块拖动与滚动到末尾通过 | `final/results.json`、`final.log` |
| 独立弹窗与映射五步 | 360 组，0 失败、0 布局告警、0 绑定诊断 | `standalone/standalone-results.json`、`standalone.log` |
| 驱动管理器实际页面 | 320 组，0 失败、0 布局告警、0 绑定诊断 | `driver/driver-results.json`、`driver.log` |
| 首次设置各分支 | 920 组页面布局及 256 组混合设备路线通过 | `first-run.log`、`product-results.json` |
| 主工作区与关联设置页 | 五语言、200% 字号 370 组，0 失败、0 布局告警、0 绑定诊断 | `workspace-200/workspace-layout/runtime-results.json`、`workspace-200/results.json` |
| 主工作区正常字号 | 日语 74 组，0 失败、0 布局告警、0 绑定诊断 | `workspace-ja-normal/workspace-layout/runtime-results.json` |
| 设置检查清单、托盘和资源回归 | 全部通过；包含动态检查结果列表、五语托盘、两方向滑块和减少动画 | `final-specialists/results.json`、`final-specialists/assessment.log`、`final-specialists/tray.log`、`final-specialists/resources.log` |
| 可访问性回归 | 20/20 组，键盘遍历、UIA 操作、配对高对比度资源和关闭确认通过 | `final-specialists/accessibility/results.json` |
| 驱动下拉菜单交互 | 弹出输入、反复选择、状态详情、主题及禁用状态通过 | `driver-combobox.log` |
| 应用逻辑回归 | 通过 | `logic-clean.log` |

320 组专项覆盖五语言、深浅主题、100%/200% 字号、360/600 DIP 窗口宽度和八类实际 WPF 控件。
检查滚动条完整矩形与实际 ScrollContentPresenter 是否相交、是否越出所属滚动区，并执行分页命令、滑块拖动事件和末尾可达性断言。
不是仅比较样式声明或滑块颜色。相关检查同时接入实际窗口矩阵、首次设置页面和弹出下拉菜单。
最终汇总见 `summary.json`，受测程序与关键样式的 SHA-256 见 `artifact-hashes.json`。

修复前相同 320 组中有 614 条检查记录（同一问题在不同语言、主题、尺寸和滚动位置重复计数，包含下拉列表隐藏滚动条）；修复后为 0。
旧记录保留在 `baseline/`，中间结果保留在 `fixed/`、`fixed2/`，最终结论使用 `final/`。
逻辑测试首次使用自定义产物目录时因源码相对路径失败，随后 `dotnet run` 又受宿主注入环境影响；最终使用正常目录的 apphost、清理子进程注入环境后通过，证据为 `logic-clean.log`。

## 复跑

```powershell
<Runtime.Tests.exe> --scrollbar-layout-audit <证据目录>
./scripts/verify_ui_validation.ps1 -RuntimeDirectory <完整运行时目录> -OutputDirectory <证据目录> -Check scrollbars
```

常规 UI 审计也会检查实际窗口和下拉菜单的滚动条边界。检查采用产品实际资源和控件模板，未改变用户 Windows 设置，也不发送手机输入。
窗口宽度、工作区和文字倍率为测试场景；本轮不将其记作实际多屏 DPI 切换验收。
