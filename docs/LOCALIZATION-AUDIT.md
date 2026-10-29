# 多语言文字一致性审计表

审计日期：2026-10-03。新增独立台湾繁体中文资源。

## 审查范围

支持语言：简体中文（zh-CN）、香港繁体中文（zh-HK）、台湾繁体中文（zh-TW）、英文（en-US）。

扫描 611 个第一方源码/脚本文件，核对主程序、驱动管理器的八份语言字典、WPF XAML、C# 提示/错误、独立驱动清理脚本，以及安装器有效语言资源。

主程序覆盖主窗口、设备绑定、蓝牙/有线/无线控制、所有设置与状态窗口、采集恢复、截图、录制、推流、虚拟摄像头、更新、关于、诊断和开发者预览。

语言无关内容（产品名、协议、键名、单位、尺寸、路径、设备自报名称）保持原样。原生库、FFmpeg、Windows 返回的原始诊断及结构化日志事件/字段是技术数据，保留原文用于排错。开发/构建脚本、测试断言、第三方代码和许可证不作为应用 UI 字典翻译。台湾完整更新日志另行校验版本、条目、代码标记及链接；两个串流测试网页也纳入资源表。

硬编码表逐项列出保留的 XAML 品牌、协议、数字、符号和单位；node 是 XML 文档中的节点序号。启动故障的两条消息及五个备用标签均有独立四语回退：它们必须在语言字典加载失败时仍然可用。安装器的更新记录、卸载快捷方式也纳入对应表。

## 问题统计

| 分类 | 受影响条目数（可重叠） |
| --- | ---: |
| 缺失翻译 | 242 |
| 错误翻译 | 4 |
| 语义不一致 | 33 |
| 占位符问题 | 2 |
| 术语不一致 | 85 |
| 可读性问题 | 68 |

确认并修复的问题条目：429。问题状态表示**修改前**；表内四语为**修改后**。未发现问题的资源标为“✅ 完全一致”。

缺失翻译按硬编码消息/资源 Key 计数，不按缺少的语言单元格重复计数。静态未发现引用不等于已废弃，全部保留并列出，避免误删外部或动态调用。

## 多语言对照

### App

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| AboutDescription | 低延迟 iPhone 投屏、录制、直播推流与虚拟摄像头。 | 低延遲 iPhone 螢幕鏡像、錄製、直播串流與虛擬攝影機。 | 低延遲 iPhone 螢幕鏡像、錄製、直播串流與虛擬攝影機。 | Low-latency iPhone mirroring, recording, streaming, and virtual camera output. | 低遅延のiPhoneミラーリング、録画、配信、仮想カメラ出力に対応しています。 | ❌ 术语不一致 → ✅ 已修复 | 关于页沿用投屏、推流正式术语 |
| AboutSubtitle | 应用信息、更新和诊断 | 應用程式資料、更新和診斷 | 應用程式資訊、更新和診斷 | App information, updates, and diagnostics | アプリの情報、アップデート、診断 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| AboutTitle | 关于 | 關於 | 關於 | About | 情報 | ✅ 完全一致 | 保留 |
| AboutToolTip | 关于和更新设置 | 關於和更新設定 | 關於和更新設定 | About and update settings | 情報とアップデート設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ActualFrameRate | 实际帧率 | 實際幀率 | 實際影格率 | Actual frame rate | 実際のフレームレート | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ActualResolution | 实际分辨率 | 實際解像度 | 實際解析度 | Actual resolution | 実際の解像度 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ActualStream | 当前 AirPlay 接收到的实际码流 | 目前 AirPlay 接收到的實際串流 | 目前 AirPlay 接收到的實際串流 | Actual AirPlay stream currently being received | 現在受信しているAirPlayストリームの実際の値 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AdvancedModeDisabled | 高级模式已关闭，恢复普通预设 | 進階模式已關閉，還原一般預設 | 進階模式已關閉，還原一般預設 | Advanced mode disabled; normal presets restored | 詳細モードを無効にし、通常のプリセットに戻しました | ✅ 完全一致 | 保留 |
| AdvancedModeEnabled | 高级模式已开启 | 進階模式已開啟 | 進階模式已開啟 | Advanced mode enabled | 詳細モードを有効にしました | ✅ 完全一致 | 保留 |
| AdvancedResolutionInvalid | 请输入 16–8192 范围内的有效宽度和高度。 | 請輸入 16–8192 範圍內的有效寬度和高度。 | 請輸入 16–8192 範圍內的有效寬度和高度。 | Enter valid width and height values from 16 to 8192. | 幅と高さには、16〜8192の有効な値を入力してください。 | ✅ 完全一致 | 保留 |
| AdvancedSettings | 高级设置 | 進階設定 | 進階設定 | Advanced settings | 詳細設定 | ✅ 完全一致 | 保留 |
| AdvancedSettingsIntro | 此设置仅作用于当前选中有线设备的 B AirPlay 实验模式。 | 此設定只套用至目前選取有線裝置的 B AirPlay 實驗模式。 | 此設定只套用至目前選取有線裝置的 B AirPlay 實驗模式。 | This setting applies only to mode B (experimental AirPlay) on the selected USB device. | この設定は、選択したUSBデバイスのモードB（実験的なAirPlay）にだけ適用されます。 | ✅ 完全一致 | 保留 |
| AdvancedSettingsTitle | 高级 USB 设置 | 進階 USB 設定 | 進階 USB 設定 | Advanced USB settings | USBの詳細設定 | ✅ 完全一致 | 保留 |
| AdvancedUsbResolution | USB 请求分辨率 | USB 請求解像度 | USB 請求解析度 | USB request resolution | USB要求の解像度 | ✅ 完全一致 | 保留 |
| AdvancedUsbResolutionHelp | 按宽度、高度输入设备面板像素，例如 12.9 英寸 iPad Pro 为宽 2048、高 2732。实际输出由设备决定，请查看实际分辨率；画面设置中的“原生”只取消本地渲染尺寸限制。 | 按闊度、高度輸入裝置面板像素，例如 12.9 吋 iPad Pro 為闊 2048、高 2732。實際輸出由裝置決定，請查看實際解像度；畫面設定中的「原始」只取消本機繪製尺寸限制。 | 依寬度、高度輸入裝置面板像素，例如 12.9 吋 iPad Pro 為寬 2048、高 2732。實際輸出由裝置決定，請查看實際解析度；畫面設定中的「原始」只取消本機繪製尺寸限制。 | Enter the panel width and height in pixels, for example width 2048 and height 2732 for a 12.9-inch iPad Pro. The device decides the output size; check the actual resolution. Native preview quality only removes the local rendering size limit. | パネルの幅と高さをピクセルで入力します。たとえば12.9インチiPad Proなら、幅2048、高さ2732です。出力サイズはデバイスが決めるため、実際の解像度を確認してください。ネイティブのプレビュー画質は、ローカル描画サイズの制限を外すだけです。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| AirPlayEmptyState | 没有可用的 AirPlay 设备。请先在 iPhone 的“屏幕镜像”中连接此电脑。 | 沒有可用的 AirPlay 裝置。請先在 iPhone 的「螢幕鏡像」連接此電腦。 | 沒有可用的 AirPlay 裝置。請先在 iPhone 的「螢幕鏡像輸出」連線此電腦。 | No AirPlay devices available. Connect to this PC from Screen Mirroring on your iPhone. | 利用できるAirPlayデバイスがありません。iPhoneの画面ミラーリングから、このPCに接続してください。 | ✅ 完全一致 | 保留 |
| AllowUpdateMirrorFallback | 自动选择最快更新下载线路 | 自動選擇最快更新下載線路 | 自動選擇最快更新下載線路 | Automatically select the fastest update route | 最速のアップデート経路を自動で選ぶ | ✅ 完全一致 | 保留 |
| AllowUpdateMirrorFallbackDescription | 测试 GitHub 和全部镜像，仅对可达线路进行 256 KB 下载测速；下载内容仍必须通过官方发布摘要中的 SHA-256 校验。 | 測試 GitHub 和全部鏡像，只對可達線路進行 256 KB 下載測速；下載內容仍必須通過官方發佈摘要中的 SHA-256 驗證。 | 測試 GitHub 和全部鏡像，只對可達線路進行 256 KB 下載測速；下載內容仍必須通過官方發布摘要中的 SHA-256 驗證。 | Tests GitHub and every mirror, then downloads a 256 KB sample from reachable routes; downloads must still pass SHA-256 verification from trusted release metadata. | GitHubとすべてのミラーを調べ、接続できる経路から256KBのサンプルをダウンロードして比べます。ダウンロードしたファイルは、信頼できるリリース情報のSHA-256検証に必ず合格する必要があります。 | ✅ 完全一致 | 保留 |
| AlreadyUpToDate | 当前已是所选发布通道的最新版本。 | 目前已是所選發佈通道的最新版本。 | 目前已是所選發布通道的最新版本。 | You have the latest version in the selected release channel. | 選択したリリースチャンネルでは、最新バージョンを使用中です。 | ✅ 完全一致 | 保留 |
| AppPreferencesTitle | 应用设置 | 應用程式設定 | 應用程式設定 | App settings | アプリの設定 | ✅ 完全一致 | 保留 |
| AppSubtitle | Windows 有线 iPhone/iPad 屏幕采集 | Windows 有線 iPhone/iPad 螢幕擷取 | Windows 有線 iPhone/iPad 螢幕擷取 | Wired iPhone/iPad screen capture for Windows | iPhone/iPadの画面を有線でWindowsに取り込みます | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AppSubtitleConnectivity | Windows USB 低延迟与 AirPlay 无线投屏 | Windows USB 低延遲與 AirPlay 無線螢幕鏡像 | Windows USB 低延遲與 AirPlay 無線螢幕鏡像 | Low-latency USB and wireless AirPlay mirroring for Windows | Windows向けの低遅延なUSBミラーリングと、無線のAirPlayミラーリング | ✅ 完全一致 | 保留 |
| ApplicationModeComplete | 完整模式 | 完整模式 | 完整模式 | Complete | 標準 | ✅ 完全一致 | 保留 |
| ApplicationModeLabel | 应用模式 | 應用模式 | 應用模式 | Application mode | アプリケーションモード | ✅ 完全一致 | 保留 |
| ApplicationModeLightweight | 轻量模式 | 輕量模式 | 輕量模式 | Lightweight | コンパクト | ✅ 完全一致 | 保留 |
| ApplicationModeTray | 托盘模式 | 系統匣模式 | 系統匣模式 | System tray | システムトレイ | ✅ 完全一致 | 保留 |
| AppliedRenderFormat | 已应用本地渲染：{0} · {1} fps | 已套用本機繪製：{0} · {1} fps | 已套用本機繪製：{0} · {1} fps | Local rendering applied: {0} · {1} fps | ローカル描画を適用しました: {0} · {1}fps | ✅ 完全一致 | 保留 |
| AppliedRenderLogFormat | 本地渲染设置：{0} / {1} fps — {2}；来源码流未重连 | 本機繪製設定：{0} / {1} fps — {2}；來源串流未重新連接 | 本機繪製設定：{0} / {1} fps — {2}；來源串流未重新連線 | Local rendering: {0} / {1} fps — {2}; source stream was not reconnected | ローカル描画: {0} / {1}fps — {2}。ソースのストリームは再接続していません | ✅ 完全一致 | 保留 |
| Apply | 应用 | 套用 | 套用 | Apply | 適用 | ✅ 完全一致 | 保留 |
| ApplyBluetoothMouseSettings | 应用设置 | 套用設定 | 套用設定 | Apply settings | 設定を適用 | ✅ 完全一致 | 保留 |
| ApplyLightweightMode | 一键切换轻量模式 | 一鍵切換輕量模式 | 一鍵切換輕量模式 | Switch to lightweight mode | コンパクト表示に切り替える | ✅ 完全一致 | 保留 |
| ApplyReceiverName | 应用 | 套用 | 套用 | Apply | 適用 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ApplySettingsFailedFormat | 应用画面设置失败：{0} | 套用畫面設定失敗：{0} | 套用畫面設定失敗：{0} | Could not apply video settings: {0} | 映像設定を適用できませんでした: {0} | ✅ 完全一致 | 保留 |
| ApplyVideoSettings | 应用画面设置 | 套用畫面設定 | 套用畫面設定 | Apply video settings | 映像設定を適用 | ✅ 完全一致 | 保留 |
| ApplyWirelessSettings | 应用 | 套用 | 套用 | Apply | 適用 | ✅ 完全一致 | 保留 |
| AudioLabel | 音频 | 音訊 | 音訊 | Audio | 音声 | ✅ 完全一致 | 保留 |
| AudioPlaybackEnabled | Windows 声音播放已开启 | Windows 音訊播放已開啟 | Windows 音訊播放已開啟 | Windows audio playback enabled | Windowsでの音声再生をオンにしました | ✅ 完全一致 | 保留 |
| AudioPlaybackMuted | Windows 声音播放已静音 | Windows 音訊播放已靜音 | Windows 音訊播放已靜音 | Windows audio playback muted | Windowsでの音声再生をミュートしました | ✅ 完全一致 | 保留 |
| AudioStateUpdateFailed | 无法更新声音播放状态 | 無法更新音訊播放狀態 | 無法更新音訊播放狀態 | Could not update audio playback | 音声再生の設定を更新できませんでした | ✅ 完全一致 | 保留 |
| AudioToggleUnsupported | 当前核心版本尚不支持运行时声音开关 | 現有核心版本尚不支援在執行階段切換音訊 | 現有核心版本尚不支援在執行階段切換音訊 | This core version does not support changing audio playback at runtime | このコアのバージョンでは、実行中に音声再生を切り替えることはできません | ✅ 完全一致 | 保留 |
| AudioVolumeFormat | Windows 播放音量 {0:F0}% | Windows 播放音量 {0:F0}% | Windows 播放音量 {0:F0}% | Windows playback volume: {0:F0}% | Windowsの再生音量: {0:F0}% | ✅ 完全一致 | 保留 |
| AudioVolumeUnsupported | 当前核心版本尚不支持运行时音量调节 | 現有核心版本尚不支援在執行階段調節音量 | 現有核心版本尚不支援在執行階段調節音量 | This core version does not support runtime volume control | このコアのバージョンでは、実行中に音量を調整することはできません | ✅ 完全一致 | 保留 |
| AudioVolumeUpdateFailed | 无法更新声音音量 | 無法更新音訊音量 | 無法更新音訊音量 | Could not update playback volume | 再生音量を更新できませんでした | ✅ 完全一致 | 保留 |
| AutoDownloadUpdates | 发现更新后自动开始下载 | 發現更新後自動開始下載 | 發現更新後自動開始下載 | Start downloading automatically when an update is found | アップデートが見つかったら自動でダウンロードを開始 | ✅ 完全一致 | 保留 |
| AutomationApply | 应用 | 套用 | 套用 | Apply | 適用 | ✅ 完全一致 | 保留 |
| AutomationCopyAddress | 复制地址 | 複製地址 | 複製位址 | Copy address | アドレスをコピー | ✅ 完全一致 | 保留 |
| AutomationCopyKey | 复制密钥 | 複製金鑰 | 複製金鑰 | Copy key | キーをコピー | ✅ 完全一致 | 保留 |
| AutomationDocs | 打开 API 文档 | 開啟 API 文件 | 開啟 API 文件 | Open API docs | APIドキュメントを開く | ✅ 完全一致 | 保留 |
| AutomationEnable | 启用本地 API | 啟用本機 API | 啟用本機 API | Enable local API | ローカルAPIを有効にする | ✅ 完全一致 | 保留 |
| AutomationHelp | 此处为实际 API 设置。应用后保存，关闭开发者窗口不会停止服务。 | 此處為實際 API 設定。套用後儲存，關閉開發者視窗不會停止服務。 | 此處為實際 API 設定。套用後儲存，關閉開發者視窗不會停止服務。 | These API settings are applied and saved. Closing developer tools keeps the service running. | このAPI設定は適用されて保存されます。開発者ツールを閉じても、サービスは動作し続けます。 | ✅ 完全一致 | 保留 |
| AutomationInvalidPort | 请输入 1024 到 65535 之间的端口。 | 請輸入 1024 到 65535 之間的連接埠。 | 請輸入 1024 到 65535 之間的連接埠。 | Enter a port from 1024 to 65535. | 1024～65535のポートを入力してください。 | ✅ 完全一致 | 保留 |
| AutomationPort | 端口 | 連接埠 | 連接埠 | Port | ポート | ✅ 完全一致 | 保留 |
| AutomationReclaim | 收回设备控制权 | 收回裝置控制權 | 收回裝置控制權 | Reclaim device control | デバイスの操作権を取り戻す | ✅ 完全一致 | 保留 |
| AutomationRegenerate | 重新生成密钥 | 重新產生金鑰 | 重新產生金鑰 | Regenerate key | キーを再生成 | ✅ 完全一致 | 保留 |
| AutomationSaveFailed | 设置保存失败，API 已停止。请检查配置目录的写入权限。 | 設定儲存失敗，API 已停止。請檢查設定目錄的寫入權限。 | 設定儲存失敗，API 已停止。請檢查設定目錄的寫入權限。 | Settings could not be saved; the API has stopped. Check write access to the settings directory. | 設定を保存できなかったため、APIを停止しました。設定フォルダーへの書き込み権限を確認してください。 | ✅ 完全一致 | 保留 |
| AutomationStateFailed | 启动失败，请检查端口和密钥存储 | 啟動失敗，請檢查連接埠和金鑰儲存 | 啟動失敗，請檢查連接埠和金鑰儲存 | Failed — check port and key store | 失敗 — ポートとキーストアを確認してください | ✅ 完全一致 | 保留 |
| AutomationStateRunning | 运行中 | 執行中 | 執行中 | Running | 動作中 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AutomationStateStarting | 正在启动 | 正在啟動 | 正在啟動 | Starting | 起動中 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AutomationStateStopped | 已停止 | 已停止 | 已停止 | Stopped | 停止中 | ✅ 完全一致 | 保留 |
| AutomationTitle | 开发者 / Automation API | 開發者 / Automation API | 開發者 / Automation API | Developer / Automation API | 開発者 / Automation API | ✅ 完全一致 | 保留 |
| BackImageSettings | 返回 | 返回 | 返回 | Back | 戻る | ✅ 完全一致 | 保留 |
| BluetoothClientAddressFormat | 设备 ID：{0} | 裝置 ID：{0} | 裝置 ID：{0} | Device ID: {0} | デバイスID: {0} | ✅ 完全一致 | 保留 |
| BluetoothClientBindingConfirm | 确认绑定 | 確認綁定 | 確認綁定 | Confirm binding | 紐づけを確定 | ✅ 完全一致 | 保留 |
| BluetoothClientBindingHint | 首次使用此投屏设备时，请确认列表中的蓝牙客户端就是当前设备。之后切换选项卡会自动使用此绑定。 | 首次使用此螢幕鏡像裝置時，請確認清單中的藍牙用戶端就是目前裝置。之後切換分頁會自動使用此綁定。 | 首次使用此螢幕鏡像裝置時，請確認清單中的藍牙用戶端就是目前裝置。之後切換分頁會自動使用此綁定。 | The first time you use this mirrored device, confirm which Bluetooth client belongs to it. Future tab switches will use this binding automatically. | このミラーリング中のデバイスを初めて使うときは、対応するBluetoothクライアントを確認してください。次回からのタブの切り替えでは、この紐づけが自動で使われます。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| BluetoothClientBindingRefresh | 刷新蓝牙客户端 | 重新整理藍牙用戶端 | 重新整理藍牙用戶端 | Refresh Bluetooth clients | Bluetoothクライアントを更新 | ✅ 完全一致 | 保留 |
| BluetoothClientBindingTargetFormat | 请选择与“{0}”对应的蓝牙手机 | 請選擇與「{0}」對應的藍牙手機 | 請選擇與「{0}」對應的藍牙手機 | Choose the Bluetooth phone for “{0}” | 「{0}」に対応するBluetoothのiPhoneを選んでください | ✅ 完全一致 | 保留 |
| BluetoothClientBindingTitle | 绑定蓝牙手机 | 綁定藍牙手機 | 綁定藍牙手機 | Bind Bluetooth phone | BluetoothのiPhoneを紐づけ | ✅ 完全一致 | 保留 |
| BluetoothClientBindingUnbind | 解除绑定 | 解除綁定 | 解除綁定 | Unbind | 紐づけを解除 | ✅ 完全一致 | 保留 |
| BluetoothClientBoundToFormat | 已绑定到：{0} | 已綁定至：{0} | 已綁定至：{0} | Bound to: {0} | 紐づけ先: {0} | ✅ 完全一致 | 保留 |
| BluetoothClientConnectionTimeFormat | 本次连接：{0} | 目前連接：{0} | 目前連線：{0} | Connected: {0} | 接続: {0} | ✅ 完全一致 | 保留 |
| BluetoothClientUnknownName | 未命名蓝牙设备 | 未命名藍牙裝置 | 未命名藍牙裝置 | Unnamed Bluetooth device | 名前のないBluetoothデバイス | ✅ 完全一致 | 保留 |
| BluetoothControlConnected | iPhone/iPad 已连接蓝牙控制 | iPhone/iPad 已連接藍牙控制 | iPhone/iPad 已連線藍牙控制 | iPhone/iPad connected for Bluetooth control | Bluetooth操作用にiPhone/iPadが接続されました | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为蓝牙控制 |
| BluetoothControlFailedBody | Windows 未能启动 BLE HID 外设服务。请检查蓝牙适配器和驱动是否支持外设模式。 | Windows 未能啟動 BLE HID 外設服務。請檢查藍牙適配器和驅動是否支援外設模式。 | Windows 無法啟動 BLE HID 周邊服務。請檢查藍牙介面卡和驅動程式是否支援周邊模式。 | Windows could not start the BLE HID peripheral service. Check whether the Bluetooth adapter and driver support peripheral mode. | WindowsでBLE HIDペリフェラルサービスを開始できませんでした。Bluetoothアダプターとドライバーがペリフェラルモードに対応しているか確認してください。 | ✅ 完全一致 | 保留 |
| BluetoothControlFailedStatus | 启动失败 | 啟動失敗 | 啟動失敗 | Startup failed | 開始に失敗しました | ✅ 完全一致 | 保留 |
| BluetoothControlFailedTitle | 蓝牙控制无法启动 | 藍牙控制無法啟動 | 藍牙控制無法啟動 | Bluetooth control could not start | Bluetooth操作を開始できませんでした | ✅ 完全一致 | 保留 |
| BluetoothControlLabel | 蓝牙控制 | 藍牙控制 | 藍牙控制 | Bluetooth control | Bluetooth操作 | ✅ 完全一致 | 保留 |
| BluetoothControlOff | 蓝牙控制未启用 | 藍牙控制未啟用 | 藍牙控制未啟用 | Bluetooth control is off | Bluetooth操作はオフです | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为蓝牙控制 |
| BluetoothControlPairStepFive | iPhone：若再次出现配对提示窗口，点击“配对”。 | iPhone：若再次出現配對提示視窗，點選「配對」。 | iPhone：若再次出現配對提示視窗，點選「配對」。 | iPhone: If another pairing prompt appears, tap Pair again. | iPhone: 別のペアリングの確認が表示されたら、もう一度「ペアリング」をタップします。 | ✅ 完全一致 | 保留 |
| BluetoothControlPairStepFour | Windows：在系统蓝牙配对窗口中点击“配对”。 | Windows：在系統藍牙配對視窗中點選「配對」。 | Windows：在系統藍牙配對視窗中點選「配對」。 | Windows: Click Pair in the system Bluetooth pairing dialog. | Windows: システムのBluetoothペアリングのダイアログで「ペアリング」をクリックします。 | ✅ 完全一致 | 保留 |
| BluetoothControlPairStepOneFormat | iPhone：打开“设置 → 辅助功能 → 触控 → 辅助触控”，开启“辅助触控”。 | iPhone：開啟「設定 → 輔助使用 → 觸控 → 輔助觸控」，開啟「輔助觸控」。 | iPhone：開啟「設定 → 輔助使用 → 觸控 → 輔助觸控」，開啟「輔助觸控」。 | iPhone: Open Settings → Accessibility → Touch → AssistiveTouch, then turn on AssistiveTouch. | iPhone: 「設定」→「アクセシビリティ」→「タッチ」→「AssistiveTouch」を開き、AssistiveTouchをオンにします。 | ✅ 完全一致 | 保留 |
| BluetoothControlPairStepThree | Windows：右下角出现“添加设备 - 点击以设置 iPhone”时，点击该系统通知。 | Windows：右下角出現「新增裝置 - 點選以設定 iPhone」時，點選系統通知。 | Windows：右下角出現「新增裝置 - 點選以設定 iPhone」時，點選系統通知。 | Windows: Click the “Add a device - click to set up iPhone” notification in the bottom-right corner. | Windows: 右下に表示される「デバイスを追加 - クリックしてiPhoneをセットアップ」の通知をクリックします。 | ✅ 完全一致 | 保留 |
| BluetoothControlPairStepTwo | iPhone：打开“设置 → 蓝牙”，连接“{0}”，然后点击“配对”。 | iPhone：開啟「設定 → 藍牙」，連接「{0}」，然後點選「配對」。 | iPhone：開啟「設定 → 藍牙」，連線「{0}」，然後點選「配對」。 | iPhone: Open Settings → Bluetooth, connect “{0}”, then tap Pair. | iPhone: 「設定」→「Bluetooth」を開き、「{0}」に接続して「ペアリング」をタップします。 | ✅ 完全一致 | 保留 |
| BluetoothControlPromptAutoCloseFormat | {0} 秒后自动关闭 | {0} 秒後自動關閉 | {0} 秒後自動關閉 | Closes automatically in {0} s | {0}秒後に自動で閉じます | ⚠️ 需要优化 → ✅ 已修复 | 秒使用单位 s，适用于倒计时 1 秒 |
| BluetoothControlPromptBodyFormat | Windows 鼠标输入已转发到 iPhone/iPad。按 {0} 释放鼠标并暂停输入，再按一次恢复控制。 | Windows 滑鼠輸入已轉發到 iPhone/iPad。按 {0} 釋放滑鼠並暫停輸入，再按一次恢復控制。 | Windows 滑鼠輸入已轉發到 iPhone/iPad。按 {0} 釋放滑鼠並暫停輸入，再按一次恢復控制。 | Windows mouse input is now redirected to the iPhone/iPad. Press {0} to release the mouse and pause input; press it again to resume control. | Windowsのマウス入力がiPhone/iPadに転送されます。{0}を押すとマウスを解放して入力を一時停止し、もう一度押すと操作を再開します。 | ✅ 完全一致 | 保留 |
| BluetoothControlPromptDetail | 反向控制期间 Windows 光标会隐藏。 | 反向控制期間 Windows 游標會隱藏。 | 反向控制期間 Windows 游標會隱藏。 | The Windows cursor is hidden while reverse control is active. | リモート操作中は、Windowsのカーソルが非表示になります。 | ✅ 完全一致 | 保留 |
| BluetoothControlPromptShortcutFormat | 按 {0} 释放鼠标 | 按 {0} 釋放滑鼠 | 按 {0} 釋放滑鼠 | Press {0} to release the mouse | {0}を押すとマウスを解放します | ❌ 含义不一致 → ✅ 已修复 | 补齐释放对象 |
| BluetoothControlPromptTitle | 蓝牙控制已开启 | 藍牙控制已啟用 | 藍牙控制已啟用 | Bluetooth control enabled | Bluetooth操作を有効にしました | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为蓝牙控制 |
| BluetoothControlReportMapChangedBody | 此更新修改了蓝牙 HID 控制。请在 iPhone/iPad 上忽略现有的 iPhoneMirror 设备，然后重新配对，再启用控制。 | 此更新修改了藍牙 HID 控制。請在 iPhone/iPad 上忽略現有的 iPhoneMirror 裝置，然後重新配對，再啟用控制。 | 此更新修改了藍牙 HID 控制。請在 iPhone/iPad 上忽略現有的 iPhoneMirror 裝置，然後重新配對，再啟用控制。 | This update changes the Bluetooth HID controls. On the iPhone/iPad, forget the existing iPhoneMirror device, then pair it again before enabling control. | このアップデートでBluetooth HIDの操作が変わりました。iPhone/iPadで既存のiPhoneMirrorデバイスを削除し、もう一度ペアリングしてから、操作を有効にしてください。 | ✅ 完全一致 | 保留 |
| BluetoothControlReportMapChangedConfirm | 我已重新配对 | 我已重新配對 | 我已重新配對 | I have re-paired | ペアリングし直しました | ✅ 完全一致 | 保留 |
| BluetoothControlReportMapChangedDetail | 移除旧配对后关闭此提示。完成新配对后再次启用蓝牙控制。 | 移除舊配對後關閉此提示。完成新配對後再次啟用藍牙控制。 | 移除舊配對後關閉此提示。完成新配對後再次啟用藍牙控制。 | Close this message after the old pairing has been removed. Enable Bluetooth control again after completing the new pairing. | 古いペアリングを削除してから、このメッセージを閉じてください。新しいペアリングを完了したら、Bluetooth操作をもう一度有効にします。 | ✅ 完全一致 | 保留 |
| BluetoothControlReportMapChangedStatus | 需要重新配对 | 需要重新配對 | 需要重新配對 | Pairing required again | ペアリングのやり直しが必要です | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| BluetoothControlReportMapChangedTitle | 蓝牙控制需要重新配对 | 藍牙控制需要重新配對 | 藍牙控制需要重新配對 | Bluetooth control needs to be paired again | Bluetooth操作のペアリングをやり直す必要があります | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| BluetoothControlStartFailedFormat | 蓝牙控制启动失败：{0} | 藍牙控制啟動失敗：{0} | 藍牙控制啟動失敗：{0} | Bluetooth control startup failed: {0} | Bluetooth操作を開始できませんでした: {0} | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为蓝牙控制 |
| BluetoothControlWaiting | 蓝牙控制已广播，正在等待 iPhone/iPad 连接 | 藍牙控制已廣播，正在等待 iPhone/iPad 連接 | 藍牙控制已廣播，正在等待 iPhone/iPad 連線 | Bluetooth control is advertising and waiting for an iPhone/iPad | Bluetooth操作を公開し、iPhone/iPadを待っています | ✅ 完全一致 | 保留 |
| BluetoothControlWaitingBody | 请按以下顺序完成 iPhone 与 Windows 的系统配对。若 Windows 已连接过此 HID 设备，请先在蓝牙设置中断开，再重新启用控制并重新连接。 | 請依序完成 iPhone 與 Windows 的系統配對。若 Windows 已連接過此 HID 裝置，請先在藍牙設定中斷開，再重新啟用控制並重新連接。 | 請依序完成 iPhone 與 Windows 的系統配對。若 Windows 已連線過此 HID 裝置，請先在藍牙設定中中斷連線，再重新啟用控制並重新連線。 | Complete the iPhone and Windows system pairing in this order. If Windows is already connected to this HID device, disconnect it in Bluetooth settings before enabling control again and reconnecting. | iPhoneとWindowsのシステムペアリングを、次の順に完了してください。WindowsがすでにこのHIDデバイスに接続されている場合は、Bluetoothの設定で切断してから、操作を有効にし直して接続してください。 | ✅ 完全一致 | 保留 |
| BluetoothControlWaitingDetail | 连接后会弹出蓝牙客户端绑定窗口，请选择对应手机。绑定完成前不会发送输入；等待期间鼠标不会被隐藏或限制。 | 連接後會顯示藍牙用戶端綁定視窗，請選擇對應手機。完成綁定前不會傳送輸入；等待期間滑鼠不會被隱藏或限制。 | 連線後會顯示藍牙用戶端綁定視窗，請選擇對應手機。完成綁定前不會傳送輸入；等待期間滑鼠不會被隱藏或限制。 | After the phone connects, a Bluetooth client binding window will appear. Choose the matching phone; no input is sent before binding is confirmed, and the mouse remains available while waiting. | iPhoneが接続されると、Bluetoothクライアントの紐づけウィンドウが表示されます。該当するiPhoneを選んでください。紐づけが確定するまで入力は送信されず、待機中もマウスは使えます。 | ✅ 完全一致 | 保留 |
| BluetoothControlWaitingStatus | 等待 HID 鼠标连接 | 等待 HID 滑鼠連接 | 等待 HID 滑鼠連線 | Waiting for HID mouse connection | HIDマウスの接続を待っています | ✅ 完全一致 | 保留 |
| BluetoothControlWaitingTargetFormat | 设备列表中通常显示为：{0} | 裝置清單中通常顯示為：{0} | 裝置清單中通常顯示為：{0} | This PC usually appears in the device list as: {0} | このPCは、通常デバイス一覧に次の名前で表示されます: {0} | ✅ 完全一致 | 保留 |
| BluetoothControlWaitingTitle | 正在等待蓝牙控制连接 | 正在等待藍牙控制連接 | 正在等待藍牙控制連線 | Waiting for Bluetooth control | Bluetooth操作を待機中 | ✅ 完全一致 | 保留 |
| BluetoothCurrentOrientationFormat | 当前设备方向：{0}（{1}） | 目前裝置方向：{0}（{1}） | 目前裝置方向：{0}（{1}） | Current device orientation: {0} ({1}) | 現在のデバイスの向き: {0}（{1}） | ✅ 完全一致 | 保留 |
| BluetoothDeviceOrientationLandscape | 横屏 | 橫向 | 橫向 | Landscape | 横向き | ✅ 完全一致 | 保留 |
| BluetoothDeviceOrientationPortrait | 竖屏 | 直向 | 直向 | Portrait | 縦向き | ✅ 完全一致 | 保留 |
| BluetoothDeviceOrientationUnknown | 未识别 | 未識別 | 未識別 | Unknown | 不明 | ✅ 完全一致 | 保留 |
| BluetoothEmptyState | 未发现已连接的蓝牙设备。请完成配对后刷新。 | 找不到已連接的藍牙裝置。請完成配對後重新整理。 | 找不到已連線的藍牙裝置。請完成配對後重新整理。 | No connected Bluetooth devices found. Complete pairing, then refresh. | 接続済みのBluetoothデバイスが見つかりません。ペアリングを完了してから更新してください。 | ✅ 完全一致 | 保留 |
| BluetoothHidAdvertisingFailed | 蓝牙 HID 控制未能开始广播。 | 藍牙 HID 控制未能開始廣播。 | 藍牙 HID 控制未能開始廣播。 | Bluetooth HID control did not start advertising. | Bluetooth HID操作がアドバタイズを開始しませんでした。 | ✅ 完全一致 | 保留 |
| BluetoothHidAdvertisingFormat | 蓝牙 HID 控制正在广播（{0}）。 | 藍牙 HID 控制正在廣播（{0}）。 | 藍牙 HID 控制正在廣播（{0}）。 | Bluetooth HID control is advertising ({0}). | Bluetooth HID操作はアドバタイズ中です（{0}）。 | ✅ 完全一致 | 保留 |
| BluetoothHidAdvertisingNotReported | 蓝牙协议栈未报告广播状态。 | 藍牙協定堆疊未回報廣播狀態。 | 藍牙協定堆疊未回報廣播狀態。 | The Bluetooth stack did not report an advertising state. | Bluetoothスタックがアドバタイズの状態を報告しませんでした。 | ✅ 完全一致 | 保留 |
| BluetoothHidCharacteristicFailedFormat | 无法创建蓝牙 HID 特征 {0}：{1} | 無法建立藍牙 HID 特徵 {0}：{1} | 無法建立藍牙 HID 特徵 {0}：{1} | Could not create Bluetooth HID characteristic {0}: {1} | Bluetooth HIDのキャラクタリスティック{0}を作成できませんでした: {1} | ❌ 缺失 → ✅ 已修复 | 补齐蓝牙启动失败详情中的第一方提示；保留系统错误码 |
| BluetoothHidClientIdentificationFailed | 无法识别选定的蓝牙客户端。 | 無法識別所選藍牙用戶端。 | 無法識別所選藍牙用戶端。 | Could not identify the selected Bluetooth client. | 選択したBluetoothクライアントを識別できませんでした。 | ✅ 完全一致 | 保留 |
| BluetoothHidClientRefreshFailed | 断开连接后无法刷新蓝牙客户端。 | 中斷連接後無法重新整理藍牙用戶端。 | 中斷連線後無法重新整理藍牙用戶端。 | Could not refresh Bluetooth clients after disconnect. | 切断後にBluetoothクライアントを更新できませんでした。 | ✅ 完全一致 | 保留 |
| BluetoothHidDisconnected | 蓝牙 HID 控制已断开。 | 藍牙 HID 控制已中斷。 | 藍牙 HID 控制已中斷。 | Bluetooth HID control disconnected. | Bluetooth HID操作が切断されました。 | ✅ 完全一致 | 保留 |
| BluetoothHidLowEnergyUnsupported | 蓝牙适配器不支持低功耗蓝牙。 | 藍牙適配器不支援低功耗藍牙。 | 藍牙介面卡不支援低功耗藍牙。 | The Bluetooth adapter does not support Bluetooth Low Energy. | このBluetoothアダプターはBluetooth Low Energyに対応していません。 | ✅ 完全一致 | 保留 |
| BluetoothHidMultipleClientsWaiting | 多个蓝牙客户端已连接，正在等待选定的 iPhone/iPad。 | 多個藍牙用戶端已連接，正在等待所選 iPhone/iPad。 | 多個藍牙用戶端已連線，正在等待所選 iPhone/iPad。 | Multiple Bluetooth clients are connected; waiting for the selected iPhone/iPad. | 複数のBluetoothクライアントが接続されています。選択したiPhone/iPadを待機しています。 | ✅ 完全一致 | 保留 |
| BluetoothHidNotificationStalled | 蓝牙 HID 鼠标通知已停滞。 | 藍牙 HID 滑鼠通知已停滯。 | 藍牙 HID 滑鼠通知已停滯。 | Bluetooth HID mouse notification stalled. | Bluetooth HIDマウスの通知が停止しました。 | ✅ 完全一致 | 保留 |
| BluetoothHidPeripheralSupported | 蓝牙适配器支持 BLE 外设模式。 | 藍牙適配器支援 BLE 外設模式。 | 藍牙介面卡支援 BLE 周邊模式。 | Bluetooth adapter supports BLE peripheral mode. | BluetoothアダプターはBLEペリフェラルモードに対応しています。 | ✅ 完全一致 | 保留 |
| BluetoothHidPeripheralTrying | 尚未确认蓝牙适配器的外设能力，正在尝试 GATT 广播。 | 尚未確認藍牙適配器的外設能力，正在嘗試 GATT 廣播。 | 尚未確認藍牙介面卡的周邊能力，正在嘗試 GATT 廣播。 | Bluetooth adapter peripheral capability is unconfirmed; trying GATT advertising. | Bluetoothアダプターのペリフェラル機能を確認できません。GATTアドバタイズを試しています。 | ✅ 完全一致 | 保留 |
| BluetoothHidPeripheralUnavailable | 此蓝牙适配器无法作为 BLE 外设。 | 此藍牙適配器無法作為 BLE 外設。 | 此藍牙介面卡無法作為 BLE 周邊。 | This Bluetooth adapter cannot act as a BLE peripheral. | このBluetoothアダプターはBLEペリフェラルとして動作できません。 | ✅ 完全一致 | 保留 |
| BluetoothHidReportBootKeyboard | HID 启动协议键盘报告 | HID 啟動協定鍵盤報告 | HID 啟動協定鍵盤報告 | HID boot keyboard report | HIDブートキーボードレポート | ✅ 完全一致 | 保留 |
| BluetoothHidReportBootMouse | HID 启动协议鼠标报告 | HID 啟動協定滑鼠報告 | HID 啟動協定滑鼠報告 | HID boot mouse report | HIDブートマウスレポート | ✅ 完全一致 | 保留 |
| BluetoothHidReportConsumer | HID 媒体控制报告 | HID 媒體控制報告 | HID 媒體控制報告 | HID consumer-control report | HIDコンシューマーコントロールレポート | ✅ 完全一致 | 保留 |
| BluetoothHidReportDescriptorFailedFormat | 无法创建蓝牙 HID 报告描述符：{0} | 無法建立藍牙 HID 報告描述符：{0} | 無法建立藍牙 HID 報告描述元：{0} | Could not create the Bluetooth HID report descriptor: {0} | Bluetooth HIDのレポートディスクリプターを作成できませんでした: {0} | ❌ 缺失 → ✅ 已修复 | 补齐蓝牙启动失败详情中的第一方提示；保留系统错误码 |
| BluetoothHidReportKeyboard | HID 键盘报告 | HID 鍵盤報告 | HID 鍵盤報告 | HID keyboard report | HIDキーボードレポート | ✅ 完全一致 | 保留 |
| BluetoothHidReportMouse | HID 鼠标报告 | HID 滑鼠報告 | HID 滑鼠報告 | HID mouse report | HIDマウスレポート | ✅ 完全一致 | 保留 |
| BluetoothHidReportNavigation | HID 导航控制报告 | HID 導航控制報告 | HID 導航控制報告 | HID navigation-control report | HIDナビゲーションコントロールレポート | ✅ 完全一致 | 保留 |
| BluetoothHidRouteResetting | 正在重置蓝牙 HID 通道。 | 正在重設藍牙 HID 通道。 | 正在重設藍牙 HID 通道。 | The Bluetooth HID route is being reset. | Bluetooth HIDの経路をリセットしています。 | ✅ 完全一致 | 保留 |
| BluetoothHidSelectedConnected | 选定的蓝牙 HID 客户端已连接。 | 所選藍牙 HID 用戶端已連接。 | 所選藍牙 HID 用戶端已連線。 | A selected Bluetooth HID client is connected. | 選択したBluetooth HIDクライアントが接続されています。 | ✅ 完全一致 | 保留 |
| BluetoothHidServiceCreateFailed | 无法创建蓝牙 HID 服务。 | 無法建立藍牙 HID 服務。 | 無法建立藍牙 HID 服務。 | Could not create the Bluetooth HID service. | Bluetooth HIDサービスを作成できませんでした。 | ✅ 完全一致 | 保留 |
| BluetoothHidServiceCreateResultFormat | GattServiceProvider.CreateAsync 返回 {0}。 | GattServiceProvider.CreateAsync 傳回 {0}。 | GattServiceProvider.CreateAsync 傳回 {0}。 | GattServiceProvider.CreateAsync returned {0}. | GattServiceProvider.CreateAsyncが{0}を返しました。 | ✅ 完全一致 | 保留 |
| BluetoothHidStartFailed | 无法启动蓝牙 HID 控制。 | 無法啟動藍牙 HID 控制。 | 無法啟動藍牙 HID 控制。 | Bluetooth HID control could not start. | Bluetooth HID操作を開始できませんでした。 | ✅ 完全一致 | 保留 |
| BluetoothHidStoppedUnexpectedly | 蓝牙 HID 控制意外停止。 | 藍牙 HID 控制意外停止。 | 藍牙 HID 控制意外停止。 | Bluetooth HID control stopped unexpectedly. | Bluetooth HID操作が予期せず停止しました。 | ✅ 完全一致 | 保留 |
| BluetoothHidSubscribedFormat | 选定的 iPhone/iPad 已订阅{0}。 | 所選 iPhone/iPad 已訂閱{0}。 | 所選 iPhone/iPad 已訂閱{0}。 | Selected iPhone/iPad subscribed to the {0}. | 選択したiPhone/iPadが{0}を購読しました。 | ✅ 完全一致 | 保留 |
| BluetoothHidWaitingClient | 蓝牙 HID 控制正在广播，等待客户端连接。 | 藍牙 HID 控制正在廣播，等待用戶端連接。 | 藍牙 HID 控制正在廣播，等待用戶端連線。 | Bluetooth HID control is advertising; waiting for a client. | Bluetooth HID操作はアドバタイズ中です。クライアントを待機しています。 | ✅ 完全一致 | 保留 |
| BluetoothHidWaitingMouseReport | 选定的蓝牙客户端已连接，正在等待其 HID 鼠标报告。 | 所選藍牙用戶端已連接，正在等待其 HID 滑鼠報告。 | 所選藍牙用戶端已連線，正在等待其 HID 滑鼠報告。 | The selected Bluetooth client is connected; waiting for its HID mouse report. | 選択したBluetoothクライアントは接続されています。HIDマウスレポートを待機しています。 | ✅ 完全一致 | 保留 |
| BluetoothHidWaitingSelected | 蓝牙客户端已连接，正在等待选定的 iPhone/iPad。 | 藍牙用戶端已連接，正在等待所選 iPhone/iPad。 | 藍牙用戶端已連線，正在等待所選 iPhone/iPad。 | Bluetooth clients are connected; waiting for the selected iPhone/iPad. | Bluetoothクライアントは接続されています。選択したiPhone/iPadを待機しています。 | ✅ 完全一致 | 保留 |
| BluetoothHidWheelDescriptorFailedFormat | 无法创建蓝牙 HID 滚轮功能描述符：{0} | 無法建立藍牙 HID 滾輪功能描述符：{0} | 無法建立藍牙 HID 滾輪功能描述元：{0} | Could not create the Bluetooth HID wheel feature descriptor: {0} | Bluetooth HIDのホイールフィーチャーディスクリプターを作成できませんでした: {0} | ❌ 缺失 → ✅ 已修复 | 补齐蓝牙启动失败详情中的第一方提示；保留系统错误码 |
| BluetoothHidWheelMultiplierFormat | HID 滚轮分辨率倍数已设为 {0}。 | HID 滾輪解像度倍數已設為 {0}。 | HID 滾輪解析度倍數已設為 {0}。 | HID wheel resolution multiplier set to {0}. | HIDホイール解像度の倍率を{0}に設定しました。 | ✅ 完全一致 | 保留 |
| BluetoothLandscapeMouseDirection | 横屏鼠标方向 | 橫向滑鼠方向 | 橫向滑鼠方向 | Landscape mouse direction | 横向きのマウスの方向 | ✅ 完全一致 | 保留 |
| BluetoothLandscapeMouseLeft90 | 向左 90° | 向左 90° | 向左 90° | Left 90° | 左90° | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性；静态未发现引用，保留待后续调用核对 |
| BluetoothLandscapeMouseLeft90Reverse | 向左 90°（反向） | 向左 90°（反向） | 向左 90°（反向） | Left 90° (reversed) | 左90°（反転） | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性；静态未发现引用，保留待后续调用核对 |
| BluetoothLandscapeMouseRight90 | 向右 90° | 向右 90° | 向右 90° | Right 90° | 右90° | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性；静态未发现引用，保留待后续调用核对 |
| BluetoothLandscapeMouseRight90Reverse | 向右 90°（反向） | 向右 90°（反向） | 向右 90°（反向） | Right 90° (reversed) | 右90°（反転） | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性；静态未发现引用，保留待后续调用核对 |
| BluetoothMouseDirectionDown | 下 | 下 | 下 | Down | 下 | ✅ 完全一致 | 保留 |
| BluetoothMouseDirectionHelp | 方向按当前画面宽高自动识别；独立窗口旋转会自动计入。 | 方向會按目前畫面寬高自動識別；獨立視窗旋轉會自動計入。 | 方向會按目前畫面寬高自動識別；獨立視窗旋轉會自動計入。 | Orientation is detected from the current frame size; independent-window rotation is included automatically. | 向きは現在のフレームサイズから検出します。独立ウィンドウの回転も自動で反映されます。 | ✅ 完全一致 | 保留 |
| BluetoothMouseDirectionLeft | 左 | 左 | 左 | Left | 左 | ✅ 完全一致 | 保留 |
| BluetoothMouseDirectionRight | 右 | 右 | 右 | Right | 右 | ✅ 完全一致 | 保留 |
| BluetoothMouseDirectionUp | 上 | 上 | 上 | Up | 上 | ✅ 完全一致 | 保留 |
| BluetoothMouseSensitivity | 蓝牙鼠标灵敏度 | 藍牙滑鼠靈敏度 | 藍牙滑鼠靈敏度 | Bluetooth mouse sensitivity | Bluetoothマウスの感度 | ✅ 完全一致 | 保留 |
| BluetoothMouseSettingsSaveFailed | 蓝牙反向控制鼠标设置保存失败 | 藍牙反向控制滑鼠設定儲存失敗 | 藍牙反向控制滑鼠設定儲存失敗 | Could not save Bluetooth control mouse settings | Bluetooth操作のマウス設定を保存できませんでした | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| BluetoothMouseSettingsTitle | 反向控制设置 | 反向控制設定 | 反向控制設定 | Reverse control settings | リモート操作の設定 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| BluetoothPortraitMouseDirection | 竖屏鼠标方向 | 直向滑鼠方向 | 直向滑鼠方向 | Portrait mouse direction | 縦向きのマウスの方向 | ✅ 完全一致 | 保留 |
| BluetoothReverseHorizontal | 左右反转 | 左右反轉 | 左右反轉 | Reverse left/right | 左右を反転 | ✅ 完全一致 | 保留 |
| BluetoothReverseVertical | 上下反转 | 上下反轉 | 上下反轉 | Reverse up/down | 上下を反転 | ✅ 完全一致 | 保留 |
| BluetoothWheelSensitivity | 滚轮灵敏度 | 滾輪靈敏度 | 滾輪靈敏度 | Wheel sensitivity | ホイールの感度 | ✅ 完全一致 | 保留 |
| BrightnessLabel | 亮度 | 亮度 | 亮度 | Brightness | 明るさ | ✅ 完全一致 | 保留 |
| Cancel | 取消 | 取消 | 取消 | Cancel | キャンセル | ✅ 完全一致 | 保留 |
| CannotStartCapture | 无法开始投屏 | 無法開始螢幕鏡像 | 無法開始螢幕鏡像 | Could not start mirroring | ミラーリングを開始できませんでした | ✅ 完全一致 | 保留 |
| CaptureActionDeviceDisconnected | 请重新连接并解锁设备后，再次开始投屏。 | 請重新連接並解鎖裝置後，再次開始螢幕鏡像。 | 請重新連線並解鎖裝置後，再次開始螢幕鏡像。 | Reconnect and unlock the device, then start mirroring again. | デバイスをつなぎ直してロックを解除し、もう一度ミラーリングを開始してください。 | ✅ 完全一致 | 保留 |
| CaptureActionDriverRecovery | 请重新插拔设备后再试；仍无法投屏时重启电脑。 | 請重新插拔裝置後再試；仍無法螢幕鏡像時請重新啟動電腦。 | 請重新插拔裝置後再試；仍無法螢幕鏡像時請重新啟動電腦。 | Reconnect the device, then try again. If it still fails, restart the computer. | デバイスをつなぎ直して、もう一度お試しください。それでも失敗する場合は、コンピュータを再起動してください。 | ✅ 完全一致 | 保留 |
| CaptureActionReconnectDevice | 请保持设备解锁，重新插拔数据线后再试。 | 請保持裝置解鎖，重新插拔數據線後再試。 | 請保持裝置解鎖，重新插拔傳輸線後再試。 | Keep the device unlocked, reconnect the cable, then try again. | デバイスのロックを解除したままケーブルをつなぎ直し、もう一度お試しください。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| CaptureActionRestartApplication | 请关闭后重新打开 iPhoneMirror，再试一次。 | 請關閉後重新開啟 iPhoneMirror，再試一次。 | 請關閉後重新開啟 iPhoneMirror，再試一次。 | Close and reopen iPhoneMirror, then try again. | iPhoneMirrorをいったん閉じて開き直し、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| CaptureActionRestartDevice | 请重启 iPhone 或 iPad 后再试。 | 請重新啟動 iPhone 或 iPad 後再試。 | 請重新啟動 iPhone 或 iPad 後再試。 | Restart the iPhone or iPad, then try again. | iPhoneまたはiPadを再起動して、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| CaptureActionRetry | 请停止投屏后重新开始；仍失败时重新连接设备。 | 請停止螢幕鏡像後重新開始；仍失敗時重新連接裝置。 | 請停止螢幕鏡像後重新開始；仍失敗時重新連線裝置。 | Stop and start mirroring again. If it still fails, reconnect the device. | ミラーリングをいったん停止して、もう一度開始してください。それでも失敗する場合は、デバイスをつなぎ直してください。 | ✅ 完全一致 | 保留 |
| CaptureActionVideoRetry | 请停止投屏后重新开始；仍无画面时重新连接数据线。 | 請停止螢幕鏡像後重新開始；仍無畫面時重新連接數據線。 | 請停止螢幕鏡像後重新開始；仍無畫面時重新連線傳輸線。 | Stop and start mirroring again. If there is still no picture, reconnect the cable. | ミラーリングをいったん停止して、もう一度開始してください。それでも映像が出ない場合は、ケーブルをつなぎ直してください。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| CaptureActionWaitForCleanup | 请等待设备清理完成后，再次开始投屏。 | 請等待裝置清理完成後，再次開始螢幕鏡像。 | 請等待裝置清理完成後，再次開始螢幕鏡像。 | Wait for device cleanup to finish, then start mirroring again. | デバイスの整理が終わるまで待ってから、もう一度ミラーリングを開始してください。 | ✅ 完全一致 | 保留 |
| CaptureActivating | 正在启用 USB 投屏接口… | 正在啟用 USB 螢幕鏡像介面… | 正在啟用 USB 螢幕鏡像介面… | Activating the USB mirroring interface… | USBミラーリングのインターフェースを有効にしています… | ✅ 完全一致 | 保留 |
| CaptureCleaningDevice | 正在清理设备…如系统请求权限，请允许设备自动重连。 | 正在清理裝置…若系統要求權限，請允許裝置自動重新連接。 | 正在清理裝置…若系統要求權限，請允許裝置自動重新連線。 | Cleaning up device… Allow automatic reconnection if Windows requests permission. | デバイスを整理しています… Windowsから許可を求められたら、自動再接続を許可してください。 | ✅ 完全一致 | 保留 |
| CaptureDriverSafetyBlocked | 检测到旧版 libusb0 与 Apple USB 过滤驱动叠加。应用不会修改驱动；本次将使用保守的 USB 会话打开和释放顺序。 | 偵測到舊版 libusb0 與 Apple USB 篩選驅動程式疊加。應用程式不會修改驅動程式；本次會使用保守的 USB 工作階段開啟及釋放順序。 | 偵測到舊版 libusb0 與 Apple USB 篩選驅動程式疊加。應用程式不會修改驅動程式；本次會使用保守的 USB 工作階段開啟及釋放順序。 | Legacy libusb0 and Apple USB filters are stacked. The installed drivers are unchanged; this session uses a conservative USB open and teardown order. | 従来のlibusb0とAppleのUSBフィルターが重なっています。インストール済みのドライバーは変更していません。このセッションでは、保守的な順序でUSBを開き、終了します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| CaptureError | 投屏出现错误 | 螢幕鏡像出現錯誤 | 螢幕鏡像出現錯誤 | Mirroring error | ミラーリングエラー | ✅ 完全一致 | 保留 |
| CaptureErrorFormat | 投屏错误：{0} | 螢幕鏡像錯誤：{0} | 螢幕鏡像錯誤：{0} | Mirroring error: {0} | ミラーリングエラー: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| CaptureFailureChildProcess | 子进程异常退出 | 子程序異常結束 | 子程序異常結束 | Child process exited unexpectedly | 子プロセスが予期せず終了しました | ✅ 完全一致 | 保留 |
| CaptureFailureDetailsFormat | 错误类型：{0}<br>失败阶段：{1}<br>错误码：{2}<br><br>详细信息：{3} | 錯誤類型：{0}<br>失敗階段：{1}<br>錯誤碼：{2}<br><br>詳細資料：{3} | 錯誤類型：{0}<br>失敗階段：{1}<br>錯誤碼：{2}<br><br>詳細資料：{3} | Error type: {0}<br>Failure stage: {1}<br>Error code: {2}<br><br>Details: {3} | エラーの種類: {0}<br>失敗した段階: {1}<br>エラーコード: {2}<br><br>詳細: {3} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| CaptureFailureDeviceDisconnected | 设备已断开 | 裝置已中斷連接 | 裝置已中斷連線 | Device disconnected | デバイスが切断されました | ✅ 完全一致 | 保留 |
| CaptureFailureDriver | Apple/libusb 驱动异常 | Apple/libusb 驅動程式異常 | Apple/libusb 驅動程式異常 | Apple/libusb driver error | Apple/libusbドライバーのエラー | ✅ 完全一致 | 保留 |
| CaptureFailureExistingSession | 已存在旧投屏会话 | 仍存在舊的螢幕鏡像工作階段 | 仍存在舊的螢幕鏡像工作階段 | A previous mirroring session still exists | 以前のミラーリングセッションが残っています | ✅ 完全一致 | 保留 |
| CaptureFailureNoFrames | 视频流无帧或黑屏 | 視訊串流沒有畫面或黑畫面 | 視訊串流沒有畫面或黑畫面 | No video frames or black screen | 映像フレームがないか、画面が真っ黒です | ✅ 完全一致 | 保留 |
| CaptureFailureSessionCreation | 投屏会话创建失败 | 螢幕鏡像工作階段建立失敗 | 螢幕鏡像工作階段建立失敗 | Mirroring session creation failed | ミラーリングのセッションを作成できませんでした | ✅ 完全一致 | 保留 |
| CaptureFailureStatusFormat | 投屏错误：{0}（{1}，错误码 {2}） | 螢幕鏡像錯誤：{0}（{1}，錯誤碼 {2}） | 螢幕鏡像錯誤：{0}（{1}，錯誤碼 {2}） | Mirroring error: {0} ({1}, code {2}) | ミラーリングエラー: {0}（{1}、コード{2}） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| CaptureFailureSystemClosed | 会话被系统关闭 | 工作階段已被系統關閉 | 工作階段已被系統關閉 | Session was closed by the system | システムによってセッションが閉じられました | ✅ 完全一致 | 保留 |
| CaptureFailureTimeout | 操作超时 | 操作逾時 | 操作逾時 | Operation timed out | 操作がタイムアウトしました | ✅ 完全一致 | 保留 |
| CaptureFailureUnknown | 未知异常 | 未知錯誤 | 未知錯誤 | Unknown error | 不明なエラー | ✅ 完全一致 | 保留 |
| CaptureFailureUsbConnection | USB 设备连接失败 | USB 裝置連接失敗 | USB 裝置連線失敗 | USB device connection failed | USBデバイスに接続できませんでした | ✅ 完全一致 | 保留 |
| CaptureFailureVideoDimensions | 视频流分辨率异常 | 視訊串流解像度異常 | 視訊串流解析度異常 | Invalid video stream dimensions | 映像ストリームのサイズが無効です | ✅ 完全一致 | 保留 |
| CaptureFailureVideoStream | 视频流建立或解码失败 | 視訊串流建立或解碼失敗 | 視訊串流建立或解碼失敗 | Video stream or decoding failed | 映像ストリームまたはデコードに失敗しました | ✅ 完全一致 | 保留 |
| CaptureHandshaking | 正在建立投屏会话… | 正在建立螢幕鏡像工作階段… | 正在建立螢幕鏡像工作階段… | Establishing the mirroring session… | ミラーリングのセッションを確立しています… | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| CaptureIdle | 等待设备 | 等待裝置 | 等待裝置 | Waiting for a device | デバイスを待っています | ✅ 完全一致 | 保留 |
| CaptureNoPingCableAction | 更换 Apple 原装或 MFi 认证数据线 | 更換 Apple 原裝或 MFi 認證數據線 | 更換 Apple 原廠或 MFi 認證傳輸線 | Replace the cable with an Apple original or MFi-certified cable | Apple純正またはMFi認証のケーブルに交換する | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| CaptureNoPingRecovery | 设备已连接，但长时间没有响应投屏握手。<br><br>请重启 iPhone 或 iPad，然后使用 Apple 原装或 MFi 认证数据线重新连接后重试。<br><br>重试时请保持设备解锁。 | 裝置已連接，但長時間沒有回應螢幕鏡像握手。<br><br>請重新啟動 iPhone 或 iPad，然後使用 Apple 原裝或 MFi 認證數據線重新連接後重試。<br><br>重試時請保持裝置解鎖。 | 裝置已連線，但長時間沒有回應螢幕鏡像握手。<br><br>請重新啟動 iPhone 或 iPad，然後使用 Apple 原廠或 MFi 認證傳輸線重新連線後重試。<br><br>重試時請保持裝置解鎖。 | The device is connected, but it did not respond to the mirroring handshake.<br><br>Restart the iPhone or iPad, then reconnect it with an Apple original or MFi-certified cable and try again.<br><br>Keep the device unlocked while retrying. | デバイスは接続されていますが、ミラーリングのハンドシェイクに応答しませんでした。<br><br>iPhoneまたはiPadを再起動し、Apple純正またはMFi認証のケーブルでつなぎ直して、もう一度お試しください。<br><br>再試行するときは、デバイスのロックを解除したままにしてください。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语；静态未发现引用，保留待后续调用核对 |
| CaptureNoPingRestartAction | 重启 iPhone 或 iPad | 重新啟動 iPhone 或 iPad | 重新啟動 iPhone 或 iPad | Restart the iPhone or iPad | iPhoneまたはiPadを再起動する | ✅ 完全一致 | 保留 |
| CaptureNoPingSummary | 设备已连接，但长时间没有响应投屏握手。再次尝试前，请优先完成以下两项操作： | 裝置已連接，但長時間沒有回應螢幕鏡像握手。再次嘗試前，請優先完成以下兩項操作： | 裝置已連線，但長時間沒有回應螢幕鏡像握手。再次嘗試前，請優先完成以下兩項操作： | The device is connected, but it did not respond to the mirroring handshake. Complete these two steps before retrying: | デバイスは接続されていますが、ミラーリングのハンドシェイクに応答しませんでした。再試行する前に、次の2つを行ってください。 | ✅ 完全一致 | 保留 |
| CaptureNoPingTitle | iPhone/iPad 投屏连接超时 | iPhone/iPad 螢幕鏡像連接逾時 | iPhone/iPad 螢幕鏡像連線逾時 | iPhone/iPad mirroring connection timed out | iPhone/iPadのミラーリング接続がタイムアウトしました | ✅ 完全一致 | 保留 |
| CaptureNoPingUnlockHint | 重新连接并开始投屏时，请保持设备处于解锁状态。 | 重新連接並開始螢幕鏡像時，請保持裝置處於解鎖狀態。 | 重新連線並開始螢幕鏡像時，請保持裝置處於解鎖狀態。 | Keep the device unlocked when reconnecting and starting mirroring again. | つなぎ直してミラーリングをもう一度開始するときは、デバイスのロックを解除したままにしてください。 | ✅ 完全一致 | 保留 |
| CaptureNoticeErrorBadge | 投屏未能继续 | 螢幕鏡像未能繼續 | 螢幕鏡像未能繼續 | Mirroring could not continue | ミラーリングを続行できません | ✅ 完全一致 | 保留 |
| CaptureNoticeErrorHint | 请检查设备和连接后重试 | 請檢查裝置和連線後重試 | 請檢查裝置和連線後重試 | Check the device and connection, then retry | デバイスと接続を確認して、再試行してください | ✅ 完全一致 | 保留 |
| CaptureNoticeStoppedBadge | 投屏已停止 | 螢幕鏡像已停止 | 螢幕鏡像已停止 | Mirroring stopped | ミラーリングを停止しました | ✅ 完全一致 | 保留 |
| CaptureNoticeStoppedHint | 重启设备后可再次投屏 | 重新啟動裝置後可再次螢幕鏡像 | 重新啟動裝置後即可再次使用螢幕鏡像 | Restart the device before mirroring again | もう一度ミラーリングする前に、デバイスを再起動してください | ✅ 完全一致 | 保留 |
| CaptureNoticeUsbBadge | USB 投屏配置未完成 | USB 螢幕鏡像設定未完成 | USB 螢幕鏡像設定未完成 | USB mirroring setup incomplete | USBミラーリングの設定が未完了です | ✅ 完全一致 | 保留 |
| CaptureNoticeUsbHint | 请重新插拔数据线后重试 | 請重新插拔數據線後重試 | 請重新插拔傳輸線後重試 | Reconnect the cable, then retry | ケーブルをつなぎ直して、再試行してください | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| CaptureQueued | 等待设备清理… | 等待裝置清理… | 等待裝置清理… | Waiting for device cleanup… | デバイスの整理を待っています… | ✅ 完全一致 | 保留 |
| CaptureStageDecoder | 视频解码 | 視訊解碼 | 視訊解碼 | Video decoder | 映像デコーダー | ✅ 完全一致 | 保留 |
| CaptureStageDeviceDiscovery | 设备发现 | 裝置探索 | 裝置探索 | Device discovery | デバイスの検出 | ✅ 完全一致 | 保留 |
| CaptureStageDeviceReenumeration | 等待 USB 设备重新枚举 | 等待 USB 裝置重新枚舉 | 等待 USB 裝置重新列舉 | USB device re-enumeration | USBデバイスの再列挙 | ✅ 完全一致 | 保留 |
| CaptureStageInterfaceOpen | 打开 QuickTime USB 接口 | 開啟 QuickTime USB 介面 | 開啟 QuickTime USB 介面 | QuickTime USB interface open | QuickTime USBインターフェースを開く処理 | ✅ 完全一致 | 保留 |
| CaptureStageQuickTimeHandshake | QuickTime 会话握手 | QuickTime 工作階段交握 | QuickTime 工作階段交握 | QuickTime session handshake | QuickTimeセッションのハンドシェイク | ✅ 完全一致 | 保留 |
| CaptureStageSessionTeardown | 释放投屏会话 | 釋放螢幕鏡像工作階段 | 釋放螢幕鏡像工作階段 | Session teardown | セッションの終了処理 | ✅ 完全一致 | 保留 |
| CaptureStageUnknown | 未知阶段 | 未知階段 | 未知階段 | Unknown stage | 不明な段階 | ✅ 完全一致 | 保留 |
| CaptureStageUsbActivation | 激活 QuickTime USB 配置 | 啟用 QuickTime USB 設定 | 啟用 QuickTime USB 設定 | QuickTime USB activation | QuickTime USBの有効化 | ✅ 完全一致 | 保留 |
| CaptureStageUsbPreflight | USB 设备预检 | USB 裝置預檢 | USB 裝置預檢 | USB device preflight | USBデバイスの事前確認 | ✅ 完全一致 | 保留 |
| CaptureStageVideoStream | 建立视频流 | 建立視訊串流 | 建立視訊串流 | Video stream setup | 映像ストリームの設定 | ✅ 完全一致 | 保留 |
| CaptureStarted | 投屏已启动 | 螢幕鏡像已啟動 | 螢幕鏡像已啟動 | Mirroring started | ミラーリングを開始しました | ✅ 完全一致 | 保留 |
| CaptureStopped | 投屏已停止 | 螢幕鏡像已停止 | 螢幕鏡像已停止 | Mirroring stopped | ミラーリングを停止しました | ✅ 完全一致 | 保留 |
| CaptureStopping | 正在停止投屏… | 正在停止螢幕鏡像… | 正在停止螢幕鏡像… | Stopping mirroring… | ミラーリングを停止しています… | ✅ 完全一致 | 保留 |
| CaptureStreaming | 正在投屏 | 正在螢幕鏡像 | 正在進行螢幕鏡像 | Mirroring | ミラーリング中 | ✅ 完全一致 | 保留 |
| CaptureUsbConfigurationRecovery | 未能切换 iPhone 或 iPad 的 USB 投屏配置。<br><br>请依次尝试：<br>1. 拔下数据线，等待几秒后重新插入<br>2. 重启 iPhone 或 iPad 后再连接<br>3. 更换 Apple 原装或 MFi 认证数据线<br><br>重新连接并开始投屏时，请保持设备处于解锁状态。 | 未能切換 iPhone 或 iPad 的 USB 螢幕鏡像設定。<br><br>請依序嘗試：<br>1. 拔下數據線，等待幾秒後重新插入<br>2. 重新啟動 iPhone 或 iPad 後再連接<br>3. 更換 Apple 原裝或 MFi 認證數據線<br><br>重新連接並開始螢幕鏡像時，請保持裝置處於解鎖狀態。 | 未能切換 iPhone 或 iPad 的 USB 螢幕鏡像設定。<br><br>請依序嘗試：<br>1. 拔下傳輸線，等待幾秒後重新插入<br>2. 重新啟動 iPhone 或 iPad 後再連線<br>3. 更換 Apple 原廠或 MFi 認證傳輸線<br><br>重新連線並開始螢幕鏡像時，請保持裝置處於解鎖狀態。 | iPhone or iPad USB mirroring configuration could not be activated.<br><br>Try these steps in order:<br>1. Unplug the cable, wait a few seconds, and plug it back in<br>2. Restart the iPhone or iPad, then reconnect it<br>3. Replace the cable with an Apple original or MFi-certified cable<br><br>Keep the device unlocked when reconnecting and starting mirroring again. | iPhoneまたはiPadのUSBミラーリング設定を有効にできませんでした。<br><br>次の手順を順番にお試しください。<br>1. ケーブルを抜いて数秒待ち、もう一度差し込む<br>2. iPhoneまたはiPadを再起動して、つなぎ直す<br>3. Apple純正またはMFi認証のケーブルに交換する<br><br>つなぎ直してミラーリングをもう一度開始するときは、デバイスのロックを解除したままにしてください。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语；静态未发现引用，保留待后续调用核对 |
| CaptureUsbConfigurationTitle | USB 投屏配置错误 | USB 螢幕鏡像設定錯誤 | USB 螢幕鏡像設定錯誤 | USB mirroring configuration error | USBミラーリングの設定エラー | ✅ 完全一致 | 保留 |
| CaptureUsbRestoreReplugRequired | 尚未确认 Apple USB 通道恢复可用。请解锁 iPhone，确认可能出现的信任提示并输入密码；若取消了自动重连的管理员授权或仍无法识别，请重新插拔后再开始投屏。 | 尚未確認 Apple USB 通道恢復可用。請解鎖 iPhone，確認可能出現的信任提示並輸入密碼；若取消了自動重新連接的管理員授權或仍無法識別，請重新插拔後再開始螢幕鏡像。 | 尚未確認 Apple USB 通道恢復可用。請解鎖 iPhone，確認可能出現的信任提示並輸入密碼；若取消了自動重新連線的系統管理員授權或仍無法辨識，請重新插拔後再開始螢幕鏡像。 | The Apple USB connection has not been confirmed ready. Unlock the iPhone, accept any Trust prompt and enter its passcode. If administrator approval for automatic reconnection was cancelled or the device is still missing, reconnect the cable before starting mirroring again. | AppleのUSB接続の準備ができたことを確認できていません。iPhoneのロックを解除し、「信頼」の確認が出たら許可してパスコードを入力してください。自動再接続の管理者承認をキャンセルした場合や、デバイスがまだ表示されない場合は、ケーブルをつなぎ直してから、もう一度ミラーリングを開始してください。 | ✅ 完全一致 | 保留 |
| CaptureVideoProtected | 可能是受保护的视频内容 | 可能是受保護的影片內容 | 可能是受保護的影片內容 | Possible protected video content | 保護された映像コンテンツの可能性があります | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedAudioActive | 正在收到音频数据 | 正在收到音訊資料 | 正在收到音訊資料 | Audio samples are arriving | 音声サンプルを受信しています | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedAudioActiveFormat | 正在收到音频数据 · {0:F0} kHz · {1} 声道 | 正在收到音訊資料 · {0:F0} kHz · {1} 聲道 | 正在收到音訊資料 · {0:F0} kHz · {1} 聲道 | Audio samples received · {0:F0} kHz · {1} ch | 音声サンプルを受信しました · {0:F0}kHz · {1}ch | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedAudioBadgeActive | 有音频 | 有音訊 | 有音訊 | Audio on | 音声あり | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedAudioBadgeUnavailable | 无音频 | 無音訊 | 無音訊 | No audio | 音声なし | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedAudioUnavailable | 尚未收到音频数据 | 尚未收到音訊資料 | 尚未收到音訊資料 | No audio samples received | 音声サンプルを受信していません | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedNoticeHint | 画面恢复后自动关闭 | 畫面恢復後自動關閉 | 畫面恢復後自動關閉 | Closes when video returns | 映像が戻ると閉じます | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedNoticeProtection | 这可能与 DRM / FairPlay 或其他内容保护机制有关 | 這可能與 DRM / FairPlay 或其他內容保護機制有關 | 這可能與 DRM / FairPlay 或其他內容保護機制有關 | This may be related to DRM / FairPlay or another content-protection mechanism | DRM / FairPlayなど、コンテンツ保護の仕組みが関係している可能性があります | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedNoticeTitle | 请确认当前视频投放是否正常？ | 請確認目前影片投放是否正常？ | 請確認目前影片投放是否正常？ | Is the current video cast working correctly? | いまの動画のキャストは正常に動いていますか？ | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedNoticeVideo | 检测到当前视频画面持续为黑屏 | 偵測到目前影片畫面持續為黑畫面 | 偵測到目前影片畫面持續為黑畫面 | The current video has remained black | いまの映像は黒いままです | ✅ 完全一致 | 保留 |
| CaptureVideoProtectedTitle | 检测到持续黑色视频 | 偵測到持續黑色影片 | 偵測到影片持續顯示黑畫面 | Sustained black video detected | 黒い映像が続いています | ✅ 完全一致 | 保留 |
| CaptureWaitingDevice | 等待 Apple 设备投屏接口… | 等待 Apple 裝置螢幕鏡像介面… | 等待 Apple 裝置螢幕鏡像介面… | Waiting for the Apple device mirroring interface… | Appleデバイスのミラーリングインターフェースを待っています… | ✅ 完全一致 | 保留 |
| Changelog | 更新日志 | 更新記錄 | 更新記錄 | Changelog | 変更履歴 | ✅ 完全一致 | 保留 |
| CheckForUpdates | 检查更新 | 檢查更新 | 檢查更新 | Check for updates | アップデートを確認 | ✅ 完全一致 | 保留 |
| CheckOnStartup | 启动时检查更新 | 啟動時檢查更新 | 啟動時檢查更新 | Check for updates at startup | 起動時にアップデートを確認 | ✅ 完全一致 | 保留 |
| CheckingForUpdates | 正在连接更新服务检查新版本… | 正在連接更新服務檢查新版本… | 正在連線更新服務檢查新版本… | Checking for updates… | アップデートを確認しています… | ⚠️ 需要优化 → ✅ 已修复 | 明确当前为更新检查状态 |
| CleanLogs | 清理日志和更新缓存 | 清理記錄和更新快取 | 清理記錄檔和更新快取 | Clean logs and update cache | ログとアップデートのキャッシュを削除 | ✅ 完全一致 | 保留 |
| ClearBluetoothBindings | 清除所有蓝牙绑定数据 | 清除所有藍牙綁定資料 | 清除所有藍牙綁定資料 | Clear all Bluetooth bindings | Bluetoothの紐づけをすべて解除 | ✅ 完全一致 | 保留 |
| ClearBluetoothBindingsBody | 这会移除所有设备档案中的 Bluetooth 身份，已绑定的 USB 和 AirPlay 身份会保留。 | 這會移除所有裝置檔案中的 Bluetooth 身份，已綁定的 USB 和 AirPlay 身份會保留。 | 這會移除所有裝置設定檔中的 Bluetooth 身分，已綁定的 USB 和 AirPlay 身分會保留。 | This removes the Bluetooth identity from every device profile. Other USB and AirPlay identities remain bound. | すべてのデバイスプロファイルからBluetoothの識別情報を削除します。USBとAirPlayの識別情報は、紐づけられたまま残ります。 | ✅ 完全一致 | 保留 |
| ClearBluetoothBindingsFailed | 无法更新设备绑定档案。 | 無法更新裝置綁定檔案。 | 無法更新裝置綁定檔案。 | Could not update the device binding profiles. | デバイスの紐づけプロファイルを更新できませんでした。 | ✅ 完全一致 | 保留 |
| ClearBluetoothBindingsTitle | 清除蓝牙绑定数据 | 清除藍牙綁定資料 | 清除藍牙綁定資料 | Clear Bluetooth bindings | Bluetoothの紐づけの解除 | ✅ 完全一致 | 保留 |
| ClearView | 清空视图 | 清除檢視 | 清除檢視 | Clear view | 表示をクリア | ✅ 完全一致 | 保留 |
| ClipboardPasteFailed | 粘贴到 iPhone 失败，请重试。 | 貼上到 iPhone 失敗，請重試。 | 貼上到 iPhone 失敗，請重試。 | Could not paste to iPhone. Try again. | iPhoneに貼り付けできませんでした。もう一度お試しください。 | ✅ 完全一致 | 保留 |
| ClipboardTextTooLarge | 文本过长，无法一次粘贴。请缩短文本后重试。 | 文字過長，無法一次貼上。請縮短文字後重試。 | 文字過長，無法一次貼上。請縮短文字後重試。 | The text is too long to paste at once. Shorten it and try again. | テキストが長すぎて一度に貼り付けられません。短くしてもう一度お試しください。 | ✅ 完全一致 | 保留 |
| Close | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 保留 |
| CloseCurrentInstance | 关闭当前窗口 | 關閉目前視窗 | 關閉目前視窗 | Close this window | このウィンドウを閉じる | ✅ 完全一致 | 保留 |
| CloseMainWindowToTray | 关闭主界面时进入托盘模式 | 關閉主視窗時進入系統匣模式 | 關閉主視窗時進入系統匣模式 | Close the main window to the system tray | メインウィンドウを閉じたら、システムトレイに入れる | ✅ 完全一致 | 保留 |
| CloseMainWindowToTrayHint | 保留投屏及独立窗口，可从托盘恢复主界面或退出应用。 | 保留投影及獨立視窗，可從系統匣還原主視窗或結束應用程式。 | 保留投影及獨立視窗，可從系統匣還原主視窗或結束應用程式。 | Keep mirroring and separate windows open. Restore the main window or exit the app from the tray. | ミラーリングと独立ウィンドウは開いたままにします。メインウィンドウの再表示やアプリの終了は、システムトレイから行えます。 | ✅ 完全一致 | 保留 |
| CloseOtherInstances | 关闭其他窗口 | 關閉其他視窗 | 關閉其他視窗 | Close other windows | ほかのウィンドウを閉じる | ⚠️ 需要优化 → ✅ 已修复 | 操作针对其他全部实例 |
| CloseOtherInstancesFailedFormat | 仍有 {0} 个 iPhoneMirror 实例未能关闭。请在任务栏或任务管理器中关闭后重试。 | 仍有 {0} 個 iPhoneMirror 執行個體未能關閉。請在工作列或工作管理員中關閉後重試。 | 仍有 {0} 個 iPhoneMirror 執行個體未能關閉。請在工作列或工作管理員中關閉後重試。 | iPhoneMirror instances still running: {0}. Close them from the taskbar or Task Manager, then try again. | iPhoneMirrorがまだ起動しています: {0}。タスクバーまたはタスクマネージャーから閉じて、もう一度お試しください。 | ⚠️ 需要优化 → ✅ 已修复 | 数量可能大于 1，避免固定单数 instance/it |
| ClosingOtherInstances | 正在安全关闭其他 iPhoneMirror 窗口… | 正在安全關閉其他 iPhoneMirror 視窗… | 正在安全關閉其他 iPhoneMirror 視窗… | Safely closing other iPhoneMirror windows… | ほかのiPhoneMirrorのウィンドウを安全に閉じています… | ⚠️ 需要优化 → ✅ 已修复 | 操作针对其他全部实例 |
| CompactLaunchDeviceUnavailable | 未找到目标设备，请连接并解锁设备后重试。 | 找不到目標裝置，請連接並解鎖裝置後再試。 | 找不到目標裝置，請連線並解鎖裝置後再試。 | The selected device was not found. Connect and unlock it, then try again. | 選択したデバイスが見つかりません。接続してロックを解除してから、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| CompactLaunchFailed | 独立窗口启动未完成：{0} | 獨立視窗啟動未完成：{0} | 獨立視窗啟動未完成：{0} | Could not complete independent window launch: {0} | 独立ウィンドウを起動できませんでした: {0} | ✅ 完全一致 | 保留 |
| CompactLaunchInvalidArguments | 请在 --device 后指定一个设备标识。 | 請在 --device 後指定一個裝置識別碼。 | 請在 --device 後指定一個裝置識別碼。 | Specify one device identifier after --device. | --deviceの後にデバイス識別子を1つ指定してください。 | ✅ 完全一致 | 保留 |
| CompactLaunchMultipleDevices | 检测到多台设备，请在主窗口选择设备并创建专用快捷方式。 | 偵測到多部裝置，請在主視窗選擇裝置並建立專用捷徑。 | 偵測到多台裝置，請在主視窗選擇裝置並建立專用捷徑。 | Multiple devices are available. Select a device in the main window and create its shortcut. | 複数のデバイスがあります。メインウィンドウでデバイスを選択して、ショートカットを作成してください。 | ✅ 完全一致 | 保留 |
| CompactLaunchTitle | 独立窗口启动 | 獨立視窗啟動 | 獨立視窗啟動 | Independent window launch | 独立ウィンドウの起動 | ✅ 完全一致 | 保留 |
| CompactShortcutCreated | 已创建快捷方式：{0} | 已建立捷徑：{0} | 已建立捷徑：{0} | Shortcut created: {0} | ショートカットを作成しました: {0} | ✅ 完全一致 | 保留 |
| ConnectionConnected | 已连接 | 已連接 | 已連線 | Connected | 接続済み | ✅ 完全一致 | 保留 |
| ConnectionDisconnected | 未连接 | 未連接 | 未連線 | Disconnected | 切断中 | ✅ 完全一致 | 保留 |
| ConnectionError | 设备连接异常 | 裝置連接異常 | 裝置連線異常 | Device connection error | デバイス接続エラー | ✅ 完全一致 | 保留 |
| ConnectionPaired | 已配对，请解锁设备 | 已配對，請解鎖裝置 | 已配對，請解鎖裝置 | Paired; unlock the device | ペアリング済み。デバイスのロックを解除してください | ✅ 完全一致 | 保留 |
| ConnectionReady | 已连接并配对 | 已連接並配對 | 已連線並配對 | Connected and paired | 接続・ペアリング済み | ✅ 完全一致 | 保留 |
| ConnectionUsbNoMux | USB 已连接，等待 Apple 通道 | USB 已連接，等待 Apple 通道 | USB 已連線，等待 Apple 通道 | USB connected; waiting for Apple channel | USB接続済み。Appleのチャンネルを待っています | ✅ 完全一致 | 保留 |
| Continue | 继续 | 繼續 | 繼續 | Continue | 続行 | ✅ 完全一致 | 保留 |
| ContrastLabel | 对比度 | 對比度 | 對比 | Contrast | コントラスト | ✅ 完全一致 | 保留 |
| ControlAutoReconnectingChannel | 控制通道暂时中断，正在自动重新连接… | 控制通道暫時中斷，正在自動重新連接… | 控制通道暫時中斷，正在自動重新連線… | The control channel was interrupted. Reconnecting automatically… | 操作チャンネルが中断されました。自動で再接続しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBindingAdvice | 请关闭此窗口，打开“设备绑定器”，为当前设备绑定有线 USB 身份；如使用 AirPlay 镜像，请将其绑定到同一台设备的档案，然后重新启动有线或无线控制。 | 請關閉此視窗，開啟「裝置綁定器」，為目前裝置綁定有線 USB 身分；如使用 AirPlay 鏡像，請將其綁定至同一台裝置的檔案，然後重新啟動有線或無線控制。 | 請關閉此視窗，開啟「裝置綁定」，為目前裝置綁定有線 USB 身分；如使用 AirPlay 鏡像，請將其綁定至同一台裝置的設定檔，然後重新啟動有線或無線控制。 | Close this window and open the device binder. Bind this device's wired USB identity; if using AirPlay mirroring, bind it to the same device profile. Then start wired or wireless control again. | このウィンドウを閉じて、デバイス紐づけツールを開いてください。このデバイスの有線USBの識別情報を紐づけます。AirPlayミラーリングを使う場合は、同じデバイスプロファイルに紐づけてください。そのあと、有線または無線の操作をもう一度開始してください。 | ✅ 完全一致 | 保留 |
| ControlBindingNotFound | 未找到设备绑定信息。 | 找不到裝置綁定資料。 | 找不到裝置綁定資料。 | Device binding information was not found. | デバイスの紐づけ情報が見つかりませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源；静态未发现引用，保留待后续调用核对 |
| ControlBindingRequired | 当前设备尚未完成正确绑定，请先完成设备绑定后再使用反向控制。 | 目前裝置尚未完成正確綁定，請先完成裝置綁定後再使用反向控制。 | 目前裝置尚未完成正確綁定，請先完成裝置綁定後再使用反向控制。 | This device is not correctly bound. Complete device binding before using reverse control. | このデバイスは正しく紐づけられていません。リモート操作を使う前に、デバイスの紐づけを完了してください。 | ✅ 完全一致 | 保留 |
| ControlBluetoothBindingAdvice | 请先在设备绑定器中为当前设备完成蓝牙绑定，再启动蓝牙控制。 | 請先在裝置綁定器中為目前裝置完成藍牙綁定，再啟動藍牙控制。 | 請先在裝置綁定中為目前裝置完成藍牙綁定，再啟動藍牙控制。 | Complete the Bluetooth binding for this device in the device binder, then start Bluetooth control. | デバイス紐づけツールでこのデバイスのBluetooth紐づけを完了してから、Bluetooth操作を開始してください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBluetoothBindingRequired | 尚未完成蓝牙设备绑定 | 尚未完成藍牙裝置綁定 | 尚未完成藍牙裝置綁定 | Bluetooth device binding is incomplete | Bluetoothデバイスの紐づけが完了していません | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBluetoothCancelled | 已取消蓝牙控制 | 已取消藍牙控制 | 已取消藍牙控制 | Bluetooth control cancelled | Bluetooth操作をキャンセルしました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBluetoothDisconnected | 设备已断开，请重新连接蓝牙… | 裝置已中斷連線，請重新連接藍牙… | 裝置已中斷連線，請重新連線藍牙… | The device disconnected. Reconnect it over Bluetooth… | デバイスが切断されました。Bluetoothで再接続してください… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBluetoothPairingTitle | 请在设备和 Windows 上完成蓝牙配对 | 請在裝置及 Windows 上完成藍牙配對 | 請在裝置及 Windows 上完成藍牙配對 | Complete Bluetooth pairing on your device and Windows | デバイスとWindowsでBluetoothのペアリングを完了してください | ❌ 含义不一致 → ✅ 已修复 | 阶段要求为配对，同时适用于 iPhone/iPad |
| ControlBluetoothReadyToPair | 蓝牙已就绪，请按下方步骤在设备上完成连接… | 藍牙已就緒，請按下方步驟在裝置上完成連線… | 藍牙已就緒，請按下方步驟在裝置上完成連線… | Bluetooth is ready. Follow the steps below to connect your device… | Bluetoothの準備ができました。以下の手順に沿ってデバイスを接続してください… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBluetoothStartFailed | 无法启用蓝牙控制 | 無法啟用藍牙控制 | 無法啟用藍牙控制 | Could not enable Bluetooth control | Bluetooth操作を有効にできませんでした | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlBluetoothTouchFailed | 蓝牙触控检查未通过 | 藍牙觸控檢查未通過 | 藍牙觸控檢查未通過 | Bluetooth touch check failed | Bluetoothのタッチ確認に失敗しました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCheckConnectionAdvice | 请检查设备连接后重试。 | 請檢查裝置連線後重試。 | 請檢查裝置連線後重試。 | Check the device connection, then try again. | デバイスの接続を確認して、もう一度お試しください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCheckingBluetoothBinding | 正在检查设备档案中的蓝牙绑定… | 正在檢查裝置檔案中的藍牙綁定… | 正在檢查裝置設定檔中的藍牙綁定… | Checking the Bluetooth binding in the device profile… | デバイスプロファイルのBluetooth紐づけを確認しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCheckingBluetoothSupport | 正在检查电脑蓝牙是否已开启并支持 BLE… | 正在檢查電腦藍牙是否已開啟並支援 BLE… | 正在檢查電腦藍牙是否已開啟並支援 BLE… | Checking that Bluetooth is on and supports BLE… | BluetoothがオンでBLEに対応していることを確認しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCheckingDeviceBinding | 正在检查设备和绑定状态… | 正在檢查裝置和綁定狀態… | 正在檢查裝置和綁定狀態… | Checking the device and its bindings… | デバイスとその紐づけを確認しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCheckingDevicePermissions | 正在检查设备权限和连接状态… | 正在檢查裝置權限和連線狀態… | 正在檢查裝置權限和連線狀態… | Checking device permissions and connection status… | デバイスの権限と接続状態を確認しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCheckingHidChannel | 设备已连接，正在检查 HID 触控通道… | 裝置已連接，正在檢查 HID 觸控通道… | 裝置已連線，正在檢查 HID 觸控通道… | The device is connected. Checking the HID touch channel… | デバイスが接続されました。HIDタッチチャンネルを確認しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlCloseCountdown | 窗口将在 {0} 秒后关闭 | 視窗將於 {0} 秒後關閉 | 視窗將於 {0} 秒後關閉 | This window closes in {0} s | このウィンドウは{0}秒後に閉じます | ⚠️ 需要优化 → ✅ 已修复 | 秒使用单位 s，适用于倒计时 1 秒 |
| ControlConnectingChannel | 正在建立设备控制通道… | 正在建立裝置控制通道… | 正在建立裝置控制通道… | Establishing the device control channel… | デバイスの操作チャンネルを確立しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlDeviceNotReady | 设备未就绪或尚未完成绑定。 | 裝置未就緒或尚未完成綁定。 | 裝置未就緒或尚未完成綁定。 | The device is not ready or has not been bound. | デバイスの準備ができていないか、紐づけられていません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlHidRouteFailed | HID 鼠标通道已连接，但触控路由校验失败。 | HID 滑鼠通道已連接，但觸控路由驗證失敗。 | HID 滑鼠通道已連線，但觸控路由驗證失敗。 | The HID mouse channel is connected, but touch routing validation failed. | HIDマウスチャンネルは接続されていますが、タッチの経路検証に失敗しました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlInitializingInput | 正在初始化触控和输入服务… | 正在初始化觸控和輸入服務… | 正在初始化觸控和輸入服務… | Initializing touch and input services… | タッチと入力のサービスを初期化しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlOperationFailed | 反向控制失败 | 反向控制失敗 | 反向控制失敗 | Reverse control failed | リモート操作に失敗しました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlPreparing | 正在准备控制连接… | 正在準備控制連線… | 正在準備控制連線… | Preparing the control connection… | 操作用の接続を準備しています… | ✅ 完全一致 | 保留 |
| ControlPreparingInput | 正在准备鼠标、键盘和系统控制… | 正在準備滑鼠、鍵盤和系統控制… | 正在準備滑鼠、鍵盤和系統控制… | Preparing mouse, keyboard, and system controls… | マウス、キーボード、システム操作を準備しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlPreparingSupportFiles | 正在准备设备所需的支持文件… | 正在準備裝置所需的支援檔案… | 正在準備裝置所需的支援檔案… | Preparing the support files required by the device… | デバイスに必要なサポートファイルを準備しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlPrerequisiteCancelled | 已取消启动前的确认。 | 已取消啟動前的確認。 | 已取消啟動前的確認。 | The startup confirmation was cancelled. | 開始前の確認をキャンセルしました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlProgressActive | 进行中 | 進行中 | 進行中 | In progress | 実行中 | ✅ 完全一致 | 保留 |
| ControlProgressCompleted | 已完成 | 已完成 | 已完成 | Completed | 完了 | ✅ 完全一致 | 保留 |
| ControlProgressFailed | 失败 | 失敗 | 失敗 | Failed | 失敗 | ✅ 完全一致 | 保留 |
| ControlProgressPending | 等待中 | 等待中 | 等待中 | Pending | 待機中 | ✅ 完全一致 | 保留 |
| ControlProgressSkipped | 已跳过 | 已略過 | 已略過 | Skipped | スキップ | ✅ 完全一致 | 保留 |
| ControlReadyDescription | 反向控制已就绪 | 反向控制已就緒 | 反向控制已就緒 | Reverse control is ready | リモート操作の準備ができました | ❌ 缺失 → ✅ 已修复 | 控制就绪默认提示改为运行时查找资源 |
| ControlReconnectingChannel | 控制通道暂时中断，正在尝试重新连接… | 控制通道暫時中斷，正在嘗試重新連接… | 控制通道暫時中斷，正在嘗試重新連線… | The control channel was interrupted. Reconnecting… | 操作チャンネルが中断されました。再接続しています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlRecoveryFailed | 自动重连失败 | 自動重新連接失敗 | 自動重新連線失敗 | Automatic reconnection failed | 自動再接続に失敗しました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlStageCancelled | 已取消反向控制 | 已取消反向控制 | 已取消反向控制 | Reverse control cancelled | リモート操作をキャンセルしました | ✅ 完全一致 | 保留 |
| ControlStageCheckingBinding | 检查设备绑定 | 檢查裝置綁定 | 檢查裝置綁定 | Checking device binding | デバイスの紐づけを確認中 | ✅ 完全一致 | 保留 |
| ControlStageCheckingBluetooth | 检查电脑蓝牙 | 檢查電腦藍牙 | 檢查電腦藍牙 | Checking Bluetooth | Bluetoothを確認中 | ✅ 完全一致 | 保留 |
| ControlStageCheckingDevice | 检查设备 | 檢查裝置 | 檢查裝置 | Checking device | デバイスを確認中 | ✅ 完全一致 | 保留 |
| ControlStageCheckingPermissions | 检查设备权限 | 檢查裝置權限 | 檢查裝置權限 | Checking device permissions | デバイスの権限を確認中 | ✅ 完全一致 | 保留 |
| ControlStageConnecting | 建立控制连接 | 建立控制連線 | 建立控制連線 | Establishing the control connection | 操作用の接続を確立中 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| ControlStageFailed | 无法启用反向控制 | 無法啟用反向控制 | 無法啟用反向控制 | Could not enable reverse control | リモート操作を有効にできませんでした | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlStageInitializingServices | 初始化控制服务 | 初始化控制服務 | 初始化控制服務 | Initializing control services | 操作サービスを初期化中 | ✅ 完全一致 | 保留 |
| ControlStagePreparingDeviceSupport | 准备设备支持文件 | 準備裝置支援檔案 | 準備裝置支援檔案 | Preparing device support files | デバイスサポート用ファイルを準備中 | ❌ 含义不一致 → ✅ 已修复 | 补齐准备对象为文件 |
| ControlStageReady | 控制已连接 | 控制已連線 | 控制已連線 | Control connected | 操作に接続しました | ✅ 完全一致 | 保留 |
| ControlStageRecovering | 正在恢复控制连接 | 正在恢復控制連線 | 正在恢復控制連線 | Recovering control connection | 操作用の接続を復旧中 | ✅ 完全一致 | 保留 |
| ControlStageStartingInputRouter | 启动输入控制 | 啟動輸入控制 | 啟動輸入控制 | Starting input control | 入力操作を開始中 | ✅ 完全一致 | 保留 |
| ControlStageStopping | 正在断开控制连接 | 正在中斷控制連線 | 正在中斷控制連線 | Disconnecting control | 操作を切断中 | ✅ 完全一致 | 保留 |
| ControlStageSwitchingBluetoothPeripheral | 切换蓝牙外设模式 | 切換藍牙周邊模式 | 切換藍牙周邊模式 | Switching to Bluetooth peripheral mode | Bluetoothペリフェラルモードに切り替え中 | ❌ 含义不一致 → ✅ 已修复 | 与实际切换阶段及中文一致 |
| ControlStageVerifyingTouch | 检查触控功能 | 檢查觸控功能 | 檢查觸控功能 | Checking touch input | タッチ入力を確認中 | ✅ 完全一致 | 保留 |
| ControlStageWaitingForDeveloperMode | 等待在手机上开启开发者模式 | 等待在手機上開啟開發者模式 | 等待在手機上開啟開發者模式 | Enable Developer Mode on your device | デバイスでデベロッパモードを有効にしてください | ✅ 完全一致 | 保留 |
| ControlStageWaitingForPhoneConnection | 等待手机连接 | 等待手機連線 | 等待手機連線 | Waiting for phone connection | iPhoneの接続を待機中 | ✅ 完全一致 | 保留 |
| ControlSwitchingBluetoothMode | 正在将电脑蓝牙切换至 HID 外设模式… | 正在將電腦藍牙切換至 HID 周邊模式… | 正在將電腦藍牙切換至 HID 周邊模式… | Switching the computer's Bluetooth to HID peripheral mode… | コンピュータのBluetoothをHIDペリフェラルモードに切り替えています… | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlTitle | 投屏设置 | 螢幕鏡像設定 | 螢幕鏡像設定 | Mirroring settings | ミラーリング設定 | ✅ 完全一致 | 保留 |
| ControlTotalDuration | 本次连接耗时 {0:0.0} 秒 | 本次連線耗時 {0:0.0} 秒 | 本次連線耗時 {0:0.0} 秒 | Connection time: {0:0.0} s | 接続時間: {0:0.0}秒 | ⚠️ 需要优化 → ✅ 已修复 | 与倒计时单位保持一致 |
| ControlWiredCancelled | 已取消有线控制 | 已取消有線控制 | 已取消有線控制 | Wired control cancelled | 有線操作をキャンセルしました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlWiredRetryFormat | 正在自动重新连接有线控制（第 {0} 次尝试）… | 正在自動重新連接有線控制（第 {0} 次嘗試）… | 正在自動重新連線有線控制（第 {0} 次嘗試）… | Reconnecting wired control automatically (attempt {0})… | 有線操作を自動で再接続しています（{0}回目）… | ❌ 缺失 → ✅ 已修复 | 自动重连计数提示迁入三语格式资源 |
| ControlWiredStartFailed | 无法启用有线控制 | 無法啟用有線控制 | 無法啟用有線控制 | Could not enable wired control | 有線操作を有効にできませんでした | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源；静态未发现引用，保留待后续调用核对 |
| ControlWirelessCancelled | 已取消无线控制 | 已取消無線控制 | 已取消無線控制 | Wireless control cancelled | 無線操作をキャンセルしました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlWirelessRecoveryDisconnected | 无线控制通道在自动重连完成前已断开。 | 無線控制通道在自動重新連接完成前已中斷連線。 | 無線控制通道在自動重新連線完成前已中斷連線。 | The wireless control channel disconnected before automatic reconnection completed. | 自動再接続が完了する前に、無線の操作チャンネルが切断されました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlWirelessRecoveryFailed | 无线控制自动重连失败 | 無線控制自動重新連接失敗 | 無線控制自動重新連線失敗 | Automatic wireless control reconnection failed | 無線操作の自動再接続に失敗しました | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlWirelessRetryFormat | 正在自动重新连接无线控制（第 {0} 次尝试）… | 正在自動重新連接無線控制（第 {0} 次嘗試）… | 正在自動重新連線無線控制（第 {0} 次嘗試）… | Reconnecting wireless control automatically (attempt {0})… | 無線操作を自動で再接続しています（{0}回目）… | ❌ 缺失 → ✅ 已修复 | 自动重连计数提示迁入三语格式资源 |
| ControlWirelessStartFailed | 无法启用无线控制 | 無法啟用無線控制 | 無法啟用無線控制 | Could not enable wireless control | 無線操作を有効にできませんでした | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源；静态未发现引用，保留待后续调用核对 |
| ControlWirelessStartupDisconnected | 无线控制通道在启动完成前已断开。 | 無線控制通道在啟動完成前已中斷連線。 | 無線控制通道在啟動完成前已中斷連線。 | The wireless control channel disconnected before startup completed. | 起動が完了する前に、無線の操作チャンネルが切断されました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| ControlWirelessStartupFailed | 无线控制启动失败 | 無線控制啟動失敗 | 無線控制啟動失敗 | Wireless control failed to start | 無線操作を開始できませんでした | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| CoreLoadFailedFormat | 核心加载失败：{0} | 核心載入失敗：{0} | 核心載入失敗：{0} | Core load failed: {0} | コアを読み込めませんでした: {0} | ✅ 完全一致 | 保留 |
| CreateCompactShortcut | 创建当前设备的桌面快捷方式 | 建立目前裝置的桌面捷徑 | 建立目前裝置的桌面捷徑 | Create a desktop shortcut for this device | このデバイス用のデスクトップショートカットを作成 | ✅ 完全一致 | 保留 |
| CurrentDevice | 当前设备 | 目前裝置 | 目前裝置 | Current device | 現在のデバイス | ✅ 完全一致 | 保留 |
| CurrentPreviewResolutionFormat | {0} x {1}（当前预览） | {0} x {1}（目前預覽） | {0} x {1}（目前預覽） | {0} x {1} (current preview) | {0} x {1}（現在のプレビュー） | ✅ 完全一致 | 保留 |
| CurrentVersionLabel | 当前版本 | 目前版本 | 目前版本 | Current version | 現在のバージョン | ✅ 完全一致 | 保留 |
| DecoderAuto | 自动（推荐） | 自動（推薦） | 自動（推薦） | Auto (recommended) | 自動（推奨） | ✅ 完全一致 | 保留 |
| DecoderHardwarePreferred | 硬件优先 | 硬件優先 | 硬體優先 | Hardware preferred | ハードウェア優先 | ✅ 完全一致 | 保留 |
| DecoderPreferenceAppliedFormat | 已应用解码器：{0} | 已套用解碼器：{0} | 已套用解碼器：{0} | Decoder applied: {0} | デコーダーを適用しました: {0} | ✅ 完全一致 | 保留 |
| DecoderPreferenceLabel | 解码器 | 解碼器 | 解碼器 | Decoder | デコーダー | ✅ 完全一致 | 保留 |
| DecoderPreferenceQueuedFormat | 已请求切换解码器：{0}（将在关键帧生效） | 已請求切換解碼器：{0}（將在關鍵幀生效） | 已請求切換解碼器：{0}（將在關鍵影格生效） | Decoder switch requested: {0} (applies at a keyframe) | デコーダーの切り替えを要求しました: {0}（キーフレームで適用されます） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DecoderPreferenceSelectedFormat | 已选择解码器：{0} | 已選擇解碼器：{0} | 已選擇解碼器：{0} | Decoder selected: {0} | デコーダーを選択しました: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DecoderPreferenceSubmittedFormat | 解码器设置已提交：{0}；请在预览下方查看实际状态。 | 解碼器設定已提交：{0}；請在預覽下方查看實際狀態。 | 解碼器設定已提交：{0}；請在預覽下方查看實際狀態。 | Decoder setting submitted: {0}; see the status below the preview for the active mode. | デコーダーの設定を送信しました: {0}。使用中のモードは、プレビューの下の状態表示で確認してください。 | ✅ 完全一致 | 保留 |
| DecoderRuntimeExternal | 无线接收器解码 | 無線接收器解碼 | 無線接收器解碼 | wireless receiver decoder | 無線レシーバーのデコーダー | ✅ 完全一致 | 保留 |
| DecoderRuntimeHardware | 硬件加速 | 硬件加速 | 硬體加速 | hardware acceleration | ハードウェアアクセラレーション | ✅ 完全一致 | 保留 |
| DecoderRuntimeSoftware | 软件解码 | 軟件解碼 | 軟體解碼 | software decoding | ソフトウェアデコード | ✅ 完全一致 | 保留 |
| DecoderRuntimeUnknown | 检测中 | 偵測中 | 偵測中 | detecting | 検出中 | ✅ 完全一致 | 保留 |
| DecoderSoftwareCompatible | 软件兼容 | 軟件相容 | 軟體相容 | Software compatibility | ソフトウェア互換 | ✅ 完全一致 | 保留 |
| DecoderStatusAppliedFormat | 解码器已生效：策略 {0}；实际 {1}。 | 解碼器已生效：策略 {0}；實際 {1}。 | 解碼器已生效：策略 {0}；實際 {1}。 | Decoder active: policy {0}; actual {1}. | デコーダーを使用中: ポリシー{0}、実際は{1}。 | ✅ 完全一致 | 保留 |
| DecoderStatusDetecting | 解码器状态：正在读取实际解码链路… | 解碼器狀態：正在讀取實際解碼鏈路… | 解碼器狀態：正在讀取實際解碼鏈路… | Decoder status: detecting the active decode path… | デコーダーの状態: 使用中のデコード経路を検出しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| DecoderStatusFailedFormat | 解码器切换失败：已保留 {0}（实际 {1}），将于后续关键帧重试 {2}。 | 解碼器切換失敗：已保留 {0}（實際 {1}），將於後續關鍵幀重試 {2}。 | 解碼器切換失敗：已保留 {0}（實際 {1}），將於後續關鍵影格重試 {2}。 | Decoder switch failed: retained {0} (actual {1}); {2} will retry at a later keyframe. | デコーダーを切り替えられませんでした: {0}を維持しています（実際は{1}）。{2}は、後のキーフレームで再試行します。 | ✅ 完全一致 | 保留 |
| DecoderStatusPendingFormat | 解码器切换中：{0} -&gt; {1}；当前实际 {2}，正在等待关键帧。 | 解碼器切換中：{0} -&gt; {1}；目前實際 {2}，正在等待關鍵幀。 | 解碼器切換中：{0} -&gt; {1}；目前實際 {2}，正在等待關鍵影格。 | Decoder switch pending: {0} -&gt; {1}; active engine {2}, waiting for a keyframe. | デコーダーの切り替えを保留中: {0} -&gt; {1}。使用中のエンジンは{2}で、キーフレームを待っています。 | ✅ 完全一致 | 保留 |
| DeveloperAbout | 关于与更新 | 關於與更新 | 關於與更新 | About and updates | 情報とアップデート | ✅ 完全一致 | 保留 |
| DeveloperAboutDescription | 版本、诊断和更新信息 | 版本、診斷和更新資料 | 版本、診斷和更新資料 | Version, diagnostics, and updates | バージョン、診断、アップデート | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeveloperActivate | 激活 | 啟用 | 啟用 | Activate | アクティブにする | ✅ 完全一致 | 保留 |
| DeveloperAdvancedSettings | 高级 USB 设置 | 進階 USB 設定 | 進階 USB 設定 | Advanced USB settings | USBの詳細設定 | ✅ 完全一致 | 保留 |
| DeveloperAdvancedSettingsDescription | 分辨率输入验证 | 解像度輸入驗證 | 解析度輸入驗證 | Resolution input validation | 解像度の入力検証 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeveloperAirPlaySelectionWindow | AirPlay 设备选择 | AirPlay 裝置選擇 | AirPlay 裝置選擇 | AirPlay device selection | AirPlayデバイスの選択 | ✅ 完全一致 | 保留 |
| DeveloperBluetoothClientBindingWindow | 蓝牙客户端绑定 | 藍牙用戶端綁定 | 藍牙用戶端綁定 | Bluetooth client binding | Bluetoothクライアントの紐づけ | ✅ 完全一致 | 保留 |
| DeveloperBluetoothConnectionWindow | 蓝牙连接窗口 | 藍牙連接視窗 | 藍牙連線視窗 | Bluetooth connection window | Bluetooth接続ウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperBluetoothControlNoticeWindow | 蓝牙控制通知 | 藍牙控制通知 | 藍牙控制通知 | Bluetooth control notice | Bluetooth操作のお知らせ | ✅ 完全一致 | 保留 |
| DeveloperCaptureError | 投屏错误弹窗 | 螢幕鏡像錯誤提示 | 螢幕鏡像錯誤提示 | Mirroring error prompt | ミラーリングエラーのダイアログ | ✅ 完全一致 | 保留 |
| DeveloperCaptureErrorDescription | 视频流失败后的错误提示 | 影片串流失敗後顯示的錯誤提示 | 影片串流失敗後顯示的錯誤提示 | Error shown after a video-stream failure | 映像ストリームの失敗後に表示されるエラー | ✅ 完全一致 | 保留 |
| DeveloperCaptureRecovery | 采集恢复提示 | 擷取恢復提示 | 擷取恢復提示 | Capture recovery prompt | キャプチャ復旧のダイアログ | ✅ 完全一致 | 保留 |
| DeveloperCaptureRecoveryDescription | 无响应时的恢复说明 | 擷取沒有回應時的恢復說明 | 擷取沒有回應時的恢復說明 | Recovery guidance for an unresponsive capture | 応答しないキャプチャの復旧ガイド | ✅ 完全一致 | 保留 |
| DeveloperClose | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 保留 |
| DeveloperDeviceBindingWindow | 设备绑定窗口 | 裝置綁定視窗 | 裝置綁定視窗 | Device binding window | デバイス紐づけウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperDevices | 投屏来源 | 螢幕鏡像來源 | 螢幕鏡像來源 | Mirroring sources | ミラーリングのソース | ✅ 完全一致 | 保留 |
| DeveloperDevicesDescription | 设备列表和连接面板 | 裝置清單和連線面板 | 裝置清單和連線面板 | Device list and connection panel | デバイス一覧と接続パネル | ✅ 完全一致 | 保留 |
| DeveloperDriver | 驱动管理 | 驅動程式管理 | 驅動程式管理 | Driver manager | ドライバー管理 | ✅ 完全一致 | 保留 |
| DeveloperDriverDescription | 打开独立驱动管理器 | 開啟獨立驅動程式管理員 | 開啟獨立驅動程式管理員 | Open the standalone driver manager | 単体のドライバー管理を開く | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeveloperImageSettings | 图像设置 | 影像設定 | 影像設定 | Image settings | 画像設定 | ✅ 完全一致 | 保留 |
| DeveloperImageSettingsDescription | 亮度、对比度和伽马滑块 | 亮度、對比度和伽馬滑桿 | 亮度、對比和伽馬滑桿 | Brightness, contrast, and gamma sliders | 明るさ、コントラスト、ガンマのスライダー | ✅ 完全一致 | 保留 |
| DeveloperInstanceConflict | 实例冲突窗口 | 執行個體衝突視窗 | 執行個體衝突視窗 | Instance conflict window | 多重起動の競合ウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperInstanceConflictDescription | 只读的多实例提示 | 唯讀多執行個體提示 | 唯讀多執行個體提示 | Read-only multi-instance prompt | 読み取り専用の多重起動ダイアログ | ✅ 完全一致 | 保留 |
| DeveloperLanguageEnglish | English | English | English | English | English | ✅ 完全一致 | 保留 |
| DeveloperLanguageSimplified | 简体中文 | 簡體中文 | 簡體中文 | Simplified Chinese | 簡体字中国語 | ✅ 完全一致 | 保留 |
| DeveloperLanguageSystem | 跟随系统 | 跟隨系統 | 跟隨系統 | System | システムの設定に従う | ✅ 完全一致 | 保留 |
| DeveloperLanguageTaiwan | 繁體中文（台灣） | 繁體中文（台灣） | 繁體中文（台灣） | Traditional Chinese (Taiwan) | 繁体字中国語（台湾） | ✅ 完全一致 | 保留 |
| DeveloperLanguageTraditional | 繁体中文（香港） | 繁體中文（香港） | 繁體中文（香港） | Traditional Chinese (Hong Kong) | 繁体字中国語（香港） | ✅ 完全一致 | 保留 |
| DeveloperMediaOutput | 媒体输出窗口 | 媒體輸出視窗 | 媒體輸出視窗 | Media output window | メディア出力ウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperMediaOutputDescription | 录制、直播和摄像头标签页 | 錄製、直播和攝影機分頁 | 錄製、直播和攝影機分頁 | Recording, live, and camera tabs | 録画、ライブ配信、カメラのタブ | ✅ 完全一致 | 保留 |
| DeveloperMirroring | 投屏控制 | 螢幕鏡像控制 | 螢幕鏡像控制 | Mirroring controls | ミラーリング操作 | ✅ 完全一致 | 保留 |
| DeveloperMirroringDescription | 主工作区与预览状态 | 主工作區和預覽狀態 | 主工作區和預覽狀態 | Main workspace and preview state | メインのワークスペースとプレビューの状態 | ✅ 完全一致 | 保留 |
| DeveloperNativePreview | 独立预览窗口 | 獨立預覽視窗 | 獨立預覽視窗 | Independent preview window | 独立プレビューウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperNativePreviewBody | 原生预览窗口 | 原生預覽視窗 | 原生預覽視窗 | Native preview window | ネイティブのプレビューウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperNativePreviewDescription | 原生窗口圆角和菜单外壳 | 原生視窗圓角和選單外殼 | 原生視窗圓角和選單外殼 | Native window corner and menu shell | ネイティブウィンドウの角とメニューのシェル | ✅ 完全一致 | 保留 |
| DeveloperNativePreviewTitle | iPhoneMirror 独立预览 | iPhoneMirror 獨立預覽 | iPhoneMirror 獨立預覽 | iPhoneMirror independent preview | iPhoneMirror独立プレビュー | ✅ 完全一致 | 保留 |
| DeveloperOutput | 输出设置 | 輸出設定 | 輸出設定 | Output settings | 出力の設定 | ✅ 完全一致 | 保留 |
| DeveloperOutputDescription | 录制、推流和虚拟摄像头 | 錄製、串流和虛擬攝影機 | 錄製、串流和虛擬攝影機 | Recording, streaming, and virtual camera | 録画、配信、仮想カメラ | ❌ 含义不一致 → ✅ 已修复 | 补齐虚拟摄像头含义 |
| DeveloperParamLanguage | 界面语言 | 介面語言 | 介面語言 | Interface language | 表示言語 | ✅ 完全一致 | 保留 |
| DeveloperParamOpacity | 主窗口透明度 | 主視窗透明度 | 主視窗透明度 | Main window opacity | メインウィンドウの不透明度 | ✅ 完全一致 | 保留 |
| DeveloperParamTheme | 应用主题 | 應用程式主題 | 應用程式主題 | Application theme | アプリのテーマ | ✅ 完全一致 | 保留 |
| DeveloperParamTopmost | 主窗口置顶 | 主視窗置頂 | 主視窗最上層顯示 | Keep main window on top | メインウィンドウを常に手前に表示 | ✅ 完全一致 | 保留 |
| DeveloperParamWindowPreset | 窗口预设 | 視窗預設 | 視窗預設 | Window preset | ウィンドウのプリセット | ✅ 完全一致 | 保留 |
| DeveloperParametersReset | 参数已恢复默认值 | 參數已還原為預設值 | 參數已還原為預設值 | Parameters restored to defaults | パラメーターを既定に戻しました | ✅ 完全一致 | 保留 |
| DeveloperPresetCompact | 紧凑 1280×700 | 緊湊 1280×700 | 緊湊 1280×700 | Compact 1280×700 | コンパクト（1280×700） | ✅ 完全一致 | 保留 |
| DeveloperPresetDefault | 默认 1540×900 | 預設 1540×900 | 預設 1540×900 | Default 1540×900 | 既定（1540×900） | ✅ 完全一致 | 保留 |
| DeveloperPresetMaximize | 最大化 | 最大化 | 最大化 | Maximize | 最大化 | ✅ 完全一致 | 保留 |
| DeveloperPreviewDeviceName | 预览设备 | 預覽裝置 | 預覽裝置 | Preview device | プレビュー用デバイス | ✅ 完全一致 | 保留 |
| DeveloperPreviewPromptBody | 这是标准确认提示框的安全预览。确认和取消按钮不会执行应用操作。 | 這是標準確認提示的安全預覽。按鈕不會執行應用程式操作。 | 這是標準確認提示的安全預覽。按鈕不會執行應用程式操作。 | This is a safe preview of the standard confirmation prompt. The buttons do not perform an app action. | 標準の確認ダイアログを安全に確認するためのプレビューです。ボタンを押してもアプリの操作は実行されません。 | ✅ 完全一致 | 保留 |
| DeveloperPreviewPromptTitle | 开发者提示预览 | 開發者提示預覽 | 開發者提示預覽 | Developer prompt preview | 開発者向けダイアログのプレビュー | ✅ 完全一致 | 保留 |
| DeveloperPreviewReverseControlUnavailable | 开发者服务未就绪（开发者工具预览） | 開發者服務未就緒（開發者工具預覽） | 開發者服務未就緒（開發者工具預覽） | The developer service is not ready (developer-tools preview). | 開発者サービスの準備ができていません（開発者ツールのプレビュー）。 | ✅ 完全一致 | 保留 |
| DeveloperPreviewUpdateBody | 这是发布说明布局的本地预览。下载按钮已禁用，不会访问网络或启动安装程序。 | 這是發佈說明版面的本機預覽。下載按鈕已停用，不會連線或啟動安裝程式。 | 這是發布說明版面的本機預覽。下載按鈕已停用，不會連線或啟動安裝程式。 | This is a local preview of the release-notes layout. Downloading is disabled and no network or installer is started. | リリースノートのレイアウトをローカルで確認するプレビューです。ダウンロードは無効で、ネットワークやインストーラーも起動しません。 | ✅ 完全一致 | 保留 |
| DeveloperPreviewUpdateTitle | 开发者更新预览 | 開發者更新預覽 | 開發者更新預覽 | Developer update preview | 開発者向けアップデートのプレビュー | ✅ 完全一致 | 保留 |
| DeveloperProjectionSettings | 投屏设置窗口 | 螢幕鏡像設定視窗 | 螢幕鏡像設定視窗 | Mirroring settings window | ミラーリング設定ウィンドウ | ❌ 术语不一致 → ✅ 已修复 | 投屏统一为 mirroring，视频应用投放仍使用 casting |
| DeveloperProjectionSettingsDescription | 设备状态和快捷操作 | 裝置狀態和快速操作 | 裝置狀態和快速操作 | Device status and quick actions | デバイスの状態とクイック操作 | ✅ 完全一致 | 保留 |
| DeveloperPrompt | 确认提示框 | 確認提示 | 確認提示 | Confirmation prompt | 確認ダイアログ | ✅ 完全一致 | 保留 |
| DeveloperPromptDescription | 标准确认和信息布局 | 標準確認和資料版面 | 標準確認和資料版面 | Standard confirmation and info layout | 標準の確認・情報レイアウト | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeveloperProtectedContent | 受保护视频提示 | 受保護影片提示 | 受保護影片提示 | Protected-video prompt | 保護された動画のダイアログ | ✅ 完全一致 | 保留 |
| DeveloperProtectedContentDescription | DRM/FairPlay 黑屏检查提示 | DRM/FairPlay 黑畫面檢查提示 | DRM/FairPlay 黑畫面檢查提示 | DRM/FairPlay black-screen check | DRM/FairPlayによる黒画面の確認 | ✅ 完全一致 | 保留 |
| DeveloperReadOnlyPreview | 只读预览：不会执行真实输出操作。 | 唯讀預覽：不會執行真實輸出操作。 | 唯讀預覽：不會執行真實輸出操作。 | Read-only preview: no real output operation will run. | 読み取り専用のプレビューです。実際の出力操作は実行されません。 | ✅ 完全一致 | 保留 |
| DeveloperRefresh | 刷新检查 | 重新整理檢查器 | 重新整理檢查器 | Refresh inspector | インスペクターを更新 | ✅ 完全一致 | 保留 |
| DeveloperResetParameters | 重置参数 | 重設參數 | 重設參數 | Reset parameters | パラメーターをリセット | ✅ 完全一致 | 保留 |
| DeveloperReverseControlError | 反向控制错误弹窗 | 反向控制錯誤對話方塊 | 反向控制錯誤對話方塊 | Reverse control error prompt | リモート操作エラーのダイアログ | ✅ 完全一致 | 保留 |
| DeveloperReverseControlErrorDescription | 反向控制桥接失败时的错误信息 | 反向控制橋接失敗時的錯誤訊息 | 反向控制橋接失敗時的錯誤訊息 | Error shown when the reverse-control bridge fails | リモート操作のブリッジが失敗したときに表示されるエラー | ✅ 完全一致 | 保留 |
| DeveloperReverseControlStatusWindow | 反向控制状态 | 反向控制狀態 | 反向控制狀態 | Reverse-control status | リモート操作の状態 | ✅ 完全一致 | 保留 |
| DeveloperReverseControlWiredPrerequisite | 有线控制前置提示 | 有線控制前置提示 | 有線控制前置提示 | Wired control prerequisites | 有線操作の前提条件 | ✅ 完全一致 | 保留 |
| DeveloperReverseControlWiredPrerequisiteDescription | 开发者模式、USB 信任和 DDI 说明 | 開發者模式、USB 信任和 DDI 說明 | 開發者模式、USB 信任和 DDI 說明 | Developer Mode, USB trust, and DDI guidance | デベロッパモード、USBの信頼、DDIの案内 | ✅ 完全一致 | 保留 |
| DeveloperReverseControlWirelessPrerequisite | 无线控制前置提示 | 無線控制前置提示 | 無線控制前置提示 | Wireless control prerequisites | 無線操作の前提条件 | ✅ 完全一致 | 保留 |
| DeveloperReverseControlWirelessPrerequisiteDescription | 开发者模式、配对和局域网说明 | 開發者模式、配對和區域網絡說明 | 開發者模式、配對和區域網路說明 | Developer Mode, pairing, and local network guidance | デベロッパモード、ペアリング、ローカルネットワークの案内 | ✅ 完全一致 | 保留 |
| DeveloperRuntimeCulture | 区域 | 地區 | 地區 | Culture | カルチャ | ✅ 完全一致 | 保留 |
| DeveloperRuntimeDpi | 文字缩放 | 文字縮放 | 文字縮放 | Text scale | 文字サイズの倍率 | ✅ 完全一致 | 保留 |
| DeveloperRuntimeTheme | 主题 | 主題 | 主題 | Theme | テーマ | ✅ 完全一致 | 保留 |
| DeveloperRuntimeVersion | 版本 | 版本 | 版本 | Version | バージョン | ✅ 完全一致 | 保留 |
| DeveloperRuntimeWindows | 窗口数 | 視窗數量 | 視窗數量 | Window count | ウィンドウ数 | ✅ 完全一致 | 保留 |
| DeveloperSessionClosed | 投屏已停止弹窗 | 螢幕鏡像已停止提示 | 螢幕鏡像已停止提示 | Mirroring stopped prompt | ミラーリング停止のダイアログ | ✅ 完全一致 | 保留 |
| DeveloperSessionClosedDescription | 从控制中心停止镜像后的提示 | 從控制中心停止鏡像後顯示的提示 | 從控制中心停止鏡像後顯示的提示 | Shown after mirroring is stopped from Control Center | コントロールセンターからミラーリングを停止した後に表示されます | ✅ 完全一致 | 保留 |
| DeveloperSettings | 投屏设置 | 螢幕鏡像設定 | 螢幕鏡像設定 | Mirroring settings | ミラーリングの設定 | ❌ 术语不一致 → ✅ 已修复 | 投屏统一为 mirroring，视频应用投放仍使用 casting |
| DeveloperSettingsDescription | AirPlay、语言和主题 | AirPlay、語言和主題 | AirPlay、語言和主題 | AirPlay, language, and theme | AirPlay、言語、テーマ | ✅ 完全一致 | 保留 |
| DeveloperShortcutSettingsWindow | 快捷键设置窗口 | 快捷鍵設定視窗 | 快速鍵設定視窗 | Shortcut settings window | ショートカット設定ウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperStartupError | 启动错误窗口 | 啟動錯誤視窗 | 啟動錯誤視窗 | Startup error window | 起動エラーウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperStartupErrorBody | 这是启动错误窗口的本地预览，用于检查错误摘要、日志路径和展开详情。 | 這是啟動錯誤視窗的本機預覽，用於檢查錯誤摘要、記錄路徑和詳細資料。 | 這是啟動錯誤視窗的本機預覽，用於檢查錯誤摘要、記錄檔路徑和詳細資料。 | This is a local preview of the startup error window for checking the summary, log path, and details expander. | 概要、ログのパス、詳細の展開表示を確認するための、起動エラーウィンドウのローカルプレビューです。 | ✅ 完全一致 | 保留 |
| DeveloperStartupErrorDescription | 错误摘要和诊断日志 | 錯誤摘要和診斷記錄 | 錯誤摘要和診斷記錄檔 | Error summary and diagnostic log | エラーの概要と診断ログ | ✅ 完全一致 | 保留 |
| DeveloperSurfaceOpenFailed | 打开预览失败 | 開啟預覽失敗 | 開啟預覽失敗 | Preview failed | プレビューを開けませんでした | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DeveloperSurfaceOpenFailedFormat | 打开预览失败：{0} | 開啟預覽失敗：{0} | 開啟預覽失敗：{0} | Could not open the preview: {0} | プレビューを開けませんでした: {0} | ✅ 完全一致 | 保留 |
| DeveloperSurfaceOpened | 预览窗口已打开 | 預覽視窗已開啟 | 預覽視窗已開啟 | Preview window opened | プレビューウィンドウを開きました | ✅ 完全一致 | 保留 |
| DeveloperThemeDark | 深色 | 深色 | 深色 | Dark | ダーク | ✅ 完全一致 | 保留 |
| DeveloperThemeLight | 浅色 | 淺色 | 淺色 | Light | ライト | ✅ 完全一致 | 保留 |
| DeveloperThemeSystem | 跟随系统 | 跟隨系統 | 跟隨系統 | System | システム | ✅ 完全一致 | 保留 |
| DeveloperToolsInspectorSection | 窗口检查器 | 視窗檢查器 | 視窗檢查器 | Window inspector | ウィンドウインスペクター | ✅ 完全一致 | 保留 |
| DeveloperToolsParametersHint | 参数仅影响当前进程，便于检查主题、缩放和窗口协调 | 只影響目前工作階段，用於檢查主題、縮放和視窗協調 | 只影響目前工作階段，用於檢查主題、縮放和視窗協調 | Session-only controls for theme, scale, and window coordination | テーマ、スケール、ウィンドウ連携を、このセッションの間だけ変更します | ✅ 完全一致 | 保留 |
| DeveloperToolsParametersSection | 运行期参数 | 執行階段參數 | 執行階段參數 | Runtime parameters | 実行時パラメーター | ✅ 完全一致 | 保留 |
| DeveloperToolsPreviewBadge | 只读预览 | 唯讀預覽 | 唯讀預覽 | READ-ONLY PREVIEW | 読み取り専用プレビュー | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DeveloperToolsSubtitle | 管理 Automation API，预览页面、弹窗和运行期参数 | 管理 Automation API，預覽頁面、對話方塊和執行階段參數 | 管理 Automation API，預覽頁面、對話方塊和執行階段參數 | Manage Automation API and preview pages, dialogs, and runtime parameters | Automation APIとプレビューページ、ダイアログ、実行時パラメーターを管理します | ✅ 完全一致 | 保留 |
| DeveloperToolsTitle | 开发者工具 | 開發者工具 | 開發者工具 | Developer tools | 開発者ツール | ✅ 完全一致 | 保留 |
| DeveloperToolsWindowsHint | 打开现有窗口的安全预览；网络、设备和破坏性操作已隔离 | 開啟安全預覽；網絡、裝置和破壞性操作已隔離 | 開啟安全預覽；網路、裝置和破壞性操作已隔離 | Open safe previews; network, device, and destructive paths are isolated | 安全なプレビューを開きます。ネットワーク、デバイス、破壊的な処理は分離されています | ✅ 完全一致 | 保留 |
| DeveloperToolsWindowsSection | 子窗口与弹窗 | 子視窗與對話方塊 | 子視窗與對話方塊 | Child windows and dialogs | 子ウィンドウとダイアログ | ✅ 完全一致 | 保留 |
| DeveloperToolsWorkspaceHint | 快速切换主窗口中的所有工作区状态 | 快速切換主視窗的所有工作區狀態 | 快速切換主視窗的所有工作區狀態 | Jump through every workspace state in the main window | メインウィンドウのすべてのワークスペース状態に移動します | ✅ 完全一致 | 保留 |
| DeveloperToolsWorkspaceSection | 工作区页面 | 工作區頁面 | 工作區頁面 | Workspace pages | ワークスペースのページ | ✅ 完全一致 | 保留 |
| DeveloperUpdate | 更新窗口 | 更新視窗 | 更新視窗 | Update window | アップデートウィンドウ | ✅ 完全一致 | 保留 |
| DeveloperUpdateDescription | 版本信息和发布说明 | 版本資料和發佈說明 | 版本資料和發布說明 | Version details and release notes | バージョンの詳細とリリースノート | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeveloperUsbConfigError | USB 配置错误弹窗 | USB 設定錯誤提示 | USB 設定錯誤提示 | USB configuration prompt | USB構成のダイアログ | ✅ 完全一致 | 保留 |
| DeveloperUsbConfigErrorDescription | USB 投屏配置失败后的提示 | USB 螢幕鏡像設定失敗後顯示的提示 | USB 螢幕鏡像設定失敗後顯示的提示 | Shown when USB mirroring setup fails | USBミラーリングのセットアップに失敗したときに表示されます | ✅ 完全一致 | 保留 |
| DeveloperUsbMode | USB 模式详情 | USB 模式詳情 | USB 模式詳情 | USB mode details | USBモードの詳細 | ✅ 完全一致 | 保留 |
| DeveloperUsbModeDescription | 模式说明和注意事项 | 模式說明和注意事項 | 模式說明和注意事項 | Mode explanation and notices | モードの説明と注意事項 | ✅ 完全一致 | 保留 |
| DeviceAlreadyMirroring | 该设备已在主预览中投屏 | 這部裝置已在主預覽中螢幕鏡像 | 這台裝置已在主預覽中進行螢幕鏡像 | This device is already mirrored in the main preview | このデバイスは、すでにメインのプレビューでミラーリング中です | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DeviceBindingAddProfileToolTip | 添加 AirPlay 设备档案 | 新增 AirPlay 裝置檔案 | 新增 AirPlay 裝置設定檔 | Add AirPlay device profile | AirPlayデバイスのプロファイルを追加 | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlay | AirPlay | AirPlay | AirPlay | AirPlay | AirPlay | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlayAddTitle | 添加 AirPlay 设备档案 | 新增 AirPlay 裝置檔案 | 新增 AirPlay 裝置設定檔 | Add AirPlay device profile | AirPlayデバイスのプロファイルを追加 | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlayBrief | 连接同一 Wi-Fi，打开 iPhone 的“屏幕镜像”并选择这台电脑。 | 連接同一 Wi-Fi，開啟 iPhone 的「螢幕鏡像輸出」並選擇這台電腦。 | 連接同一 Wi-Fi，開啟 iPhone 的「螢幕鏡像輸出」並選擇這台電腦。 | On the same Wi-Fi, open Screen Mirroring and select this computer. | 同じWi-Fiで画面ミラーリングを開き、このコンピュータを選択してください。 | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlayDescription | 请让手机与电脑处于同一局域网，在 iPhone/iPad 打开“控制中心”→“屏幕镜像”，选择 iPhoneMirror。镜像建立后会出现在下方列表；选择它并绑定到此档案。 | 請讓手機與電腦處於同一區域網絡，在 iPhone/iPad 開啟「控制中心」→「螢幕鏡像」，選擇 iPhoneMirror。鏡像建立後會出現在下方清單；選擇它並綁定到此檔案。 | 請讓手機與電腦連線至同一區域網路，在 iPhone/iPad 開啟「控制中心」→「螢幕鏡像輸出」，選擇 iPhoneMirror。連線後，裝置會出現在下方清單；請選取並綁定至此設定檔。 | Put the phone and computer on the same local network. On the iPhone/iPad, open Control Center → Screen Mirroring and choose iPhoneMirror. After mirroring starts, select it below and bind it to this profile. | iPhone/iPadとコンピュータを同じローカルネットワークに接続します。iPhone/iPadでコントロールセンターを開き、「画面ミラーリング」からiPhoneMirrorを選びます。ミラーリングが始まったら、下の一覧でそのデバイスを選び、このプロファイルに紐づけます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DeviceBindingAirPlayReady | AirPlay 已就绪。在 iPhone 控制中心打开“屏幕镜像”，选择这台电脑。 | AirPlay 已就緒。在 iPhone 控制中心開啟「螢幕鏡像輸出」，選擇這台電腦。 | AirPlay 已就緒。在 iPhone 控制中心開啟「螢幕鏡像輸出」，選擇這台電腦。 | AirPlay is ready. Open Screen Mirroring in Control Center and select this computer. | AirPlayの準備ができました。コントロールセンターで画面ミラーリングを開き、このコンピュータを選択してください。 | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlayReceiving | AirPlay 接收已启动 | AirPlay 接收已啟動 | AirPlay 接收已啟動 | AirPlay receiver is running | AirPlayレシーバーが動作中です | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlaySelectDescription | 选择当前正在镜像的 AirPlay 设备以创建档案。 | 選擇目前正在鏡像的 AirPlay 裝置以建立檔案。 | 選擇目前正在鏡像的 AirPlay 裝置以建立設定檔。 | Select the AirPlay device currently being mirrored to create a profile. | 現在ミラーリング中のAirPlayデバイスを選ぶと、プロファイルを作成します。 | ✅ 完全一致 | 保留 |
| DeviceBindingAirPlaySelectTitle | 选择 AirPlay 设备 | 選擇 AirPlay 裝置 | 選擇 AirPlay 裝置 | Select AirPlay device | AirPlayデバイスを選択 | ✅ 完全一致 | 保留 |
| DeviceBindingBind | 绑定所选设备 | 綁定所選裝置 | 綁定所選裝置 | Bind selected device | 選択したデバイスを紐づけ | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| DeviceBindingBluetooth | Bluetooth | Bluetooth | Bluetooth | Bluetooth | Bluetooth | ✅ 完全一致 | 保留 |
| DeviceBindingBluetoothBrief | 连接蓝牙后开启“辅助触控”，即可通过电脑控制 iPhone。 | 連接藍牙後開啟「輔助觸控」，即可透過電腦控制 iPhone。 | 連接藍牙後開啟「輔助觸控」，即可透過電腦控制 iPhone。 | Pair via Bluetooth and enable AssistiveTouch to control your iPhone. | Bluetoothでペアリングし、AssistiveTouchを有効にすると、iPhoneを操作できます。 | ✅ 完全一致 | 保留 |
| DeviceBindingBluetoothBroadcasting | 电脑正在广播 Bluetooth HID 设备 | 電腦正在廣播 Bluetooth HID 裝置 | 電腦正在廣播 Bluetooth HID 裝置 | The computer is broadcasting a Bluetooth HID device | コンピュータがBluetooth HIDデバイスとして公開されています | ✅ 完全一致 | 保留 |
| DeviceBindingBluetoothDescription | 点击“连接设备”后，电脑会临时广播 Bluetooth HID 服务。请在 iPhone/iPad 的“设置”→“蓝牙”中选择此电脑完成配对，再点击等待窗口中的“下一步”选择 HID 设备。完成后只保存绑定，不会启动反向控制。 | 按一下「連接裝置」後，電腦會暫時廣播 Bluetooth HID 服務。請在 iPhone/iPad 的「設定」→「藍牙」中選擇此電腦完成配對，再按等待視窗中的「下一步」選擇 HID 裝置。完成後只會儲存綁定，不會啟動反向控制。 | 按一下「連線裝置」後，電腦會暫時廣播 Bluetooth HID 服務。請在 iPhone/iPad 的「設定」→「藍牙」中選擇此電腦完成配對，再按等待視窗中的「下一步」選擇 HID 裝置。完成後只會儲存綁定，不會啟動反向控制。 | Click “Connect device” to temporarily advertise a Bluetooth HID service. On the iPhone/iPad, open Settings → Bluetooth and pair with this computer. Click “Next” in the waiting window and select the HID device. Only the binding is saved; reverse control is not started. | 「デバイスを接続」をクリックすると、Bluetooth HIDサービスを一時的に公開します。iPhone/iPadで「設定」→「Bluetooth」を開き、このコンピュータとペアリングします。待機中のウィンドウで「次へ」をクリックし、HIDデバイスを選んでください。保存されるのは紐づけだけで、リモート操作は開始されません。 | ❌ 含义不一致、❌ 术语不一致 → ✅ 已修复 | 补齐英文遗漏的“下一步”操作；统一反向控制正式名称；静态未发现引用，保留待后续调用核对 |
| DeviceBindingBluetoothSaveFailed | 无法保存 Bluetooth 设备绑定。 | 無法儲存 Bluetooth 裝置綁定。 | 無法儲存 Bluetooth 裝置綁定。 | Could not save the Bluetooth device binding. | Bluetoothデバイスの紐づけを保存できませんでした。 | ✅ 完全一致 | 保留 |
| DeviceBindingBluetoothStartFailed | 无法启动 Bluetooth HID 连接。请确认电脑蓝牙已开启。 | 無法啟動 Bluetooth HID 連線。請確認電腦藍牙已開啟。 | 無法啟動 Bluetooth HID 連線。請確認電腦藍牙已開啟。 | Could not start the Bluetooth HID connection. Make sure Bluetooth is enabled on this computer. | Bluetooth HID接続を開始できませんでした。このコンピュータでBluetoothが有効になっているか確認してください。 | ✅ 完全一致 | 保留 |
| DeviceBindingBluetoothWaitingDescription | 请在 iPhone/iPad 打开“设置”→“蓝牙”，在设备列表中选择此电脑并完成配对。配对成功后返回这里，点击“下一步”选择刚刚连接的 HID 设备。此流程只保存设备绑定，不会启动蓝牙反向控制。 | 請在 iPhone/iPad 開啟「設定」→「藍牙」，在裝置清單中選擇此電腦並完成配對。配對成功後返回這裡，按一下「下一步」選擇剛剛連接的 HID 裝置。此流程只會儲存裝置綁定，不會啟動藍牙反向控制。 | 請在 iPhone/iPad 開啟「設定」→「藍牙」，在裝置清單中選擇此電腦並完成配對。配對成功後返回這裡，按一下「下一步」選擇剛剛連線的 HID 裝置。此流程只會儲存裝置綁定，不會啟動藍牙反向控制。 | On the iPhone/iPad, open Settings → Bluetooth, select this computer, and complete pairing. Return here and click “Next” to choose the HID device you just connected. This process only saves the device binding; Bluetooth reverse control will not start. | iPhone/iPadで「設定」→「Bluetooth」を開き、このコンピュータを選んでペアリングを完了します。ここに戻って「次へ」をクリックし、いま接続したHIDデバイスを選んでください。この操作で保存されるのはデバイスの紐づけだけで、Bluetoothによるリモート操作は開始されません。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称 |
| DeviceBindingBluetoothWaitingStatus | 等待设备连接 HID 服务 | 等待裝置連接 HID 服務 | 等待裝置連線 HID 服務 | Waiting for the device to connect to the HID service | デバイスがHIDサービスに接続するのを待っています | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| DeviceBindingBluetoothWaitingTitle | 等待 Bluetooth HID 连接 | 等待 Bluetooth HID 連線 | 等待 Bluetooth HID 連線 | Waiting for Bluetooth HID connection | Bluetooth HID接続を待機中 | ✅ 完全一致 | 保留 |
| DeviceBindingBound | 未绑定 | 未綁定 | 未綁定 | Not bound | 未紐づけ | ❌ 含义不一致 → ✅ 已修复 | 调用条件为身份为空；英文 Bound 与实际未绑定状态相反 |
| DeviceBindingBoundConnected | 已绑定 · 已连接 | 已綁定 · 已連接 | 已綁定 · 已連線 | Bound · Connected | 紐づけ済み · 接続中 | ✅ 完全一致 | 保留 |
| DeviceBindingBoundDisconnected | 已绑定 · 已断开 | 已綁定 · 已中斷連線 | 已綁定 · 已中斷連線 | Bound · Disconnected | 紐づけ済み · 切断中 | ✅ 完全一致 | 保留 |
| DeviceBindingBoundMirroring | 已绑定 · 当前镜像 | 已綁定 · 目前鏡像 | 已綁定 · 目前鏡像 | Bound · Currently mirrored | 紐づけ済み · ミラーリング中 | ✅ 完全一致 | 保留 |
| DeviceBindingBoundUnavailable | 已绑定 · 当前不可用 | 已綁定 · 目前不可用 | 已綁定 · 目前不可用 | Bound · Currently unavailable | 紐づけ済み · 現在利用できません | ✅ 完全一致 | 保留 |
| DeviceBindingCancel | 取消 | 取消 | 取消 | Cancel | キャンセル | ✅ 完全一致 | 保留 |
| DeviceBindingCompatibleNeedsConfirmation | 设备型号一致，需要用户确认。 | 裝置型號一致，需要用戶確認。 | 裝置型號一致，需要使用者確認。 | The device model matches, but user confirmation is required. | デバイスの機種は一致していますが、ユーザーの確認が必要です。 | ✅ 完全一致 | 保留 |
| DeviceBindingConfirmBodyFormat | {0}<br><br>确认这是同一台真实设备吗？ | {0}<br><br>確認這是同一台真實裝置嗎？ | {0}<br><br>確認這是同一台真實裝置嗎？ | {0}<br><br>Are you sure this is the same physical device? | {0}<br><br>同じ実機で間違いありませんか？ | ✅ 完全一致 | 保留 |
| DeviceBindingConfirmTitle | 确认设备绑定 | 確認裝置綁定 | 確認裝置綁定 | Confirm device binding | デバイスの紐づけを確認 | ✅ 完全一致 | 保留 |
| DeviceBindingConnect | 连接设备 | 連接裝置 | 連線裝置 | Connect device | デバイスを接続 | ✅ 完全一致 | 保留 |
| DeviceBindingCreateFailed | 无法创建设备档案。 | 無法建立裝置檔案。 | 無法建立裝置設定檔。 | Could not create the device profile. | デバイスプロファイルを作成できませんでした。 | ✅ 完全一致 | 保留 |
| DeviceBindingCreateProfile | 创建档案 | 建立檔案 | 建立設定檔 | Create profile | プロファイルを作成 | ✅ 完全一致 | 保留 |
| DeviceBindingDeleteConfirmation | 删除该设备档案将解除所有已绑定的 USB、AirPlay 和 Bluetooth 身份。是否继续？ | 刪除此裝置檔案將解除所有已綁定的 USB、AirPlay 和 Bluetooth 身份。是否繼續？ | 刪除此裝置設定檔將解除所有已綁定的 USB、AirPlay 和 Bluetooth 身分。是否繼續？ | Deleting this device profile will remove all bound USB, AirPlay, and Bluetooth identities. Continue? | このデバイスプロファイルを削除すると、紐づけられているUSB、AirPlay、Bluetoothの識別情報がすべて削除されます。続行しますか？ | ✅ 完全一致 | 保留 |
| DeviceBindingDeleteProfile | 删除档案 | 刪除裝置檔案 | 刪除裝置設定檔 | Delete profile | プロファイルを削除 | ✅ 完全一致 | 保留 |
| DeviceBindingDeleteTitle | 删除设备档案 | 刪除裝置檔案 | 刪除裝置設定檔 | Delete device profile | デバイスプロファイルの削除 | ✅ 完全一致 | 保留 |
| DeviceBindingDeletedFeedback | 设备档案已删除 | 裝置檔案已刪除 | 裝置檔案已刪除 | Device profile deleted | デバイスプロファイルを削除しました | ✅ 完全一致 | 保留 |
| DeviceBindingEmptyHint | 使用数据线连接并解锁 iPhone，轻点“信任”。也可以先启动 AirPlay，在手机上选择屏幕镜像后添加设备。 | 使用傳輸線連接並解鎖 iPhone，點一下「信任」。也可以先啟動 AirPlay，在手機上選擇螢幕鏡像輸出後新增裝置。 | 使用傳輸線連接並解鎖 iPhone，點一下「信任」。也可以先啟動 AirPlay，在手機上選擇螢幕鏡像輸出後新增裝置。 | Connect and unlock your iPhone, then tap Trust. Or start AirPlay, select Screen Mirroring on your phone, and add the device. | iPhoneを接続してロックを解除し、「信頼」をタップしてください。または、AirPlayを開始して、iPhoneの画面ミラーリングを選択し、デバイスを追加してください。 | ✅ 完全一致 | 保留 |
| DeviceBindingEmptyList | 还没有设备档案 | 尚無裝置檔案 | 尚無裝置檔案 | No devices yet | デバイスはまだありません | ✅ 完全一致 | 保留 |
| DeviceBindingEmptyTitle | 连接你的第一台 iPhone | 連接你的第一台 iPhone | 連接你的第一台 iPhone | Connect your first iPhone | 最初のiPhoneを接続 | ✅ 完全一致 | 保留 |
| DeviceBindingIdentityAlreadyBound | 该设备身份已经绑定到设备档案。 | 此裝置身份已綁定到裝置檔案。 | 此裝置身分已綁定到裝置設定檔。 | This device identity is already bound to a device profile. | このデバイスの識別情報は、すでにデバイスプロファイルに紐づけられています。 | ✅ 完全一致 | 保留 |
| DeviceBindingIdentityBoundElsewhere | 该设备身份已绑定到另一台设备档案。 | 此裝置身份已綁定到另一個裝置檔案。 | 此裝置身分已綁定到另一個裝置設定檔。 | This device identity is already bound to another device profile. | このデバイスの識別情報は、すでに別のデバイスプロファイルに紐づけられています。 | ✅ 完全一致 | 保留 |
| DeviceBindingIdentityRequired | 设备身份不能为空。 | 裝置身份不可為空。 | 裝置身分不可為空。 | A device identity is required. | デバイスの識別情報が必要です。 | ✅ 完全一致 | 保留 |
| DeviceBindingIncompatibleModel | 检测到的设备型号不一致，无法绑定。 | 偵測到的裝置型號不一致，無法綁定。 | 偵測到的裝置型號不一致，無法綁定。 | The detected device model does not match; it cannot be bound. | 検出したデバイスの機種が一致しないため、紐づけできません。 | ✅ 完全一致 | 保留 |
| DeviceBindingModelUnknown | 暂无型号信息 | 暫無型號資料 | 暫無型號資料 | Model information unavailable | 機種情報を取得できません | ⚠️ 需要优化 → ✅ 已修复 | 未知信息不应暗示正在读取 |
| DeviceBindingNext | 下一步 | 下一步 | 下一步 | Next | 次へ | ✅ 完全一致 | 保留 |
| DeviceBindingOpenFailedFormat | 无法打开设备绑定器：{0} | 無法開啟裝置綁定器：{0} | 無法開啟裝置綁定：{0} | Could not open the device binder: {0} | デバイスの紐づけを開けませんでした: {0} | ✅ 完全一致 | 保留 |
| DeviceBindingOperationFailed | 设备操作未完成。请重试；如果问题持续，请查看诊断日志。 | 裝置操作未完成。請重試；如果問題持續，請查看診斷記錄。 | 裝置操作未完成。請重試；如果問題持續，請查看診斷記錄。 | The device operation could not be completed. Try again, and check the diagnostic log if the problem persists. | デバイス操作を完了できませんでした。再試行し、問題が続く場合は診断ログを確認してください。 | ✅ 完全一致 | 保留 |
| DeviceBindingProfileDescription | 管理此设备档案的 USB、AirPlay 和蓝牙绑定。 | 管理此裝置檔案的 USB、AirPlay 和藍牙綁定。 | 管理此裝置設定檔的 USB、AirPlay 和藍牙綁定。 | Manage the USB, AirPlay, and Bluetooth bindings for this device profile. | このデバイスプロファイルのUSB、AirPlay、Bluetoothの紐づけを管理します。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| DeviceBindingProfileNotFound | 设备档案不存在。 | 找不到裝置檔案。 | 找不到裝置設定檔。 | The device profile was not found. | デバイスプロファイルが見つかりませんでした。 | ✅ 完全一致 | 保留 |
| DeviceBindingProfiles | 我的设备档案 | 我的裝置檔案 | 我的裝置設定檔 | My device profiles | マイデバイスのプロファイル | ✅ 完全一致 | 保留 |
| DeviceBindingRefreshFailed | 无法刷新设备档案。请重试；如果问题持续，请查看诊断日志。 | 無法重新整理裝置檔案。請重試；如果問題持續，請查看診斷記錄。 | 無法重新整理裝置設定檔。請重試；如果問題持續，請查看診斷記錄。 | Device profiles could not be refreshed. Try again, and check the diagnostic log if the problem persists. | デバイスプロファイルを更新できませんでした。再試行し、問題が続く場合は診断ログを確認してください。 | ✅ 完全一致 | 保留 |
| DeviceBindingRenameProfile | 重命名档案 | 重新命名裝置檔案 | 重新命名裝置設定檔 | Rename profile | プロファイル名を変更 | ✅ 完全一致 | 保留 |
| DeviceBindingRenamePrompt | 输入设备档案名称 | 輸入裝置檔案名稱 | 輸入裝置設定檔名稱 | Enter a device profile name | デバイスプロファイルの名前を入力してください | ✅ 完全一致 | 保留 |
| DeviceBindingRenameTitle | 重命名设备档案 | 重新命名裝置檔案 | 重新命名裝置設定檔 | Rename device profile | デバイスプロファイル名の変更 | ❌ 含义不一致 → ✅ 已修复 | 修改的是应用内档案名，不是实体设备名称 |
| DeviceBindingSaveFailed | 无法保存设备绑定，请重试。 | 無法儲存裝置綁定，請重試。 | 無法儲存裝置綁定，請重試。 | Device bindings could not be saved. Please try again. | デバイスの紐づけを保存できませんでした。もう一度お試しください。 | ✅ 完全一致 | 保留 |
| DeviceBindingSavedFeedback | 绑定已保存 | 綁定已儲存 | 綁定已儲存 | Binding saved | 紐づけを保存しました | ✅ 完全一致 | 保留 |
| DeviceBindingSelectProfile | 选择设备档案 | 選擇裝置檔案 | 選擇裝置設定檔 | Select a device profile | デバイスのプロファイルを選択 | ✅ 完全一致 | 保留 |
| DeviceBindingSidebarHint | USB 连接后会自动创建设备档案。无线设备可通过右上方的 + 添加。 | USB 連線後會自動建立裝置檔案。無線裝置可透過右上方的 + 新增。 | USB 連線後會自動建立裝置檔案。無線裝置可透過右上方的 + 新增。 | USB devices get a profile automatically. Use + to add an AirPlay device. | USBデバイスには自動でプロファイルが作られます。AirPlayデバイスは「+」で追加します。 | ✅ 完全一致 | 保留 |
| DeviceBindingStartAirPlay | 启动 AirPlay 接收 | 啟動 AirPlay 接收 | 啟動 AirPlay 接收 | Start AirPlay receiver | AirPlayレシーバーを開始 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DeviceBindingSubtitle | 在同一设备档案中关联 USB、AirPlay 和蓝牙连接。 | 在同一裝置檔案中關聯 USB、AirPlay 和藍牙連線。 | 在同一裝置設定檔中關聯 USB、AirPlay 和藍牙連線。 | Link USB, AirPlay, and Bluetooth connections in one device profile. | USB、AirPlay、Bluetoothの接続を1つのデバイスプロファイルにまとめます。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性；静态未发现引用，保留待后续调用核对 |
| DeviceBindingTitle | 设备绑定器 | 裝置綁定器 | 裝置綁定 | Device binder | デバイスの紐づけ | ✅ 完全一致 | 保留 |
| DeviceBindingUnbind | 解绑 | 解除綁定 | 解除綁定 | Unbind | 紐づけを解除 | ✅ 完全一致 | 保留 |
| DeviceBindingUnboundFeedback | 绑定已解除 | 綁定已解除 | 綁定已解除 | Binding removed | 紐づけを解除しました | ✅ 完全一致 | 保留 |
| DeviceBindingUnknownNeedsConfirmation | 无法自动验证设备型号，需要用户确认。 | 無法自動驗證裝置型號，需要用戶確認。 | 無法自動驗證裝置型號，需要使用者確認。 | The device model could not be verified automatically; user confirmation is required. | デバイスの機種を自動で確認できませんでした。ユーザーの確認が必要です。 | ✅ 完全一致 | 保留 |
| DeviceBindingUnnamedDevice | 未命名设备 | 未命名裝置 | 未命名裝置 | Unnamed device | 名前のないデバイス | ✅ 完全一致 | 保留 |
| DeviceBindingUsbOrAirPlayRequired | 请先为该档案绑定 USB 或 AirPlay 设备。 | 請先為此檔案綁定 USB 或 AirPlay 裝置。 | 請先為此設定檔綁定 USB 或 AirPlay 裝置。 | Bind a USB or AirPlay device to this profile first. | 先にこのプロファイルにUSBまたはAirPlayのデバイスを紐づけてください。 | ✅ 完全一致 | 保留 |
| DeviceBindingWired | 有线 USB | 有線 USB | 有線 USB | Wired USB | 有線USB | ✅ 完全一致 | 保留 |
| DeviceBindingWiredBrief | 使用数据线连接并解锁 iPhone，在手机上轻点“信任”。 | 使用傳輸線連接並解鎖 iPhone，在手機上點一下「信任」。 | 使用傳輸線連接並解鎖 iPhone，在手機上點一下「信任」。 | Connect and unlock your iPhone, then tap Trust on the phone. | iPhoneを接続してロックを解除し、iPhoneで「信頼」をタップしてください。 | ✅ 完全一致 | 保留 |
| DeviceBindingWiredDescription | 使用数据线连接 iPhone/iPad，解锁设备并在提示时选择“信任”。已连接的 USB 设备会自动建立档案；如需为当前档案更换有线身份，可在下方选择后绑定。 | 使用數據線連接 iPhone/iPad，解鎖裝置並在提示時選擇「信任」。已連接的 USB 裝置會自動建立檔案；如需為目前檔案更換有線身份，可在下方選擇後綁定。 | 使用傳輸線連接 iPhone/iPad，解鎖裝置並在提示時選擇「信任」。已連線的 USB 裝置會自動建立設定檔；如需更換目前設定檔綁定的有線裝置，可在下方選取後綁定。 | Connect the iPhone/iPad with a cable, unlock it, and choose “Trust” when prompted. Connected USB devices create profiles automatically; select a device below to bind a different wired identity to this profile. | iPhone/iPadをケーブルで接続してロックを解除し、確認が表示されたら「信頼」を選びます。接続したUSBデバイスのプロファイルは自動で作成されます。このプロファイルに別の有線デバイスを紐づけるには、下の一覧からデバイスを選んでください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DeviceBindingWorkspaceHint | 一台设备，一个档案。让每种连接方式都对应到正确的 iPhone。 | 一台裝置，一個檔案。讓每種連線方式都對應到正確的 iPhone。 | 一台裝置，一個檔案。讓每種連線方式都對應到正確的 iPhone。 | One profile for each iPhone. Keep every connection linked to the right device. | iPhoneごとに1つのプロファイル。すべての接続を、正しいデバイスに結びつけておきます。 | ✅ 完全一致 | 保留 |
| DeviceCaptureErrorTitleFormat | {0} 投屏错误 | {0} 螢幕鏡像錯誤 | {0} 螢幕鏡像錯誤 | Mirroring error — {0} | ミラーリングエラー — {0} | ✅ 完全一致 | 保留 |
| DeviceCountFormat | {0} 个来源 | {0} 個來源裝置 | {0} 個來源裝置 | Sources: {0} | ソース: {0} | ⚠️ 需要优化 → ✅ 已修复 | 使用数量标签，适用于单数与复数 |
| DeviceProfileGuidanceWiredBody | 检测到一台新的有线 iPhone/iPad。为了让有线投屏、无线投屏和反向控制始终对应到同一台真实设备，请现在建立设备档案。<br><br>请保持设备解锁并完成“信任此电脑”。点击“继续”将打开设备绑定器，在其中确认或管理此设备档案；点击“取消”也可以稍后从“反向控制”菜单打开。 | 偵測到新的有線 iPhone/iPad。為了讓有線螢幕鏡像、無線螢幕鏡像和反向控制始終對應同一台真實裝置，請現在建立裝置檔案。<br><br>請保持裝置解鎖並完成「信任此電腦」。點選「繼續」會開啟裝置綁定器，確認或管理此裝置檔案；點選「取消」亦可稍後從「反向控制」選單開啟。 | 偵測到新的有線 iPhone/iPad。為了讓有線螢幕鏡像、無線螢幕鏡像和反向控制始終對應同一台真實裝置，請現在建立裝置設定檔。<br><br>請保持裝置解鎖並完成「信任此電腦」。點選「繼續」會開啟裝置綁定，確認或管理此裝置設定檔；點選「取消」亦可稍後從「反向控制」選單開啟。 | A new wired iPhone/iPad was detected. Create a device profile now so wired mirroring, wireless mirroring, and reverse control always resolve to the same physical device.<br><br>Keep the device unlocked and complete the “Trust This Computer” prompt. Click Continue to open the device binder and confirm or manage this profile; click Cancel to open it later from the Reverse control menu. | 新しい有線のiPhone/iPadを検出しました。有線ミラーリング、無線ミラーリング、リモート操作がいつも同じ実機を指すよう、いまデバイスプロファイルを作成してください。<br><br>デバイスのロックを解除したまま、「このコンピュータを信頼」の確認を完了してください。「続行」をクリックするとデバイスの紐づけが開き、このプロファイルを確認・管理できます。「キャンセル」をクリックした場合は、あとからリモート操作メニューで開けます。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeviceProfileGuidanceWiredTitle | 首次连接此有线设备 | 首次連接此有線裝置 | 首次連線此有線裝置 | First connection for this wired device | この有線デバイスの初回接続 | ✅ 完全一致 | 保留 |
| DeviceProfileGuidanceWirelessBody | 检测到一台新的 AirPlay 无线设备。为了让无线投屏能够匹配对应的有线设备并启用反向控制，请现在建立设备档案。<br><br>请确保手机和电脑处于同一局域网，并保持设备名称可识别。点击“继续”将打开设备绑定器，在其中选择并绑定此 AirPlay 设备；点击“取消”也可以稍后从“反向控制”菜单打开。 | 偵測到新的 AirPlay 無線裝置。為了讓無線螢幕鏡像能夠配對對應的有線裝置並啟用反向控制，請現在建立裝置檔案。<br><br>請確保手機和電腦處於同一區域網絡，並保持裝置名稱可識別。點選「繼續」會開啟裝置綁定器，選擇並綁定此 AirPlay 裝置；點選「取消」亦可稍後從「反向控制」選單開啟。 | 偵測到新的 AirPlay 無線裝置。為了讓無線螢幕鏡像能夠配對對應的有線裝置並啟用反向控制，請現在建立裝置設定檔。<br><br>請確保手機和電腦處於同一區域網路，並保持裝置名稱可識別。點選「繼續」會開啟裝置綁定，選擇並綁定此 AirPlay 裝置；點選「取消」亦可稍後從「反向控制」選單開啟。 | A new AirPlay device was detected. Create a device profile now so wireless mirroring can match its wired identity and reverse control can target the correct device.<br><br>Make sure the phone and computer are on the same local network and keep the device name recognizable. Click Continue to open the device binder and bind this AirPlay device; click Cancel to open it later from the Reverse control menu. | 新しいAirPlayデバイスを検出しました。無線ミラーリングを有線の識別情報と対応づけ、リモート操作を正しいデバイスに向けられるよう、いまデバイスプロファイルを作成してください。<br><br>iPhoneとコンピュータが同じローカルネットワークにあることを確認し、デバイス名は分かりやすいままにしておいてください。「続行」をクリックするとデバイスの紐づけが開き、このAirPlayデバイスを紐づけられます。「キャンセル」をクリックした場合は、あとからリモート操作メニューで開けます。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DeviceProfileGuidanceWirelessTitle | 首次连接此无线设备 | 首次連接此無線裝置 | 首次連線此無線裝置 | First connection for this wireless device | この無線デバイスの初回接続 | ✅ 完全一致 | 保留 |
| DeviceRefreshFailedFormat | 设备刷新失败：{0} | 裝置重新整理失敗：{0} | 裝置重新整理失敗：{0} | Could not refresh devices: {0} | デバイスを更新できませんでした: {0} | ❌ 缺失 → ✅ 已修复 | 补齐面向用户的日志摘要；原始诊断详情保留 |
| DeviceSessionClosedWarningBody | 检测到您已经在控制中心点击了停止镜像，下一次该设备有线镜像需重启 iPhone/iPad | 偵測到您已在控制中心點擊停止螢幕鏡像，下次使用此裝置進行有線螢幕鏡像前需重新啟動 iPhone/iPad | 偵測到您已在控制中心按一下停止螢幕鏡像，下次使用此裝置進行有線螢幕鏡像前需重新啟動 iPhone/iPad | You stopped mirroring from Control Center. Restart the iPhone or iPad before using wired mirroring with this device again. | コントロールセンターからミラーリングを停止しました。このデバイスで有線ミラーリングをもう一度使うには、先にiPhoneまたはiPadを再起動してください。 | ✅ 完全一致 | 保留 |
| DeviceSessionClosedWarningTitleFormat | {0} 投屏已停止 | {0} 螢幕鏡像已停止 | {0} 螢幕鏡像已停止 | Mirroring stopped — {0} | ミラーリングを停止しました — {0} | ✅ 完全一致 | 保留 |
| DevicesTitle | 投屏来源 | 螢幕鏡像來源 | 螢幕鏡像來源 | Sources | ソース | ✅ 完全一致 | 保留 |
| DiagnosticsCleanedFormat | 清理完成：删除 {0} 个文件，释放 {1}；{2} 个正在使用或无权限的文件已跳过。 | 清理完成：刪除 {0} 個檔案，釋放 {1}；{2} 個正在使用或無權限的檔案已跳過。 | 清理完成：刪除 {0} 個檔案，釋放 {1}；{2} 個正在使用或無權限的檔案已跳過。 | Cleanup complete. Files removed: {0}; space freed: {1}; in-use or inaccessible files skipped: {2}. | 削除が完了しました。削除したファイル: {0}、解放した容量: {1}、使用中やアクセスできずスキップしたファイル: {2}。 | ⚠️ 需要优化 → ✅ 已修复 | 用数量标签兼容 0、1 和多个文件 |
| DiagnosticsCleanupFailedFormat | 清理失败：{0} | 清理失敗：{0} | 清理失敗：{0} | Cleanup failed: {0} | 削除できませんでした: {0} | ✅ 完全一致 | 保留 |
| DiagnosticsDescription | 应用错误、投屏核心和更新流程会写入本地日志，便于排查其他电脑上的问题。 | 應用程式錯誤、螢幕鏡像核心和更新流程會寫入本機記錄，方便排解其他電腦上的問題。 | 應用程式錯誤、螢幕鏡像核心和更新流程會寫入本機記錄檔，方便排解其他電腦上的問題。 | Application errors, capture-core events, and update workflows are written to local logs for troubleshooting failures on other PCs. | アプリのエラー、キャプチャコアのイベント、アップデートの処理はローカルのログに書き込まれ、他のPCで起きた問題の調査に使えます。 | ✅ 完全一致 | 保留 |
| DiagnosticsLocation | 日志位置 | 記錄位置 | 記錄檔位置 | Log location | ログの場所 | ✅ 完全一致 | 保留 |
| DiagnosticsRetentionSummary | 日志自动限制为单文件 8–16 MB，并清理超过 14 天或总量超过 64 MB 的旧文件。 | 每個記錄檔會自動限制為 8–16 MB，並清理超過 14 天或總大小超過 64 MB 的舊檔案。 | 每個記錄檔會自動限制為 8–16 MB，並清理超過 14 天或總大小超過 64 MB 的舊檔案。 | Logs are capped at 8–16 MB per file; files older than 14 days or beyond a 64 MB total are cleaned automatically. | ログは1ファイルあたり8〜16MBまでです。14日より古いファイルや、合計64MBを超える分は自動で削除されます。 | ✅ 完全一致 | 保留 |
| DiagnosticsTitle | 诊断 | 診斷 | 診斷 | Diagnostics | 診断 | ✅ 完全一致 | 保留 |
| DisableAdvancedMode | 关闭高级模式 | 關閉進階模式 | 關閉進階模式 | Disable advanced mode | 詳細モードを無効にする | ✅ 完全一致 | 保留 |
| DiscardRecording | 丢弃录制 | 丟棄錄製 | 丟棄錄製 | Discard recording | 録画を破棄 | ✅ 完全一致 | 保留 |
| DiscardRecordingConfirmation | 确定要删除这段尚未保存的录制吗？此操作不可撤销。 | 確定要刪除此段尚未儲存的錄製嗎？此操作無法復原。 | 確定要刪除此段尚未儲存的錄製嗎？此操作無法復原。 | Delete this unsaved recording? This cannot be undone. | この未保存の録画を削除しますか？ この操作は元に戻せません。 | ✅ 完全一致 | 保留 |
| DisplayBoundsUnavailable | 无法获取当前显示器的显示区域。 | 無法取得目前顯示器的顯示範圍。 | 無法取得目前顯示器的顯示範圍。 | Could not determine the current display bounds. | 現在のディスプレイの範囲を取得できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DownloadProgressFormat | 正在下载 {0:F0}% | 正在下載 {0:F0}% | 正在下載 {0:F0}% | Downloading {0:F0}% | ダウンロード中 {0:F0}% | ✅ 完全一致 | 保留 |
| DownloadingUpdate | 正在下载更新 | 正在下載更新 | 正在下載更新 | Downloading update | アップデートをダウンロード中 | ✅ 完全一致 | 保留 |
| DriverAppleReadyFormat | Apple 通道就绪 / libusb {0} | Apple 通道就緒 / libusb {0} | Apple 通道就緒 / libusb {0} | Apple channel ready / libusb {0} | Appleチャンネルの準備完了 / libusb {0} | ✅ 完全一致 | 保留 |
| DriverCaptureReady | USB 采集就绪 | USB 擷取就緒 | USB 擷取就緒 | USB capture ready | USBキャプチャの準備完了 | ✅ 完全一致 | 保留 |
| DriverDeviceFilterMissing | 当前设备需要外部采集驱动 | 目前裝置需要外部擷取驅動程式 | 目前裝置需要外部擷取驅動程式 | This device needs the external capture driver | このデバイスには外部のキャプチャドライバーが必要です | ✅ 完全一致 | 保留 |
| DriverDeviceFilterProvisionalFormat | 过滤驱动已登记 / libusb0 {0}；开始投屏时将核验当前设备 | 過濾驅動程式已註冊 / libusb0 {0}；開始螢幕鏡像時將驗證目前裝置 | 篩選驅動程式已註冊 / libusb0 {0}；開始螢幕鏡像時將驗證目前裝置 | Filter registered / libusb0 {0}; capture will verify this device | フィルター登録済み / libusb0 {0}。キャプチャ時にこのデバイスを確認します | ✅ 完全一致 | 保留 |
| DriverDeviceFilterReadyFormat | 当前设备已就绪 / libusb0 {0} | 目前裝置已就緒 / libusb0 {0} | 目前裝置已就緒 / libusb0 {0} | This device is ready / libusb0 {0} | このデバイスは準備完了 / libusb0 {0} | ✅ 完全一致 | 保留 |
| DriverExternalRequired | 请先安装或修复外部采集驱动，然后重新连接这台 Apple 设备。 | 請先安裝或修復外部擷取驅動程式，然後重新連接這部 Apple 裝置。 | 請先安裝或修復外部擷取驅動程式，然後重新連線這台 Apple 裝置。 | Install or repair the external capture driver, then reconnect this Apple device. | 外部のキャプチャドライバーをインストールまたは修復してから、このAppleデバイスをつなぎ直してください。 | ✅ 完全一致 | 保留 |
| DriverFilterStateError | 无法确认 Apple 设备采集驱动状态。 | 無法確認 Apple 裝置擷取驅動程式狀態。 | 無法確認 Apple 裝置擷取驅動程式狀態。 | The Apple device capture-driver state could not be verified. | Appleデバイスのキャプチャドライバーの状態を確認できませんでした。 | ✅ 完全一致 | 保留 |
| DriverInvalidAppleStack | Apple USB 父设备驱动不兼容。 | Apple USB 父裝置驅動程式不相容。 | Apple USB 父裝置驅動程式不相容。 | The Apple USB parent driver is not compatible. | AppleのUSB親ドライバーに互換性がありません。 | ✅ 完全一致 | 保留 |
| DriverLibUsbReadyFormat | libusb {0} / UsbDk 就绪 | libusb {0} / UsbDk 就緒 | libusb {0} / UsbDk 就緒 | libusb {0} / UsbDk ready | libusb {0} / UsbDkの準備完了 | ✅ 完全一致 | 保留 |
| DriverManagerActivated | 已切换到正在运行的驱动管理器。 | 已切換至正在執行的驅動程式管理員。 | 已切換至正在執行的驅動程式管理員。 | Switched to the running driver manager. | 実行中のドライバー管理に切り替えました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DriverManagerButton | 驱动管理器 | 驅動程式管理員 | 驅動程式管理員 | Driver manager | ドライバー管理 | ✅ 完全一致 | 保留 |
| DriverManagerExecutableMissing | 找不到驱动管理器。请重新安装完整的 iPhoneMirror 安装包。 | 找不到驅動程式管理員。請重新安裝完整的 iPhoneMirror 安裝套件。 | 找不到驅動程式管理員。請重新安裝完整的 iPhoneMirror 安裝套件。 | The driver manager could not be found. Reinstall the full iPhoneMirror package. | ドライバー管理が見つかりません。iPhoneMirrorのパッケージ一式を再インストールしてください。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DriverManagerLaunchFailedFormat | 无法打开驱动管理器：{0} | 無法開啟驅動程式管理員：{0} | 無法開啟驅動程式管理員：{0} | Could not open the driver manager: {0} | ドライバー管理を開けませんでした: {0} | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DriverManagerOpened | 已打开驱动管理器 | 已開啟驅動程式管理員 | 已開啟驅動程式管理員 | Driver manager opened | ドライバー管理を開きました | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DriverManagerOpenedAutomatically | 检测到有线设备驱动异常，已自动打开驱动管理器 | 偵測到有線裝置驅動程式異常，已自動開啟驅動程式管理員 | 偵測到有線裝置驅動程式異常，已自動開啟驅動程式管理員 | A wired-device driver problem was detected; the driver manager was opened | 有線デバイスのドライバーに問題が見つかったため、ドライバー管理を開きました | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| DriverManagerPathInvalid | 驱动管理器路径必须指向可执行文件（.exe）。 | 驅動程式管理員路徑必須指向可執行檔案（.exe）。 | 驅動程式管理員路徑必須指向可執行檔案（.exe）。 | The driver manager path must point to an executable (.exe). | ドライバー管理のパスは実行ファイル（.exe）を指す必要があります。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DriverManagerProcessStartFailed | Windows 未能启动驱动管理器。 | Windows 未能啟動驅動程式管理員。 | Windows 未能啟動驅動程式管理員。 | Windows could not start the driver manager. | Windowsがドライバー管理を起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DriverManagerStarted | 驱动管理器已启动。 | 驅動程式管理員已啟動。 | 驅動程式管理員已啟動。 | The driver manager has started. | ドライバー管理を起動しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DriverManagerTitle | 驱动管理器 | 驅動程式管理員 | 驅動程式管理員 | Driver manager | ドライバー管理 | ✅ 完全一致 | 保留 |
| DriverManagerToolTip | 打开驱动安装、修复与卸载工具 | 開啟驅動程式安裝、修復與解除安裝工具 | 開啟驅動程式安裝、修復與解除安裝工具 | Open the driver installation, repair, and removal tool | ドライバーのインストール・修復・削除ツールを開きます | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DriverNeedsApple | 需要 Apple USB 通道 | 需要 Apple USB 通道 | 需要 Apple USB 通道 | Apple USB channel required | AppleのUSBチャンネルが必要です | ✅ 完全一致 | 保留 |
| DriverPreflightFormat | 驱动预检结果：{0} | 驅動程式預先檢查結果：{0} | 驅動程式預先檢查結果：{0} | Driver preflight result: {0} | ドライバーの事前確認の結果: {0} | ❌ 缺失 → ✅ 已修复 | 补齐面向用户的日志摘要；原始诊断详情保留 |
| DriverReconnectPhone | 请解锁并重新连接这台 Apple 设备，然后刷新设备。 | 請解鎖並重新連接這部 Apple 裝置，然後重新整理裝置。 | 請解鎖並重新連線這台 Apple 裝置，然後重新整理裝置。 | Unlock and reconnect this Apple device, then refresh devices. | このAppleデバイスのロックを解除してつなぎ直し、デバイスを更新してください。 | ✅ 完全一致 | 保留 |
| DriverReplugRequired | 请重新连接这台 Apple 设备，以便外部采集驱动接管。 | 請重新連接這部 Apple 裝置，以便外部擷取驅動程式接管。 | 請重新連線這台 Apple 裝置，以便外部擷取驅動程式接管。 | Reconnect this Apple device so the external capture driver can attach. | 外部のキャプチャドライバーを適用するため、このAppleデバイスをつなぎ直してください。 | ✅ 完全一致 | 保留 |
| DriverSafetyWarningFormat | 驱动安全警告：{0} | 驅動程式安全警告：{0} | 驅動程式安全警告：{0} | Driver safety warning: {0} | ドライバーの安全性に関する警告: {0} | ❌ 缺失 → ✅ 已修复 | 补齐面向用户的日志摘要；原始诊断详情保留 |
| DriverUnsafeAppleStack | 驱动叠加：已启用保守 USB 模式 | 驅動程式疊加：已啟用保守 USB 模式 | 驅動程式疊加：已啟用保守 USB 模式 | Driver stack detected; conservative USB mode enabled | ドライバースタックを検出したため、保守的なUSBモードを有効にしました | ✅ 完全一致 | 保留 |
| EndToEndLabel | 端到端 | 端對端 | 端對端 | End to end | エンドツーエンド | ✅ 完全一致 | 保留 |
| EnumerateDevicesFailed | 枚举设备失败 | 列舉裝置失敗 | 列舉裝置失敗 | Could not enumerate devices | デバイスを列挙できませんでした | ✅ 完全一致 | 保留 |
| EnvironmentNeedsApple | 需要启动 Apple 设备服务并连接 iPhone 或 iPad。 | 需要啟動 Apple 裝置服務並連接 iPhone 或 iPad。 | 需要啟動 Apple 裝置服務並連線 iPhone 或 iPad。 | Start Apple device services and connect an iPhone or iPad. | Appleデバイスのサービスを起動し、iPhoneまたはiPadを接続してください。 | ✅ 完全一致 | 保留 |
| EnvironmentReadyApple | Apple 设备通道已就绪，正在检查采集后端。 | Apple 裝置通道已就緒，正在檢查擷取後端。 | Apple 裝置通道已就緒，正在檢查擷取後端。 | The Apple device channel is ready; checking the capture backend. | Appleデバイスのチャンネルの準備ができました。キャプチャバックエンドを確認しています。 | ✅ 完全一致 | 保留 |
| EnvironmentReadyCapture | Apple 配对通道与 USB 采集后端已就绪。 | Apple 配對通道與 USB 擷取後端已就緒。 | Apple 配對通道與 USB 擷取後端已就緒。 | Apple pairing and direct USB capture are ready. | Appleのペアリングと、USBの直接キャプチャの準備ができています。 | ✅ 完全一致 | 保留 |
| EnvironmentReadyUsbDk | Apple 配对通道与 UsbDk 后端已就绪。 | Apple 配對通道與 UsbDk 後端已就緒。 | Apple 配對通道與 UsbDk 後端已就緒。 | Apple pairing and the UsbDk backend are ready. | Appleのペアリングと、UsbDkバックエンドの準備ができています。 | ✅ 完全一致 | 保留 |
| ErrorTechnicalDetails | 技术详情 | 技術詳情 | 技術詳情 | Technical details | 技術的な詳細 | ✅ 完全一致 | 保留 |
| FfmpegAudioInputTimeout | FFmpeg 未能在 5 秒内连接投屏音频输入。 | FFmpeg 未能在 5 秒內連接螢幕鏡像音訊輸入。 | FFmpeg 未能在 5 秒內連線螢幕鏡像音訊輸入。 | FFmpeg did not connect to the mirroring audio input within 5 seconds. | FFmpegが5秒以内にミラーリングの音声入力へ接続しませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegAudioStartFailed | 无法启动 FFmpeg 音频解码器。 | 無法啟動 FFmpeg 音訊解碼器。 | 無法啟動 FFmpeg 音訊解碼器。 | The FFmpeg audio decoder could not start. | FFmpegの音声デコーダーを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegEncoderSizeUnsupported | 已安装的 FFmpeg H.264 编码器均无法编码所选尺寸。 | 已安裝的 FFmpeg H.264 編碼器均無法編碼所選尺寸。 | 已安裝的 FFmpeg H.264 編碼器均無法編碼所選尺寸。 | No installed FFmpeg H.264 encoder supports the selected dimensions. | インストール済みのFFmpegのH.264エンコーダーは、選択したサイズに対応していません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegEncoderUnavailable | 没有可用的兼容 FFmpeg H.264 编码器。 | 沒有可用的相容 FFmpeg H.264 編碼器。 | 沒有可用的相容 FFmpeg H.264 編碼器。 | A compatible FFmpeg H.264 encoder is unavailable. | 互換性のあるFFmpegのH.264エンコーダーがありません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegExitedFormat | FFmpeg 已退出，代码为 {0}。 | FFmpeg 已結束，代碼為 {0}。 | FFmpeg 已結束，代碼為 {0}。 | FFmpeg exited with code {0}. | FFmpegがコード{0}で終了しました。 | ❌ 缺失 → ✅ 已修复 | 输出错误详情迁入三语资源 |
| FfmpegNoUsableEncoderFormat | {0} / 没有可用的 H.264 编码器 | {0} / 沒有可用的 H.264 編碼器 | {0} / 沒有可用的 H.264 編碼器 | {0} / no usable H.264 encoder | {0} / 使えるH.264エンコーダーなし | ❌ 缺失 → ✅ 已修复 | 用户可见错误详情补齐三语 |
| FfmpegNotFound | 未找到 FFmpeg。请安装 FFmpeg 8，或将其放入应用目录。 | 找不到 FFmpeg。請安裝 FFmpeg 8，或將其放入應用程式資料夾。 | 找不到 FFmpeg。請安裝 FFmpeg 8，或將其放入應用程式資料夾。 | FFmpeg was not found. Install FFmpeg 8 or place it in the application directory. | FFmpegが見つかりません。FFmpeg 8をインストールするか、アプリのフォルダーに置いてください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegProbeFailed | FFmpeg 输出能力检测失败。 | FFmpeg 輸出能力偵測失敗。 | FFmpeg 輸出能力偵測失敗。 | FFmpeg capability probing failed. | FFmpegの機能を調べられませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegProtocolUnavailable | FFmpeg 不支持所选输出协议。 | FFmpeg 不支援所選輸出協議。 | FFmpeg 不支援所選輸出協定。 | The selected FFmpeg output protocol is unavailable. | 選択したFFmpegの出力プロトコルは利用できません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegStartFailed | 无法启动 FFmpeg。 | 無法啟動 FFmpeg。 | 無法啟動 FFmpeg。 | FFmpeg could not be started. | FFmpegを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| FfmpegStartupExitedFormat | FFmpeg 在启动时退出，代码为 {0}。 | FFmpeg 在啟動時結束，代碼為 {0}。 | FFmpeg 在啟動時結束，代碼為 {0}。 | FFmpeg exited during startup with code {0}. | FFmpegが起動中にコード{0}で終了しました。 | ❌ 缺失 → ✅ 已修复 | 输出错误详情迁入三语资源 |
| FooterConnectivity | 本机 USB / AirPlay，无云端中转 | 本機 USB / AirPlay，無需雲端中轉 | 本機 USB / AirPlay，無需雲端中轉 | Local USB / AirPlay; no cloud relay | ローカルのUSB / AirPlay。クラウド経由はありません | ✅ 完全一致 | 保留 |
| FrameRateLabel | 帧率 | 幀率 | 影格率 | Frame rate | フレームレート | ✅ 完全一致 | 保留 |
| FullScreenFailedFormat | 切换全屏失败：{0} | 切換全螢幕失敗：{0} | 切換全螢幕失敗：{0} | Could not toggle full screen: {0} | 全画面を切り替えられませんでした: {0} | ✅ 完全一致 | 保留 |
| FullScreenPreview | 全屏预览 | 全螢幕預覽 | 全螢幕預覽 | Full-screen preview | 全画面プレビュー | ✅ 完全一致 | 保留 |
| GammaLabel | 伽马 | 伽馬 | 伽馬 | Gamma | ガンマ | ✅ 完全一致 | 保留 |
| GeneralOperationFailed | 操作未能完成。请重试；如果问题持续，请查看诊断日志。 | 操作未能完成。請重試；如果問題持續，請查看診斷記錄。 | 操作未能完成。請重試；如果問題持續，請查看診斷記錄檔。 | The operation could not be completed. Retry, and check the diagnostic log if the problem persists. | 操作を完了できませんでした。再試行してください。解消しない場合は、診断ログを確認してください。 | ✅ 完全一致 | 保留 |
| HeightLabel | 高度 | 高度 | 高度 | Height | 高さ | ✅ 完全一致 | 保留 |
| HlsRestartFailed | HLS 播放桥接组件重启失败。 | HLS 播放橋接元件重新啟動失敗。 | HLS 播放橋接元件重新啟動失敗。 | The HLS playback bridge could not restart. | HLS再生ブリッジを再起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| ImageAdjustmentsApplied | 画面调节已应用。 | 畫面調節已套用。 | 畫面調節已套用。 | Image adjustments applied. | 映像の調整を適用しました。 | ✅ 完全一致 | 保留 |
| ImageAdjustmentsBusy | 另一项投屏设置正在应用，请等待完成后重试。 | 另一項螢幕鏡像設定正在套用，請等待完成後重試。 | 另一項螢幕鏡像設定正在套用，請等待完成後重試。 | Another mirroring setting is being applied. Try again when it finishes. | 別のミラーリング設定を適用中です。完了してからもう一度お試しください。 | ❌ 术语不一致 → ✅ 已修复 | 投屏统一为 mirroring，视频应用投放仍使用 casting |
| ImageAdjustmentsPreviewOnlyNotice | 仅对本地预览生效，无法应用到推流、虚拟摄像头、录屏或截图画面。 | 僅對本機預覽生效，無法套用到串流、虛擬攝影機、畫面錄製或螢幕擷取畫面。 | 僅對本機預覽生效，無法套用到串流、虛擬攝影機、畫面錄製或螢幕截圖。 | Affects the local preview only. It cannot be applied to streams, the virtual camera, recordings, or screenshots. | ローカルのプレビューにだけ反映されます。配信、仮想カメラ、録画、スクリーンショットには適用できません。 | ✅ 完全一致 | 保留 |
| ImageAdjustmentsSaved | 画面调节已保存，将在下次投屏时应用。 | 畫面調節已儲存，將在下次螢幕鏡像時套用。 | 畫面調節已儲存，將在下次螢幕鏡像時套用。 | Image adjustments saved for the next cast. | 映像の調整を、次回のキャスト用に保存しました。 | ✅ 完全一致 | 保留 |
| ImageAdjustmentsUpdateFailed | 无法应用画面调节。 | 無法套用畫面調節。 | 無法套用畫面調節。 | Could not apply image adjustments. | 映像の調整を適用できませんでした。 | ✅ 完全一致 | 保留 |
| ImageAndSound | 画面与声音 | 畫面與音訊 | 畫面與音訊 | Video and audio | 映像と音声 | ✅ 完全一致 | 保留 |
| IndependentPreviewOpened | 已在独立窗口打开 | 已在獨立視窗開啟 | 已在獨立視窗開啟 | Opened in independent window | 独立ウィンドウで開きました | ✅ 完全一致 | 保留 |
| IndependentWindowAudioMenu | 声音 | 音訊 | 音訊 | Audio | 音声 | ✅ 完全一致 | 保留 |
| IndependentWindowBluetoothControl | 蓝牙控制 | 藍牙控制 | 藍牙控制 | Bluetooth control | Bluetooth操作 | ✅ 完全一致 | 保留 |
| IndependentWindowClose | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 保留 |
| IndependentWindowDisplayMenu | 画面 | 畫面 | 畫面 | Image | 映像 | ✅ 完全一致 | 保留 |
| IndependentWindowEnterFullScreen | 进入全屏 | 進入全螢幕 | 進入全螢幕 | Enter full screen | 全画面にする | ✅ 完全一致 | 保留 |
| IndependentWindowExitFullScreen | 退出全屏 | 離開全螢幕 | 離開全螢幕 | Exit full screen | 全画面を終了 | ✅ 完全一致 | 保留 |
| IndependentWindowFix | 固定窗口 | 固定視窗 | 固定視窗 | Lock window | ウィンドウを固定 | ✅ 完全一致 | 保留 |
| IndependentWindowImageSettings | 调节画面 | 調節畫面 | 調節畫面 | Adjust image | 映像を調整 | ✅ 完全一致 | 保留 |
| IndependentWindowKeepCorners | 保留圆角 | 保留圓角 | 保留圓角 | Keep rounded corners | 角丸を有効にする | ✅ 完全一致 | 保留 |
| IndependentWindowMute | 静音 | 靜音 | 靜音 | Mute | ミュート | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| IndependentWindowMuteOthers | 静音其他窗口 | 靜音其他視窗 | 靜音其他視窗 | Mute other windows | 他のウィンドウをミュート | ✅ 完全一致 | 保留 |
| IndependentWindowMuteThis | 静音该窗口 | 靜音該視窗 | 靜音該視窗 | Mute this window | このウィンドウをミュート | ✅ 完全一致 | 保留 |
| IndependentWindowOpacity | 窗口透明度 | 視窗透明度 | 視窗透明度 | Window opacity | ウィンドウの不透明度 | ✅ 完全一致 | 保留 |
| IndependentWindowOpacityFailed | 暂时无法调整透明度，请重新打开独立窗口后重试。 | 暫時無法調整透明度，請重新開啟獨立視窗後再試。 | 暫時無法調整透明度，請重新開啟獨立視窗後再試。 | Opacity could not be changed. Reopen the independent window and try again. | 不透明度を変更できませんでした。独立ウィンドウを開き直して、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| IndependentWindowOpacityHelp | 数值越低越透明，100% 为完全不透明。 | 數值越低越透明，100% 為完全不透明。 | 數值越低越透明，100% 為完全不透明。 | Lower values are more transparent. 100% is fully opaque. | 値が小さいほど透明になります。100%で完全に不透明です。 | ✅ 完全一致 | 保留 |
| IndependentWindowOpacityReset | 恢复不透明 | 恢復不透明 | 恢復不透明 | Restore opacity | 不透明度を元に戻す | ✅ 完全一致 | 保留 |
| IndependentWindowOpaqueOnHover | 鼠标悬停时不透明 | 滑鼠停留時不透明 | 滑鼠停留時不透明 | Opaque on hover | ポインターを重ねると不透明に | ✅ 完全一致 | 保留 |
| IndependentWindowOpaqueOnHoverHelp | 鼠标移入独立窗口时完全不透明，移开后恢复上方设置的透明度。 | 滑鼠移入獨立視窗時完全不透明，移開後恢復上方設定的透明度。 | 滑鼠移入獨立視窗時完全不透明，移開後恢復上方設定的透明度。 | The window becomes fully opaque while the pointer is over it, then returns to the opacity set above. | ポインターがウィンドウに重なっている間は完全に不透明になり、離れると上で設定した不透明度に戻ります。 | ✅ 完全一致 | 保留 |
| IndependentWindowOtherWindowsMuted | 其他窗口已静音 | 其他視窗已靜音 | 其他視窗已靜音 | Other windows muted | 他のウィンドウをミュート中 | ✅ 完全一致 | 保留 |
| IndependentWindowPin | 置顶 | 置頂 | 最上層顯示 | Always on top | 常に手前に表示 | ✅ 完全一致 | 保留 |
| IndependentWindowProjectionSettings | 投屏设置 | 螢幕鏡像設定 | 螢幕鏡像設定 | Mirroring settings | ミラーリング設定 | ✅ 完全一致 | 保留 |
| IndependentWindowRemoveCorners | 去除圆角 | 去除圓角 | 去除圓角 | Remove rounded corners | 角丸を無効にする | ✅ 完全一致 | 保留 |
| IndependentWindowReverseControl | 反向控制 | 反向控制 | 反向控制 | Reverse control | リモート操作 | ✅ 完全一致 | 保留 |
| IndependentWindowRotateLeft | 向左旋转 | 向左旋轉 | 向左旋轉 | Rotate left | 左に回転 | ✅ 完全一致 | 保留 |
| IndependentWindowRotateRight | 向右旋转 | 向右旋轉 | 向右旋轉 | Rotate right | 右に回転 | ✅ 完全一致 | 保留 |
| IndependentWindowStyle | 样式 | 樣式 | 樣式 | Style | スタイル | ✅ 完全一致 | 保留 |
| IndependentWindowStyleSubtitle | 实时调整，仅应用于当前独立窗口。 | 即時調整，只套用至目前獨立視窗。 | 即時調整，只套用至目前獨立視窗。 | Changes apply immediately to this window only. | 変更はこのウィンドウにだけ、すぐに反映されます。 | ✅ 完全一致 | 保留 |
| IndependentWindowStyleTitle | 独立窗口样式 | 獨立視窗樣式 | 獨立視窗樣式 | Independent window style | 独立ウィンドウのスタイル | ✅ 完全一致 | 保留 |
| IndependentWindowUnfix | 取消固定 | 取消固定 | 取消固定 | Unlock window | ウィンドウの固定を解除 | ✅ 完全一致 | 保留 |
| IndependentWindowUnmuteThis | 取消静音该窗口 | 取消靜音該視窗 | 取消靜音該視窗 | Unmute this window | このウィンドウのミュートを解除 | ✅ 完全一致 | 保留 |
| IndependentWindowUnpin | 取消置顶 | 取消置頂 | 取消最上層顯示 | Disable always on top | 常に手前に表示を解除 | ✅ 完全一致 | 保留 |
| IndependentWindowWindowMenu | 窗口 | 視窗 | 視窗 | Window | ウィンドウ | ✅ 完全一致 | 保留 |
| IndependentWindowWiredProjection | 有线控制 | 有線控制 | 有線控制 | Wired control | 有線操作 | ❌ 含义不一致 → ✅ 已修复 | 菜单和快捷键实际调用控制功能，不是开始投屏 |
| IndependentWindowWirelessProjection | 无线控制 | 無線控制 | 無線控制 | Wireless control | 無線操作 | ❌ 含义不一致 → ✅ 已修复 | 菜单和快捷键实际调用控制功能，不是开始投屏 |
| InstallVirtualCamera | 安装虚拟摄像头组件 | 安裝虛擬攝影機元件 | 安裝虛擬攝影機元件 | Install virtual camera component | 仮想カメラのコンポーネントをインストール | ✅ 完全一致 | 保留 |
| InstanceConflictBody | 检测到另一个 iPhoneMirror 程序正在运行。请选择要保留的窗口。 | 偵測到另一個 iPhoneMirror 程式正在執行。請選擇要保留的視窗。 | 偵測到另一個 iPhoneMirror 程式正在執行。請選擇要保留的視窗。 | Another iPhoneMirror instance is currently running. Choose which window to keep. | 別のiPhoneMirrorが起動中です。残すウィンドウを選んでください。 | ✅ 完全一致 | 保留 |
| InstanceConflictHint | 关闭其他窗口后，当前窗口会继续启动；关闭当前窗口不会影响已经运行的投屏。 | 關閉其他視窗後，目前視窗會繼續啟動；關閉目前視窗不會影響進行中的螢幕鏡像。 | 關閉其他視窗後，目前視窗會繼續啟動；關閉目前視窗不會影響進行中的螢幕鏡像。 | Closing the other windows continues this launch. Closing this window leaves active mirroring sessions untouched. | ほかのウィンドウを閉じると、今回の起動を続行します。このウィンドウを閉じても、実行中のミラーリングセッションには影響しません。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| InstanceConflictTitle | iPhoneMirror 已在运行 | iPhoneMirror 正在執行 | iPhoneMirror 正在執行 | iPhoneMirror is already running | iPhoneMirrorはすでに起動しています | ✅ 完全一致 | 保留 |
| KeepUnlocked | 连接后请保持 Apple 设备解锁 | 連接後請保持 Apple 裝置解鎖 | 連線後請保持 Apple 裝置解鎖 | Keep the Apple device unlocked after connecting | 接続したあとも、デバイスのロックを解除したままにしてください | ✅ 完全一致 | 保留 |
| KeyboardInputModeDirect | 直连键盘输入已启用，键盘映射暂不可用。 | 直接鍵盤輸入已啟用，鍵盤映射暫時無法使用。 | 直接鍵盤輸入已啟用，鍵盤映射暫時無法使用。 | Direct keyboard input to Apple is active; keyboard mapping is unavailable. | Appleへのキーボード直接入力が有効です。キー割り当ては利用できません。 | ✅ 完全一致 | 保留 |
| KeyboardInputModeMapping | 键盘映射已启用；不会将键盘按键直连转发到 Apple 设备。 | 鍵盤映射已啟用；不會將鍵盤按鍵直接轉送至 Apple 裝置。 | 鍵盤映射已啟用；不會將鍵盤按鍵直接轉送至 Apple 裝置。 | Keyboard mapping is active; direct keyboard forwarding to Apple is disabled. | キー割り当てが有効です。Appleへのキーボード直接転送は無効です。 | ✅ 完全一致 | 保留 |
| KeyboardInputModeNone | 键盘输入未启用 | 鍵盤輸入未啟用 | 鍵盤輸入未啟用 | Keyboard input is inactive | キーボード入力は無効です | ✅ 完全一致 | 保留 |
| LanguageChinese | 简体中文 | 簡體中文 | 簡體中文 | 简体中文 | 简体中文 | ✅ 完全一致 | 保留 |
| LanguageEnglish | English | English | English | English | English | ✅ 完全一致 | 保留 |
| LanguageJapanese | 日本語 | 日本語 | 日本語 | 日本語 | 日本語 | ✅ 完全一致 | 保留 |
| LanguageSystem | 跟随系统 | 跟隨系統 | 跟隨系統 | System default | システムの設定に従う | ✅ 完全一致 | 保留 |
| LanguageToolTip | 界面语言 | 介面語言 | 介面語言 | Interface language | 表示言語 | ✅ 完全一致 | 保留 |
| LanguageTraditionalChineseHongKong | 繁體中文（香港） | 繁體中文（香港） | 繁體中文（香港） | Traditional Chinese (Hong Kong) | 繁体字中国語（香港） | ✅ 完全一致 | 保留 |
| LanguageTraditionalChineseTaiwan | 繁體中文（台灣） | 繁體中文（台灣） | 繁體中文（台灣） | Traditional Chinese (Taiwan) | 繁体字中国語（台湾） | ✅ 完全一致 | 保留 |
| LatencyLabel | 延迟 | 延遲 | 延遲 | Latency | 遅延 | ✅ 完全一致 | 保留 |
| LatestVersionLabel | 最新版本 | 最新版本 | 最新版本 | Latest version | 最新バージョン | ✅ 完全一致 | 保留 |
| LicenseInformation | 许可证信息 | 許可證資料 | 授權資訊 | License information | ライセンス情報 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| LiveLogHeader | 实时日志  ·  Ctrl+L | 即時記錄  ·  Ctrl+L | 即時記錄檔  ·  Ctrl+L | Live log  ·  Ctrl+L | ライブログ  ·  Ctrl+L | ✅ 完全一致 | 保留 |
| LocalTargetMissing | 找不到要打开的本地文件或文件夹。 | 找不到要開啟的本機檔案或資料夾。 | 找不到要開啟的本機檔案或資料夾。 | The local file or folder could not be found. | ローカルのファイルまたはフォルダーが見つかりませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| LogViewCleared | 日志视图已清空（不会删除磁盘日志） | 記錄檢視已清除（不會刪除磁碟上的記錄檔） | 記錄檢視已清除（不會刪除磁碟上的記錄檔） | Log view cleared (the log file was not deleted) | ログの表示をクリアしました（ログファイルは削除していません） | ✅ 完全一致 | 保留 |
| MappingAction | 触控操作 | 觸控操作 | 觸控操作 | Touch action | タッチ操作 | ✅ 完全一致 | 保留 |
| MappingActionDoubleTap | 双击 | 連按兩下 | 點兩下 | Double tap | ダブルタップ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionHoldUntilRelease | 按住直到松开 | 按住直到放開 | 按住直到放開 | Hold until key release | キーを離すまで押し続ける | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionLongPress | 长按 | 長按 | 長按 | Long press | 長押し | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionSwipe | 滑动 | 滑動 | 滑動 | Swipe | スワイプ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionSwipeDown | 下滑 | 向下滑動 | 向下滑動 | Swipe down | 下にスワイプ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionSwipeLeft | 左滑 | 向左滑動 | 向左滑動 | Swipe left | 左にスワイプ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionSwipeRight | 右滑 | 向右滑動 | 向右滑動 | Swipe right | 右にスワイプ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionSwipeUp | 上滑 | 向上滑動 | 向上滑動 | Swipe up | 上にスワイプ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingActionTap | 点击 | 點按 | 點一下 | Tap | タップ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingAdd | 添加映射 | 新增映射 | 新增映射 | Add mapping | 割り当てを追加 | ✅ 完全一致 | 保留 |
| MappingAutoSave | 列表更改自动保存；编辑中的映射需点击「保存」。 | 清單變更會自動儲存；編輯中的映射需按「儲存」。 | 清單變更會自動儲存；編輯中的映射需按「儲存」。 | List changes save automatically. Use Save to finish editing a mapping. | 一覧の変更は自動で保存されます。割り当ての編集を終えるときは「保存」を使ってください。 | ✅ 完全一致 | 保留 |
| MappingBluetoothUnsupported | 当前蓝牙模式仅支持相对鼠标，无法可靠执行指定坐标。请切换到 USB 或无线触控反控后使用键盘映射。 | 目前藍牙模式僅支援相對滑鼠，無法可靠執行指定座標。請切換至 USB 或無線觸控反控後使用鍵盤映射。 | 目前藍牙模式僅支援相對滑鼠，無法可靠執行指定座標。請切換至 USB 或無線觸控反向控制後使用鍵盤映射。 | The current Bluetooth mode provides only a relative mouse, not reliable coordinate touch. Use USB or wireless touch control for keyboard mappings. | 現在のBluetoothモードは相対マウスのみで、正確な座標のタッチには対応していません。キー割り当てには、USBまたは無線のタッチ操作を使ってください。 | ✅ 完全一致 | 保留 |
| MappingCapture | 录入按键 | 錄入按鍵 | 擷取按鍵 | Record key | キーを記録 | ✅ 完全一致 | 保留 |
| MappingCaptureHelp | 录入一个物理按键并松开。Ctrl / Shift / Alt / Win 单独松开时触发；组合键不触发单键映射。Win 单键映射会阻止开始菜单；系统安全快捷键仍由 Windows 处理。 | 錄入一個實體按鍵並放開。Ctrl / Shift / Alt / Win 單獨放開時觸發；組合鍵不觸發單鍵映射。Win 單鍵映射會阻止開始功能表；系統安全快捷鍵仍由 Windows 處理。 | 擷取一個實體按鍵並放開。Ctrl / Shift / Alt / Win 單獨放開時觸發；組合鍵不觸發單鍵映射。Win 單鍵映射會阻止開始功能表；系統安全快速鍵仍由 Windows 處理。 | Press and release one physical key. Ctrl / Shift / Alt / Win trigger on standalone release; chords do not trigger a single-key mapping. A mapped Win key suppresses Start. Windows retains control of secure system shortcuts. | 物理キーを1つ押して離してください。Ctrl / Shift / Alt / Winは、単独で離したときに動作します。キーの組み合わせでは、単一キーの割り当ては動作しません。割り当てたWinキーは、スタートメニューを開かなくなります。セキュリティ保護されたシステムのショートカットは、Windowsが引き続き制御します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingCaptureHint | 请按下要绑定的键盘按键 | 請按下要綁定的鍵盤按鍵 | 請按下要綁定的鍵盤按鍵 | Press the keyboard key to bind | 割り当てるキーボードのキーを押してください | ✅ 完全一致 | 保留 |
| MappingConnecting | 等待反向控制会话建立或切换完成… | 等候反向控制工作階段建立或切換完成… | 等候反向控制工作階段建立或切換完成… | Waiting for the control session to connect or finish switching… | 操作セッションの接続または切り替えの完了を待っています… | ✅ 完全一致 | 保留 |
| MappingControlNotReady | 触控反控尚未就绪或已断开。请为当前设备启用 USB 或无线反控。 | 觸控反控尚未就緒或已中斷。請為目前裝置啟用 USB 或無線反控。 | 觸控反向控制尚未就緒或已中斷。請為目前裝置啟用 USB 或無線反向控制。 | Touch control is not ready or has disconnected. Enable USB or wireless control for the selected device. | タッチ操作の準備ができていないか、切断されました。選択したデバイスのUSB操作または無線操作を有効にしてください。 | ✅ 完全一致 | 保留 |
| MappingCoordinateHelp | 在当前投屏画面点击或拖动选择位置，无需填写 X/Y。滑动方向表示手指移动方向。 | 在目前投屏畫面點擊或拖曳選擇位置，毋須填寫 X/Y。滑動方向代表手指移動方向。 | 在目前螢幕鏡像畫面點選或拖曳選擇位置，無需填寫 X/Y。滑動方向代表手指移動方向。 | Click or drag directly on the current mirror to choose a position. No X/Y entry is needed. Swipe directions describe finger movement. | 現在のミラーリング画面を直接クリックまたはドラッグして、位置を選べます。XとYを入力する必要はありません。スワイプの方向は、指の動きを表します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingDamagedConfig | 部分映射配置无效，已关闭键盘映射。请检查保留的映射后重新启用。 | 部分映射設定無效，已關閉鍵盤映射。請檢查保留的映射後重新啟用。 | 部分映射設定無效，已關閉鍵盤映射。請檢查保留的映射後重新啟用。 | Some mappings were invalid. Mapping is off; review the retained mappings before enabling it again. | 正しくない割り当てがありました。割り当てはオフになっています。再び有効にする前に、残っている割り当てを確認してください。 | ✅ 完全一致 | 保留 |
| MappingDelete | 删除 | 刪除 | 刪除 | Delete | 削除 | ✅ 完全一致 | 保留 |
| MappingDeleteConfirm | 删除按键「{0}」的映射？ | 刪除按鍵「{0}」的映射？ | 刪除按鍵「{0}」的映射？ | Delete the mapping for {0}? | {0}の割り当てを削除しますか? | ✅ 完全一致 | 保留 |
| MappingDescription | 将 Windows 键盘按键绑定到 iPhone/iPad 的触控操作。 | 將 Windows 鍵盤按鍵綁定至 iPhone/iPad 的觸控操作。 | 將 Windows 鍵盤按鍵綁定至 iPhone/iPad 的觸控操作。 | Bind Windows keyboard keys to iPhone/iPad touch actions. | Windowsのキーボードのキーを、iPhone/iPadのタッチ操作に割り当てます。 | ✅ 完全一致 | 保留 |
| MappingDirectKeyboardActive | 直连键盘输入已启用。请先停止直连键盘输入，再打开或启用键盘映射。 | 直接鍵盤輸入已啟用。請先停止直接鍵盤輸入，再開啟或啟用鍵盤映射。 | 直接鍵盤輸入已啟用。請先停止直接鍵盤輸入，再開啟或啟用鍵盤映射。 | Direct keyboard input is active. Stop it before opening or enabling keyboard mapping. | キーボードの直接入力が有効です。キー割り当てを開く前、または有効にする前に、直接入力を停止してください。 | ✅ 完全一致 | 保留 |
| MappingDistance | 滑动距离（所在轴的 %） | 滑動距離（所在軸的 %） | 滑動距離（所在軸的 %） | Distance (% of the movement axis) | 距離（移動する軸に対する%） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingDoubleSummary | X: {0:0.##}%, Y: {1:0.##}% · 间隔 {2} 毫秒 | X: {0:0.##}%, Y: {1:0.##}% · 間隔 {2} 毫秒 | X: {0:0.##}%, Y: {1:0.##}% · 間隔 {2} 毫秒 | X: {0:0.##}%, Y: {1:0.##}% · {2} ms interval | X: {0:0.##}%、Y: {1:0.##}% · 間隔{2}ms | ✅ 完全一致 | 保留 |
| MappingDuplicate | 此按键已经存在映射。请选择替换、取消或编辑原映射。 | 此按鍵已有映射。請選擇取代、取消或編輯原映射。 | 此按鍵已有映射。請選擇取代、取消或編輯原映射。 | This key already has a mapping. Replace it, cancel, or edit the original. | このキーにはすでに割り当てがあります。置き換えるか、キャンセルするか、元の割り当てを編集してください。 | ✅ 完全一致 | 保留 |
| MappingDuration | 持续时间（毫秒，50–10000） | 持續時間（毫秒，50–10000） | 持續時間（毫秒，50–10000） | Duration (ms, 50–10000) | 時間（ms、50～10000） | ✅ 完全一致 | 保留 |
| MappingEdit | 编辑 | 編輯 | 編輯 | Edit | 編集 | ✅ 完全一致 | 保留 |
| MappingEditOriginal | 编辑原映射 | 編輯原映射 | 編輯原映射 | Edit original | 元の割り当てを編集 | ✅ 完全一致 | 保留 |
| MappingEditorTitle | 编辑键盘映射 | 編輯鍵盤映射 | 編輯鍵盤映射 | Edit keyboard mapping | キー割り当てを編集 | ✅ 完全一致 | 保留 |
| MappingEmpty | 尚无映射。点击「添加映射」，选择按键和触控操作。 | 尚無映射。按「新增映射」，選擇按鍵及觸控操作。 | 尚無映射。按「新增映射」，選擇按鍵及觸控操作。 | No mappings yet. Add a mapping to choose a key and touch action. | 割り当てはまだありません。割り当てを追加して、キーとタッチ操作を選んでください。 | ✅ 完全一致 | 保留 |
| MappingEnable | 启用键盘映射 | 啟用鍵盤映射 | 啟用鍵盤映射 | Enable keyboard mapping | キー割り当てを有効にする | ✅ 完全一致 | 保留 |
| MappingEnabled | 已启用 | 已啟用 | 已啟用 | Enabled | 有効 | ✅ 完全一致 | 保留 |
| MappingEndX | 终点 X（%） | 終點 X（%） | 終點 X（%） | End X (%) | 終了X（%） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingEndY | 终点 Y（%） | 終點 Y（%） | 終點 Y（%） | End Y (%) | 終了Y（%） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingGeometryUnavailable | 等待设备画面尺寸与方向。 | 等候裝置畫面尺寸及方向。 | 等候裝置畫面尺寸及方向。 | Waiting for the device's screen size and orientation. | デバイスの画面サイズと向きを待っています。 | ✅ 完全一致 | 保留 |
| MappingGlobalHelp | 启用后可在其他应用前台时生效；在设置、编辑和文字输入时暂停。每次按下执行一次，按住不连发。组合键保留原行为，修饰键不会被拦截。 | 啟用後可在其他應用程式處於前景時生效；在設定、編輯及文字輸入時暫停。每次按下執行一次，按住不連發。組合鍵保留原有行為，修飾鍵不會被攔截。 | 啟用後可在其他應用程式處於前景時生效；在設定、編輯及文字輸入時暫停。每次按下執行一次，按住不連發。組合鍵保留原有行為，修飾鍵不會被攔截。 | Works while other apps are foreground. Pauses in settings, editors and text fields. Holding a key does not repeat actions. Key combinations and modifier keys keep their Windows behavior. | ほかのアプリが前面にあるときも動作します。設定、エディター、テキスト欄では一時停止します。キーを押し続けても操作は繰り返されません。キーの組み合わせと修飾キーは、Windowsの動作のままです。 | ✅ 完全一致 | 保留 |
| MappingHoldSummary | X: {0:0.##}%, Y: {1:0.##}% · {2} 毫秒 | X: {0:0.##}%, Y: {1:0.##}% · {2} 毫秒 | X: {0:0.##}%, Y: {1:0.##}% · {2} 毫秒 | X: {0:0.##}%, Y: {1:0.##}% · {2} ms | X: {0:0.##}%、Y: {1:0.##}% · {2}ms | ✅ 完全一致 | 保留 |
| MappingHookFailed | 无法启动键盘监听。请关闭并重新启用键盘映射。 | 無法啟動鍵盤監聽。請關閉並重新啟用鍵盤映射。 | 無法啟動鍵盤監聽。請關閉並重新啟用鍵盤映射。 | Could not start keyboard capture. Turn mapping off and on again. | キーボードのキャプチャを開始できませんでした。割り当てをオフにして、もう一度オンにしてください。 | ✅ 完全一致 | 保留 |
| MappingInterval | 双击间隔（毫秒，40–1000） | 連按間隔（毫秒，40–1000） | 點兩下間隔（毫秒，40–1000） | Double-tap interval (ms, 40–1000) | ダブルタップの間隔（ms、40～1000） | ✅ 完全一致 | 保留 |
| MappingInvalidCoordinates | 坐标必须是 0–100 之间的数值。 | 座標必須是 0–100 之間的數值。 | 座標必須是 0–100 之間的數值。 | Coordinates must be numbers between 0 and 100. | 座標は0～100の数値にしてください。 | ✅ 完全一致 | 保留 |
| MappingInvalidDistance | 滑动距离必须大于 0 且不超过 100%。 | 滑動距離必須大於 0 且不超過 100%。 | 滑動距離必須大於 0 且不超過 100%。 | Swipe distance must be greater than 0 and no more than 100%. | スワイプの距離は0より大きく100%以下にしてください。 | ✅ 完全一致 | 保留 |
| MappingInvalidDuration | 持续时间必须是 50–10000 毫秒之间的整数。 | 持續時間必須是 50–10000 毫秒之間的整數。 | 持續時間必須是 50–10000 毫秒之間的整數。 | Duration must be a whole number from 50 to 10000 ms. | 時間は50～10000msの整数にしてください。 | ✅ 完全一致 | 保留 |
| MappingInvalidInterval | 双击间隔必须是 40–1000 毫秒之间的整数。 | 連按間隔必須是 40–1000 毫秒之間的整數。 | 點兩下間隔必須是 40–1000 毫秒之間的整數。 | Double-tap interval must be a whole number from 40 to 1000 ms. | ダブルタップの間隔は40～1000msの整数にしてください。 | ✅ 完全一致 | 保留 |
| MappingInvalidSwipe | 滑动终点必须位于画面内，且不能与起点相同。请调整起点、终点或距离。 | 滑動終點必須位於畫面內，且不能與起點相同。請調整起點、終點或距離。 | 滑動終點必須位於畫面內，且不能與起點相同。請調整起點、終點或距離。 | The swipe endpoint must be inside the screen and differ from its start. Adjust the points or distance. | スワイプの終点は画面内にあり、始点と異なる必要があります。位置または距離を調整してください。 | ✅ 完全一致 | 保留 |
| MappingKey | Windows 按键 | Windows 按鍵 | Windows 按鍵 | Windows key | Windowsのキー | ✅ 完全一致 | 保留 |
| MappingLimit | 最多支持 256 条映射。 | 最多支援 256 項映射。 | 最多支援 256 項映射。 | Up to 256 mappings are supported. | 割り当ては256件まで対応しています。 | ✅ 完全一致 | 保留 |
| MappingManage | 管理键盘映射 | 管理鍵盤映射 | 管理鍵盤映射 | Manage keyboard mappings | キー割り当てを管理 | ✅ 完全一致 | 保留 |
| MappingNoDevice | 等待设备：请选择并连接 iPhone/iPad。 | 等候裝置：請選取並連接 iPhone/iPad。 | 等候裝置：請選取並連線 iPhone/iPad。 | Waiting for a device: select and connect an iPhone/iPad. | デバイスを待っています。iPhone/iPadを選択して接続してください。 | ✅ 完全一致 | 保留 |
| MappingOff | 键盘映射已关闭 | 鍵盤映射已關閉 | 鍵盤映射已關閉 | Keyboard mapping is off | キー割り当てはオフです | ✅ 完全一致 | 保留 |
| MappingPaused | 键盘映射已暂停。点击当前投屏画面后恢复；编辑或文字输入期间不执行映射。 | 鍵盤映射已暫停。點擊目前投屏畫面後恢復；編輯或文字輸入期間不執行映射。 | 鍵盤映射已暫停。點選目前螢幕鏡像畫面後恢復；編輯或文字輸入期間不執行映射。 | Mapping is paused. Click the current mirror to resume; editing and text input pause execution. | 割り当ては一時停止中です。現在のミラーリング画面をクリックすると再開します。編集やテキスト入力の間は実行が一時停止します。 | ✅ 完全一致 | 保留 |
| MappingPick | 选择位置 | 選擇位置 | 選擇位置 | Choose position | 位置を選択 | ✅ 完全一致 | 保留 |
| MappingPickClick | 点击目标位置。Esc 取消。 | 點擊目標位置。Esc 取消。 | 點選目標位置。Esc 取消。 | Click the target. Esc cancels. | 対象をクリックしてください。Escでキャンセルします。 | ✅ 完全一致 | 保留 |
| MappingPickDrag | 按下并拖动到终点，松开完成。Esc 取消。 | 按下並拖曳到終點，放開完成。Esc 取消。 | 按下並拖曳到終點，放開完成。Esc 取消。 | Press, drag to the endpoint, then release. Esc cancels. | 押したまま終点までドラッグして離してください。Escでキャンセルします。 | ✅ 完全一致 | 保留 |
| MappingPickInside | 将鼠标移入视频内容区域 | 將滑鼠移入影片內容區域 | 將滑鼠移入影片內容區域 | Move the pointer into the video content | ポインターを映像の内側に移動してください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingPickNoPreview | 请先开始当前设备的投屏，再选择位置。 | 請先開始目前裝置的投屏，再選擇位置。 | 請先開始目前裝置的螢幕鏡像，再選擇位置。 | Start mirroring the current device before choosing a position. | 位置を選ぶ前に、現在のデバイスのミラーリングを開始してください。 | ✅ 完全一致 | 保留 |
| MappingPickRequired | 请在当前投屏画面选择位置。 | 請在目前投屏畫面選擇位置。 | 請在目前螢幕鏡像畫面選擇位置。 | Choose a position on the current mirror. | 現在のミラーリング画面で位置を選んでください。 | ✅ 完全一致 | 保留 |
| MappingPicking | 正在投屏画面取点 | 正在投屏畫面取點 | 正在螢幕鏡像畫面取點 | Choosing a position on the mirror | ミラーリング画面で位置を選択中 | ✅ 完全一致 | 保留 |
| MappingPointSummary | X: {0:0.##}%, Y: {1:0.##}% | X: {0:0.##}%, Y: {1:0.##}% | X: {0:0.##}%, Y: {1:0.##}% | X: {0:0.##}%, Y: {1:0.##}% | X: {0:0.##}%、Y: {1:0.##}% | ✅ 完全一致 | 保留 |
| MappingReady | 键盘映射已启用 · 目标为当前选中的设备 | 鍵盤映射已啟用 · 目標為目前選取的裝置 | 鍵盤映射已啟用 · 目標為目前選取的裝置 | Keyboard mapping is ready · targets the selected device | キー割り当ての準備ができました · 選択中のデバイスが対象です | ✅ 完全一致 | 保留 |
| MappingRepick | 重新取点 | 重新取點 | 重新取點 | Pick again | 選び直す | ✅ 完全一致 | 保留 |
| MappingReplace | 替换 | 取代 | 取代 | Replace | 置き換える | ✅ 完全一致 | 保留 |
| MappingSaveFailed | 保存键盘映射失败，更改未应用。请检查配置目录权限后重试。 | 儲存鍵盤映射失敗，變更未套用。請檢查設定目錄權限後重試。 | 儲存鍵盤映射失敗，變更未套用。請檢查設定目錄權限後重試。 | Could not save mappings. Changes were not applied. Check access to the settings folder and retry. | 割り当てを保存できませんでした。変更は適用されていません。設定フォルダーへのアクセスを確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| MappingSendFailed | 触控发送失败。请检查当前设备的反向控制连接。 | 觸控傳送失敗。請檢查目前裝置的反向控制連線。 | 觸控傳送失敗。請檢查目前裝置的反向控制連線。 | Touch input could not be sent. Check the selected device's control connection. | タッチ入力を送信できませんでした。選択したデバイスの操作接続を確認してください。 | ✅ 完全一致 | 保留 |
| MappingShortcutConflict | 此按键与 iPhoneMirror 快捷键冲突。请更换按键或先调整快捷键设置。F5、F11 保留给刷新和全屏。 | 此按鍵與 iPhoneMirror 快捷鍵衝突。請更換按鍵或先調整快捷鍵設定。F5、F11 保留予重新整理及全螢幕。 | 此按鍵與 iPhoneMirror 快速鍵衝突。請更換按鍵或先調整快速鍵設定。F5、F11 保留供重新整理及全螢幕。 | This key conflicts with an iPhoneMirror shortcut. Choose another key or change the shortcut first. F5 and F11 are reserved for refresh and full screen. | このキーはiPhoneMirrorのショートカットと重複しています。別のキーを選ぶか、先にショートカットを変更してください。F5とF11は、更新と全画面のために予約されています。 | ✅ 完全一致 | 保留 |
| MappingStateIdle | 第 1 步：录入 Windows 按键 | 第 1 步：錄入 Windows 按鍵 | 第 1 步：擷取 Windows 按鍵 | Step 1: capture a Windows key | 手順1: Windowsのキーを記録 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingStateKeyCaptured | 第 2 步：选择操作，然后选择位置 | 第 2 步：選擇操作，然後選擇位置 | 第 2 步：選擇操作，然後選擇位置 | Step 2: choose an action, then a position | 手順2: 操作を選び、次に位置を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingStateMappingReady | 按键和位置已确认，可以保存 | 按鍵和位置已確認，可以儲存 | 按鍵和位置已確認，可以儲存 | Key and position confirmed. Ready to save. | キーと位置が確定しました。保存できます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingStatePickingPosition | 正在当前投屏画面选择位置 | 正在目前投屏畫面選擇位置 | 正在目前螢幕鏡像畫面選擇位置 | Choosing a position on the current mirror | 現在のミラーリング画面で位置を選択中 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingStateWaitingForKey | 请按下一个按键并松开；再次点击可取消录入 | 請按下一個按鍵並放開；再次點擊可取消錄入 | 請按下一個按鍵並放開；再次點選可取消擷取 | Press and release a key; click again to cancel capture | キーを押して離してください。もう一度クリックすると記録をキャンセルします | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingSuppress | 阻止已映射普通按键的原始 Windows 行为 | 阻止已映射一般按鍵的原有 Windows 行為 | 阻止已映射一般按鍵的原有 Windows 行為 | Block the original Windows action of mapped ordinary keys | 割り当てた通常キーのWindows本来の動作を無効にする | ✅ 完全一致 | 保留 |
| MappingSwipeDirection | 滑动方向 | 滑動方向 | 滑動方向 | Swipe direction | スワイプの方向 | ✅ 完全一致 | 保留 |
| MappingSwipeDirectionFree | 任意方向 | 任意方向 | 任意方向 | Any direction | 自由な方向 | ✅ 完全一致 | 保留 |
| MappingSwipeSummary | ({0:0.##}%, {1:0.##}%) → ({2:0.##}%, {3:0.##}%) · {4} 毫秒 | ({0:0.##}%, {1:0.##}%) → ({2:0.##}%, {3:0.##}%) · {4} 毫秒 | ({0:0.##}%, {1:0.##}%) → ({2:0.##}%, {3:0.##}%) · {4} 毫秒 | ({0:0.##}%, {1:0.##}%) → ({2:0.##}%, {3:0.##}%) · {4} ms | （{0:0.##}%、{1:0.##}%）→（{2:0.##}%、{3:0.##}%）· {4}ms | ✅ 完全一致 | 保留 |
| MappingTargetStatus | 目标：{0} · {1} | 目標：{0} · {1} | 目標：{0} · {1} | Target: {0} · {1} | 対象: {0} · {1} | ✅ 完全一致 | 保留 |
| MappingTitle | 键盘映射 | 鍵盤映射 | 鍵盤映射 | Keyboard mapping | キー割り当て | ✅ 完全一致 | 保留 |
| MappingUnsupportedAction | 不支持此触控操作，请重新选择。 | 不支援此觸控操作，請重新選擇。 | 不支援此觸控操作，請重新選擇。 | Unsupported touch action. Choose another action. | 対応していないタッチ操作です。別の操作を選んでください。 | ✅ 完全一致 | 保留 |
| MappingUnsupportedDevice | 当前设备不支持触控反控。请选择 iPhone/iPad 投屏设备。 | 目前裝置不支援觸控反控。請選取 iPhone/iPad 投屏裝置。 | 目前裝置不支援觸控反向控制。請選取 iPhone/iPad 螢幕鏡像裝置。 | This device does not support touch control. Select an iPhone/iPad mirror. | このデバイスはタッチ操作に対応していません。iPhone/iPadのミラーリングを選択してください。 | ✅ 完全一致 | 保留 |
| MappingUnsupportedKey | 不支持此按键。请使用物理键盘录入其他按键。 | 不支援此按鍵。請使用實體鍵盤錄入其他按鍵。 | 不支援此按鍵。請使用實體鍵盤擷取其他按鍵。 | Unsupported key. Record another key using a physical keyboard. | 対応していないキーです。物理キーボードで別のキーを記録してください。 | ✅ 完全一致 | 保留 |
| MappingWaiting | 等待按键…（再次点击取消） | 等候按鍵…（再次按下以取消） | 等候按鍵…（再次按下以取消） | Waiting for a key… (click again to cancel) | キーを待っています…（もう一度クリックでキャンセル） | ✅ 完全一致 | 保留 |
| MappingWindowsKeyUnsupported | Win 键及 Windows 系统组合键不支持绑定，原始系统行为会保留。 | Win 鍵及 Windows 系統組合鍵不支援綁定，原有系統行為會保留。 | Win 鍵及 Windows 系統組合鍵不支援綁定，原有系統行為會保留。 | Windows keys and Windows system combinations cannot be bound. Their system behavior is preserved. | Windowsキーと、Windowsのシステムの組み合わせは割り当てられません。システムの動作はそのまま維持されます。 | ✅ 完全一致 | 保留 |
| MappingX | X / 起点 X（%） | X / 起點 X（%） | X / 起點 X（%） | X / start X (%) | X / 開始X（%） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| MappingY | Y / 起点 Y（%） | Y / 起點 Y（%） | Y / 起點 Y（%） | Y / start Y (%) | Y / 開始Y（%） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| Maximize | 最大化 | 最大化 | 最大化 | Maximize | 最大化 | ✅ 完全一致 | 保留 |
| MeasuringUpdateRoutes | 正在测试可达线路的下载速度… | 正在測試可達線路的下載速度… | 正在測試可達線路的下載速度… | Measuring reachable download routes… | 接続できるダウンロード経路を測定しています… | ✅ 完全一致 | 保留 |
| MediaCastAudioActive | 媒体音频 | 媒體音訊 | 媒體音訊 | media audio | メディアの音声 | ✅ 完全一致 | 保留 |
| MediaCastAudioMuted | 已静音 | 已靜音 | 已靜音 | muted | ミュート中 | ✅ 完全一致 | 保留 |
| MediaCastDescription | 接收视频 App 内“投屏”按钮发送的影片，不是控制中心的屏幕镜像。 | 接收影片 App 內「投放」按鈕發送的影片，不是控制中心的螢幕鏡像。 | 接收影片 App 內「投放」按鈕傳送的影片，不是控制中心的螢幕鏡像。 | Receives movies sent from a video app's Cast button. This is separate from Control Center Screen Mirroring. | 動画アプリのキャストボタンから送られた動画を受信します。コントロールセンターの「画面ミラーリング」とは別の機能です。 | ✅ 完全一致 | 保留 |
| MediaCastDeviceActive | 正在投放视频 | 正在投放影片 | 正在投放影片 | Video is being cast | 動画をキャスト中 | ✅ 完全一致 | 保留 |
| MediaCastDeviceConnection | 网络媒体投放 | 網絡媒體投放 | 網路媒體投放 | Network media cast | ネットワークメディアのキャスト | ✅ 完全一致 | 保留 |
| MediaCastDeviceModel | AirPlay / DLNA 视频 | AirPlay / DLNA 影片投放 | AirPlay / DLNA 影片投放 | AirPlay / DLNA video | AirPlay / DLNA動画 | ✅ 完全一致 | 保留 |
| MediaCastDeviceName | 视频应用投屏 | 影片 App 投放 | 影片 App 投放 | Video app casting | 動画アプリのキャスト | ❌ 含义不一致 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay |
| MediaCastFpsCapabilityFormat | 接收上限 {0} fps | 接收上限 {0} fps | 接收上限 {0} fps | Receiver limit {0} fps | レシーバーの上限 {0}fps | ✅ 完全一致 | 保留 |
| MediaCastFpsDisplayFormat | ≤ {0} fps | ≤ {0} fps | ≤ {0} fps | ≤ {0} fps | ≤ {0}fps | ✅ 完全一致 | 保留 |
| MediaCastHlsBackendUnavailable | HLS 播放组件不可用，请检查安装包是否包含 FFmpeg。 | HLS 播放元件不可用，請檢查安裝包是否包含 FFmpeg。 | HLS 播放元件不可用，請檢查安裝套件是否包含 FFmpeg。 | The HLS playback component is unavailable. Check that FFmpeg is included in the installation. | HLS再生コンポーネントが利用できません。インストールにFFmpegが含まれているか確認してください。 | ✅ 完全一致 | 保留 |
| MediaCastInvalidUrl | 收到的视频地址无效或不是 HTTP(S) 地址。 | 收到的影片網址無效或不是 HTTP(S) 網址。 | 收到的影片網址無效或不是 HTTP(S) 網址。 | The received video URL is invalid or is not an HTTP(S) URL. | 受信した動画のURLが無効か、HTTP(S)のURLではありません。 | ✅ 完全一致 | 保留 |
| MediaCastLive | 直播 | 直播 | 直播 | Live | ライブ | ✅ 完全一致 | 保留 |
| MediaCastLiveRecoveringFormat | 直播流暂时中断，正在重新连接：{0} | 直播串流暫時中斷，正在重新連接：{0} | 直播串流暫時中斷，正在重新連線：{0} | The live stream was interrupted and is reconnecting: {0} | ライブ配信が中断されたため、再接続しています: {0} | ✅ 完全一致 | 保留 |
| MediaCastLoadingVideo | 正在加载投放的视频… | 正在載入投放的影片… | 正在載入投放的影片… | Loading the cast video… | キャストされた動画を読み込んでいます… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| MediaCastMute | 静音 | 靜音 | 靜音 | Mute | ミュート | ✅ 完全一致 | 保留 |
| MediaCastNetworkStream | 网络流 | 網絡串流 | 網路串流 | network stream | ネットワークストリーム | ✅ 完全一致 | 保留 |
| MediaCastOriginalResolution | 媒体原始分辨率 | 媒體原始解像度 | 媒體原始解析度 | Original media resolution | メディア本来の解像度 | ✅ 完全一致 | 保留 |
| MediaCastPause | 暂停 | 暫停 | 暫停 | Pause | 一時停止 | ✅ 完全一致 | 保留 |
| MediaCastPlay | 播放 | 播放 | 播放 | Play | 再生 | ✅ 完全一致 | 保留 |
| MediaCastPlayReceived | 已收到视频应用投屏请求 | 已收到影片 App 投放請求 | 已收到影片 App 投放請求 | Received a video app casting request | 動画アプリのキャスト要求を受信しました | ❌ 含义不一致 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay |
| MediaCastPlaybackEnded | 视频播放完毕 | 影片播放完畢 | 影片播放完畢 | Video playback ended | 動画の再生が終了しました | ✅ 完全一致 | 保留 |
| MediaCastPlaybackFailedFormat | 视频投放播放失败：{0} | 影片投放播放失敗：{0} | 影片投放播放失敗：{0} | Video casting playback failed: {0} | 動画キャストを再生できませんでした: {0} | ✅ 完全一致 | 保留 |
| MediaCastReady | 视频投放接收端已就绪 | 影片投放接收端已就緒 | 影片投放接收端已就緒 | Video casting receiver ready | 動画キャストのレシーバーの準備完了 | ❌ 含义不一致 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay |
| MediaCastReceiverMissing | 缺少视频投放组件。请重新安装完整的 iPhoneMirror 安装包。 | 缺少影片投放元件。請重新安裝完整的 iPhoneMirror 安裝套件。 | 缺少影片投放元件。請重新安裝完整的 iPhoneMirror 安裝套件。 | The video casting component is missing. Reinstall the full iPhoneMirror package. | 動画キャストのコンポーネントが見つかりません。iPhoneMirrorの完全版パッケージをインストールし直してください。 | ⚠️ 需要优化 → ✅ 已修复 | 面向最终用户提供可执行的重新安装建议 |
| MediaCastRequiresOriginalBackend | 视频应用投屏仅支持“原始方案”无线接收端。 | 影片 App 投放僅支援「原始方案」無線接收端。 | 影片 App 投放僅支援「原始方案」無線接收端。 | Video app casting is available only with the Original wireless receiver implementation. | 動画アプリのキャストは、無線レシーバーの実装がオリジナルのときだけ使えます。 | ✅ 完全一致 | 保留 |
| MediaCastSeek | 播放进度 | 播放進度 | 播放進度 | Playback position | 再生位置 | ✅ 完全一致 | 保留 |
| MediaCastSeekBackward | 后退 10 秒 | 後退 10 秒 | 後退 10 秒 | Back 10 seconds | 10秒戻る | ✅ 完全一致 | 保留 |
| MediaCastSeekForward | 前进 10 秒 | 前進 10 秒 | 前進 10 秒 | Forward 10 seconds | 10秒進む | ✅ 完全一致 | 保留 |
| MediaCastSpeedUnsupportedBody | 当前投放的视频不支持 {0} 播放速度，已恢复为 1x。 | 目前投放的影片不支援 {0} 播放速度，已恢復為 1x。 | 目前投放的影片不支援 {0} 播放速度，已恢復為 1x。 | This cast stream does not support {0} playback. Playback was restored to 1x. | このキャストストリームは{0}の再生に対応していません。再生速度を1xに戻しました。 | ⚠️ 需要优化 → ✅ 已修复 | 参数已包含 x，避免显示 2x 倍速 |
| MediaCastSpeedUnsupportedTitle | 当前流不支持倍速 | 目前串流不支援倍速 | 目前串流不支援倍速 | Playback speed unavailable | 再生速度を変更できません | ✅ 完全一致 | 保留 |
| MediaCastStarting | 正在启动视频投放接收端… | 正在啟動影片投放接收端… | 正在啟動影片投放接收端… | Starting the video casting receiver… | 動画キャストのレシーバーを起動しています… | ❌ 含义不一致、⚠️ 需要优化 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay；统一进行中状态的省略号 |
| MediaCastStopRequestFailed | 接收端未接受停止投屏请求。 | 接收端未接受停止投放請求。 | 接收端未接受停止投放請求。 | The receiver did not accept the stop request. | レシーバーが停止の要求を受け付けませんでした。 | ✅ 完全一致 | 保留 |
| MediaCastStopRequestFailedFormat | 无法通知投屏发送端停止：{0} | 無法通知影片投放發送端停止：{0} | 無法通知影片投放傳送端停止：{0} | Could not notify the casting sender to stop: {0} | キャスト元に停止を通知できませんでした: {0} | ✅ 完全一致 | 保留 |
| MediaCastStopped | 视频应用投屏已停止 | 影片 App 投放已停止 | 影片 App 投放已停止 | Video app casting stopped | 動画アプリのキャストを停止しました | ❌ 含义不一致 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay |
| MediaCastSystemDecoder | 系统媒体解码 | 系統媒體解碼 | 系統媒體解碼 | system media decoder | システムのメディアデコーダー | ✅ 完全一致 | 保留 |
| MediaCastTitle | 视频应用投屏 | 影片 App 投放 | 影片 App 投放 | Video app casting | 動画アプリのキャスト | ❌ 含义不一致 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay |
| MediaCastUnmute | 取消静音 | 取消靜音 | 取消靜音 | Unmute | ミュートを解除 | ✅ 完全一致 | 保留 |
| MediaCastWaitingVideo | 等待视频 App 投放内容… | 等待影片 App 投放內容… | 等待影片 App 投放內容… | Waiting for a video app to cast content… | 動画アプリからのキャストを待っています… | ❌ 含义不一致、⚠️ 需要优化 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay；统一进行中状态的省略号 |
| MediaCastWindowTitle | iPhoneMirror 视频应用投屏 | iPhoneMirror 影片 App 投放 | iPhoneMirror 影片 App 投放 | iPhoneMirror Video App Casting | iPhoneMirror動画アプリのキャスト | ❌ 含义不一致 → ✅ 已修复 | 功能也支持 DLNA，不能仅标为 AirPlay |
| MediaOutputAlreadyRunning | 同一投屏可同时录制和直播。请先停止同类输出，切换投屏来源前请停止所有输出；虚拟摄像头需单独使用。 | 同一投屏可同時錄影及直播。請先停止同類輸出，切換來源前請停止所有輸出；虛擬鏡頭需獨立使用。 | 同一投影可同時錄影及直播。請先停止同類輸出，切換來源前請停止所有輸出；虛擬攝影機需單獨使用。 | One recording and one live stream can share the same source. Stop the output of the same kind, or stop all outputs before changing the source. Virtual camera output runs separately. | 同じソースを共有できるのは、録画1つとライブ配信1つです。同じ種類の出力を停止するか、ソースを変更する前にすべての出力を停止してください。仮想カメラの出力は別に動作します。 | ✅ 完全一致 | 保留 |
| MediaOutputAudioInvalid | 投屏音频数据的 PCM 布局无效。 | 螢幕鏡像音訊資料的 PCM 排列無效。 | 螢幕鏡像音訊資料的 PCM 排列無效。 | The mirroring audio packet has an invalid PCM layout. | ミラーリングの音声パケットのPCMレイアウトが正しくありません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputAudioStalled | 投屏音频序列未更新。 | 螢幕鏡像音訊序列未更新。 | 螢幕鏡像音訊序列未更新。 | The mirroring audio sequence did not advance. | ミラーリングの音声シーケンスが進んでいません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputAudioUnsupported | 投屏音频数据使用了不支持的 PCM 格式。 | 螢幕鏡像音訊資料使用了不支援的 PCM 格式。 | 螢幕鏡像音訊資料使用了不支援的 PCM 格式。 | The mirroring audio packet has an unsupported PCM format. | ミラーリングの音声パケットのPCM形式に対応していません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputButton | 录制与推流 | 錄製與串流 | 錄製與串流 | Recording and streaming | 録画と配信 | ✅ 完全一致 | 保留 |
| MediaOutputCapabilitiesFormat | 可用：{0}、{1}、{2}；编码器：{3}。 | 可用：{0}、{1}、{2}；編碼器：{3}。 | 可用：{0}、{1}、{2}；編碼器：{3}。 | Available: {0}, {1}, {2}; encoder: {3}. | 利用可能: {0}、{1}、{2}。エンコーダー: {3}。 | ✅ 完全一致 | 保留 |
| MediaOutputCapabilitiesUnknown | 尚未检测输出能力。 | 尚未偵測輸出能力。 | 尚未偵測輸出能力。 | Output capabilities have not been checked. | 出力機能をまだ確認していません。 | ✅ 完全一致 | 保留 |
| MediaOutputChecking | 正在检测 FFmpeg 输出能力… | 正在偵測 FFmpeg 輸出能力… | 正在偵測 FFmpeg 輸出能力… | Checking FFmpeg output capabilities… | FFmpegの出力機能を確認しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| MediaOutputDestinationRequired | 请指定输出位置或服务器地址。 | 請指定輸出位置或伺服器位址。 | 請指定輸出位置或伺服器位址。 | Specify an output location or server address. | 出力先またはサーバーのアドレスを指定してください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputFailedFormat | 媒体输出失败：{0} | 媒體輸出失敗：{0} | 媒體輸出失敗：{0} | Media output failed: {0} | メディア出力に失敗しました: {0} | ✅ 完全一致 | 保留 |
| MediaOutputFrameInvalid | 原生输出画面布局无效。 | 原生輸出畫面排列無效。 | 原生輸出畫面排列無效。 | The native output frame has an invalid layout. | ネイティブ出力フレームのレイアウトが正しくありません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputFrameStalled | 已连续 5 秒无法获取投屏画面。 | 已連續 5 秒無法取得螢幕鏡像畫面。 | 已連續 5 秒無法取得螢幕鏡像畫面。 | No mirroring frame has been available for 5 seconds. | 5秒間、ミラーリングのフレームを取得できていません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputFrameTimeout | 已连续 5 秒未收到投屏画面。 | 已連續 5 秒未收到螢幕鏡像畫面。 | 已連續 5 秒未收到螢幕鏡像畫面。 | No mirroring frame was received for 5 seconds. | 5秒間、ミラーリングのフレームを受信できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputIdle | 当前没有媒体输出任务。 | 目前沒有媒體輸出任務。 | 目前沒有媒體輸出任務。 | No media output is active. | 実行中のメディア出力はありません。 | ✅ 完全一致 | 保留 |
| MediaOutputInvalidDimensions | 输出宽高必须为偶数，宽度为 160–3840，高度为 160–2160。 | 輸出寬高必須為偶數，寬度為 160–3840，高度為 160–2160。 | 輸出寬高必須為偶數，寬度為 160–3840，高度為 160–2160。 | Output dimensions must be even: width 160–3840 and height 160–2160. | 出力サイズは偶数にしてください。幅は160～3840、高さは160～2160です。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputInvalidProtocol | 请选择受支持的推流协议。 | 請選擇受支援的串流協議。 | 請選擇受支援的串流協定。 | Select a supported streaming protocol. | 対応している配信プロトコルを選んでください。 | ✅ 完全一致 | 保留 |
| MediaOutputInvalidSettings | 请输入偶数输出尺寸、10-60 fps 帧率以及 500-50000 kbps 码率。 | 請輸入偶數輸出尺寸、10-60 fps 幀率以及 500-50000 kbps 位元率。 | 請輸入偶數輸出尺寸、10-60 fps 影格率以及 500-50000 kbps 位元率。 | Enter an even output size, 10-60 fps, and a bitrate from 500 to 50000 kbps. | 出力サイズは偶数、フレームレートは10〜60fps、ビットレートは500〜50000kbpsで入力してください。 | ✅ 完全一致 | 保留 |
| MediaOutputNoSession | 请先开始设备投屏，再启动媒体输出。 | 請先開始裝置螢幕鏡像，再啟動媒體輸出。 | 請先開始裝置螢幕鏡像，再啟動媒體輸出。 | Start mirroring a device before starting media output. | メディア出力を開始する前に、デバイスのミラーリングを開始してください。 | ✅ 完全一致 | 保留 |
| MediaOutputOperationFailed | 媒体输出操作未完成。请重试；如果问题持续，请查看诊断日志。 | 媒體輸出操作未完成。請重試；如果問題持續，請查看診斷記錄。 | 媒體輸出操作未完成。請重試；如果問題持續，請查看診斷記錄。 | The media output operation could not be completed. Try again, and check the diagnostic log if the problem persists. | メディア出力操作を完了できませんでした。再試行し、問題が続く場合は診断ログを確認してください。 | ✅ 完全一致 | 保留 |
| MediaOutputRecording | 正在录制 | 正在錄製 | 正在錄製 | Recording | 録画中 | ✅ 完全一致 | 保留 |
| MediaOutputRecordingAndStreaming | 正在录制和直播 | 正在錄影及直播 | 正在錄影及直播 | Recording and streaming | 録画と配信 | ✅ 完全一致 | 保留 |
| MediaOutputRecordingFormat | 已开始录制：{0} | 已開始錄製：{0} | 已開始錄製：{0} | Recording started: {0} | 録画を開始しました: {0} | ✅ 完全一致 | 保留 |
| MediaOutputRtmpAddressRequired | 请输入 rtmp:// 或 rtmps:// 地址。 | 請輸入 rtmp:// 或 rtmps:// 位址。 | 請輸入 rtmp:// 或 rtmps:// 位址。 | Enter an rtmp:// or rtmps:// address. | rtmp://またはrtmps://のアドレスを入力してください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputSrtAddressRequired | 请输入 srt:// 地址。 | 請輸入 srt:// 位址。 | 請輸入 srt:// 位址。 | Enter an srt:// address. | srt://のアドレスを入力してください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MediaOutputStartFailedFormat | 无法启动媒体输出：{0} | 無法啟動媒體輸出：{0} | 無法啟動媒體輸出：{0} | Could not start media output: {0} | メディア出力を開始できませんでした: {0} | ✅ 完全一致 | 保留 |
| MediaOutputStopped | 媒体输出已停止。 | 媒體輸出已停止。 | 媒體輸出已停止。 | Media output stopped. | メディア出力を停止しました。 | ✅ 完全一致 | 保留 |
| MediaOutputStopping | 正在停止输出并完成文件或推流收尾… | 正在停止輸出並完成檔案或串流收尾… | 正在停止輸出並完成檔案或串流收尾… | Stopping output and finalizing the file or stream… | 出力を停止し、ファイルまたはストリームの最終処理をしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| MediaOutputStreaming | 正在直播推流 | 正在直播串流 | 正在直播串流 | Live streaming | ライブ配信中 | ✅ 完全一致 | 保留 |
| MediaOutputStreamingFormat | 已开始直播推流：{0} | 已開始直播串流：{0} | 已開始直播串流：{0} | Live stream started: {0} | ライブ配信を開始しました: {0} | ✅ 完全一致 | 保留 |
| MediaOutputTitle | 输出设置 | 輸出設定 | 輸出設定 | Output settings | 出力設定 | ✅ 完全一致 | 保留 |
| MediaOutputUnavailableFormat | 媒体输出不可用：{0} | 媒體輸出不可用：{0} | 媒體輸出不可用：{0} | Media output is unavailable: {0} | メディア出力は利用できません: {0} | ✅ 完全一致 | 保留 |
| MediaOutputWhipAddressRequired | 请输入 HTTP(S) WHIP 端点地址。 | 請輸入 HTTP(S) WHIP 端點位址。 | 請輸入 HTTP(S) WHIP 端點位址。 | Enter an HTTP(S) WHIP endpoint. | HTTP(S)のWHIPエンドポイントを入力してください。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| MicrophoneAudioRequired | 此输出缺少音频编码器，无法加入麦克风。 | 此輸出缺少音訊編碼器，無法加入麥克風。 | 此輸出缺少音訊編碼器，無法加入麥克風。 | This output needs an audio encoder to include a microphone. | マイクを含めるには、この出力に音声エンコーダーが必要です。 | ✅ 完全一致 | 保留 |
| MicrophoneEnumerationFailed | 无法读取麦克风列表：{0} | 無法讀取麥克風清單：{0} | 無法讀取麥克風清單：{0} | Could not read microphones: {0} | マイクを取得できませんでした: {0} | ✅ 完全一致 | 保留 |
| MicrophoneNotFound | 未找到麦克风，请检查 Windows 麦克风访问权限。 | 找不到麥克風，請檢查 Windows 麥克風存取權限。 | 找不到麥克風，請檢查 Windows 麥克風存取權限。 | No microphone found. Check Windows microphone access settings. | マイクが見つかりません。Windowsのマイクのアクセス設定を確認してください。 | ✅ 完全一致 | 保留 |
| MicrophoneOff | 不使用麦克风 | 不使用麥克風 | 不使用麥克風 | No microphone | マイクなし | ✅ 完全一致 | 保留 |
| Minimize | 最小化 | 最小化 | 最小化 | Minimize | 最小化 | ✅ 完全一致 | 保留 |
| MirrorSimultaneously | 同时投屏 | 同時螢幕鏡像 | 同時鏡像多台裝置 | Mirror simultaneously | 同時にミラーリング | ✅ 完全一致 | 保留 |
| ModelLoading | 型号读取中 | 型號讀取中 | 型號讀取中 | Reading model | 機種を読み取り中 | ✅ 完全一致 | 保留 |
| MoreImageSettingsButton | 更多设置 | 更多設定 | 更多設定 | More settings | その他の設定 | ✅ 完全一致 | 保留 |
| MoreImageSettingsSubtitle | 为当前设备微调本地预览画面。 | 為現有裝置微調本機預覽畫面。 | 為現有裝置微調本機預覽畫面。 | Fine-tune the local preview for the selected device. | 選択したデバイスのローカルプレビューを細かく調整します。 | ✅ 完全一致 | 保留 |
| MoreImageSettingsTitle | 画面调节 | 畫面調節 | 畫面調節 | Image adjustments | 映像の調整 | ✅ 完全一致 | 保留 |
| MultiDeviceControlAlreadyActive | 此设备已在另一个投屏会话中启用反控，请使用已有窗口。 | 此裝置已在另一個投影工作階段啟用反控，請使用現有視窗。 | 此裝置已在另一個螢幕鏡像工作階段啟用反向控制，請使用現有視窗。 | This device is already controlled through another mirroring session. Use its existing window. | このデバイスはすでに別のミラーリングセッションで操作されています。既存のウィンドウを使ってください。 | ✅ 完全一致 | 保留 |
| MultiDeviceControlHint | 分别为各设备启用反控。切换选项卡或点击独立投屏窗口即可控制对应设备，连接会保持。 | 分別為各裝置啟用反控。切換分頁或點擊獨立投影視窗即可控制對應裝置，連線會保持。 | 分別為各裝置啟用反向控制。切換分頁或按一下獨立螢幕鏡像視窗即可控制對應裝置，連線會保持。 | Enable control for each device, then switch tabs or focus its separate mirror window. Other device connections stay active. | デバイスごとに操作を有効にしてから、タブを切り替えるか、そのデバイスのミラーリングウィンドウにフォーカスしてください。ほかのデバイスの接続は維持されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| NativeCoreInitFailed | 原生核心初始化失败 | 原生核心初始化失敗 | 原生核心初始化失敗 | Native core initialization failed | ネイティブコアを初期化できませんでした | ✅ 完全一致 | 保留 |
| NavAbout | 关于 | 關於 | 關於 | About | 情報 | ✅ 完全一致 | 保留 |
| NavAboutDescription | 关于与更新 | 關於與更新 | 關於與更新 | About and updates | 情報とアップデート | ✅ 完全一致 | 保留 |
| NavCollapseDescription | 收起导航 | 收起導覽 | 收起導覽 | Collapse navigation | ナビゲーションを折りたたむ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| NavDeviceBinding | 设备绑定器 | 裝置綁定器 | 裝置綁定 | Device binder | デバイスの紐づけ | ✅ 完全一致 | 保留 |
| NavDeviceBindingDescription | 管理真实设备的 USB、AirPlay 和 Bluetooth 身份绑定 | 管理真實裝置的 USB、AirPlay 和 Bluetooth 身份綁定 | 管理真實裝置的 USB、AirPlay 和 Bluetooth 身分綁定 | Manage USB, AirPlay, and Bluetooth identities for real devices | 実機のUSB、AirPlay、Bluetoothの識別情報を管理します | ✅ 完全一致 | 保留 |
| NavDevices | 投屏来源 | 螢幕鏡像來源 | 螢幕鏡像來源 | Sources | ソース | ✅ 完全一致 | 保留 |
| NavDevicesDescription | 选择投屏来源 | 選擇螢幕鏡像來源 | 選擇螢幕鏡像來源 | Choose a mirroring source | ミラーリングのソースを選択 | ✅ 完全一致 | 保留 |
| NavDriver | 驱动 | 驅動程式 | 驅動程式 | Drivers | ドライバー | ✅ 完全一致 | 保留 |
| NavDriverDescription | 驱动管理 | 驅動程式管理 | 驅動程式管理 | Driver manager | ドライバー管理 | ✅ 完全一致 | 保留 |
| NavExpandDescription | 展开导航 | 展開導覽 | 展開導覽 | Expand navigation | ナビゲーションを展開 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| NavExpandToolTip | 展开左侧导航 | 展開左側導覽 | 展開左側導覽 | Expand left navigation | 左のナビゲーションを展開 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| NavMirroring | 投屏 | 螢幕鏡像 | 螢幕鏡像 | Mirroring | ミラーリング | ✅ 完全一致 | 保留 |
| NavMirroringDescription | 投屏控制 | 螢幕鏡像控制 | 螢幕鏡像控制 | Mirroring controls | ミラーリング操作 | ✅ 完全一致 | 保留 |
| NavOutput | 输出 | 輸出 | 輸出 | Output | 出力 | ✅ 完全一致 | 保留 |
| NavOutputDescription | 输出设置 | 輸出設定 | 輸出設定 | Output settings | 出力の設定 | ✅ 完全一致 | 保留 |
| NavSettings | 设置 | 設定 | 設定 | Settings | 設定 | ✅ 完全一致 | 保留 |
| NavSettingsDescription | 投屏设置 | 螢幕鏡像設定 | 螢幕鏡像設定 | Mirroring settings | ミラーリングの設定 | ❌ 术语不一致 → ✅ 已修复 | 投屏统一为 mirroring，视频应用投放仍使用 casting |
| NoDeviceSelected | 未选择设备 | 未選擇裝置 | 未選擇裝置 | No device selected | デバイスが選択されていません | ✅ 完全一致 | 保留 |
| NotifyPrereleaseReleases | 提醒 Beta 预览版更新 | 提醒 Beta 預覽版更新 | 提醒 Beta 預覽版更新 | Notify me about Beta preview releases | ベータ版のプレビューリリースを通知する | ✅ 完全一致 | 保留 |
| NotifyStableReleases | 提醒正式版更新 | 提醒正式版更新 | 提醒正式版更新 | Notify me about stable releases | 安定版のリリースを通知する | ✅ 完全一致 | 保留 |
| ObsTitleCopyFailedFormat | OBS 专用窗口已打开；复制标题失败：{0} | OBS 專用視窗已開啟；複製標題失敗：{0} | OBS 專用視窗已開啟；複製標題失敗：{0} | OBS preview window opened; could not copy its title: {0} | OBS用プレビューウィンドウを開きましたが、タイトルをコピーできませんでした: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ObsWindowHelp | 独立窗口可直接用于 OBS“窗口采集”。 | 獨立視窗可直接用於 OBS「視窗擷取」。 | 獨立視窗可直接用於 OBS「視窗擷取」。 | Use the detached window directly with OBS Window Capture. | 独立ウィンドウは、OBSのウィンドウキャプチャでそのまま使えます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ObsWindowOpenFailedFormat | 打开 OBS 专用窗口失败：{0} | 開啟 OBS 專用視窗失敗：{0} | 開啟 OBS 專用視窗失敗：{0} | Could not open the OBS preview window: {0} | OBS用プレビューウィンドウを開けませんでした: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ObsWindowOpened | OBS 专用窗口已打开；窗口标题已复制 | OBS 專用視窗已開啟；視窗標題已複製 | OBS 專用視窗已開啟；視窗標題已複製 | OBS preview window opened; title copied | OBS用プレビューウィンドウを開き、タイトルをコピーしました | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| OpenLinkFailedTitle | 无法打开 | 無法開啟 | 無法開啟 | Could not open | 開けませんでした | ✅ 完全一致 | 保留 |
| OpenLogs | 打开日志目录 | 開啟記錄檔位置 | 開啟記錄檔位置 | Open log folder | ログフォルダーを開く | ✅ 完全一致 | 保留 |
| OpenObsWindow | 打开 OBS 专用窗口 | 開啟 OBS 專用視窗 | 開啟 OBS 專用視窗 | Open OBS preview window | OBS用プレビューウィンドウを開く | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| OpenReleasePage | 查看完整 Release | 查看完整 Release | 查看完整 Release | View full release | リリースの全文を表示 | ✅ 完全一致 | 保留 |
| OpenShortcutSettings | 设置快捷键 | 設定快捷鍵 | 設定快速鍵 | Configure shortcuts | ショートカットを設定 | ✅ 完全一致 | 保留 |
| OutputBitrate | 码率（kbps） | 位元率（kbps） | 位元率（kbps） | Bitrate (kbps) | ビットレート（kbps） | ✅ 完全一致 | 保留 |
| OutputFps | 帧率 | 幀率 | 影格率 | Frame rate | フレームレート | ✅ 完全一致 | 保留 |
| OutputHeight | 高度 | 高度 | 高度 | Height | 高さ | ✅ 完全一致 | 保留 |
| OutputWidth | 宽度 | 寬度 | 寬度 | Width | 幅 | ✅ 完全一致 | 保留 |
| PauseBluetoothControl | 暂停蓝牙控制 | 暫停藍牙控制 | 暫停藍牙控制 | Pause Bluetooth control | Bluetooth操作を一時停止 | ✅ 完全一致 | 保留 |
| PendingSettingsFormat | 待应用：{0} · {1} fps | 待套用：{0} · {1} fps | 待套用：{0} · {1} fps | Pending: {0} · {1} fps | 保留中: {0} · {1}fps | ✅ 完全一致 | 保留 |
| PendingSettingsLocalFormat | 待应用：{0} · {1} fps（仅本地渲染） | 待套用：{0} · {1} fps（僅本機繪製） | 待套用：{0} · {1} fps（僅本機繪製） | Pending: {0} · {1} fps (local rendering only) | 保留中: {0} · {1}fps（ローカル描画のみ） | ✅ 完全一致 | 保留 |
| PendingVideoSettingsFormat | 待应用：{0} · {1} fps · {2} | 待套用：{0} · {1} fps · {2} | 待套用：{0} · {1} fps · {2} | Pending: {0} · {1} fps · {2} | 保留中: {0} · {1}fps · {2} | ✅ 完全一致 | 保留 |
| PlayAudioWindows | 在 Windows 播放声音 | 在 Windows 播放音訊 | 在 Windows 播放音訊 | Play audio on Windows | Windowsで音声を再生 | ✅ 完全一致 | 保留 |
| PlaybackSpeed | 播放倍速 | 播放倍速 | 播放倍速 | Playback speed | 再生速度 | ✅ 完全一致 | 保留 |
| PlaybackVolume | 播放音量 | 播放音量 | 播放音量 | Playback volume | 再生音量 | ✅ 完全一致 | 保留 |
| PreparingDownload | 正在准备安全下载… | 正在準備安全下載… | 正在準備安全下載… | Preparing a secure download… | 安全なダウンロードを準備しています… | ✅ 完全一致 | 保留 |
| PreviewAndObs | 预览与 OBS | 預覽與 OBS | 預覽與 OBS | Preview and OBS | プレビューとOBS | ✅ 完全一致 | 保留 |
| PreviewChildCreateFailed | 无法创建 D3D11 预览子窗口 | 無法建立 D3D11 預覽子視窗 | 無法建立 D3D11 預覽子視窗 | Could not create the D3D11 preview child window | D3D11プレビューの子ウィンドウを作成できませんでした | ✅ 完全一致 | 保留 |
| PreviewLabel | 预览 | 預覽 | 預覽 | Preview | プレビュー | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| PreviewRefreshFailed | 预览刷新失败：窗口尚未就绪 | 預覽重新整理失敗：視窗尚未就緒 | 預覽重新整理失敗：視窗尚未就緒 | Preview refresh failed: the window is not ready | プレビューを更新できませんでした: ウィンドウの準備ができていません | ✅ 完全一致 | 保留 |
| PreviewRefreshed | 预览渲染器已刷新 | 預覽繪製器已重新整理 | 預覽繪製器已重新整理 | Preview renderer refreshed | プレビューの描画を更新しました | ✅ 完全一致 | 保留 |
| PreviewRendererAttachFailed | 无法连接 D3D11 预览渲染器 | 無法連接 D3D11 預覽渲染器 | 無法連線 D3D11 預覽渲染器 | Could not attach the D3D11 preview renderer | D3D11プレビューのレンダラーを接続できませんでした | ✅ 完全一致 | 保留 |
| PreviewWindowOpenFailedFormat | 打开独立预览失败：{0} | 開啟獨立預覽失敗：{0} | 開啟獨立預覽失敗：{0} | Could not open the preview window: {0} | プレビューウィンドウを開けませんでした: {0} | ✅ 完全一致 | 保留 |
| PreviewWindowOpened | 已打开独立预览窗口 | 已開啟獨立預覽視窗 | 已開啟獨立預覽視窗 | Preview window opened | プレビューウィンドウを開きました | ✅ 完全一致 | 保留 |
| ProjectionActions | 投屏操作 | 螢幕鏡像操作 | 螢幕鏡像操作 | Mirroring | ミラーリング | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ProjectionSettingsDescription | 按需展开常用投屏操作；开始投屏后可使用画面、窗口和截图功能。 | 按需要展開常用螢幕鏡像操作；開始螢幕鏡像後可使用畫面、視窗和螢幕擷取功能。 | 按需要展開常用螢幕鏡像操作；開始螢幕鏡像後可使用畫面、視窗和螢幕擷取功能。 | Open common mirroring actions when needed. Image, window, and capture tools become available after mirroring starts. | よく使うミラーリング操作を必要なときに開けます。画像・ウィンドウ・キャプチャのツールは、ミラーリングの開始後に使えるようになります。 | ✅ 完全一致 | 保留 |
| ProjectionSettingsTitle | 投屏设置 | 螢幕鏡像設定 | 螢幕鏡像設定 | Mirroring settings | ミラーリング設定 | ✅ 完全一致 | 保留 |
| PublishedAtLabel | 发布时间 | 發佈時間 | 發布時間 | Published | 公開日 | ✅ 完全一致 | 保留 |
| ReadCaptureStatusFailed | 读取采集状态失败 | 讀取擷取狀態失敗 | 讀取擷取狀態失敗 | Could not read capture status | キャプチャの状態を読み取れませんでした | ✅ 完全一致 | 保留 |
| ReadDeviceInfoFailed | 读取设备信息失败 | 讀取裝置資料失敗 | 讀取裝置資料失敗 | Could not read device information | デバイス情報を読み取れませんでした | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| ReadEnvironmentFailed | 读取环境失败 | 讀取環境失敗 | 讀取環境失敗 | Could not read the environment | 環境を読み取れませんでした | ✅ 完全一致 | 保留 |
| RecordDescription | 点击后立即开始录制当前投屏画面。结束录制并完成 MP4 封装后，再选择保存位置和文件名。 | 按一下後立即開始錄製目前螢幕鏡像畫面。結束錄製並完成 MP4 封裝後，再選擇儲存位置和檔案名稱。 | 按一下後立即開始錄製目前螢幕鏡像畫面。結束錄製並完成 MP4 封裝後，再選擇儲存位置和檔案名稱。 | Start recording the mirrored video immediately. Choose the save location and file name after MP4 finalization finishes. | ミラーリング中の映像をすぐに録画します。保存先とファイル名は、MP4の最終処理が終わってから選びます。 | ✅ 完全一致 | 保留 |
| RecordMp4Filter | MP4 视频 (*.mp4)&#124;*.mp4 | MP4 影片 (*.mp4)&#124;*.mp4 | MP4 影片 (*.mp4)&#124;*.mp4 | MP4 video (*.mp4)&#124;*.mp4 | MP4動画 (*.mp4)&#124;*.mp4 | ✅ 完全一致 | 保留 |
| RecordSaveTitle | 保存投屏录制 | 儲存螢幕鏡像錄製 | 儲存錄製影片 | Save mirrored recording | ミラーリングの録画を保存 | ✅ 完全一致 | 保留 |
| RecordTab | 录制 | 錄製 | 錄製 | Record | 録画 | ✅ 完全一致 | 保留 |
| RecordingDiscardFailed | 无法丢弃录制文件。 | 無法丟棄錄製檔案。 | 無法丟棄錄製檔案。 | Could not discard the recording. | 録画を破棄できませんでした。 | ✅ 完全一致 | 保留 |
| RecordingDiscarded | 录制已丢弃。 | 錄製已丟棄。 | 錄製已丟棄。 | Recording discarded. | 録画を破棄しました。 | ✅ 完全一致 | 保留 |
| RecordingFinalizeTimeout | FFmpeg 未能在 2 分钟内完成录制文件封装。 | FFmpeg 未能在 2 分鐘內完成錄製檔案封裝。 | FFmpeg 未能在 2 分鐘內完成錄製檔案封裝。 | FFmpeg did not finalize the recording within 2 minutes. | FFmpegが2分以内に録画を完了しませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| RecordingPendingSave | 上一段录制已完成但尚未保存，请先选择保存位置和文件名。 | 上一段錄製已完成但尚未儲存，請先選擇儲存位置和檔案名稱。 | 上一段錄製已完成但尚未儲存，請先選擇儲存位置和檔案名稱。 | The previous recording is complete but has not been saved. Choose its location and file name first. | 前回の録画は完了していますが、まだ保存されていません。先に保存先とファイル名を選んでください。 | ✅ 完全一致 | 保留 |
| RecordingSaveFailedFormat | 无法保存录制文件：{0} | 無法儲存錄製檔案：{0} | 無法儲存錄製檔案：{0} | Could not save the recording: {0} | 録画を保存できませんでした: {0} | ✅ 完全一致 | 保留 |
| RecordingSavedFormat | 录制已保存到：{0} | 錄製已儲存到：{0} | 錄製已儲存到：{0} | Recording saved to: {0} | 録画を保存しました: {0} | ✅ 完全一致 | 保留 |
| RefreshDevices | 刷新设备 | 重新整理裝置 | 重新整理裝置 | Refresh devices | デバイスを更新 | ✅ 完全一致 | 保留 |
| RefreshFrame | 刷新画面 | 重新整理畫面 | 重新整理畫面 | Refresh frame | フレームを更新 | ✅ 完全一致 | 保留 |
| RefreshMicrophones | 刷新麦克风 | 重新整理麥克風 | 重新整理麥克風 | Refresh microphones | マイクを更新 | ✅ 完全一致 | 保留 |
| ReleaseNotesEmpty | 未提供更新说明。 | 未提供更新說明。 | 未提供更新說明。 | No release notes were provided. | リリースノートはありません。 | ✅ 完全一致 | 保留 |
| RemindLater | 稍后提醒 | 稍後提醒 | 稍後提醒 | Remind me later | 後で通知 | ✅ 完全一致 | 保留 |
| RemoteTextClipboardUnavailable | 远程文字未能输入：手机剪贴板服务暂时不可用。请解锁 iPhone 并重新连接有线／无线控制后重试。 | 遠端文字未能輸入：手機剪貼簿服務暫時無法使用。請解鎖 iPhone 並重新連接有線／無線控制後重試。 | 遠端文字未能輸入：手機剪貼簿服務暫時無法使用。請解鎖 iPhone 並重新連接有線／無線控制後重試。 | Remote text could not be entered: the device clipboard service is unavailable. Unlock iPhone and reconnect wired or wireless control, then try again. | リモートでテキストを入力できませんでした。デバイスのクリップボードサービスを利用できません。iPhoneのロックを解除し、有線または無線の操作を再接続してから、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| RenderLimitFormat | 渲染上限 {0} | 繪製上限 {0} | 繪製上限 {0} | Render limit: {0} | 描画の上限: {0} | ✅ 完全一致 | 保留 |
| RenderLimitHelp | 只限制 Windows 本地渲染；不会改变来源分辨率，也不会强制 iOS 固定输出帧率 | 只限制 Windows 本機繪製；不會改變來源解像度，也不會強制 iOS 固定輸出幀率 | 只限制 Windows 本機繪製；不會改變來源解析度，也不會強制 iOS 固定輸出影格率 | Limits Windows rendering only; it does not change source resolution or force iOS to output a fixed frame rate | Windows側の描画だけを制限します。ソースの解像度は変わらず、iOSに固定のフレームレートで出力させることもありません | ✅ 完全一致 | 保留 |
| RenderResolutionLimit | 渲染分辨率上限 | 繪製解像度上限 | 繪製解析度上限 | Render resolution limit | 描画解像度の上限 | ✅ 完全一致 | 保留 |
| ResetImageSettings | 重置 | 還原 | 還原 | Reset | リセット | ✅ 完全一致 | 保留 |
| Resolution1080p | 1080p（1920×1080） | 1080p（1920×1080） | 1080p（1920×1080） | 1080p (1920×1080) | 1080p（1920×1080） | ✅ 完全一致 | 保留 |
| Resolution540p | 540p（960×540） | 540p（960×540） | 540p（960×540） | 540p (960×540) | 540p（960×540） | ✅ 完全一致 | 保留 |
| Resolution720p | 720p（1280×720） | 720p（1280×720） | 720p（1280×720） | 720p (1280×720) | 720p（1280×720） | ✅ 完全一致 | 保留 |
| ResolutionLabel | 分辨率 | 解像度 | 解析度 | Resolution | 解像度 | ✅ 完全一致 | 保留 |
| ResolutionNative | 原生（不限制渲染尺寸） | 原始（不限制繪製尺寸） | 原始（不限制繪製尺寸） | Native (no render limit) | ネイティブ（描画の上限なし） | ✅ 完全一致 | 保留 |
| ResumeBluetoothControl | 恢复蓝牙控制 | 恢復藍牙控制 | 恢復藍牙控制 | Resume Bluetooth control | Bluetooth操作を再開 | ✅ 完全一致 | 保留 |
| RetryUpdate | 重新下载 | 重新下載 | 重新下載 | Download again | もう一度ダウンロード | ✅ 完全一致 | 保留 |
| ReverseControlActivatingImage | 正在设备上挂载开发者镜像… | 正在裝置上掛載開發者映像… | 正在裝置上掛載開發者映像檔… | Mounting the developer image on the device… | デバイスに開発者イメージをマウントしています… | ✅ 完全一致 | 保留 |
| ReverseControlBluetoothFailureAdvice | 蓝牙控制无法连接。请确认电脑蓝牙已开启、设备已配对，再重新尝试。 | 藍牙控制無法連接。請確認電腦藍牙已開啟、裝置已配對，再重新嘗試。 | 藍牙控制無法連線。請確認電腦藍牙已開啟、裝置已配對，再重新嘗試。 | Bluetooth control could not connect. Check that Bluetooth is on and the device is paired, then retry. | Bluetooth操作に接続できませんでした。Bluetoothがオンで、デバイスがペアリングされていることを確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| ReverseControlBridgeNotReady | 反向控制桥接器尚未就绪。 | 反向控制橋接器尚未就緒。 | 反向控制橋接器尚未就緒。 | The reverse-control bridge is not ready. | リモート操作のブリッジの準備ができていません。 | ❌ 术语不一致、❌ 缺失 → ✅ 已修复 | 统一反向控制正式名称；将代码中的用户可见硬编码文字迁入三语资源 |
| ReverseControlCaptureMuxReady | 正在通过镜像共存的 USB 通道连接设备 | 正在透過與螢幕鏡像共存的 USB 通道連接裝置 | 正在透過與螢幕鏡像共存的 USB 通道連線裝置 | Connecting over the USB channel shared with the mirror | ミラーリングと共有しているUSBチャンネルで接続しています | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| ReverseControlCheckingEnvironmentFormat | 正在检查{0}反向控制的开发者环境 | 正在檢查{0}反向控制的開發者環境 | 正在檢查{0}反向控制的開發者環境 | Checking the {0} reverse-control developer environment | {0}のリモート操作に必要な開発者環境を確認しています | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| ReverseControlCheckingImageSources | 正在检查 GitHub 开发者镜像下载 | 正在檢查 GitHub 開發者映像檔下載 | 正在檢查 GitHub 開發者映像檔下載 | Checking GitHub developer-image downloads | GitHubの開発者イメージのダウンロード元を確認しています | ✅ 完全一致 | 保留 |
| ReverseControlCheckingImageTicket | 正在检查设备上的开发者镜像签名… | 正在檢查裝置上的開發者映像簽署… | 正在檢查裝置上的開發者映像檔簽章… | Checking the developer image ticket on the device… | デバイスの開発者イメージチケットを確認しています… | ✅ 完全一致 | 保留 |
| ReverseControlConnectingWireless | 正在连接无线反向控制桥接器 | 正在連接無線反向控制橋接器 | 正在連線無線反向控制橋接器 | Connecting the wireless reverse-control bridge | 無線リモート操作のブリッジに接続しています | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称 |
| ReverseControlDetails | 查看详细信息 | 查看詳細資料 | 查看詳細資料 | View details | 詳細を表示 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语；静态未发现引用，保留待后续调用核对 |
| ReverseControlDiscoveringWireless | 正在发现无线 CoreDevice 设备 | 正在尋找無線 CoreDevice 裝置 | 正在尋找無線 CoreDevice 裝置 | Discovering wireless CoreDevice devices | 無線のCoreDeviceデバイスを探しています | ✅ 完全一致 | 保留 |
| ReverseControlDownloadingImage | 正在下载并校验开发者镜像 | 正在下載並驗證開發者映像檔 | 正在下載並驗證開發者映像檔 | Downloading and verifying the developer image | 開発者イメージをダウンロードして検証しています | ✅ 完全一致 | 保留 |
| ReverseControlErrorBodyFormat | {0}反向控制发生错误：{1} | {0}反向控制發生錯誤：{1} | {0}反向控制發生錯誤：{1} | {0} reverse control encountered an error: {1} | {0}のリモート操作でエラーが発生しました: {1} | ✅ 完全一致 | 保留 |
| ReverseControlErrorCodeFormat | 桥接器错误代码：{0} | 橋接器錯誤代碼：{0} | 橋接器錯誤代碼：{0} | Bridge error code: {0} | ブリッジのエラーコード: {0} | ✅ 完全一致 | 保留 |
| ReverseControlErrorTitle | 反向控制错误 | 反向控制錯誤 | 反向控制錯誤 | Reverse control error | リモート操作のエラー | ✅ 完全一致 | 保留 |
| ReverseControlInitializingTouchFormat | 正在初始化{0}触控通道 | 正在初始化{0}觸控通道 | 正在初始化{0}觸控通道 | Initializing the {0} touch channel | {0}のタッチチャンネルを初期化しています | ✅ 完全一致 | 保留 |
| ReverseControlNoDetail | 未提供详细信息 | 未提供詳細資料 | 未提供詳細資料 | No details were provided | 詳細は提供されませんでした | ✅ 完全一致 | 保留 |
| ReverseControlNoticeErrorBadge | 反向控制未能继续 | 反向控制未能繼續 | 反向控制未能繼續 | Reverse control could not continue | リモート操作を続行できません | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| ReverseControlPersonalizingImage | 正在向 Apple 请求开发者镜像签名… | 正在向 Apple 請求開發者映像簽署… | 正在向 Apple 請求開發者映像檔簽章… | Requesting a developer image ticket from Apple… | Appleに開発者イメージチケットを要求しています… | ✅ 完全一致 | 保留 |
| ReverseControlPreparingImage | 正在准备开发者镜像… | 正在準備開發者映像… | 正在準備開發者映像檔… | Preparing the developer image… | 開発者イメージを準備しています… | ✅ 完全一致 | 保留 |
| ReverseControlPrerequisiteStatus | 请确认准备工作后继续 | 請確認準備工作後繼續 | 請確認準備工作後繼續 | Confirm the prerequisites before continuing | 続行する前に、前提条件を確認してください | ✅ 完全一致 | 保留 |
| ReverseControlPrerequisiteWiredBody | 1. USB 连接设备，解锁并点击“信任此电脑”。<br>2. 点击“继续”后会自动请求显示“开发者模式”开关。<br>3. 若尚未开启，请按提示在手机设置中开启、重启并确认，然后回来重试。<br>4. 首次使用会从 GitHub 下载匹配的 DDI，准备完成前不会发送输入。<br><br>连接并信任后点击“继续”，否则点击“取消”。 | 1. 使用 USB 連接裝置，解鎖並點選「信任此電腦」。<br>2. 點選「繼續」後會自動請求顯示「開發者模式」開關。<br>3. 若尚未開啟，請依提示在手機設定中開啟、重新啟動並確認，再回來重試。<br>4. 首次使用會從 GitHub 下載相符的 DDI，準備完成前不會傳送輸入。<br><br>連接並信任後點選「繼續」，否則點選「取消」。 | 1. 使用 USB 連線裝置，解鎖並點選「信任此電腦」。<br>2. 點選「繼續」後會自動請求顯示「開發者模式」開關。<br>3. 若尚未開啟，請依提示在手機設定中開啟、重新啟動並確認，再回來重試。<br>4. 首次使用會從 GitHub 下載相符的 DDI，準備完成前不會傳送輸入。<br><br>連線並信任後點選「繼續」，否則點選「取消」。 | 1. Connect by USB, unlock the device, and tap “Trust This Computer”.<br>2. Click Continue to automatically request the Developer Mode toggle in Settings.<br>3. If disabled, follow the instructions to enable it on the device, restart, confirm, then retry here.<br>4. The matching DDI downloads from GitHub on first use. No input is sent until setup is ready.<br><br>Click Continue once connected and trusted, or Cancel. | 1. USBで接続し、デバイスのロックを解除して、「このコンピュータを信頼」をタップします。<br>2. 「続行」をクリックすると、「設定」のデベロッパモードのスイッチが自動で要求されます。<br>3. 無効の場合は、案内に従ってデバイスで有効にし、再起動して確認してから、ここで再試行します。<br>4. 初回は、対応するDDIがGitHubからダウンロードされます。準備が整うまで、入力は送信されません。<br><br>接続して信頼したら「続行」を、やめる場合は「キャンセル」をクリックしてください。 | ✅ 完全一致 | 保留 |
| ReverseControlPrerequisiteWiredTitle | 启用有线控制前请确认 | 啟用有線控制前請確認 | 啟用有線控制前請確認 | Before enabling wired control | 有線操作を有効にする前に | ✅ 完全一致 | 保留 |
| ReverseControlPrerequisiteWirelessBody | 1. 开启“开发者模式”并重启设备。<br>2. 先通过 USB 完成信任和无线配对。<br>3. 保持设备解锁，并连接同一局域网。<br>4. 允许 iPhoneMirror 通过 Windows 防火墙通信。<br><br>完成后点击“继续”，否则点击“取消”。 | 1. 開啟「開發者模式」並重新啟動裝置。<br>2. 先透過 USB 完成信任和無線配對。<br>3. 保持裝置解鎖，並連接同一區域網絡。<br>4. 允許 iPhoneMirror 通過 Windows 防火牆通訊。<br><br>完成後點選「繼續」，否則點選「取消」。 | 1. 開啟「開發者模式」並重新啟動裝置。<br>2. 先透過 USB 完成信任和無線配對。<br>3. 保持裝置解鎖，並連線同一區域網路。<br>4. 允許 iPhoneMirror 通過 Windows 防火牆通訊。<br><br>完成後點選「繼續」，否則點選「取消」。 | 1. Turn on Developer Mode and restart the device.<br>2. Complete trust and wireless pairing once over USB.<br>3. Keep the device unlocked on the same local network.<br>4. Allow iPhoneMirror through Windows Firewall.<br><br>Click Continue when ready, or Cancel. | 1. デベロッパモードをオンにして、デバイスを再起動します。<br>2. 信頼と無線ペアリングを、一度USBで済ませます。<br>3. デバイスのロックを解除したまま、同じローカルネットワークに接続します。<br>4. WindowsファイアウォールでiPhoneMirrorを許可します。<br><br>準備ができたら「続行」を、やめる場合は「キャンセル」をクリックしてください。 | ✅ 完全一致 | 保留 |
| ReverseControlPrerequisiteWirelessTitle | 启用无线控制前请确认 | 啟用無線控制前請確認 | 啟用無線控制前請確認 | Before enabling wireless control | 無線操作を有効にする前に | ✅ 完全一致 | 保留 |
| ReverseControlRecoveryErrorTitle | 反向控制连接中断 | 反向控制連線中斷 | 反向控制連線中斷 | Reverse control disconnected | リモート操作が切断されました | ✅ 完全一致 | 保留 |
| ReverseControlRemountingImage | 正在刷新旧开发者镜像以启用触控服务 | 正在重新整理舊開發者映像檔以啟用觸控服務 | 正在重新整理舊開發者映像檔以啟用觸控服務 | Refreshing the old developer image to enable touch service | タッチサービスを有効にするため、古い開発者イメージを更新しています | ✅ 完全一致 | 保留 |
| ReverseControlRetry | 重试 | 重試 | 重試 | Retry | 再試行 | ✅ 完全一致 | 保留 |
| ReverseControlStartErrorTitle | 反向控制启动失败 | 反向控制啟動失敗 | 反向控制啟動失敗 | Reverse control could not start | リモート操作を開始できませんでした | ✅ 完全一致 | 保留 |
| ReverseControlStopErrorTitle | 反向控制关闭异常 | 反向控制關閉異常 | 反向控制關閉異常 | Reverse control shutdown issue | リモート操作の終了時に問題が発生しました | ✅ 完全一致 | 保留 |
| ReverseControlStopFailureAdvice | 控制已停止，但设备资源可能尚未完全释放。请重新连接设备后再试。 | 控制已停止，但裝置資源可能尚未完全釋放。請重新連接裝置後再試。 | 控制已停止，但裝置資源可能尚未完全釋放。請重新連線裝置後再試。 | Control has stopped, but device resources may not be fully released. Reconnect the device before retrying. | 操作は停止しましたが、デバイスのリソースが完全には解放されていない可能性があります。再試行する前に、デバイスをつなぎ直してください。 | ✅ 完全一致 | 保留 |
| ReverseControlStopFailureDetailFormat | 关闭失败：{0} | 關閉失敗：{0} | 關閉失敗：{0} | Shutdown failed: {0} | 終了できませんでした: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ReverseControlSwitchingImage | 当前镜像不可用，正在尝试其他兼容镜像… | 目前映像無法使用，正在嘗試其他相容映像… | 目前映像檔無法使用，正在嘗試其他相容映像檔… | The current image is unavailable; trying another compatible image… | 現在のイメージは利用できません。互換性のある別のイメージを試しています… | ✅ 完全一致 | 保留 |
| ReverseControlTitle | 反向控制 | 反向控制 | 反向控制 | Reverse control | リモート操作 | ✅ 完全一致 | 保留 |
| ReverseControlTransportBluetooth | 蓝牙 | 藍牙 | 藍牙 | Bluetooth | Bluetooth | ✅ 完全一致 | 保留 |
| ReverseControlTransportWired | 有线 | 有線 | 有線 | wired | 有線 | ✅ 完全一致 | 保留 |
| ReverseControlTransportWireless | 无线 | 無線 | 無線 | wireless | 無線 | ✅ 完全一致 | 保留 |
| ReverseControlUnknownError | 反向控制桥接器报告未知错误。 | 反向控制橋接器報告未知錯誤。 | 反向控制橋接器報告未知錯誤。 | The reverse-control bridge reported an unknown error. | リモート操作のブリッジから不明なエラーが報告されました。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| ReverseControlUploadingImage | 正在向设备传输开发者镜像… | 正在向裝置傳輸開發者映像… | 正在向裝置傳輸開發者映像檔… | Transferring the developer image to the device… | 開発者イメージをデバイスに転送しています… | ✅ 完全一致 | 保留 |
| ReverseControlUsbBindingChanged | 设备 USB 绑定已改变，请重新启用控制。 | 裝置 USB 綁定已變更，請重新啟用控制。 | 裝置 USB 綁定已變更，請重新啟用控制。 | The USB device binding changed. Enable control again. | USBデバイスの紐づけが変更されました。操作をもう一度有効にしてください。 | ✅ 完全一致 | 保留 |
| ReverseControlUsbConnected | 有线控制已连接（设备认证状态需以实测为准） | 有線控制已連接（裝置驗證狀態需以實測為準） | 有線控制已連線（裝置驗證狀態需以實測為準） | Wired control connected (device authentication status should be verified in practice) | 有線操作に接続しました（デバイス認証の状態は実機で確認してください） | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbConnecting | 正在连接有线控制 | 正在連接有線控制 | 正在連線有線控制 | Connecting wired control | 有線操作に接続しています | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbDisconnected | USB 触控通道已断开 | USB 觸控通道已中斷連線 | USB 觸控通道已中斷連線 | The USB touch channel was disconnected | USBタッチチャンネルが切断されました | ✅ 完全一致 | 保留 |
| ReverseControlUsbEnabled | 有线控制已启用 | 有線控制已啟用 | 有線控制已啟用 | Wired control enabled | 有線操作を有効にしました | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbEnabledDirect | 有线控制已启用（直接 HID） | 有線控制已啟用（直接 HID） | 有線控制已啟用（直接 HID） | Wired control enabled (direct HID) | 有線操作を有効にしました（HID直接） | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbFailedFormat | 有线控制连接失败：{0} | 有線控制連線失敗：{0} | 有線控制連線失敗：{0} | Wired control connection failed: {0} | 有線操作に接続できませんでした: {0} | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbOff | 有线控制未启用 | 有線控制未啟用 | 有線控制未啟用 | Wired control is off | 有線操作はオフです | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbStopFailedFormat | 有线控制关闭失败：{0} | 有線控制關閉失敗：{0} | 有線控制關閉失敗：{0} | Wired control shutdown failed: {0} | 有線操作を終了できませんでした: {0} | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlUsbStopping | 正在关闭有线控制 | 正在關閉有線控制 | 正在關閉有線控制 | Stopping wired control | 有線操作を停止しています | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| ReverseControlVerifyingImage | 正在验证开发者镜像挂载结果… | 正在驗證開發者映像掛載結果… | 正在驗證開發者映像檔掛載結果… | Verifying the developer image mount… | 開発者イメージのマウントを検証しています… | ✅ 完全一致 | 保留 |
| ReverseControlWaitingTouchService | 正在等待开发者镜像发布触控服务 | 正在等待開發者映像檔發佈觸控服務 | 正在等待開發者映像檔發布觸控服務 | Waiting for the developer image to publish the touch service | 開発者イメージがタッチサービスを公開するのを待っています | ✅ 完全一致 | 保留 |
| ReverseControlWirelessConnected | 无线控制已连接 | 無線控制已連接 | 無線控制已連線 | Wireless control connected | 無線操作に接続しました | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| ReverseControlWirelessDisconnected | 无线反向控制桥接通道已断开 | 無線反向控制通道已中斷連線 | 無線反向控制通道已中斷連線 | The wireless reverse-control channel was disconnected | 無線リモート操作のチャンネルが切断されました | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称 |
| ReverseControlWirelessEnabled | 无线控制已启用 | 無線控制已啟用 | 無線控制已啟用 | Wireless control enabled | 無線操作を有効にしました | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| ReverseControlWirelessEnabledDirect | 无线控制已启用（直接 HID） | 無線控制已啟用（直接 HID） | 無線控制已啟用（直接 HID） | Wireless control enabled (direct HID) | 無線操作を有効にしました（HID直接） | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| ReverseControlWirelessFailedFormat | 无线控制连接失败：{0} | 無線控制連線失敗：{0} | 無線控制連線失敗：{0} | Wireless control connection failed: {0} | 無線操作に接続できませんでした: {0} | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| ReverseControlWirelessOff | 无线控制未启用 | 無線控制未啟用 | 無線控制未啟用 | Wireless control is off | 無線操作はオフです | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| ReverseControlWirelessStopFailedFormat | 无线控制关闭失败：{0} | 無線控制關閉失敗：{0} | 無線控制關閉失敗：{0} | Wireless control shutdown failed: {0} | 無線操作を終了できませんでした: {0} | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| SaturationLabel | 饱和度 | 飽和度 | 飽和度 | Saturation | 彩度 | ✅ 完全一致 | 保留 |
| Save | 保存 | 儲存 | 儲存 | Save | 保存 | ✅ 完全一致 | 保留 |
| Screenshot | 截图 | 螢幕擷取畫面 | 螢幕截圖 | Screenshot | スクリーンショット | ✅ 完全一致 | 保留 |
| ScreenshotBusy | 截图正在处理中，请稍候 | 螢幕擷取畫面正在處理中，請稍候 | 螢幕截圖正在處理中，請稍候 | A screenshot is already being processed | スクリーンショットを処理中です | ✅ 完全一致 | 保留 |
| ScreenshotFailedFormat | 截图失败：{0} | 螢幕擷取畫面失敗：{0} | 螢幕截圖失敗：{0} | Screenshot failed: {0} | スクリーンショットを保存できませんでした: {0} | ✅ 完全一致 | 保留 |
| ScreenshotInvalidFrame | 最新视频帧的 BGRA 布局无效 | 最新影片畫面的 BGRA 排列無效 | 最新影片畫面的 BGRA 排列無效 | The latest BGRA video frame is invalid | 最新のBGRA映像フレームが無効です | ✅ 完全一致 | 保留 |
| ScreenshotNoFrame | 尚未收到可截图的视频帧 | 尚未收到可擷取的影片畫面 | 尚未收到可擷取的影片畫面 | No video frame is available for a screenshot | スクリーンショットに使える映像フレームがありません | ✅ 完全一致 | 保留 |
| ScreenshotPngFilter | PNG 图片 (*.png)&#124;*.png | PNG 圖片 (*.png)&#124;*.png | PNG 圖片 (*.png)&#124;*.png | PNG image (*.png)&#124;*.png | PNG画像 (*.png)&#124;*.png | ✅ 完全一致 | 保留 |
| ScreenshotSaveTitle | 保存投屏截图 | 儲存螢幕擷取畫面 | 儲存螢幕截圖 | Save mirroring screenshot | ミラーリングのスクリーンショットを保存 | ✅ 完全一致 | 保留 |
| ScreenshotSavedFormat | 截图已保存：{0} | 螢幕擷取畫面已儲存：{0} | 螢幕截圖已儲存：{0} | Screenshot saved: {0} | スクリーンショットを保存しました: {0} | ✅ 完全一致 | 保留 |
| SeparateWindow | 独立窗口 | 獨立視窗 | 獨立視窗 | Preview window | プレビューウィンドウ | ✅ 完全一致 | 保留 |
| SetupAirPlayFailed | 无线投屏尚未就绪，请检查 Wi-Fi 和接收组件。 | 無線鏡像輸出尚未就緒，請檢查 Wi-Fi 和接收元件。 | 無線鏡像輸出尚未就緒，請檢查 Wi-Fi 和接收元件。 | Wireless mirroring isn't ready. Check Wi-Fi and receiver components. | 無線ミラーリングの準備ができていません。Wi-Fiとレシーバーのコンポーネントを確認してください。 | ✅ 完全一致 | 保留 |
| SetupAppearance | 外观 | 外觀 | 外觀 | Appearance | 外観 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupBegin | 开始设置 → | 開始設定 → | 開始設定 → | Get started → | 始める → | ✅ 完全一致 | 保留 |
| SetupBindingSaved | 绑定已保存，可以直接继续；需要更换设备时再重新配置。 | 綁定已儲存，可以直接繼續；需要更換裝置時再重新設定。 | 綁定已儲存，可以直接繼續；需要更換裝置時再重新設定。 | The binding is saved. Continue, or set up again to use a different device. | 紐づけを保存しました。続けるか、別のデバイスを使うにはもう一度設定してください。 | ✅ 完全一致 | 保留 |
| SetupBluetoothFailed | 未能验证蓝牙连接，请检查配对和辅助触控。 | 無法驗證藍牙連線，請檢查配對和輔助觸控。 | 無法驗證藍牙連線，請檢查配對和輔助觸控。 | Couldn't verify Bluetooth. Check pairing and AssistiveTouch. | Bluetoothを確認できませんでした。ペアリングとAssistiveTouchを確認してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupCancelOperation | 取消操作 | 取消操作 | 取消操作 | Cancel task | タスクをキャンセル | ✅ 完全一致 | 保留 |
| SetupCancelled | 操作已取消，可以重新尝试。 | 操作已取消，可以重試。 | 操作已取消，可以重試。 | Cancelled. You can try again. | キャンセルしました。もう一度お試しください。 | ✅ 完全一致 | 保留 |
| SetupCancelling | 正在取消，等待当前操作安全结束… | 正在取消，等待目前操作安全結束… | 正在取消，等待目前操作安全結束… | Cancelling; waiting for the current operation to finish safely… | キャンセルしています。実行中の処理が安全に終わるのを待っています… | ✅ 完全一致 | 保留 |
| SetupCheckAgain | 重新检查 | 重新檢查 | 重新檢查 | Check again | もう一度確認 | ✅ 完全一致 | 保留 |
| SetupCheckAirPlayBinding | 无线设备绑定 | 無線裝置綁定 | 無線裝置綁定 | AirPlay binding | AirPlayの紐づけ | ✅ 完全一致 | 保留 |
| SetupCheckAppearance | 外观 | 外觀 | 外觀 | Appearance | 外観 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupCheckApple | Apple 驱动与服务 | Apple 驅動程式與服務 | Apple 驅動程式與服務 | Apple drivers and services | Appleのドライバーとサービス | ✅ 完全一致 | 保留 |
| SetupCheckApplicationMode | 应用模式 | 應用程式模式 | 應用程式模式 | Application mode | アプリの表示モード | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupCheckBinding | 设备绑定 | 裝置綁定 | 裝置綁定 | Device binding | デバイスの紐づけ | ✅ 完全一致 | 保留 |
| SetupCheckBindingsUnreadable | 无法读取设备档案，请检查配置文件或重新保存绑定。 | 無法讀取裝置檔案，請檢查設定檔或重新儲存綁定。 | 無法讀取裝置檔案，請檢查設定檔或重新儲存綁定。 | Device profiles could not be read. Check the settings file or save the binding again. | デバイスプロファイルを読み取れませんでした。設定ファイルを確認するか、紐づけをもう一度保存してください。 | ✅ 完全一致 | 保留 |
| SetupCheckBluetooth | 蓝牙环境 | 藍牙環境 | 藍牙環境 | Bluetooth environment | Bluetooth環境 | ✅ 完全一致 | 保留 |
| SetupCheckBluetoothBinding | 蓝牙设备绑定 | 藍牙裝置綁定 | 藍牙裝置綁定 | Bluetooth binding | Bluetoothの紐づけ | ✅ 完全一致 | 保留 |
| SetupCheckBluetoothOff | 请打开电脑蓝牙，然后重新检查。已有绑定不会被清除。 | 請開啟電腦藍牙，然後重新檢查。已有綁定不會被清除。 | 請開啟電腦藍牙，然後重新檢查。已有綁定不會被清除。 | Turn on Bluetooth on this computer, then check again. Existing bindings are preserved. | このコンピュータのBluetoothをオンにしてから、もう一度確認してください。既存の紐づけは保持されます。 | ✅ 完全一致 | 保留 |
| SetupCheckBridge | 反向控制组件 | 反向控制組件 | 反向控制元件 | Control components | 操作コンポーネント | ✅ 完全一致 | 保留 |
| SetupCheckBridgeRepair | 反向控制组件缺失或无法运行。请使用同一版本的完整安装包修复安装，然后点击重新检查。 | 反向控制組件遺失或無法執行。請使用相同版本的完整安裝套件修復安裝，然後按重新檢查。 | 反向控制元件遺失或無法執行。請使用相同版本的完整安裝套件修復安裝，然後按重新檢查。 | Control components are missing or cannot run. Repair the installation with the complete installer for this version, then check again. | 操作コンポーネントが見つからないか、実行できません。このバージョンのインストーラー一式でインストールを修復してから、もう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupCheckControlHint | 请连接并解锁对应 iPhone，确认已信任此电脑并开启开发者模式。无线控制还需要通过现有连接设置启用 Wi-Fi 同步。完成后重新检查。检查不会配对设备、下载或挂载镜像，也不会发送控制输入。 | 請連接並解鎖對應 iPhone，確認已信任此電腦並開啟開發者模式。無線控制還需要透過現有連線設定啟用 Wi-Fi 同步。完成後重新檢查。檢查不會配對裝置、下載或掛載映像，也不會傳送控制輸入。 | 請連接並解鎖對應 iPhone，確認已信任此電腦並開啟開發者模式。無線控制還需要透過現有連線設定啟用 Wi-Fi 同步。完成後重新檢查。檢查不會配對裝置、下載或掛載映像，也不會傳送控制輸入。 | Connect and unlock this iPhone, trust this computer, and enable Developer Mode. Wireless control also needs Wi-Fi sync enabled through the existing connection settings. Then check again. This check does not pair devices, download or mount images, or send input. | このiPhoneを接続してロックを解除し、このコンピュータを信頼して、デベロッパモードを有効にしてください。無線操作には、既存の接続設定でWi-Fi同期を有効にする必要もあります。そのあと、もう一度確認してください。この確認では、デバイスのペアリング、イメージのダウンロードやマウント、入力の送信は行いません。 | ✅ 完全一致 | 保留 |
| SetupCheckDescription | 正在确认当前配置、设备身份和必要组件。 | 正在確認目前設定、裝置身分與必要組件。 | 正在確認目前設定、裝置身分與必要元件。 | Checking saved settings, device identities, and required components. | 保存済みの設定、デバイスの識別情報、必要なコンポーネントを確認しています。 | ✅ 完全一致 | 保留 |
| SetupCheckDevice | 设备连接与身份 | 裝置連線與身分 | 裝置連線與身分 | Device connection and identity | デバイスの接続と識別情報 | ✅ 完全一致 | 保留 |
| SetupCheckDeviceDriver | 检查此设备的 USB 驱动与连接状态。 | 檢查此裝置的 USB 驅動程式與連線狀態。 | 檢查此裝置的 USB 驅動程式與連線狀態。 | Check this device’s USB driver and connection. | このデバイスのUSBドライバーと接続を確認してください。 | ✅ 完全一致 | 保留 |
| SetupCheckDisplay | 投屏偏好 | 投影偏好 | 投影偏好 | Display preferences | 表示設定 | ✅ 完全一致 | 保留 |
| SetupCheckDone | 完成 | 完成 | 完成 | Done | 完了 | ✅ 完全一致 | 保留 |
| SetupCheckDoneLater | 保存并稍后处理 | 儲存並稍後處理 | 儲存並稍後處理 | Save and finish later | 保存してあとで完了 | ✅ 完全一致 | 保留 |
| SetupCheckFinished | 设置检查完成 | 設定檢查完成 | 設定檢查完成 | Setup check complete | セットアップの確認が完了しました | ✅ 完全一致 | 保留 |
| SetupCheckHeading | 正在检查你的设置 | 正在檢查你的設定 | 正在檢查你的設定 | Checking your setup | セットアップを確認中 | ✅ 完全一致 | 保留 |
| SetupCheckNewDevices | 发现新的设备 | 發現新的裝置 | 發現新的裝置 | New devices found | 新しいデバイスが見つかりました | ✅ 完全一致 | 保留 |
| SetupCheckOffline | 设备暂未连接。原有绑定已保留，请连接并解锁设备后重新检查。 | 裝置尚未連線。原有綁定已保留，請連接並解鎖裝置後重新檢查。 | 裝置尚未連線。原有綁定已保留，請連接並解鎖裝置後重新檢查。 | The device is offline. Its bindings are preserved. Connect and unlock it, then check again. | デバイスがオフラインです。紐づけは保持されています。接続してロックを解除してから、もう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupCheckPairing | 核对已保存的蓝牙身份与 Windows 配对记录。 | 核對已儲存的藍牙身分與 Windows 配對記錄。 | 核對已儲存的藍牙身分與 Windows 配對記錄。 | Compare the saved Bluetooth identity with Windows pairing records. | 保存済みのBluetoothの識別情報を、Windowsのペアリング記録と照合します。 | ✅ 完全一致 | 保留 |
| SetupCheckPreferences | 界面语言 | 介面語言 | 介面語言 | Language | 言語 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupCheckReady | 设置已完成 | 設定已完成 | 設定已完成 | Setup is complete | セットアップが完了しました | ✅ 完全一致 | 保留 |
| SetupCheckReadyHint | iPhone Mirror 已经准备就绪。 | iPhone Mirror 已經準備就緒。 | iPhone Mirror 已經準備就緒。 | iPhone Mirror is ready. | iPhone Mirrorの準備ができました。 | ✅ 完全一致 | 保留 |
| SetupCheckReceiver | 无线投屏组件 | 無線投影組件 | 無線投影元件 | Wireless receiver | 無線レシーバー | ✅ 完全一致 | 保留 |
| SetupCheckReconfigure | 重新配置全部设置 | 重新配置全部設定 | 重新配置全部設定 | Configure all settings again | すべての設定をやり直す | ✅ 完全一致 | 保留 |
| SetupCheckRemaining | 发现 {0} 项需要处理。我们会引导你完成剩余设置，已完成的设置不会重复配置。 | 發現 {0} 項需要處理。我們會引導你完成剩餘設定，已完成的設定不會重複配置。 | 發現 {0} 項需要處理。我們會引導你完成剩餘設定，已完成的設定不會重複配置。 | {0} items need attention. We’ll guide you through the remaining setup and keep what is already complete. | {0}件の項目に対応が必要です。残りのセットアップをご案内します。完了済みの内容はそのまま維持されます。 | ✅ 完全一致 | 保留 |
| SetupCheckRunning | 正在检查 | 正在檢查 | 正在檢查 | Checking… | 確認中… | ✅ 完全一致 | 保留 |
| SetupCheckUnavailable | 暂时无法完成检查，请重试或查看诊断信息。 | 暫時無法完成檢查，請重試或查看診斷資訊。 | 暫時無法完成檢查，請重試或查看診斷資訊。 | This check could not be completed. Retry or review the diagnostic details. | この確認を完了できませんでした。再試行するか、診断の詳細を確認してください。 | ✅ 完全一致 | 保留 |
| SetupCheckUnlock | 请解锁 iPhone 并确认信任此电脑，然后重新检测设备身份。 | 請解鎖 iPhone 並確認信任此電腦，然後重新偵測裝置身分。 | 請解鎖 iPhone 並確認信任此電腦，然後重新偵測裝置身分。 | Unlock the iPhone and trust this computer, then check its identity again. | iPhoneのロックを解除してこのコンピュータを信頼してから、識別情報をもう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupCheckUsage | 使用用途 | 使用用途 | 使用用途 | Usage | 使い方 | ✅ 完全一致 | 保留 |
| SetupCheckUsb | USB 驱动组件 | USB 驅動程式組件 | USB 驅動程式元件 | USB driver components | USBドライバーのコンポーネント | ✅ 完全一致 | 保留 |
| SetupCheckUseFeature | 使用此功能 | 使用此功能 | 使用此功能 | Use this feature | この機能を使う | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupCheckWaiting | 等待检查 | 等待檢查 | 等待檢查 | Waiting | 待機中 | ✅ 完全一致 | 保留 |
| SetupChecking | 正在检测 · 第 {0} 次检查 · 最多再等待 {1} 秒 | 正在偵測 · 第 {0} 次檢查 · 最多再等候 {1} 秒 | 正在偵測 · 第 {0} 次檢查 · 最多再等候 {1} 秒 | Checking · Attempt {0} · Up to {1} seconds remaining | 確認中 · {0}回目 · 残り最大{1}秒 | ✅ 完全一致 | 保留 |
| SetupConfigure | 开始配置 | 開始設定 | 開始設定 | Start setup | セットアップを開始 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupConfigureAgain | 重新配置 | 重新設定 | 重新設定 | Set up again | もう一度設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupConfirmIdentity | 请选择当前正在配置的设备，并确认它属于你。 | 請選擇目前正在設定的裝置，並確認它屬於你。 | 請選擇目前正在設定的裝置，並確認它屬於你。 | Select the device you are setting up and confirm it belongs to you. | セットアップするデバイスを選び、自分のものであることを確認してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupConnectedCount | 目前已连接 {0} 台 iPhone / iPad | 目前已連接 {0} 部 iPhone / iPad | 目前已連接 {0} 台 iPhone / iPad | {0} iPhone / iPad devices connected | iPhone / iPadを{0}台接続中 | ✅ 完全一致 | 保留 |
| SetupContinue | 继续设置 | 繼續設定 | 繼續設定 | Continue setup | セットアップを続ける | ✅ 完全一致 | 保留 |
| SetupControlBluetooth | 蓝牙控制 | 藍牙控制 | 藍牙控制 | Bluetooth control | Bluetooth操作 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupControlFailed | 设备控制服务尚未就绪，请按提示完成设备上的操作。 | 裝置控制服務尚未就緒，請依提示完成裝置上的操作。 | 裝置控制服務尚未就緒，請依提示完成裝置上的操作。 | Device control isn't ready. Complete the requested steps on your device. | デバイスの操作の準備ができていません。デバイスで求められた手順を完了してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupControlHintBluetooth | 独立于投屏连接<br>需要蓝牙和辅助触控<br>配对后选择设备并保存 | 獨立於鏡像輸出連線<br>需要藍牙和輔助觸控<br>配對後選擇裝置並儲存 | 獨立於鏡像輸出連線<br>需要藍牙與輔助觸控<br>配對後選擇裝置並儲存 | Independent of mirroring.<br>Requires Bluetooth and AssistiveTouch.<br>Pair, select and save. | ミラーリングとは独立しています。<br>BluetoothとAssistiveTouchが必要です。<br>ペアリングして選択し、保存します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupControlHintUsb | 低延迟、稳定<br>需要 USB 数据线<br>读取设备身份后自动保存 | 低延遲、穩定<br>需要 USB 數據線<br>讀取裝置身份後自動儲存 | 低延遲、穩定<br>需要 USB 傳輸線<br>讀取裝置身分後自動儲存 | Low latency and stable.<br>Requires a USB cable.<br>Device identity is saved automatically. | 低遅延で安定しています。<br>USBケーブルが必要です。<br>デバイスの識別情報は自動で保存されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupControlHintWireless | 不用连接数据线<br>稳定性取决于网络<br>投屏一次即可记录设备 | 不需要連接數據線<br>穩定性取決於網絡<br>鏡像輸出一次即可記錄裝置 | 不需要連接傳輸線<br>穩定性取決於網路<br>鏡像輸出一次即可記錄裝置 | No USB cable needed.<br>Depends on your network.<br>Mirror once to save the device. | USBケーブルは不要です。<br>ネットワークの状態に左右されます。<br>一度ミラーリングすると、デバイスが保存されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupControlRecommend | 推荐先完成有线绑定，再按需添加无线和蓝牙。 | 建議先完成有線綁定，再按需要新增無線和藍牙。 | 建議先完成有線綁定，再依需求新增無線和藍牙。 | Start with wired binding, then add wireless or Bluetooth as needed. | まず有線の紐づけから始めて、必要に応じて無線やBluetoothを追加してください。 | ✅ 完全一致 | 保留 |
| SetupControlUsb | 有线控制 · 推荐 | 有線控制 · 建議 | 有線控制 · 建議 | Wired control · Recommended | 有線操作 · おすすめ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupControlWireless | 无线控制 | 無線控制 | 無線控制 | Wireless control | 無線操作 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupCustomize | 逐项调整 | 逐項調整 | 逐項調整 | Customize step by step | 一歩ずつカスタマイズ | ✅ 完全一致 | 保留 |
| SetupCustomizeHint | 分别选择画质、流畅度和画面处理方式。 | 分別選擇畫質、流暢度和畫面處理方式。 | 分別選擇畫質、流暢度和畫面處理方式。 | Choose quality, smoothness and video processing on separate pages. | 画質、滑らかさ、映像処理を別々のページで選びます。 | ✅ 完全一致 | 保留 |
| SetupDefer | 以后再配置 | 稍後再設定 | 稍後再設定 | Set up later | あとで設定 | ✅ 完全一致 | 保留 |
| SetupDetails | 查看详细信息 | 檢視詳細資訊 | 檢視詳細資訊 | View details | 詳細を表示 | ✅ 完全一致 | 保留 |
| SetupDeviceLost | 未能验证这台设备。请重新连接原设备、解锁，并点击“信任”。 | 無法驗證這台裝置。請重新連接原裝置、解鎖，並點選「信任」。 | 無法驗證這台裝置。請重新連接原裝置、解鎖，並點選「信任」。 | Couldn't verify this device. Reconnect the same device, unlock it and tap Trust. | このデバイスを確認できませんでした。同じデバイスを再接続し、ロックを解除して「信頼」をタップしてください。 | ✅ 完全一致 | 保留 |
| SetupDeviceProgress | 设备 {0} / {1} · {2} | 裝置 {0} / {1} · {2} | 裝置 {0} / {1} · {2} | Device {0} of {1} · {2} | デバイス {0}/{1} · {2} | ✅ 完全一致 | 保留 |
| SetupDriverApple | 正在准备设备支持，必要时尝试启动服务…… | 正在準備裝置支援，必要時嘗試啟動服務…… | 正在準備裝置支援，必要時嘗試啟動服務…… | Preparing device support and starting its service if needed… | デバイスサポートを準備し、必要ならサービスを開始しています… | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverAppleFailed | 设备支持准备失败，请检查网络、权限和详细信息。 | 裝置支援準備失敗，請檢查網絡、權限和詳細資訊。 | 裝置支援準備失敗，請檢查網路、權限和詳細資訊。 | Device support preparation failed. Check the network, permissions and details. | デバイスサポートの準備に失敗しました。ネットワーク、権限、詳細を確認してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverBusy | 上一项安装仍在安全退出，请稍后重试。 | 上一項安裝仍在安全結束，請稍後重試。 | 上一項安裝仍在安全結束，請稍後重試。 | The previous installation is still finishing safely. Try again shortly. | 前回のインストールが安全に終了処理中です。しばらくしてからもう一度お試しください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverCancelled | 安装已取消，请重新检测后再尝试。 | 安裝已取消，請重新偵測後再嘗試。 | 安裝已取消，請重新偵測後再嘗試。 | Installation was cancelled. Check again before retrying. | インストールをキャンセルしました。再試行する前に、もう一度確認してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverChecking | 正在检查设备支持和 USB 组件…… | 正在檢查裝置支援和 USB 元件…… | 正在檢查裝置支援和 USB 元件…… | Checking device support and USB components… | デバイスサポートとUSBコンポーネントを確認しています… | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverDisconnected | 未找到原设备，请重新连接。 | 找不到原裝置，請重新連接。 | 找不到原裝置，請重新連接。 | The original device wasn't found. Reconnect it. | 元のデバイスが見つかりませんでした。再接続してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverDriverFailed | 连接组件安装失败，请查看详细信息后重试。 | 連線元件安裝失敗，請檢視詳細資訊後重試。 | 連線元件安裝失敗，請檢視詳細資訊後重試。 | Connection component installation failed. Review the details and retry. | 接続コンポーネントのインストールに失敗しました。詳細を確認して、再試行してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverFailed | 无法取得安装结果，请重新检测。 | 無法取得安裝結果，請重新偵測。 | 無法取得安裝結果，請重新偵測。 | Couldn't read the installation result. Check again. | インストール結果を読み取れませんでした。もう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupDriverReDetection | 正在重新扫描设备…… | 正在重新掃描裝置…… | 正在重新掃描裝置…… | Scanning the device again… | デバイスをもう一度スキャンしています… | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverReplug | 请拔下并重新连接这台设备，再继续重新检测。 | 請拔除並重新連接這台裝置，再繼續重新偵測。 | 請拔除並重新連接這台裝置，再繼續重新偵測。 | Unplug and reconnect this device, then continue to check again. | このデバイスを抜いて挿し直し、続けてもう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupDriverRestart | Windows 需要重新启动，请重启后继续。 | Windows 需要重新啟動，請重新啟動後繼續。 | Windows 需要重新啟動，請重新啟動後繼續。 | Windows needs to restart. Continue after restarting. | Windowsの再起動が必要です。再起動してから続けてください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverResult | 环境检查已返回，下一步验证设备通信。 | 環境檢查已傳回，下一步驗證裝置通訊。 | 環境檢查已傳回，下一步驗證裝置通訊。 | Environment check returned. Next, verify device communication. | 環境の確認が終わりました。次に、デバイスとの通信を確認します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupDriverUsb | 正在安装 / 修复 USB 连接组件…… | 正在安裝 / 修復 USB 連線元件…… | 正在安裝 / 修復 USB 連線元件…… | Installing / repairing USB components… | USBコンポーネントをインストール / 修復しています… | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupExitHint | 进度会保存，下次可以继续。安装会在安全节点停止。 | 進度會儲存，下次可以繼續。安裝會在安全節點停止。 | 進度會儲存，下次可以繼續。安裝會在安全節點停止。 | Progress will be saved. Installation will stop at a safe boundary. | 進行状況は保存されます。インストールは安全な区切りで停止します。 | ✅ 完全一致 | 保留 |
| SetupExitSave | 退出，稍后继续 | 離開，稍後繼續 | 離開，稍後繼續 | Save and leave | 保存して終了 | ✅ 完全一致 | 保留 |
| SetupExitTitle | 要退出首次设置吗？ | 要離開首次設定嗎？ | 要離開首次設定嗎？ | Leave setup? | セットアップを終了しますか? | ✅ 完全一致 | 保留 |
| SetupFailed | 暂时无法完成此步骤，请查看解决方法或重新尝试。 | 暫時無法完成此步驟，請檢視解決方法或重試。 | 暫時無法完成此步驟，請檢視解決方法或重試。 | This step couldn't be completed. Review the guidance or try again. | この手順を完了できませんでした。ガイドを確認するか、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| SetupHelpBluetooth | 开启两端蓝牙，电脑需支持蓝牙外设模式。从设备上配对，并在辅助功能中开启辅助触控。 | 開啟兩端藍牙，電腦需支援藍牙周邊模式。從裝置上配對，並在輔助功能中開啟輔助觸控。 | 開啟兩端藍牙，電腦需支援藍牙周邊模式。從裝置上配對，並在輔助使用中開啟輔助觸控。 | Enable Bluetooth on both devices. The computer needs peripheral support. Pair from your device and enable AssistiveTouch in Accessibility. | 両方のデバイスでBluetoothを有効にしてください。コンピュータがペリフェラルに対応している必要があります。デバイス側からペアリングして、アクセシビリティでAssistiveTouchを有効にしてください。 | ✅ 完全一致 | 保留 |
| SetupHelpControl | 解锁并信任电脑，按提示开启开发者模式，必要时重启设备。无线控制还需要同一 Wi-Fi。详细信息会显示权限和设备支持问题。 | 解鎖並信任電腦，依提示開啟開發者模式，必要時重新啟動裝置。無線控制也需要同一個 Wi-Fi。詳細資訊會顯示權限和裝置支援問題。 | 解鎖並信任電腦，依提示開啟開發者模式，必要時重新啟動裝置。無線控制也需要同一個 Wi-Fi。詳細資訊會顯示權限和裝置支援問題。 | Unlock, trust the computer and enable Developer Mode when prompted. Restart if needed. Wireless control also needs the same Wi-Fi. Details show permission and device support issues. | ロックを解除し、コンピュータを信頼して、求められたらデベロッパモードを有効にしてください。必要なら再起動します。無線操作には、同じWi-Fiも必要です。詳細に、権限とデバイスサポートの問題が表示されます。 | ✅ 完全一致 | 保留 |
| SetupHelpDevice | 解锁并信任电脑。尝试支持数据传输的 USB 线或其他 USB 接口，然后重新检测。 | 解鎖並信任電腦。嘗試支援資料傳輸的 USB 線或其他 USB 連接埠，再重新偵測。 | 解鎖並信任電腦。嘗試支援資料傳輸的 USB 線或其他 USB 連接埠，再重新偵測。 | Unlock and trust the computer. Try a USB data cable or another USB port, then check again. | ロックを解除して、このコンピュータを信頼してください。USBデータケーブルまたは別のUSBポートを試してから、もう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupHelpDriver | 权限被拒绝时允许 Windows 提权；下载失败时检查网络；要求重启时先重启。重新插拔设备后再检测。 | 權限遭拒時允許 Windows 提升權限；下載失敗時檢查網絡；要求重新啟動時先重新啟動。重新插拔裝置後再偵測。 | 權限遭拒時允許 Windows 提升權限；下載失敗時檢查網路；要求重新啟動時先重新啟動。重新插拔裝置後再偵測。 | Allow Windows elevation if denied; check the network after download errors; restart if requested. Reconnect the device and check again. | Windowsの昇格が拒否された場合は許可してください。ダウンロードエラーのときはネットワークを確認し、求められたら再起動してください。デバイスを再接続して、もう一度確認してください。 | ✅ 完全一致 | 保留 |
| SetupHelpWireless | 使用同一 Wi-Fi，避免访客网络隔离。在设备控制中心 → 屏幕镜像中选择这台电脑。检查防火墙是否允许本应用访问本地网络。 | 使用同一個 Wi-Fi，避免訪客網絡隔離。在裝置控制中心 → 螢幕鏡像輸出中選擇這台電腦。檢查防火牆是否允許本應用程式存取區域網絡。 | 使用同一個 Wi-Fi，避免訪客網路隔離。在裝置控制中心 → 螢幕鏡像輸出中選擇這台電腦。檢查防火牆是否允許本應用程式存取區域網路。 | Use the same Wi-Fi without guest isolation. In Control Center → Screen Mirroring, select this computer. Allow the app through the firewall on your local network. | ゲスト分離のない同じWi-Fiを使ってください。コントロールセンター → 画面ミラーリングで、このコンピュータを選択します。ローカルネットワークでアプリがファイアウォールを通過することを許可してください。 | ✅ 完全一致 | 保留 |
| SetupHintAppearance | 跟随系统，或选一个你喜欢的配色。 | 跟隨系統，或選一個你喜歡的配色。 | 跟隨系統，或選一個你喜歡的配色。 | Follow your system, or pick a light or dark appearance. | システムに合わせるか、ライトまたはダークを選んでください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintApplicationMode | 从轻量模式开始，也可以选择完整界面或托盘。 | 從輕量模式開始，也可以選擇完整介面或系統匣。 | 從輕量模式開始，也可以選擇完整介面或系統匣。 | Start with lightweight mode, or choose the full interface or tray. | コンパクト表示から始めるか、標準表示またはトレイ表示を選んでください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintBluetooth | 开启蓝牙和辅助触控，配对电脑后选择设备，保存绑定。 | 開啟藍牙和輔助觸控，配對電腦後選擇裝置，儲存綁定。 | 開啟藍牙與輔助觸控，配對電腦後選擇裝置，儲存綁定。 | Enable Bluetooth and AssistiveTouch, pair with this computer, then select the device to save. | BluetoothとAssistiveTouchを有効にして、このコンピュータとペアリングし、保存するデバイスを選択してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintBluetoothIntroduction | 一种独立的控制方式，也可以稍后再配置。 | 另一種獨立的控制方式，也可以稍後再設定。 | 另一種獨立的控制方式，也可以稍後再設定。 | An independent control option that you can set up later. | 独立した操作方法で、あとで設定できます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintCompleted | 现在可以开始使用 iPhone Mirror。 | 現在可以開始使用 iPhone Mirror。 | 現在可以開始使用 iPhone Mirror。 | You can now start using iPhone Mirror. | iPhone Mirrorを使い始められます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintConnection | 用 USB 数据线连接设备。清单会自动更新，可继续连接更多设备。 | 用 USB 數據線連接裝置。清單會自動更新，可繼續連接更多裝置。 | 用 USB 傳輸線連接裝置。清單會自動更新，可繼續連接更多裝置。 | Connect by USB. The list updates as you connect or disconnect devices. | USBで接続してください。デバイスの接続や取り外しに合わせて、一覧が更新されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintControlIntroduction | 先建立设备绑定；无线和蓝牙都可以稍后配置。 | 先建立裝置綁定；無線和藍牙都可以稍後設定。 | 先建立裝置綁定；無線和藍牙都可以稍後設定。 | Save your device bindings first. Wireless and Bluetooth are optional. | まずデバイスの紐づけを保存します。無線とBluetoothは任意です。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintControlReadiness | 确认此设备的控制前置设置。 | 確認此裝置的控制前置設定。 | 確認此裝置的控制前置設定。 | Verify the prerequisites for controlling this device. | このデバイスを操作するための前提条件を確認します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintDeviceComplete | 下面显示已配置和已跳过的功能，继续配置下一台设备。 | 以下顯示已設定和已略過的功能，繼續設定下一台裝置。 | 以下顯示已設定和已略過的功能，繼續設定下一台裝置。 | Review configured and skipped features, then continue to the next device. | 設定した機能とスキップした機能を確認して、次のデバイスに進んでください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintDevices | 按照检测到的顺序，逐台完成配置。 | 依照偵測到的順序，逐一完成設定。 | 依照偵測到的順序，逐一完成設定。 | We'll set up devices in the order they were detected. | 検出された順に、デバイスをセットアップします。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintDisplay | 保留当前预设，或逐项调整画质和流畅度。 | 保留目前預設，或逐項調整畫質和流暢度。 | 保留目前預設，或逐項調整畫質與流暢度。 | Keep your presets, or adjust quality and smoothness. | プリセットのままにするか、画質と滑らかさを調整してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintEnvironment | 检查必要组件，正常的组件不会重复安装。 | 檢查必要元件，正常的元件不會重複安裝。 | 檢查必要元件，正常的元件不會重複安裝。 | Checking required components. Healthy components won't be reinstalled. | 必要なコンポーネントを確認しています。問題のないコンポーネントは再インストールされません。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintMirrorConnection | 无线无需数据线；有线会自动检查并准备驱动。 | 無線不需要數據線；有線會自動檢查並準備驅動程式。 | 無線不需要傳輸線；有線會自動檢查並準備驅動程式。 | Wireless needs no cable. Wired setup checks the required drivers. | 無線ならケーブルは不要です。有線のセットアップでは、必要なドライバーを確認します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintPartial | 有些步骤尚未配置，可以随时从设置重新打开向导。 | 部分步驟尚未設定，可隨時從設定重新開啟精靈。 | 部分步驟尚未設定，可隨時從設定重新開啟精靈。 | Some steps are not configured. Reopen the wizard in settings at any time. | 一部の手順が未設定です。設定から、いつでもアシスタントを開き直せます。 | ✅ 完全一致 | 保留 |
| SetupHintPreferences | 选择你熟悉的语言，立即应用到向导。 | 選擇你熟悉的語言，立即套用到助手。 | 選擇你熟悉的語言，立即套用到助手。 | Pick a familiar language. The wizard updates immediately. | 使い慣れた言語を選んでください。アシスタントにすぐ反映されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintProfile | 使用读取到的设备身份保存有线绑定。 | 使用讀取到的裝置身份儲存有線綁定。 | 使用讀取到的裝置身分儲存有線綁定。 | Save the wired binding using the device identity. | デバイスの識別情報を使って、有線の紐づけを保存します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintReDetection | 读取这台设备的 UDID。必要时请解锁并点击“信任”。 | 讀取這部裝置的 UDID。需要時請解鎖並點按「信任」。 | 讀取這台裝置的 UDID。必要時請解鎖並點選「信任」。 | Read this device’s UDID. Unlock it and tap Trust if prompted. | このデバイスのUDIDを読み取ります。求められたら、ロックを解除して「信頼」をタップしてください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintUsage | 选择最适合你的使用方式。 | 選擇最適合你的使用方式。 | 選擇最適合你的使用方式。 | Choose the experience that suits you. | 合う使い方を選んでください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintValidation | 确认设备身份和偏好已保存，跳过的功能可在以后添加。 | 確認裝置身份和偏好已儲存，略過的功能可在日後新增。 | 確認裝置身分與偏好已儲存，略過的功能可在之後新增。 | Check that identities and preferences are saved. Add skipped options later. | 識別情報と設定が保存されていることを確認してください。スキップした項目は、あとで追加できます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWelcome | 让你的 iPhone，与电脑一起工作。 | 讓你的 iPhone，與電腦一起工作。 | 讓你的 iPhone，與電腦一起工作。 | Bring your iPhone and computer together. | iPhoneとコンピュータをつなぎましょう。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWiredControl | 准备控制服务，需要操作时会在这里提示。 | 準備控制服務，需要操作時會在這裡提示。 | 準備控制服務，需要操作時會在這裡提示。 | Prepare control services. Any steps you need to take will appear here. | 操作サービスを準備します。必要な手順があれば、ここに表示されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWiredDecoder | 推荐自动选择。只有遇到画面问题时才需要改动。 | 建議自動選擇。只有遇到畫面問題時才需要調整。 | 建議自動選擇。只有遇到畫面問題時才需要調整。 | Automatic is recommended. Change this if you have video issues. | 自動をおすすめします。映像に問題があるときは変更してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWiredDisplay | 设置这台设备在电脑上的显示分辨率。 | 設定這部裝置在電腦上的顯示解像度。 | 設定這台裝置在電腦上的顯示解析度。 | Set this device’s display resolution on your computer. | コンピュータで表示するこのデバイスの解像度を設定します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWiredFrameRate | 帧率越高，画面越流畅，也需要更多电脑资源。 | 幀率越高，畫面越流暢，也需要更多電腦資源。 | 影格率越高，畫面越流暢，也需要更多電腦資源。 | Higher frame rates look smoother and use more computer resources. | フレームレートが高いほど滑らかに見えますが、コンピュータの負荷も増えます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWireless | 连接同一 Wi-Fi，在 iPhone 控制中心打开屏幕镜像，选择这台电脑。投屏后保存设备地址。 | 連接同一 Wi-Fi，在 iPhone 控制中心開啟螢幕鏡像，選擇這部電腦。鏡像輸出後儲存裝置地址。 | 連接同一 Wi-Fi，在 iPhone 控制中心開啟螢幕鏡像輸出，選擇這台電腦。鏡像輸出後儲存裝置位址。 | On the same Wi-Fi, open Screen Mirroring on your iPhone and select this computer. Its address will be saved. | 同じWi-Fiで、iPhoneの画面ミラーリングを開き、このコンピュータを選択してください。アドレスが保存されます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWirelessBackend | 沿用当前选项即可；不同方式的兼容性可能不同。 | 沿用目前選項即可；不同方式的兼容性可能不同。 | 沿用目前選項即可；不同方式的相容性可能不同。 | Keep the current option unless you need a different receiver. | 別のレシーバーが必要でなければ、現在の選択のままにしてください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWirelessControl | 验证无线控制服务，首次准备时请保留数据线连接。 | 驗證無線控制服務，首次準備時請保留傳輸線連線。 | 驗證無線控制服務，首次準備時請保留傳輸線連線。 | Verify wireless control. Keep the cable connected during initial preparation. | 無線操作を検証します。最初の準備の間は、ケーブルを接続したままにしてください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWirelessDisplay | 更高的画质需要更稳定的网络。 | 更高的畫質需要更穩定的網絡。 | 更高的畫質需要更穩定的網路。 | Higher quality needs a more stable network. | 画質を上げるには、より安定したネットワークが必要です。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupHintWirelessIntroduction | 摆脱数据线，可在后续步骤中选择配置或跳过。 | 擺脫數據線，可在後續步驟中選擇設定或略過。 | 擺脫傳輸線，可在後續步驟中選擇設定或略過。 | Go cable-free. You can set this up or skip it later. | ケーブルなしで使えます。あとで設定することも、スキップすることもできます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupInstall | 开始安装 / 修复 | 開始安裝 / 修復 | 開始安裝 / 修復 | Install / repair | インストール / 修復 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupInstallConsent | 需要准备 USB 连接环境。点击开始安装后，将依次检查设备支持和连接组件。Windows 可能请求管理员权限。 | 需要準備 USB 連線環境。點選開始安裝後，會依序檢查裝置支援和連線元件。Windows 可能要求管理員權限。 | 需要準備 USB 連線環境。點選開始安裝後，會依序檢查裝置支援和連線元件。Windows 可能要求管理員權限。 | USB support needs preparation. Install will check device support, then connection components. Windows may ask for administrator permission. | USBサポートの準備が必要です。インストールでは、デバイスサポート、続いて接続コンポーネントを確認します。Windowsから管理者権限を求められることがあります。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupKeepSettings | 沿用当前配置 | 沿用目前設定 | 沿用目前設定 | Keep current settings | 現在の設定を維持 | ✅ 完全一致 | 保留 |
| SetupKeepSettingsHint | 直接继续，使用当前投屏预设。 | 直接繼續，使用目前的鏡像輸出預設。 | 直接繼續，使用目前的鏡像輸出預設。 | Continue with your current mirroring presets. | 現在のミラーリングのプリセットのまま続けます。 | ✅ 完全一致 | 保留 |
| SetupLaterMain | 进入主界面 | 進入主畫面 | 進入主畫面 | Go to the main window | メインウィンドウへ | ✅ 完全一致 | 保留 |
| SetupMirrorOnly | 仅投屏 | 僅鏡像輸出 | 僅鏡像輸出 | Mirror only | ミラーリングのみ | ✅ 完全一致 | 保留 |
| SetupMirrorOnlyHint | 把 iPhone 画面显示到电脑，下一步选择连接方式。 | 將 iPhone 畫面顯示到電腦，下一步選擇連線方式。 | 將 iPhone 畫面顯示到電腦，下一步選擇連線方式。 | Show your iPhone on your computer. Choose how to connect next. | iPhoneをコンピュータに表示します。次に、接続方法を選びます。 | ✅ 完全一致 | 保留 |
| SetupModeComplete | 显示全部功能和高级设置 | 顯示全部功能和進階設定 | 顯示全部功能和進階設定 | All features and advanced settings | すべての機能と詳細設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupModeHint | 精简模式保留常用功能；完整模式显示全部设置；托盘模式主要在通知区域运行。 | 精簡模式保留常用功能；完整模式顯示全部設定；系統匣模式主要在通知區域執行。 | 精簡模式保留常用功能；完整模式顯示全部設定；系統匣模式主要在通知區域執行。 | Lightweight mode shows everyday controls. Complete mode includes all settings. Tray mode runs in the notification area. | コンパクト表示では、よく使う操作を表示します。標準表示では、すべての設定を含みます。トレイ表示では、通知領域で動作します。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupModeLightweight | 保留常用功能，推荐首次使用 | 保留常用功能，建議首次使用 | 保留常用功能，建議首次使用 | Everyday controls, recommended for getting started | よく使う操作。始めるときにおすすめ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupModeTray | 在系统托盘运行，需要时再打开 | 在系統匣執行，需要時再開啟 | 在系統匣執行，需要時再開啟 | Run in the system tray and open the window when needed | システムトレイで動作し、必要なときにウィンドウを開く | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupNoDeviceConfigured | 本次未配置设备，可进入主界面后再连接。 | 本次未設定裝置，可進入主畫面後再連接。 | 本次未設定裝置，可進入主畫面後再連接。 | No device was configured. You can connect one from the main window later. | 設定したデバイスはありません。あとでメインウィンドウから接続できます。 | ✅ 完全一致 | 保留 |
| SetupPageFormat | {0} / {1} | {0} / {1} | {0} / {1} | {0} / {1} | {0} / {1} | ✅ 完全一致 | 保留 |
| SetupReceiverDownloadHint | 选择 UxPlay 并点击“下一步”后，如缺少组件，会在这里下载并安装。 | 選擇 UxPlay 並點選「下一步」後，如缺少組件，會在此下載並安裝。 | 選擇 UxPlay 並點選「下一步」後，若缺少元件，會在此下載並安裝。 | Select UxPlay and click Next to download and install any missing components here. | UxPlayを選択して「次へ」をクリックすると、不足しているコンポーネントをここでダウンロードしてインストールします。 | ✅ 完全一致 | 保留 |
| SetupRecommended | 沿用当前预设。新安装默认使用无线 1080p · 60 FPS，有线自动选择解码器。高级选项可在下方调整。 | 沿用目前預設。新安裝預設使用無線 1080p · 60 FPS，有線自動選擇解碼器。進階選項可在下方調整。 | 沿用目前預設。新安裝預設使用無線 1080p · 60 FPS，有線自動選擇解碼器。進階選項可在下方調整。 | Your current presets are used. New installations default to wireless 1080p at 60 FPS and automatic wired decoding. Adjust advanced options below. | 現在のプリセットを使用します。新規インストールの既定は、無線1080p・60 FPS、有線は自動デコードです。詳細なオプションは下で調整できます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupReopen | 首次使用助手 · 重新配置 | 首次使用助手 · 重新設定 | 首次使用助手 · 重新設定 | First run setup · Run again | 初回セットアップ · もう一度実行 | ✅ 完全一致 | 保留 |
| SetupRetry | 重新检测 | 重新偵測 | 重新偵測 | Check again | もう一度確認 | ✅ 完全一致 | 保留 |
| SetupSaveFailed | 无法保存，请检查磁盘空间和文件权限后重试。 | 無法儲存，請檢查磁碟空間和檔案權限後重試。 | 無法儲存，請檢查磁碟空間和檔案權限後重試。 | Couldn't save. Check disk space and file permissions, then retry. | 保存できませんでした。ディスクの空き容量とファイルのアクセス許可を確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| SetupScanAgain | 重新扫描 | 重新掃描 | 重新掃描 | Scan again | もう一度スキャン | ✅ 完全一致 | 保留 |
| SetupScanning | 正在持续查找设备，全部连接后点击下一步。 | 正在持續搜尋裝置，全部連接後按下一步。 | 正在持續尋找裝置，全部連接後按下一步。 | Looking for devices. Connect them all, then select Next. | デバイスを探しています。すべて接続してから「次へ」を選択してください。 | ✅ 完全一致 | 保留 |
| SetupSkip | 跳过此项 | 略過此項 | 略過此項 | Skip this step | この手順をスキップ | ✅ 完全一致 | 保留 |
| SetupSkipHintBluetooth | 如果只使用有线控制，可以跳过。以后可从设置补充蓝牙配对。 | 如果只使用有線控制，可以略過。日後可從設定補做藍牙配對。 | 如果只使用有線控制，可以略過。日後可從設定補做藍牙配對。 | Skip this if you only need wired control. Add Bluetooth pairing later in Settings. | 有線操作だけで足りる場合は、スキップしてください。Bluetoothのペアリングは、あとで設定から追加できます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupSkipHintWireless | 跳过后仍可使用有线投屏，以后可以从设置重新打开助手。 | 略過後仍可使用有線鏡像輸出，日後可以從設定重新開啟助手。 | 略過後仍可使用有線鏡像輸出，日後可以從設定重新開啟助手。 | You can still mirror with a cable. Return to this assistant in Settings to add wireless mirroring later. | ケーブルでのミラーリングは引き続き使えます。無線ミラーリングは、あとで設定からこのアシスタントに戻って追加できます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupSkipHintWirelessBackend | 可以跳过无线绑定，继续配置蓝牙。 | 可以略過無線綁定，繼續設定藍牙。 | 可以略過無線綁定，繼續設定藍牙。 | Skip wireless binding and continue to Bluetooth. | 無線の紐づけをスキップして、Bluetoothに進みます。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupSkipHintWirelessControl | 可以只使用有线控制。需要无线操作时，再从设置重新配置。 | 可以只使用有線控制。需要無線操作時，再從設定重新設定。 | 可以只使用有線控制。需要無線操作時，再從設定重新設定。 | Wired control works on its own. Return to Settings when you want wireless control. | 有線操作は単独で使えます。無線操作が必要になったら、設定に戻ってください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupSkipped | 已跳过 | 已略過 | 已略過 | Skipped | スキップしました | ✅ 完全一致 | 保留 |
| SetupSkippedSummary | 已跳过的项目尚未完成，可在设置中继续配置。 | 略過的項目尚未完成，可在設定中繼續設定。 | 略過的項目尚未完成，可在設定中繼續設定。 | Skipped items are unfinished. Continue configuring them in settings. | スキップした項目は未完了です。設定から続けて設定してください。 | ✅ 完全一致 | 保留 |
| SetupSolutions | 查看解决方法 | 檢視解決方法 | 檢視解決方法 | How to resolve this | 解決方法 | ✅ 完全一致 | 保留 |
| SetupStageBasics | 基础设置 | 基本設定 | 基本設定 | Basic settings | 基本設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStageDevices | 设备连接 | 裝置連線 | 裝置連線 | Device connection | デバイスの接続 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStageExperience | 投屏体验 | 投影體驗 | 投影體驗 | Mirroring experience | ミラーリングの使い心地 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStartMirror | 开始投屏 → | 開始鏡像輸出 → | 開始鏡像輸出 → | Start mirroring → | ミラーリングを開始 → | ✅ 完全一致 | 保留 |
| SetupStateCompleted | 已完成 | 已完成 | 已完成 | Complete | 完了 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStateIncomplete | 尚未配置 | 尚未設定 | 尚未設定 | Not configured | 未設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStateInvalid | 配置异常 | 設定異常 | 設定異常 | Needs repair | 修復が必要 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStateNotRequired | 无需配置 | 無需設定 | 無需設定 | Not required | 不要 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStateUnknown | 待确认 | 待確認 | 待確認 | Needs verification | 確認が必要 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupStopSessions | 请先停止正在进行的投屏和控制，再运行首次使用助手。 | 請先停止正在進行的鏡像輸出和控制，再執行首次使用助手。 | 請先停止正在進行的鏡像輸出和控制，再執行首次使用助手。 | Stop active mirroring and control before running setup. | セットアップを実行する前に、実行中のミラーリングと操作を停止してください。 | ✅ 完全一致 | 保留 |
| SetupSystemLanguage | 跟随系统语言 | 跟隨系統語言 | 跟隨系統語言 | Use system language | システムの言語を使う | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupThemeDark | 深色 | 深色 | 深色 | Dark | ダーク | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupThemeLight | 浅色 | 淺色 | 淺色 | Light | ライト | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupThemeSystem | 跟随系统 | 跟隨系統 | 跟隨系統 | Use system appearance | システムの外観に従う | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTimeout | 检测已超时，请检查连接后重试。 | 偵測已逾時，請檢查連線後重試。 | 偵測已逾時，請檢查連線後重試。 | The check timed out. Check the connection and retry. | 確認がタイムアウトしました。接続を確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| SetupTitle | 首次使用助手 | 首次使用助手 | 首次使用助手 | First run setup | 初回セットアップ | ✅ 完全一致 | 保留 |
| SetupTitleAppearance | 选择喜欢的外观 | 選擇喜歡的外觀 | 選擇喜歡的外觀 | Choose your appearance | 外観を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleApplicationMode | 选择应用模式 | 選擇應用程式模式 | 選擇應用程式模式 | Choose your app mode | アプリの表示モードを選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleBluetooth | 保存蓝牙绑定 | 儲存藍牙綁定 | 儲存藍牙綁定 | Save Bluetooth binding | Bluetoothの紐づけを保存 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleBluetoothIntroduction | 了解蓝牙控制 | 了解藍牙控制 | 認識藍牙控制 | Explore Bluetooth control | Bluetooth操作を試す | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleCompleted | 设置完成 | 設定完成 | 設定完成 | You're ready | 準備ができました | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleConnection | 连接你的 iPhone / iPad | 連接你的 iPhone / iPad | 連接你的 iPhone / iPad | Connect your iPhone or iPad | iPhoneまたはiPadを接続 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleControlIntroduction | 了解三种控制方式 | 了解三種控制方式 | 認識三種控制方式 | Three ways to control | 3つの操作方法 | ✅ 完全一致 | 保留 |
| SetupTitleControlReadiness | 设备控制设置 | 裝置控制設定 | 裝置控制設定 | Device control setup | デバイス操作のセットアップ | ✅ 完全一致 | 保留 |
| SetupTitleDeviceComplete | 这台设备配置完成 | 這台裝置設定完成 | 這台裝置設定完成 | This device is set up | このデバイスのセットアップが完了しました | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleDevices | 发现设备 | 找到裝置 | 找到裝置 | Devices found | 見つかったデバイス | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleDisplay | 优化投屏体验 | 最佳化鏡像輸出體驗 | 最佳化鏡像輸出體驗 | Tune your mirroring experience | ミラーリングの使い心地を調整 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleEnvironment | 准备电脑环境 | 準備電腦環境 | 準備電腦環境 | Prepare your computer | コンピュータを準備 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleMirrorConnection | 你想怎样连接？ | 你想如何連線？ | 你想如何連線？ | How would you like to connect? | どのように接続しますか? | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitlePartial | 向导已结束 | 精靈已結束 | 精靈已結束 | Wizard finished | アシスタントを終了しました | ✅ 完全一致 | 保留 |
| SetupTitlePreferences | 选择界面语言 | 選擇介面語言 | 選擇介面語言 | Choose your language | 言語を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleProfile | 保存有线绑定 | 儲存有線綁定 | 儲存有線綁定 | Save wired binding | 有線の紐づけを保存 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleReDetection | 读取设备身份 | 讀取裝置身份 | 讀取裝置身分 | Read device identity | デバイスの識別情報を読み取る | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleUsage | 你准备怎么使用？ | 你打算怎麼使用？ | 你打算怎麼使用？ | How will you use it? | どのように使いますか? | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleValidation | 保存并整理设置 | 儲存並整理設定 | 儲存並整理設定 | Save your setup | セットアップを保存 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWelcome | 欢迎使用 iPhone Mirror | 歡迎使用 iPhone Mirror | 歡迎使用 iPhone Mirror | Welcome to iPhone Mirror | iPhone Mirrorへようこそ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWiredControl | 设置有线控制 | 設定有線控制 | 設定有線控制 | Set up wired control | 有線操作を設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWiredDecoder | 选择画面处理方式 | 選擇畫面處理方式 | 選擇畫面處理方式 | Choose video processing | 映像処理を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWiredDisplay | 选择有线画质 | 選擇有線畫質 | 選擇有線畫質 | Choose wired quality | 有線の画質を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWiredFrameRate | 选择画面流畅度 | 選擇畫面流暢度 | 選擇畫面流暢度 | Choose smoothness | 滑らかさを選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWireless | 记录无线设备 | 記錄無線裝置 | 記錄無線裝置 | Save wireless device | 無線デバイスを保存 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWirelessBackend | 选择无线接收方式 | 選擇無線接收方式 | 選擇無線接收方式 | Choose a wireless receiver | 無線レシーバーを選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWirelessControl | 设置无线控制 | 設定無線控制 | 設定無線控制 | Set up wireless control | 無線操作を設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWirelessDisplay | 选择无线画质 | 選擇無線畫質 | 選擇無線畫質 | Choose wireless quality | 無線の画質を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupTitleWirelessIntroduction | 了解无线控制 | 了解無線控制 | 認識無線控制 | Explore wireless control | 無線操作を試す | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupToolsBindingHint | 在独立窗口中管理有线、AirPlay 和蓝牙身份。 | 在獨立視窗中管理有線、AirPlay 和藍牙識別。 | 在獨立視窗中管理有線、AirPlay 和藍牙識別。 | Manage USB, AirPlay and Bluetooth identities in a dedicated window. | USB、AirPlay、Bluetoothの識別情報を専用のウィンドウで管理します。 | ✅ 完全一致 | 保留 |
| SetupToolsBindingWaiting | 请在设备绑定器中选择设备并完成绑定。 | 請在裝置綁定器中選擇裝置並完成綁定。 | 請在裝置綁定器中選擇裝置並完成綁定。 | Select your device and complete the binding in Device Binder. | デバイス紐づけツールで、デバイスを選択して紐づけを完了してください。 | ✅ 完全一致 | 保留 |
| SetupToolsBluetoothStarting | 正在准备蓝牙连接… | 正在準備藍牙連線… | 正在準備藍牙連線… | Preparing Bluetooth… | Bluetoothを準備しています… | ✅ 完全一致 | 保留 |
| SetupToolsChecking | 正在检查实际配置… | 正在檢查實際設定… | 正在檢查實際設定… | Checking the saved configuration… | 保存済みの構成を確認しています… | ✅ 完全一致 | 保留 |
| SetupToolsCombinedBindingHint | 在设备绑定器中统一管理 USB、AirPlay 和蓝牙绑定，无线和蓝牙可稍后添加。 | 在裝置綁定器中統一管理 USB、AirPlay 和藍牙綁定，無線和藍牙可稍後新增。 | 在裝置綁定中統一管理 USB、AirPlay 和藍牙綁定，無線和藍牙可稍後新增。 | Manage USB, AirPlay and Bluetooth bindings together. Wireless and Bluetooth can be added later. | USB、AirPlay、Bluetoothの紐づけをまとめて管理します。無線とBluetoothは、あとから追加できます。 | ✅ 完全一致 | 保留 |
| SetupToolsDriverHint | 安装和修复 Apple 支持组件与 USB 驱动。 | 安裝和修復 Apple 支援元件與 USB 驅動程式。 | 安裝和修復 Apple 支援元件與 USB 驅動程式。 | Install or repair Apple support and USB drivers. | Appleのサポートとドライバーをインストールまたは修復します。 | ✅ 完全一致 | 保留 |
| SetupToolsDriverWaiting | 驱动管理器已打开，请在该窗口中操作。取消等待不会中断安装。 | 驅動管理器已開啟，請在該視窗中操作。取消等待不會中斷安裝。 | 驅動管理器已開啟，請在該視窗中操作。取消等待不會中斷安裝。 | Continue in Driver Manager. Cancelling this wait does not stop installation. | ドライバー管理で続けてください。この待機をキャンセルしても、インストールは止まりません。 | ✅ 完全一致 | 保留 |
| SetupToolsIncomplete | 此项尚未完成。可以重新打开对应工具，或稍后再设置。 | 此項尚未完成。可以重新開啟對應工具，或稍後再設定。 | 此項尚未完成。可以重新開啟對應工具，或稍後再設定。 | This step is still incomplete. Reopen the tool or continue later. | この手順はまだ完了していません。ツールを開き直すか、あとで続けてください。 | ✅ 完全一致 | 保留 |
| SetupToolsOpen | 打开独立窗口  ↗ | 開啟獨立視窗  ↗ | 開啟獨立視窗  ↗ | Open window  ↗ | ウィンドウを開く  ↗ | ✅ 完全一致 | 保留 |
| SetupToolsReceiverStarting | 正在准备 AirPlay 接收器… | 正在準備 AirPlay 接收器… | 正在準備 AirPlay 接收器… | Preparing the AirPlay receiver… | AirPlayレシーバーを準備しています… | ✅ 完全一致 | 保留 |
| SetupToolsReturnHint | 在对应窗口中完成操作。关闭后会自动检查结果，也可以稍后继续。 | 在對應視窗中完成操作。關閉後會自動檢查結果，也可以稍後繼續。 | 在對應視窗中完成操作。關閉後會自動檢查結果，也可以稍後繼續。 | Complete the task in its window. Closing it checks the result; you can also continue later. | 作業はそのウィンドウで完了してください。閉じると結果を確認します。あとで続けることもできます。 | ✅ 完全一致 | 保留 |
| SetupUsageHintMirrorAndControl | 不仅显示画面，还能使用鼠标和键盘操作设备。 | 不只顯示畫面，也能使用滑鼠和鍵盤操作裝置。 | 不只顯示畫面，也能使用滑鼠和鍵盤操作裝置。 | See your screen and use your computer's mouse and keyboard to operate the device. | 画面を見ながら、コンピュータのマウスとキーボードでデバイスを操作できます。 | ✅ 完全一致 | 保留 |
| SetupUsageHintWiredOnly | 使用 USB 数据线，更稳定、低延迟。适合游戏、录制、直播。 | 使用 USB 傳輸線，更穩定、低延遲。適合遊戲、錄影、直播。 | 使用 USB 傳輸線，更穩定、低延遲。適合遊戲、錄影、直播。 | Use a USB cable for stable, low-latency mirroring. Good for games, recording and streaming. | USBケーブルで、安定した低遅延のミラーリングができます。ゲーム、録画、配信に向いています。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupUsageHintWirelessOnly | 不用数据线。适合日常展示、观看视频。 | 不用傳輸線。適合日常展示、觀看影片。 | 不用傳輸線。適合日常展示、觀看影片。 | No cable needed. Good for presentations and videos. | ケーブルは不要です。プレゼンテーションや動画に向いています。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupUsageMirrorAndControl | 投屏 + 控屏 | 鏡像輸出 + 控制 | 鏡像輸出 + 控制 | Mirror + control | ミラーリング + 操作 | ✅ 完全一致 | 保留 |
| SetupUsageWiredOnly | 有线投屏 | 有線鏡像輸出 | 有線鏡像輸出 | Wired mirroring | 有線ミラーリング | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupUsageWirelessOnly | 无线投屏 | 無線鏡像輸出 | 無線鏡像輸出 | Wireless mirroring | 無線ミラーリング | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SetupVerified | ✓ 已完成此步骤 | ✓ 已完成此步驟 | ✓ 已完成此步驟 | ✓ Step completed | ✓ 手順が完了しました | ✅ 完全一致 | 保留 |
| SetupWelcomeNote | 选好使用方式，连接你的设备。<br>其余的设置，我们一步一步来。 | 選好使用方式，連接你的裝置。<br>其餘設定，我們一步一步來。 | 選好使用方式，連接你的裝置。<br>其餘設定，我們一步一步來。 | Choose how you want to use it and connect your device.<br>We’ll take the rest one step at a time. | 使い方を選んで、デバイスを接続しましょう。<br>残りは一歩ずつ進めていきます。 | ✅ 完全一致 | 保留 |
| SetupWirelessReconnectNote | 无线设置已更新。请在 iPhone 上重新选择屏幕镜像。 | 無線設定已更新。請在 iPhone 上重新選擇螢幕鏡像。 | 無線設定已更新。請在 iPhone 上重新選擇螢幕鏡像輸出。 | Wireless settings updated. Select Screen Mirroring again on your iPhone. | 無線の設定を更新しました。iPhoneで画面ミラーリングをもう一度選択してください。 | ✅ 完全一致 | 保留 |
| SetupWirelessVerified | ✓ 无线设备地址已保存 | ✓ 無線裝置地址已儲存 | ✓ 無線裝置位址已儲存 | ✓ Wireless device address saved | ✓ 無線デバイスのアドレスを保存しました | ✅ 完全一致 | 保留 |
| SetupWorking | 正在检查，请稍候…… | 正在檢查，請稍候…… | 正在檢查，請稍候…… | Checking, please wait… | 確認しています。しばらくお待ちください… | ✅ 完全一致 | 保留 |
| ShortcutKeyNumPadFormat | 数字小键盘 {0} | 數字小鍵盤 {0} | 數字小鍵盤 {0} | Num {0} | テンキー{0} | ✅ 完全一致 | 保留 |
| ShortcutModifierAlt | Alt | Alt | Alt | Alt | Alt | ✅ 完全一致 | 保留 |
| ShortcutModifierControl | Ctrl | Ctrl | Ctrl | Ctrl | Ctrl | ✅ 完全一致 | 保留 |
| ShortcutModifierShift | Shift | Shift | Shift | Shift | Shift | ✅ 完全一致 | 保留 |
| ShortcutMouseMiddle | 中键 | 中鍵 | 中鍵 | Middle mouse button | マウスの中ボタン | ✅ 完全一致 | 保留 |
| ShortcutMouseRight | 右键 | 右鍵 | 右鍵 | Right mouse button | マウスの右ボタン | ✅ 完全一致 | 保留 |
| ShortcutRegistrationFailedFormat | Windows 无法注册 {0}，该快捷键可能已被占用。 | Windows 無法註冊 {0}，該快捷鍵可能已被佔用。 | Windows 無法註冊 {0}，該快速鍵可能已被佔用。 | Windows could not register {0}; it may already be in use. | Windowsに{0}を登録できませんでした。すでに使われている可能性があります。 | ✅ 完全一致 | 保留 |
| ShortcutSettings | 快捷键设置 | 快捷鍵設定 | 快速鍵設定 | Keyboard shortcuts | キーボードショートカット | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsAllWindows | 显示所有应用窗口 | 顯示所有 App 視窗 | 顯示所有 App 視窗 | Show All App Windows | Appのすべてのウィンドウを表示 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsAppSwitcher | 打开多任务 | 開啟多工 | 開啟多工 | Open App Switcher | Appスイッチャーを開く | ✅ 完全一致 | 保留 |
| ShortcutSettingsBluetoothControl | 蓝牙控制 | 藍牙控制 | 藍牙控制 | Bluetooth control | Bluetooth操作 | ✅ 完全一致 | 保留 |
| ShortcutSettingsBossKey | 老板键（隐藏 / 显示窗口） | 老闆鍵（隱藏 / 顯示視窗） | 老闆鍵（隱藏 / 顯示視窗） | Boss key (hide / show windows) | ボスキー（ウィンドウの非表示/表示） | ✅ 完全一致 | 保留 |
| ShortcutSettingsBossKeyKeyboardOnly | 老板键只能使用键盘快捷键，以便隐藏窗口后仍可恢复。 | 老闆鍵只能使用鍵盤快捷鍵，以便隱藏視窗後仍可還原。 | 老闆鍵只能使用鍵盤快速鍵，以便隱藏視窗後仍可還原。 | Boss Key requires a keyboard shortcut so hidden windows can still be restored. | 非表示にしたウィンドウを復元できるよう、ボスキーにはキーボードのショートカットが必要です。 | ✅ 完全一致 | 保留 |
| ShortcutSettingsCaptureHint | 聚焦输入框后按下快捷键。Backspace 或 Delete 可解除绑定；F1-F11、右键、中键可单独使用。 | 聚焦輸入框後按下快捷鍵。按 Backspace 或 Delete 可解除繫結；F1-F11、右鍵、中鍵可單獨使用。 | 點選輸入框後按下快速鍵。按 Backspace 或 Delete 可解除綁定；F1-F11、右鍵、中鍵可單獨使用。 | Focus the field, then press a shortcut. Backspace or Delete unbinds it; F1-F11, right mouse, and middle mouse can be used alone. | 欄にフォーカスしてからショートカットを押します。BackspaceまたはDeleteで割り当てを解除できます。F1〜F11、マウスの右ボタン、中ボタンは単独で使えます。 | ✅ 完全一致 | 保留 |
| ShortcutSettingsCategoryAssistant | 助理 | 助理 | 助理 | Assistant | アシスタント | ✅ 完全一致 | 保留 |
| ShortcutSettingsCategoryControl | 控制 | 控制 | 控制 | Control | 操作 | ✅ 完全一致 | 保留 |
| ShortcutSettingsCategoryNavigation | 系统导航 | 系統導覽 | 系統導覽 | System navigation | システムナビゲーション | ✅ 完全一致 | 保留 |
| ShortcutSettingsControlCenter | 打开控制中心 | 開啟控制中心 | 開啟控制中心 | Open Control Center | コントロールセンターを開く | ✅ 完全一致 | 保留 |
| ShortcutSettingsDescription | 配置投屏工具的快捷键。 | 設定螢幕鏡像工具的快捷鍵。 | 設定螢幕鏡像工具的快速鍵。 | Configure shortcuts for mirroring tools. | ミラーリングツールのショートカットを設定します。 | ✅ 完全一致 | 保留 |
| ShortcutSettingsDock | 显示 Dock | 顯示 Dock | 顯示 Dock | Show Dock | Dockを表示 | ✅ 完全一致 | 保留 |
| ShortcutSettingsDuplicate | 每个动作必须使用不同的快捷键。 | 每個動作必須使用不同的快捷鍵。 | 每個動作必須使用不同的快速鍵。 | Each action must use a different shortcut. | 操作ごとに異なるショートカットを割り当ててください。 | ✅ 完全一致 | 保留 |
| ShortcutSettingsDuplicateBindingFormat | {0} 已用于“{1}”，请选择其他快捷键或先解除原绑定。 | {0} 已用於「{1}」，請選擇其他快捷鍵或先解除原綁定。 | {0} 已用於「{1}」，請選擇其他快速鍵或先解除原綁定。 | {0} is already assigned to {1}. Choose another shortcut or clear that binding first. | {0}はすでに{1}に割り当てられています。別のショートカットを選ぶか、先にその割り当てを解除してください。 | ✅ 完全一致 | 保留 |
| ShortcutSettingsFullScreen | 切换全屏 | 切換全螢幕 | 切換全螢幕 | Toggle Full Screen | 全画面の切り替え | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsHome | 回到桌面 | 返回主畫面 | 返回主畫面 | Go to Home Screen | ホーム画面に移動 | ✅ 完全一致 | 保留 |
| ShortcutSettingsInvalid | 请选择有效快捷键。F12、Windows 键组合及单独修饰键不可用。 | 請選擇有效快捷鍵。F12、Windows 鍵組合及單獨修飾鍵不可用。 | 請選擇有效快速鍵。F12、Windows 鍵組合及單獨修飾鍵不可用。 | Choose a valid shortcut. F12, Windows-key shortcuts, and modifier-only keys are unavailable. | 有効なショートカットを選んでください。F12、Windowsキーを使うショートカット、修飾キーだけの指定は使えません。 | ✅ 完全一致 | 保留 |
| ShortcutSettingsKeyboardShortcuts | 显示键盘快捷键 | 顯示鍵盤快速鍵 | 顯示鍵盤快速鍵 | Show Keyboard Shortcuts | キーボードショートカットを表示 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsLockScreen | 锁定屏幕 | 鎖定螢幕 | 鎖定螢幕 | Lock Screen | ロック画面 | ✅ 完全一致 | 保留 |
| ShortcutSettingsNextApp | 切换到下一个应用 | 切換至下一個 App | 切換至下一個 App | Switch to Next App | 次のAppに切り替える | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsNotificationCenter | 打开通知栏 | 開啟通知中心 | 開啟通知中心 | Open Notification Center | 通知センターを開く | ✅ 完全一致 | 保留 |
| ShortcutSettingsPreviousApp | 切换到上一个应用 | 切換至上一個 App | 切換至上一個 App | Switch to Previous App | 前のAppに切り替える | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsQuickNote | 新建快捷笔记 | 新增快速備忘錄 | 新增快速備忘錄 | New Quick Note | クイックメモを新規作成 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsReset | 恢复默认值 | 還原預設值 | 還原預設值 | Restore defaults | 初期設定に戻す | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| ShortcutSettingsReverseControl | 反向控制 | 反向控制 | 反向控制 | Reverse control | リモート操作 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsSaveFailed | 无法保存快捷键设置。 | 無法儲存快捷鍵設定。 | 無法儲存快速鍵設定。 | Could not save keyboard shortcut settings. | キーボードショートカットの設定を保存できませんでした。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| ShortcutSettingsSearch | 打开搜索 | 開啟搜尋 | 開啟搜尋 | Open Search | 検索を開く | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ShortcutSettingsSiri | 唤醒 Siri | 啟動 Siri | 啟動 Siri | Start Siri | Siriを起動 | ✅ 完全一致 | 保留 |
| ShortcutSettingsTitle | 快捷键设置 | 快捷鍵設定 | 快速鍵設定 | Keyboard shortcuts | キーボードショートカット | ✅ 完全一致 | 保留 |
| ShortcutSettingsUnbound | 未绑定 | 未繫結 | 未綁定 | Unbound | 未割り当て | ✅ 完全一致 | 保留 |
| ShortcutSettingsVolumeDown | 音量- | 音量- | 音量- | Volume down | 音量を下げる | ✅ 完全一致 | 保留 |
| ShortcutSettingsVolumeUp | 音量+ | 音量+ | 音量+ | Volume up | 音量を上げる | ✅ 完全一致 | 保留 |
| ShortcutSettingsWiredControl | 有线控制 | 有線控制 | 有線控制 | Wired control | 有線操作 | ❌ 含义不一致 → ✅ 已修复 | 菜单和快捷键实际调用控制功能，不是开始投屏 |
| ShortcutSettingsWirelessControl | 无线控制 | 無線控制 | 無線控制 | Wireless control | 無線操作 | ❌ 含义不一致 → ✅ 已修复 | 菜单和快捷键实际调用控制功能，不是开始投屏 |
| SimultaneousMirrorFailedFormat | 同时投屏启动失败：{0} | 同時螢幕鏡像啟動失敗：{0} | 同時螢幕鏡像啟動失敗：{0} | Could not start simultaneous mirroring: {0} | 同時ミラーリングを開始できませんでした: {0} | ✅ 完全一致 | 保留 |
| SimultaneousMirrorStartedFormat | 已为 {0} 打开同时投屏窗口 | 已為 {0} 開啟同時螢幕鏡像視窗 | 已為 {0} 開啟同時螢幕鏡像視窗 | Opened a simultaneous mirror window for {0} | {0}の同時ミラーリング用ウィンドウを開きました | ✅ 完全一致 | 保留 |
| StartBluetoothControl | 启用蓝牙控制 | 啟用藍牙控制 | 啟用藍牙控制 | Enable Bluetooth control | Bluetooth操作を有効にする | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为蓝牙控制 |
| StartFailedFormat | 开始投屏失败：{0} | 開始螢幕鏡像失敗：{0} | 開始螢幕鏡像失敗：{0} | Could not start mirroring: {0} | ミラーリングを開始できませんでした: {0} | ✅ 完全一致 | 保留 |
| StartMirroring | 开始投屏 | 開始螢幕鏡像 | 開始螢幕鏡像 | Start mirroring | ミラーリングを開始 | ✅ 完全一致 | 保留 |
| StartRecording | 开始录制 | 開始錄製 | 開始錄製 | Start recording | 録画を開始 | ✅ 完全一致 | 保留 |
| StartRequested | 已请求开始投屏 | 已請求開始螢幕鏡像 | 已請求開始螢幕鏡像 | Mirroring start requested | ミラーリングの開始を要求しました | ✅ 完全一致 | 保留 |
| StartStreaming | 开始直播推流 | 開始直播串流 | 開始直播串流 | Start live stream | ライブ配信を開始 | ✅ 完全一致 | 保留 |
| StartVirtualCamera | 启动虚拟摄像头 | 啟動虛擬攝影機 | 啟動虛擬攝影機 | Start virtual camera | 仮想カメラを開始 | ✅ 完全一致 | 保留 |
| StartingInstaller | 正在启动安装程序，应用即将安全退出… | 正在啟動安裝程式，應用程式即將安全退出… | 正在啟動安裝程式，應用程式即將安全退出… | Starting the installer. The app will close safely… | インストーラーを起動しています。アプリは安全に終了します… | ✅ 完全一致 | 保留 |
| StartupErrorClose | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 保留 |
| StartupErrorDetails | 错误详情 | 錯誤詳細資料 | 錯誤詳細資料 | Error details | エラーの詳細 | ✅ 完全一致 | 保留 |
| StartupErrorHeading | iPhoneMirror 无法启动 | iPhoneMirror 無法啟動 | iPhoneMirror 無法啟動 | iPhoneMirror could not start | iPhoneMirrorを起動できませんでした | ✅ 完全一致 | 保留 |
| StartupErrorLogLabel | 诊断日志 | 診斷記錄 | 診斷記錄檔 | Diagnostic log | 診断ログ | ✅ 完全一致 | 保留 |
| StartupErrorOpenLog | 打开日志位置 | 開啟記錄位置 | 開啟記錄檔位置 | Open log location | ログの場所を開く | ✅ 完全一致 | 保留 |
| StatusCheckingEnvironment | 正在检查 Apple USB 环境… | 正在檢查 Apple USB 環境… | 正在檢查 Apple USB 環境… | Checking the Apple USB environment… | AppleのUSB環境を確認しています… | ✅ 完全一致 | 保留 |
| StatusDefaultSettings | 原生 · 60 fps | 原始 · 60 fps | 原始 · 60 fps | Native · 60 fps | ネイティブ · 60fps | ❌ 含义不一致 → ✅ 已修复 | Native 表示原始分辨率，不是默认设置 |
| StatusDetecting | 检测中 | 偵測中 | 偵測中 | Detecting | 検出中 | ✅ 完全一致 | 保留 |
| StatusWaiting | 等待 | 等待 | 等待 | Waiting | 待機中 | ✅ 完全一致 | 保留 |
| StatusWaitingDevice | 等待设备连接 | 等待裝置連接 | 等待裝置連線 | Waiting for a device | デバイスを待っています | ✅ 完全一致 | 保留 |
| StatusWaitingLog | 等待核心日志… | 等待核心記錄… | 等待核心記錄檔… | Waiting for core logs… | コアログを待っています… | ✅ 完全一致 | 保留 |
| StopBluetoothControl | 关闭蓝牙控制 | 關閉藍牙控制 | 關閉藍牙控制 | Disable Bluetooth control | Bluetooth操作を無効にする | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为蓝牙控制；静态未发现引用，保留待后续调用核对 |
| StopFailedFormat | 停止投屏失败：{0} | 停止螢幕鏡像失敗：{0} | 停止螢幕鏡像失敗：{0} | Could not stop mirroring: {0} | ミラーリングを停止できませんでした: {0} | ✅ 完全一致 | 保留 |
| StopMediaOutput | 停止输出 | 停止輸出 | 停止輸出 | Stop output | 出力を停止 | ✅ 完全一致 | 保留 |
| StopMirroring | 停止投屏 | 停止螢幕鏡像 | 停止螢幕鏡像 | Stop mirroring | ミラーリングを停止 | ✅ 完全一致 | 保留 |
| StopRecordingOnly | 停止录制 | 停止錄影 | 停止錄影 | Stop recording | 録画を停止 | ✅ 完全一致 | 保留 |
| StopSessionReleased | 投屏已停止，会话资源已释放 | 螢幕鏡像已停止，工作階段資源已釋放 | 螢幕鏡像已停止，工作階段資源已釋放 | Mirroring stopped and session resources were released | ミラーリングを停止し、セッションのリソースを解放しました | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| StopStreamingOnly | 停止直播 | 停止直播 | 停止直播 | Stop live stream | ライブ配信を停止 | ✅ 完全一致 | 保留 |
| StopUsbRestoreWarningFormat | 投屏已停止，会话资源已释放，但尚未确认 Apple USB 通道恢复可用。请解锁 iPhone，确认可能出现的信任提示并输入密码；若取消了自动重连的管理员授权或仍无法识别，请重新插拔数据线。诊断：{0} | 螢幕鏡像已停止，工作階段資源已釋放，但尚未確認 Apple USB 通道恢復可用。請解鎖 iPhone，確認可能出現的信任提示並輸入密碼；若取消了自動重新連接的管理員授權或仍無法識別，請重新插拔數據線。診斷：{0} | 螢幕鏡像已停止，工作階段資源已釋放，但尚未確認 Apple USB 通道恢復可用。請解鎖 iPhone，確認可能出現的信任提示並輸入密碼；若取消了自動重新連線的系統管理員授權或仍無法辨識，請重新插拔傳輸線。診斷：{0} | Mirroring stopped and session resources were released, but the Apple USB connection has not been confirmed ready. Unlock the iPhone, accept any Trust prompt and enter its passcode. If administrator approval for automatic reconnection was cancelled or the device is still missing, reconnect the cable. Diagnostic: {0} | ミラーリングを停止し、セッションのリソースを解放しましたが、AppleのUSB接続の準備ができたことを確認できていません。iPhoneのロックを解除し、「信頼」の確認が出たら許可してパスコードを入力してください。自動再接続の管理者承認をキャンセルした場合や、デバイスがまだ表示されない場合は、ケーブルをつなぎ直してください。診断: {0} | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| StreamAuthorization | WHIP Bearer 令牌（可选） | WHIP Bearer Token（可選） | WHIP Bearer Token（可選） | WHIP bearer token (optional) | WHIPベアラートークン（省略可） | ✅ 完全一致 | 保留 |
| StreamDescription | 通过 RTMP、SRT 或 WebRTC WHIP 端点发送当前投屏画面。 | 透過 RTMP、SRT 或 WebRTC WHIP 端點傳送目前的螢幕鏡像畫面。 | 透過 RTMP、SRT 或 WebRTC WHIP 端點傳送目前的螢幕鏡像畫面。 | Send the selected mirror through RTMP, SRT, or a WebRTC WHIP endpoint. | 選択したミラーリングを、RTMP、SRT、またはWebRTC WHIPのエンドポイントに送信します。 | ✅ 完全一致 | 保留 |
| StreamDestination | 服务器地址或 WHIP 端点 | 伺服器位址或 WHIP 端點 | 伺服器位址或 WHIP 端點 | Server or WHIP endpoint | サーバーまたはWHIPエンドポイント | ✅ 完全一致 | 保留 |
| StreamMicrophone | 直播麦克风 | 直播麥克風 | 直播麥克風 | Stream microphone | マイクを配信 | ✅ 完全一致 | 保留 |
| StreamMicrophoneHint | 与手机声音混合。建议使用耳机避免回声。 | 與手機聲音混合。建議使用耳機避免回音。 | 與手機聲音混合。建議使用耳機避免回音。 | Mix with phone audio. Use headphones to avoid echo. | iPhoneの音声とミックスします。エコーを防ぐため、ヘッドホンを使ってください。 | ✅ 完全一致 | 保留 |
| StreamProtocol | 协议 | 協議 | 協定 | Protocol | プロトコル | ✅ 完全一致 | 保留 |
| StreamTab | 直播推流 | 直播串流 | 直播串流 | Live stream | ライブ配信 | ✅ 完全一致 | 保留 |
| StreamingStopTimeout | FFmpeg 未能在 15 秒内停止直播推流。 | FFmpeg 未能在 15 秒內停止直播串流。 | FFmpeg 未能在 15 秒內停止直播串流。 | FFmpeg did not stop live streaming within 15 seconds. | FFmpegが15秒以内にライブ配信を停止しませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| SwitchDeviceFailedFormat | 切换设备失败：{0} | 切換裝置失敗：{0} | 切換裝置失敗：{0} | Could not switch devices: {0} | デバイスを切り替えられませんでした: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| SwitchingDeviceFormat | 正在停止当前投屏并切换到 {0}… | 正在停止目前螢幕鏡像並切換到 {0}… | 正在停止目前螢幕鏡像並切換到 {0}… | Stopping the current session before switching to {0}… | {0}に切り替える前に、現在のセッションを停止しています… | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| TargetFpsFormat | 本地上限 {0} fps | 本機上限 {0} fps | 本機上限 {0} fps | Local limit: {0} fps | ローカルの上限: {0}fps | ✅ 完全一致 | 保留 |
| TargetFrameRate | 本地渲染帧率上限 | 本機繪製幀率上限 | 本機繪製影格率上限 | Local rendering frame-rate limit | ローカル描画のフレームレート上限 | ✅ 完全一致 | 保留 |
| TestingUpdateRoutes | 正在测试 GitHub 和镜像线路… | 正在測試 GitHub 和鏡像線路… | 正在測試 GitHub 和鏡像線路… | Testing GitHub and mirror routes… | GitHubとミラーの経路をテストしています… | ✅ 完全一致 | 保留 |
| ThemeDark | 深色 | 深色 | 深色 | Dark | ダーク | ✅ 完全一致 | 保留 |
| ThemeLight | 浅色 | 淺色 | 淺色 | Light | ライト | ✅ 完全一致 | 保留 |
| ThemeSystem | 跟随系统 | 跟隨系統 | 跟隨系統 | Use system setting | システムの設定に従う | ✅ 完全一致 | 保留 |
| ThemeTitle | 应用主题 | 應用程式主題 | 應用程式主題 | App theme | アプリのテーマ | ✅ 完全一致 | 保留 |
| TitleBarCloseToolTip | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 保留 |
| TitleBarMaximizeToolTip | 最大化或还原 | 最大化或還原 | 最大化或還原 | Maximize or restore | 最大化または元に戻す | ✅ 完全一致 | 保留 |
| TitleBarMinimizeToolTip | 最小化 | 最小化 | 最小化 | Minimize | 最小化 | ✅ 完全一致 | 保留 |
| TouchBridgeAlreadyStarted | USB 触控桥接器已经启动。 | USB 觸控橋接器已啟動。 | USB 觸控橋接器已啟動。 | The USB touch bridge has already started. | USBタッチブリッジはすでに起動しています。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeAuthenticationRequired | 设备未确认触控认证已开启，无法启动反向控制。 | 裝置未確認觸控驗證已開啟，無法啟動反向控制。 | 裝置未確認觸控驗證已開啟，無法啟動反向控制。 | The device did not confirm touch authentication, so reverse control could not start. | デバイスがタッチの認証を確認しなかったため、リモート操作を開始できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeDiagnosticFormat |  最近诊断：{0} |  最近診斷：{0} |  最近診斷：{0} |  Latest diagnostic: {0} |  最新の診断情報: {0} | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TouchBridgeErrorCodeFormat | （错误代码：{0}） | （錯誤代碼：{0}） | （錯誤代碼：{0}） |  (error code: {0}) |  （エラーコード: {0}） | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TouchBridgeExitedFormat | USB 触控桥接器意外退出（代码 {0}）。 | USB 觸控橋接器意外結束（代碼 {0}）。 | USB 觸控橋接器意外結束（代碼 {0}）。 | The USB touch bridge exited unexpectedly (code {0}). | USBタッチブリッジが予期せず終了しました（コード {0}）。 | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TouchBridgeInvalidBatch | 触控批次必须包含 1 到 5 个触点。 | 觸控批次必須包含 1 至 5 個觸點。 | 觸控批次必須包含 1 至 5 個觸點。 | A touch batch must contain 1 to 5 points. | タッチのバッチには1～5点を含める必要があります。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeInvalidCoordinates | 触点坐标必须是 0 到 1 之间的有限数值。 | 觸點座標必須是 0 至 1 之間的有限數值。 | 觸點座標必須是 0 至 1 之間的有限數值。 | Touch coordinates must be finite numbers between 0 and 1. | タッチ座標は0～1の有限の数値にする必要があります。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeInvalidOutput | USB 触控桥接器输出格式无效。 | USB 觸控橋接器輸出格式無效。 | USB 觸控橋接器輸出格式無效。 | The USB touch bridge output format is invalid. | USBタッチブリッジの出力形式が正しくありません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeInvalidPointId | 触点编号必须为非负整数。 | 觸點編號必須為非負整數。 | 觸點編號必須為非負整數。 | Touch point IDs must be non-negative integers. | タッチポイントのIDは0以上の整数にする必要があります。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeNotReady | USB 触控桥接器尚未就绪。 | USB 觸控橋接器尚未就緒。 | USB 觸控橋接器尚未就緒。 | The USB touch bridge is not ready. | USBタッチブリッジの準備ができていません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeNotStarted | USB 触控桥接器未启动。 | USB 觸控橋接器未啟動。 | USB 觸控橋接器未啟動。 | The USB touch bridge has not started. | USBタッチブリッジが起動していません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeOutputClosed | USB 触控桥接器在就绪前关闭了输出通道。 | USB 觸控橋接器在就緒前關閉了輸出通道。 | USB 觸控橋接器在就緒前關閉了輸出通道。 | The USB touch bridge closed its output channel before it was ready. | USBタッチブリッジが、準備できる前に出力チャンネルを閉じました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeOutputDisconnected | USB 触控桥接器意外关闭了输出通道。 | USB 觸控橋接器意外關閉了輸出通道。 | USB 觸控橋接器意外關閉了輸出通道。 | The USB touch bridge unexpectedly closed its output channel. | USBタッチブリッジが出力チャンネルを予期せず閉じました。 | ✅ 完全一致 | 保留 |
| TouchBridgeReportedError | USB 触控桥接器报告错误。 | USB 觸控橋接器報告錯誤。 | USB 觸控橋接器報告錯誤。 | The USB touch bridge reported an error. | USBタッチブリッジがエラーを報告しました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeRuntimeIncompleteFormat | USB 触控桥接组件不完整：{0}。请重新安装完整的 iPhoneMirror 安装包。 | USB 觸控橋接元件不完整：{0}。請重新安裝完整的 iPhoneMirror 安裝套件。 | USB 觸控橋接元件不完整：{0}。請重新安裝完整的 iPhoneMirror 安裝套件。 | The USB touch bridge runtime is incomplete: {0}. Reinstall the full iPhoneMirror package. | USBタッチブリッジのランタイムが不完全です: {0}。iPhoneMirrorのパッケージ一式を再インストールしてください。 | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TouchBridgeStartFailed | 无法启动 USB 触控桥接器。 | 無法啟動 USB 觸控橋接器。 | 無法啟動 USB 觸控橋接器。 | Could not start the USB touch bridge. | USBタッチブリッジを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源；静态未发现引用，保留待后续调用核对 |
| TouchBridgeTargetMismatch | 反向控制桥接目标 UDID 不匹配。 | 反向控制橋接目標 UDID 不符。 | 反向控制橋接目標 UDID 不符。 | The reverse-control bridge target UDID does not match. | リモート操作ブリッジの対象UDIDが一致しません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| TouchBridgeTargetMismatchFormat | 反向控制目标不匹配：请求 {0}，实际 {1}。 | 反向控制目標不符：要求 {0}，實際為 {1}。 | 反向控制目標不符：要求 {0}，實際為 {1}。 | Reverse-control target mismatch: requested {0}, received {1}. | リモート操作の対象が一致しません。要求: {0}、受信: {1}。 | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TouchBridgeTimeoutFormat | USB 触控桥接器在 {0:0} 秒内未就绪。详细信息：{1} | USB 觸控橋接器在 {0:0} 秒內未就緒。詳細資料：{1} | USB 觸控橋接器在 {0:0} 秒內未就緒。詳細資料：{1} | The USB touch bridge was not ready within {0:0} s. Details: {1} | USBタッチブリッジが{0:0}秒以内に準備できませんでした。詳細: {1} | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TouchBridgeTransportMismatchFormat | 反向控制传输类型不匹配：请求 {0}，实际 {1}。 | 反向控制傳輸類型不符：要求 {0}，實際為 {1}。 | 反向控制傳輸類型不符：要求 {0}，實際為 {1}。 | Reverse-control transport mismatch: requested {0}, received {1}. | リモート操作の通信方式が一致しません。要求: {0}、受信: {1}。 | ❌ 缺失 → ✅ 已修复 | 桥接错误提示迁入三语资源；原始诊断参数保留 |
| TrayExit | 退出应用 | 結束應用程式 | 結束應用程式 | Exit app | アプリを終了 | ✅ 完全一致 | 保留 |
| TrayHidePanel | 收起到托盘 | 收起到系統匣 | 收起到系統匣 | Hide to system tray | システムトレイに隠す | ✅ 完全一致 | 保留 |
| TrayNoDevices | 连接并解锁 USB 设备，或在 iPhone 的屏幕镜像中选择此电脑。 | 連接並解鎖 USB 裝置，或在 iPhone 的螢幕鏡像中選擇此電腦。 | 連線並解鎖 USB 裝置，或在 iPhone 的螢幕鏡像中選擇此電腦。 | Connect and unlock a USB device, or select this computer in iPhone Screen Mirroring. | USBデバイスを接続してロックを解除するか、iPhoneの画面ミラーリングでこのコンピュータを選択してください。 | ✅ 完全一致 | 保留 |
| TrayPanelSubtitle | 选择设备，直接在独立窗口投屏 | 選擇裝置，直接在獨立視窗投影 | 選擇裝置，在獨立視窗中進行螢幕鏡像 | Choose a device to mirror in its own window | 専用ウィンドウでミラーリングするデバイスを選択 | ✅ 完全一致 | 保留 |
| TrayRefreshFailed | 无法从托盘刷新设备。请重试。 | 無法從系統匣重新整理裝置。請重試。 | 無法從系統匣重新整理裝置。請重試。 | Devices could not be refreshed from the tray. Try again. | トレイからデバイスを更新できませんでした。再試行してください。 | ✅ 完全一致 | 保留 |
| TrayRestoreMainWindow | 恢复主界面 | 還原主視窗 | 還原主視窗 | Restore main window | メインウィンドウを表示 | ✅ 完全一致 | 保留 |
| TrayStartFailed | 无法从托盘启动投屏。请检查设备后重试。 | 無法從系統匣啟動投屏。請檢查裝置後重試。 | 無法從系統匣啟動投影。請檢查裝置後重試。 | Mirroring could not start from the tray. Check the device and try again. | トレイからミラーリングを開始できませんでした。デバイスを確認して再試行してください。 | ✅ 完全一致 | 保留 |
| TrayStartMirroring | 打开独立投屏窗口 | 開啟獨立投影視窗 | 開啟獨立螢幕鏡像視窗 | Open mirroring window | ミラーリングウィンドウを開く | ✅ 完全一致 | 保留 |
| TrayStarting | 正在打开投屏窗口… | 正在開啟投影視窗… | 正在開啟螢幕鏡像視窗… | Opening mirroring window… | ミラーリングウィンドウを開いています… | ✅ 完全一致 | 保留 |
| TrayUnavailable | 无法创建托盘图标：{0} | 無法建立系統匣圖示：{0} | 無法建立系統匣圖示：{0} | Could not create the tray icon: {0} | トレイアイコンを作成できませんでした: {0} | ✅ 完全一致 | 保留 |
| UiBluetoothRefreshFailed | 无法刷新蓝牙设备。请检查蓝牙连接后重试；列表可能不是最新状态。 | 無法重新整理藍牙裝置。請檢查藍牙連線後重試；清單可能不是最新狀態。 | 無法重新整理藍牙裝置。請檢查藍牙連線後重試；清單可能不是最新狀態。 | Could not refresh Bluetooth devices. Check Bluetooth and try again; the list may be out of date. | Bluetoothデバイスを更新できませんでした。Bluetoothを確認してもう一度お試しください。一覧が古い可能性があります。 | ✅ 完全一致 | 保留 |
| UiLogLocationFailed | 无法打开日志位置。你可以复制以下路径并在文件资源管理器中打开：<br>{0} | 無法開啟記錄位置。你可以複製以下路徑並在檔案總管中開啟：<br>{0} | 無法開啟記錄檔位置。您可以複製以下路徑並在檔案總管中開啟：<br>{0} | Could not open the log location. Copy this path and open it in File Explorer:<br>{0} | ログの場所を開けませんでした。次のパスをコピーして、エクスプローラーで開いてください:<br>{0} | ✅ 完全一致 | 保留 |
| UiProtectedContentShort | 受保护内容 | 受保護內容 | 受保護內容 | Protected content | 保護されたコンテンツ | ✅ 完全一致 | 保留 |
| UiRefreshing | 正在刷新… | 正在重新整理… | 正在重新整理… | Refreshing… | 更新中… | ✅ 完全一致 | 保留 |
| Unavailable | 不可用 | 不可用 | 不可用 | Unavailable | 利用不可 | ✅ 完全一致 | 保留 |
| UninstallVirtualCamera | 卸载虚拟摄像头组件 | 解除安裝虛擬攝影機元件 | 解除安裝虛擬攝影機元件 | Uninstall virtual camera component | 仮想カメラのコンポーネントをアンインストール | ✅ 完全一致 | 保留 |
| UnknownError | 未知错误 | 未知錯誤 | 未知錯誤 | Unknown error | 不明なエラー | ✅ 完全一致 | 保留 |
| UpdateAvailableFormat | 发现新版本 {0}。 | 發現新版本 {0}。 | 發現新版本 {0}。 | Version {0} is available. | バージョン{0}が利用可能です。 | ✅ 完全一致 | 保留 |
| UpdateCheckCancelled | 更新检查已取消。 | 更新檢查已取消。 | 更新檢查已取消。 | The update check was cancelled. | アップデートの確認をキャンセルしました。 | ✅ 完全一致 | 保留 |
| UpdateCheckFailedFormat | 无法检查更新：{0} | 無法檢查更新：{0} | 無法檢查更新：{0} | Could not check for updates: {0} | アップデートを確認できませんでした: {0} | ✅ 完全一致 | 保留 |
| UpdateChecksumDownloadUnavailable | 所有校验清单下载线路暂时不可用。 | 所有驗證清單下載線路暫時不可用。 | 所有驗證清單下載線路暫時不可用。 | All checksum download routes are temporarily unavailable. | チェックサムのダウンロード経路がすべて一時的に利用できません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateChecksumEntryMissingFormat | SHA256SUMS.txt 中没有 {0} 的校验值。 | SHA256SUMS.txt 中沒有 {0} 的驗證值。 | SHA256SUMS.txt 中沒有 {0} 的驗證值。 | SHA256SUMS.txt does not contain a checksum for {0}. | SHA256SUMS.txtに{0}のチェックサムがありません。 | ❌ 缺失 → ✅ 已修复 | 用户可见错误详情补齐三语 |
| UpdateChecksumFailed | 下载的更新未通过 SHA-256 校验。 | 下載的更新未通過 SHA-256 驗證。 | 下載的更新未通過 SHA-256 驗證。 | The downloaded update failed SHA-256 verification. | ダウンロードしたアップデートがSHA-256の検証に失敗しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateChecksumListInvalid | 校验清单未通过 SHA-256 校验。 | 驗證清單未通過 SHA-256 驗證。 | 驗證清單未通過 SHA-256 驗證。 | The checksum manifest failed SHA-256 verification. | チェックサムのマニフェストがSHA-256の検証に失敗しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateChecksumListTooLarge | 校验清单大小超出允许范围。 | 驗證清單大小超出允許範圍。 | 驗證清單大小超出允許範圍。 | The checksum manifest exceeds the allowed size. | チェックサムのマニフェストが許容サイズを超えています。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateChecksumRequired | 此版本未提供可信的 SHA-256 校验值，无法安装。 | 此版本未提供可信的 SHA-256 驗證值，無法安裝。 | 此版本未提供可信的 SHA-256 驗證值，無法安裝。 | This release does not provide a trusted SHA-256 value and cannot be installed. | このリリースには信頼できるSHA-256値がないため、インストールできません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateChecksumSizeMismatch | 校验清单大小与发布信息不符。 | 驗證清單大小與發佈資料不符。 | 驗證清單大小與發布資料不符。 | The checksum manifest size does not match the release metadata. | チェックサムのマニフェストのサイズが、リリースのメタデータと一致しません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateDigestInvalid | 更新校验值无效。 | 更新驗證值無效。 | 更新驗證值無效。 | The update verification digest is invalid. | アップデートの検証用ダイジェストが正しくありません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateDigestMissing | 更新校验值缺失或无效。 | 更新驗證值遺失或無效。 | 更新驗證值遺失或無效。 | The update verification digest is missing or invalid. | アップデートの検証用ダイジェストがないか、正しくありません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateDownloadCancelled | 更新下载已取消，可稍后重新尝试。 | 更新下載已取消，可稍後重新嘗試。 | 更新下載已取消，可稍後重新嘗試。 | The update download was cancelled. You can retry later. | アップデートのダウンロードをキャンセルしました。後で再試行できます。 | ✅ 完全一致 | 保留 |
| UpdateDownloadEndpointsUnavailable | 所有更新下载线路暂时不可用。 | 所有更新下載線路暫時不可用。 | 所有更新下載線路暫時不可用。 | All update download routes are temporarily unavailable. | アップデートのダウンロード経路がすべて一時的に利用できません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateDownloadFailedFormat | 更新失败：{0} | 更新失敗：{0} | 更新失敗：{0} | Update failed: {0} | アップデートできませんでした: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| UpdateDownloadUntrustedRedirect | 更新下载重定向到了不受信任的网站。 | 更新下載重新導向至不受信任的網站。 | 更新下載重新導向至不受信任的網站。 | The update download redirected to an untrusted host. | アップデートのダウンロードが信頼できないホストへリダイレクトされました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateDownloadedNoChecksum | 下载完成；此 Release 未提供 SHA-256 校验值。 | 下載完成；此 Release 未提供 SHA-256 驗證值。 | 下載完成；此 Release 未提供 SHA-256 驗證值。 | Download complete. This release did not provide a SHA-256 value. | ダウンロードが完了しました。このリリースにはSHA-256の値がありませんでした。 | ❌ 术语不一致 → ✅ 已修复 | 统一校验算法显示名称 |
| UpdateEndpointsUnavailable | 所有更新服务暂时不可用。 | 所有更新服務暫時不可用。 | 所有更新服務暫時不可用。 | All update services are temporarily unavailable. | すべてのアップデートサービスが一時的に利用できません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateFailedFormat | 更新失败：{0} | 更新失敗：{0} | 更新失敗：{0} | Update failed: {0} | アップデートに失敗しました：{0} | ✅ 完全一致 | 保留 |
| UpdateFormatUnsupported | 不支持此更新包格式。 | 不支援此更新套件格式。 | 不支援此更新套件格式。 | This update package format is unsupported. | このアップデートパッケージの形式には対応していません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateHelperExitedFormat | 更新助手未能完成安装或准备交接（退出码 {0}）。请重试，或手动运行下载的更新包。 | 更新助手未能完成安裝或準備交接（結束代碼 {0}）。請重試，或手動執行已下載的更新套件。 | 更新助手無法完成安裝或準備交接（結束代碼 {0}）。請重試，或手動執行已下載的更新套件。 | The update helper could not complete installation or prepare the handoff (exit code {0}). Retry or run the downloaded update package manually. | アップデートヘルパーがインストールまたは引き継ぎの準備を完了できませんでした（終了コード {0}）。再試行するか、ダウンロードした更新パッケージを手動で実行してください。 | ✅ 完全一致 | 保留 |
| UpdateHelperMissing | 缺少内置 ZIP 更新助手。 | 缺少內置 ZIP 更新助手。 | 缺少內建 ZIP 更新助手。 | The embedded ZIP update helper is missing. | 組み込みのZIPアップデートヘルパーがありません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateHelperStartFailed | Windows 无法启动更新助手。 | Windows 無法啟動更新助手。 | Windows 無法啟動更新助手。 | Windows could not start the update helper. | Windowsがアップデートヘルパーを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateHelperTimedOut | 更新助手准备超时，已取消本次安装。请重试或手动安装更新包。 | 更新助手準備逾時，已取消本次安裝。請重試或手動安裝更新套件。 | 更新助手準備逾時，已取消本次安裝。請重試或手動安裝更新套件。 | The update helper timed out while preparing, so this installation was cancelled. Retry or install the update package manually. | アップデートヘルパーの準備がタイムアウトしたため、今回のインストールをキャンセルしました。再試行するか、更新パッケージを手動でインストールしてください。 | ✅ 完全一致 | 保留 |
| UpdateInstallFailed | 更新未完成。请手动安装已下载的更新包。错误详情： | 更新未完成。請手動安裝已下載的更新套件。錯誤詳情： | 更新未完成。請手動安裝已下載的更新套件。錯誤詳細資料： | The update did not complete. Install the downloaded update package manually. Error details: | アップデートが完了しませんでした。ダウンロードした更新パッケージを手動でインストールしてください。エラーの詳細： | ✅ 完全一致 | 保留 |
| UpdateInstallerPackageMissing | 此版本未提供 Windows 安装包。 | 此版本未提供 Windows 安裝套件。 | 此版本未提供 Windows 安裝套件。 | This release does not provide a Windows installer package. | このリリースにはWindows用のインストーラーパッケージがありません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateNetworkUnavailable | 所有更新线路暂时不可用，请检查网络连接后重试。 | 所有更新連線暫時不可用，請檢查網絡連接後重試。 | 所有更新連線暫時不可用，請檢查網路連線後重試。 | All update routes are temporarily unavailable. Check your connection and try again. | すべてのアップデート経路が一時的に利用できません。接続を確認して、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| UpdateNow | 立即更新 | 立即更新 | 立即更新 | Update now | 今すぐアップデート | ✅ 完全一致 | 保留 |
| UpdatePackageChanged | 更新包在校验后发生变化，已停止安装。 | 更新套件在驗證後發生變更，已停止安裝。 | 更新套件在驗證後發生變更，已停止安裝。 | The update package changed after verification. Installation stopped. | 検証後にアップデートパッケージが変更されました。インストールを中止しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdatePackageNotVerified | 更新包未经验证，不会运行。 | 更新套件未經驗證，不會執行。 | 更新套件未經驗證，不會執行。 | The update package has not been verified and will not run. | アップデートパッケージが検証されていないため、実行しません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdatePackageTooLarge | 更新包大小超出允许范围。 | 更新套件大小超出允許範圍。 | 更新套件大小超出允許範圍。 | The update package exceeds the allowed size. | アップデートパッケージが許容サイズを超えています。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdatePortableDirectoryUnsafe | 便携版安装目录包含可写子目录或重解析点，无法安全地使用管理员权限更新。 | 可攜式版本的安裝資料夾包含可寫入的子資料夾或重新分析點，無法安全地使用管理員權限更新。 | 可攜式版本的安裝資料夾包含可寫入的子資料夾或重新分析點，無法安全地使用管理員權限更新。 | The portable installation contains a writable subdirectory or reparse point and cannot be safely updated with administrator privileges. | ポータブル版のインストール先に、書き込み可能なサブフォルダーまたは再解析ポイントがあるため、管理者権限で安全にアップデートできません。 | ❌ 缺失 → ✅ 已修复 | 更新启动失败提示补齐三语 |
| UpdatePortableElevationUnsupported | 请以非管理员身份重新启动 iPhoneMirror，再更新便携版。 | 請以非管理員身分重新啟動 iPhoneMirror，再更新可攜式版本。 | 請以非管理員身分重新啟動 iPhoneMirror，再更新可攜式版本。 | Restart iPhoneMirror without administrator privileges, then update the portable edition. | iPhoneMirrorを管理者権限なしで再起動してから、ポータブル版をアップデートしてください。 | ❌ 缺失 → ✅ 已修复 | 更新启动失败提示补齐三语 |
| UpdatePortablePackageMissing | 此版本未提供便携 ZIP 包。 | 此版本未提供可攜式 ZIP 套件。 | 此版本未提供可攜式 ZIP 套件。 | This release does not provide a portable ZIP package. | このリリースにはポータブル版のZIPパッケージがありません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdatePortableRequired | 便携版必须使用便携 ZIP 包更新。 | 可攜式版本必須使用可攜式 ZIP 套件更新。 | 可攜式版本必須使用可攜式 ZIP 套件更新。 | The portable edition must be updated with the portable ZIP package. | ポータブル版は、ポータブル版のZIPパッケージでアップデートする必要があります。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateReleaseFieldMissingFormat | GitHub 版本信息缺少 {0}。 | GitHub 版本資料缺少 {0}。 | GitHub 版本資料缺少 {0}。 | The GitHub release is missing {0}. | GitHubのリリースに{0}がありません。 | ❌ 缺失 → ✅ 已修复 | 用户可见错误详情补齐三语 |
| UpdateReleaseListInvalid | GitHub 返回了无效的版本列表。 | GitHub 傳回了無效的版本清單。 | GitHub 傳回了無效的版本清單。 | GitHub returned an invalid release list. | GitHubが正しくないリリース一覧を返しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateReleaseListTooLarge | 更新版本列表大小超出允许范围。 | 更新版本清單大小超出允許範圍。 | 更新版本清單大小超出允許範圍。 | The release list exceeds the allowed size. | リリース一覧が許容サイズを超えています。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateRequestTimedOut | 连接更新服务超时，请稍后重试。 | 連接更新服務逾時，請稍後重試。 | 連線更新服務逾時，請稍後重試。 | The update request timed out. Try again later. | アップデートの要求がタイムアウトしました。しばらくしてからもう一度お試しください。 | ✅ 完全一致 | 保留 |
| UpdateResponseUrlMissing | 更新服务未返回最终下载地址。 | 更新服務未傳回最終下載位址。 | 更新服務未傳回最終下載位址。 | The update service did not return a final download URL. | アップデートサービスが最終的なダウンロードURLを返しませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateSettingsDescription | 控制后台检查、自动下载、镜像加速和发布通道。 | 控制背景更新檢查、自動下載、鏡像加速和發佈通道。 | 控制背景更新檢查、自動下載、鏡像加速和發布通道。 | Control background checks, automatic downloads, mirror acceleration, and release channels. | バックグラウンドでの確認、自動ダウンロード、ミラーによる高速化、リリースチャンネルを設定します。 | ✅ 完全一致 | 保留 |
| UpdateSettingsTitle | 更新设置 | 更新設定 | 更新設定 | Update settings | アップデート設定 | ✅ 完全一致 | 保留 |
| UpdateSetupRequired | 安装版必须使用 Windows 安装包更新。 | 安裝版必須使用 Windows 安裝套件更新。 | 安裝版必須使用 Windows 安裝套件更新。 | The installed edition must be updated with the Windows Setup package. | インストール版は、Windows用セットアップパッケージでアップデートする必要があります。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateStatusReady | 可随时检查 GitHub Release 更新。 | 可隨時檢查 GitHub Release 更新。 | 可隨時檢查 GitHub Release 更新。 | Check GitHub Releases for updates at any time. | GitHub Releasesでのアップデートは、いつでも確認できます。 | ✅ 完全一致 | 保留 |
| UpdateStatusTitle | 更新状态 | 更新狀態 | 更新狀態 | Update status | アップデートの状況 | ✅ 完全一致 | 保留 |
| UpdateUnsafeFileName | 更新文件名不安全，已停止下载。 | 更新檔案名稱不安全，已停止下載。 | 更新檔案名稱不安全，已停止下載。 | The update file name is unsafe. Download stopped. | アップデートファイルの名前が安全ではありません。ダウンロードを中止しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateUntrustedAssetUrl | 更新下载地址不受信任。 | 更新下載位址不受信任。 | 更新下載位址不受信任。 | The update download URL is not trusted. | アップデートのダウンロードURLは信頼できません。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateUntrustedNotesRedirect | 更新说明地址重定向到了不受信任的网站。 | 更新說明位址重新導向至不受信任的網站。 | 更新說明位址重新導向至不受信任的網站。 | The release notes URL redirected to an untrusted host. | リリースノートのURLが信頼できないホストへリダイレクトしました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateUntrustedRedirect | 更新服务重定向到了不受信任的网站。 | 更新服務重新導向至不受信任的網站。 | 更新服務重新導向至不受信任的網站。 | The update service redirected to an untrusted host. | アップデートサービスが信頼できないホストへリダイレクトしました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| UpdateVerified | 下载完成，SHA-256 校验通过。 | 下載完成，SHA-256 驗證通過。 | 下載完成，SHA-256 驗證通過。 | Download complete. SHA-256 verification passed. | ダウンロードが完了しました。SHA-256の検証に成功しました。 | ❌ 术语不一致 → ✅ 已修复 | 统一校验算法显示名称 |
| UpdateVirtualCamera | 更新虚拟摄像头组件 | 更新虛擬攝影機元件 | 更新虛擬攝影機元件 | Update virtual camera component | 仮想カメラのコンポーネントをアップデート | ✅ 完全一致 | 保留 |
| UpdateWindowSubtitle | 查看更新内容并一键完成升级 | 查看更新內容並一按完成升級 | 查看更新內容並一鍵完成升級 | Review the changes and upgrade in one step | 変更内容を確認して、ワンステップでアップグレードします | ✅ 完全一致 | 保留 |
| UpdateWindowTitle | 发现新版本 | 發現新版本 | 發現新版本 | A new version is available | 新しいバージョンがあります | ✅ 完全一致 | 保留 |
| UsbControlDefault | 反向控制 | 反向控制 | 反向控制 | Reverse control | リモート操作 | ✅ 完全一致 | 保留 |
| UsbControlDeveloperModeRevealed | 设备已确认显示“开发者模式”开关的请求。请在 iPhone/iPad 的“设置 &gt; 隐私与安全性 &gt; 开发者模式”中开启，按提示重启并在手机上确认开启，然后回到此窗口点击“重试”。若设置页面已打开，请退出后重新进入。 | 裝置已確認顯示「開發者模式」開關的請求。請在 iPhone/iPad 的「設定 &gt; 私隱與安全性 &gt; 開發者模式」中開啟，依提示重新啟動並在手機上確認開啟，再回到此視窗點選「重試」。若設定頁面已開啟，請離開後重新進入。 | 裝置已確認顯示「開發者模式」開關的請求。請在 iPhone/iPad 的「設定 &gt; 隱私權與安全性 &gt; 開發者模式」中開啟，依提示重新啟動並在手機上確認開啟，再回到此視窗點選「重試」。若設定頁面已開啟，請離開後重新進入。 | The device accepted the request to show the Developer Mode toggle. Enable it under iPhone/iPad Settings → Privacy &amp; Security → Developer Mode, restart and confirm on the device, then click Retry here. If Settings is already open, leave the page and reopen it. | デベロッパモードのスイッチを表示する要求をデバイスが受け付けました。iPhone/iPadの「設定」→「プライバシーとセキュリティ」→「デベロッパモード」で有効にし、再起動してデバイスで確認を済ませてから、ここで「再試行」をクリックしてください。すでに「設定」を開いている場合は、いったんページを閉じて開き直してください。 | ✅ 完全一致 | 保留 |
| UsbControlDisable | 关闭有线控制 | 關閉有線控制 | 關閉有線控制 | Disable wired control | 有線操作を無効にする | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| UsbControlDisableWireless | 关闭无线控制 | 關閉無線控制 | 關閉無線控制 | Disable wireless control | 無線操作を無効にする | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| UsbControlFailureAppleUsbmux | Apple USB 配对服务未就绪。请在驱动管理中安装或修复 Apple Devices/iTunes 支持，连接并解锁 iPhone 后重试。 | Apple USB 配對服務未就緒。請在驅動程式管理員中安裝或修復 Apple Devices/iTunes 支援，連接並解鎖 iPhone 後重試。 | Apple USB 配對服務未就緒。請在驅動程式管理員中安裝或修復 Apple Devices/iTunes 支援，連線並解鎖 iPhone 後重試。 | The Apple USB pairing service is not ready. Install or repair Apple Devices/iTunes support in the driver manager, connect and unlock the iPhone, then try again. | AppleのUSBペアリングサービスの準備ができていません。ドライバー管理でApple Devices/iTunesのサポートをインストールまたは修復し、iPhoneを接続してロックを解除してから、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureBridgeExited | 反向控制进程意外退出。请重试；若持续出现，请重新安装完整版本，并保留诊断日志中的退出信息。 | 反向控制程序意外結束。請重試；若持續出現，請重新安裝完整版本，並保留診斷記錄中的結束資訊。 | 反向控制處理程序意外結束。請重試；若持續發生，請重新安裝完整版本，並保留診斷記錄中的結束資訊。 | The reverse-control process exited unexpectedly. Retry; if it persists, reinstall the complete package and retain the exit details in the diagnostic log. | リモート操作のプロセスが予期せず終了しました。再試行してください。解決しない場合は、パッケージ一式を再インストールし、診断ログの終了時の詳細を保管してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureBridgeProtocol | 主程序与反向控制组件通信异常。请重新安装同一版本的完整安装包后重试。 | 主程式與反向控制元件通訊異常。請重新安裝相同版本的完整安裝套件後重試。 | 主程式與反向控制元件通訊異常。請重新安裝相同版本的完整安裝套件後重試。 | The application and reverse-control component could not communicate correctly. Reinstall the complete package of the same version and retry. | アプリとリモート操作コンポーネントが正しく通信できませんでした。同じバージョンのパッケージ一式を再インストールして、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureConnectionLost | 与 iPhone 的控制连接已中断。请保持设备解锁，检查 USB 数据线或无线网络连接后重试。 | 與 iPhone 的控制連線已中斷。請保持裝置解鎖，檢查 USB 數據線或無線網絡連線後重試。 | 與 iPhone 的控制連線已中斷。請保持裝置解鎖，檢查 USB 傳輸線或無線網路連線後重試。 | The control connection to the iPhone was interrupted. Keep the device unlocked, check the USB cable or wireless network, and retry. | iPhoneとの操作接続が中断されました。デバイスのロックを解除したまま、USBケーブルまたは無線ネットワークを確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureControlServiceTimeout | 设备的 CoreDevice 隧道或触控服务未及时就绪。请解锁并重新连接 iPhone，关闭其他正在使用设备的开发工具后重试；无线连接时请检查局域网和防火墙。 | 裝置的 CoreDevice 通道或觸控服務未及時就緒。請解鎖並重新連接 iPhone，關閉其他正在使用裝置的開發工具後重試；無線連線時請檢查區域網絡與防火牆。 | 裝置的 CoreDevice 通道或觸控服務未及時就緒。請解鎖並重新連接 iPhone，關閉其他正在使用裝置的開發工具後重試；無線連線時請檢查區域網路與防火牆。 | The device’s CoreDevice tunnel or touch service did not become ready in time. Unlock and reconnect the iPhone, close other developer tools using it, and retry. For wireless control, check the local network and firewall. | デバイスのCoreDeviceトンネルまたはタッチサービスが時間内に準備できませんでした。iPhoneのロックを解除して再接続し、そのデバイスを使っているほかの開発ツールを閉じてから、再試行してください。無線操作の場合は、ローカルネットワークとファイアウォールを確認してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureDeveloperMode | 此设备未开启开发者模式。请在 iPhone/iPad 的“设置 &gt; 隐私与安全性 &gt; 开发者模式”中开启并重启设备后重试。 | 此裝置未開啟開發者模式。請在 iPhone/iPad 的「設定 &gt; 私隱與安全性 &gt; 開發者模式」中開啟並重新啟動裝置後重試。 | 此裝置未開啟開發者模式。請在 iPhone/iPad 的「設定 &gt; 隱私權與安全性 &gt; 開發者模式」中開啟並重新啟動裝置後重試。 | Developer Mode is not enabled on this device. Turn it on under iPhone/iPad Settings → Privacy &amp; Security → Developer Mode, then restart the device and try again. | このデバイスではデベロッパモードが有効になっていません。iPhone/iPadの「設定」→「プライバシーとセキュリティ」→「デベロッパモード」でオンにし、デバイスを再起動してからもう一度お試しください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureDeveloperModeCheck | 暂时无法确认设备的开发者模式状态。请解锁 iPhone、完成信任提示并重新连接后重试；这不表示开发者模式一定未开启。 | 暫時無法確認裝置的開發者模式狀態。請解鎖 iPhone、完成信任提示並重新連接後重試；這不表示開發者模式一定未開啟。 | 暫時無法確認裝置的開發者模式狀態。請解鎖 iPhone、完成信任提示並重新連線後重試；這不表示開發者模式一定未開啟。 | The device's Developer Mode status could not be confirmed. Unlock the iPhone, complete any Trust prompt, reconnect, and retry. This does not necessarily mean Developer Mode is disabled. | デバイスのデベロッパモードの状態を確認できませんでした。iPhoneのロックを解除し、「信頼」の確認を済ませて再接続してから、再試行してください。デベロッパモードが無効とは限りません。 | ✅ 完全一致 | 保留 |
| UsbControlFailureDeveloperModeReveal | 未能确认“开发者模式”开关已显示。请解锁 iPhone/iPad、完成“信任此电脑”并检查 USB 连接后重试；若设置中已有该开关，也可手动开启、重启并确认。 | 無法確認「開發者模式」開關已顯示。請解鎖 iPhone/iPad、完成「信任此電腦」並檢查 USB 連接後重試；若設定中已有該開關，也可手動開啟、重新啟動並確認。 | 無法確認「開發者模式」開關已顯示。請解鎖 iPhone/iPad、完成「信任此電腦」並檢查 USB 連線後重試；若設定中已有該開關，也可手動開啟、重新啟動並確認。 | Could not confirm that the Developer Mode toggle is visible. Unlock the iPhone/iPad, complete Trust This Computer, check the USB connection, and retry. If the toggle is already in Settings, you can enable it manually, restart, and confirm. | デベロッパモードのスイッチが表示されたことを確認できませんでした。iPhone/iPadのロックを解除し、「このコンピュータを信頼」を完了してUSB接続を確認してから、再試行してください。スイッチがすでに「設定」にある場合は、手動で有効にし、再起動して確認することもできます。 | ✅ 完全一致 | 保留 |
| UsbControlFailureDeviceConnectionTimeout | 连接设备超时。请保持 iPhone 解锁，重新插拔 USB 数据线并确认已信任此电脑后重试。 | 連接裝置逾時。請保持 iPhone 解鎖，重新插拔 USB 數據線並確認已信任此電腦後重試。 | 連接裝置逾時。請保持 iPhone 解鎖，重新插拔 USB 傳輸線並確認已信任此電腦後重試。 | Connecting to the device timed out. Keep the iPhone unlocked, reconnect the USB cable and confirm that this computer is trusted, then retry. | デバイスへの接続がタイムアウトしました。iPhoneのロックを解除したままUSBケーブルをつなぎ直し、このコンピュータが信頼されていることを確認してから、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureDeviceLocked | iPhone 正处于锁定状态或正在等待输入密码。请解锁手机并保持亮屏，如有“信任此电脑”或密码提示请先在手机上完成，然后重新启动反向控制。 | iPhone 目前處於鎖定狀態或正在等待輸入密碼。請解鎖手機並保持亮屏，如有「信任此電腦」或密碼提示請先在手機上完成，然後重新啟動反向控制。 | iPhone 目前處於鎖定狀態或正在等待輸入密碼。請解鎖手機並保持螢幕開啟，如有「信任此電腦」或密碼提示請先在手機上完成，然後重新啟動反向控制。 | The iPhone is locked or waiting for its passcode. Unlock the phone and keep the screen on, complete any Trust This Computer or passcode prompt on the phone, then start reverse control again. | iPhoneがロックされているか、パスコードの入力待ちです。iPhoneのロックを解除して画面をオンにしたまま、「このコンピュータを信頼」やパスコードの確認をすべて済ませてから、もう一度リモート操作を開始してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureDeviceNotFound | 未找到这台设备的 Apple 网络配对会话。请先用数据线连接一次，在 Apple Devices 或 iTunes 中启用“通过 Wi-Fi 与此 iPhone 同步”，保持手机解锁并与电脑连接同一局域网后再试。 | 找不到此裝置的 Apple 網絡配對工作階段。請先用數據線連接一次，在 Apple Devices 或 iTunes 中啟用「透過 Wi-Fi 與此 iPhone 同步」，保持手機解鎖並與電腦連接同一區域網絡後再試。 | 找不到此裝置的 Apple 網路配對工作階段。請先用傳輸線連線一次，在 Apple Devices 或 iTunes 中啟用「透過 Wi-Fi 與此 iPhone 同步」，保持手機解鎖並與電腦連線同一區域網路後再試。 | The Apple network-pairing session for this device was not found. Connect by cable once and enable “Sync with this iPhone over Wi-Fi” in Apple Devices or iTunes. Keep the phone unlocked and on the same local network as the computer, then try again. | このデバイスのAppleネットワークペアリングのセッションが見つかりませんでした。一度ケーブルで接続し、Apple DevicesまたはiTunesで「Wi-FiでこのiPhoneと同期」を有効にしてください。iPhoneのロックを解除したまま、コンピュータと同じローカルネットワークに接続して、もう一度お試しください。 | ❌ 含义不一致 → ✅ 已修复 | 补齐英文缺少的保持解锁、与电脑位于同一局域网条件 |
| UsbControlFailureGateUnavailable | 设备未确认 CoreDevice 触控认证已开启。为避免输入被系统静默丢弃，反向控制未启动。 | 裝置未確認 CoreDevice 觸控驗證已開啟。為避免輸入被系統靜默丟棄，反向控制未啟動。 | 裝置未確認 CoreDevice 觸控驗證已開啟。為避免輸入被系統靜默丟棄，反向控制未啟動。 | The device did not confirm that CoreDevice touch authentication is enabled. Reverse control was not started to prevent silent input loss. | デバイスから、CoreDeviceのタッチ認証が有効であるという確認が得られませんでした。入力が気づかれないまま失われるのを防ぐため、リモート操作は開始しませんでした。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| UsbControlFailureIdentityMismatch | 连接到的 iPhone 与所选设备不一致。请检查设备绑定，重新选择正确的 iPhone 后启动控制。 | 連接的 iPhone 與所選裝置不一致。請檢查裝置綁定，重新選擇正確的 iPhone 後啟動控制。 | 連線的 iPhone 與所選裝置不一致。請檢查裝置繫結，重新選擇正確的 iPhone 後啟動控制。 | The connected iPhone does not match the selected device. Check the device binding and select the correct iPhone before starting control. | 接続中のiPhoneが、選択したデバイスと一致しません。デバイスの紐づけを確認し、正しいiPhoneを選択してから、操作を開始してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageCache | 无法保存开发者镜像缓存。请检查用户目录所在磁盘的剩余空间和写入权限，确认安全软件没有阻止写入后重试。 | 無法儲存開發者映像檔快取。請檢查使用者目錄所在磁碟的剩餘空間與寫入權限，確認安全軟件未阻擋寫入後重試。 | 無法儲存開發者映像檔快取。請檢查使用者目錄所在磁碟的剩餘空間與寫入權限，確認安全軟體未阻擋寫入後重試。 | The developer image cache could not be saved. Check free space and write permissions on the drive containing your user folder, and ensure security software is not blocking the write before retrying. | 開発者イメージのキャッシュを保存できませんでした。ユーザーフォルダがあるドライブの空き容量と書き込み権限を確認し、セキュリティソフトが書き込みを妨げていないことを確かめてから、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageDownload | 开发者镜像下载失败或超时。请检查 GitHub 网络连接后重试，也可通过 IPHONE_MIRROR_DDI_DIR 提供官方本地镜像。 | 開發者映像檔下載失敗或逾時。請檢查 GitHub 網絡連線後重試，也可透過 IPHONE_MIRROR_DDI_DIR 提供官方本機映像檔。 | 開發者映像檔下載失敗或逾時。請檢查 GitHub 網路連線後重試，也可透過 IPHONE_MIRROR_DDI_DIR 提供官方本機映像檔。 | The developer image download failed or timed out. Check the GitHub network connection, or provide an official local image through IPHONE_MIRROR_DDI_DIR. | 開発者イメージのダウンロードに失敗したか、タイムアウトしました。GitHubへのネットワーク接続を確認するか、IPHONE_MIRROR_DDI_DIRで公式のローカルイメージを指定してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageIncompatible | 当前开发者镜像与设备或控制组件不兼容。请更新到最新完整版本后重试；仍失败时请提交设备系统版本和诊断日志。 | 目前開發者映像與裝置或控制元件不相容。請更新至最新完整版本後重試；仍失敗時請提交裝置系統版本與診斷記錄。 | 目前開發者映像檔與裝置或控制元件不相容。請更新至最新完整版本後重試；仍失敗時請提交裝置系統版本與診斷記錄。 | The developer image is incompatible with the device or control component. Update to the latest complete package and retry. If it persists, submit the device OS version and diagnostic log. | 開発者イメージが、デバイスまたは操作コンポーネントと互換性がありません。完全版パッケージを最新にして再試行してください。解消しない場合は、デバイスのOSバージョンと診断ログを送ってください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageIntegrity | 开发者镜像校验失败，下载文件可能不完整或已损坏。请检查网络或更换镜像源后重试。 | 開發者映像檔驗證失敗，下載檔案可能不完整或已損壞。請檢查網絡或更換來源後重試。 | 開發者映像檔驗證失敗，下載檔案可能不完整或已損壞。請檢查網路或更換來源後重試。 | Developer image verification failed. The download may be incomplete or damaged. Check the network or use another image source, then retry. | 開発者イメージの検証に失敗しました。ダウンロードが不完全か、ファイルが破損している可能性があります。ネットワークを確認するか別のイメージ取得元を使ってから、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageMount | 设备未能完成开发者镜像挂载。请解锁并重新连接 iPhone，关闭其他正在使用设备的开发工具后重试；若持续失败，请更新完整版本并保留诊断日志。 | 裝置未能完成開發者映像掛載。請解鎖並重新連接 iPhone，關閉其他正在使用裝置的開發工具後重試；若持續失敗，請更新完整版本並保留診斷記錄。 | 裝置未能完成開發者映像檔掛載。請解鎖並重新連線 iPhone，關閉其他正在使用裝置的開發工具後重試；若持續失敗，請更新完整版本並保留診斷記錄。 | The device could not mount the developer image. Unlock and reconnect the iPhone, close other development tools using it, and retry. If it persists, update the complete package and retain the diagnostic log. | デバイスに開発者イメージをマウントできませんでした。iPhoneのロックを解除してつなぎ直し、使用中の他の開発ツールを閉じてから、再試行してください。解消しない場合は、完全版パッケージを更新し、診断ログを保管しておいてください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImagePrepareTimeout | 开发者镜像准备或挂载超时。请保持设备解锁，关闭其他正在使用设备的开发工具后重试。 | 開發者映像準備或掛載逾時。請保持裝置解鎖，關閉其他正在使用裝置的開發工具後重試。 | 開發者映像檔準備或掛載逾時。請保持裝置解鎖，關閉其他正在使用裝置的開發工具後重試。 | Developer image preparation or mounting timed out. Keep the device unlocked, close other development tools using it, and retry. | 開発者イメージの準備またはマウントがタイムアウトしました。デバイスのロックを解除したまま、そのデバイスを使っているほかの開発ツールを閉じて、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageRateLimited | GitHub 暂时限制了开发者镜像下载请求。请稍后重试。 | GitHub 暫時限制了開發者映像下載請求。請稍後重試。 | GitHub 暫時限制了開發者映像檔下載請求。請稍後重試。 | GitHub has temporarily rate limited developer image downloads. Please retry later. | GitHubが開発者イメージのダウンロードを一時的に制限しています。しばらくしてから再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageRemount | 无法刷新旧的 Personalized Developer Disk Image。请关闭可能占用设备的 Xcode/开发工具，重启 iPhone 后再试。 | 無法重新整理舊的 Personalized Developer Disk Image。請關閉可能佔用裝置的 Xcode/開發工具，重新啟動 iPhone 後再試。 | 無法重新整理舊的 Personalized Developer Disk Image。請關閉可能佔用裝置的 Xcode/開發工具，重新啟動 iPhone 後再試。 | The old Personalized Developer Disk Image could not be refreshed. Close Xcode or other tools using the device, restart the iPhone, and try again. | 古いPersonalized Developer Disk Imageを更新できませんでした。Xcodeやデバイスを使用している他のツールを閉じ、iPhoneを再起動してから、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageRequired | 设备尚未挂载 Personalized Developer Disk Image。请使用与设备系统匹配的官方 Xcode 开发者镜像完成挂载后重试。 | 裝置尚未掛載 Personalized Developer Disk Image。請使用與裝置系統匹配的官方 Xcode 開發者映像檔完成掛載後重試。 | 裝置尚未掛載 Personalized Developer Disk Image。請使用與裝置系統相符的官方 Xcode 開發者映像檔完成掛載後重試。 | The device has not mounted the Personalized Developer Disk Image. Mount the official Xcode image matching the device system, then try again. | デバイスにPersonalized Developer Disk Imageがマウントされていません。デバイスのシステムに合った公式のXcodeイメージをマウントしてから、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageServiceTimeout | 设备的开发者镜像服务未及时响应。请保持 iPhone 解锁，重新连接设备后重试。 | 裝置的開發者映像服務未及時回應。請保持 iPhone 解鎖，重新連接裝置後重試。 | 裝置的開發者映像檔服務未及時回應。請保持 iPhone 解鎖，重新連線裝置後重試。 | The device's developer image service did not respond in time. Keep the iPhone unlocked, reconnect it, and retry. | デバイスの開発者イメージサービスが時間内に応答しませんでした。iPhoneのロックを解除したまま再接続して、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageServiceUnavailable | 无法打开设备的开发者镜像服务。请解锁 iPhone、确认已开启开发者模式，关闭其他正在使用设备的开发工具后重试。 | 無法開啟裝置的開發者映像服務。請解鎖 iPhone、確認已開啟開發者模式，關閉其他正在使用裝置的開發工具後重試。 | 無法開啟裝置的開發者映像檔服務。請解鎖 iPhone、確認已開啟開發者模式，關閉其他正在使用裝置的開發工具後重試。 | The device's developer image service could not be opened. Unlock the iPhone, confirm Developer Mode is enabled, close other development tools using the device, and retry. | デバイスの開発者イメージサービスを開けませんでした。iPhoneのロックを解除し、デベロッパモードが有効であることを確認して、そのデバイスを使っているほかの開発ツールを閉じてから、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageTss | Apple 镜像签名请求失败或返回了无效响应。请检查网络及代理设置后重试；若持续失败，请保留诊断日志。 | Apple 映像簽署請求失敗或傳回無效回應。請檢查網絡及代理設定後重試；若持續失敗，請保留診斷記錄。 | Apple 映像檔簽章請求失敗或傳回無效回應。請檢查網路與 Proxy 設定後重試；若持續失敗，請保留診斷記錄。 | Apple image personalization failed or returned an invalid response. Check the network and proxy settings and retry. Retain the diagnostic log if it persists. | Appleのイメージ個別化に失敗したか、無効な応答が返されました。ネットワークとプロキシの設定を確認して再試行してください。解消しない場合は、診断ログを保管しておいてください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageTssRejected | Apple 未接受当前开发者镜像的签名请求。请更新到最新完整版本，重新连接设备后重试；仍失败时请提交诊断日志。 | Apple 未接受目前開發者映像的簽署請求。請更新至最新完整版本，重新連接裝置後重試；仍失敗時請提交診斷記錄。 | Apple 未接受目前開發者映像檔的簽章請求。請更新至最新完整版本，重新連線裝置後重試；仍失敗時請提交診斷記錄。 | Apple did not accept personalization of the developer image. Update to the latest complete package, reconnect, and retry. If it persists, submit the diagnostic log. | Appleが開発者イメージのパーソナライズを受け付けませんでした。最新のパッケージ一式にアップデートし、再接続して再試行してください。解決しない場合は、診断ログを送信してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageTssTimeout | Apple 开发者镜像签名请求超时。请检查电脑能否访问 gs.apple.com，然后重试。 | Apple 開發者映像簽署請求逾時。請檢查電腦能否存取 gs.apple.com，然後重試。 | Apple 開發者映像檔簽章請求逾時。請檢查電腦能否存取 gs.apple.com，然後重試。 | Apple developer image personalization timed out. Check this computer's access to gs.apple.com, then retry. | Appleの開発者イメージのパーソナライズがタイムアウトしました。このコンピュータからgs.apple.comへアクセスできるか確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageTssUnavailable | Apple 签名服务暂时不可用或请求受限，自动重试后仍未成功。请稍后重试，并检查 Apple 服务的网络连接。 | Apple 簽署服務暫時無法使用或請求受限，自動重試後仍未成功。請稍後重試，並檢查 Apple 服務的網絡連線。 | Apple 簽章服務暫時無法使用或請求受限，自動重試後仍未成功。請稍後重試，並檢查 Apple 服務的網路連線。 | Apple's signing service is temporarily unavailable or rate limited, and the automatic retry did not succeed. Retry later and check connectivity to Apple services. | Appleの署名サービスが一時的に利用できないか、リクエストが制限されています。自動再試行も成功しませんでした。しばらくしてから再試行し、Appleのサービスへの接続を確認してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageUploadFailed | 开发者镜像传输失败。请保持 iPhone 解锁，检查设备连接并重新连接后重试。 | 開發者映像傳輸失敗。請保持 iPhone 解鎖，檢查裝置連線並重新連接後重試。 | 開發者映像檔傳輸失敗。請保持 iPhone 解鎖，檢查裝置連線並重新連線後重試。 | The developer image transfer failed. Keep the iPhone unlocked, check the connection, reconnect, and retry. | 開発者イメージの転送に失敗しました。iPhoneのロックを解除したまま、接続を確認して再接続し、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageUploadTimeout | 向设备传输开发者镜像超时。请保持 iPhone 解锁，检查连接后重试。 | 向裝置傳輸開發者映像逾時。請保持 iPhone 解鎖，檢查連線後重試。 | 向裝置傳輸開發者映像檔逾時。請保持 iPhone 解鎖，檢查連線後重試。 | Transferring the developer image to the device timed out. Keep the iPhone unlocked, check the connection, and retry. | 開発者イメージのデバイスへの転送がタイムアウトしました。iPhoneのロックを解除したまま、接続を確認して再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureImageVerification | 设备报告挂载完成，但未确认开发者镜像可用。请重新连接后重试；仍失败时请重启 iPhone，并保留诊断日志。 | 裝置回報掛載完成，但未確認開發者映像可用。請重新連接後重試；仍失敗時請重新啟動 iPhone，並保留診斷記錄。 | 裝置回報掛載完成，但未確認開發者映像檔可用。請重新連線後重試；仍失敗時請重新啟動 iPhone，並保留診斷記錄。 | The device reported a mount but the developer image could not be confirmed. Reconnect and retry. If it persists, restart the iPhone and retain the diagnostic log. | デバイスはマウント済みと報告しましたが、開発者イメージを確認できませんでした。再接続して再試行してください。解決しない場合は、iPhoneを再起動して診断ログを保管してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureMux | Apple USB 服务在设备握手时中断了连接。请保持设备解锁并确认已信任此电脑；若仍失败，请重新插拔数据线后重试。 | Apple USB 服務在裝置握手時中斷連線。請保持裝置解鎖並確認已信任此電腦；若仍失敗，請重新插拔數據線後重試。 | Apple USB 服務在裝置握手時中斷連線。請保持裝置解鎖並確認已信任此電腦；若仍失敗，請重新插拔傳輸線後重試。 | The Apple USB service disconnected during the device handshake. Keep the device unlocked and trusted, reconnect the cable, and try again. | デバイスとのハンドシェイク中に、AppleのUSBサービスが切断されました。デバイスのロックを解除して信頼した状態でケーブルをつなぎ直し、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureNoDetails | USB 触控桥接器未提供错误详情。请确认设备已通过 USB 连接并已信任此电脑。 | USB 觸控橋接器未提供錯誤詳細資料。請確認裝置已透過 USB 連接並已信任此電腦。 | USB 觸控橋接器未提供錯誤詳細資料。請確認裝置已透過 USB 連線並已信任此電腦。 | The USB touch bridge provided no error details. Confirm the device is connected by USB and trusted. | USBタッチブリッジからエラーの詳細が提供されませんでした。デバイスがUSBで接続され、信頼されていることを確認してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureNotTrusted | 此 iPhone 尚未信任当前 Windows 帐户。请保持手机解锁，重新插拔数据线并在手机上点按“信任”。 | 此 iPhone 尚未信任目前 Windows 帳戶。請保持手機解鎖，重新插拔數據線並在手機上點按「信任」。 | 此 iPhone 尚未信任目前 Windows 帳戶。請保持手機解鎖，重新插拔傳輸線並在手機上點一下「信任」。 | This iPhone has not trusted the current Windows account. Keep the phone unlocked, reconnect the cable, and tap “Trust” on the phone. | このiPhoneは、現在のWindowsアカウントを信頼していません。iPhoneのロックを解除したままケーブルをつなぎ直し、iPhoneで「信頼」をタップしてください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureRecoveryExhausted | 反向控制连接中断，自动恢复多次后仍未成功。请解锁并重新连接设备，再启动反向控制；若反复出现，请提交诊断日志。 | 反向控制連線中斷，多次自動復原後仍未成功。請解鎖並重新連接裝置，再啟動反向控制；若反覆發生，請提供診斷記錄。 | 反向控制連線中斷，多次自動復原後仍未成功。請解鎖並重新連接裝置，再啟動反向控制；若反覆發生，請提供診斷記錄。 | The control connection was interrupted and automatic recovery failed after several attempts. Unlock and reconnect the device, then restart reverse control. If this repeats, provide the diagnostic log. | 操作接続が中断され、何度か試した自動復旧にも失敗しました。デバイスのロックを解除して再接続し、リモート操作をもう一度開始してください。繰り返し発生する場合は、診断ログを提供してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureRuntimeInvalid | 反向控制组件校验未通过。请使用最新完整安装包重新安装，不要只替换主程序或桥接器。具体校验信息已记录在诊断日志中。 | 反向控制元件驗證未通過。請使用最新完整安裝套件重新安裝，不要只替換主程式或橋接器。診斷記錄中已保留具體驗證資訊。 | 反向控制元件驗證未通過。請使用最新完整安裝套件重新安裝，不要只替換主程式或橋接器。診斷記錄中已保留具體驗證資訊。 | Reverse-control component verification failed. Reinstall the latest complete package instead of replacing individual executables. Verification details are recorded in the diagnostic log. | リモート操作コンポーネントの検証に失敗しました。実行ファイルを個別に置き換えず、最新のパッケージ一式を再インストールしてください。検証の詳細は診断ログに記録されています。 | ✅ 完全一致 | 保留 |
| UsbControlFailureStartTimeout | 反向控制服务启动超时。请重新连接设备后重试，并查看诊断日志中的最后启动阶段。 | 反向控制服務啟動逾時。請重新連接裝置後重試，並查看診斷記錄中的最後啟動階段。 | 反向控制服務啟動逾時。請重新連線裝置後重試，並查看診斷記錄中的最後啟動階段。 | The reverse-control service did not start in time. Reconnect the device and retry. Check the last startup stage in the diagnostic log. | リモート操作のサービスが時間内に起動しませんでした。デバイスを再接続して、再試行してください。診断ログで最後の起動ステージを確認してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureTouchService | 设备暂未提供触控反向控制服务。请保持设备解锁并信任此电脑后重试；若仍失败，请改用蓝牙反向控制或无线反向控制。 | 裝置暫未提供觸控反向控制服務。請保持裝置解鎖並信任此電腦後重試；若仍失敗，請改用藍牙反向控制或無線反向控制。 | 裝置暫未提供觸控反向控制服務。請保持裝置解鎖並信任此電腦後重試；若仍失敗，請改用藍牙反向控制或無線反向控制。 | The device has not provided the touch-control service. Keep it unlocked and trusted, then try again; otherwise use Bluetooth or wireless control. | デバイスがタッチ操作サービスを提供していません。ロックを解除して信頼した状態でもう一度お試しください。それでも解消しない場合は、Bluetooth操作または無線操作を使ってください。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| UsbControlFailureTouchSurface | 已建立 CoreDevice 会话，但开发者镜像没有发布 mainTouchscreen（257）触控面。请重启 iPhone 后重试。 | 已建立 CoreDevice 工作階段，但開發者映像檔沒有發佈 mainTouchscreen（257）觸控面。請重新啟動 iPhone 後重試。 | 已建立 CoreDevice 工作階段，但開發者映像檔沒有發布 mainTouchscreen（257）觸控面。請重新啟動 iPhone 後重試。 | A CoreDevice session was established, but the developer image did not publish the mainTouchscreen (257) touch surface. Restart the iPhone and try again. | CoreDeviceのセッションは確立されましたが、開発者イメージがmainTouchscreen（257）のタッチ面を公開しませんでした。iPhoneを再起動してもう一度お試しください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureUnknown | 反向控制启动失败，暂未识别具体原因。请重新连接设备后重试；若持续出现，请提交诊断日志。 | 反向控制啟動失敗，暫未識別具體原因。請重新連接裝置後重試；若持續出現，請提交診斷記錄。 | 反向控制啟動失敗，暫未識別具體原因。請重新連線裝置後重試；若持續發生，請提交診斷記錄。 | Reverse control could not start for an unidentified reason. Reconnect the device and retry. If it persists, submit the diagnostic log. | 原因が特定できず、リモート操作を開始できませんでした。デバイスをつなぎ直して再試行してください。解消しない場合は、診断ログを送ってください。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称 |
| UsbControlFailureUnknownCodeFormat | 反向控制启动失败（错误代码：{0}）。请重新连接设备后重试；若持续出现，请提交诊断日志。 | 反向控制啟動失敗（錯誤代碼：{0}）。請重新連接裝置後重試；若持續出現，請提交診斷記錄。 | 反向控制啟動失敗（錯誤代碼：{0}）。請重新連線裝置後重試；若持續發生，請提交診斷記錄。 | Reverse control could not start (error code: {0}). Reconnect the device and retry. If it persists, submit the diagnostic log. | リモート操作を開始できませんでした（エラーコード: {0}）。デバイスを再接続して、再試行してください。解決しない場合は、診断ログを送信してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureUnsupportedIos | 设备拒绝了媒体流认证（9021），且没有可用的直接 Universal HID 触控通道。请重启 iPhone 后重试；若仍失败，请使用蓝牙反向控制。 | 裝置拒絕了媒體串流驗證（9021），且沒有可用的直接 Universal HID 觸控通道。請重新啟動 iPhone 後重試；若仍失敗，請使用藍牙反向控制。 | 裝置拒絕了媒體串流驗證（9021），且沒有可用的直接 Universal HID 觸控通道。請重新啟動 iPhone 後重試；若仍失敗，請使用藍牙反向控制。 | The device rejected media-stream authentication (9021), and no direct Universal HID touch channel is available. Restart the iPhone and try again; if it still fails, use Bluetooth control. | デバイスがメディアストリーム認証（9021）を拒否し、Universal HIDのタッチチャンネルを直接使うこともできません。iPhoneを再起動してもう一度お試しください。それでも失敗する場合は、Bluetooth操作を使ってください。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称 |
| UsbControlFailureWiredDeviceNotFound | 未能在 USB 连接中找到这台设备的控制通道。投屏运行时系统可能暂时无法访问设备：请先停止投屏再启动反向控制，或重新插拔数据线、解锁手机并确认已信任此电脑后重试。 | 未能在 USB 連線中找到此裝置的控制通道。螢幕鏡像運行時系統可能暫時無法存取裝置：請先停止螢幕鏡像再啟動反向控制，或重新插拔數據線、解鎖手機並確認已信任此電腦後重試。 | 未能在 USB 連線中找到此裝置的控制通道。螢幕鏡像執行時系統可能暫時無法存取裝置：請先停止螢幕鏡像再啟動反向控制，或重新插拔傳輸線、解鎖手機並確認已信任此電腦後重試。 | The control channel for this device was not found over USB. While mirroring, the system may temporarily lose access to the device: stop the mirror before starting reverse control, or replug the cable, unlock the iPhone, confirm it trusts this PC, and retry. | USB経由でこのデバイスの操作チャンネルが見つかりませんでした。ミラーリング中は、システムがデバイスへのアクセスを一時的に失うことがあります。リモート操作を開始する前にミラーリングを停止するか、ケーブルを抜き差ししてiPhoneのロックを解除し、このPCが信頼されていることを確認してから、再試行してください。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| UsbControlFailureWirelessAddressResolution | 已发现无线服务，但未解析到可连接的设备地址。请保持 iPhone 解锁，确认手机和电脑处于可互通的同一局域网，并检查路由器的客户端隔离及 mDNS（UDP 5353）限制后重试。 | 已找到無線服務，但未解析出可連接的裝置位址。請保持 iPhone 解鎖，確認手機與電腦位於可互通的同一區域網絡，並檢查路由器的用戶端隔離及 mDNS（UDP 5353）限制後重試。 | 已找到無線服務，但未解析出可連線的裝置位址。請保持 iPhone 解鎖，確認手機與電腦位於可互通的同一區域網路，並檢查路由器的用戶端隔離及 mDNS（UDP 5353）限制後重試。 | Wireless services were found, but no usable device address was resolved. Keep the iPhone unlocked, ensure it and the computer can communicate on the same local network, and check router client isolation and mDNS (UDP 5353) restrictions before retrying. | 無線サービスは見つかりましたが、使えるデバイスのアドレスを解決できませんでした。iPhoneのロックを解除したまま、iPhoneとコンピュータが同じローカルネットワークで通信できることを確かめ、ルーターのクライアント分離とmDNS（UDP 5353）の制限を確認してから、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureWirelessDiscoveryUnavailable | 电脑无法启动无线设备发现。请确认网络适配器已启用、防火墙允许本地网络发现，并检查 UDP 5353 端口是否被其他程序独占，然后重试。 | 電腦無法啟動無線裝置搜尋。請確認網絡介面卡已啟用、防火牆允許區域網絡搜尋，並檢查 UDP 5353 連接埠是否被其他程式獨佔，然後重試。 | 電腦無法啟動無線裝置探索。請確認網路介面卡已啟用、防火牆允許區域網路探索，並檢查 UDP 5353 連接埠是否被其他程式獨佔，然後重試。 | The PC could not start wireless device discovery. Check that a network adapter is enabled, the firewall allows local discovery, and another program is not exclusively using UDP port 5353, then retry. | PCで無線デバイスの検出を開始できませんでした。ネットワークアダプターが有効か、ファイアウォールがローカルの検出を許可しているか、他のプログラムがUDPポート5353を占有していないかを確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureWirelessNotDiscoverable | 未发现 iPhone 的无线 CoreDevice 服务。请保持 iPhone 解锁、与电脑处于同一局域网，并允许 Windows 防火墙通过本地网络发现。 | 未找到 iPhone 的無線 CoreDevice 服務。請保持 iPhone 解鎖、與電腦處於同一區域網絡，並允許 Windows 防火牆透過本機網絡尋找。 | 未找到 iPhone 的無線 CoreDevice 服務。請保持 iPhone 解鎖、與電腦處於同一區域網路，並允許 Windows 防火牆透過本機網路尋找。 | The iPhone wireless CoreDevice service was not found. Keep the iPhone unlocked on the same local network and allow Windows firewall discovery. | iPhoneの無線CoreDeviceサービスが見つかりませんでした。iPhoneのロックを解除したまま同じローカルネットワークに接続し、Windowsファイアウォールでデバイスの検出を許可してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureWirelessPairingFailed | 无线 CoreDevice 配对或隧道建立失败。请先用 USB 连接一次并完成初始化，随后确认 iPhone 已解锁且局域网未隔离。 | 無線 CoreDevice 配對或通道建立失敗。請先用 USB 連接一次並完成初始化，然後確認 iPhone 已解鎖且區域網絡未隔離用戶端。 | 無線 CoreDevice 配對或通道建立失敗。請先用 USB 連線一次並完成初始化，然後確認 iPhone 已解鎖且區域網路未隔離用戶端。 | Wireless CoreDevice pairing or tunnel setup failed. Connect by USB once and complete initialization, then confirm the iPhone is unlocked and the network does not isolate clients. | 無線CoreDeviceのペアリングまたはトンネルの設定に失敗しました。一度USBで接続して初期化を完了し、iPhoneのロックが解除されていること、ネットワークがクライアント同士を分離していないことを確認してください。 | ✅ 完全一致 | 保留 |
| UsbControlFailureWirelessPairingRequired | 当前 Windows 帐户尚未完成此设备的无线 CoreDevice 配对。请先通过 USB 连接并解锁 iPhone，完成一次 USB 反向控制初始化后再试无线反向控制。 | 目前 Windows 帳戶尚未完成此裝置的無線 CoreDevice 配對。請先透過 USB 連接並解鎖 iPhone，完成一次 USB 反向控制初始化後再試無線反向控制。 | 目前 Windows 帳戶尚未完成此裝置的無線 CoreDevice 配對。請先透過 USB 連線並解鎖 iPhone，完成一次 USB 反向控制初始化後再試無線反向控制。 | This Windows account has not completed wireless CoreDevice pairing for this device. Connect by USB and unlock the iPhone, complete USB reverse-control initialization once, then try wireless control again. | このWindowsアカウントでは、このデバイスの無線CoreDeviceペアリングが完了していません。USBで接続してiPhoneのロックを解除し、USBでのリモート操作の初期化を一度完了してから、もう一度無線操作をお試しください。 | ❌ 术语不一致 → ✅ 已修复 | 统一反向控制正式名称；统一香港繁体中文既有用语 |
| UsbControlNeedsConnection | 需要 USB 连接 | 需要 USB 連接 | 需要 USB 連線 | USB connection required | USB接続が必要です | ✅ 完全一致 | 保留 |
| UsbControlOff | 有线控制未启用 | 有線控制未啟用 | 有線控制未啟用 | Wired control is off | 有線操作はオフです | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| UsbControlOperationFailedFormat | 有线控制操作失败：{0} | 有線控制操作失敗：{0} | 有線控制操作失敗：{0} | Wired control operation failed: {0} | 有線操作に失敗しました: {0} | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| UsbControlPrerequisite | 请通过 USB 连接 iPhone 或 iPad，并在设备上选择“信任此电脑”，然后启用有线控制。 | 請透過 USB 連接 iPhone 或 iPad，並在裝置上選擇「信任此電腦」，然後啟用有線控制。 | 請透過 USB 連線 iPhone 或 iPad，並在裝置上選擇「信任此電腦」，然後啟用有線控制。 | Connect an iPhone or iPad by USB and trust this computer before enabling wired control. | 有線操作を有効にする前に、iPhoneまたはiPadをUSBで接続し、このコンピュータを信頼してください。 | ❌ 含义不一致 → ✅ 已修复 | 信任对象是电脑，不是 iPhone；同时统一有线控制名称 |
| UsbControlRetry | 重试有线控制 | 重試有線控制 | 重試有線控制 | Retry wired control | 有線操作を再試行 | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| UsbControlStarting | 正在连接反向控制 | 正在連接反向控制 | 正在連線反向控制 | Connecting reverse control | リモート操作に接続しています | ✅ 完全一致 | 保留 |
| UsbControlStopping | 正在关闭有线控制 | 正在關閉有線控制 | 正在關閉有線控制 | Stopping wired control | 有線操作を停止しています | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| UsbControlTitle | 有线控制 | 有線控制 | 有線控制 | Wired control | 有線操作 | ❌ 术语不一致 → ✅ 已修复 | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 |
| UsbModeAdvantageTitle | 优点 | 優點 | 優點 | Advantages | 長所 | ✅ 完全一致 | 保留 |
| UsbModeAirPlayAdvantage | 保留真实状态栏。iPad 使用横竖屏对称的显示能力，避免方向变化时重启 USB；实际源分辨率由设备决定，可能低于面板原生像素。视频 App 可以尝试外接播放。 | 保留真實狀態列。iPad 使用橫直向對稱的顯示能力，避免方向變化時重新啟動 USB；實際來源解像度由裝置決定，可能低於面板原生像素。影片 App 可以嘗試外接播放。 | 保留真實狀態列。iPad 使用橫直向對稱的顯示能力，避免方向變化時重新啟動 USB；實際來源解析度由裝置決定，可能低於面板原生像素。影片 App 可以嘗試外接播放。 | Keeps the real status bar. iPad advertises the same display bounds in both orientations to avoid restarting USB on rotation. The device chooses the source resolution, which may be below panel-native pixels. Video apps may use external playback. | 本物のステータスバーを残します。iPadは向きを変えても同じ表示範囲を伝えるため、回転してもUSBを再起動しません。元の解像度はデバイスが決めるため、画面本来の画素数より低くなることがあります。動画アプリは外部再生を使えます。 | ✅ 完全一致 | 保留 |
| UsbModeAirPlayDisadvantage | 外接内容的分辨率无法保证与手机和窗口完美自适应，可能出现裁切、比例异常或画面显示不全。 | 外接內容的解像度無法保證與手機和視窗完美自適應，可能出現裁切、比例異常或畫面顯示不全。 | 外接內容的解析度無法保證與手機和視窗完美自適應，可能出現裁切、比例異常或畫面顯示不全。 | External-content resolution cannot be guaranteed to adapt perfectly to both the phone and the window. Content may be cropped, use the wrong aspect ratio, or be partly off-screen. | 外部コンテンツの解像度は、iPhoneとウィンドウの両方に完全に合わせられるとは限りません。コンテンツが切り取られたり、縦横比が合わなかったり、一部が画面の外に出たりすることがあります。 | ✅ 完全一致 | 保留 |
| UsbModeAirPlayLabel | B AirPlay（实验） | B AirPlay（實驗） | B AirPlay（實驗） | B AirPlay (experimental) | B AirPlay（実験的） | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| UsbModeAirPlayNotice | 需要自定义时，连续点击右下角版本号 5 次开启高级模式。自定义 HPD1 尺寸存在风险，错误参数可能导致黑屏、裁切或 USB 重连失败。 | 需要自訂時，連續按右下角版本號 5 次開啟進階模式。自訂 HPD1 尺寸存在風險，錯誤參數可能導致黑畫面、裁切或 USB 重新連接失敗。 | 需要自訂時，連續按右下角版本號 5 次開啟進階模式。自訂 HPD1 尺寸存在風險，錯誤參數可能導致黑畫面、裁切或 USB 重新連線失敗。 | For custom sizing, click the version in the lower-right corner five times to enable Advanced mode. Custom HPD1 dimensions are risky and can cause a black screen, cropping, or failed USB reconnection. | サイズを自由に指定するには、右下のバージョンを5回クリックして詳細モードを有効にします。HPD1のサイズを自由に変えると、画面が黒くなる、切り取られる、USBを再接続できなくなるなどの危険があります。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| UsbModeAisiAdvantage | 采用爱思同类方案，发送 Valeria=false 并固定请求 1565×1565，减少不同设备之间的分辨率协商差异。 | 採用愛思同類方案，發送 Valeria=false 並固定請求 1565×1565，減少不同裝置之間的解像度協商差異。 | 採用愛思同類方案，傳送 Valeria=false 並固定請求 1565×1565，減少不同裝置之間的解析度協商差異。 | Uses an Aisi-style configuration with Valeria=false and a fixed 1565×1565 request, reducing display-negotiation differences between devices. | Valeria=falseと固定の1565×1565の要求による、Aisi方式の設定を使います。デバイスごとのディスプレイ交渉の違いを減らせます。 | ✅ 完全一致 | 保留 |
| UsbModeAisiDisadvantage | 方形目标会限制源画面的清晰度，不适合画质优先；横屏内容还可能出现缩放、黑边或比例不理想。 | 方形目標會限制原始畫面的畫質，不適合畫質優先；橫向螢幕內容還可能出現縮放、黑邊或比例不理想。 | 方形目標會限制原始畫面的畫質，不適合畫質優先；橫向螢幕內容還可能出現縮放、黑邊或比例不理想。 | The square target limits source clarity and is unsuitable when image quality is the priority. Landscape content may also be scaled, letterboxed, or shown at an imperfect ratio. | 正方形の目標サイズのため、ソースの鮮明さが制限され、画質を優先する用途には向きません。横向きのコンテンツは、拡大縮小されたり、レターボックスになったり、比率が崩れたりすることがあります。 | ✅ 完全一致 | 保留 |
| UsbModeAisiLabel | C 爱思模式 | C 愛思模式 | C 愛思模式 | C Aisi mode | C Aisiモード | ✅ 完全一致 | 保留 |
| UsbModeAisiNotice | 此模式不会使用本项目的原生分辨率探测和横竖屏自适应重配。 | 此模式不會使用本項目的原始解像度偵測和橫直螢幕自動調整。 | 此模式不會使用本專案的原始解析度偵測和橫直向自動調整。 | This mode does not use this application's native-resolution probing or adaptive orientation reconfiguration. | このモードでは、このアプリのネイティブ解像度の検出と、向きに合わせた自動再構成は使われません。 | ✅ 完全一致 | 保留 |
| UsbModeDemoAdvantage | 发送 Valeria=true 和设备原生 DisplaySize，由 iOS 输出完整的手机镜像，并保持固定演示状态。兼容性和画面完整性最高，推荐日常使用。 | 發送 Valeria=true 和裝置原始 DisplaySize，由 iOS 輸出完整的手機鏡像，並保持固定示範狀態。相容性和畫面完整性最高，推薦日常使用。 | 傳送 Valeria=true 和裝置原始 DisplaySize，由 iOS 輸出完整的手機鏡像，並保持固定示範狀態。相容性和畫面完整性最高，推薦日常使用。 | Sends Valeria=true with the device's native DisplaySize, letting iOS provide a complete phone mirror while remaining in demonstration state. It offers the best compatibility and framing and is recommended for everyday use. | デバイス本来のDisplaySizeとともにValeria=trueを送信し、デモ状態のまま、iOSに画面全体のミラーリングを任せます。互換性と画面の収まりが最も良く、日常の利用に推奨します。 | ✅ 完全一致 | 保留 |
| UsbModeDemoDisadvantage | iOS 会进入 Apple 演示状态，状态栏日期、时间和电量会锁定为演示值，不能反映手机当前状态。 | iOS 會進入 Apple 示範狀態，狀態列日期、時間和電量會鎖定為示範值，不能反映手機目前狀態。 | iOS 會進入 Apple 示範狀態，狀態列日期、時間和電量會鎖定為示範值，不能反映手機目前狀態。 | iOS enters Apple's demonstration state. The status-bar date, time, and battery are locked to demonstration values instead of the phone's current state. | iOSがAppleのデモ状態になります。ステータスバーの日付、時刻、バッテリーは、iPhoneの現在の状態ではなくデモ用の値に固定されます。 | ✅ 完全一致 | 保留 |
| UsbModeDemoLabel | A 演示模式（推荐） | A 示範模式（推薦） | A 示範模式（推薦） | A Demo (recommended) | Aデモ（推奨） | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| UsbModeDemoNotice | 此模式不会启用视频 App 的 AirPlay 或外接播放画面。 | 此模式不會啟用影片 App 的 AirPlay 或外接播放畫面。 | 此模式不會啟用影片 App 的 AirPlay 或外接播放畫面。 | This mode does not enable AirPlay or external playback from video apps. | このモードでは、AirPlayや動画アプリからの外部再生は使えません。 | ✅ 完全一致 | 保留 |
| UsbModeDetailsTitle | 有线投屏模式说明 | 有線螢幕鏡像模式說明 | 有線螢幕鏡像模式說明 | USB mirroring mode details | USBミラーリングモードの詳細 | ❌ 术语不一致 → ✅ 已修复 | 投屏统一为 mirroring，视频应用投放仍使用 casting |
| UsbModeDetailsToolTip | 查看该模式的优缺点 | 查看該模式的優缺點 | 查看該模式的優缺點 | View this mode's advantages and disadvantages | このモードの長所と短所を表示します | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| UsbModeDisadvantageTitle | 缺点 | 缺點 | 缺點 | Disadvantages | 短所 | ✅ 完全一致 | 保留 |
| UsbProjectionModeAppliedFormat | 已应用：{0} | 已套用：{0} | 已套用：{0} | Applied: {0} | 適用しました: {0} | ✅ 完全一致 | 保留 |
| UsbProjectionModeRestarting | 正在按新模式重新连接当前有线设备… | 正在按新模式重新連接目前有線裝置… | 正在按新模式重新連線目前有線裝置… | Reconnecting the current USB device with the new mode… | 現在のUSBデバイスを新しいモードでつなぎ直しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| UsbProjectionModeSelectedFormat | 已选择：{0} | 已選擇：{0} | 已選擇：{0} | Selected: {0} | 選択中: {0} | ✅ 完全一致 | 保留 |
| UsbProjectionModeTitle | 有线投屏协议 | 有線螢幕鏡像協議 | 有線螢幕鏡像協定 | USB mirroring protocol | USBミラーリングのプロトコル | ❌ 术语不一致 → ✅ 已修复 | 投屏统一为 mirroring，视频应用投放仍使用 casting |
| UsbProjectionPerDeviceHint | 仅应用于当前选中的有线设备。 | 只套用至目前選取的有線裝置。 | 只套用至目前選取的有線裝置。 | Applies only to the currently selected USB device. | 現在選択しているUSBデバイスにだけ適用されます。 | ✅ 完全一致 | 保留 |
| UxPlayComponentUnavailable | 此构建缺少 UxPlay 下载信息，请使用正式发布的完整应用包。 | 此版本缺少 UxPlay 下載資訊，請使用正式發佈的完整應用程式套件。 | 此版本缺少 UxPlay 下載資訊，請使用正式發布的完整應用程式套件。 | This build has no UxPlay download metadata. Please use a complete release build. | このビルドにはUxPlayのダウンロード用メタデータがありません。完全なリリースビルドを使ってください。 | ✅ 完全一致 | 保留 |
| UxPlayDownloadCancel | 取消 | 取消 | 取消 | Cancel | キャンセル | ✅ 完全一致 | 保留 |
| UxPlayDownloadCancelling | 正在取消下载… | 正在取消下載… | 正在取消下載… | Cancelling download… | ダウンロードをキャンセルしています… | ✅ 完全一致 | 保留 |
| UxPlayDownloadDescription | 首次使用需要下载。自动选择高速镜像，安装后无需重复下载。 | 首次使用需要下載。自動選擇高速鏡像，安裝後無需重複下載。 | 首次使用需要下載。自動選擇高速鏡像，安裝後無需重複下載。 | A download is needed on first use. The fastest mirror is selected automatically and the component is saved for reuse. | 初回の利用時にダウンロードが必要です。最も速いミラーを自動で選び、コンポーネントは再利用のために保存されます。 | ✅ 完全一致 | 保留 |
| UxPlayDownloadFailed | 组件下载或安装失败，可重试；当前无线方案仍可使用。 | 元件下載或安裝失敗，可重試；目前無線方案仍可使用。 | 元件下載或安裝失敗，可重試；目前無線方案仍可使用。 | Download or installation failed. Retry when ready; your current wireless receiver remains available. | ダウンロードまたはインストールに失敗しました。準備ができたら再試行してください。現在の無線レシーバーはそのまま使えます。 | ✅ 完全一致 | 保留 |
| UxPlayDownloadFindingMirror | 正在连接下载镜像… | 正在連接下載鏡像… | 正在連線下載鏡像… | Connecting to download mirrors… | ダウンロード用ミラーに接続しています… | ✅ 完全一致 | 保留 |
| UxPlayDownloadInstalling | 正在校验并安装组件… | 正在驗證並安裝元件… | 正在驗證並安裝元件… | Verifying and installing the component… | コンポーネントを検証してインストールしています… | ✅ 完全一致 | 保留 |
| UxPlayDownloadIntegrityFailed | 组件完整性校验失败，未安装。请重新下载。 | 元件完整性驗證失敗，未安裝。請重新下載。 | 元件完整性驗證失敗，未安裝。請重新下載。 | Component integrity verification failed. Nothing was installed. Please download it again. | コンポーネントの整合性を検証できませんでした。何もインストールされていません。もう一度ダウンロードしてください。 | ✅ 完全一致 | 保留 |
| UxPlayDownloadNotFound | 此版本的组件下载地址不可用（404）。请确认对应版本的组件已发布，或稍后重试。 | 此版本的元件下載地址不可用（404）。請確認對應版本的元件已發佈，或稍後重試。 | 此版本的元件下載位址不可用（404）。請確認對應版本的元件已發布，或稍後重試。 | The component for this version is unavailable (404). Check that the matching component has been published, or retry later. | このバージョン用のコンポーネントを利用できません（404）。対応するコンポーネントが公開されているか確認するか、後でもう一度お試しください。 | ✅ 完全一致 | 保留 |
| UxPlayDownloadRetry | 重试 | 重試 | 重試 | Retry | 再試行 | ✅ 完全一致 | 保留 |
| UxPlayDownloadStorageFailed | 无法写入组件缓存。请检查剩余磁盘空间和文件访问权限后重试。 | 無法寫入元件快取。請檢查剩餘磁碟空間及檔案存取權限後重試。 | 無法寫入元件快取。請檢查剩餘磁碟空間及檔案存取權限後重試。 | Cannot write to the component cache. Check free disk space and file permissions, then retry. | コンポーネントのキャッシュに書き込めません。ディスクの空き容量とファイルのアクセス許可を確認して、再試行してください。 | ✅ 完全一致 | 保留 |
| UxPlayDownloadTestingMirror | 正在测速并选择最快的下载线路… | 正在測速並選擇最快的下載線路… | 正在測速並選擇最快的下載線路… | Testing download speeds… | ダウンロード速度をテストしています… | ✅ 完全一致 | 保留 |
| UxPlayDownloadTitle | 下载 UxPlay 无线组件 | 下載 UxPlay 無線元件 | 下載 UxPlay 無線元件 | Download UxPlay wireless component | UxPlay無線コンポーネントをダウンロード | ✅ 完全一致 | 保留 |
| VerifyingDownload | 正在校验下载文件… | 正在驗證下載檔案… | 正在驗證下載檔案… | Verifying the download… | ダウンロードを検証しています… | ✅ 完全一致 | 保留 |
| VideoPipelineAppliedFormat | 已应用视频管线：{0} | 已套用影片管線：{0} | 已套用影片管線：{0} | Video pipeline applied: {0} | 映像パイプラインを適用しました: {0} | ✅ 完全一致 | 保留 |
| VideoPipelinePreferenceHelp | 软件兼容会关闭视频解码硬件加速，但 D3D 预览仍会使用 GPU。解码器切换通常在下一关键帧生效。 | 軟件相容會關閉影片解碼硬件加速，但 D3D 預覽仍會使用 GPU。解碼器切換通常在下一關鍵幀生效。 | 軟體相容會關閉影片解碼硬體加速，但 D3D 預覽仍會使用 GPU。解碼器切換通常在下一關鍵影格生效。 | Software compatibility disables hardware video decoding, but the D3D preview still uses the GPU. Decoder changes normally apply at the next keyframe. | ソフトウェア互換を選ぶと、ハードウェアによる映像デコードは無効になりますが、D3Dプレビューは引き続きGPUを使います。デコーダーの変更は、通常、次のキーフレームで反映されます。 | ✅ 完全一致 | 保留 |
| VideoPipelineRestarting | 正在按新的视频管线设置重新连接当前设备… | 正在按新的影片管線設定重新連接目前裝置… | 正在按新的影片管線設定重新連線目前裝置… | Reconnecting the current device with the new video pipeline… | 現在のデバイスを新しい映像パイプラインでつなぎ直しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| VideoPreferencesApplied | 本地渲染参数已应用（来源码流未重连） | 本機繪製參數已套用（來源串流未重新連接） | 本機繪製參數已套用（來源串流未重新連線） | Local rendering settings applied (source stream was not reconnected) | ローカル描画の設定を適用しました（ソースのストリームは再接続していません） | ❌ 含义不一致 → ✅ 已修复 | 未重连与码流未改变不是同一含义 |
| VideoPreferencesUnsupported | 当前核心版本尚不支持本地渲染尺寸/帧率调整 | 現有核心版本尚不支援本機繪製尺寸/幀率調整 | 現有核心版本尚不支援本機繪製尺寸/影格率調整 | This core version does not support local render size or frame-rate control | このコアのバージョンでは、ローカルの描画サイズやフレームレートを制御することはできません | ✅ 完全一致 | 保留 |
| VideoPreferencesUpdateFailed | 无法更新本地渲染参数 | 無法更新本機繪製參數 | 無法更新本機繪製參數 | Could not update local rendering settings | ローカル描画の設定を更新できませんでした | ✅ 完全一致 | 保留 |
| VideoSettingsAppliedFormat | 设置已提交：{0} · {1} fps · {2} | 設定已提交：{0} · {1} fps · {2} | 設定已提交：{0} · {1} fps · {2} | Settings submitted: {0} · {1} fps · {2} | 設定を送信しました: {0} · {1}fps · {2} | ✅ 完全一致 | 保留 |
| VideoSettingsReconnectBodyFormat | 无法在当前连接中应用画面设置：{0}<br><br>解码器：{1}<br><br>是否停止当前投屏并重新连接该设备？ | 無法在現有連接中套用畫面設定：{0}<br><br>解碼器：{1}<br><br>是否停止現有螢幕鏡像並重新連接這部裝置？ | 無法在現有連線中套用畫面設定：{0}<br><br>解碼器：{1}<br><br>是否停止現有螢幕鏡像並重新連線這台裝置？ | The video settings could not be applied to the current connection: {0}<br><br>Decoder: {1}<br><br>Stop the current cast and reconnect this device? | 映像設定を現在の接続に適用できませんでした: {0}<br><br>デコーダー: {1}<br><br>現在のキャストを停止して、このデバイスを再接続しますか？ | ✅ 完全一致 | 保留 |
| VideoSettingsReconnectCancelled | 已取消重新连接；所选设置尚未全部应用。 | 已取消重新連接；所選設定尚未全部套用。 | 已取消重新連線；所選設定尚未全部套用。 | Reconnect cancelled; the selected settings have not all been applied. | 再接続をキャンセルしました。選択した設定は、すべては適用されていません。 | ✅ 完全一致 | 保留 |
| VideoSettingsReconnectTitle | 需要重新连接设备 | 需要重新連接裝置 | 需要重新連線裝置 | Reconnect the device? | デバイスを再接続しますか？ | ✅ 完全一致 | 保留 |
| VideoSettingsSavedFormat | 已保存，将在下次开始投屏时应用：{0} · {1} fps · {2} | 已儲存，將在下次開始螢幕鏡像時套用：{0} · {1} fps · {2} | 已儲存，將在下次開始螢幕鏡像時套用：{0} · {1} fps · {2} | Saved for the next cast: {0} · {1} fps · {2} | 次回のキャスト用に保存しました: {0} · {1}fps · {2} | ✅ 完全一致 | 保留 |
| VirtualCameraAlreadyRunning | 虚拟摄像头已在运行。 | 虛擬攝影機已在運作。 | 虛擬攝影機已在運作。 | The virtual camera is already running. | 仮想カメラはすでに動作中です。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| VirtualCameraBackendMissing | 未安装兼容的 Windows 虚拟摄像头媒体源。按钮将保持禁用，避免误报不存在的摄像头设备。 | 未安裝相容的 Windows 虛擬攝影機媒體源。按鈕將保持停用，避免誤報不存在的攝影機裝置。 | 未安裝相容的 Windows 虛擬攝影機媒體源。按鈕將保持停用，避免誤報不存在的攝影機裝置。 | No compatible Windows virtual-camera media source is installed. This button stays disabled instead of reporting a camera that does not exist. | 互換性のあるWindowsの仮想カメラのメディアソースがインストールされていません。存在しないカメラを報告しないよう、このボタンは無効のままです。 | ✅ 完全一致 | 保留 |
| VirtualCameraChecking | 正在检测虚拟摄像头能力… | 正在偵測虛擬攝影機能力… | 正在偵測虛擬攝影機能力… | Checking virtual camera support… | 仮想カメラの対応状況を確認しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| VirtualCameraDescription | 将当前投屏画面注册为会议和录制软件可选择的摄像头设备。 | 將目前螢幕鏡像畫面註冊為會議和錄製軟件可選擇的攝影機裝置。 | 將目前螢幕鏡像畫面註冊為會議和錄製軟體可選擇的攝影機裝置。 | Expose the selected mirror as a camera device that conferencing and recording applications can select. | 選択したミラーリングを、会議や録画のアプリで選べるカメラデバイスとして公開します。 | ✅ 完全一致 | 保留 |
| VirtualCameraInstallCancelled | 已取消安装虚拟摄像头。 | 已取消安裝虛擬攝影機。 | 已取消安裝虛擬攝影機。 | Virtual camera installation was cancelled. | 仮想カメラのインストールをキャンセルしました。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| VirtualCameraInstallFailedFormat | 无法安装虚拟摄像头组件：{0} | 無法安裝虛擬攝影機元件：{0} | 無法安裝虛擬攝影機元件：{0} | Could not install the virtual camera component: {0} | 仮想カメラのコンポーネントをインストールできませんでした: {0} | ✅ 完全一致 | 保留 |
| VirtualCameraInstallNotDetected | 安装程序已结束，但 Windows 未检测到虚拟摄像头组件。 | 安裝程式已結束，但 Windows 未偵測到虛擬攝影機元件。 | 安裝程式已結束，但 Windows 未偵測到虛擬攝影機元件。 | The installer finished, but Windows did not detect the virtual camera component. | インストーラーは完了しましたが、Windowsが仮想カメラのコンポーネントを検出しませんでした。 | ✅ 完全一致 | 保留 |
| VirtualCameraInstallRequired | 需要先安装虚拟摄像头组件。安装过程只会请求一次管理员权限，之后普通用户即可启动。 | 需要先安裝虛擬攝影機元件。安裝過程只會請求一次管理員權限，之後一般使用者即可啟動。 | 需要先安裝虛擬攝影機元件。安裝過程只會請求一次管理員權限，之後一般使用者即可啟動。 | Install the virtual camera component first. Administrator approval is needed once; normal users can start it afterward. | 先に仮想カメラのコンポーネントをインストールしてください。管理者の承認が一度だけ必要です。その後は、通常のユーザーでも開始できます。 | ✅ 完全一致 | 保留 |
| VirtualCameraInstalled | 虚拟摄像头组件安装完成。 | 虛擬攝影機元件安裝完成。 | 虛擬攝影機元件安裝完成。 | The virtual camera component was installed. | 仮想カメラのコンポーネントをインストールしました。 | ✅ 完全一致 | 保留 |
| VirtualCameraInstallerExitedFormat | 虚拟摄像头安装程序已退出，代码为 {0}。 | 虛擬攝影機安裝程式已結束，代碼為 {0}。 | 虛擬攝影機安裝程式已結束，代碼為 {0}。 | The virtual camera installer exited with code {0}. | 仮想カメラのインストーラーがコード{0}で終了しました。 | ❌ 缺失 → ✅ 已修复 | 输出错误详情迁入三语资源 |
| VirtualCameraInstallerStartFailed | 无法启动虚拟摄像头安装程序。 | 無法啟動虛擬攝影機安裝程式。 | 無法啟動虛擬攝影機安裝程式。 | The virtual camera installer could not be started. | 仮想カメラのインストーラーを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| VirtualCameraInstalling | 正在安装虚拟摄像头组件… | 正在安裝虛擬攝影機元件… | 正在安裝虛擬攝影機元件… | Installing the virtual camera component… | 仮想カメラのコンポーネントをインストールしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| VirtualCameraPayloadChangedFormat | 虚拟摄像头安装文件意外发生变化：{0} | 虛擬攝影機安裝檔案意外發生變更：{0} | 虛擬攝影機安裝檔案意外發生變更：{0} | The staged virtual camera installation file changed unexpectedly: {0} | 展開済みの仮想カメラのインストール用ファイルが予期せず変更されました: {0} | ❌ 缺失 → ✅ 已修复 | 输出错误详情迁入三语资源 |
| VirtualCameraPayloadMissing | 缺少内置虚拟摄像头安装文件。 | 缺少內置虛擬攝影機安裝檔案。 | 缺少內建虛擬攝影機安裝檔案。 | The embedded virtual camera installation files are missing. | 仮想カメラのインストール用ファイルが組み込まれていません。 | ❌ 缺失 → ✅ 已修复 | 将代码中的用户可见硬编码文字迁入三语资源 |
| VirtualCameraReady | 虚拟摄像头组件已就绪，可将当前投屏画面提供给会议或录制软件。 | 虛擬攝影機元件已就緒，可將目前螢幕鏡像畫面提供給會議或錄製軟件。 | 虛擬攝影機元件已就緒，可將目前螢幕鏡像畫面提供給會議或錄製軟體。 | The virtual camera component is ready to expose the current mirror to conferencing or recording apps. | 仮想カメラのコンポーネントの準備ができました。現在のミラーリングを、会議や録画のアプリに公開できます。 | ✅ 完全一致 | 保留 |
| VirtualCameraRunning | 虚拟摄像头正在运行 | 虛擬攝影機正在運作 | 虛擬攝影機正在運作 | Virtual camera is running | 仮想カメラが動作中です | ✅ 完全一致 | 保留 |
| VirtualCameraStarted | 虚拟摄像头已启动。 | 虛擬攝影機已啟動。 | 虛擬攝影機已啟動。 | Virtual camera started. | 仮想カメラを開始しました。 | ✅ 完全一致 | 保留 |
| VirtualCameraTab | 虚拟摄像头 | 虛擬攝影機 | 虛擬攝影機 | Virtual camera | 仮想カメラ | ✅ 完全一致 | 保留 |
| VirtualCameraUninstallFailedFormat | 无法卸载虚拟摄像头组件：{0} | 無法解除安裝虛擬攝影機元件：{0} | 無法解除安裝虛擬攝影機元件：{0} | Could not uninstall the virtual camera component: {0} | 仮想カメラのコンポーネントをアンインストールできませんでした: {0} | ✅ 完全一致 | 保留 |
| VirtualCameraUninstallStillDetected | 卸载程序已结束，但 Windows 仍检测到虚拟摄像头组件。 | 解除安裝程式已結束，但 Windows 仍偵測到虛擬攝影機元件。 | 解除安裝程式已結束，但 Windows 仍偵測到虛擬攝影機元件。 | The uninstaller finished, but Windows still detects the virtual camera component. | アンインストーラーは完了しましたが、Windowsがまだ仮想カメラのコンポーネントを検出しています。 | ✅ 完全一致 | 保留 |
| VirtualCameraUninstalled | 虚拟摄像头组件已卸载。 | 虛擬攝影機元件已解除安裝。 | 虛擬攝影機元件已解除安裝。 | The virtual camera component was uninstalled. | 仮想カメラのコンポーネントをアンインストールしました。 | ✅ 完全一致 | 保留 |
| VirtualCameraUninstalling | 正在卸载虚拟摄像头组件… | 正在解除安裝虛擬攝影機元件… | 正在解除安裝虛擬攝影機元件… | Uninstalling the virtual camera component… | 仮想カメラのコンポーネントをアンインストールしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| VirtualCameraUnsupported | 当前 Windows 版本不支持软件虚拟摄像头。此功能需要 Windows 11。 | 目前 Windows 版本不支援軟件虛擬攝影機。此功能需要 Windows 11。 | 目前 Windows 版本不支援軟體虛擬攝影機。此功能需要 Windows 11。 | This version of Windows does not support software virtual cameras. Windows 11 is required. | このバージョンのWindowsは、ソフトウェア仮想カメラに対応していません。Windows 11が必要です。 | ✅ 完全一致 | 保留 |
| VirtualCameraUpdateRequired | 检测到旧版虚拟摄像头组件。请先更新组件，再启动虚拟摄像头。 | 偵測到舊版虛擬攝影機元件。請先更新元件，再啟動虛擬攝影機。 | 偵測到舊版虛擬攝影機元件。請先更新元件，再啟動虛擬攝影機。 | An older virtual camera component is installed. Update it before starting the virtual camera. | 古い仮想カメラのコンポーネントがインストールされています。仮想カメラを開始する前にアップデートしてください。 | ✅ 完全一致 | 保留 |
| VirtualCameraUpdated | 虚拟摄像头组件更新完成。 | 虛擬攝影機元件更新完成。 | 虛擬攝影機元件更新完成。 | The virtual camera component was updated. | 仮想カメラのコンポーネントをアップデートしました。 | ✅ 完全一致 | 保留 |
| VirtualCameraUpdating | 正在更新虚拟摄像头组件… | 正在更新虛擬攝影機元件… | 正在更新虛擬攝影機元件… | Updating the virtual camera component… | 仮想カメラのコンポーネントをアップデートしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| WidthLabel | 宽度 | 寬度 | 寬度 | Width | 幅 | ✅ 完全一致 | 保留 |
| WindowTitle | iPhoneMirror — USB iPhone/iPad 投屏 | iPhoneMirror — USB iPhone/iPad 螢幕鏡像 | iPhoneMirror — USB iPhone/iPad 螢幕鏡像 | iPhoneMirror — USB iPhone/iPad Mirroring | iPhoneMirror — USB接続のiPhone/iPadミラーリング | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WindowTitleConnectivity | iPhoneMirror - iPhone/iPad 投屏 | iPhoneMirror - iPhone/iPad 螢幕鏡像 | iPhoneMirror - iPhone/iPad 螢幕鏡像 | iPhoneMirror - iPhone/iPad Mirroring | iPhoneMirror - iPhone/iPadミラーリング | ✅ 完全一致 | 保留 |
| WiredControlDisable | 关闭有线控制 | 關閉有線控制 | 關閉有線控制 | Disable wired control | 有線操作を無効にする | ✅ 完全一致 | 保留 |
| WiredControlEnable | 开启有线控制 | 啟用有線控制 | 啟用有線控制 | Enable wired control | 有線操作を有効にする | ✅ 完全一致 | 保留 |
| WiredControlLabel | 有线控制 | 有線控制 | 有線控制 | Wired control | 有線操作 | ✅ 完全一致 | 保留 |
| WirelessBackendAppliedFormat | 当前接收方案：{0} | 目前接收方案：{0} | 目前接收方案：{0} | Receiver implementation in use: {0} | 使用中のレシーバーの実装: {0} | ✅ 完全一致 | 保留 |
| WirelessBackendChangeFormat | 接收方案：{0} → {1} | 接收方案：{0} → {1} | 接收方案：{0} → {1} | Receiver implementation: {0} → {1} | レシーバーの実装: {0} → {1} | ✅ 完全一致 | 保留 |
| WirelessBackendLabel | 接收方案 | 接收方案 | 接收方案 | Receiver implementation | レシーバーの実装 | ✅ 完全一致 | 保留 |
| WirelessBackendOriginal | 原始方案 | 原始方案 | 原始方案 | Original | オリジナル | ✅ 完全一致 | 保留 |
| WirelessBackendSettingsSaveFailed | 无法保存所选无线接收方案。 | 無法儲存所選無線接收方案。 | 無法儲存所選無線接收方案。 | The selected wireless receiver implementation could not be saved. | 選択した無線レシーバーの実装を保存できませんでした。 | ✅ 完全一致 | 保留 |
| WirelessBackendUnavailableFormat | 缺少 {0} 无线接收组件。请重新安装完整的 iPhoneMirror 安装包。 | 缺少 {0} 無線接收元件。請重新安裝完整的 iPhoneMirror 安裝套件。 | 缺少 {0} 無線接收元件。請重新安裝完整的 iPhoneMirror 安裝套件。 | The {0} wireless receiver component is missing. Reinstall the full iPhoneMirror package. | {0}の無線レシーバーのコンポーネントが見つかりません。iPhoneMirrorの完全版パッケージをインストールし直してください。 | ⚠️ 需要优化 → ✅ 已修复 | 面向最终用户提供可执行的重新安装建议 |
| WirelessBackendUxPlay | UxPlay（备用） | UxPlay（備用） | UxPlay（備用） | UxPlay (fallback) | UxPlay（フォールバック） | ✅ 完全一致 | 保留 |
| WirelessConnected | AirPlay 已连接 | AirPlay 已連接 | AirPlay 已連線 | AirPlay connected | AirPlay接続済み | ✅ 完全一致 | 保留 |
| WirelessConnecting | AirPlay 设备正在连接… | AirPlay 裝置正在連接… | AirPlay 裝置正在連線… | An AirPlay device is connecting… | AirPlayデバイスが接続中です… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| WirelessControlDisable | 关闭无线控制 | 關閉無線控制 | 關閉無線控制 | Disable wireless control | 無線操作を無効にする | ✅ 完全一致 | 保留 |
| WirelessControlEnable | 开启无线控制 | 啟用無線控制 | 啟用無線控制 | Enable wireless control | 無線操作を有効にする | ✅ 完全一致 | 保留 |
| WirelessControlLabel | 无线控制 | 無線控制 | 無線控制 | Wireless control | 無線操作 | ✅ 完全一致 | 保留 |
| WirelessControlOperationFailedFormat | 无线控制操作失败：{0} | 無線控制操作失敗：{0} | 無線控制操作失敗：{0} | Wireless control operation failed: {0} | 無線操作に失敗しました: {0} | ❌ 术语不一致 → ✅ 已修复 | 状态及操作标签统一为无线控制 |
| WirelessLocalNetwork | 本地网络 | 本機網絡 | 本機網路 | Local network | ローカルネットワーク | ✅ 完全一致 | 保留 |
| WirelessMusicAudioFormat | AirPlay PCM 音频 | AirPlay PCM 音訊 | AirPlay PCM 音訊 | AirPlay PCM audio | AirPlay PCM音声 | ✅ 完全一致 | 保留 |
| WirelessMusicAudioOnly | 仅音频 | 只限音訊 | 只限音訊 | Audio only | 音声のみ | ✅ 完全一致 | 保留 |
| WirelessMusicNoVideo | 无视频流 | 沒有視訊串流 | 沒有視訊串流 | No video stream | 映像ストリームなし | ✅ 完全一致 | 保留 |
| WirelessMusicStreaming | 正在通过 AirPlay 播放音乐 | 正在透過 AirPlay 播放音樂 | 正在透過 AirPlay 播放音樂 | Playing music through AirPlay | AirPlayで音楽を再生中 | ✅ 完全一致 | 保留 |
| WirelessMusicTitle | AirPlay 音乐 | AirPlay 音樂 | AirPlay 音樂 | AirPlay Music | AirPlayミュージック | ✅ 完全一致 | 保留 |
| WirelessNameChangeFormat | 接收端名称：{0} → {1} | 接收端名稱：{0} → {1} | 接收端名稱：{0} → {1} | Receiver name: {0} → {1} | レシーバー名: {0} → {1} | ✅ 完全一致 | 保留 |
| WirelessOriginalQualityWarningBody | 原画模式在部分设备或网络环境下可能出现画面停帧。建议优先使用 1080p；如仍需原画，请确保局域网稳定，并从 iPhone“控制中心” → “屏幕镜像”连接。 | 原畫模式在部分裝置或網絡環境下可能出現畫面停幀。建議優先使用 1080p；如仍需原畫，請確保區域網絡穩定，並從 iPhone「控制中心」 → 「螢幕鏡像」連接。 | 原始畫質模式在部分裝置或網路環境下可能出現畫面停格。建議優先使用 1080p；如仍需原始畫質，請確保區域網路穩定，並從 iPhone「控制中心」 → 「螢幕鏡像輸出」連線。 | Original quality may freeze on some devices or network conditions. 1080p is recommended. If you still need original quality, use a stable local network and connect from iPhone Control Center → Screen Mirroring. | オリジナル画質では、デバイスやネットワークの状況によって映像が止まることがあります。1080pをおすすめします。それでもオリジナル画質が必要な場合は、安定したローカルネットワークを使い、iPhoneのコントロールセンターの「画面ミラーリング」から接続してください。 | ✅ 完全一致 | 保留 |
| WirelessOriginalQualityWarningTitle | 原画模式提示 | 原畫模式提示 | 原始畫質模式提示 | Original quality notice | オリジナル画質についてのお知らせ | ✅ 完全一致 | 保留 |
| WirelessProfile1080p | 1080p（推荐 · 60 fps） | 1080p（推薦 · 60 fps） | 1080p（推薦 · 60 fps） | 1080p (recommended · 60 fps) | 1080p（推奨 · 60fps） | ✅ 完全一致 | 保留 |
| WirelessProfile540p | 540p（弱网 · 30 fps） | 540p（弱網 · 30 fps） | 540p（低速網路 · 30 fps） | 540p (weak network · 30 fps) | 540p（弱いネットワーク向け · 30fps） | ✅ 完全一致 | 保留 |
| WirelessProfile720p | 720p（流畅 · 30 fps） | 720p（流暢 · 30 fps） | 720p（流暢 · 30 fps） | 720p (smooth · 30 fps) | 720p（滑らか · 30fps） | ✅ 完全一致 | 保留 |
| WirelessProfileAppliedFormat | 当前声明：{0} | 現有宣告：{0} | 現有宣告：{0} | Advertised now: {0} | 現在の公開内容: {0} | ✅ 完全一致 | 保留 |
| WirelessProfileDisconnectConfirmFormat | 当前有 {0} 台无线设备已连接。应用“{1}”会断开全部无线投屏并重启接收端。是否继续？ | 現有 {0} 部無線裝置已連接。套用「{1}」會中斷所有無線螢幕鏡像連接，並重新啟動接收端。是否繼續？ | 現有 {0} 台無線裝置已連線。套用「{1}」會中斷所有無線螢幕鏡像連線，並重新啟動接收端。是否繼續？ | Connected wireless devices: {0}. Applying “{1}” will disconnect all wireless mirroring and restart the receiver. Continue? | 接続中の無線デバイス: {0}台。「{1}」を適用すると、すべての無線ミラーリングが切断され、レシーバーが再起動します。続行しますか？ | ⚠️ 需要优化 → ✅ 已修复 | 用数量标签兼容单复数；静态未发现引用，保留待后续调用核对 |
| WirelessProfileMaximum | 原画（横竖屏最长边 2880 · 60 fps） | 原畫（橫直向最長邊 2880 · 60 fps） | 原始畫質（橫直向最長邊 2880 · 60 fps） | Original quality (2880 long edge in either orientation · 60 fps) | オリジナル画質（縦横どちらの向きでも長辺2880 · 60fps） | ✅ 完全一致 | 保留 |
| WirelessProfileMaximumIpad | 原画（iPad / Air · 长边 2360 · 60 fps） | 原畫（iPad / Air · 最長邊 2360 · 60 fps） | 原始畫質（iPad / Air · 最長邊 2360 · 60 fps） | Original quality (iPad / Air · 2360 long edge · 60 fps) | オリジナル画質（iPad / Air · 長辺2360 · 60fps） | ✅ 完全一致 | 保留 |
| WirelessProfileMaximumIpadPro | 原画（iPad Pro 12.9 · 长边 2732 · 60 fps） | 原畫（iPad Pro 12.9 · 最長邊 2732 · 60 fps） | 原始畫質（iPad Pro 12.9 · 最長邊 2732 · 60 fps） | Original quality (iPad Pro 12.9 · 2732 long edge · 60 fps) | オリジナル画質（iPad Pro 12.9 · 長辺2732 · 60fps） | ✅ 完全一致 | 保留 |
| WirelessProfileNativeDimensions | 原画（{0} · {1}×{2} · 自动横竖屏） | 原畫（{0} · {1}×{2} · 自動橫直向） | 原始畫質（{0} · {1}×{2} · 自動橫直向） | Original ({0} · {1}×{2} · automatic rotation) | オリジナル（{0} · {1}×{2} · 自動回転） | ✅ 完全一致 | 保留 |
| WirelessProfileReconnectInstructionsFormat | 已重新声明“{0}”。请在 iPhone 打开“控制中心” → “屏幕镜像”，重新选择“{1}”。如果列表仍保留旧连接，请先点“停止镜像”，再重新选择接收端。 | 已重新宣告「{0}」。請在 iPhone 開啟「控制中心」 → 「螢幕鏡像」，重新選擇「{1}」。如果裝置清單仍保留舊連接，請先按一下「停止鏡像」，再重新選擇接收端。 | 已重新宣告「{0}」。請在 iPhone 開啟「控制中心」 → 「螢幕鏡像輸出」，重新選擇「{1}」。如果裝置清單仍保留舊連線，請先按一下「停止鏡像輸出」，再重新選擇接收端。 | “{0}” is now advertised. On iPhone, open Control Center → Screen Mirroring and select “{1}” again. If the old connection remains listed, tap Stop Mirroring first, then select the receiver again. | 「{0}」を公開しました。iPhoneでコントロールセンターの「画面ミラーリング」を開き、「{1}」をもう一度選んでください。古い接続が一覧に残っている場合は、先に「ミラーリングを停止」をタップしてから、レシーバーをもう一度選んでください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WirelessReady | AirPlay 接收端已就绪 | AirPlay 接收端已就緒 | AirPlay 接收端已就緒 | AirPlay receiver ready | AirPlayレシーバーの準備完了 | ✅ 完全一致 | 保留 |
| WirelessReceiverMissing | 缺少无线接收组件。请重新安装完整的 iPhoneMirror 安装包。 | 缺少無線接收元件。請重新安裝完整的 iPhoneMirror 安裝套件。 | 缺少無線接收元件。請重新安裝完整的 iPhoneMirror 安裝套件。 | The wireless receiver component is missing. Reinstall the full iPhoneMirror package. | 無線レシーバーのコンポーネントが見つかりません。iPhoneMirrorの完全版パッケージをインストールし直してください。 | ⚠️ 需要优化 → ✅ 已修复 | 面向最终用户提供可执行的重新安装建议 |
| WirelessReceiverNameLabel | 接收端名称 | 接收端名稱 | 接收端名稱 | Receiver name | レシーバー名 | ✅ 完全一致 | 保留 |
| WirelessReceiverTitle | 无线 AirPlay | 無線 AirPlay | 無線 AirPlay | Wireless AirPlay | 無線AirPlay | ✅ 完全一致 | 保留 |
| WirelessResolutionChangeFormat | 连接分辨率：{0} → {1} | 連接解像度：{0} → {1} | 連線解析度：{0} → {1} | Connection resolution: {0} → {1} | 接続の解像度: {0} → {1} | ✅ 完全一致 | 保留 |
| WirelessResolutionHelp | 应用后将重新声明 AirPlay 接收能力；弱网请选择 720p 或 540p。 | 套用後將重新宣告 AirPlay 接收能力；弱網請選擇 720p 或 540p。 | 套用後將重新宣告 AirPlay 接收能力；低速網路請選擇 720p 或 540p。 | Applying re-advertises the AirPlay receiver capability. Use 720p or 540p on a weak network. | 適用すると、AirPlayレシーバーの機能を再度公開します。ネットワークが弱いときは、720pまたは540pをお使いください。 | ✅ 完全一致 | 保留 |
| WirelessResolutionLabel | 连接分辨率 | 連接解像度 | 連線解析度 | Connection resolution | 接続の解像度 | ✅ 完全一致 | 保留 |
| WirelessResolutionTitle | 无线投屏清晰度 | 無線螢幕鏡像畫質 | 無線螢幕鏡像畫質 | Wireless mirroring quality | 無線ミラーリングの画質 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WirelessRunningFormat | 无线接收端运行中：{0} | 無線接收端正在運作：{0} | 無線接收端正在運作：{0} | Wireless receiver active: {0} | 無線レシーバーが動作中: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WirelessRunningWithBackendFormat | {0} 无线接收端运行中：{1} | {0} 無線接收端正在運作：{1} | {0} 無線接收端正在運作：{1} | {0} wireless receiver active: {1} | {0}の無線レシーバーが動作中: {1} | ✅ 完全一致 | 保留 |
| WirelessRuntimeCodeIntegrityBlocked | Windows 安全策略阻止了无线解码组件。请改用 Setup 安装版；若使用 ZIP，请先在 ZIP 的“属性”中勾选“解除锁定”，然后重新解压。 | Windows 安全策略阻止了無線解碼元件。請改用 Setup 安裝版；若使用 ZIP，請先在 ZIP 的「屬性」中選取「解除鎖定」，然後重新解壓縮。 | Windows 安全策略阻止了無線解碼元件。請改用 Setup 安裝版；若使用 ZIP，請先在 ZIP 的「屬性」中選取「解除鎖定」，然後重新解壓縮。 | Windows security policy blocked the wireless decoder. Use the Setup installer, or open the downloaded ZIP's Properties, select Unblock, and extract it again. | Windowsのセキュリティポリシーにより、無線デコーダーがブロックされました。セットアップインストーラーを使うか、ダウンロードしたZIPのプロパティで「許可する」を選んでから、展開し直してください。 | ✅ 完全一致 | 保留 |
| WirelessRuntimeIncompatible | 无线解码组件版本不兼容，请重新安装最新版本。 | 無線解碼元件版本不相容，請重新安裝最新版本。 | 無線解碼元件版本不相容，請重新安裝最新版本。 | The wireless decoder version is incompatible. Reinstall the latest version. | 無線デコーダーのバージョンに互換性がありません。最新版をインストールし直してください。 | ✅ 完全一致 | 保留 |
| WirelessRuntimeLoadFailedFormat | 无线解码组件无法加载（检查代码 {0}），请重新安装最新版本。 | 無線解碼元件無法載入（檢查代碼 {0}），請重新安裝最新版本。 | 無線解碼元件無法載入（檢查代碼 {0}），請重新安裝最新版本。 | The wireless decoder could not be loaded (check code {0}). Reinstall the latest version. | 無線デコーダーを読み込めませんでした（確認コード{0}）。最新版をインストールし直してください。 | ✅ 完全一致 | 保留 |
| WirelessRuntimeProbeTimedOut | 无线解码组件检查超时，请重新启动应用后重试。 | 無線解碼元件檢查逾時，請重新啟動應用程式後重試。 | 無線解碼元件檢查逾時，請重新啟動應用程式後重試。 | The wireless decoder check timed out. Restart the application and try again. | 無線デコーダーの確認がタイムアウトしました。アプリを再起動して、もう一度お試しください。 | ✅ 完全一致 | 保留 |
| WirelessServiceAlwaysOn | 自动启动 | 自動啟動 | 自動啟動 | Starts automatically | 自動で起動します | ✅ 完全一致 | 保留 |
| WirelessSettingsConfirmFormat | 本次修改：<br>{0}<br><br>{1}<br><br>应用后请在 iPhone 打开“控制中心” → “屏幕镜像”，重新选择“{2}”。 | 本次修改：<br>{0}<br><br>{1}<br><br>套用後請在 iPhone 開啟「控制中心」 → 「螢幕鏡像」，重新選擇「{2}」。 | 本次修改：<br>{0}<br><br>{1}<br><br>套用後請在 iPhone 開啟「控制中心」 → 「螢幕鏡像輸出」，重新選擇「{2}」。 | Changes:<br>{0}<br><br>{1}<br><br>After applying, open Control Center → Screen Mirroring on iPhone and select “{2}” again. | 変更内容:<br>{0}<br><br>{1}<br><br>適用後は、iPhoneでコントロールセンターの「画面ミラーリング」を開き、「{2}」をもう一度選んでください。 | ✅ 完全一致 | 保留 |
| WirelessSettingsConnectedImpactFormat | 当前有 {0} 台无线设备连接，应用后会全部断开。 | 現有 {0} 部無線裝置連接，套用後會全部中斷連接。 | 現有 {0} 台無線裝置連線，套用後會全部中斷連線。 | Connected wireless devices: {0}. Applying changes will disconnect all of them. | 接続中の無線デバイス: {0}台。変更を適用すると、すべて切断されます。 | ⚠️ 需要优化 → ✅ 已修复 | 消除 device(s) 表达并保留应用后断开的条件 |
| WirelessSettingsReadyImpact | 接收端将重启并重新发布 AirPlay 能力。 | 接收端將重新啟動並重新發佈 AirPlay 能力。 | 接收端將重新啟動並重新發布 AirPlay 能力。 | The receiver will restart and re-advertise its AirPlay capabilities. | レシーバーが再起動し、AirPlayの機能を再度公開します。 | ✅ 完全一致 | 保留 |
| WirelessSettingsTitle | 应用无线 AirPlay 设置 | 套用無線 AirPlay 設定 | 套用無線 AirPlay 設定 | Apply wireless AirPlay settings | 無線AirPlayの設定を適用 | ✅ 完全一致 | 保留 |
| WirelessSettingsUnchanged | 名称和连接分辨率均未改变。 | 名稱和連接解像度均未改變。 | 名稱和連線解析度均未改變。 | The receiver name and connection resolution have not changed. | レシーバー名と接続の解像度は変更されていません。 | ✅ 完全一致 | 保留 |
| WirelessStarting | 正在启动 AirPlay 接收端… | 正在啟動 AirPlay 接收端… | 正在啟動 AirPlay 接收端… | Starting the AirPlay receiver… | AirPlayレシーバーを起動しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| WirelessStopped | 无线投屏已停止 | 無線螢幕鏡像已停止 | 無線螢幕鏡像已停止 | Wireless mirroring stopped | 無線ミラーリングを停止しました | ✅ 完全一致 | 保留 |
| WirelessStopping | 正在停止 AirPlay 接收端… | 正在停止 AirPlay 接收端… | 正在停止 AirPlay 接收端… | Stopping the AirPlay receiver… | AirPlayレシーバーを停止しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| WirelessStreaming | AirPlay 无线投屏中 | AirPlay 無線螢幕鏡像中 | AirPlay 無線螢幕鏡像中 | Wireless AirPlay mirroring | 無線AirPlayミラーリング | ✅ 完全一致 | 保留 |
| WirelessUxPlayStartupFailed | UxPlay 启动后立即退出。请修复 UxPlay 运行时后重新应用无线设置。 | UxPlay 啟動後立即結束。請修復 UxPlay 執行階段後重新套用無線設定。 | UxPlay 啟動後立即結束。請修復 UxPlay 執行階段後重新套用無線設定。 | UxPlay stopped immediately after startup. Repair the UxPlay runtime, then apply the wireless settings again. | UxPlayが起動直後に停止しました。UxPlayのランタイムを修復してから、無線設定をもう一度適用してください。 | ✅ 完全一致 | 保留 |
| WirelessVideoPaused | iPhone 已暂停画面传输 | iPhone 已暫停畫面傳輸 | iPhone 已暫停畫面傳輸 | iPhone paused video transmission | iPhoneが映像の送信を一時停止しました | ✅ 完全一致 | 保留 |
| WirelessVideoReconnecting | 正在恢复 AirPlay 画面连接… | 正在恢復 AirPlay 畫面連線… | 正在恢復 AirPlay 畫面連線… | Restoring the AirPlay video connection… | AirPlayの映像接続を復旧しています… | ✅ 完全一致 | 保留 |
| WirelessWaitingDevice | AirPlay 接收端已启动，请在 iPhone 控制中心选择屏幕镜像。 | AirPlay 接收端已啟動，請在 iPhone 控制中心選擇螢幕鏡像。 | AirPlay 接收端已啟動，請在 iPhone 控制中心選擇螢幕鏡像。 | The AirPlay receiver is running. Choose Screen Mirroring in iPhone Control Center. | AirPlayレシーバーが動作中です。iPhoneのコントロールセンターで「画面ミラーリング」を選んでください。 | ✅ 完全一致 | 保留 |
| WizardActionHintDoubleTap | 连续点击两次 | 連續點按兩次 | 連續點按兩次 | Tap twice | 2回タップ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardActionHintHoldUntilRelease | 松开按键时释放 | 放開按鍵時釋放 | 放開按鍵時釋放 | Hold until the key is released | キーを離すまで押し続ける | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardActionHintLongPress | 按住指定时长 | 按住指定時間 | 按住指定時間 | Hold for a set duration | 指定した時間だけ押し続ける | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardActionHintSwipe | 从起点滑到终点 | 從起點滑到終點 | 從起點滑到終點 | Swipe between two positions | 2つの位置の間をスワイプ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardActionHintTap | 点击屏幕一点 | 按一下螢幕上的位置 | 按一下螢幕上的位置 | Tap one position | 1か所をタップ | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardCaptureNavigation | 录入时 Enter / Esc 也可绑定；录入结束后恢复导航。 | 錄入時 Enter / Esc 也可綁定；錄入結束後恢復導覽。 | 錄入時 Enter / Esc 也可綁定；錄入結束後恢復導覽。 | Enter / Esc can be captured too. Navigation resumes after capture. | EnterとEscも記録できます。記録後にナビゲーションが再開します。 | ✅ 完全一致 | 保留 |
| WizardChooseAction | 请选择一个操作 | 請選擇一個操作 | 請選擇一個操作 | Choose an action | 操作を選択 | ✅ 完全一致 | 保留 |
| WizardContinueEditing | 继续编辑 | 繼續編輯 | 繼續編輯 | Keep editing | 編集を続ける | ✅ 完全一致 | 保留 |
| WizardDiscard | 放弃 | 放棄 | 放棄 | Discard | 破棄 | ✅ 完全一致 | 保留 |
| WizardDiscardHint | 你的更改将不会保存。 | 你的變更將不會儲存。 | 你的變更將不會儲存。 | Your changes will not be saved. | 変更は保存されません。 | ✅ 完全一致 | 保留 |
| WizardDiscardTitle | 放弃此次编辑？ | 放棄此次編輯？ | 放棄此次編輯？ | Discard these changes? | 変更を破棄しますか? | ✅ 完全一致 | 保留 |
| WizardDisconnected | iPhone 已断开，请重新连接设备后继续。 | iPhone 已中斷連線，請重新連接裝置後繼續。 | iPhone 已中斷連線，請重新連接裝置後繼續。 | iPhone disconnected. Reconnect your device to continue. | iPhoneが切断されました。続けるにはデバイスを再接続してください。 | ✅ 完全一致 | 保留 |
| WizardDuplicate | 该按键已有映射。请选择其他按键，或处理现有映射。 | 該按鍵已有映射。請選擇其他按鍵，或處理現有映射。 | 該按鍵已有映射。請選擇其他按鍵，或處理現有映射。 | This key already has a mapping. Choose another key or resolve the existing mapping. | このキーにはすでに割り当てがあります。別のキーを選ぶか、既存の割り当てを整理してください。 | ✅ 完全一致 | 保留 |
| WizardFinish | 完成 ✓ | 完成 ✓ | 完成 ✓ | Finish ✓ | 完了 ✓ | ✅ 完全一致 | 保留 |
| WizardGestureSelected | 手势已记录 | 手勢已記錄 | 手勢已記錄 | Swipe recorded | スワイプを記録しました | ✅ 完全一致 | 保留 |
| WizardHintAction | 选择按下该键后要执行的操作 | 選擇按下該鍵後要執行的操作 | 選擇按下該鍵後要執行的操作 | Choose what happens when you press the key | キーを押したときの動作を選んでください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardHintConfirmation | 检查设置后保存 | 檢查設定後儲存 | 檢查設定後儲存 | Review your settings, then save | 設定を確認して保存してください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardHintGesture | 在原投屏画面中按住鼠标并拖动 | 在原投影畫面中按住滑鼠並拖曳 | 在原投影畫面中按住滑鼠並拖曳 | Press and drag in the original mirror | 元のミラーリング画面で押したままドラッグしてください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardHintKey | 按下一个键作为此映射的触发键 | 按下一個按鍵作為此映射的觸發鍵 | 按下一個按鍵作為此映射的觸發鍵 | Press a key to trigger this mapping | この割り当てを動作させるキーを押してください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardHintParameters | 设置此操作需要的参数 | 設定此操作需要的參數 | 設定此操作需要的參數 | Adjust the settings for this action | この操作の設定を調整してください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardHintPosition | 在原投屏画面中点击要执行操作的位置 | 在原投影畫面中按一下要執行操作的位置 | 在原投影畫面中按一下要執行操作的位置 | Click the target in the original mirror | 元のミラーリング画面で対象をクリックしてください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardKeySelected | 按键已选择 · 点击可重新录入 | 按鍵已選擇 · 按一下可重新錄入 | 按鍵已選擇 · 按一下可重新錄入 | Key selected · select to change | キーを選択済み · 選択して変更 | ✅ 完全一致 | 保留 |
| WizardKeyStart | 点击上方开始录入 | 按一下上方開始錄入 | 按一下上方開始錄入 | Select the key above to begin | 上のキーを選択して開始してください | ✅ 完全一致 | 保留 |
| WizardKeyWaiting | 按下一个键并松开 | 按下一個按鍵並放開 | 按下一個按鍵並放開 | Press and release a key | キーを押して離してください | ✅ 完全一致 | 保留 |
| WizardMilliseconds | {0} ms | {0} ms | {0} ms | {0} ms | {0}ms | ✅ 完全一致 | 保留 |
| WizardNext | 下一步 → | 下一步 → | 下一步 → | Next → | 次へ → | ✅ 完全一致 | 保留 |
| WizardPointPixels | X {0:N0}   Y {1:N0} | X {0:N0}   Y {1:N0} | X {0:N0}   Y {1:N0} | X {0:N0}   Y {1:N0} | X {0:N0}   Y {1:N0} | ✅ 完全一致 | 保留 |
| WizardPositionLabel | 位置 | 位置 | 位置 | Position | 位置 | ✅ 完全一致 | 保留 |
| WizardPositionSelected | 位置已选择 | 位置已選擇 | 位置已選擇 | Position selected | 位置を選択しました | ✅ 完全一致 | 保留 |
| WizardPressKey | 按下按键 | 按下按鍵 | 按下按鍵 | Press a key | キーを押してください | ✅ 完全一致 | 保留 |
| WizardPrevious | ← 上一步 | ← 上一步 | ← 上一步 | ← Back | ← 戻る | ✅ 完全一致 | 保留 |
| WizardProgress | 步骤 {0} / {1} | 步驟 {0} / {1} | 步驟 {0} / {1} | Step {0} of {1} | 手順 {0}/{1} | ✅ 完全一致 | 保留 |
| WizardReadyToPick | 等待选择 | 等待選擇 | 等待選擇 | Waiting for a selection | 選択を待っています | ✅ 完全一致 | 保留 |
| WizardRecordGesture | 开始录制手势 | 開始錄製手勢 | 開始錄製手勢 | Record on the mirror | ミラーリング画面で記録 | ✅ 完全一致 | 保留 |
| WizardRecording | 正在录制 | 正在錄製 | 正在錄製 | Recording | 記録中 | ✅ 完全一致 | 保留 |
| WizardRepickRequired | 位置已失效。请返回上一步重新取点。 | 位置已失效。請返回上一步重新選取位置。 | 位置已失效。請返回上一步重新選取位置。 | The position is no longer valid. Go back to choose it again. | 位置が無効になりました。戻って選び直してください。 | ✅ 完全一致 | 保留 |
| WizardSaved | 映射已保存 | 映射已儲存 | 映射已儲存 | Mapping saved | 割り当てを保存しました | ✅ 完全一致 | 保留 |
| WizardStepAction | 操作 | 操作 | 操作 | Action | 操作 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardStepConfirmation | 确认 | 確認 | 確認 | Review | 確認 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardStepKey | 按键 | 按鍵 | 按鍵 | Key | キー | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardStepParameters | 参数 | 參數 | 參數 | Settings | 設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardStepPosition | 取点 | 取點 | 取點 | Position | 位置 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardSwipePixels | 起点  {0:N0}, {1:N0}<br>终点  {2:N0}, {3:N0} · {4} ms | 起點  {0:N0}, {1:N0}<br>終點  {2:N0}, {3:N0} · {4} ms | 起點  {0:N0}, {1:N0}<br>終點  {2:N0}, {3:N0} · {4} ms | Start  {0:N0}, {1:N0}<br>End  {2:N0}, {3:N0} · {4} ms | 開始  {0:N0}, {1:N0}<br>終了  {2:N0}, {3:N0} · {4}ms | ✅ 完全一致 | 保留 |
| WizardSwipeTiming | 滑动时长会在下一步拖动时自动记录。 | 滑動時間會在下一步拖曳時自動記錄。 | 滑動時間會在下一步拖曳時自動記錄。 | Swipe duration is recorded as you drag in the next step. | スワイプの時間は、次の手順でドラッグしたときに記録されます。 | ✅ 完全一致 | 保留 |
| WizardTitleAction | 选择操作 | 選擇操作 | 選擇操作 | Choose an action | 操作を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardTitleConfirmation | 确认映射 | 確認映射 | 確認映射 | Confirm mapping | 割り当てを確認 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardTitleGesture | 设置手势 | 設定手勢 | 設定手勢 | Record a swipe | スワイプを記録 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardTitleKey | 选择 Win 按键 | 選擇 Win 按鍵 | 選擇 Win 按鍵 | Choose a Windows key | Windowsのキーを選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardTitleParameters | 设置操作参数 | 設定操作參數 | 設定操作參數 | Set action parameters | 操作のパラメーターを設定 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| WizardTitlePosition | 设置操作位置 | 設定操作位置 | 設定操作位置 | Choose a position | 位置を選択 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |

### DriverInstaller

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Acknowledge | 知道了 | 明白 | 知道了 | Got it | OK | ✅ 完全一致 | 保留 |
| AdvancedSettings | 高级设置 | 進階設定 | 進階設定 | Advanced settings | 詳細設定 | ✅ 完全一致 | 保留 |
| AisiBody | 从爱思官网下载并完成一次正常有线投屏，然后返回重新检测。 | 從愛思官網下載並完成一次正常有線螢幕鏡像，然後返回重新偵測。 | 從愛思官網下載並完成一次正常有線螢幕鏡像，然後返回重新偵測。 | Download Aisi Screen Mirroring from its official website, complete one normal wired mirroring session, then return and recheck. | 公式サイトからAisi Screen Mirroringをダウンロードし、有線で通常のミラーリングを一度行ってから、ここに戻って再確認してください。 | ❌ 含义不一致 → ✅ 已修复 | 补齐官方下载来源 |
| AisiTitle | 使用爱思投屏完成驱动准备 | 使用愛思螢幕鏡像完成驅動程式準備 | 使用愛思螢幕鏡像完成驅動程式準備 | Prepare the driver with Aisi Screen Mirroring | Aisi Screen Mirroringでドライバーを準備 | ✅ 完全一致 | 保留 |
| AppSubtitle | Apple USB 环境与按设备采集过滤驱动 | Apple USB 環境與按裝置擷取過濾驅動程式 | Apple USB 環境與按裝置擷取篩選驅動程式 | Apple USB environment and per-device capture filter | Apple USB環境とデバイスごとのキャプチャフィルター | ✅ 完全一致 | 保留 |
| AppTitle | iPhoneMirror 驱动管理器 | iPhoneMirror 驅動程式管理員 | iPhoneMirror 驅動程式管理員 | iPhoneMirror Driver Manager | iPhoneMirrorドライバー管理 | ✅ 完全一致 | 保留 |
| Appearance | 外观 | 外觀 | 外觀 | Appearance | 外観 | ✅ 完全一致 | 保留 |
| AppleCompatibilityDownloadUnavailable | 无法下载缺失的 Apple Mobile Device Service 兼容组件。请检查网络后重试，详细原因已写入日志。 | 無法下載遺失的 Apple Mobile Device Service 相容元件。請檢查網絡後重試，詳細原因已寫入記錄。 | 無法下載遺失的 Apple Mobile Device Service 相容元件。請檢查網路後重試，詳細原因已寫入記錄檔。 | The missing Apple Mobile Device Service compatibility component could not be downloaded. Check the network and retry; details were written to the log. | 不足しているApple Mobile Device Serviceの互換コンポーネントをダウンロードできませんでした。ネットワークを確認して再試行してください。詳細はログに書き込みました。 | ✅ 完全一致 | 保留 |
| AppleDevices | Apple 设备 | Apple 裝置 | Apple 裝置 | Apple devices | Apple Devices | ✅ 完全一致 | 保留 |
| AppleDownloadUnavailable | 无法自动获得 Apple 官方安装包，已打开 Microsoft Store 中的 Apple Devices 页面。 | 無法自動取得 Apple 官方安裝套件，已開啟 Microsoft Store 中的 Apple Devices 頁面。 | 無法自動取得 Apple 官方安裝套件，已開啟 Microsoft Store 中的 Apple Devices 頁面。 | The official Apple installer could not be obtained automatically. The Apple Devices page was opened in Microsoft Store. | Apple公式インストーラーを自動で取得できませんでした。Microsoft StoreでApple Devicesのページを開きました。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AppleInstallerFailed | Apple Mobile Device Support 组件安装失败，退出代码 {0}。<br>{1}<br>日志：{2} | Apple Mobile Device Support 元件安裝失敗，結束代碼 {0}。<br>{1}<br>記錄：{2} | Apple Mobile Device Support 元件安裝失敗，結束代碼 {0}。<br>{1}<br>記錄檔：{2} | The Apple Mobile Device Support component failed with exit code {0}.<br>{1}<br>Log: {2} | Apple Mobile Device Supportコンポーネントが終了コード{0}で失敗しました。<br>{1}<br>ログ: {2} | ✅ 完全一致 | 保留 |
| AppleInstallerStartFailed | 无法启动 Apple 安装程序。 | 無法啟動 Apple 安裝程式。 | 無法啟動 Apple 安裝程式。 | The Apple installer could not start. | Appleのインストーラーを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| AppleMobileDevice | Apple 移动设备 | Apple 流動裝置 | Apple 行動裝置 | Apple mobile device | Appleモバイルデバイス | ✅ 完全一致 | 保留 |
| AppleMuxPortConflict | 127.0.0.1:27015 被 {0} 占用，但未返回有效的 Apple 设备列表。请退出对应应用后重试。若为 Apple Devices，请先退出该应用，并在任务管理器结束 AppleMobileDeviceLauncher.exe 和 AppleMobileDeviceProcess.exe，再重新准备驱动。无需重复安装 Apple 支持组件。 | 127.0.0.1:27015 被 {0} 佔用，但未傳回有效的 Apple 裝置清單。請退出對應應用程式後重試。若為 Apple Devices，請先退出該應用程式，並在工作管理員結束 AppleMobileDeviceLauncher.exe 和 AppleMobileDeviceProcess.exe，再重新準備驅動程式。此連接埠衝突毋須重複安裝 Apple 支援元件。 | 127.0.0.1:27015 被 {0} 佔用，但未傳回有效的 Apple 裝置清單。請結束對應應用程式後重試。若為 Apple Devices，請先結束該應用程式，並在工作管理員結束 AppleMobileDeviceLauncher.exe 和 AppleMobileDeviceProcess.exe，再重新準備驅動程式。此連接埠衝突不需重複安裝 Apple 支援元件。 | 127.0.0.1:27015 is occupied by {0}, but did not return a valid Apple device list. Exit the corresponding application and retry. For Apple Devices, close the app and end AppleMobileDeviceLauncher.exe and AppleMobileDeviceProcess.exe in Task Manager, then prepare the driver again. Reinstalling Apple support components is not needed for this port conflict. | 127.0.0.1:27015は{0}に使われていますが、有効なAppleデバイス一覧が返りませんでした。該当するアプリケーションを終了して再試行してください。Apple Devicesの場合は、アプリを閉じ、タスクマネージャーでAppleMobileDeviceLauncher.exeとAppleMobileDeviceProcess.exeを終了してから、もう一度ドライバーを準備してください。このポートの競合では、Appleのサポートコンポーネントを再インストールする必要はありません。 | ✅ 完全一致 | 保留 |
| AppleMuxReady | Apple USB 驱动和设备通信服务已就绪（兼容 Apple Devices）。 | Apple USB 驅動程式和裝置通訊服務已就緒（支援 Apple Devices）。 | Apple USB 驅動程式和裝置通訊服務已就緒（支援 Apple Devices）。 | The Apple USB driver and device communication service are ready (Apple Devices supported). | Apple USBドライバーとデバイス通信サービスの準備ができています（Apple Devicesに対応）。 | ✅ 完全一致 | 保留 |
| AppleMuxUnknownListener | 未知进程 | 未知程序 | 未知處理程序 | an unknown process | 不明なプロセス | ✅ 完全一致 | 保留 |
| ApplePackageManagerStartFailed | 无法启动软件包管理器。 | 無法啟動套件管理員。 | 無法啟動套件管理員。 | The package manager could not start. | パッケージマネージャーを起動できませんでした。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| AppleRestartRequired | Apple Mobile Device Support 已安装，但 Windows 需要重启才能完成驱动和服务注册。请重启电脑后重新检测。<br>日志：{0} | Apple Mobile Device Support 已安裝，但 Windows 需要重新啟動才能完成驅動程式和服務註冊。請重新啟動電腦後重新偵測。<br>記錄：{0} | Apple Mobile Device Support 已安裝，但 Windows 需要重新啟動才能完成驅動程式和服務註冊。請重新啟動電腦後重新偵測。<br>記錄檔：{0} | Apple Mobile Device Support was installed, but Windows must restart to finish registering the driver and service. Restart the PC, then check again.<br>Log: {0} | Apple Mobile Device Supportをインストールしましたが、ドライバーとサービスの登録を完了するにはWindowsの再起動が必要です。PCを再起動してから、もう一度確認してください。<br>ログ: {0} | ✅ 完全一致 | 保留 |
| AppleServiceMissing | Apple USB 驱动已安装，但缺少 Apple Mobile Device Service | Apple USB 驅動程式已安裝，但缺少 Apple Mobile Device Service | Apple USB 驅動程式已安裝，但缺少 Apple Mobile Device Service | The Apple USB driver is installed, but Apple Mobile Device Service is missing | Apple USBドライバーはインストール済みですが、Apple Mobile Device Serviceがありません | ✅ 完全一致 | 保留 |
| AppleServiceNotReady | Apple USB 支持不完整：服务或 Apple USB 驱动包尚未就绪。请连接并解锁 iPhone 后重新检测。<br>日志：{0} | Apple USB 支援不完整：服務或 Apple USB 驅動程式包尚未就緒。請連接並解鎖 iPhone 後重新偵測。<br>記錄：{0} | Apple USB 支援不完整：服務或 Apple USB 驅動程式套件尚未就緒。請連線並解鎖 iPhone 後重新偵測。<br>記錄檔：{0} | Apple USB support is incomplete: the service or Apple USB driver package is not ready. Connect and unlock the iPhone, then check again.<br>Log: {0} | Apple USBサポートが不完全です。サービスまたはApple USBドライバーパッケージの準備ができていません。iPhoneを接続してロックを解除し、もう一度確認してください。<br>ログ: {0} | ✅ 完全一致 | 保留 |
| AppleServiceRunning | Apple USB 服务正在运行 | Apple USB 服務正在執行 | Apple USB 服務正在執行 | Apple USB service is running | Apple USBサービスが動作中です | ✅ 完全一致 | 保留 |
| AppleServiceStopped | Apple USB 服务已安装但未运行 | Apple USB 服務已安裝但未執行 | Apple USB 服務已安裝但未執行 | Apple USB support is installed but the service is stopped | Apple USBサポートはインストール済みですが、サービスが停止しています | ✅ 完全一致 | 保留 |
| AppleSignatureInvalid | Apple 安装包签名无法通过 Windows 验证，已拒绝执行。 | Apple 安裝套件簽名無法通過 Windows 驗證，已拒絕執行。 | Apple 安裝套件簽章無法通過 Windows 驗證，已拒絕執行。 | The Apple installer failed Windows signature validation and was not executed. | AppleのインストーラーがWindowsの署名検証に通らなかったため、実行しませんでした。 | ✅ 完全一致 | 保留 |
| AppleSupportDownloadProgress | 正在下载 Apple 服务组件：{0}%（{1:F1}/{2:F1} MB） | 正在下載 Apple 服務元件：{0}%（{1:F1}/{2:F1} MB） | 正在下載 Apple 服務元件：{0}%（{1:F1}/{2:F1} MB） | Downloading the Apple service component: {0}% ({1:F1}/{2:F1} MB) | Appleのサービスコンポーネントをダウンロード中: {0}%（{1:F1}/{2:F1}MB） | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AppleSupportDownloadProgressParallel | 正在下载 Apple 服务组件：{0}%（{1:F1}/{2:F1} MB，{3:F1} MB/s，{4} 路） | 正在下載 Apple 服務元件：{0}%（{1:F1}/{2:F1} MB，{3:F1} MB/s，{4} 路） | 正在下載 Apple 服務元件：{0}%（{1:F1}/{2:F1} MB，{3:F1} MB/s，{4} 路） | Downloading the Apple service component: {0}% ({1:F1}/{2:F1} MB, {3:F1} MB/s, {4} connections) | Appleのサービスコンポーネントをダウンロード中: {0}%（{1:F1}/{2:F1}MB、{3:F1}MB/秒、{4}接続） | ✅ 完全一致 | 保留 |
| AppleSupportDownloadProgressUnknown | 正在下载 Apple 服务组件：已下载 {0:F1} MB | 正在下載 Apple 服務元件：已下載 {0:F1} MB | 正在下載 Apple 服務元件：已下載 {0:F1} MB | Downloading the Apple service component: {0:F1} MB downloaded | Appleのサービスコンポーネントをダウンロード中: {0:F1}MBを取得済み | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| AppleSupportDownloadProgressUnknownParallel | 正在下载 Apple 服务组件：已下载 {0:F1} MB（{1:F1} MB/s，{2} 路） | 正在下載 Apple 服務元件：已下載 {0:F1} MB（{1:F1} MB/s，{2} 路） | 正在下載 Apple 服務元件：已下載 {0:F1} MB（{1:F1} MB/s，{2} 路） | Downloading the Apple service component: {0:F1} MB ({1:F1} MB/s, {2} connections) | Appleのサービスコンポーネントをダウンロード中: {0:F1}MB（{1:F1}MB/秒、{2}接続） | ✅ 完全一致 | 保留 |
| AppleSupportDownloadingCompatibility | 正在从 Apple 官方更新服务获取驱动组件… | 正在從 Apple 官方更新服務取得驅動程式元件… | 正在從 Apple 官方更新服務取得驅動程式元件… | Downloading the driver component from Apple Software Update… | Apple Software Updateからドライバーコンポーネントをダウンロードしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| AppleSupportExtractingCompatibility | 正在从 Apple 官方安装包提取服务组件… | 正在從 Apple 官方安裝套件提取服務元件… | 正在從 Apple 官方安裝套件提取服務元件… | Extracting the service component from the official Apple installer… | Apple公式インストーラーからサービスコンポーネントを展開しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| AppleSupportInstallTimeout | Apple USB 支持组件安装超时。 | Apple USB 支援元件安裝逾時。 | Apple USB 支援元件安裝逾時。 | Apple USB support installation timed out. | Apple USBサポートのインストールがタイムアウトしました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源；静态未发现引用，保留待后续调用核对 |
| AppleSupportInstallingCompatibility | 正在安装 Apple Mobile Device Service 兼容组件… | 正在安裝 Apple Mobile Device Service 相容元件… | 正在安裝 Apple Mobile Device Service 相容元件… | Installing the Apple Mobile Device Service compatibility component… | Apple Mobile Device Serviceの互換コンポーネントをインストールしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| AppleSupportInstallingStore | 正在从 Microsoft Store 安装或修复 Apple USB 支持… | 正在從 Microsoft Store 安裝或修復 Apple USB 支援… | 正在從 Microsoft Store 安裝或修復 Apple USB 支援… | Installing or repairing Apple USB support from Microsoft Store… | Microsoft StoreからApple USBサポートをインストールまたは修復しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号；静态未发现引用，保留待后续调用核对 |
| AppleSupportMissing | 未检测到 Apple Devices 或 Apple Mobile Device Support | 未偵測到 Apple Devices 或 Apple Mobile Device Support | 未偵測到 Apple Devices 或 Apple Mobile Device Support | Apple Devices or Apple Mobile Device Support was not found | Apple DevicesまたはApple Mobile Device Supportが見つかりません | ✅ 完全一致 | 保留 |
| AppleSupportPreparing | 正在准备 Apple USB 支持… | 正在準備 Apple USB 支援… | 正在準備 Apple USB 支援… | Preparing Apple USB support… | Apple USBサポートを準備しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| AppleSupportProcessTimeout | Apple 支持组件操作超时。 | Apple 支援元件操作逾時。 | Apple 支援元件操作逾時。 | The Apple support component operation timed out. | Appleのサポートコンポーネントの操作がタイムアウトしました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| AppleSupportReady | Apple USB 支持已就绪。 | Apple USB 支援已就緒。 | Apple USB 支援已就緒。 | Apple USB support is ready. | Apple USBサポートの準備ができました。 | ✅ 完全一致 | 保留 |
| AppleSupportStartingService | 正在启动 Apple Mobile Device Service… | 正在啟動 Apple Mobile Device Service… | 正在啟動 Apple Mobile Device Service… | Starting Apple Mobile Device Service… | Apple Mobile Device Serviceを起動しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| AppleSupportVerifying | 正在验证 Apple USB 驱动和服务… | 正在驗證 Apple USB 驅動程式和服務… | 正在驗證 Apple USB 驅動程式和服務… | Verifying the Apple USB driver and service… | Apple USBドライバーとサービスを検証しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| AppleUsbDeviceFormat | Apple USB 设备 {0} | Apple USB 裝置 {0} | Apple USB 裝置 {0} | Apple USB device {0} | Apple USBデバイス{0} | ✅ 完全一致 | 保留 |
| AppleUsbDriverMissing | Apple Mobile Device Service 已安装，但缺少 Apple USB 驱动包 | Apple Mobile Device Service 已安裝，但缺少 Apple USB 驅動程式包 | Apple Mobile Device Service 已安裝，但缺少 Apple USB 驅動程式套件 | Apple Mobile Device Service is installed, but the Apple USB driver package is missing | Apple Mobile Device Serviceはインストール済みですが、Apple USBドライバーパッケージがありません | ✅ 完全一致 | 保留 |
| AppleUsbEnvironment | Apple USB 环境 | Apple USB 環境 | Apple USB 環境 | Apple USB environment | Apple USB環境 | ✅ 完全一致 | 保留 |
| BackToSimple | 返回简洁界面 | 返回簡易介面 | 返回簡易介面 | Back to simple view | 簡易表示に戻る | ✅ 完全一致 | 保留 |
| Cancel | 取消 | 取消 | 取消 | Cancel | キャンセル | ✅ 完全一致 | 保留 |
| CannotOpenLogs | 无法打开日志 | 無法開啟記錄檔 | 無法開啟記錄檔 | Could not open logs | ログを開けませんでした | ✅ 完全一致 | 保留 |
| CannotOpenQq | 无法打开 QQ | 無法開啟 QQ | 無法開啟 QQ | Could not open QQ | QQを開けませんでした | ✅ 完全一致 | 保留 |
| CaptureFilterDriver | 采集过滤驱动 | 擷取過濾驅動程式 | 擷取篩選驅動程式 | Capture filter driver | キャプチャフィルタードライバー | ✅ 完全一致 | 保留 |
| CaptureInstalled | 采集驱动已安装 | 擷取驅動程式已安裝 | 擷取驅動程式已安裝 | Capture driver installed | キャプチャドライバーはインストール済み | ✅ 完全一致 | 保留 |
| CaptureMissing | 未安装采集驱动 | 未安裝擷取驅動程式 | 未安裝擷取驅動程式 | Capture driver not installed | キャプチャドライバーは未インストール | ✅ 完全一致 | 保留 |
| CheckPending | 正在检查 | 正在檢查 | 正在檢查 | Checking | 確認中 | ✅ 完全一致 | 保留 |
| Close | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 保留 |
| ConfirmOperation | 确认{0} | 確認{0} | 確認{0} | Confirm {0} | {0}の確認 | ✅ 完全一致 | 保留 |
| ConfirmOperationBody | 将对以下设备执行{0}：<br><br>{1}<br>{2}<br><br>操作只修改该设备的 libusb0 过滤器，不替换 Apple 官方驱动。Windows 可能请求管理员授权。 | 將對以下裝置執行{0}：<br><br>{1}<br>{2}<br><br>操作只修改這部裝置的 libusb0 過濾器，不替換 Apple 官方驅動程式。Windows 可能請求管理員授權。 | 將對以下裝置執行{0}：<br><br>{1}<br>{2}<br><br>操作只修改這台裝置的 libusb0 篩選器，不替換 Apple 官方驅動程式。Windows 可能請求管理員授權。 | Perform {0} on the following device:<br><br>{1}<br>{2}<br><br>Only this device's libusb0 filter is changed. Apple's official driver is not replaced. Windows may request administrator approval. | 次のデバイスで{0}を実行します。<br><br>{1}<br>{2}<br><br>変更するのは、このデバイスのlibusb0フィルターだけです。Apple公式のドライバーは置き換えません。Windowsから管理者の承認を求められる場合があります。 | ❌ 含义不一致 → ✅ 已修复 | {0} 是操作名，不是设备信息 |
| ConnectIphone | 请先连接 iPhone | 請先連接 iPhone | 請先連線 iPhone | Connect an iPhone first | 先にiPhoneを接続してください | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| ConnectPhoneBody | Apple USB 支持已准备好。请连接并解锁 iPhone；手机出现提示时点击“信任此电脑”。检测到设备后会自动继续。 | Apple USB 支援已準備就緒。請連接並解鎖 iPhone；手機出現提示時按一下「信任這部電腦」。偵測到裝置後會自動繼續。 | Apple USB 支援已準備就緒。請連線並解鎖 iPhone；手機出現提示時按一下「信任這台電腦」。偵測到裝置後會自動繼續。 | Apple USB support is ready. Connect and unlock the iPhone, then tap Trust if prompted. The tool continues automatically after it detects the device. | Apple USBサポートの準備ができました。iPhoneを接続してロックを解除し、確認が表示されたら「信頼」をタップしてください。デバイスを検出すると、自動で続行します。 | ✅ 完全一致 | 保留 |
| ConnectPhoneTitle | 请连接 iPhone | 請連接 iPhone | 請連線 iPhone | Connect an iPhone | iPhoneを接続 | ✅ 完全一致 | 保留 |
| Connected | 已连接 | 已連接 | 已連線 | Connected | 接続済み | ✅ 完全一致 | 保留 |
| ConnectionStatus | 连接状态 | 連接狀態 | 連線狀態 | Connection | 接続 | ✅ 完全一致 | 保留 |
| Continue | 继续 | 繼續 | 繼續 | Continue | 続行 | ✅ 完全一致 | 保留 |
| CopyGroup | 复制群号 | 複製群號 | 複製群組編號 | Copy group number | グループ番号をコピー | ✅ 完全一致 | 保留 |
| CurrentDevice | 当前设备 | 目前裝置 | 目前裝置 | Current device | 現在のデバイス | ✅ 完全一致 | 保留 |
| DeviceInstance | 设备实例 | 裝置執行個體 | 裝置執行個體 | Device instance | デバイスインスタンス | ✅ 完全一致 | 保留 |
| DeviceModelFormat | 设备型号 {0} | 裝置型號 {0} | 裝置型號 {0} | Model {0} | モデル{0} | ✅ 完全一致 | 保留 |
| DeviceNumberFormat | {0}（设备 {1}） | {0}（裝置 {1}） | {0}（裝置 {1}） | {0} (device {1}) | {0}（デバイス{1}） | ✅ 完全一致 | 保留 |
| DeviceOsFormat | {0} · iOS {1} | {0} · iOS {1} | {0} · iOS {1} | {0} · iOS {1} | {0} · iOS {1} | ✅ 完全一致 | 保留 |
| DeviceReady | {0} 的投屏驱动已经全部就绪。 | {0} 的螢幕鏡像驅動程式已全部就緒。 | {0} 的螢幕鏡像驅動程式已全部就緒。 | All mirroring drivers for {0} are ready. | {0}のミラーリング用ドライバーがすべて整いました。 | ❌ 含义不一致 → ✅ 已修复 | 补齐全部驱动就绪含义 |
| DeviceTrustAction | 请解锁 iPhone 或 iPad，并查看设备屏幕 | 請解鎖 iPhone 或 iPad，並查看裝置螢幕 | 請解鎖 iPhone 或 iPad，並查看裝置螢幕 | Unlock the iPhone or iPad and check its screen | iPhoneまたはiPadのロックを解除して画面を確認してください | ✅ 完全一致 | 保留 |
| DeviceTrustConfirmed | 出现了提示，我已点击“信任” | 出現了提示，我已按一下「信任」 | 出現了提示，我已按一下「信任」 | The prompt appeared and I tapped Trust | 確認が表示され、「信頼」をタップした | ✅ 完全一致 | 保留 |
| DeviceTrustExplanation | Windows 刚刚变更了驱动，可能会重新识别设备。如果设备出现“要信任此电脑吗？”，请点击“信任”并输入设备密码。 | Windows 剛剛變更了驅動程式，可能會重新辨識裝置。如果裝置出現「要信任這部電腦嗎？」，請按一下「信任」並輸入裝置密碼。 | Windows 剛剛變更了驅動程式，可能會重新辨識裝置。如果裝置出現「要信任這台電腦嗎？」，請按一下「信任」並輸入裝置密碼。 | Windows has changed a driver and may detect the device again. If “Trust This Computer?” appears on the device, tap Trust and enter the device passcode. | Windowsがドライバーを変更したため、デバイスが再検出されることがあります。デバイスに「このコンピュータを信頼しますか？」と表示されたら、「信頼」をタップしてデバイスのパスコードを入力してください。 | ✅ 完全一致 | 保留 |
| DeviceTrustNoPrompt | 没有出现提示（此前已信任此电脑） | 沒有出現提示（此前已信任這部電腦） | 沒有出現提示（此前已信任這台電腦） | No prompt appeared (this computer was already trusted) | 確認は表示されなかった（このコンピュータは信頼済み） | ✅ 完全一致 | 保留 |
| DeviceTrustNotHandled | 尚未处理 | 尚未處理 | 尚未處理 | Not handled yet | まだ対応していない | ✅ 完全一致 | 保留 |
| DeviceTrustPending | 驱动变更已完成。投屏前请解锁设备，并在设备上点击“信任”。 | 驅動程式變更已完成。螢幕鏡像前請解鎖裝置，並在裝置上按一下「信任」。 | 驅動程式變更已完成。螢幕鏡像前請解鎖裝置，並在裝置上按一下「信任」。 | Driver changes are complete. Unlock the device and tap Trust before mirroring. | ドライバーの変更が完了しました。ミラーリングの前に、デバイスのロックを解除して「信頼」をタップしてください。 | ✅ 完全一致 | 保留 |
| DeviceTrustQuestion | 设备上出现了什么情况？ | 裝置上出現了什麼情況？ | 裝置上出現了什麼情況？ | What happened on the device? | デバイスで何が起きましたか？ | ✅ 完全一致 | 保留 |
| DeviceTrustTitle | 确认设备信任状态 | 確認裝置信任狀態 | 確認裝置信任狀態 | Confirm device trust | デバイスの信頼を確認 | ✅ 完全一致 | 保留 |
| DevicesMissing | 已检测到 {0} 台设备，点击按钮自动安装缺失驱动。 | 已偵測到 {0} 部裝置，按一下按鈕自動安裝遺失驅動程式。 | 已偵測到 {0} 台裝置，按一下按鈕自動安裝遺失驅動程式。 | Devices detected: {0}. Click the button to install missing drivers. | 検出したデバイス: {0}台。ボタンを押すと、不足しているドライバーをインストールします。 | ⚠️ 需要优化 → ✅ 已修复 | 用数量标签兼容单复数 |
| DevicesReady | 已检测到 {0} 台设备，投屏驱动均已就绪。 | 已偵測到 {0} 部裝置，螢幕鏡像驅動程式均已就緒。 | 已偵測到 {0} 台裝置，螢幕鏡像驅動程式均已就緒。 | Devices detected: {0}. All mirroring drivers are ready. | 検出したデバイス: {0}台。ミラーリング用ドライバーはすべて整っています。 | ⚠️ 需要优化 → ✅ 已修复 | 用数量标签兼容单复数 |
| DriverChangeNotice | 采集操作修改所选设备的过滤器；父驱动管理可在你单独确认后替换该设备的驱动绑定。 | 擷取操作修改所選裝置的過濾器；父驅動程式管理可在你另行確認後取代該裝置的驅動程式綁定。 | 擷取操作修改所選裝置的篩選器；父驅動程式管理可在您另行確認後取代該裝置的驅動程式綁定。 | Capture operations change the selected device's filter. Parent driver management can replace its driver binding after a separate confirmation. | キャプチャ操作は、選択したデバイスのフィルターを変更します。親ドライバーの管理では、別途確認したうえでドライバーの割り当てを置き換えることがあります。 | ✅ 完全一致 | 保留 |
| DriverCleanupBody | 在独立窗口中选择设备，清理其关联设备节点及可安全移除的驱动包，可能包括 Apple 官方驱动。其他设备仍在使用的驱动包会保留；无法确定使用情况时只清理设备节点。修改系统前需要确认。 | 在獨立視窗中選擇裝置，清理其關聯裝置節點及可安全移除的驅動程式套件，可能包括 Apple 官方驅動程式。其他裝置仍在使用的驅動程式套件會保留；無法確定使用情況時只清理裝置節點。修改系統前需要確認。 | 在獨立視窗中選擇裝置，清理其關聯裝置節點及可安全移除的驅動程式套件，可能包括 Apple 官方驅動程式。其他裝置仍在使用的驅動程式套件會保留；無法確定使用情況時只清理裝置節點。修改系統前需要確認。 | Choose a device in a separate window to remove its associated device nodes and driver packages that can be safely removed, which may include Apple drivers. Packages used by other devices are preserved. If package usage cannot be verified, only device nodes are removed. Confirmation is required before changing the system. | 別のウィンドウでデバイスを選ぶと、そのデバイスに関連するデバイスノードと、安全に削除できるドライバーパッケージ（Appleのドライバーを含む場合があります）を削除します。ほかのデバイスが使っているパッケージは残します。パッケージの使用状況を確認できない場合は、デバイスノードだけを削除します。システムを変更する前に確認が必要です。 | ✅ 完全一致 | 保留 |
| DriverCleanupHostStartFailed | 无法启动管理员驱动清理进程。 | 無法啟動管理員驅動程式清理程序。 | 無法啟動管理員驅動程式清理程序。 | The driver cleanup process could not start with administrator access. | ドライバー整理のプロセスを管理者権限で開始できませんでした。 | ❌ 缺失 → ✅ 已修复 | 清理启动失败在已初始化的界面中使用三语提示；启动前的诊断回退保留 |
| DriverCleanupProtectionFailed | 无法验证并保护驱动管理器文件，已停止请求管理员权限。 | 無法驗證及保護驅動程式管理員檔案，已停止要求管理員權限。 | 無法驗證及保護驅動程式管理員檔案，已停止要求管理員權限。 | The driver manager file could not be verified and protected. Administrator access was not requested. | ドライバー管理のファイルを検証して保護できませんでした。管理者権限は要求していません。 | ❌ 缺失 → ✅ 已修复 | 清理启动失败在已初始化的界面中使用三语提示；启动前的诊断回退保留 |
| DriverCleanupScriptMissing | 找不到驱动清理脚本：{0} | 找不到驅動程式清理指令碼：{0} | 找不到驅動程式清理指令碼：{0} | The driver cleanup script was not found: {0} | ドライバー整理スクリプトが見つかりません: {0} | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| DriverCleanupScriptStartFailed | 无法启动驱动清理脚本：{0} | 無法啟動驅動程式清理指令碼：{0} | 無法啟動驅動程式清理指令碼：{0} | Could not start the driver cleanup script: {0} | ドライバー整理スクリプトを開始できませんでした: {0} | ✅ 完全一致 | 保留 |
| DriverCleanupTitle | 清理设备驱动 | 清理裝置驅動程式 | 清理裝置驅動程式 | Clean up device drivers | デバイスドライバーを整理 | ✅ 完全一致 | 保留 |
| DriverExecutableMissing | 无法确定驱动管理器的可执行文件路径。 | 無法確定驅動程式管理員的可執行檔路徑。 | 無法確定驅動程式管理員的可執行檔路徑。 | The driver manager executable path could not be determined. | ドライバー管理の実行ファイルのパスを特定できませんでした。 | ✅ 完全一致 | 保留 |
| DriverFilterInstalledReconnect | 已安装所选设备的采集过滤驱动。请重新连接设备以完成启用。 | 已安裝所選裝置的擷取過濾驅動程式。請重新連接裝置以完成啟用。 | 已安裝所選裝置的擷取篩選驅動程式。請重新連線裝置以完成啟用。 | Selected-device capture filter installed. Reconnect the device to complete activation. | 選択したデバイスのキャプチャフィルターをインストールしました。有効にするには、デバイスを再接続してください。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverFilterRemovedReconnect | 已移除所选设备的采集过滤驱动。请重新连接设备以完成卸载。 | 已移除所選裝置的擷取過濾驅動程式。請重新連接裝置以完成卸載。 | 已移除所選裝置的擷取篩選驅動程式。請重新連線裝置以完成卸載。 | Selected-device capture filter removed. Reconnect the device to complete unload. | 選択したデバイスのキャプチャフィルターを削除しました。アンロードを完了するには、デバイスを再接続してください。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverInstalled | 当前设备的采集过滤驱动已安装并验证。 | 目前裝置的擷取過濾驅動程式已安裝並驗證。 | 目前裝置的擷取篩選驅動程式已安裝並驗證。 | The capture filter was installed and verified on the current device. | 現在のデバイスにキャプチャフィルターをインストールし、検証しました。 | ✅ 完全一致 | 保留 |
| DriverOperationDetailsFormat | 详细信息：{0} | 詳細資料：{0} | 詳細資料：{0} | Details: {0} | 詳細: {0} | ❌ 缺失 → ✅ 已修复 | 驱动操作详情标题 |
| DriverOperationRollbackIncomplete | 驱动操作失败，回滚未完成。请查看操作日志。 | 驅動程式操作失敗，復原未完成。請查看操作記錄。 | 驅動程式操作失敗，復原未完成。請查看操作記錄檔。 | Driver operation failed and rollback was incomplete. Review the operation log. | ドライバー操作に失敗し、ロールバックも完了しませんでした。操作ログを確認してください。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverOperationRolledBack | 驱动操作失败，已还原所有已备份的状态。 | 驅動程式操作失敗，已還原所有已備份的狀態。 | 驅動程式操作失敗，已還原所有已備份的狀態。 | Driver operation failed and all captured state was restored. | ドライバー操作に失敗しましたが、保存していた状態をすべて復元しました。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverParentRemoved | 已移除错误的 Apple 父设备。请重新连接 iPhone 以重新绑定 usbccgp。 | 已移除錯誤的 Apple 父裝置。請重新連接 iPhone 以重新綁定 usbccgp。 | 已移除錯誤的 Apple 父裝置。請重新連線 iPhone 以重新綁定 usbccgp。 | The incorrect Apple parent device was removed. Reconnect the iPhone to rebind usbccgp. | 正しくないAppleの親デバイスを削除しました。iPhoneを再接続して、usbccgpを割り当て直してください。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverParentRepairRejected | 父驱动修复已被拒绝，尚未修改系统。 | 父驅動程式修復已被拒絕，尚未修改系統。 | 父驅動程式修復已被拒絕，尚未修改系統。 | Parent driver repair was rejected before any system change. | システムを変更する前に、親ドライバーの修復が拒否されました。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverParentRepairStopped | 移除请求开始后，父驱动修复已停止。请重新连接 iPhone 并查看操作日志。 | 移除要求開始後，父驅動程式修復已停止。請重新連接 iPhone 並查看操作記錄。 | 移除要求開始後，父驅動程式修復已停止。請重新連線 iPhone 並查看操作記錄檔。 | Parent driver repair stopped after the removal request began. Reconnect the iPhone and review the operation log. | 削除要求の開始後に、親ドライバーの修復が中断されました。iPhoneを再接続し、操作ログを確認してください。 | ❌ 缺失 → ✅ 已修复 | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 |
| DriverRefreshFailed | 状态刷新失败，以上操作结果已保留。原因：{0}。日志：{1} | 狀態重新整理失敗，以上操作結果已保留。原因：{0}。記錄：{1} | 狀態重新整理失敗，以上操作結果已保留。原因：{0}。記錄檔：{1} | Status refresh failed; the operation result above is preserved. Reason: {0}. Log: {1} | 状態を更新できませんでした。上の操作結果はそのまま残しています。理由: {0}。ログ: {1} | ✅ 完全一致 | 保留 |
| DriverResultExitCodeMismatchFormat | 管理员驱动操作结果与进程退出代码 {0} 不一致。 | 管理員驅動程式操作結果與程序結束代碼 {0} 不一致。 | 管理員驅動程式操作結果與程序結束代碼 {0} 不一致。 | The elevated driver result did not match process exit code {0}. | 昇格したドライバーの結果が、プロセスの終了コード{0}と一致しませんでした。 | ❌ 缺失 → ✅ 已修复 | 驱动验证失败提示补齐三语 |
| DriverResultTargetMismatch | 管理员驱动操作返回了其他设备的结果，已拒绝使用。 | 管理員驅動程式操作傳回了其他裝置的結果，已拒絕使用。 | 管理員驅動程式操作傳回了其他裝置的結果，已拒絕使用。 | The elevated driver result did not match the requested device and was rejected. | 昇格したドライバーの結果が要求したデバイスと一致しなかったため、破棄しました。 | ❌ 缺失 → ✅ 已修复 | 将用户可见硬编码错误或状态提示迁入三语资源 |
| DriverStatus | 驱动状态 | 驅動程式狀態 | 驅動程式狀態 | Driver status | ドライバーの状態 | ✅ 完全一致 | 保留 |
| DriverUninstalled | 当前设备的采集过滤驱动已卸载。 | 目前裝置的擷取過濾驅動程式已解除安裝。 | 目前裝置的擷取篩選驅動程式已解除安裝。 | The capture filter was removed from the current device. | 現在のデバイスからキャプチャフィルターを削除しました。 | ✅ 完全一致 | 保留 |
| DriverWaitingSafeStop | 操作用时较长，已请求取消，正在等待当前步骤和恢复完成。请保持窗口打开。日志：{0} | 操作需時較長，已請求取消，正在等待目前步驟及還原完成。請保持視窗開啟。記錄：{0} | 操作需時較長，已請求取消，正在等待目前步驟及還原完成。請保持視窗開啟。記錄檔：{0} | The operation is taking longer than expected. Cancellation was requested; waiting for the current step and recovery to finish. Keep this window open. Log: {0} | 操作に想定より時間がかかっています。キャンセルを要求したので、現在の手順と復旧が終わるのを待っています。このウィンドウは閉じないでください。ログ: {0} | ✅ 完全一致 | 保留 |
| ElevatedInvalidResult | 管理员驱动进程返回了无效结果。 | 以系統管理員身分執行的驅動程式工具傳回了無效結果。 | 以系統管理員身分執行的驅動程式工具傳回了無效結果。 | The elevated driver process returned an invalid result. | 昇格したドライバープロセスが正しくない結果を返しました。 | ✅ 完全一致 | 保留 |
| ElevatedProcessNoResult | 管理员驱动进程以代码 {0} 退出，但没有返回结果。 | 以系統管理員身分執行的驅動程式工具以代碼 {0} 退出，但沒有傳回結果。 | 以系統管理員身分執行的驅動程式工具以代碼 {0} 退出，但沒有傳回結果。 | The elevated driver process exited with code {0} without returning a result. | 昇格したドライバープロセスが、結果を返さずにコード{0}で終了しました。 | ✅ 完全一致 | 保留 |
| ElevatedProcessStartFailed | 管理员驱动进程未能启动。 | 以系統管理員身分執行的驅動程式操作未能啟動。 | 以系統管理員身分執行的驅動程式操作未能啟動。 | The elevated driver process could not be started. | 昇格したドライバープロセスを開始できませんでした。 | ✅ 完全一致 | 保留 |
| ElevatedProcessTimeout | 管理员驱动操作已超时，请查看操作日志后重试。 | 以系統管理員身分執行的驅動程式操作已逾時，請查看操作記錄後重試。 | 以系統管理員身分執行的驅動程式操作已逾時，請查看操作記錄檔後重試。 | The elevated driver operation timed out. Review the operation log before retrying. | 昇格したドライバー操作がタイムアウトしました。再試行する前に操作ログを確認してください。 | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| FailureHeading | 未能完成驱动操作 | 未能完成驅動程式操作 | 未能完成驅動程式操作 | The driver operation could not be completed | ドライバー操作を完了できませんでした | ✅ 完全一致 | 保留 |
| FailureMethods | 可以选择以下一种处理方式 | 你可以選擇以下其中一種處理方式 | 您可以選擇以下其中一種處理方式 | Choose one of the following options | 次のいずれかの方法を選んでください | ✅ 完全一致 | 保留 |
| FailureTitle | 驱动处理失败 | 驅動程式處理失敗 | 驅動程式處理失敗 | Driver operation failed | ドライバー操作に失敗しました | ✅ 完全一致 | 保留 |
| ForceDriverCleanup | 清理设备驱动 | 清理裝置驅動程式 | 清理裝置驅動程式 | Clean up device drivers | デバイスドライバーを整理 | ✅ 完全一致 | 保留 |
| GroupCopiedBody | QQ 群号 1050045279 已复制。请在 QQ 中搜索并申请加入。 | QQ 群號 1050045279 已複製。請在 QQ 中搜尋並申請加入。 | QQ 群組編號 1050045279 已複製。請在 QQ 中搜尋並申請加入。 | QQ group 1050045279 was copied. Search for it in QQ to apply. | QQグループ1050045279をコピーしました。QQで検索して参加を申請してください。 | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| GroupCopiedTitle | 群号已复制 | 群號已複製 | 群組編號已複製 | Group number copied | グループ番号をコピーしました | ✅ 完全一致 | 保留 |
| HelpBody | 加入 QQ 群 1050045279，并提供操作日志。 | 加入 QQ 群 1050045279，並提供操作記錄。 | 加入 QQ 群組 1050045279，並提供操作記錄檔。 | Join QQ group 1050045279 and provide the operation log. | QQグループ1050045279に参加し、操作ログを提示してください。 | ✅ 完全一致 | 保留 |
| HelpBrowserFailed | 请手动打开：{0}。原因：{1} | 請手動開啟：{0}。原因：{1} | 請手動開啟：{0}。原因：{1} | Open this address manually: {0}. Reason: {1} | 次のアドレスを手動で開いてください: {0}。理由: {1} | ✅ 完全一致 | 保留 |
| HelpBrowserFailedTitle | 无法打开帮助网站 | 無法開啟說明網站 | 無法開啟說明網站 | Cannot open the help website | ヘルプのWebサイトを開けません | ✅ 完全一致 | 保留 |
| HelpTitle | 获取人工帮助 | 取得人工幫助 | 取得人工協助 | Get community help | コミュニティでヘルプを受ける | ✅ 完全一致 | 保留 |
| HistoricalDevice | 历史设备 | 過往裝置 | 過往裝置 | Previously connected device | 以前に接続したデバイス | ⚠️ 需要优化 → ✅ 已修复 | 优化自然表达和可读性 |
| Install | 安装 | 安裝 | 安裝 | Install | インストール | ✅ 完全一致 | 保留 |
| InstallAll | 一键安装全部驱动 | 一按安裝全部驅動程式 | 一鍵安裝全部驅動程式 | Install all drivers | すべてのドライバーをインストール | ✅ 完全一致 | 保留 |
| InstallAppleDevices | 安装 Apple USB 支持 | 安裝 Apple USB 支援 | 安裝 Apple USB 支援 | Install Apple USB support | Apple USBサポートをインストール | ✅ 完全一致 | 保留 |
| Installed | 已安装 | 已安裝 | 已安裝 | Installed | インストール済み | ✅ 完全一致 | 保留 |
| InstallingDriver | 正在为 {0} 安装采集驱动… | 正在為 {0} 安裝擷取驅動程式… | 正在為 {0} 安裝擷取驅動程式… | Installing the capture driver for {0}… | {0}のキャプチャドライバーをインストールしています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| InvalidDeviceTarget | 拒绝了无效的 Apple 设备目标。 | 拒絕了無效的 Apple 裝置目標。 | 拒絕了無效的 Apple 裝置目標。 | The selected Apple device target is invalid. | 選択したAppleデバイスの対象が正しくありません。 | ✅ 完全一致 | 保留 |
| LibUsbCheckFailed | 无法检查 libusb0： | 無法檢查 libusb0： | 無法檢查 libusb0： | Could not inspect libusb0:  | libusb0を調べられませんでした:  | ✅ 完全一致 | 保留 |
| LibUsbFilesMismatch | libusb0 文件缺失或与受信任版本不一致 | libusb0 檔案遺失或與受信任版本不一致 | libusb0 檔案遺失或與受信任版本不一致 | libusb0 files are missing or do not match the trusted version | libusb0のファイルが見つからないか、信頼済みのバージョンと一致しません | ✅ 完全一致 | 保留 |
| LibUsbMissing | libusb0 共享服务尚未安装 | libusb0 共用服務尚未安裝 | libusb0 共用服務尚未安裝 | The libusb0 shared service is not installed | libusb0共有サービスがインストールされていません | ✅ 完全一致 | 保留 |
| LibUsbReadyOnConnect | libusb0 已安装，连接设备后将加载 | libusb0 已安裝，連接裝置後將載入 | libusb0 已安裝，連線裝置後將載入 | libusb0 is installed and will load when a device connects | libusb0はインストール済みで、デバイスの接続時に読み込まれます | ✅ 完全一致 | 保留 |
| LibUsbRunning | libusb0 {0} 正在运行 | libusb0 {0} 正在執行 | libusb0 {0} 正在執行 | libusb0 {0} is running | libusb0 {0}が動作中です | ✅ 完全一致 | 保留 |
| LogSuffix | 日志：{0} | 記錄：{0} | 記錄檔：{0} | Log: {0} | ログ: {0} | ✅ 完全一致 | 保留 |
| Maximize | 最大化或还原 | 最大化或還原 | 最大化或還原 | Maximize or restore | 最大化または元に戻す | ✅ 完全一致 | 保留 |
| Minimize | 最小化 | 最小化 | 最小化 | Minimize | 最小化 | ✅ 完全一致 | 保留 |
| NamedDeviceFormat | {0}（{1}） | {0}（{1}） | {0}（{1}） | {0} ({1}) | {0}（{1}） | ✅ 完全一致 | 保留 |
| NoSelection | 未选择设备 | 未選擇裝置 | 未選擇裝置 | No device selected | デバイスが選択されていません | ✅ 完全一致 | 保留；静态未发现引用，保留待后续调用核对 |
| OfflineMsiFailed | 离线 AppleMobileDeviceSupport MSI 安装失败，退出代码 {0}。<br>{1}<br>日志：{2} | 離線 AppleMobileDeviceSupport MSI 安裝失敗，結束代碼 {0}。<br>{1}<br>記錄：{2} | 離線 AppleMobileDeviceSupport MSI 安裝失敗，結束代碼 {0}。<br>{1}<br>記錄檔：{2} | The offline AppleMobileDeviceSupport MSI failed with exit code {0}.<br>{1}<br>Log: {2} | オフラインのAppleMobileDeviceSupport MSIが終了コード{0}で失敗しました。<br>{1}<br>ログ: {2} | ✅ 完全一致 | 保留 |
| OpenLogs | 打开日志 | 開啟記錄檔 | 開啟記錄檔 | Open logs | ログを開く | ✅ 完全一致 | 保留 |
| OpenWebsite | 打开官网 | 開啟官網 | 開啟官網 | Open website | Webサイトを開く | ✅ 完全一致 | 保留 |
| Operating | 正在执行{0}：{1}… | 正在執行{0}：{1}… | 正在執行{0}：{1}… | Operation: {0} — {1}… | 実行中: {0} — {1}… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号；参数为 Install/Repair/Uninstall 基本形式，避免组成 Install device 的假进行时 |
| ParentBackupFormat | 状态快照：{0} | 狀態快照：{0} | 狀態快照：{0} | State snapshot: {0} | 状態のスナップショット: {0} | ✅ 完全一致 | 保留 |
| ParentBind | 绑定所选驱动 | 綁定所選驅動程式 | 綁定所選驅動程式 | Bind selected driver | 選択したドライバーを割り当て | ✅ 完全一致 | 保留 |
| ParentBindingComplete | 父驱动已重新绑定，并已确认设备正常启动。 | 父驅動程式已重新綁定，並已確認裝置正常啟動。 | 父驅動程式已重新綁定，並已確認裝置正常啟動。 | The parent driver was rebound and the device started successfully. | 親ドライバーを割り当て直し、デバイスが正常に開始しました。 | ✅ 完全一致 | 保留 |
| ParentBindingRestartRequired | Windows 已接受父驱动绑定，请重启电脑后重新检测；当前尚未验证生效。 | Windows 已接受父驅動程式綁定，請重新啟動電腦後再檢測；目前尚未驗證是否生效。 | Windows 已接受父驅動程式綁定，請重新啟動電腦後再檢測；目前尚未驗證是否生效。 | Windows accepted the parent driver binding. Restart the PC and refresh to verify it; activation has not yet been verified. | Windowsが親ドライバーの割り当てを受け付けました。PCを再起動してから更新し、確認してください。有効になったことは、まだ確認できていません。 | ✅ 完全一致 | 保留 |
| ParentChangeRecoveryNeeded | 父驱动操作未完成，无法确认已恢复。请重新插拔手机并刷新；必要时在父驱动管理或设备管理器中重新绑定驱动。状态快照和日志保留了操作信息。 | 父驅動程式操作未完成，無法確認已還原。請重新插拔手機並重新整理；必要時在父驅動程式管理或裝置管理員中重新綁定驅動程式。狀態快照及記錄保留了操作資料。 | 父驅動程式操作未完成，無法確認已還原。請重新插拔手機並重新整理；必要時在父驅動程式管理或裝置管理員中重新綁定驅動程式。狀態快照及記錄檔保留了操作資料。 | The parent driver operation did not complete and recovery could not be verified. Reconnect the phone and refresh; use parent driver management or Device Manager to rebind if needed. The state snapshot and log contain operation details. | 親ドライバーの操作が完了せず、復旧も確認できませんでした。スマートフォンを再接続して更新し、必要なら親ドライバーの管理またはデバイスマネージャーで割り当て直してください。操作の詳細は、状態のスナップショットとログにあります。 | ✅ 完全一致 | 保留 |
| ParentChangeRejected | 修改未执行：设备状态、确认信息或目标驱动已变化，或准备工作失败。请刷新后重新确认，详细原因见日志。 | 未執行變更：裝置狀態、確認資料或目標驅動程式已變更，或準備工作失敗。請重新整理後再次確認，詳細原因請參閱記錄。 | 未執行變更：裝置狀態、確認資料或目標驅動程式已變更，或準備工作失敗。請重新整理後再次確認，詳細原因請參閱記錄檔。 | No change was made: the device state, confirmation, or target driver changed, or preparation failed. Refresh and confirm again; see the log for details. | 変更は行われませんでした。デバイスの状態、確認内容、変更後のドライバーのいずれかが変わったか、準備に失敗しました。更新してもう一度確認してください。詳細はログを確認してください。 | ✅ 完全一致 | 保留 |
| ParentChangeRolledBack | 父驱动绑定失败，已恢复原驱动绑定。原有故障可能仍然存在，请查看日志。 | 父驅動程式綁定失敗，已還原原驅動程式綁定。原有問題可能仍然存在，請查看記錄。 | 父驅動程式綁定失敗，已還原原驅動程式綁定。原有問題可能仍然存在，請查看記錄檔。 | Parent driver binding failed. The previous driver binding was restored; its original problem may remain. See the log for details. | 親ドライバーの割り当てに失敗しました。元の割り当てを復元しましたが、元の問題が残っている場合があります。詳細はログを確認してください。 | ✅ 完全一致 | 保留 |
| ParentCompositeUnavailable | 无法读取 Windows USB 复合驱动，请打开父驱动管理查看其他选项。 | 無法讀取 Windows USB 複合驅動程式，請開啟父驅動程式管理查看其他選項。 | 無法讀取 Windows USB 複合驅動程式，請開啟父驅動程式管理查看其他選項。 | The Windows USB composite driver is unavailable. Open parent driver management for other options. | Windows標準のUSBコンポジットドライバーを利用できません。ほかの選択肢は、親ドライバーの管理で確認してください。 | ✅ 完全一致 | 保留 |
| ParentConfirmApply | 确认修改 | 確認修改 | 確認修改 | Confirm change | 変更を確定 | ✅ 完全一致 | 保留 |
| ParentConfirmBody | 设备：{0}<br>{1}<br><br>当前状态：<br>{2}<br><br>执行操作／目标驱动：<br>{3}<br><br>将修改这台手机的父驱动，可能替换 Apple 官方或第三方绑定，并暂时中断该手机的 USB 连接、投屏、控制和 Apple 软件连接。子接口可能重新枚举。Windows 可能要求管理员授权、重新插拔或重启。<br><br>操作前会保存驱动绑定和过滤器状态快照；绑定失败会尝试恢复原绑定，但无法保证恢复成功。是否继续？ | 裝置：{0}<br>{1}<br><br>目前狀態：<br>{2}<br><br>執行操作／目標驅動程式：<br>{3}<br><br>將修改這部手機的父驅動程式，可能取代 Apple 官方或第三方綁定，並暫時中斷此手機的 USB 連線、螢幕鏡像、控制及 Apple 軟件連線。子介面可能重新列舉。Windows 可能要求管理員授權、重新插拔或重新啟動。<br><br>操作前會儲存驅動程式綁定及過濾器狀態快照；綁定失敗會嘗試還原原綁定，但無法保證還原成功。是否繼續？ | 裝置：{0}<br>{1}<br><br>目前狀態：<br>{2}<br><br>執行操作／目標驅動程式：<br>{3}<br><br>將修改這台手機的父驅動程式，可能取代 Apple 官方或第三方綁定，並暫時中斷此手機的 USB 連線、螢幕鏡像、控制及 Apple 軟體連線。子介面可能重新列舉。Windows 可能要求管理員授權、重新插拔或重新啟動。<br><br>操作前會儲存驅動程式綁定及篩選器狀態快照；綁定失敗會嘗試還原原綁定，但無法保證還原成功。是否繼續？ | Device: {0}<br>{1}<br><br>Current state:<br>{2}<br><br>Action / target driver:<br>{3}<br><br>This changes this phone’s parent driver and may replace an Apple or third-party binding. USB connectivity, mirroring, control, and Apple software connections may be interrupted. Child interfaces may be enumerated again. Windows may request administrator approval, reconnection, or a restart.<br><br>Driver binding and filter state will be saved before changes. A failed binding triggers an attempt to restore the previous binding, but recovery is not guaranteed. Continue? | デバイス: {0}<br>{1}<br><br>現在の状態:<br>{2}<br><br>操作 / 変更後のドライバー:<br>{3}<br><br>この操作は、このスマートフォンの親ドライバーを変更し、Appleまたはサードパーティの割り当てを置き換えることがあります。USB接続、ミラーリング、リモート操作、Appleのソフトウェアとの接続が中断される場合があります。子インターフェイスが再列挙されることもあります。Windowsから、管理者の承認、再接続、再起動を求められる場合があります。<br><br>変更の前に、ドライバーの割り当てとフィルターの状態を保存します。割り当てに失敗した場合は元の割り当てへの復元を試みますが、復旧は保証されません。続行しますか？ | ✅ 完全一致 | 保留 |
| ParentConfirmTitle | 确认修改 Apple 父驱动 | 確認修改 Apple 父驅動程式 | 確認修改 Apple 父驅動程式 | Confirm Apple parent driver change | Appleの親ドライバーの変更を確認 | ✅ 完全一致 | 保留 |
| ParentDeviceUnavailable | 所选手机已断开，请重新连接后再操作。 | 所選手機已中斷連線，請重新連接後再操作。 | 所選手機已中斷連線，請重新連線後再操作。 | The selected phone is disconnected. Reconnect it before continuing. | 選択したスマートフォンが切断されています。続行する前に再接続してください。 | ✅ 完全一致 | 保留 |
| ParentDriverSelection | 目标驱动（系统复合驱动及 Windows 提供的适用驱动） | 目標驅動程式（系統複合驅動程式及 Windows 提供的適用驅動程式） | 目標驅動程式（系統複合驅動程式及 Windows 提供的適用驅動程式） | Target driver (system composite driver and drivers available for this device) | 変更後のドライバー（システムのコンポジットドライバーと、このデバイスで使えるドライバー） | ✅ 完全一致 | 保留 |
| ParentHealthy | 已正常启动 | 已正常啟動 | 已正常啟動 | Started and healthy | 開始済みで正常 | ✅ 完全一致 | 保留 |
| ParentListPartial | 部分驱动列表读取失败，以下仍列出可用选项。详细信息： | 部分驅動程式清單讀取失敗，以下仍列出可用選項。詳細資料： | 部分驅動程式清單讀取失敗，以下仍列出可用選項。詳細資料： | Some driver lists could not be read. Available choices are still listed. Details: | 一部のドライバー一覧を読み取れませんでした。利用できる選択肢は表示しています。詳細: | ✅ 完全一致 | 保留 |
| ParentListUnavailable | 无法读取驱动列表。可重建设备后重试，详细原因见日志。 | 無法讀取驅動程式清單。可重建裝置後重試，詳細原因請參閱記錄。 | 無法讀取驅動程式清單。可重建裝置後重試，詳細原因請參閱記錄檔。 | The driver list could not be read. Rebuild the device and retry; see the log for details. | ドライバー一覧を読み取れませんでした。デバイスを再構築して再試行してください。詳細はログを確認してください。 | ✅ 完全一致 | 保留 |
| ParentManagerHelp | 可修改任意当前父驱动，包括 Apple 官方驱动、第三方驱动或缺失的绑定。有线投屏通常需要 USB Composite Device（usbccgp）。请选择目标驱动，下一步将确认修改。 | 可修改任何目前的父驅動程式，包括 Apple 官方驅動程式、第三方驅動程式或遺失的綁定。有線螢幕鏡像通常需要 USB Composite Device（usbccgp）。請選取目標驅動程式，下一步將確認變更。 | 可修改任何目前的父驅動程式，包括 Apple 官方驅動程式、第三方驅動程式或遺失的綁定。有線螢幕鏡像通常需要 USB Composite Device（usbccgp）。請選取目標驅動程式，下一步將確認變更。 | You can change any current parent binding, including Apple, third-party, or missing drivers. Wired mirroring normally requires USB Composite Device (usbccgp). Select the target driver, then review and confirm the change. | Apple、サードパーティ、未割り当てのドライバーを含め、現在の親ドライバーの割り当てはどれでも変更できます。有線ミラーリングには、通常USB Composite Device（usbccgp）が必要です。変更後のドライバーを選び、内容を確認してから変更を確定してください。 | ✅ 完全一致 | 保留 |
| ParentManagerTitle | 父驱动管理 | 父驅動程式管理 | 父驅動程式管理 | Manage parent driver | 親ドライバーを管理 | ✅ 完全一致 | 保留 |
| ParentNeedsAttention | 未启动或需要检查 | 未啟動或需要檢查 | 未啟動或需要檢查 | Not started or needs attention | 未開始、または要確認 | ✅ 完全一致 | 保留 |
| ParentNoInf | 无驱动包 | 沒有驅動程式套件 | 沒有驅動程式套件 | No driver package | ドライバーパッケージなし | ✅ 完全一致 | 保留 |
| ParentNoService | 未绑定服务 | 未綁定服務 | 未綁定服務 | No service bound | 割り当てられたサービスなし | ✅ 完全一致 | 保留 |
| ParentRepairFailed | 父驱动重新绑定后仍不是 usbccgp，已停止自动安装。日志：{0} | 父驅動程式重新綁定後仍不是 usbccgp，已停止自動安裝。記錄：{0} | 父驅動程式重新綁定後仍不是 usbccgp，已停止自動安裝。記錄檔：{0} | The parent driver is still not usbccgp after repair; automatic installation stopped. Log: {0} | 修復後も親ドライバーがusbccgpになりませんでした。自動インストールを中止しました。ログ: {0} | ✅ 完全一致 | 保留 |
| ParentReset | 重建设备 | 重建裝置 | 重建裝置 | Rebuild device | デバイスを再構築 | ✅ 完全一致 | 保留 |
| ParentResetComplete | 已请求移除父设备。请拔下并重新连接手机，让 Windows 重新枚举，再检查父驱动状态。 | 已要求移除父裝置。請拔下並重新連接手機，讓 Windows 重新列舉，再檢查父驅動程式狀態。 | 已要求移除父裝置。請拔下並重新連線手機，讓 Windows 重新列舉，再檢查父驅動程式狀態。 | Parent device removal was requested. Unplug and reconnect the phone so Windows can enumerate it again, then check its parent driver status. | 親デバイスの削除を要求しました。Windowsが再列挙できるように、スマートフォンを取り外して再接続してから、親ドライバーの状態を確認してください。 | ✅ 完全一致 | 保留 |
| ParentResetHelp | “重建设备”会移除所选父设备及其子接口，随后需重新连接手机。原驱动包会保留，Windows 可能再次选择原驱动；更换绑定请选择上方驱动。 | 「重建裝置」會移除選取的父裝置及其子介面，之後需重新連接手機。原驅動程式套件會保留，Windows 可能再次選取原驅動程式；變更綁定請選取上方驅動程式。 | 「重建裝置」會移除選取的父裝置及其子介面，之後需重新連線手機。原驅動程式套件會保留，Windows 可能再次選取原驅動程式；變更綁定請選取上方驅動程式。 | Rebuild device removes the selected parent and its child interfaces. Reconnect the phone afterward. Driver packages remain installed, so Windows may choose the same driver again; select a driver above to change the binding. | 「デバイスを再構築」は、選択した親デバイスとその子インターフェイスを削除します。実行後はスマートフォンを再接続してください。ドライバーパッケージは残るため、Windowsが同じドライバーをもう一度選ぶ場合があります。割り当てを変えるには、上でドライバーを選んでください。 | ✅ 完全一致 | 保留 |
| ParentResetRestartRequired | Windows 要求重启电脑以完成父设备移除。重启后重新连接手机并检测。 | Windows 要求重新啟動電腦以完成父裝置移除。重新啟動後重新連接手機並檢測。 | Windows 要求重新啟動電腦以完成父裝置移除。重新啟動後重新連線手機並檢測。 | Windows requires a PC restart to finish removing the parent device. Reconnect the phone and refresh afterward. | 親デバイスの削除を完了するには、PCの再起動が必要です。その後、スマートフォンを再接続して更新してください。 | ✅ 完全一致 | 保留 |
| ParentRollbackRestartRequired | 父驱动绑定失败；Windows 已接受恢复原绑定，但需要重启电脑。重启后请重新检测。 | 父驅動程式綁定失敗；Windows 已接受還原原綁定，但需要重新啟動電腦。重新啟動後請再次檢測。 | 父驅動程式綁定失敗；Windows 已接受還原原綁定，但需要重新啟動電腦。重新啟動後請再次檢測。 | Parent driver binding failed. Windows accepted restoration of the previous binding, but a PC restart is required. Refresh afterward to verify recovery. | 親ドライバーの割り当てに失敗しました。Windowsは元の割り当ての復元を受け付けましたが、PCの再起動が必要です。再起動後に更新して、復旧を確認してください。 | ✅ 完全一致 | 保留 |
| ParentStatusFormat | 父驱动：{0} · INF：{1}<br>故障代码：{2} · {3} | 父驅動程式：{0} · INF：{1}<br>問題代碼：{2} · {3} | 父驅動程式：{0} · INF：{1}<br>問題代碼：{2} · {3} | Parent: {0} · INF: {1}<br>Problem code: {2} · {3} | 親: {0} · INF: {1}<br>問題コード: {2} · {3} | ✅ 完全一致 | 保留 |
| PrepareDescription | 自动检测并安装 Apple USB 支持、共享采集驱动，以及当前已连接 iPhone 的采集过滤器。 | 自動偵測並安裝 Apple USB 支援、共用擷取驅動程式，以及目前已連接 iPhone 的擷取過濾器。 | 自動偵測並安裝 Apple USB 支援、共用擷取驅動程式，以及目前已連線 iPhone 的擷取篩選器。 | Automatically detect and install Apple USB support, the shared capture driver, and the capture filter for the connected iPhone. | Apple USBサポート、共有キャプチャドライバー、接続中のiPhone用のキャプチャフィルターを自動で検出してインストールします。 | ✅ 完全一致 | 保留 |
| PrepareTitle | 一键准备投屏环境 | 一按準備螢幕鏡像環境 | 一鍵準備螢幕鏡像環境 | Prepare mirroring environment | ミラーリング環境を準備 | ✅ 完全一致 | 保留 |
| QuickInstallBody | 工具将检查 Apple USB 支持、共享采集驱动和当前选中的 iPhone，并安装缺失项。父驱动异常时，会显示当前绑定和目标驱动，待你单独确认后修复。 | 工具將檢查 Apple USB 支援、共用擷取驅動程式及目前選取的 iPhone，並安裝遺失項目。父驅動程式異常時，會顯示目前綁定及目標驅動程式，待你另行確認後修復。 | 工具將檢查 Apple USB 支援、共用擷取驅動程式及目前選取的 iPhone，並安裝遺失項目。父驅動程式異常時，會顯示目前綁定及目標驅動程式，待您另行確認後修復。 | The tool checks Apple USB support, the shared capture driver, and the selected iPhone, then installs missing components. If the parent driver needs repair, you will see the current binding and target driver and be asked to confirm that change separately. | Apple USBサポート、共有キャプチャドライバー、選択したiPhoneを確認し、不足しているコンポーネントをインストールします。親ドライバーの修復が必要な場合は、現在の割り当てと変更後のドライバーが表示され、その変更を別途確認します。 | ✅ 完全一致 | 保留 |
| QuickInstallComplete | 一键安装完成，{0} 的投屏驱动已就绪。 | 一按安裝完成，{0} 的螢幕鏡像驅動程式已就緒。 | 一鍵安裝完成，{0} 的螢幕鏡像驅動程式已就緒。 | Installation complete. The mirroring driver for {0} is ready. | インストールが完了しました。{0}のミラーリング用ドライバーの準備ができました。 | ✅ 完全一致 | 保留 |
| QuickInstallTitle | 一键安装全部驱动 | 一按安裝全部驅動程式 | 一鍵安裝全部驅動程式 | Install all drivers | すべてのドライバーをインストール | ✅ 完全一致 | 保留 |
| Recheck | 重新检测 | 重新偵測 | 重新偵測 | Recheck | 再確認 | ✅ 完全一致 | 保留 |
| ReconnectBody | 已检测到设备断开。现在请重新连接 iPhone，解锁设备，并在手机出现提示时点击“信任此电脑”。 | 已偵測到裝置中斷連接。現在請重新連接 iPhone，解鎖裝置，並在手機出現提示時按一下「信任這部電腦」。 | 已偵測到裝置中斷連線。現在請重新連線 iPhone，解鎖裝置，並在手機出現提示時按一下「信任這台電腦」。 | The device disconnected. Reconnect and unlock the iPhone, then tap Trust if prompted. | デバイスが切断されました。iPhoneを再接続してロックを解除し、確認が表示されたら「信頼」をタップしてください。 | ✅ 完全一致 | 保留 |
| ReconnectTimeout | 等待设备重新连接超时。日志：{0} | 等待裝置重新連接逾時。記錄：{0} | 等待裝置重新連線逾時。記錄檔：{0} | Timed out waiting for the device to reconnect. Log: {0} | デバイスの再接続待ちがタイムアウトしました。ログ: {0} | ✅ 完全一致 | 保留 |
| ReconnectTitle | 请重新连接 | 請重新連接 | 請重新連線 | Reconnect the device | デバイスを再接続してください | ✅ 完全一致 | 保留 |
| ReconnectVerificationFailed | 设备重连验证未通过：请检查连接、设备故障代码、父驱动绑定和采集过滤器状态。 | 裝置重新連接驗證未通過：請檢查連接、裝置錯誤代碼、父驅動程式綁定及擷取過濾器狀態。 | 裝置重新連線驗證未通過：請檢查連線、裝置錯誤代碼、父驅動程式綁定及擷取篩選器狀態。 | Reconnect verification failed. Check the connection, device problem code, parent driver binding, and capture filter state. | 再接続後の検証に失敗しました。接続、デバイスの問題コード、親ドライバーの割り当て、キャプチャフィルターの状態を確認してください。 | ✅ 完全一致 | 保留 |
| Reconnected | 已经连接 | 已經連接 | 已經連線 | Reconnected | 再接続済み | ✅ 完全一致 | 保留 |
| Refresh | 刷新 | 重新整理 | 重新整理 | Refresh | 更新 | ✅ 完全一致 | 保留 |
| Repair | 修复 | 修復 | 修復 | Repair | 修復 | ✅ 完全一致 | 保留 |
| RepairingDriver | 正在为 {0} 修复采集驱动… | 正在為 {0} 修復擷取驅動程式… | 正在為 {0} 修復擷取驅動程式… | Repairing the capture driver for {0}… | {0}のキャプチャドライバーを修復しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| RepairingParent | 正在修复 {0} 的父驱动… | 正在修復 {0} 的父驅動程式… | 正在修復 {0} 的父驅動程式… | Repairing the parent driver for {0}… | {0}の親ドライバーを修復しています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| ReplugTimeout | 等待设备拔下或重新连接超时。驱动操作本身已经回滚或完成，请查看日志后重试。 | 等待裝置拔下或重新連接逾時。驅動程式操作本身已經復原或完成，請查看記錄後重試。 | 等待裝置拔下或重新連線逾時。驅動程式操作本身已經復原或完成，請查看記錄檔後重試。 | Timed out waiting for the device to disconnect or reconnect. The operation was rolled back or completed; review the log and retry. | デバイスの切断または再接続の待機がタイムアウトしました。操作はロールバックされたか、完了しています。ログを確認して再試行してください。 | ✅ 完全一致 | 保留 |
| RequiredActionTitle | 需要你的操作 | 需要你執行操作 | 需要您執行操作 | Action required | 操作が必要です | ✅ 完全一致 | 保留 |
| RequiredAppleInstallBody | 请完成当前这一步后点击“重新检测”。工具不会自动操作商店窗口。 | 請完成目前這一步後按一下「重新偵測」。工具不會自動控制商店視窗。 | 請完成目前這一步後按一下「重新偵測」。工具不會自動控制商店視窗。 | Complete this step, then click Recheck. The tool will not operate the store window for you. | この手順を完了してから「再確認」を押してください。ストアのウィンドウは、このツールでは操作しません。 | ✅ 完全一致 | 保留 |
| RequiredAppleInstallTitle | 需要完成 Apple 官方安装 | 需要完成 Apple 官方安裝 | 需要完成 Apple 官方安裝 | Apple installation required | Appleのインストールが必要です | ✅ 完全一致 | 保留 |
| Retry | 重新检测 | 重新偵測 | 重新偵測 | Recheck | 再確認 | ❌ 术语不一致 → ✅ 已修复 | 相同重新检测动作与 Recheck 按钮一致 |
| RunDriverCleanup | 清理设备驱动 | 清理裝置驅動程式 | 清理裝置驅動程式 | Clean up device drivers | デバイスドライバーを整理 | ✅ 完全一致 | 保留 |
| SelectedDeviceDisconnected | 选中的设备已经断开，请重新选择后再试。日志：{0} | 選取的裝置已中斷連接，請重新選擇後再試。記錄：{0} | 選取的裝置已中斷連線，請重新選擇後再試。記錄檔：{0} | The selected device disconnected. Select it again and retry. Log: {0} | 選択したデバイスが切断されました。もう一度選択して再試行してください。ログ: {0} | ✅ 完全一致 | 保留 |
| SimpleNoDevice | 连接 iPhone 后点击按钮，工具会自动完成检测和安装。 | 連接 iPhone 後按一下按鈕，工具會自動完成偵測和安裝。 | 連線 iPhone 後按一下按鈕，工具會自動完成偵測和安裝。 | Connect an iPhone and click the button. The tool will detect and install what is missing. | iPhoneを接続してボタンを押してください。不足しているものを検出してインストールします。 | ✅ 完全一致 | 保留 |
| StartDetection | 开始检测 | 開始偵測 | 開始偵測 | Start detection | 検出を開始 | ✅ 完全一致 | 保留 |
| StartInstall | 开始安装 | 開始安裝 | 開始安裝 | Start installation | インストールを開始 | ✅ 完全一致 | 保留 |
| ThemeDark | 深色 | 深色 | 深色 | Dark | ダーク | ✅ 完全一致 | 保留 |
| ThemeLight | 浅色 | 淺色 | 淺色 | Light | ライト | ✅ 完全一致 | 保留 |
| ThemeSystem | 跟随系统 | 跟隨系統 | 跟隨系統 | Use system setting | システムの設定に従う | ✅ 完全一致 | 保留 |
| UacCancelled | 用户取消了 Windows 管理员授权。 | 使用者取消了 Windows 系統管理員授權。 | 使用者取消了 Windows 系統管理員授權。 | Windows administrator approval was cancelled. | Windowsの管理者承認がキャンセルされました。 | ✅ 完全一致 | 保留 |
| Uninstall | 卸载 | 解除安裝 | 解除安裝 | Uninstall | アンインストール | ✅ 完全一致 | 保留 |
| UnknownVersion | 未知版本 | 未知版本 | 未知版本 | unknown version | 不明なバージョン | ✅ 完全一致 | 保留 |
| UnplugBody | 驱动更改已经完成。现在请拔掉这台 iPhone 的数据线，等待设备从列表中消失。 | 驅動程式更改已經完成。現在請拔除這部 iPhone 的數據線，等待裝置從清單中消失。 | 驅動程式更改已經完成。現在請拔除這台 iPhone 的傳輸線，等待裝置從清單中消失。 | The driver change is complete. Unplug this iPhone and wait for it to disappear from the device list. | ドライバーの変更が完了しました。このiPhoneを取り外し、デバイス一覧から消えるまで待ってください。 | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| UnplugTitle | 请拔线 | 請拔除數據線 | 請拔除傳輸線 | Unplug the device | デバイスを取り外してください | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| Unplugged | 已经拔线 | 已拔除數據線 | 已拔除傳輸線 | Unplugged | 取り外し済み | ❌ 术语不一致 → ✅ 已修复 | 统一香港繁体中文既有用语 |
| WaitDeviceTimeout | 等待 Apple 设备连接超时。日志：{0} | 等待 Apple 裝置連接逾時。記錄：{0} | 等待 Apple 裝置連線逾時。記錄檔：{0} | Timed out waiting for an Apple device. Log: {0} | Appleデバイスの待機がタイムアウトしました。ログ: {0} | ✅ 完全一致 | 保留 |
| WaitingDisconnect | 等待设备断开… | 等待裝置中斷連接… | 等待裝置中斷連線… | Waiting for the device to disconnect… | デバイスの切断を待っています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| WaitingForDevice | 等待 Apple 设备连接… | 等待 Apple 裝置連接… | 等待 Apple 裝置連線… | Waiting for an Apple device… | Appleデバイスを待っています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |
| WaitingReconnect | 等待设备重新连接… | 等待裝置重新連接… | 等待裝置重新連線… | Waiting for the device to reconnect… | デバイスの再接続を待っています… | ⚠️ 需要优化 → ✅ 已修复 | 统一进行中状态的省略号 |

### Cleanup

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| AssociatedDrivers | 关联驱动包总数：{0} | 關聯驅動程式套件總數：{0} | 關聯驅動程式套件總數：{0} | Total associated driver packages: {0} | 関連するドライバーパッケージの合計: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| AssociatedNodes | 关联 PnP 节点：{0} | 關聯 PnP 節點：{0} | 關聯 PnP 節點：{0} | Associated PnP nodes: {0} | 関連するPnPノード: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| BluetoothExcluded | 已安全排除 BTHLE 设备：{0} | 已安全排除 BTHLE 裝置：{0} | 已安全排除 BTHLE 裝置：{0} | BTHLE device safely excluded: {0} | BTHLEデバイスを安全のため除外しました: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| BluetoothNotListed | BTHLE / Bluetooth LE 设备不会显示。 | BTHLE / Bluetooth LE 裝置不會顯示。 | BTHLE / Bluetooth LE 裝置不會顯示。 | BTHLE / Bluetooth LE devices are not listed. | BTHLE / Bluetooth LEデバイスは一覧に出しません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| CheckRequirements | 请确认： | 請確認： | 請確認： | Check the following: | 次の点を確認してください: | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| CleanupPlan |  清理计划 |  清理計劃 |  清理計劃 |  Cleanup plan |  整理の計画 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| CleanupResults |  清理结果 |  清理結果 |  清理結果 |  Cleanup results |  整理の結果 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ClosingProcesses | 正在关闭 iPhoneMirror 相关进程… | 正在關閉 iPhoneMirror 相關程序… | 正在關閉 iPhoneMirror 相關程序… | Closing iPhoneMirror processes… | iPhoneMirrorのプロセスを終了しています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| Completed |  清理完成。 |  清理完成。 |  清理完成。 |  Cleanup completed successfully. |  整理が完了しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| CompletedWithErrors |  清理结束，发生 {0} 个错误。 |  清理結束，發生 {0} 個錯誤。 |  清理結束，發生 {0} 個錯誤。 |  Cleanup finished. Errors: {0} |  整理が終わりました。エラー: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| Confirm | 请输入 {0} 确认： | 請輸入 {0} 確認： | 請輸入 {0} 確認： | Type {0} to confirm: | 確認のため{0}と入力してください: | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ConfirmationMismatch | 确认文字不匹配，未做任何修改。 | 確認文字不符，未作任何修改。 | 確認文字不符，未作任何修改。 | The confirmation text did not match. No changes were made. | 確認の文字が一致しません。何も変更していません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DetectedDevices | 检测到以下 Apple 物理设备： | 偵測到以下 Apple 實體裝置： | 偵測到以下 Apple 實體裝置： | Detected Apple physical devices: | 見つかったAppleの物理デバイス: | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DeviceNode | 设备节点：{0} | 裝置節點：{0} | 裝置節點：{0} | Device node: {0} | デバイスノード: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DeviceNodeFailed | 设备节点删除失败：{0} | 裝置節點刪除失敗：{0} | 裝置節點刪除失敗：{0} | Could not remove device node: {0} | デバイスノードを削除できませんでした: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DeviceNodeFailedDetail | 设备节点删除失败：{0}  | 裝置節點刪除失敗：{0}  | 裝置節點刪除失敗：{0}  | Could not remove device node: {0}  | デバイスノードを削除できませんでした: {0}  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DeviceNodeRestart | 设备节点已移除，重启后完成：{0} | 裝置節點已移除，重新啟動後完成：{0} | 裝置節點已移除，重新啟動後完成：{0} | Device node removed; a restart is required to finish: {0} | デバイスノードを削除しました。完了には再起動が必要です: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverEnumerationFailed | pnputil Driver Store 枚举失败，退出代码为 {0}； | pnputil Driver Store 列舉失敗，結束代碼為 {0}； | pnputil Driver Store 列舉失敗，結束代碼為 {0}； | pnputil Driver Store enumeration failed (exit code {0}).  | pnputilによるDriver Storeの列挙に失敗しました（終了コード {0}）。  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverIndexReady | Driver Store 索引完成：{0} 个 OEM INF | Driver Store 索引完成：{0} 個 OEM INF | Driver Store 索引完成：{0} 個 OEM INF | Driver Store index ready. OEM INF files: {0} | Driver Storeの索引の準備ができました。OEMのINFファイル: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverNodesMissing | Driver Store XML 中没有 Driver 节点，已停止清理，以免遗漏驱动包。 | Driver Store XML 中沒有 Driver 節點，已停止清理，以免遺漏驅動程式套件。 | Driver Store XML 中沒有 Driver 節點，已停止清理，以免遺漏驅動程式套件。 | Driver Store XML has no Driver nodes. Cleanup stopped to avoid missing driver packages. | Driver StoreのXMLにDriverノードがありません。ドライバーパッケージの取りこぼしを避けるため、整理を中止しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverOperationBusy | 另一个驱动操作或回滚仍在进行，请等待完成后重试清理。 | 另一個驅動操作或復原仍在進行，請等待完成後重試清理。 | 另一個驅動操作或復原仍在進行，請等待完成後重試清理。 | Another driver operation or rollback is in progress. Wait for it to finish before retrying cleanup. | ほかのドライバー操作か巻き戻しが進行中です。終わってから、もう一度整理を実行してください。 | ✅ 完全一致 | 保留 |
| DriverPackage | 驱动包：{0} | 驅動程式套件：{0} | 驅動程式套件：{0} | Driver package: {0} | ドライバーパッケージ: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverPackageFailed | 驱动包删除失败：{0} | 驅動程式套件刪除失敗：{0} | 驅動程式套件刪除失敗：{0} | Could not remove driver package: {0} | ドライバーパッケージを削除できませんでした: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverPackageFailedDetail | 驱动包删除失败：{0}  | 驅動程式套件刪除失敗：{0}  | 驅動程式套件刪除失敗：{0}  | Could not remove driver package: {0}  | ドライバーパッケージを削除できませんでした: {0}  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverPackageRestart | 驱动包已删除，重启后完成：{0} | 驅動程式套件已刪除，重新啟動後完成：{0} | 驅動程式套件已刪除，重新啟動後完成：{0} | Driver package removed; a restart is required to finish: {0} | ドライバーパッケージを削除しました。完了には再起動が必要です: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverStoreCount |     Driver Store 驱动包：{0} |     Driver Store 驅動程式套件：{0} |     Driver Store 驅動程式套件：{0} |     Driver Store packages: {0} |     Driver Storeのパッケージ: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverXmlEmpty | Driver Store XML 为空。 | Driver Store XML 為空。 | Driver Store XML 為空。 | Driver Store XML is empty. | Driver StoreのXMLが空です。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverXmlEmptyStopped | Driver Store XML 为空，已停止清理，以免遗漏驱动包。 | Driver Store XML 為空，已停止清理，以免遺漏驅動程式套件。 | Driver Store XML 為空，已停止清理，以免遺漏驅動程式套件。 | Driver Store XML is empty. Cleanup stopped to avoid missing driver packages. | Driver StoreのXMLが空です。ドライバーパッケージの取りこぼしを避けるため、整理を中止しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverXmlInvalid | Driver Store XML 解析失败： | Driver Store XML 解析失敗： | Driver Store XML 解析失敗： | Could not parse Driver Store XML:  | Driver StoreのXMLを解析できませんでした:  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverXmlInvalidStopped | Driver Store XML 解析失败，已停止清理： | Driver Store XML 解析失敗，已停止清理： | Driver Store XML 解析失敗，已停止清理： | Could not parse Driver Store XML. Cleanup stopped:  | Driver StoreのXMLを解析できなかったため、整理を中止しました:  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| DriverXmlUnavailable | 无法使用 Driver Store XML，退出代码为 {0} | 無法使用 Driver Store XML，結束代碼為 {0} | 無法使用 Driver Store XML，結束代碼為 {0} | Driver Store XML is unavailable. Exit code: {0} | Driver StoreのXMLを取得できません。終了コード: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| Error | 错误：{0} | 錯誤：{0} | 錯誤：{0} | Error: {0} | エラー: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ErrorLog | 错误日志：{0} | 錯誤記錄：{0} | 錯誤記錄檔：{0} | Error log: {0} | エラーログ: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| FatalError | iPhoneMirror 驱动清理严重错误 | iPhoneMirror 驅動程式清理嚴重錯誤 | iPhoneMirror 驅動程式清理嚴重錯誤 | iPhoneMirror driver cleanup fatal error | iPhoneMirrorのドライバー整理で致命的なエラー | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| FinalDeviceCheck | 正在执行删除前的最终设备确认… | 正在執行刪除前的最終裝置確認… | 正在執行刪除前的最終裝置確認… | Performing the final device check before removal… | 削除の前に、最後のデバイスの確認をしています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| FinalVerification | 正在执行最终验证… | 正在執行最終驗證… | 正在執行最終驗證… | Performing final verification… | 最後の確認をしています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| IndexDriverStore | 正在建立 Driver Store 驱动索引… | 正在建立 Driver Store 驅動程式索引… | 正在建立 Driver Store 驅動程式索引… | Indexing Driver Store packages… | Driver Storeのパッケージを索引付けしています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| InternalError |  清理工具内部错误 |  清理工具內部錯誤 |  清理工具內部錯誤 |  Cleanup tool internal error |  整理ツールの内部エラー | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| InvalidDeviceNumber | 设备序号无效。 | 裝置編號無效。 | 裝置編號無效。 | Invalid device number. | デバイスの番号が正しくありません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| Irreversible | 此操作不可撤销。 | 此操作無法復原。 | 此操作無法復原。 | This operation cannot be undone. | この操作は元に戻せません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ListOnly | 仅列表模式，未修改系统。 | 僅清單模式，未修改系統。 | 僅清單模式，未修改系統。 | List-only mode. No system changes were made. | 一覧のみのモードです。システムは変更していません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| Location | 位置： | 位置： | 位置： | Location: | 場所: | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| LogPath | 日志：{0} | 記錄：{0} | 記錄檔：{0} | Log: {0} | ログ: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ManifestWriteFailed | 无法写入清单： | 無法寫入清單： | 無法寫入清單： | Could not write the manifest:  | 記録ファイルを書き込めませんでした:  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| MappingDevices | 正在建立 Apple 设备关系… | 正在建立 Apple 裝置關係… | 正在建立 Apple 裝置關係… | Mapping Apple device relationships… | Appleデバイスの関係を調べています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| MappingDrivers | 正在建立驱动关系… | 正在建立驅動程式關係… | 正在建立驅動程式關係… | Mapping driver relationships… | ドライバーの関係を調べています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| MappingReady | 设备关系建立完成。 | 裝置關係建立完成。 | 裝置關係建立完成。 | Device relationships are ready. | デバイスの関係がわかりました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| NoAppleDevice | 未找到当前连接的 iPhone/iPad。 | 找不到目前連接的 iPhone/iPad。 | 找不到目前連線的 iPhone/iPad。 | No connected iPhone/iPad was found. | 接続されたiPhone/iPadが見つかりませんでした。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| NoAvailablePnp | pnputil PnP XML 中没有可用设备。 | pnputil PnP XML 中沒有可用裝置。 | pnputil PnP XML 中沒有可用裝置。 | No available devices were found in pnputil PnP XML. | pnputilのPnP XMLに、使用できるデバイスが見つかりませんでした。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| NoCachedPnp | pnputil PnP 缓存完成：0 个设备 | pnputil PnP 快取完成：0 個裝置 | pnputil PnP 快取完成：0 個裝置 | pnputil PnP cache ready. Devices: 0 | pnputilのPnPキャッシュの準備ができました。デバイス: 0 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| NoConnectedPnp | pnputil PnP XML 中没有当前连接的设备。 | pnputil PnP XML 中沒有目前連接的裝置。 | pnputil PnP XML 中沒有目前連線的裝置。 | No connected devices were found in pnputil PnP XML. | pnputilのPnP XMLに、接続中のデバイスが見つかりませんでした。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| NoRemovableNodes | 没有可删除的目标 PnP 节点。 | 沒有可刪除的目標 PnP 節點。 | 沒有可刪除的目標 PnP 節點。 | There are no target PnP nodes to remove. | 削除の対象のPnPノードはありません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| NodesRemoved | 目标 PnP 节点已清理。 | 目標 PnP 節點已清理。 | 目標 PnP 節點已清理。 | Target PnP nodes were removed. | 対象のPnPノードを削除しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| OnePhysicalDevice | 物理设备：1 台 | 實體裝置：1 部 | 實體裝置：1 部 | Physical devices: 1 | 物理デバイス: 1 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PackagesHandled | 目标 Driver Store 驱动包已处理。 | 目標 Driver Store 驅動程式套件已處理。 | 目標 Driver Store 驅動程式套件已處理。 | Target Driver Store packages were processed. | 対象のDriver Storeのパッケージを処理しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PackagesPreservedUnsupported | 此 Windows 版本无法完整列出驱动包使用者；将只清理所选设备节点，保留驱动包。 | 此 Windows 版本無法完整列出驅動程式套件使用者；只會清理所選裝置節點，保留驅動程式套件。 | 此 Windows 版本無法完整列出驅動程式套件使用者；只會清理所選裝置節點，保留驅動程式套件。 | This Windows version cannot list all driver package users. Only selected device nodes will be removed; driver packages will be preserved. | このバージョンのWindowsでは、ドライバーパッケージを使っているものをすべて列挙できません。選んだデバイスのノードだけを削除し、ドライバーパッケージは残します。 | ✅ 完全一致 | 保留 |
| Pause | 按 Enter 键关闭窗口 | 按 Enter 鍵關閉視窗 | 按 Enter 鍵關閉視窗 | Press Enter to close this window | Enterキーを押すと、このウィンドウを閉じます | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PhysicalDeviceCount | Apple 物理设备分组完成：{0} 台 | Apple 實體裝置分組完成：{0} 部 | Apple 實體裝置分組完成：{0} 部 | Apple physical devices grouped: {0} | Appleの物理デバイスのまとまり: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpCached | PnP 缓存完成：{0} 个设备 | PnP 快取完成：{0} 個裝置 | PnP 快取完成：{0} 個裝置 | PnP cache ready. Devices: {0} | PnPのキャッシュの準備ができました。デバイス: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpEnumerationFailed | 无法枚举 PnP 设备，pnputil 退出代码为 {0} | 無法列舉 PnP 裝置，pnputil 結束代碼為 {0} | 無法列舉 PnP 裝置，pnputil 結束代碼為 {0} | Could not enumerate PnP devices. pnputil exit code: {0} | PnPデバイスを列挙できませんでした。pnputilの終了コード: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpFallback | Get-PnpDevice 扫描失败，正在改用 pnputil： | Get-PnpDevice 掃描失敗，正在改用 pnputil： | Get-PnpDevice 掃描失敗，正在改用 pnputil： | Get-PnpDevice scan failed; switching to pnputil:  | Get-PnpDeviceのスキャンに失敗しました。pnputilに切り替えます:  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpNodeCount |     PnP 节点：{0} |     PnP 節點：{0} |     PnP 節點：{0} |     PnP nodes: {0} |     PnPノード: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpUtilCached | pnputil PnP 缓存完成：{0} 个设备 | pnputil PnP 快取完成：{0} 個裝置 | pnputil PnP 快取完成：{0} 個裝置 | pnputil PnP cache ready. Devices: {0} | pnputilのPnPキャッシュの準備ができました。デバイス: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpUtilMissing | 找不到 pnputil.exe：{0} | 找不到 pnputil.exe：{0} | 找不到 pnputil.exe：{0} | pnputil.exe was not found: {0} | pnputil.exeが見つかりません: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpXmlEmpty | pnputil PnP XML 为空，无法枚举设备。 | pnputil PnP XML 為空，無法列舉裝置。 | pnputil PnP XML 為空，無法列舉裝置。 | pnputil PnP XML is empty; devices cannot be enumerated. | pnputilのPnP XMLが空のため、デバイスを列挙できません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PnpXmlInvalid | pnputil PnP XML 解析失败： | pnputil PnP XML 解析失敗： | pnputil PnP XML 解析失敗： | Could not parse pnputil PnP XML:  | pnputilのPnP XMLを解析できませんでした:  | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| PreviewOnly |  仅预览，未修改系统 |  僅預覽，未修改系統 |  僅預覽，未修改系統 |  Preview only. No system changes were made. |  確認のみです。システムは変更していません。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ProtectedLaunchRequired | 请通过 iPhoneMirror.Driver.exe 或发布包中的清理入口运行此工具，以获得受保护的管理员权限。 | 請透過 iPhoneMirror.Driver.exe 或發佈套件中的清理入口執行此工具，以取得受保護的管理員權限。 | 請透過 iPhoneMirror.Driver.exe 或發布套件中的清理入口執行此工具，以取得受保護的管理員權限。 | Run this tool through iPhoneMirror.Driver.exe or the cleanup entry in the release package to obtain protected administrator privileges. | 保護された管理者権限で実行するため、このツールはiPhoneMirror.Driver.exeか、リリースのパッケージにある整理の入口から起動してください。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ReinstallAdvice | 完成后可重新安装 Apple Devices 或 iTunes，以恢复所需驱动。 | 完成後可重新安裝 Apple Devices 或 iTunes，以還原所需驅動程式。 | 完成後可重新安裝 Apple Devices 或 iTunes，以還原所需驅動程式。 | Afterward, reinstall Apple Devices or iTunes to restore the required drivers. | 終わったら、Apple DevicesかiTunesを入れ直して、必要なドライバーを戻してください。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RemainingNodes | 仍存在 {0} 个目标节点。 | 仍存在 {0} 個目標節點。 | 仍存在 {0} 個目標節點。 | Target nodes remaining: {0}. | 残っている対象のノード: {0}。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RemainingPackages | 仍存在 {0} 个驱动包。 | 仍存在 {0} 個驅動程式套件。 | 仍存在 {0} 個驅動程式套件。 | Driver packages remaining: {0}. | 残っているドライバーパッケージ: {0}。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RemovingNodes |  正在卸载设备节点 |  正在卸載裝置節點 |  正在卸載裝置節點 |  Removing device nodes |  デバイスノードを削除しています | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RemovingPackages |  正在删除 Driver Store 驱动包 |  正在刪除 Driver Store 驅動程式套件 |  正在刪除 Driver Store 驅動程式套件 |  Removing Driver Store packages |  Driver Storeのパッケージを削除しています | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RequirementCable |   4. 数据线支持数据传输 |   4. 數據線支援資料傳輸 |   4. 傳輸線支援資料傳輸 |   4. The cable supports data transfer |   4. ケーブルがデータ通信に対応している | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RequirementTrusted |   3. 已在设备上选择“信任此电脑” |   3. 已在裝置上選擇「信任此電腦」 |   3. 已在裝置上選擇「信任此電腦」 |   3. You have trusted this computer on the device |   3. デバイスでこのコンピュータを信頼している | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RequirementUnlocked |   2. 设备已解锁 |   2. 裝置已解鎖 |   2. 裝置已解鎖 |   2. The device is unlocked |   2. デバイスのロックが解除されている | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RequirementUsb |   1. iPhone/iPad 已通过 USB 连接 |   1. iPhone/iPad 已透過 USB 連接 |   1. iPhone/iPad 已透過 USB 連線 |   1. The iPhone/iPad is connected by USB |   1. iPhone/iPadがUSBで接続されている | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| RestartRequired | Windows 报告部分操作需要重启。 | Windows 報告部分操作需要重新啟動。 | Windows 報告部分操作需要重新啟動。 | Windows reported that some operations require a restart. | 一部の操作は再起動が必要だとWindowsが報告しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ScanPnp | 正在扫描当前 PnP 设备… | 正在掃描目前 PnP 裝置… | 正在掃描目前 PnP 裝置… | Scanning current PnP devices… | 現在のPnPデバイスをスキャンしています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ScanningDevices | 正在扫描设备… | 正在掃描裝置… | 正在掃描裝置… | Scanning devices… | デバイスをスキャンしています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| ScopeWarning | 将清理所选设备的关联设备节点及可安全移除的驱动包，可能包括 Apple 官方驱动；其他设备仍在使用的驱动包会保留。 | 將清理所選裝置的關聯裝置節點及可安全移除的驅動程式套件，可能包括 Apple 官方驅動程式；其他裝置仍在使用的驅動程式套件會保留。 | 將清理所選裝置的關聯裝置節點及可安全移除的驅動程式套件，可能包括 Apple 官方驅動程式；其他裝置仍在使用的驅動程式套件會保留。 | Cleanup will remove device nodes associated with the selected device and driver packages that can be safely removed, which may include official Apple drivers. Packages still used by other devices will be preserved. | 整理では、選んだデバイスに関連するデバイスノードと、安全に削除できるドライバーパッケージを削除します。Apple公式のドライバーが含まれることがあります。ほかのデバイスが使っているパッケージは残します。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| SelectDevice | 请输入设备序号；输入 Q 取消 | 請輸入裝置編號；輸入 Q 取消 | 請輸入裝置編號；輸入 Q 取消 | Enter a device number, or Q to cancel | デバイスの番号を入力してください（Qで取り消し） | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| SelectedDevice | 设备：{0} | 裝置：{0} | 裝置：{0} | Device: {0} | デバイス: {0} | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| SelectedDisconnected | 所选 iPhone 已断开。 | 所選 iPhone 已中斷連線。 | 所選 iPhone 已中斷連線。 | The selected iPhone disconnected. | 選んだiPhoneが切断されました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| SharedPackagePreserved | 驱动包 {0} 正被其他设备使用，已保留。 | 驅動程式套件 {0} 正被其他裝置使用，已保留。 | 驅動程式套件 {0} 正被其他裝置使用，已保留。 | Driver package {0} is used by other devices and has been preserved. | ドライバーパッケージ{0}はほかのデバイスが使っているため、残しました。 | ✅ 完全一致 | 保留 |
| StackTrace | 调用栈： | 呼叫堆疊： | 呼叫堆疊： | Stack trace: | スタックトレース: | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| StopMissingPackages | 已停止清理，以免遗漏驱动包。 | 已停止清理，以免遺漏驅動程式套件。 | 已停止清理，以免遺漏驅動程式套件。 | Cleanup stopped to avoid missing driver packages. | ドライバーパッケージの取りこぼしを避けるため、整理を中止しました。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| Title |  清除 iPhone/iPad 关联驱动 |  清除 iPhone/iPad 關聯驅動程式 |  清除 iPhone/iPad 關聯驅動程式 |  Remove iPhone/iPad associated drivers |  iPhone/iPadに関連するドライバーを削除 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| UnresolvedNodes | 仍存在 {0} 个目标 PnP 节点。 | 仍存在 {0} 個目標 PnP 節點。 | 仍存在 {0} 個目標 PnP 節點。 | Target PnP nodes remaining: {0}. | 残っている対象のPnPノード: {0}。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| UnresolvedPackages | 仍存在 {0} 个目标 Driver Store 驱动包。 | 仍存在 {0} 個目標 Driver Store 驅動程式套件。 | 仍存在 {0} 個目標 Driver Store 驅動程式套件。 | Target Driver Store packages remaining: {0}. | 残っている対象のDriver Storeのパッケージ: {0}。 | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |
| WaitingWindows | 正在等待 Windows 更新设备状态… | 正在等待 Windows 更新裝置狀態… | 正在等待 Windows 更新裝置狀態… | Waiting for Windows to update device status… | Windowsがデバイスの状態を更新するのを待っています… | ❌ 缺失 → ✅ 已修复 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 |

### Hardcoded

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| src/App/App.xaml / node 83 / Text | &gt; | &gt; | &gt; | &gt; | &gt; | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 351 / Text | ! | ! | ! | ! | ! | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 440 / Text | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 715 / Text | 00:00 | 00:00 | 00:00 | 00:00 | 00:00 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 717 / Text | --:-- | --:-- | --:-- | --:-- | --:-- | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 725 / Text | −10 | −10 | −10 | −10 | −10 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 731 / Text | +10 | +10 | +10 | +10 | +10 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 734 / Content | 0.5x | 0.5x | 0.5x | 0.5x | 0.5x | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 735 / Content | 0.75x | 0.75x | 0.75x | 0.75x | 0.75x | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 736 / Content | 1x | 1x | 1x | 1x | 1x | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 737 / Content | 1.25x | 1.25x | 1.25x | 1.25x | 1.25x | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 738 / Content | 1.5x | 1.5x | 1.5x | 1.5x | 1.5x | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 739 / Content | 2x | 2x | 2x | 2x | 2x | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 838 / Text |   ·   |   ·   |   ·   |   ·   |   ·   | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/MainWindow.xaml / node 840 / Text | UDID | UDID | UDID | UDID | UDID | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/AboutWindow.xaml / node 27 / Text | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/AboutWindow.xaml / node 35 / Content | GitHub | GitHub | GitHub | GitHub | GitHub | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/AdvancedSettingsWindow.xaml / node 28 / Text | × | × | × | × | × | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/BluetoothControlNoticeWindow.xaml / node 31 / Text | 1 | 1 | 1 | 1 | 1 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/BluetoothControlNoticeWindow.xaml / node 38 / Text | 2 | 2 | 2 | 2 | 2 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/BluetoothControlNoticeWindow.xaml / node 45 / Text | 3 | 3 | 3 | 3 | 3 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/BluetoothControlNoticeWindow.xaml / node 52 / Text | 4 | 4 | 4 | 4 | 4 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/BluetoothControlNoticeWindow.xaml / node 59 / Text | 5 | 5 | 5 | 5 | 5 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/CaptureRecoveryWindow.xaml / node 25 / Text | 1 | 1 | 1 | 1 | 1 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/CaptureRecoveryWindow.xaml / node 33 / Text | 2 | 2 | 2 | 2 | 2 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/DeveloperToolsWindow.xaml / node 23 / Text | 127.0.0.1 | 127.0.0.1 | 127.0.0.1 | 127.0.0.1 | 127.0.0.1 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/DeveloperToolsWindow.xaml / node 28 / Text | API Key: •••••••••••• | API Key: •••••••••••• | API Key: •••••••••••• | API Key: •••••••••••• | API Key: •••••••••••• | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/DeviceBindingWindow.xaml / node 45 / Text | iPhone Mirror  /  DEVICES | iPhone Mirror  /  DEVICES | iPhone Mirror  /  DEVICES | iPhone Mirror  /  DEVICES | iPhone Mirror  /  DEVICES | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/FirstRunSetupWindow.xaml / node 41 / Text | ○ | ○ | ○ | ○ | ○ | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/FirstRunSetupWindow.xaml / node 61 / Text | iPhone Mirror  /  SETUP | iPhone Mirror  /  SETUP | iPhone Mirror  /  SETUP | iPhone Mirror  /  SETUP | iPhone Mirror  /  SETUP | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/FirstRunSetupWindow.xaml / node 63 / Content | × | × | × | × | × | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 112 / Content | 1280 x 720 | 1280 x 720 | 1280 x 720 | 1280 x 720 | 1280 x 720 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 113 / Content | 1920 x 1080 | 1920 x 1080 | 1920 x 1080 | 1920 x 1080 | 1920 x 1080 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 114 / Content | 720 x 1280 | 720 x 1280 | 720 x 1280 | 720 x 1280 | 720 x 1280 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 115 / Content | 1080 x 1920 | 1080 x 1920 | 1080 x 1920 | 1080 x 1920 | 1080 x 1920 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 119 / Content | 30 fps | 30 fps | 30 fps | 30 fps | 30 fps | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 120 / Content | 60 fps | 60 fps | 60 fps | 60 fps | 60 fps | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 59 / Content | RTMP | RTMP | RTMP | RTMP | RTMP | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 60 / Content | SRT | SRT | SRT | SRT | SRT | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/MediaOutputSettingsWindow.xaml / node 61 / Content | WebRTC / WHIP | WebRTC / WHIP | WebRTC / WHIP | WebRTC / WHIP | WebRTC / WHIP | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/ReverseControlStatusWindow.xaml / node 44 / Text | 1 | 1 | 1 | 1 | 1 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/ReverseControlStatusWindow.xaml / node 50 / Text | 2 | 2 | 2 | 2 | 2 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/ReverseControlStatusWindow.xaml / node 56 / Text | 3 | 3 | 3 | 3 | 3 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/ReverseControlStatusWindow.xaml / node 62 / Text | 4 | 4 | 4 | 4 | 4 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/ReverseControlStatusWindow.xaml / node 68 / Text | 5 | 5 | 5 | 5 | 5 | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/StartupErrorWindow.xaml / node 1 / Title | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/TrayPanelWindow.xaml / node 10 / Text | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/TrayPanelWindow.xaml / node 32 / Text |  ·  |  ·  |  ·  |  ·  |  ·  | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/App/Windows/UsbProjectionModeInfoWindow.xaml / node 29 / Text | ! | ! | ! | ! | ! | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |
| src/DriverInstaller/MainWindow.xaml / node 164 / Text | USB · Apple | USB · Apple | USB · Apple | USB · Apple | USB · Apple | ✅ 完全一致 | 品牌、协议、数字、符号或单位；四语通用，保留 |

### StartupFallback

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| StartupDiagnostics.Label/StartupErrorClose | 关闭 | 關閉 | 關閉 | Close | 閉じる | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |
| StartupDiagnostics.Label/StartupErrorDetails | 错误详情 | 錯誤詳細資料 | 錯誤詳細資料 | Error details | エラーの詳細 | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |
| StartupDiagnostics.Label/StartupErrorHeading | iPhoneMirror 无法启动 | iPhoneMirror 無法啟動 | iPhoneMirror 無法啟動 | iPhoneMirror could not start | iPhoneMirrorを起動できませんでした | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |
| StartupDiagnostics.Label/StartupErrorLogLabel | 诊断日志 | 診斷記錄 | 診斷記錄檔 | Diagnostic log | 診断ログ | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |
| StartupDiagnostics.Label/StartupErrorOpenLog | 打开日志位置 | 開啟記錄位置 | 開啟記錄檔位置 | Open log location | ログの場所を開く | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |
| StartupDiagnostics.UserMessage/NativeComponentLoadFailure | 无法加载程序所需的原生组件。请重新安装最新的完整安装包；详细诊断已写入下方日志。 | 無法載入應用程式所需的原生元件。請重新安裝最新的完整安裝程式；詳細診斷資料已寫入下方記錄。 | 無法載入應用程式所需的原生元件。請重新安裝最新的完整安裝套件；詳細診斷資訊已寫入下方記錄檔。 | A required native component could not be loaded. Reinstall the latest full Setup package; detailed diagnostics were written to the log below. | アプリに必要なネイティブコンポーネントを読み込めませんでした。最新の完全版セットアップを入れ直してください。詳しい診断は下のログに書き込みました。 | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |
| StartupDiagnostics.UserMessage/StartupFailure | iPhoneMirror 启动时遇到错误。详细诊断已写入下方日志。 | iPhoneMirror 啟動時發生錯誤。詳細診斷資料已寫入下方記錄。 | iPhoneMirror 啟動時發生錯誤。詳細診斷資訊已寫入下方記錄檔。 | iPhoneMirror encountered an error during startup. Detailed diagnostics were written to the log below. | iPhoneMirrorの起動中にエラーが発生しました。詳しい診断は下のログに書き込みました。 | ✅ 完全一致 | 语言字典无法加载时的独立四语回退，保留 |

### SrsLab

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 0 streams | 流数量：0 | 串流數量：0 | 串流數量：0 | 0 streams | ストリーム: 0 | ✅ 完全一致 | 保留 |
| Active media streams | 活动媒体流 | 使用中的媒體串流 | 使用中的媒體串流 | Active media streams | 配信中のストリーム | ✅ 完全一致 | 保留 |
| Actual FPS | 实际帧率 | 實際影格率 | 實際影格率 | Actual FPS | 実際のfps | ✅ 完全一致 | 保留 |
| App | 应用名 | 應用程式名稱 | 應用程式名稱 | App | アプリ名 | ✅ 完全一致 | 保留 |
| Browser camera is idle. | 浏览器摄像头空闲。 | 瀏覽器攝影機閒置。 | 瀏覽器攝影機閒置。 | Browser camera is idle. | ブラウザーのカメラは待機中です。 | ✅ 完全一致 | 保留 |
| Browser device check | 浏览器设备检查 | 瀏覽器裝置檢查 | 瀏覽器裝置檢查 | Browser device check | ブラウザーでのデバイスの確認 | ✅ 完全一致 | 保留 |
| Browser playback | 浏览器播放 | 瀏覽器播放 | 瀏覽器播放 | Browser playback | ブラウザーで再生 | ✅ 完全一致 | 保留 |
| Camera APIs are unavailable in this browser context. | 当前浏览器环境不支持摄像头接口。 | 目前瀏覽器環境不支援攝影機介面。 | 目前瀏覽器環境不支援攝影機介面。 | Camera APIs are unavailable in this browser context. | このブラウザーの環境では、カメラのAPIを使えません。 | ✅ 完全一致 | 保留 |
| Camera is delivering frames. | 摄像头正在传输画面。 | 攝影機正在傳送畫面。 | 攝影機正在傳送畫面。 | Camera is delivering frames. | カメラから映像が届いています。 | ✅ 完全一致 | 保留 |
| Camera is not open. | 摄像头未打开。 | 攝影機未開啟。 | 攝影機未開啟。 | Camera is not open. | カメラが開いていません。 | ✅ 完全一致 | 保留 |
| Camera permission request timed out. | 摄像头权限请求超时。 | 攝影機權限請求逾時。 | 攝影機權限要求逾時。 | Camera permission request timed out. | カメラの許可の要求がタイムアウトしました。 | ✅ 完全一致 | 保留 |
| Camera permission request timed out. Allow camera access and scan again. | 摄像头权限请求超时。请允许访问后重新扫描。 | 攝影機權限請求逾時。請允許存取後重新掃描。 | 攝影機權限要求逾時。請允許存取後重新掃描。 | Camera permission request timed out. Allow camera access and scan again. | カメラの許可の要求がタイムアウトしました。カメラへのアクセスを許可して、もう一度スキャンしてください。 | ✅ 完全一致 | 保留 |
| Camera {0} | 摄像头 {0} | 攝影機 {0} | 攝影機 {0} | Camera {0} | カメラ {0} | ✅ 完全一致 | 保留 |
| Checking media server | 正在检查媒体服务器 | 正在檢查媒體伺服器 | 正在檢查媒體伺服器 | Checking media server | メディアサーバーを確認しています | ✅ 完全一致 | 保留 |
| Clients: {0} | 客户端：{0} | 用戶端：{0} | 用戶端：{0} | Clients: {0} | クライアント: {0} | ✅ 完全一致 | 保留 |
| Connected. | 已连接。 | 已連線。 | 已連線。 | Connected. | 接続しました。 | ✅ 完全一致 | 保留 |
| Connecting to WHEP... | 正在连接 WHEP… | 正在連線至 WHEP… | 正在連線至 WHEP… | Connecting to WHEP... | WHEPに接続しています… | ✅ 完全一致 | 保留 |
| Dashboard request failed | 状态请求失败 | 狀態請求失敗 | 狀態要求失敗 | Dashboard request failed | 状態の取得に失敗しました | ✅ 完全一致 | 保留 |
| Device | 设备 | 裝置 | 裝置 | Device | デバイス | ✅ 完全一致 | 保留 |
| Endpoint | 地址 | 位址 | 位址 | Endpoint | アドレス | ✅ 完全一致 | 保留 |
| Endpoints | 连接地址 | 連線位址 | 連線位址 | Endpoints | 接続先 | ✅ 完全一致 | 保留 |
| Frame analysis failed: {0} | 帧分析失败：{0} | 影格分析失敗：{0} | 影格分析失敗：{0} | Frame analysis failed: {0} | フレームの解析に失敗しました: {0} | ✅ 完全一致 | 保留 |
| Idle. | 空闲。 | 閒置。 | 閒置。 | Idle. | 待機中。 | ✅ 完全一致 | 保留 |
| LOCAL TEST BENCH | 本地测试台 | 本機測試台 | 本機測試台 | LOCAL TEST BENCH | ローカルのテスト台 | ✅ 完全一致 | 保留 |
| Longest frame gap | 最长帧间隔 | 最長影格間隔 | 最長影格間隔 | Longest frame gap | フレームの最大の間隔 | ✅ 完全一致 | 保留 |
| Media server publish and playback endpoints | 媒体服务器推流与播放地址 | 媒體伺服器串流與播放位址 | 媒體伺服器串流與播放位址 | Media server publish and playback endpoints | メディアサーバーの配信と再生のアドレス | ✅ 完全一致 | 保留 |
| Media server ready | 媒体服务器已就绪 | 媒體伺服器已就緒 | 媒體伺服器已就緒 | Media server ready | メディアサーバーの準備ができました | ✅ 完全一致 | 保留 |
| Media server unavailable | 媒体服务器不可用 | 媒體伺服器無法使用 | 媒體伺服器無法使用 | Media server unavailable | メディアサーバーを使えません | ✅ 完全一致 | 保留 |
| MediaMTX ready | MediaMTX 已就绪 | MediaMTX 已就緒 | MediaMTX 已就緒 | MediaMTX ready | MediaMTXの準備ができました | ✅ 完全一致 | 保留 |
| Near-black frames | 近黑帧数 | 接近全黑的影格數 | 接近全黑的影格數 | Near-black frames | ほぼ黒のフレーム | ✅ 完全一致 | 保留 |
| Negotiating WHEP playback | 正在建立 WHEP 播放连接 | 正在建立 WHEP 播放連線 | 正在建立 WHEP 播放連線 | Negotiating WHEP playback | WHEPの再生の接続を確立しています | ✅ 完全一致 | 保留 |
| No active stream. Start RTMP, SRT, or WHIP from iPhoneMirror. | 没有活动流。请从 iPhoneMirror 启动 RTMP、SRT 或 WHIP 推流。 | 沒有使用中的串流。請從 iPhoneMirror 啟動 RTMP、SRT 或 WHIP 串流。 | 沒有使用中的串流。請從 iPhoneMirror 啟動 RTMP、SRT 或 WHIP 串流。 | No active stream. Start RTMP, SRT, or WHIP from iPhoneMirror. | 配信中のストリームはありません。iPhoneMirrorからRTMP・SRT・WHIPで配信を始めてください。 | ✅ 完全一致 | 保留 |
| No response from media server | 媒体服务器没有响应 | 媒體伺服器沒有回應 | 媒體伺服器沒有回應 | No response from media server | メディアサーバーから応答がありません | ✅ 完全一致 | 保留 |
| No video input found | 未找到视频输入 | 找不到視訊輸入 | 找不到視訊輸入 | No video input found | ビデオ入力が見つかりません | ✅ 完全一致 | 保留 |
| No video input is available. | 没有可用的视频输入。 | 沒有可用的視訊輸入。 | 沒有可用的視訊輸入。 | No video input is available. | 使えるビデオ入力がありません。 | ✅ 完全一致 | 保留 |
| No video input was found. | 未找到视频输入。 | 找不到視訊輸入。 | 找不到視訊輸入。 | No video input was found. | ビデオ入力が見つかりませんでした。 | ✅ 完全一致 | 保留 |
| Not open | 未打开 | 未開啟 | 未開啟 | Not open | 開いていません | ✅ 完全一致 | 保留 |
| Open backend player | 打开后端播放器 | 開啟後端播放器 | 開啟後端播放器 | Open backend player | サーバー側のプレーヤーを開く | ✅ 完全一致 | 保留 |
| Open camera | 打开摄像头 | 開啟攝影機 | 開啟攝影機 | Open camera | カメラを開く | ✅ 完全一致 | 保留 |
| PUBLISH TARGETS | 推流目标 | 串流目標 | 串流目標 | PUBLISH TARGETS | 配信先 | ✅ 完全一致 | 保留 |
| Playback state: {0} | 播放状态：{0} | 播放狀態：{0} | 播放狀態：{0} | Playback state: {0} | 再生の状態: {0} | ✅ 完全一致 | 保留 |
| Protocol | 协议 | 協定 | 協定 | Protocol | プロトコル | ✅ 完全一致 | 保留 |
| Publish browser camera through WHIP | 通过 WHIP 推送浏览器摄像头画面 | 透過 WHIP 發佈瀏覽器攝影機畫面 | 透過 WHIP 發布瀏覽器攝影機畫面 | Publish browser camera through WHIP | ブラウザーのカメラをWHIPで配信 | ✅ 完全一致 | 保留 |
| Publish from iPhoneMirror | 从 iPhoneMirror 推流 | 從 iPhoneMirror 發佈串流 | 從 iPhoneMirror 發布串流 | Publish from iPhoneMirror | iPhoneMirrorから配信 | ✅ 完全一致 | 保留 |
| Publish from iPhoneMirror through RTMP, SRT, or WHIP, then verify the same stream through WHEP. | 通过 iPhoneMirror 以 RTMP、SRT 或 WHIP 推流，再通过 WHEP 验证同一条流。 | 透過 iPhoneMirror 以 RTMP、SRT 或 WHIP 發佈串流，再透過 WHEP 驗證同一串流。 | 透過 iPhoneMirror 以 RTMP、SRT 或 WHIP 發布串流，再透過 WHEP 驗證同一串流。 | Publish from iPhoneMirror through RTMP, SRT, or WHIP, then verify the same stream through WHEP. | iPhoneMirrorからRTMP・SRT・WHIPで配信し、同じストリームをWHEPで確かめます。 | ✅ 完全一致 | 保留 |
| Publish state: {0} | 推流状态：{0} | 串流狀態：{0} | 串流狀態：{0} | Publish state: {0} | 配信の状態: {0} | ✅ 完全一致 | 保留 |
| Refresh | 刷新 | 重新整理 | 重新整理 | Refresh | 更新 | ✅ 完全一致 | 保留 |
| Request camera access to list devices | 允许摄像头访问以列出设备 | 允許存取攝影機以列出裝置 | 允許存取攝影機以列出裝置 | Request camera access to list devices | デバイスを一覧にするには、カメラへのアクセスを許可してください | ✅ 完全一致 | 保留 |
| Request returned HTTP {0} | 请求返回 HTTP {0} | 請求傳回 HTTP {0} | 要求傳回 HTTP {0} | Request returned HTTP {0} | 要求がHTTP {0}を返しました | ✅ 完全一致 | 保留 |
| Requesting browser camera... | 正在请求摄像头权限… | 正在請求攝影機權限… | 正在要求攝影機權限… | Requesting browser camera... | カメラの許可を求めています… | ✅ 完全一致 | 保留 |
| Resolution | 分辨率 | 解像度 | 解析度 | Resolution | 解像度 | ✅ 完全一致 | 保留 |
| Role | 用途 | 用途 | 用途 | Role | 用途 | ✅ 完全一致 | 保留 |
| SERVER INVENTORY | 服务器状态 | 伺服器狀態 | 伺服器狀態 | SERVER INVENTORY | サーバーの状態 | ✅ 完全一致 | 保留 |
| SRS ready | SRS 已就绪 | SRS 已就緒 | SRS 已就緒 | SRS ready | SRSの準備ができました | ✅ 完全一致 | 保留 |
| Scan cameras | 扫描摄像头 | 掃描攝影機 | 掃描攝影機 | Scan cameras | カメラをスキャン | ✅ 完全一致 | 保留 |
| Start WHEP playback | 开始 WHEP 播放 | 開始 WHEP 播放 | 開始 WHEP 播放 | Start WHEP playback | WHEPの再生を開始 | ✅ 完全一致 | 保留 |
| Start monitor | 开始预览 | 開始預覽 | 開始預覽 | Start monitor | モニターを開始 | ✅ 完全一致 | 保留 |
| Stop | 停止 | 停止 | 停止 | Stop | 停止 | ✅ 完全一致 | 保留 |
| Stop browser publish | 停止浏览器推流 | 停止瀏覽器串流 | 停止瀏覽器串流 | Stop browser publish | ブラウザーからの配信を停止 | ✅ 完全一致 | 保留 |
| Stop playback | 停止播放 | 停止播放 | 停止播放 | Stop playback | 再生を停止 | ✅ 完全一致 | 保留 |
| Stream | 流名称 | 串流名稱 | 串流名稱 | Stream | ストリーム名 | ✅ 完全一致 | 保留 |
| Streams: {0} | 流数量：{0} | 串流數量：{0} | 串流數量：{0} | Streams: {0} | ストリーム: {0} | ✅ 完全一致 | 保留 |
| The page focuses on video delivery. iPhoneMirror may include source audio when available; browser camera publishing is an independent SRS check. | 此页面用于验证视频传输。iPhoneMirror 可在音源可用时包含音频；浏览器摄像头推流是独立的 SRS 测试。 | 此頁面用於驗證視訊傳輸。iPhoneMirror 可在音訊來源可用時包含音訊；瀏覽器攝影機串流是獨立的 SRS 測試。 | 此頁面用於驗證視訊傳輸。iPhoneMirror 可在音訊來源可用時包含音訊；瀏覽器攝影機串流是獨立的 SRS 測試。 | The page focuses on video delivery. iPhoneMirror may include source audio when available; browser camera publishing is an independent SRS check. | このページは映像の配信の確認用です。iPhoneMirrorは、音声があれば一緒に送ることがあります。ブラウザーのカメラからの配信は、SRSを単独で確かめるためのものです。 | ✅ 完全一致 | 保留 |
| Use the same stream name in the app | 使用与应用相同的流名称 | 使用與應用程式相同的串流名稱 | 使用與應用程式相同的串流名稱 | Use the same stream name in the app | アプリでも同じストリーム名を使ってください | ✅ 完全一致 | 保留 |
| VIRTUAL CAMERA | 虚拟摄像头 | 虛擬攝影機 | 虛擬攝影機 | VIRTUAL CAMERA | 仮想カメラ | ✅ 完全一致 | 保留 |
| Video input | 视频输入 | 視訊輸入 | 視訊輸入 | Video input | ビデオ入力 | ✅ 完全一致 | 保留 |
| Video inputs: {0}. Selected: {1}. | 视频输入：{0}。已选择：{1}。 | 視訊輸入：{0}。已選擇：{1}。 | 視訊輸入：{0}。已選擇：{1}。 | Video inputs: {0}. Selected: {1}. | ビデオ入力: {0}。選択中: {1}。 | ✅ 完全一致 | 保留 |
| WEBRTC PLAYBACK | WebRTC 播放 | WebRTC 播放 | WebRTC 播放 | WEBRTC PLAYBACK | WebRTCの再生 | ✅ 完全一致 | 保留 |
| WHEP Playback | WHEP 播放 | WHEP 播放 | WHEP 播放 | WHEP Playback | WHEPの再生 | ✅ 完全一致 | 保留 |
| WHEP monitor | WHEP 预览 | WHEP 預覽 | WHEP 預覽 | WHEP monitor | WHEPのモニター | ✅ 完全一致 | 保留 |
| Waiting for a live stream | 等待实时流 | 等待即時串流 | 等待即時串流 | Waiting for a live stream | ライブストリームを待っています | ✅ 完全一致 | 保留 |
| Waiting for media server. | 等待媒体服务器。 | 等待媒體伺服器。 | 等待媒體伺服器。 | Waiting for media server. | メディアサーバーを待っています。 | ✅ 完全一致 | 保留 |
| Waiting for video frames | 等待视频帧 | 等待視訊影格 | 等待視訊影格 | Waiting for video frames | ビデオのフレームを待っています | ✅ 完全一致 | 保留 |
| WebRTC connection failed | WebRTC 连接失败 | WebRTC 連線失敗 | WebRTC 連線失敗 | WebRTC connection failed | WebRTCの接続に失敗しました | ✅ 完全一致 | 保留 |
| closed | 已关闭 | 已關閉 | 已關閉 | closed | 終了 | ✅ 完全一致 | 保留 |
| disconnected | 已断开 | 已中斷 | 已中斷連線 | disconnected | 切断 | ✅ 完全一致 | 保留 |
| failed | 失败 | 失敗 | 失敗 | failed | 失敗 | ✅ 完全一致 | 保留 |
| iPhoneMirror SRS Test | iPhoneMirror SRS 测试 | iPhoneMirror SRS 測試 | iPhoneMirror SRS 測試 | iPhoneMirror SRS Test | iPhoneMirror SRSテスト | ✅ 完全一致 | 保留 |
| iPhoneMirror Stream Lab | iPhoneMirror 推流实验室 | iPhoneMirror 串流實驗室 | iPhoneMirror 串流實驗室 | iPhoneMirror Stream Lab | iPhoneMirror配信ラボ | ✅ 完全一致 | 保留 |
| unknown | 未知 | 未知 | 未知 | unknown | 不明 | ✅ 完全一致 | 保留 |
| video | 视频 | 視訊 | 視訊 | video | ビデオ | ✅ 完全一致 | 保留 |
| {0} at {1}. | {0}（地址：{1}）。 | {0}（位址：{1}）。 | {0}（位址：{1}）。 | {0} at {1}. | {0}（アドレス: {1}）。 | ✅ 完全一致 | 保留 |

### SrsTest

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 0 streams | 流数量：0 | 串流數量：0 | 串流數量：0 | 0 streams | ストリーム: 0 | ✅ 完全一致 | 保留 |
| Active media streams | 活动媒体流 | 使用中的媒體串流 | 使用中的媒體串流 | Active media streams | 配信中のストリーム | ✅ 完全一致 | 保留 |
| Actual FPS | 实际帧率 | 實際影格率 | 實際影格率 | Actual FPS | 実際のfps | ✅ 完全一致 | 保留 |
| App | 应用名 | 應用程式名稱 | 應用程式名稱 | App | アプリ名 | ✅ 完全一致 | 保留 |
| Browser camera is idle. | 浏览器摄像头空闲。 | 瀏覽器攝影機閒置。 | 瀏覽器攝影機閒置。 | Browser camera is idle. | ブラウザーのカメラは待機中です。 | ✅ 完全一致 | 保留 |
| Browser device check | 浏览器设备检查 | 瀏覽器裝置檢查 | 瀏覽器裝置檢查 | Browser device check | ブラウザーでのデバイスの確認 | ✅ 完全一致 | 保留 |
| Browser playback | 浏览器播放 | 瀏覽器播放 | 瀏覽器播放 | Browser playback | ブラウザーで再生 | ✅ 完全一致 | 保留 |
| Camera APIs are unavailable in this browser context. | 当前浏览器环境不支持摄像头接口。 | 目前瀏覽器環境不支援攝影機介面。 | 目前瀏覽器環境不支援攝影機介面。 | Camera APIs are unavailable in this browser context. | このブラウザーの環境では、カメラのAPIを使えません。 | ✅ 完全一致 | 保留 |
| Camera is delivering frames. | 摄像头正在传输画面。 | 攝影機正在傳送畫面。 | 攝影機正在傳送畫面。 | Camera is delivering frames. | カメラから映像が届いています。 | ✅ 完全一致 | 保留 |
| Camera is not open. | 摄像头未打开。 | 攝影機未開啟。 | 攝影機未開啟。 | Camera is not open. | カメラが開いていません。 | ✅ 完全一致 | 保留 |
| Camera permission request timed out. | 摄像头权限请求超时。 | 攝影機權限請求逾時。 | 攝影機權限要求逾時。 | Camera permission request timed out. | カメラの許可の要求がタイムアウトしました。 | ✅ 完全一致 | 保留 |
| Camera permission request timed out. Allow camera access and scan again. | 摄像头权限请求超时。请允许访问后重新扫描。 | 攝影機權限請求逾時。請允許存取後重新掃描。 | 攝影機權限要求逾時。請允許存取後重新掃描。 | Camera permission request timed out. Allow camera access and scan again. | カメラの許可の要求がタイムアウトしました。カメラへのアクセスを許可して、もう一度スキャンしてください。 | ✅ 完全一致 | 保留 |
| Camera {0} | 摄像头 {0} | 攝影機 {0} | 攝影機 {0} | Camera {0} | カメラ {0} | ✅ 完全一致 | 保留 |
| Checking media server | 正在检查媒体服务器 | 正在檢查媒體伺服器 | 正在檢查媒體伺服器 | Checking media server | メディアサーバーを確認しています | ✅ 完全一致 | 保留 |
| Clients: {0} | 客户端：{0} | 用戶端：{0} | 用戶端：{0} | Clients: {0} | クライアント: {0} | ✅ 完全一致 | 保留 |
| Connected. | 已连接。 | 已連線。 | 已連線。 | Connected. | 接続しました。 | ✅ 完全一致 | 保留 |
| Connecting to WHEP... | 正在连接 WHEP… | 正在連線至 WHEP… | 正在連線至 WHEP… | Connecting to WHEP... | WHEPに接続しています… | ✅ 完全一致 | 保留 |
| Dashboard request failed | 状态请求失败 | 狀態請求失敗 | 狀態要求失敗 | Dashboard request failed | 状態の取得に失敗しました | ✅ 完全一致 | 保留 |
| Device | 设备 | 裝置 | 裝置 | Device | デバイス | ✅ 完全一致 | 保留 |
| Endpoint | 地址 | 位址 | 位址 | Endpoint | アドレス | ✅ 完全一致 | 保留 |
| Endpoints | 连接地址 | 連線位址 | 連線位址 | Endpoints | 接続先 | ✅ 完全一致 | 保留 |
| Frame analysis failed: {0} | 帧分析失败：{0} | 影格分析失敗：{0} | 影格分析失敗：{0} | Frame analysis failed: {0} | フレームの解析に失敗しました: {0} | ✅ 完全一致 | 保留 |
| Idle. | 空闲。 | 閒置。 | 閒置。 | Idle. | 待機中。 | ✅ 完全一致 | 保留 |
| LOCAL TEST BENCH | 本地测试台 | 本機測試台 | 本機測試台 | LOCAL TEST BENCH | ローカルのテスト台 | ✅ 完全一致 | 保留 |
| Longest frame gap | 最长帧间隔 | 最長影格間隔 | 最長影格間隔 | Longest frame gap | フレームの最大の間隔 | ✅ 完全一致 | 保留 |
| Media server publish and playback endpoints | 媒体服务器推流与播放地址 | 媒體伺服器串流與播放位址 | 媒體伺服器串流與播放位址 | Media server publish and playback endpoints | メディアサーバーの配信と再生のアドレス | ✅ 完全一致 | 保留 |
| Media server ready | 媒体服务器已就绪 | 媒體伺服器已就緒 | 媒體伺服器已就緒 | Media server ready | メディアサーバーの準備ができました | ✅ 完全一致 | 保留 |
| Media server unavailable | 媒体服务器不可用 | 媒體伺服器無法使用 | 媒體伺服器無法使用 | Media server unavailable | メディアサーバーを使えません | ✅ 完全一致 | 保留 |
| MediaMTX ready | MediaMTX 已就绪 | MediaMTX 已就緒 | MediaMTX 已就緒 | MediaMTX ready | MediaMTXの準備ができました | ✅ 完全一致 | 保留 |
| Near-black frames | 近黑帧数 | 接近全黑的影格數 | 接近全黑的影格數 | Near-black frames | ほぼ黒のフレーム | ✅ 完全一致 | 保留 |
| Negotiating WHEP playback | 正在建立 WHEP 播放连接 | 正在建立 WHEP 播放連線 | 正在建立 WHEP 播放連線 | Negotiating WHEP playback | WHEPの再生の接続を確立しています | ✅ 完全一致 | 保留 |
| No active stream. Start RTMP, SRT, or WHIP from iPhoneMirror. | 没有活动流。请从 iPhoneMirror 启动 RTMP、SRT 或 WHIP 推流。 | 沒有使用中的串流。請從 iPhoneMirror 啟動 RTMP、SRT 或 WHIP 串流。 | 沒有使用中的串流。請從 iPhoneMirror 啟動 RTMP、SRT 或 WHIP 串流。 | No active stream. Start RTMP, SRT, or WHIP from iPhoneMirror. | 配信中のストリームはありません。iPhoneMirrorからRTMP・SRT・WHIPで配信を始めてください。 | ✅ 完全一致 | 保留 |
| No response from media server | 媒体服务器没有响应 | 媒體伺服器沒有回應 | 媒體伺服器沒有回應 | No response from media server | メディアサーバーから応答がありません | ✅ 完全一致 | 保留 |
| No video input found | 未找到视频输入 | 找不到視訊輸入 | 找不到視訊輸入 | No video input found | ビデオ入力が見つかりません | ✅ 完全一致 | 保留 |
| No video input is available. | 没有可用的视频输入。 | 沒有可用的視訊輸入。 | 沒有可用的視訊輸入。 | No video input is available. | 使えるビデオ入力がありません。 | ✅ 完全一致 | 保留 |
| No video input was found. | 未找到视频输入。 | 找不到視訊輸入。 | 找不到視訊輸入。 | No video input was found. | ビデオ入力が見つかりませんでした。 | ✅ 完全一致 | 保留 |
| Not open | 未打开 | 未開啟 | 未開啟 | Not open | 開いていません | ✅ 完全一致 | 保留 |
| Open backend player | 打开后端播放器 | 開啟後端播放器 | 開啟後端播放器 | Open backend player | サーバー側のプレーヤーを開く | ✅ 完全一致 | 保留 |
| Open camera | 打开摄像头 | 開啟攝影機 | 開啟攝影機 | Open camera | カメラを開く | ✅ 完全一致 | 保留 |
| PUBLISH TARGETS | 推流目标 | 串流目標 | 串流目標 | PUBLISH TARGETS | 配信先 | ✅ 完全一致 | 保留 |
| Playback state: {0} | 播放状态：{0} | 播放狀態：{0} | 播放狀態：{0} | Playback state: {0} | 再生の状態: {0} | ✅ 完全一致 | 保留 |
| Protocol | 协议 | 協定 | 協定 | Protocol | プロトコル | ✅ 完全一致 | 保留 |
| Publish browser camera through WHIP | 通过 WHIP 推送浏览器摄像头画面 | 透過 WHIP 發佈瀏覽器攝影機畫面 | 透過 WHIP 發布瀏覽器攝影機畫面 | Publish browser camera through WHIP | ブラウザーのカメラをWHIPで配信 | ✅ 完全一致 | 保留 |
| Publish from iPhoneMirror | 从 iPhoneMirror 推流 | 從 iPhoneMirror 發佈串流 | 從 iPhoneMirror 發布串流 | Publish from iPhoneMirror | iPhoneMirrorから配信 | ✅ 完全一致 | 保留 |
| Publish from iPhoneMirror through RTMP, SRT, or WHIP, then verify the same stream through WHEP. | 通过 iPhoneMirror 以 RTMP、SRT 或 WHIP 推流，再通过 WHEP 验证同一条流。 | 透過 iPhoneMirror 以 RTMP、SRT 或 WHIP 發佈串流，再透過 WHEP 驗證同一串流。 | 透過 iPhoneMirror 以 RTMP、SRT 或 WHIP 發布串流，再透過 WHEP 驗證同一串流。 | Publish from iPhoneMirror through RTMP, SRT, or WHIP, then verify the same stream through WHEP. | iPhoneMirrorからRTMP・SRT・WHIPで配信し、同じストリームをWHEPで確かめます。 | ✅ 完全一致 | 保留 |
| Publish state: {0} | 推流状态：{0} | 串流狀態：{0} | 串流狀態：{0} | Publish state: {0} | 配信の状態: {0} | ✅ 完全一致 | 保留 |
| Refresh | 刷新 | 重新整理 | 重新整理 | Refresh | 更新 | ✅ 完全一致 | 保留 |
| Request camera access to list devices | 允许摄像头访问以列出设备 | 允許存取攝影機以列出裝置 | 允許存取攝影機以列出裝置 | Request camera access to list devices | デバイスを一覧にするには、カメラへのアクセスを許可してください | ✅ 完全一致 | 保留 |
| Request returned HTTP {0} | 请求返回 HTTP {0} | 請求傳回 HTTP {0} | 要求傳回 HTTP {0} | Request returned HTTP {0} | 要求がHTTP {0}を返しました | ✅ 完全一致 | 保留 |
| Requesting browser camera... | 正在请求摄像头权限… | 正在請求攝影機權限… | 正在要求攝影機權限… | Requesting browser camera... | カメラの許可を求めています… | ✅ 完全一致 | 保留 |
| Resolution | 分辨率 | 解像度 | 解析度 | Resolution | 解像度 | ✅ 完全一致 | 保留 |
| Role | 用途 | 用途 | 用途 | Role | 用途 | ✅ 完全一致 | 保留 |
| SERVER INVENTORY | 服务器状态 | 伺服器狀態 | 伺服器狀態 | SERVER INVENTORY | サーバーの状態 | ✅ 完全一致 | 保留 |
| SRS ready | SRS 已就绪 | SRS 已就緒 | SRS 已就緒 | SRS ready | SRSの準備ができました | ✅ 完全一致 | 保留 |
| Scan cameras | 扫描摄像头 | 掃描攝影機 | 掃描攝影機 | Scan cameras | カメラをスキャン | ✅ 完全一致 | 保留 |
| Start WHEP playback | 开始 WHEP 播放 | 開始 WHEP 播放 | 開始 WHEP 播放 | Start WHEP playback | WHEPの再生を開始 | ✅ 完全一致 | 保留 |
| Start monitor | 开始预览 | 開始預覽 | 開始預覽 | Start monitor | モニターを開始 | ✅ 完全一致 | 保留 |
| Stop | 停止 | 停止 | 停止 | Stop | 停止 | ✅ 完全一致 | 保留 |
| Stop browser publish | 停止浏览器推流 | 停止瀏覽器串流 | 停止瀏覽器串流 | Stop browser publish | ブラウザーからの配信を停止 | ✅ 完全一致 | 保留 |
| Stop playback | 停止播放 | 停止播放 | 停止播放 | Stop playback | 再生を停止 | ✅ 完全一致 | 保留 |
| Stream | 流名称 | 串流名稱 | 串流名稱 | Stream | ストリーム名 | ✅ 完全一致 | 保留 |
| Streams: {0} | 流数量：{0} | 串流數量：{0} | 串流數量：{0} | Streams: {0} | ストリーム: {0} | ✅ 完全一致 | 保留 |
| The page focuses on video delivery. iPhoneMirror may include source audio when available; browser camera publishing is an independent SRS check. | 此页面用于验证视频传输。iPhoneMirror 可在音源可用时包含音频；浏览器摄像头推流是独立的 SRS 测试。 | 此頁面用於驗證視訊傳輸。iPhoneMirror 可在音訊來源可用時包含音訊；瀏覽器攝影機串流是獨立的 SRS 測試。 | 此頁面用於驗證視訊傳輸。iPhoneMirror 可在音訊來源可用時包含音訊；瀏覽器攝影機串流是獨立的 SRS 測試。 | The page focuses on video delivery. iPhoneMirror may include source audio when available; browser camera publishing is an independent SRS check. | このページは映像の配信の確認用です。iPhoneMirrorは、音声があれば一緒に送ることがあります。ブラウザーのカメラからの配信は、SRSを単独で確かめるためのものです。 | ✅ 完全一致 | 保留 |
| Use the same stream name in the app | 使用与应用相同的流名称 | 使用與應用程式相同的串流名稱 | 使用與應用程式相同的串流名稱 | Use the same stream name in the app | アプリでも同じストリーム名を使ってください | ✅ 完全一致 | 保留 |
| VIRTUAL CAMERA | 虚拟摄像头 | 虛擬攝影機 | 虛擬攝影機 | VIRTUAL CAMERA | 仮想カメラ | ✅ 完全一致 | 保留 |
| Video input | 视频输入 | 視訊輸入 | 視訊輸入 | Video input | ビデオ入力 | ✅ 完全一致 | 保留 |
| Video inputs: {0}. Selected: {1}. | 视频输入：{0}。已选择：{1}。 | 視訊輸入：{0}。已選擇：{1}。 | 視訊輸入：{0}。已選擇：{1}。 | Video inputs: {0}. Selected: {1}. | ビデオ入力: {0}。選択中: {1}。 | ✅ 完全一致 | 保留 |
| WEBRTC PLAYBACK | WebRTC 播放 | WebRTC 播放 | WebRTC 播放 | WEBRTC PLAYBACK | WebRTCの再生 | ✅ 完全一致 | 保留 |
| WHEP Playback | WHEP 播放 | WHEP 播放 | WHEP 播放 | WHEP Playback | WHEPの再生 | ✅ 完全一致 | 保留 |
| WHEP monitor | WHEP 预览 | WHEP 預覽 | WHEP 預覽 | WHEP monitor | WHEPのモニター | ✅ 完全一致 | 保留 |
| Waiting for a live stream | 等待实时流 | 等待即時串流 | 等待即時串流 | Waiting for a live stream | ライブストリームを待っています | ✅ 完全一致 | 保留 |
| Waiting for media server. | 等待媒体服务器。 | 等待媒體伺服器。 | 等待媒體伺服器。 | Waiting for media server. | メディアサーバーを待っています。 | ✅ 完全一致 | 保留 |
| Waiting for video frames | 等待视频帧 | 等待視訊影格 | 等待視訊影格 | Waiting for video frames | ビデオのフレームを待っています | ✅ 完全一致 | 保留 |
| WebRTC connection failed | WebRTC 连接失败 | WebRTC 連線失敗 | WebRTC 連線失敗 | WebRTC connection failed | WebRTCの接続に失敗しました | ✅ 完全一致 | 保留 |
| closed | 已关闭 | 已關閉 | 已關閉 | closed | 終了 | ✅ 完全一致 | 保留 |
| disconnected | 已断开 | 已中斷 | 已中斷連線 | disconnected | 切断 | ✅ 完全一致 | 保留 |
| failed | 失败 | 失敗 | 失敗 | failed | 失敗 | ✅ 完全一致 | 保留 |
| iPhoneMirror SRS Test | iPhoneMirror SRS 测试 | iPhoneMirror SRS 測試 | iPhoneMirror SRS 測試 | iPhoneMirror SRS Test | iPhoneMirror SRSテスト | ✅ 完全一致 | 保留 |
| iPhoneMirror Stream Lab | iPhoneMirror 推流实验室 | iPhoneMirror 串流實驗室 | iPhoneMirror 串流實驗室 | iPhoneMirror Stream Lab | iPhoneMirror配信ラボ | ✅ 完全一致 | 保留 |
| unknown | 未知 | 未知 | 未知 | unknown | 不明 | ✅ 完全一致 | 保留 |
| video | 视频 | 視訊 | 視訊 | video | ビデオ | ✅ 完全一致 | 保留 |
| {0} at {1}. | {0}（地址：{1}）。 | {0}（位址：{1}）。 | {0}（位址：{1}）。 | {0} at {1}. | {0}（アドレス: {1}）。 | ✅ 完全一致 | 保留 |

### Launcher

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 / 使用情况 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| ExecutableMissing | 找不到 iPhoneMirror.Driver.exe。请将启动器放在驱动管理器所在文件夹。 | 找不到 iPhoneMirror.Driver.exe。請將啟動器放在驅動程式管理員所在資料夾。 | 找不到 iPhoneMirror.Driver.exe。請將啟動器放在驅動程式管理員所在資料夾。 | iPhoneMirror.Driver.exe was not found. Place this launcher in the driver manager folder. | iPhoneMirror.Driver.exeが見つかりません。このランチャーをドライバー管理のフォルダーに置いてください。 | ❌ 缺失 → ✅ 已修复 | 独立 CMD 无法加载语言字典，故障时显示简体、繁体和英文回退；UTF-8/CRLF 防止乱码；独立 CMD 启动器无语言字典，异常时同时显示三语回退 |
| OperationIncomplete | 操作未完成。退出代码：%EXIT_CODE% | 操作未完成。結束代碼：%EXIT_CODE% | 操作未完成。結束代碼：%EXIT_CODE% | The operation did not complete. Exit code: %EXIT_CODE% | 操作は完了しませんでした。終了コード: %EXIT_CODE% | ❌ 缺失 → ✅ 已修复 | 独立启动器异常结果补齐三语，保留退出代码变量；独立 CMD 启动器无语言字典，异常时同时显示三语回退 |
| Title | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | iPhoneMirror | ❌ 含义不一致 → ✅ 已修复 | 窗口标题保留产品名，避免暗示删除所有设备驱动；原设备范围不变；独立 CMD 启动器无语言字典，异常时同时显示三语回退 |

### 代码调用对应关系

| Key / 位置 | 简体中文 | 繁體中文（香港） | 繁體中文（台灣） | English | 日本語 | 状态（修改前 → 修改后） | 修改内容 |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Code/MainViewModel.ShowControlOperationError | 蓝牙 / 无线 → 对应控制模式 | 藍牙 / 無線 → 對應控制模式 | 见对应资源 Key | Bluetooth / wireless → corresponding control mode | 见对应资源 Key | ❌ 含义不一致 → ✅ 已修复 | 补齐香港繁体的蓝牙/无线传输名称匹配，避免错误归类为有线控制 |
| Code/ReverseControlStatusWindow.ModeSummary | 有线控制 | 有線控制 | 见对应资源 Key | Wired control | 见对应资源 Key | ❌ 术语不一致 → ✅ 已修复 | 有线模式摘要复用 WiredControlLabel，与按钮和状态名称一致 |
| Code/DriverCleanupHost.ExecutableMissing | 无法确定驱动管理器的可执行文件路径。 | 無法確定驅動程式管理員的可執行檔路徑。 | 见对应资源 Key | The driver manager executable path could not be determined. | 见对应资源 Key | ❌ 缺失 → ✅ 已修复 | 复用 DriverExecutableMissing；界面使用所选语言，字典加载前保留英文诊断回退 |
| Code/ControlStatusService.Cancelled | 已取消反向控制 | 已取消反向控制 | 见对应资源 Key | Reverse control cancelled | 见对应资源 Key | ❌ 缺失 → ✅ 已修复 | 默认取消说明原为硬编码中文；调用时读取现有 ControlStageCancelled 资源 |

## 代码位置与修改前记录

| Key / 位置 | 修改前文字 | 修改说明 | 当前调用位置 |
| --- | --- | --- | --- |
| App/AboutDescription | zh-CN: 低延迟 iPhone 屏幕投射、录制、直播与虚拟摄像头。；zh-HK: 低延遲 iPhone 螢幕投射、錄製、直播與虛擬攝影機。 | 关于页沿用投屏、推流正式术语 | src/App/Windows/AboutWindow.xaml:69 |
| App/AboutSubtitle | zh-HK: 應用程式資訊、更新和診斷 | 统一香港繁体中文既有用语 | src/App/Windows/AboutWindow.xaml:34 |
| App/AdvancedUsbResolutionHelp | en-US: Enter a value such as 1920×1080. Apply ignores normal preview presets; disabling advanced mode restores them. | 优化自然表达和可读性 | src/App/Windows/AdvancedSettingsWindow.xaml:22 |
| App/BluetoothClientBindingHint | zh-HK: 首次使用此投屏裝置時，請確認清單中的藍牙用戶端就是目前裝置。之後切換分頁會自動使用此綁定。 | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:1821；src/App/Windows/BluetoothClientBindingWindow.xaml:34 |
| App/BluetoothControlConnected | zh-CN: iPhone/iPad 已连接蓝牙反向控制；zh-HK: iPhone/iPad 已連接藍牙反向控制 | 状态及操作标签统一为蓝牙控制 | src/App/ViewModels/MainViewModel.cs:1582；src/App/ViewModels/MainViewModel.cs:2016 |
| App/BluetoothControlOff | zh-CN: 蓝牙反向控制未启用；zh-HK: 藍牙反向控制未啟用 | 状态及操作标签统一为蓝牙控制 | src/App/ViewModels/MainViewModel.cs:1132 |
| App/BluetoothControlPromptAutoCloseFormat | en-US: Closes automatically in {0} seconds | 秒使用单位 s，适用于倒计时 1 秒 | src/App/Windows/BluetoothControlNoticeWindow.xaml.cs:85 |
| App/BluetoothControlPromptShortcutFormat | en-US: Press {0} to release | 补齐释放对象 | src/App/Windows/BluetoothControlNoticeWindow.xaml.cs:71 |
| App/BluetoothControlPromptTitle | zh-CN: 蓝牙反向控制已开启；zh-HK: 藍牙反向控制已啟用 | 状态及操作标签统一为蓝牙控制 | src/App/ViewModels/MainViewModel.cs:3126；src/App/Windows/BluetoothControlNoticeWindow.xaml.cs:36 |
| App/BluetoothControlReportMapChangedStatus | en-US: Re-pair required | 优化自然表达和可读性 | src/App/Windows/BluetoothControlNoticeWindow.xaml.cs:83 |
| App/BluetoothControlReportMapChangedTitle | zh-CN: 蓝牙控制需要刷新配对；en-US: Bluetooth control needs pairing refresh | 优化自然表达和可读性 | src/App/ViewModels/MainViewModel.cs:1702；src/App/Windows/BluetoothControlNoticeWindow.xaml.cs:35 |
| App/BluetoothControlStartFailedFormat | zh-CN: 蓝牙反控启动失败：{0}；zh-HK: 藍牙反向控制啟動失敗：{0}；en-US: Bluetooth reverse-control startup failed: {0} | 状态及操作标签统一为蓝牙控制 | src/App/MainWindow.xaml.cs:5474 |
| App/BluetoothHidCharacteristicFailedFormat | en-US: $"Could not create HID characteristic {uuid}: {result.Error}" | 补齐蓝牙启动失败详情中的第一方提示；保留系统错误码 | src/App/Services/BluetoothHidMouseService.cs:1009 |
| App/BluetoothHidReportDescriptorFailedFormat | en-US: $"Could not create HID report descriptor: {result.Error}" | 补齐蓝牙启动失败详情中的第一方提示；保留系统错误码 | src/App/Services/BluetoothHidMouseService.cs:1028 |
| App/BluetoothHidWheelDescriptorFailedFormat | en-US: $"Could not create HID wheel feature descriptor: {result.Error}" | 补齐蓝牙启动失败详情中的第一方提示；保留系统错误码 | src/App/Services/BluetoothHidMouseService.cs:1889 |
| App/BluetoothLandscapeMouseLeft90 | zh-CN: 左90度；zh-HK: 左90度；en-US: Left 90 degrees | 优化自然表达和可读性 | 见 Key 所指文件或资源字典 |
| App/BluetoothLandscapeMouseLeft90Reverse | zh-CN: 左90度（反）；zh-HK: 左90度（反）；en-US: Left 90 degrees (reversed) | 优化自然表达和可读性 | 见 Key 所指文件或资源字典 |
| App/BluetoothLandscapeMouseRight90 | zh-CN: 右90度；zh-HK: 右90度；en-US: Right 90 degrees | 优化自然表达和可读性 | 见 Key 所指文件或资源字典 |
| App/BluetoothLandscapeMouseRight90Reverse | zh-CN: 右90度（反）；zh-HK: 右90度（反）；en-US: Right 90 degrees (reversed) | 优化自然表达和可读性 | 见 Key 所指文件或资源字典 |
| App/BluetoothMouseSettingsSaveFailed | zh-CN: 蓝牙反控鼠标设置保存失败；zh-HK: 藍牙反控滑鼠設定儲存失敗 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:584 |
| App/BluetoothMouseSettingsTitle | zh-CN: 蓝牙反控鼠标设置；zh-HK: 藍牙反控滑鼠設定 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/MainWindow.xaml:1841 |
| App/CaptureActionReconnectDevice | zh-HK: 請保持裝置解鎖，重新插拔傳輸線後再試。 | 统一香港繁体中文既有用语 | src/App/Services/CaptureErrorGuidance.cs:107；src/App/Services/CaptureErrorGuidance.cs:117；src/App/Services/CaptureErrorGuidance.cs:127；src/App/Services/CaptureErrorGuidance.cs:138；src/App/Windows/CaptureStatusNoticeWindow.xaml.cs:131 |
| App/CaptureActionVideoRetry | zh-HK: 請停止螢幕鏡像後重新開始；仍無畫面時重新連接傳輸線。 | 统一香港繁体中文既有用语 | src/App/Services/CaptureErrorGuidance.cs:120；src/App/Windows/CaptureStatusNoticeWindow.xaml.cs:112 |
| App/CaptureHandshaking | zh-HK: 正在建立螢幕鏡像會話… | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:5783 |
| App/CaptureNoPingCableAction | zh-HK: 更換 Apple 原裝或 MFi 認證傳輸線 | 统一香港繁体中文既有用语 | src/App/Windows/CaptureRecoveryWindow.xaml:79 |
| App/CaptureNoPingRecovery | zh-HK: 裝置已連接，但長時間沒有回應螢幕鏡像握手。<br><br>請重新啟動 iPhone 或 iPad，然後使用 Apple 原裝或 MFi 認證傳輸線重新連接後重試。<br><br>重試時請保持裝置解鎖。 | 统一香港繁体中文既有用语 | 见 Key 所指文件或资源字典 |
| App/CaptureNoticeUsbHint | zh-HK: 請重新插拔傳輸線後重試 | 统一香港繁体中文既有用语 | src/App/Windows/CaptureStatusNoticeWindow.xaml.cs:40 |
| App/CaptureUsbConfigurationRecovery | zh-HK: 未能切換 iPhone 或 iPad 的 USB 螢幕鏡像設定。<br><br>請依序嘗試：<br>1. 拔下傳輸線，等待幾秒後重新插入<br>2. 重新啟動 iPhone 或 iPad 後再連接<br>3. 更換 Apple 原裝或 MFi 認證傳輸線<br><br>重新連接並開始螢幕鏡像時，請保持裝置處於解鎖狀態。 | 统一香港繁体中文既有用语 | 见 Key 所指文件或资源字典 |
| App/CheckingForUpdates | en-US: Connecting to the update services… | 明确当前为更新检查状态 | src/App/Windows/AboutWindow.xaml.cs:117 |
| App/CloseOtherInstances | en-US: Close other window | 操作针对其他全部实例 | src/App/Windows/InstanceConflictWindow.xaml:94 |
| App/CloseOtherInstancesFailedFormat | en-US: {0} iPhoneMirror instance could not be closed. Close it from the taskbar or Task Manager, then try again. | 数量可能大于 1，避免固定单数 instance/it | src/App/Windows/InstanceConflictWindow.xaml.cs:109 |
| App/ClosingOtherInstances | en-US: Safely closing the other iPhoneMirror window… | 操作针对其他全部实例 | src/App/Windows/InstanceConflictWindow.xaml:81 |
| App/ControlAutoReconnectingChannel | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2572；src/App/ViewModels/MainViewModel.cs:2623 |
| App/ControlBindingNotFound | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2428 |
| App/ControlBluetoothBindingAdvice | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1499 |
| App/ControlBluetoothBindingRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1498 |
| App/ControlBluetoothCancelled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1505 |
| App/ControlBluetoothDisconnected | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2004 |
| App/ControlBluetoothPairingTitle | zh-CN: 请在手机和 Windows 上完成蓝牙连接；zh-HK: 請在手機及 Windows 上完成藍牙連線；en-US: Complete Bluetooth pairing on your phone and Windows | 阶段要求为配对，同时适用于 iPhone/iPad | src/App/Windows/ReverseControlStatusWindow.xaml:59 |
| App/ControlBluetoothReadyToPair | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1574 |
| App/ControlBluetoothStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1491；src/App/ViewModels/MainViewModel.cs:1601 |
| App/ControlBluetoothTouchFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2010 |
| App/ControlCheckConnectionAdvice | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/ControlStatusService.cs:349 |
| App/ControlCheckingBluetoothBinding | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/ControlStatusService.cs:213；src/App/ViewModels/MainViewModel.cs:1485 |
| App/ControlCheckingBluetoothSupport | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1550 |
| App/ControlCheckingDeviceBinding | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/ControlStatusService.cs:214；src/App/ViewModels/MainViewModel.cs:2149；src/App/ViewModels/MainViewModel.cs:2420 |
| App/ControlCheckingDevicePermissions | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2157；src/App/ViewModels/MainViewModel.cs:2430 |
| App/ControlCheckingHidChannel | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1997 |
| App/ControlCloseCountdown | en-US: This window closes in {0} seconds | 秒使用单位 s，适用于倒计时 1 秒 | src/App/Windows/ReverseControlStatusWindow.xaml.cs:35 |
| App/ControlConnectingChannel | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2170；src/App/ViewModels/MainViewModel.cs:2456 |
| App/ControlDeviceNotReady | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1491；src/App/ViewModels/MainViewModel.cs:2152；src/App/ViewModels/MainViewModel.cs:2422 |
| App/ControlHidRouteFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2011 |
| App/ControlInitializingInput | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2185；src/App/ViewModels/MainViewModel.cs:2458 |
| App/ControlOperationFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2808；src/App/ViewModels/MainViewModel.cs:2810 |
| App/ControlPreparingInput | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2186；src/App/ViewModels/MainViewModel.cs:2459 |
| App/ControlPreparingSupportFiles | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2443 |
| App/ControlPrerequisiteCancelled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1505；src/App/ViewModels/MainViewModel.cs:2154；src/App/ViewModels/MainViewModel.cs:2424 |
| App/ControlReadyDescription | 原为代码硬编码；对应源码变更见工作区 diff | 控制就绪默认提示改为运行时查找资源 | src/App/Services/ControlStatusService.cs:292 |
| App/ControlReconnectingChannel | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2255 |
| App/ControlRecoveryFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2606；src/App/ViewModels/MainViewModel.cs:2978；src/App/ViewModels/MainViewModel.cs:3021 |
| App/ControlStageConnecting | en-US: Connecting control | 优化自然表达和可读性 | 见 Key 所指文件或资源字典 |
| App/ControlStageFailed | en-US: Unable to start reverse control | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2483 |
| App/ControlStagePreparingDeviceSupport | en-US: Preparing device support | 补齐准备对象为文件 | 见 Key 所指文件或资源字典 |
| App/ControlStageSwitchingBluetoothPeripheral | en-US: Preparing Bluetooth peripheral mode | 与实际切换阶段及中文一致 | 见 Key 所指文件或资源字典 |
| App/ControlSwitchingBluetoothMode | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:1551 |
| App/ControlTotalDuration | en-US: Connection time: {0:0.0} seconds | 与倒计时单位保持一致 | src/App/Windows/ReverseControlStatusWindow.xaml.cs:37 |
| App/ControlWiredCancelled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2424 |
| App/ControlWiredRetryFormat | 原为代码硬编码；对应源码变更见工作区 diff | 自动重连计数提示迁入三语格式资源 | src/App/ViewModels/MainViewModel.cs:2958 |
| App/ControlWiredStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2422；src/App/ViewModels/MainViewModel.cs:2428 |
| App/ControlWirelessCancelled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2154 |
| App/ControlWirelessRecoveryDisconnected | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2327 |
| App/ControlWirelessRecoveryFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2359 |
| App/ControlWirelessRetryFormat | 原为代码硬编码；对应源码变更见工作区 diff | 自动重连计数提示迁入三语格式资源 | src/App/ViewModels/MainViewModel.cs:2300 |
| App/ControlWirelessStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2152 |
| App/ControlWirelessStartupDisconnected | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2181 |
| App/ControlWirelessStartupFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/ViewModels/MainViewModel.cs:2197 |
| App/DecoderStatusDetecting | zh-CN: 解码器状态：正在读取实际解码链路...；zh-HK: 解碼器狀態：正在讀取實際解碼鏈路...；en-US: Decoder status: detecting the active decode path... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:5540 |
| App/DeveloperAboutDescription | zh-HK: 版本、診斷和更新資訊 | 统一香港繁体中文既有用语 | src/App/Windows/DeveloperToolsWindow.xaml.cs:49；src/App/Windows/DeveloperToolsWindow.xaml.cs:126 |
| App/DeveloperAdvancedSettingsDescription | zh-HK: 解析度輸入驗證 | 统一香港繁体中文既有用语 | src/App/Windows/DeveloperToolsWindow.xaml.cs:53 |
| App/DeveloperDriverDescription | zh-HK: 開啟獨立驅動程式管理器 | 统一香港繁体中文既有用语 | src/App/Windows/DeveloperToolsWindow.xaml.cs:48；src/App/Windows/DeveloperToolsWindow.xaml.cs:125 |
| App/DeveloperOutputDescription | en-US: Recording, streaming, and camera | 补齐虚拟摄像头含义 | src/App/Windows/DeveloperToolsWindow.xaml.cs:47；src/App/Windows/DeveloperToolsWindow.xaml.cs:124 |
| App/DeveloperProjectionSettings | en-US: Projection settings window | 投屏统一为 mirroring，视频应用投放仍使用 casting | src/App/Windows/DeveloperToolsWindow.xaml.cs:70；src/App/Windows/DeveloperToolsWindow.xaml.cs:150 |
| App/DeveloperPromptDescription | zh-HK: 標準確認和資訊版面 | 统一香港繁体中文既有用语 | src/App/Windows/DeveloperToolsWindow.xaml.cs:61 |
| App/DeveloperSettings | en-US: Projection settings | 投屏统一为 mirroring，视频应用投放仍使用 casting | src/App/Windows/DeveloperToolsWindow.xaml.cs:46；src/App/Windows/DeveloperToolsWindow.xaml.cs:114 |
| App/DeveloperUpdateDescription | zh-HK: 版本資訊和發佈說明 | 统一香港繁体中文既有用语 | src/App/Windows/DeveloperToolsWindow.xaml.cs:74 |
| App/DeviceBindingBind | zh-CN: 绑定选择设备 | 优化自然表达和可读性 | src/App/Windows/DeviceBindingWindow.xaml:22；src/App/Windows/DeviceBindingWindow.xaml:23 |
| App/DeviceBindingBluetoothDescription | en-US: Click “Connect device” to temporarily advertise a Bluetooth HID service. On the iPhone/iPad, open Settings → Bluetooth and pair with this computer, then choose the HID device in the waiting window. Only the binding is saved; reverse control is not started.；zh-CN: 点击“连接设备”后，电脑会临时广播 Bluetooth HID 服务。请在 iPhone/iPad 的“设置”→“蓝牙”中选择此电脑完成配对，再点击等待窗口中的“下一步”选择 HID 设备。完成后只保存绑定，不会启动反控。 | 补齐英文遗漏的“下一步”操作；统一反向控制正式名称 | src/App/Windows/DeviceBindingWindow.xaml:24 |
| App/DeviceBindingBluetoothWaitingDescription | zh-CN: 请在 iPhone/iPad 打开“设置”→“蓝牙”，在设备列表中选择此电脑并完成配对。配对成功后返回这里，点击“下一步”选择刚刚连接的 HID 设备。此流程只保存设备绑定，不会启动蓝牙反控。 | 统一反向控制正式名称 | src/App/Windows/BluetoothConnectionWindow.xaml:8 |
| App/DeviceBindingBluetoothWaitingStatus | zh-CN: 等待设备订阅 HID 服务；zh-HK: 等待裝置訂閱 HID 服務；en-US: Waiting for device to subscribe to HID service | 优化自然表达和可读性 | src/App/Windows/BluetoothConnectionWindow.xaml:8 |
| App/DeviceBindingBound | en-US: Bound | 调用条件为身份为空；英文 Bound 与实际未绑定状态相反 | src/App/Windows/DeviceBindingWindow.xaml.cs:61；src/App/Windows/DeviceBindingWindow.xaml.cs:63；src/App/Windows/DeviceBindingWindow.xaml.cs:65 |
| App/DeviceBindingModelUnknown | zh-CN: 型号信息待获取；zh-HK: 型號資料待取得 | 未知信息不应暗示正在读取 | src/App/Windows/DeviceBindingWindow.xaml.cs:27 |
| App/DeviceBindingProfileDescription | zh-CN: 为此档案选择并管理三种连接身份。；zh-HK: 為此檔案選擇並管理三種連線身份。；en-US: Choose and manage the three connection identities for this profile. | 优化自然表达和可读性 | src/App/Windows/DeviceBindingWindow.xaml:21 |
| App/DeviceBindingRenameTitle | zh-CN: 重命名设备；zh-HK: 重新命名裝置 | 修改的是应用内档案名，不是实体设备名称 | src/App/Windows/DeviceBindingWindow.xaml.cs:127 |
| App/DeviceBindingSubtitle | zh-CN: 以真实设备档案管理 USB、AirPlay 和 Bluetooth 身份绑定。；zh-HK: 以真實裝置檔案管理 USB、AirPlay 和 Bluetooth 身份綁定。；en-US: Manage USB, AirPlay, and Bluetooth identities for real device profiles. | 优化自然表达和可读性 | src/App/Windows/DeviceBindingWindow.xaml:18 |
| App/DeviceCountFormat | en-US: {0} source(s) | 使用数量标签，适用于单数与复数 | src/App/ViewModels/MainViewModel.cs:738 |
| App/DeviceProfileGuidanceWiredBody | zh-HK: 偵測到新的有線 iPhone/iPad。為了讓有線投屏、無線投屏和反向控制始終對應同一台真實裝置，請現在建立裝置檔案。<br><br>請保持裝置解鎖並完成「信任此電腦」。點選「繼續」會開啟裝置綁定器，確認或管理此裝置檔案；點選「取消」亦可稍後從「反向控制」選單開啟。 | 统一香港繁体中文既有用语 | src/App/MainWindow.xaml.cs:6544 |
| App/DeviceProfileGuidanceWirelessBody | zh-HK: 偵測到新的 AirPlay 無線裝置。為了讓無線投屏能夠配對對應的有線裝置並啟用反向控制，請現在建立裝置檔案。<br><br>請確保手機和電腦處於同一區域網絡，並保持裝置名稱可識別。點選「繼續」會開啟裝置綁定器，選擇並綁定此 AirPlay 裝置；點選「取消」亦可稍後從「反向控制」選單開啟。 | 统一香港繁体中文既有用语 | src/App/MainWindow.xaml.cs:6543 |
| App/DeviceRefreshFailedFormat | en-US: $"device refresh failed: {AppLog.Error(error.Message)}" | 补齐面向用户的日志摘要；原始诊断详情保留 | src/App/ViewModels/MainViewModel.cs:3500 |
| App/DiagnosticsCleanedFormat | en-US: Cleanup complete: removed {0} files and freed {1}; {2} in-use or inaccessible files were skipped. | 用数量标签兼容 0、1 和多个文件 | src/App/Windows/AboutWindow.xaml.cs:214 |
| App/DisplayBoundsUnavailable | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/MainWindow.xaml.cs:6677 |
| App/DriverManagerActivated | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/DriverManagerLauncher.cs:35 |
| App/DriverManagerExecutableMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/DriverManagerLauncher.cs:28 |
| App/DriverManagerLaunchFailedFormat | zh-HK: 無法開啟驅動程式管理工具：{0} | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:5759 |
| App/DriverManagerOpened | zh-HK: 已開啟驅動程式管理工具 | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:5755 |
| App/DriverManagerOpenedAutomatically | zh-HK: 偵測到有線裝置驅動程式異常，已自動開啟驅動程式管理工具 | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:5754 |
| App/DriverManagerPathInvalid | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/DriverManagerLauncher.cs:32 |
| App/DriverManagerProcessStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/DriverManagerLauncher.cs:56 |
| App/DriverManagerStarted | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/DriverManagerLauncher.cs:57 |
| App/DriverPreflightFormat | en-US: $"driver preflight: {driverStatus.Diagnostic}" | 补齐面向用户的日志摘要；原始诊断详情保留 | src/App/ViewModels/MainViewModel.cs:5736 |
| App/DriverSafetyWarningFormat | en-US: $"driver safety warning: {driverStatus.Diagnostic}" | 补齐面向用户的日志摘要；原始诊断详情保留 | src/App/ViewModels/MainViewModel.cs:5722 |
| App/FfmpegAudioInputTimeout | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:263 |
| App/FfmpegAudioStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaCastAudioDecoder.cs:61 |
| App/FfmpegEncoderSizeUnsupported | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:203 |
| App/FfmpegEncoderUnavailable | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1045 |
| App/FfmpegExitedFormat | 原为代码硬编码；对应源码变更见工作区 diff | 输出错误详情迁入三语资源 | src/App/Services/MediaOutputService.cs:462；src/App/Services/MediaOutputService.cs:576 |
| App/FfmpegNoUsableEncoderFormat | 原为代码硬编码；对应源码变更见工作区 diff | 用户可见错误详情补齐三语 | src/App/Services/MediaOutputService.cs:939 |
| App/FfmpegNotFound | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:140 |
| App/FfmpegProbeFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:134 |
| App/FfmpegProtocolUnavailable | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1047 |
| App/FfmpegStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:241；src/App/Services/MediaOutputService.cs:1275 |
| App/FfmpegStartupExitedFormat | 原为代码硬编码；对应源码变更见工作区 diff | 输出错误详情迁入三语资源 | src/App/Services/MediaOutputService.cs:1110 |
| App/HlsRestartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/MainWindow.xaml.cs:3880 |
| App/ImageAdjustmentsBusy | en-US: Another projection setting is being applied. Try again when it finishes. | 投屏统一为 mirroring，视频应用投放仍使用 casting | src/App/ViewModels/MainViewModel.cs:4421；src/App/ViewModels/MainViewModel.cs:6090；src/App/ViewModels/MainViewModel.cs:6091；src/App/ViewModels/MainViewModel.cs:6156；src/App/ViewModels/MainViewModel.cs:6157；src/App/ViewModels/MainViewModel.cs:6274 |
| App/IndependentWindowWiredProjection | zh-CN: 有线投屏；zh-HK: 有線投屏；en-US: Wired projection | 菜单和快捷键实际调用控制功能，不是开始投屏 | src/App/Windows/NativePreviewWindow.cs:943 |
| App/IndependentWindowWirelessProjection | zh-CN: 无线投屏；zh-HK: 無線投屏；en-US: Wireless projection | 菜单和快捷键实际调用控制功能，不是开始投屏 | src/App/Windows/NativePreviewWindow.cs:949 |
| App/InstanceConflictHint | en-US: Closing the other window continues this launch. Closing this window leaves the active mirroring session untouched. | 优化自然表达和可读性 | src/App/Windows/InstanceConflictWindow.xaml:61 |
| App/LicenseInformation | zh-HK: 許可證資訊 | 统一香港繁体中文既有用语 | src/App/Windows/AboutWindow.xaml:92 |
| App/LocalTargetMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Windows/AboutWindow.xaml.cs:179 |
| App/MediaCastDeviceName | zh-HK: 影片 App AirPlay 播放 | 功能也支持 DLNA，不能仅标为 AirPlay | src/App/Models/DeviceViewModel.cs:45；src/App/Models/DeviceViewModel.cs:128 |
| App/MediaCastLoadingVideo | zh-CN: 正在加载投放的视频...；zh-HK: 正在載入投放的影片...；en-US: Loading the cast video... | 统一进行中状态的省略号 | src/App/MainWindow.xaml.cs:3068；src/App/MainWindow.xaml.cs:3371；src/App/MainWindow.xaml.cs:3465；src/App/MainWindow.xaml.cs:3567；src/App/MainWindow.xaml.cs:3651；src/App/MainWindow.xaml.cs:3750；src/App/MainWindow.xaml.cs:3889；src/App/MainWindow.xaml.cs:4969 |
| App/MediaCastPlayReceived | zh-HK: 已收到影片 App AirPlay 播放請求 | 功能也支持 DLNA，不能仅标为 AirPlay | src/App/MainWindow.xaml.cs:2847 |
| App/MediaCastReady | zh-HK: 影片 AirPlay 接收端已就緒 | 功能也支持 DLNA，不能仅标为 AirPlay | src/App/Interop/NativeCore.cs:720；src/App/Services/MediaCastReceiverController.cs:86 |
| App/MediaCastReceiverMissing | zh-CN: 视频投放组件缺失，请重新构建发布包。；zh-HK: 影片投放元件遺失，請重新建構發佈套件。；en-US: The video casting component is missing. Rebuild the release package. | 面向最终用户提供可执行的重新安装建议 | src/App/Interop/NativeCore.cs:721；src/App/Services/MediaCastReceiverController.cs:83 |
| App/MediaCastSpeedUnsupportedBody | zh-CN: 当前投屏视频不支持 {0} 倍速，已恢复到 1x 播放。；zh-HK: 目前投放影片不支援 {0} 倍速，已恢復至 1x 播放。 | 参数已包含 x，避免显示 2x 倍速 | src/App/MainWindow.xaml.cs:4841；src/App/MainWindow.xaml.cs:4848 |
| App/MediaCastStarting | zh-HK: 正在啟動影片 AirPlay 接收端...；zh-CN: 正在启动视频投放接收端...；en-US: Starting the video casting receiver... | 功能也支持 DLNA，不能仅标为 AirPlay；统一进行中状态的省略号 | src/App/Services/MediaCastReceiverController.cs:86 |
| App/MediaCastStopped | zh-HK: 影片 App AirPlay 播放已停止 | 功能也支持 DLNA，不能仅标为 AirPlay | src/App/Interop/NativeCore.cs:753；src/App/MainWindow.xaml.cs:2843；src/App/MainWindow.xaml.cs:2950 |
| App/MediaCastTitle | zh-HK: 影片 App AirPlay 播放 | 功能也支持 DLNA，不能仅标为 AirPlay | src/App/MainWindow.xaml:1987 |
| App/MediaCastWaitingVideo | zh-HK: 等待影片 App AirPlay 播放內容...；zh-CN: 等待视频 App 投放内容...；en-US: Waiting for a video app to cast content... | 功能也支持 DLNA，不能仅标为 AirPlay；统一进行中状态的省略号 | src/App/MainWindow.xaml:1431 |
| App/MediaCastWindowTitle | zh-HK: iPhoneMirror 影片 App AirPlay 播放 | 功能也支持 DLNA，不能仅标为 AirPlay | src/App/MainWindow.xaml.cs:6790 |
| App/MediaOutputAudioInvalid | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:645 |
| App/MediaOutputAudioStalled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:605；src/App/Services/MediaOutputService.cs:756 |
| App/MediaOutputAudioUnsupported | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:641 |
| App/MediaOutputChecking | zh-CN: 正在检测 FFmpeg 输出能力...；zh-HK: 正在偵測 FFmpeg 輸出能力...；en-US: Checking FFmpeg output capabilities... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:6291 |
| App/MediaOutputDestinationRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1054 |
| App/MediaOutputFrameInvalid | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:771 |
| App/MediaOutputFrameStalled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/VirtualCameraService.cs:472 |
| App/MediaOutputFrameTimeout | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:478；src/App/Services/VirtualCameraService.cs:466 |
| App/MediaOutputInvalidDimensions | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1050 |
| App/MediaOutputRtmpAddressRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1057 |
| App/MediaOutputSrtAddressRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1060 |
| App/MediaOutputStopping | zh-CN: 正在停止输出并完成文件或推流收尾...；zh-HK: 正在停止輸出並完成檔案或串流收尾...；en-US: Stopping output and finalizing the file or stream... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:6602 |
| App/MediaOutputWhipAddressRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/MediaOutputService.cs:1063 |
| App/NavSettingsDescription | en-US: Projection settings | 投屏统一为 mirroring，视频应用投放仍使用 casting | src/App/MainWindow.xaml:756 |
| App/ReadDeviceInfoFailed | zh-HK: 讀取裝置資訊失敗 | 统一香港繁体中文既有用语 | src/App/Interop/NativeCore.cs:688；src/App/Interop/NativeCore.cs:690 |
| App/RecordingFinalizeTimeout | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/MediaOutputService.cs:381 |
| App/ReverseControlBridgeNotReady | zh-CN: 当前设备的反控桥接器尚未就绪。；zh-HK: 目前裝置的反向控制橋接器尚未就緒。；en-US: The reverse-control bridge for the current device is not ready. | 统一反向控制正式名称；将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/UsbTouchBridgeHost.cs:117；src/App/ViewModels/MainViewModel.cs:1359 |
| App/ReverseControlCaptureMuxReady | zh-HK: 正在透過與投屏共存的 USB 通道連接裝置 | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2742 |
| App/ReverseControlCheckingEnvironmentFormat | zh-CN: 正在检查{0}反控的开发者环境；zh-HK: 正在檢查{0}反控的開發者環境 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2736 |
| App/ReverseControlConnectingWireless | zh-CN: 正在连接无线反控桥接器 | 统一反向控制正式名称 | src/App/ViewModels/MainViewModel.cs:2158；src/App/ViewModels/MainViewModel.cs:2169 |
| App/ReverseControlDetails | zh-HK: 查看詳細資訊 | 统一香港繁体中文既有用语 | 见 Key 所指文件或资源字典 |
| App/ReverseControlNoticeErrorBadge | zh-CN: 反控未能继续；zh-HK: 反控未能繼續 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/Windows/CaptureStatusNoticeWindow.xaml.cs:35 |
| App/ReverseControlUnknownError | zh-CN: 反控桥接器报告未知错误。；zh-HK: 反控橋接器報告未知錯誤。 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2779 |
| App/ReverseControlUsbConnected | zh-CN: USB 控制已连接（设备认证状态需以实测为准）；zh-HK: USB 控制已連接（裝置驗證狀態需以實測為準）；en-US: USB control connected (device authentication status should be verified in practice) | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2465；src/App/ViewModels/MainViewModel.cs:3004 |
| App/ReverseControlUsbConnecting | zh-CN: 正在连接 USB 控制；zh-HK: 正在連接 USB 控制；en-US: Connecting USB control | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2433；src/App/ViewModels/MainViewModel.cs:2574；src/App/ViewModels/MainViewModel.cs:2624；src/App/ViewModels/MainViewModel.cs:2959 |
| App/ReverseControlUsbEnabled | zh-CN: USB 控制已启用；zh-HK: USB 控制已啟用；en-US: USB control enabled | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2464；src/App/ViewModels/MainViewModel.cs:2591；src/App/ViewModels/MainViewModel.cs:3003 |
| App/ReverseControlUsbEnabledDirect | zh-CN: USB 控制已启用（直接 HID）；zh-HK: USB 控制已啟用（直接 HID）；en-US: USB control enabled (direct HID) | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2462；src/App/ViewModels/MainViewModel.cs:2591；src/App/ViewModels/MainViewModel.cs:3001 |
| App/ReverseControlUsbFailedFormat | zh-CN: USB 控制连接失败：{0}；zh-HK: USB 控制連線失敗：{0}；en-US: USB control connection failed: {0} | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2486；src/App/ViewModels/MainViewModel.cs:2607；src/App/ViewModels/MainViewModel.cs:2976；src/App/ViewModels/MainViewModel.cs:3023 |
| App/ReverseControlUsbOff | zh-CN: USB 控制未启用；zh-HK: USB 控制未啟用；en-US: USB control is off | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2882；src/App/ViewModels/MainViewModel.cs:2938 |
| App/ReverseControlUsbStopFailedFormat | zh-CN: USB 控制关闭失败：{0}；zh-HK: USB 控制關閉失敗：{0}；en-US: USB control shutdown failed: {0} | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2888 |
| App/ReverseControlUsbStopping | zh-CN: 正在关闭 USB 控制；zh-HK: 正在關閉 USB 控制；en-US: Stopping USB control | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:2871 |
| App/ReverseControlWirelessConnected | zh-CN: 无线反控已连接；zh-HK: 無線反向控制已連接；en-US: Wireless reverse control connected | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:2190 |
| App/ReverseControlWirelessDisconnected | zh-CN: 无线反控桥接通道已断开 | 统一反向控制正式名称 | src/App/ViewModels/MainViewModel.cs:2256 |
| App/ReverseControlWirelessEnabled | zh-CN: 无线反控已启用；zh-HK: 無線反向控制已啟用；en-US: Wireless reverse control enabled | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:2190；src/App/ViewModels/MainViewModel.cs:2332 |
| App/ReverseControlWirelessEnabledDirect | zh-CN: 无线反控已启用（直接 HID）；zh-HK: 無線反向控制已啟用（直接 HID）；en-US: Wireless reverse control enabled (direct HID) | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:2189；src/App/ViewModels/MainViewModel.cs:2331 |
| App/ReverseControlWirelessFailedFormat | zh-CN: 无线反控连接失败：{0}；zh-HK: 無線反向控制連線失敗：{0}；en-US: Wireless reverse-control connection failed: {0} | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:2206；src/App/ViewModels/MainViewModel.cs:2356 |
| App/ReverseControlWirelessOff | zh-CN: 无线反控未启用；zh-HK: 無線反向控制未啟用；en-US: Wireless reverse control is off | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:2289；src/App/ViewModels/MainViewModel.cs:2309；src/App/ViewModels/MainViewModel.cs:2391 |
| App/ReverseControlWirelessStopFailedFormat | zh-CN: 无线反控关闭失败：{0}；zh-HK: 無線反向控制關閉失敗：{0}；en-US: Wireless reverse-control shutdown failed: {0} | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:2396 |
| App/ShortcutSettingsReset | en-US: Restore default | 优化自然表达和可读性 | src/App/Windows/ShortcutSettingsWindow.xaml:32；src/App/Windows/ShortcutSettingsWindow.xaml:33 |
| App/ShortcutSettingsSaveFailed | en-US: Could not save the keyboard shortcut. | 优化自然表达和可读性 | src/App/MainWindow.xaml.cs:578 |
| App/ShortcutSettingsWiredControl | zh-CN: 有线投屏；zh-HK: 有線投屏；en-US: Wired mirroring | 菜单和快捷键实际调用控制功能，不是开始投屏 | src/App/Windows/ShortcutSettingsWindow.xaml.cs:224 |
| App/ShortcutSettingsWirelessControl | zh-CN: 无线投屏；zh-HK: 無線投屏；en-US: Wireless mirroring | 菜单和快捷键实际调用控制功能，不是开始投屏 | src/App/Windows/ShortcutSettingsWindow.xaml.cs:223 |
| App/StartBluetoothControl | zh-CN: 启用蓝牙反向控制；zh-HK: 啟用藍牙反向控制 | 状态及操作标签统一为蓝牙控制 | src/App/ViewModels/MainViewModel.cs:353 |
| App/StatusDefaultSettings | zh-HK: 預設 · 60 fps | Native 表示原始分辨率，不是默认设置 | src/App/ViewModels/MainViewModel.cs:191；src/App/ViewModels/MainViewModel.cs:1128；src/App/ViewModels/MainViewModel.cs:5966 |
| App/StopBluetoothControl | zh-CN: 关闭蓝牙反向控制；zh-HK: 關閉藍牙反向控制 | 状态及操作标签统一为蓝牙控制 | src/App/ViewModels/MainViewModel.cs:353 |
| App/StopSessionReleased | zh-HK: 螢幕鏡像已停止，會話資源已釋放 | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:4723 |
| App/StopUsbRestoreWarningFormat | zh-HK: 螢幕鏡像已停止，會話資源已釋放；但未能確認 iPhone 已還原普通 USB 設定。診斷：{0} | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:4724 |
| App/StreamingStopTimeout | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Services/MediaOutputService.cs:382 |
| App/TouchBridgeAlreadyStarted | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/UsbTouchBridgeHost.cs:43 |
| App/TouchBridgeAuthenticationRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:371 |
| App/TouchBridgeDiagnosticFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:603 |
| App/TouchBridgeErrorCodeFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:601 |
| App/TouchBridgeExitedFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:582 |
| App/TouchBridgeInvalidBatch | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:189 |
| App/TouchBridgeInvalidCoordinates | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:196 |
| App/TouchBridgeInvalidOutput | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:409 |
| App/TouchBridgeInvalidPointId | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:193 |
| App/TouchBridgeNotReady | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:186；src/App/Services/DirectUsbInputBridge.cs:203；src/App/Services/DirectUsbInputBridge.cs:429；src/App/Services/DirectUsbInputBridge.cs:442；src/App/Services/DirectUsbInputBridge.cs:465；src/App/Services/DirectUsbInputBridge.cs:473；src/App/Services/DirectUsbInputBridge.cs:497；src/App/Services/DirectUsbInputBridge.cs:503；src/App/Services/DirectUsbInputBridge.cs:523；src/App/Services/DirectUsbInputBridge.cs:529 |
| App/TouchBridgeNotStarted | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:415 |
| App/TouchBridgeOutputClosed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:318 |
| App/TouchBridgeReportedError | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:402 |
| App/TouchBridgeRuntimeIncompleteFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:78 |
| App/TouchBridgeStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/DirectUsbInputBridge.cs:136 |
| App/TouchBridgeTargetMismatch | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/UsbTouchBridgeHost.cs:54 |
| App/TouchBridgeTargetMismatchFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:352 |
| App/TouchBridgeTimeoutFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:421 |
| App/TouchBridgeTransportMismatchFormat | 原为代码硬编码；对应源码变更见工作区 diff | 桥接错误提示迁入三语资源；原始诊断参数保留 | src/App/Services/DirectUsbInputBridge.cs:359 |
| App/UpdateChecksumDownloadUnavailable | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:764 |
| App/UpdateChecksumEntryMissingFormat | 原为代码硬编码；对应源码变更见工作区 diff | 用户可见错误详情补齐三语 | src/App/Updater/GitHubReleaseClient.cs:704 |
| App/UpdateChecksumFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:710 |
| App/UpdateChecksumListInvalid | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:746 |
| App/UpdateChecksumListTooLarge | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:732；src/App/Updater/GitHubReleaseClient.cs:735 |
| App/UpdateChecksumRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:699 |
| App/UpdateChecksumSizeMismatch | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:738 |
| App/UpdateDigestInvalid | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:544 |
| App/UpdateDigestMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:163 |
| App/UpdateDownloadEndpointsUnavailable | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:465 |
| App/UpdateDownloadUntrustedRedirect | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:822 |
| App/UpdateDownloadedNoChecksum | zh-CN: 下载完成；此 Release 未提供 SHA256 校验值。；en-US: Download complete. This release did not provide a SHA256 value. | 统一校验算法显示名称 | src/App/Windows/UpdateWindow.xaml.cs:114 |
| App/UpdateEndpointsUnavailable | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:327 |
| App/UpdateFormatUnsupported | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:189；src/App/Updater/UpdateInstallerLauncher.cs:438 |
| App/UpdateHelperMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:521 |
| App/UpdateHelperStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:258 |
| App/UpdateInstallerPackageMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:398 |
| App/UpdatePackageChanged | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:552 |
| App/UpdatePackageNotVerified | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:160 |
| App/UpdatePackageTooLarge | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:408 |
| App/UpdatePortableDirectoryUnsafe | 原为代码硬编码；对应源码变更见工作区 diff | 更新启动失败提示补齐三语 | src/App/Updater/UpdateInstallerLauncher.cs:200 |
| App/UpdatePortableElevationUnsupported | 原为代码硬编码；对应源码变更见工作区 diff | 更新启动失败提示补齐三语 | src/App/Updater/UpdateInstallerLauncher.cs:194 |
| App/UpdatePortablePackageMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:399 |
| App/UpdatePortableRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:444 |
| App/UpdateReleaseFieldMissingFormat | 原为代码硬编码；对应源码变更见工作区 diff | 用户可见错误详情补齐三语 | src/App/Updater/ReleaseParser.cs:181 |
| App/UpdateReleaseListInvalid | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/ReleaseParser.cs:45 |
| App/UpdateReleaseListTooLarge | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:383；src/App/Updater/GitHubReleaseClient.cs:385 |
| App/UpdateResponseUrlMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:819 |
| App/UpdateSetupRequired | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/UpdateInstallerLauncher.cs:441 |
| App/UpdateUnsafeFileName | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:406 |
| App/UpdateUntrustedAssetUrl | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:472 |
| App/UpdateUntrustedNotesRedirect | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:345 |
| App/UpdateUntrustedRedirect | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/App/Updater/GitHubReleaseClient.cs:380 |
| App/UpdateVerified | zh-CN: 下载完成，SHA256 校验通过。；en-US: Download complete. SHA256 verification passed. | 统一校验算法显示名称 | src/App/Windows/UpdateWindow.xaml.cs:113 |
| App/UsbControlDisable | zh-CN: 关闭 USB 控制；zh-HK: 關閉 USB 控制；en-US: Disable USB control | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:384 |
| App/UsbControlDisableWireless | zh-CN: 关闭无线反控；zh-HK: 關閉無線反向控制；en-US: Disable wireless reverse control | 状态及操作标签统一为无线控制 | src/App/ViewModels/MainViewModel.cs:384 |
| App/UsbControlFailureDeviceNotFound | en-US: The Apple network-pairing session for this device was not found. Connect by cable once, enable “Sync with this iPhone over Wi-Fi” in Apple Devices or iTunes, and try again. | 补齐英文缺少的保持解锁、与电脑位于同一局域网条件 | src/App/ViewModels/MainViewModel.cs:2717 |
| App/UsbControlFailureGateUnavailable | zh-CN: 设备未确认 CoreDevice 触控认证已开启。为避免输入被系统静默丢弃，反控未启动。；zh-HK: 裝置未確認 CoreDevice 觸控驗證已開啟。為避免輸入被系統靜默丟棄，反控未啟動。 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2704 |
| App/UsbControlFailureTouchService | zh-CN: 设备暂未提供触控反控服务。请保持设备解锁并信任此电脑后重试；若仍失败，请改用蓝牙反控或无线反控。；zh-HK: 裝置暫未提供觸控反控服務。請保持裝置解鎖並信任此電腦後重試；若仍失敗，請改用藍牙反控或無線反控。 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2711 |
| App/UsbControlFailureUnknown | zh-CN: USB 反控桥接器返回了无法识别的错误。请查看诊断日志后重试。 | 统一反向控制正式名称 | src/App/ViewModels/MainViewModel.cs:2726 |
| App/UsbControlFailureUnsupportedIos | zh-CN: 设备拒绝了媒体流认证（9021），且没有可用的直接 Universal HID 触控通道。请重启 iPhone 后重试；若仍失败，请使用蓝牙反控。 | 统一反向控制正式名称 | src/App/ViewModels/MainViewModel.cs:2689 |
| App/UsbControlFailureWiredDeviceNotFound | zh-HK: 未能在 USB 連線中找到此裝置的控制通道。投屏運行時系統可能暫時無法存取裝置：請先停止投屏再啟動反向控制，或重新插拔數據線、解鎖手機並確認已信任此電腦後重試。 | 统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2718 |
| App/UsbControlFailureWirelessPairingRequired | zh-CN: 当前 Windows 帐户尚未完成此设备的无线 CoreDevice 配对。请先通过 USB 连接并解锁 iPhone，完成一次 USB 反控初始化后再试无线反控。；zh-HK: 目前 Windows 帳戶尚未完成此裝置的無線 CoreDevice 配對。請先透過 USB 連接並解鎖 iPhone，完成一次 USB 反控初始化後再試無線反控。 | 统一反向控制正式名称；统一香港繁体中文既有用语 | src/App/ViewModels/MainViewModel.cs:2695 |
| App/UsbControlOff | zh-CN: USB 控制未启用；zh-HK: USB 控制未啟用；en-US: USB control is off | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:1133 |
| App/UsbControlOperationFailedFormat | zh-CN: USB 控制操作失败：{0}；zh-HK: USB 控制操作失敗：{0}；en-US: USB control operation failed: {0} | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/MainWindow.xaml.cs:1314；src/App/MainWindow.xaml.cs:5492 |
| App/UsbControlPrerequisite | zh-CN: 请通过 USB 连接并在设备上信任一台 iPhone 或 iPad 后，再启用 USB 控制；zh-HK: 請透過 USB 連接並在裝置上信任一部 iPhone 或 iPad 後，再啟用 USB 控制；en-US: Connect an iPhone or iPad by USB and trust this computer before enabling USB control | 信任对象是电脑，不是 iPhone；同时统一有线控制名称 | src/App/ViewModels/MainViewModel.cs:361 |
| App/UsbControlRetry | zh-CN: 重试 USB 控制；zh-HK: 重試 USB 控制；en-US: Retry USB control | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:383 |
| App/UsbControlStopping | zh-CN: 正在关闭 USB 控制；zh-HK: 正在關閉 USB 控制；en-US: Stopping USB control | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/ViewModels/MainViewModel.cs:381 |
| App/UsbControlTitle | zh-CN: USB 控制；zh-HK: USB 控制；en-US: USB control | 相同功能统一为有线控制；USB 作为连接协议的说明予以保留 | src/App/MainWindow.xaml.cs:5494 |
| App/UsbModeAirPlayLabel | zh-CN: B AirPlay(实验) | 优化自然表达和可读性 | src/App/ViewModels/MainViewModel.cs:301 |
| App/UsbModeAirPlayNotice | zh-HK: 需要自訂時，連續按一下右下角版本號 5 次開啟進階模式。自訂 HPD1 尺寸存在風險，錯誤參數可能導致黑畫面、裁切或 USB 重新連接失敗。 | 优化自然表达和可读性 | src/App/ViewModels/MainViewModel.cs:302 |
| App/UsbModeDemoLabel | zh-CN: A 演示模式(推荐) | 优化自然表达和可读性 | src/App/ViewModels/MainViewModel.cs:299 |
| App/UsbModeDetailsTitle | en-US: USB projection mode details | 投屏统一为 mirroring，视频应用投放仍使用 casting | src/App/Windows/UsbProjectionModeInfoWindow.xaml:6；src/App/Windows/UsbProjectionModeInfoWindow.xaml:25 |
| App/UsbProjectionModeRestarting | zh-CN: 正在按新模式重新连接当前有线设备...；zh-HK: 正在按新模式重新連接目前有線裝置...；en-US: Reconnecting the current USB device with the new mode... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:945 |
| App/UsbProjectionModeTitle | en-US: USB projection protocol | 投屏统一为 mirroring，视频应用投放仍使用 casting | src/App/MainWindow.xaml:1683 |
| App/VideoPipelineRestarting | zh-CN: 正在按新的视频管线设置重新连接当前设备...；zh-HK: 正在按新的影片管線設定重新連接目前裝置...；en-US: Reconnecting the current device with the new video pipeline... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:4625 |
| App/VideoPreferencesApplied | en-US: Local rendering settings applied (source stream unchanged) | 未重连与码流未改变不是同一含义 | src/App/Interop/NativeCore.cs:954；src/App/Interop/NativeCore.cs:967；src/App/Interop/NativeCore.cs:1069；src/App/ViewModels/MainViewModel.cs:4336 |
| App/VirtualCameraAlreadyRunning | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/VirtualCameraService.cs:376 |
| App/VirtualCameraChecking | zh-CN: 正在检测虚拟摄像头能力...；zh-HK: 正在偵測虛擬攝影機能力...；en-US: Checking virtual camera support... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:1131 |
| App/VirtualCameraInstallCancelled | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/VirtualCameraService.cs:317 |
| App/VirtualCameraInstallerExitedFormat | 原为代码硬编码；对应源码变更见工作区 diff | 输出错误详情迁入三语资源 | src/App/Services/VirtualCameraService.cs:312 |
| App/VirtualCameraInstallerStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/VirtualCameraService.cs:284 |
| App/VirtualCameraInstalling | zh-CN: 正在安装虚拟摄像头组件...；zh-HK: 正在安裝虛擬攝影機元件...；en-US: Installing the virtual camera component... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:6429 |
| App/VirtualCameraPayloadChangedFormat | 原为代码硬编码；对应源码变更见工作区 diff | 输出错误详情迁入三语资源 | src/App/Services/VirtualCameraService.cs:363 |
| App/VirtualCameraPayloadMissing | 原为代码硬编码；对应源码变更见工作区 diff | 将代码中的用户可见硬编码文字迁入三语资源 | src/App/Services/VirtualCameraService.cs:346 |
| App/VirtualCameraUninstalling | zh-CN: 正在卸载虚拟摄像头组件...；zh-HK: 正在解除安裝虛擬攝影機元件...；en-US: Uninstalling the virtual camera component... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:6468 |
| App/VirtualCameraUpdating | zh-CN: 正在更新虚拟摄像头组件...；zh-HK: 正在更新虛擬攝影機元件...；en-US: Updating the virtual camera component... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:6429 |
| App/WirelessBackendUnavailableFormat | zh-CN: {0} 无线接收组件缺失，请重新构建发布包。；zh-HK: {0} 無線接收元件遺失，請重新建構發佈套件。；en-US: The {0} wireless receiver component is missing. Rebuild the release package. | 面向最终用户提供可执行的重新安装建议 | src/App/Services/WirelessReceiverController.cs:162；src/App/ViewModels/MainViewModel.cs:3690 |
| App/WirelessConnecting | zh-CN: AirPlay 设备正在连接...；zh-HK: AirPlay 裝置正在連接...；en-US: An AirPlay device is connecting... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:5783 |
| App/WirelessControlOperationFailedFormat | zh-CN: 无线反控操作失败：{0}；zh-HK: 無線反向控制操作失敗：{0}；en-US: Wireless reverse-control operation failed: {0} | 状态及操作标签统一为无线控制 | src/App/MainWindow.xaml.cs:1335；src/App/MainWindow.xaml.cs:5511 |
| App/WirelessProfileDisconnectConfirmFormat | en-US: {0} wireless device(s) are connected. Applying “{1}” will disconnect all wireless mirroring and restart the receiver. Continue? | 用数量标签兼容单复数 | 见 Key 所指文件或资源字典 |
| App/WirelessReceiverMissing | zh-CN: 无线接收组件缺失，请重新构建发布包。；zh-HK: 無線接收元件遺失，請重新建構發佈套件。；en-US: The wireless receiver component is missing. Rebuild the release package. | 面向最终用户提供可执行的重新安装建议 | src/App/Interop/NativeCore.cs:704 |
| App/WirelessSettingsConnectedImpactFormat | en-US: {0} wireless device(s) are connected and will all be disconnected. | 消除 device(s) 表达并保留应用后断开的条件 | src/App/ViewModels/MainViewModel.cs:3722 |
| App/WirelessStarting | zh-CN: 正在启动 AirPlay 接收端...；en-US: Starting the AirPlay receiver... | 统一进行中状态的省略号 | src/App/Services/WirelessReceiverController.cs:166；src/App/ViewModels/MainViewModel.cs:5781 |
| App/WirelessStopping | zh-CN: 正在停止 AirPlay 接收端...；zh-HK: 正在停止 AirPlay 接收端...；en-US: Stopping the AirPlay receiver... | 统一进行中状态的省略号 | src/App/ViewModels/MainViewModel.cs:5785 |
| Cleanup/AssociatedDrivers | 原始文字: 关联全部驱动包：{0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:77；scripts/remove_selected_iphone_drivers.ps1:167；scripts/remove_selected_iphone_drivers.ps1:257；scripts/remove_selected_iphone_drivers.ps1:2029 |
| Cleanup/AssociatedNodes | 原始文字: 关联 PnP 节点：{0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:76；scripts/remove_selected_iphone_drivers.ps1:166；scripts/remove_selected_iphone_drivers.ps1:256；scripts/remove_selected_iphone_drivers.ps1:2024 |
| Cleanup/BluetoothExcluded | 原始文字: 安全过滤 BTHLE：$InstanceId | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:41；scripts/remove_selected_iphone_drivers.ps1:131；scripts/remove_selected_iphone_drivers.ps1:221；scripts/remove_selected_iphone_drivers.ps1:1538 |
| Cleanup/BluetoothNotListed | 原始文字: BTHLE / Bluetooth LE 设备不会显示。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:64；scripts/remove_selected_iphone_drivers.ps1:154；scripts/remove_selected_iphone_drivers.ps1:244；scripts/remove_selected_iphone_drivers.ps1:1805 |
| Cleanup/CheckRequirements | 原始文字: 请确认： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:59；scripts/remove_selected_iphone_drivers.ps1:149；scripts/remove_selected_iphone_drivers.ps1:239；scripts/remove_selected_iphone_drivers.ps1:1799 |
| Cleanup/CleanupPlan | 原始文字:  清理计划 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:73；scripts/remove_selected_iphone_drivers.ps1:163；scripts/remove_selected_iphone_drivers.ps1:253；scripts/remove_selected_iphone_drivers.ps1:2006 |
| Cleanup/CleanupResults | 原始文字:  清理结果 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:89；scripts/remove_selected_iphone_drivers.ps1:179；scripts/remove_selected_iphone_drivers.ps1:269；scripts/remove_selected_iphone_drivers.ps1:2341 |
| Cleanup/ClosingProcesses | 原始文字: 关闭 iPhoneMirror 相关进程... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:40；scripts/remove_selected_iphone_drivers.ps1:130；scripts/remove_selected_iphone_drivers.ps1:220；scripts/remove_selected_iphone_drivers.ps1:1508 |
| Cleanup/Completed | 原始文字:  Cleanup completed successfully. | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:103；scripts/remove_selected_iphone_drivers.ps1:193；scripts/remove_selected_iphone_drivers.ps1:283；scripts/remove_selected_iphone_drivers.ps1:2408 |
| Cleanup/CompletedWithErrors | 原始文字:  Cleanup finished with errors. Count: {0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:104；scripts/remove_selected_iphone_drivers.ps1:194；scripts/remove_selected_iphone_drivers.ps1:284；scripts/remove_selected_iphone_drivers.ps1:2434 |
| Cleanup/Confirm | 原始文字: 请输入 {0} 确认： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:81；scripts/remove_selected_iphone_drivers.ps1:171；scripts/remove_selected_iphone_drivers.ps1:261；scripts/remove_selected_iphone_drivers.ps1:2110 |
| Cleanup/ConfirmationMismatch | 原始文字: 确认文字不匹配，未做任何修改。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:82；scripts/remove_selected_iphone_drivers.ps1:172；scripts/remove_selected_iphone_drivers.ps1:262；scripts/remove_selected_iphone_drivers.ps1:2119 |
| Cleanup/DetectedDevices | 原始文字: 检测到以下物理 Apple 设备： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:67；scripts/remove_selected_iphone_drivers.ps1:157；scripts/remove_selected_iphone_drivers.ps1:247；scripts/remove_selected_iphone_drivers.ps1:1862 |
| Cleanup/DeviceNode | 原始文字: 设备节点：$InstanceId | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:42；scripts/remove_selected_iphone_drivers.ps1:132；scripts/remove_selected_iphone_drivers.ps1:222；scripts/remove_selected_iphone_drivers.ps1:1555 |
| Cleanup/DeviceNodeFailed | 原始文字: 设备节点删除失败：$InstanceId | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:45；scripts/remove_selected_iphone_drivers.ps1:135；scripts/remove_selected_iphone_drivers.ps1:225；scripts/remove_selected_iphone_drivers.ps1:1585 |
| Cleanup/DeviceNodeFailedDetail | 原始文字: 设备节点删除失败：$InstanceId  | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:44；scripts/remove_selected_iphone_drivers.ps1:134；scripts/remove_selected_iphone_drivers.ps1:224；scripts/remove_selected_iphone_drivers.ps1:1574 |
| Cleanup/DeviceNodeRestart | 原始文字: 设备节点已移除，重启后完成：$InstanceId | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:43；scripts/remove_selected_iphone_drivers.ps1:133；scripts/remove_selected_iphone_drivers.ps1:223；scripts/remove_selected_iphone_drivers.ps1:1567 |
| Cleanup/DriverEnumerationFailed | 原始文字: pnputil Driver Store 枚举失败，ExitCode=$($result.ExitCode)； | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:32；scripts/remove_selected_iphone_drivers.ps1:122；scripts/remove_selected_iphone_drivers.ps1:212；scripts/remove_selected_iphone_drivers.ps1:1265 |
| Cleanup/DriverIndexReady | 原始文字: Driver Store 索引完成：$($script:DriverInventory.Count) 个 OEM INF | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:39；scripts/remove_selected_iphone_drivers.ps1:129；scripts/remove_selected_iphone_drivers.ps1:219；scripts/remove_selected_iphone_drivers.ps1:1380 |
| Cleanup/DriverNodesMissing | 原始文字: Driver Store XML 中没有 Driver 节点，已停止清理以避免遗漏驱动包。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:38；scripts/remove_selected_iphone_drivers.ps1:128；scripts/remove_selected_iphone_drivers.ps1:218；scripts/remove_selected_iphone_drivers.ps1:1305 |
| Cleanup/DriverPackage | 原始文字: 驱动包：$InfName | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:46；scripts/remove_selected_iphone_drivers.ps1:136；scripts/remove_selected_iphone_drivers.ps1:226；scripts/remove_selected_iphone_drivers.ps1:1619 |
| Cleanup/DriverPackageFailed | 原始文字: 驱动包删除失败：$InfName | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:49；scripts/remove_selected_iphone_drivers.ps1:139；scripts/remove_selected_iphone_drivers.ps1:229；scripts/remove_selected_iphone_drivers.ps1:1649 |
| Cleanup/DriverPackageFailedDetail | 原始文字: 驱动包删除失败：$InfName  | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:48；scripts/remove_selected_iphone_drivers.ps1:138；scripts/remove_selected_iphone_drivers.ps1:228；scripts/remove_selected_iphone_drivers.ps1:1638 |
| Cleanup/DriverPackageRestart | 原始文字: 驱动包已删除，重启后完成：$InfName | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:47；scripts/remove_selected_iphone_drivers.ps1:137；scripts/remove_selected_iphone_drivers.ps1:227；scripts/remove_selected_iphone_drivers.ps1:1631 |
| Cleanup/DriverStoreCount | 原始文字:     Driver Store 驱动包：{0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:69；scripts/remove_selected_iphone_drivers.ps1:159；scripts/remove_selected_iphone_drivers.ps1:249；scripts/remove_selected_iphone_drivers.ps1:1884 |
| Cleanup/DriverXmlEmpty | 原始文字: Driver Store XML 为空。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:34；scripts/remove_selected_iphone_drivers.ps1:124；scripts/remove_selected_iphone_drivers.ps1:214；scripts/remove_selected_iphone_drivers.ps1:1275 |
| Cleanup/DriverXmlEmptyStopped | 原始文字: Driver Store XML 为空，已停止清理以避免遗漏驱动包。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:35；scripts/remove_selected_iphone_drivers.ps1:125；scripts/remove_selected_iphone_drivers.ps1:215；scripts/remove_selected_iphone_drivers.ps1:1277 |
| Cleanup/DriverXmlInvalid | 原始文字: Driver Store XML 解析失败： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:36；scripts/remove_selected_iphone_drivers.ps1:126；scripts/remove_selected_iphone_drivers.ps1:216；scripts/remove_selected_iphone_drivers.ps1:1288 |
| Cleanup/DriverXmlInvalidStopped | 原始文字: Driver Store XML 解析失败，已停止清理： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:37；scripts/remove_selected_iphone_drivers.ps1:127；scripts/remove_selected_iphone_drivers.ps1:217；scripts/remove_selected_iphone_drivers.ps1:1293 |
| Cleanup/DriverXmlUnavailable | 原始文字: 无法使用 Driver Store XML，ExitCode=$($result.ExitCode) | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:31；scripts/remove_selected_iphone_drivers.ps1:121；scripts/remove_selected_iphone_drivers.ps1:211；scripts/remove_selected_iphone_drivers.ps1:1261 |
| Cleanup/Error | 原始文字: 错误：{0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:98；scripts/remove_selected_iphone_drivers.ps1:188；scripts/remove_selected_iphone_drivers.ps1:278；scripts/remove_selected_iphone_drivers.ps1:2488 |
| Cleanup/ErrorLog | 原始文字: 错误日志：$errorLog | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:101；scripts/remove_selected_iphone_drivers.ps1:191；scripts/remove_selected_iphone_drivers.ps1:281；scripts/remove_selected_iphone_drivers.ps1:2564 |
| Cleanup/FatalError | 原始文字: iPhoneMirror Driver Cleanup Fatal Error | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:106；scripts/remove_selected_iphone_drivers.ps1:196；scripts/remove_selected_iphone_drivers.ps1:286；scripts/remove_selected_iphone_drivers.ps1:2548 |
| Cleanup/FinalDeviceCheck | 原始文字: 执行删除前最终设备确认... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:83；scripts/remove_selected_iphone_drivers.ps1:173；scripts/remove_selected_iphone_drivers.ps1:263；scripts/remove_selected_iphone_drivers.ps1:2128 |
| Cleanup/FinalVerification | 原始文字: 执行最终验证... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:88；scripts/remove_selected_iphone_drivers.ps1:178；scripts/remove_selected_iphone_drivers.ps1:268；scripts/remove_selected_iphone_drivers.ps1:2289 |
| Cleanup/IndexDriverStore | 原始文字: 建立 Driver Store 驱动索引... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:30；scripts/remove_selected_iphone_drivers.ps1:120；scripts/remove_selected_iphone_drivers.ps1:210；scripts/remove_selected_iphone_drivers.ps1:1248 |
| Cleanup/InternalError | 原始文字:  CLEANUP INTERNAL ERROR | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:105；scripts/remove_selected_iphone_drivers.ps1:195；scripts/remove_selected_iphone_drivers.ps1:285；scripts/remove_selected_iphone_drivers.ps1:2479 |
| Cleanup/InvalidDeviceNumber | 原始文字: 设备序号无效。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:72；scripts/remove_selected_iphone_drivers.ps1:162；scripts/remove_selected_iphone_drivers.ps1:252；scripts/remove_selected_iphone_drivers.ps1:1937 |
| Cleanup/Irreversible | 原始文字: 这是不可撤销的操作。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:80；scripts/remove_selected_iphone_drivers.ps1:170；scripts/remove_selected_iphone_drivers.ps1:260；scripts/remove_selected_iphone_drivers.ps1:2106 |
| Cleanup/ListOnly | 原始文字: 仅列表模式，未修改系统。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:70；scripts/remove_selected_iphone_drivers.ps1:160；scripts/remove_selected_iphone_drivers.ps1:250；scripts/remove_selected_iphone_drivers.ps1:1901 |
| Cleanup/Location | 原始文字: 位置： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:99；scripts/remove_selected_iphone_drivers.ps1:189；scripts/remove_selected_iphone_drivers.ps1:279；scripts/remove_selected_iphone_drivers.ps1:2500 |
| Cleanup/LogPath | 原始文字: 日志：$logPath | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:97；scripts/remove_selected_iphone_drivers.ps1:187；scripts/remove_selected_iphone_drivers.ps1:277；scripts/remove_selected_iphone_drivers.ps1:2424；scripts/remove_selected_iphone_drivers.ps1:2450 |
| Cleanup/ManifestWriteFailed | 原始文字: 无法写入 manifest： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:50；scripts/remove_selected_iphone_drivers.ps1:140；scripts/remove_selected_iphone_drivers.ps1:230；scripts/remove_selected_iphone_drivers.ps1:1717 |
| Cleanup/MappingDevices | 原始文字: 建立 Apple 设备关系... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:56；scripts/remove_selected_iphone_drivers.ps1:146；scripts/remove_selected_iphone_drivers.ps1:236；scripts/remove_selected_iphone_drivers.ps1:1785 |
| Cleanup/MappingDrivers | 原始文字: 建立驱动关系... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:65；scripts/remove_selected_iphone_drivers.ps1:155；scripts/remove_selected_iphone_drivers.ps1:245；scripts/remove_selected_iphone_drivers.ps1:1815 |
| Cleanup/MappingReady | 原始文字: 设备关系建立完成。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:66；scripts/remove_selected_iphone_drivers.ps1:156；scripts/remove_selected_iphone_drivers.ps1:246；scripts/remove_selected_iphone_drivers.ps1:1855 |
| Cleanup/NoAppleDevice | 原始文字: 没有找到当前连接的 iPhone/iPad。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:58；scripts/remove_selected_iphone_drivers.ps1:148；scripts/remove_selected_iphone_drivers.ps1:238；scripts/remove_selected_iphone_drivers.ps1:1797 |
| Cleanup/NoAvailablePnp | 原始文字: pnputil PnP XML 中没有可用设备。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:28；scripts/remove_selected_iphone_drivers.ps1:118；scripts/remove_selected_iphone_drivers.ps1:208；scripts/remove_selected_iphone_drivers.ps1:901 |
| Cleanup/NoCachedPnp | 原始文字: pnputil PnP 缓存完成：0 个设备 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:27；scripts/remove_selected_iphone_drivers.ps1:117；scripts/remove_selected_iphone_drivers.ps1:207；scripts/remove_selected_iphone_drivers.ps1:865 |
| Cleanup/NoConnectedPnp | 原始文字: pnputil PnP XML 中没有当前连接的设备。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:26；scripts/remove_selected_iphone_drivers.ps1:116；scripts/remove_selected_iphone_drivers.ps1:206；scripts/remove_selected_iphone_drivers.ps1:864 |
| Cleanup/NoRemovableNodes | 原始文字: 没有可删除的目标 PnP 节点。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:79；scripts/remove_selected_iphone_drivers.ps1:169；scripts/remove_selected_iphone_drivers.ps1:259；scripts/remove_selected_iphone_drivers.ps1:2086 |
| Cleanup/NodesRemoved | 原始文字: 目标 PnP 节点已清理。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:90；scripts/remove_selected_iphone_drivers.ps1:180；scripts/remove_selected_iphone_drivers.ps1:270；scripts/remove_selected_iphone_drivers.ps1:2351 |
| Cleanup/OnePhysicalDevice | 原始文字: 物理设备：1 台 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:75；scripts/remove_selected_iphone_drivers.ps1:165；scripts/remove_selected_iphone_drivers.ps1:255；scripts/remove_selected_iphone_drivers.ps1:2020 |
| Cleanup/PackagesHandled | 原始文字: 目标 Driver Store 驱动包已处理。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:93；scripts/remove_selected_iphone_drivers.ps1:183；scripts/remove_selected_iphone_drivers.ps1:273；scripts/remove_selected_iphone_drivers.ps1:2377 |
| Cleanup/Pause | 原始文字: 按 Enter 键关闭窗口 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:19；scripts/remove_selected_iphone_drivers.ps1:109；scripts/remove_selected_iphone_drivers.ps1:199；scripts/remove_selected_iphone_drivers.ps1:467 |
| Cleanup/PhysicalDeviceCount | 原始文字: Apple 物理设备分组完成：$($physicalDevices.Count) 台 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:57；scripts/remove_selected_iphone_drivers.ps1:147；scripts/remove_selected_iphone_drivers.ps1:237；scripts/remove_selected_iphone_drivers.ps1:1791 |
| Cleanup/PnpCached | 原始文字: PnP 缓存完成：$($script:DeviceCache.Count) 个设备 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:21；scripts/remove_selected_iphone_drivers.ps1:111；scripts/remove_selected_iphone_drivers.ps1:201；scripts/remove_selected_iphone_drivers.ps1:812 |
| Cleanup/PnpEnumerationFailed | 原始文字: 无法枚举 PnP 设备，pnputil ExitCode=$($result.ExitCode) | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:23；scripts/remove_selected_iphone_drivers.ps1:113；scripts/remove_selected_iphone_drivers.ps1:203；scripts/remove_selected_iphone_drivers.ps1:842 |
| Cleanup/PnpFallback | 原始文字: Get-PnpDevice 扫描失败，切换到 pnputil： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:22；scripts/remove_selected_iphone_drivers.ps1:112；scripts/remove_selected_iphone_drivers.ps1:202；scripts/remove_selected_iphone_drivers.ps1:820 |
| Cleanup/PnpNodeCount | 原始文字:     PnP 节点：{0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:68；scripts/remove_selected_iphone_drivers.ps1:158；scripts/remove_selected_iphone_drivers.ps1:248；scripts/remove_selected_iphone_drivers.ps1:1879 |
| Cleanup/PnpUtilCached | 原始文字: pnputil PnP 缓存完成：$($script:DeviceCache.Count) 个设备 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:29；scripts/remove_selected_iphone_drivers.ps1:119；scripts/remove_selected_iphone_drivers.ps1:209；scripts/remove_selected_iphone_drivers.ps1:905 |
| Cleanup/PnpUtilMissing | 原始文字: 找不到 pnputil.exe：$PnpUtil | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:52；scripts/remove_selected_iphone_drivers.ps1:142；scripts/remove_selected_iphone_drivers.ps1:232；scripts/remove_selected_iphone_drivers.ps1:1740 |
| Cleanup/PnpXmlEmpty | 原始文字: pnputil PnP XML 为空，无法枚举设备。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:24；scripts/remove_selected_iphone_drivers.ps1:114；scripts/remove_selected_iphone_drivers.ps1:204；scripts/remove_selected_iphone_drivers.ps1:847 |
| Cleanup/PnpXmlInvalid | 原始文字: pnputil PnP XML 解析失败： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:25；scripts/remove_selected_iphone_drivers.ps1:115；scripts/remove_selected_iphone_drivers.ps1:205；scripts/remove_selected_iphone_drivers.ps1:855 |
| Cleanup/PreviewOnly | 原始文字:  Preview only - 未修改系统 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:78；scripts/remove_selected_iphone_drivers.ps1:168；scripts/remove_selected_iphone_drivers.ps1:258；scripts/remove_selected_iphone_drivers.ps1:2071 |
| Cleanup/ProtectedLaunchRequired | 原始文字: 请通过 iPhoneMirror.Driver.exe 或发布包中的清理入口运行此工具，以获得受保护的管理员权限。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:51；scripts/remove_selected_iphone_drivers.ps1:141；scripts/remove_selected_iphone_drivers.ps1:231；scripts/remove_selected_iphone_drivers.ps1:1732 |
| Cleanup/ReinstallAdvice | 原始文字: 完成后可重新安装 Apple Devices 或 iTunes 以恢复所需驱动。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:54；scripts/remove_selected_iphone_drivers.ps1:144；scripts/remove_selected_iphone_drivers.ps1:234；scripts/remove_selected_iphone_drivers.ps1:1771 |
| Cleanup/RemainingNodes | 原始文字: 仍存在 $($remainingNodes.Count) 个目标节点。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:92；scripts/remove_selected_iphone_drivers.ps1:182；scripts/remove_selected_iphone_drivers.ps1:272；scripts/remove_selected_iphone_drivers.ps1:2364 |
| Cleanup/RemainingPackages | 原始文字: 仍存在 $($remainingDrivers.Count) 个驱动包。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:95；scripts/remove_selected_iphone_drivers.ps1:185；scripts/remove_selected_iphone_drivers.ps1:275；scripts/remove_selected_iphone_drivers.ps1:2390 |
| Cleanup/RemovingNodes | 原始文字:  卸载设备节点 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:85；scripts/remove_selected_iphone_drivers.ps1:175；scripts/remove_selected_iphone_drivers.ps1:265；scripts/remove_selected_iphone_drivers.ps1:2205 |
| Cleanup/RemovingPackages | 原始文字:  删除 Driver Store 驱动包 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:86；scripts/remove_selected_iphone_drivers.ps1:176；scripts/remove_selected_iphone_drivers.ps1:266；scripts/remove_selected_iphone_drivers.ps1:2229 |
| Cleanup/RequirementCable | 原始文字:   4. 数据线支持数据传输 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:63；scripts/remove_selected_iphone_drivers.ps1:153；scripts/remove_selected_iphone_drivers.ps1:243；scripts/remove_selected_iphone_drivers.ps1:1803 |
| Cleanup/RequirementTrusted | 原始文字:   3. 已点击“信任此电脑” | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:62；scripts/remove_selected_iphone_drivers.ps1:152；scripts/remove_selected_iphone_drivers.ps1:242；scripts/remove_selected_iphone_drivers.ps1:1802 |
| Cleanup/RequirementUnlocked | 原始文字:   2. 设备已解锁 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:61；scripts/remove_selected_iphone_drivers.ps1:151；scripts/remove_selected_iphone_drivers.ps1:241；scripts/remove_selected_iphone_drivers.ps1:1801 |
| Cleanup/RequirementUsb | 原始文字:   1. iPhone/iPad 已通过 USB 连接 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:60；scripts/remove_selected_iphone_drivers.ps1:150；scripts/remove_selected_iphone_drivers.ps1:240；scripts/remove_selected_iphone_drivers.ps1:1800 |
| Cleanup/RestartRequired | 原始文字: Windows 报告部分操作需要重启。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:96；scripts/remove_selected_iphone_drivers.ps1:186；scripts/remove_selected_iphone_drivers.ps1:276；scripts/remove_selected_iphone_drivers.ps1:2418 |
| Cleanup/ScanPnp | 原始文字: 扫描当前 PnP 设备... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:20；scripts/remove_selected_iphone_drivers.ps1:110；scripts/remove_selected_iphone_drivers.ps1:200；scripts/remove_selected_iphone_drivers.ps1:759 |
| Cleanup/ScanningDevices | 原始文字: 开始设备扫描... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:55；scripts/remove_selected_iphone_drivers.ps1:145；scripts/remove_selected_iphone_drivers.ps1:235；scripts/remove_selected_iphone_drivers.ps1:1781 |
| Cleanup/ScopeWarning | 原始文字: 将清除所选设备关联的所有设备节点和驱动包，包括 Apple 官方驱动。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:53；scripts/remove_selected_iphone_drivers.ps1:143；scripts/remove_selected_iphone_drivers.ps1:233；scripts/remove_selected_iphone_drivers.ps1:1769 |
| Cleanup/SelectDevice | 原始文字: 请输入设备序号；输入 Q 取消 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:71；scripts/remove_selected_iphone_drivers.ps1:161；scripts/remove_selected_iphone_drivers.ps1:251；scripts/remove_selected_iphone_drivers.ps1:1915 |
| Cleanup/SelectedDevice | 原始文字: 设备：{0} | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:74；scripts/remove_selected_iphone_drivers.ps1:164；scripts/remove_selected_iphone_drivers.ps1:254；scripts/remove_selected_iphone_drivers.ps1:2015 |
| Cleanup/SelectedDisconnected | 原始文字: 所选 iPhone 已断开。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:84；scripts/remove_selected_iphone_drivers.ps1:174；scripts/remove_selected_iphone_drivers.ps1:264；scripts/remove_selected_iphone_drivers.ps1:2134 |
| Cleanup/StackTrace | 原始文字: 调用栈： | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:100；scripts/remove_selected_iphone_drivers.ps1:190；scripts/remove_selected_iphone_drivers.ps1:280；scripts/remove_selected_iphone_drivers.ps1:2516 |
| Cleanup/StopMissingPackages | 原始文字: 已停止清理以避免遗漏驱动包。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:33；scripts/remove_selected_iphone_drivers.ps1:123；scripts/remove_selected_iphone_drivers.ps1:213；scripts/remove_selected_iphone_drivers.ps1:1266 |
| Cleanup/Title | 原始文字:  iPhone/iPad Remove All Drivers | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:102；scripts/remove_selected_iphone_drivers.ps1:192；scripts/remove_selected_iphone_drivers.ps1:282；scripts/remove_selected_iphone_drivers.ps1:1762 |
| Cleanup/UnresolvedNodes | 原始文字: 仍存在 $($unresolvedNodes.Count) 个目标 PnP 节点。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:91；scripts/remove_selected_iphone_drivers.ps1:181；scripts/remove_selected_iphone_drivers.ps1:271；scripts/remove_selected_iphone_drivers.ps1:2360 |
| Cleanup/UnresolvedPackages | 原始文字: 仍存在 $($unresolvedDrivers.Count) 个目标 Driver Store 驱动包。 | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:94；scripts/remove_selected_iphone_drivers.ps1:184；scripts/remove_selected_iphone_drivers.ps1:274；scripts/remove_selected_iphone_drivers.ps1:2386 |
| Cleanup/WaitingWindows | 原始文字: 等待 Windows 更新设备状态... | 驱动清理控制台硬编码提示补齐三语；操作和确认令牌不变 | scripts/remove_selected_iphone_drivers.ps1:87；scripts/remove_selected_iphone_drivers.ps1:177；scripts/remove_selected_iphone_drivers.ps1:267；scripts/remove_selected_iphone_drivers.ps1:2248 |
| Code/ControlStatusService.Cancelled | zh-CN: 已取消反向控制 | 默认取消说明原为硬编码中文；调用时读取现有 ControlStageCancelled 资源 | 见 Key 所指文件或资源字典 |
| Code/DriverCleanupHost.ExecutableMissing | en-US: The driver manager executable is missing. | 复用 DriverExecutableMissing；界面使用所选语言，字典加载前保留英文诊断回退 | 见 Key 所指文件或资源字典 |
| Code/MainViewModel.ShowControlOperationError | zh-HK: 藍牙／無線名称无法匹配，回落至 USB 状态 | 补齐香港繁体的蓝牙/无线传输名称匹配，避免错误归类为有线控制 | 见 Key 所指文件或资源字典 |
| Code/ReverseControlStatusWindow.ModeSummary | 所有语言: USB | 有线模式摘要复用 WiredControlLabel，与按钮和状态名称一致 | 见 Key 所指文件或资源字典 |
| DriverInstaller/AisiBody | en-US: Download Aisi Screen Mirroring, complete one normal wired mirroring session, then return and check again. | 补齐官方下载来源 | src/DriverInstaller/Windows/FailureHelpWindow.xaml:63 |
| DriverInstaller/AppleInstallerStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/DriverInstaller/Services/AppleSupportInstaller.cs:885 |
| DriverInstaller/ApplePackageManagerStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/DriverInstaller/Services/AppleSupportInstaller.cs:462 |
| DriverInstaller/AppleSupportDownloadingCompatibility | en-US: Downloading the driver component from Apple Software Update... | 统一进行中状态的省略号 | src/DriverInstaller/Services/AppleSupportInstaller.cs:172；src/DriverInstaller/Services/AppleSupportInstaller.cs:220 |
| DriverInstaller/AppleSupportExtractingCompatibility | en-US: Extracting the service component from the official Apple installer... | 统一进行中状态的省略号 | src/DriverInstaller/Services/AppleSupportInstaller.cs:246 |
| DriverInstaller/AppleSupportInstallTimeout | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/DriverInstaller/Services/AppleSupportInstaller.cs:914 |
| DriverInstaller/AppleSupportInstallingCompatibility | en-US: Installing the Apple Mobile Device Service compatibility component... | 统一进行中状态的省略号 | src/DriverInstaller/Services/AppleSupportInstaller.cs:187；src/DriverInstaller/Services/AppleSupportInstaller.cs:221；src/DriverInstaller/Services/AppleSupportInstaller.cs:766 |
| DriverInstaller/AppleSupportInstallingStore | en-US: Installing or repairing Apple USB support from Microsoft Store... | 统一进行中状态的省略号 | 见 Key 所指文件或资源字典 |
| DriverInstaller/AppleSupportPreparing | en-US: Preparing Apple USB support... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:210 |
| DriverInstaller/AppleSupportProcessTimeout | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/DriverInstaller/Services/AppleSupportInstaller.cs:477 |
| DriverInstaller/AppleSupportStartingService | en-US: Starting Apple Mobile Device Service... | 统一进行中状态的省略号 | src/DriverInstaller/Services/AppleSupportInstaller.cs:145 |
| DriverInstaller/AppleSupportVerifying | en-US: Verifying the Apple USB driver and service... | 统一进行中状态的省略号 | src/DriverInstaller/Services/AppleSupportInstaller.cs:271 |
| DriverInstaller/ConfirmOperationBody | en-US: The following device will be changed: {0}<br><br>{1}<br>{2}<br><br>Only this device's libusb0 filter is changed. Apple's official driver is not replaced. Windows may request administrator approval. | {0} 是操作名，不是设备信息 | src/DriverInstaller/MainWindow.xaml.cs:417 |
| DriverInstaller/DeviceReady | en-US: The mirroring driver for {0} is ready. | 补齐全部驱动就绪含义 | src/DriverInstaller/MainWindow.xaml.cs:338 |
| DriverInstaller/DevicesMissing | en-US: Detected {0} device(s); click the button to install missing drivers. | 用数量标签兼容单复数 | src/DriverInstaller/MainWindow.xaml.cs:598 |
| DriverInstaller/DevicesReady | en-US: Detected {0} device(s); all mirroring drivers are ready. | 用数量标签兼容单复数 | src/DriverInstaller/MainWindow.xaml.cs:597 |
| DriverInstaller/DriverCleanupHostStartFailed | 原为代码硬编码；对应源码变更见工作区 diff | 清理启动失败在已初始化的界面中使用三语提示；启动前的诊断回退保留 | src/DriverInstaller/Services/DriverCleanupHost.cs:54 |
| DriverInstaller/DriverCleanupProtectionFailed | 原为代码硬编码；对应源码变更见工作区 diff | 清理启动失败在已初始化的界面中使用三语提示；启动前的诊断回退保留 | src/DriverInstaller/Services/DriverCleanupHost.cs:32 |
| DriverInstaller/DriverFilterInstalledReconnect | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:53 |
| DriverInstaller/DriverFilterRemovedReconnect | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:52 |
| DriverInstaller/DriverOperationDetailsFormat | 原为代码硬编码；对应源码变更见工作区 diff | 驱动操作详情标题 | src/DriverInstaller/Services/DriverLocalization.cs:66 |
| DriverInstaller/DriverOperationRollbackIncomplete | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:57 |
| DriverInstaller/DriverOperationRolledBack | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:56 |
| DriverInstaller/DriverParentRemoved | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:51 |
| DriverInstaller/DriverParentRepairRejected | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:55 |
| DriverInstaller/DriverParentRepairStopped | 原为代码硬编码；对应源码变更见工作区 diff | 管理员进程返回的操作结果在界面层本地化，保留原始技术详情 | src/DriverInstaller/Services/DriverLocalization.cs:54 |
| DriverInstaller/DriverResultExitCodeMismatchFormat | 原为代码硬编码；对应源码变更见工作区 diff | 驱动验证失败提示补齐三语 | src/DriverInstaller/Services/DriverOperationClient.cs:177 |
| DriverInstaller/DriverResultTargetMismatch | 原为代码硬编码；对应源码变更见工作区 diff | 将用户可见硬编码错误或状态提示迁入三语资源 | src/DriverInstaller/Services/DriverOperationClient.cs:168 |
| DriverInstaller/GroupCopiedBody | zh-CN: QQ群号 1050045279 已复制。请在 QQ 中搜索并申请加入。 | 优化自然表达和可读性 | src/DriverInstaller/Windows/FailureHelpWindow.xaml.cs:26 |
| DriverInstaller/HistoricalDevice | en-US: Historical device | 优化自然表达和可读性 | src/DriverInstaller/Models/DriverModels.cs:27 |
| DriverInstaller/InstallingDriver | en-US: Installing the capture driver for {0}... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:345 |
| DriverInstaller/Operating | en-US: {0} {1}...；zh-CN: 正在{0} {1}…；zh-HK: 正在{0} {1}… | 统一进行中状态的省略号；参数为 Install/Repair/Uninstall 基本形式，避免组成 Install device 的假进行时 | src/DriverInstaller/MainWindow.xaml.cs:430 |
| DriverInstaller/RepairingDriver | en-US: Repairing the capture driver for {0}... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:345 |
| DriverInstaller/RepairingParent | en-US: Repairing the parent driver for {0}... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:315 |
| DriverInstaller/Retry | en-US: Check again | 相同重新检测动作与 Recheck 按钮一致 | src/DriverInstaller/Windows/FailureHelpWindow.xaml:90 |
| DriverInstaller/UnplugBody | zh-HK: 驅動程式更改已經完成。現在請拔除這部 iPhone 的傳輸線，等待裝置從清單中消失。 | 统一香港繁体中文既有用语 | src/DriverInstaller/MainWindow.xaml.cs:510 |
| DriverInstaller/UnplugTitle | zh-HK: 請拔除傳輸線 | 统一香港繁体中文既有用语 | src/DriverInstaller/MainWindow.xaml.cs:510 |
| DriverInstaller/Unplugged | zh-HK: 已拔除傳輸線 | 统一香港繁体中文既有用语 | src/DriverInstaller/MainWindow.xaml.cs:510 |
| DriverInstaller/WaitingDisconnect | en-US: Waiting for the device to disconnect... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:540 |
| DriverInstaller/WaitingForDevice | en-US: Waiting for an Apple device... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:385 |
| DriverInstaller/WaitingReconnect | en-US: Waiting for the device to reconnect... | 统一进行中状态的省略号 | src/DriverInstaller/MainWindow.xaml.cs:540 |
| Installer/Messages/CloseApplications | zh-HK: 關閉應用程式 (&amp;A) | 补齐自动关闭的行为 | 见 Key 所指文件或资源字典 |
| Installer/Messages/ConfirmDeleteSharedFile2 | zh-HK: 系統顯示下列共用檔案已不再被任何程式所使用，您要移除這些檔案嗎?%n%n%1%n%n倘若您移除了以上檔案但仍有程式需要使用它們，將造成這些程式無法正常執行，因此您若無法確定請選擇 [否]。保留這些檔案在您的系統中不會造成任何損害。；zh-CN: 系统表示下列共享的文件已不有其他程序使用。您希望卸载程序删除这些共享的文件吗？%n%n如果删除这些文件，但仍有程序在使用这些文件，则这些程序可能出现异常。如果您不能确定，请选择“否”，在系统中保留这些文件以免引发问题。 | 移除新版 Inno Setup 不再提供的 %1 参数；文件名已由独立标签显示；修复“已不有”错字并简化共享文件确认文字 | 见 Key 所指文件或资源字典 |
| Installer/Messages/ConfirmUninstall | zh-HK: 您確定要完全移除 %1 及其相關的檔案嗎？ | 卸载范围为所有组件，不只是相关文件 | 见 Key 所指文件或资源字典 |
| Installer/Messages/ErrorCloseApplications | zh-HK: 安裝程式無法自動關閉所有應用程式。建議您在繼續前先關閉所有應用程式使用的檔案。 | 应关闭占用文件的应用，而不是关闭应用使用的文件 | 见 Key 所指文件或资源字典 |
| Installer/Messages/ExistingFileNewerOverwriteOrKeepAll | zh-HK: 對下次衝突執行相同操作 (&amp;D) | 作用范围是所有冲突而非下次冲突 | 见 Key 所指文件或资源字典 |
| Installer/Messages/FileExistsKeepExisting | zh-HK: 保留現有檔案 (&amp;O) | 修复保留操作错误使用 Alt+O，应为 Alt+K | 见 Key 所指文件或资源字典 |
| Installer/Messages/FileExistsOverwriteExisting | zh-HK: 覆寫現有檔案 | 恢复覆盖操作缺失的 Alt+O 快捷键标记 | 见 Key 所指文件或资源字典 |
| Installer/Messages/FileExistsOverwriteOrKeepAll | zh-HK: 對下次衝突執行相同操作 (&amp;D) | 作用范围是所有冲突而非下次冲突 | 见 Key 所指文件或资源字典 |
| Installer/Messages/FinishedHeadingLabel | zh-HK: 安裝完成 | 补齐安装完成标题缺少的产品名占位符 | 见 Key 所指文件或资源字典 |
| Installer/Messages/InvalidPath | zh-CN: 您必须输入一个带驱动器卷标的完整路径，例如：%n%nC:\APP%n%n或UNC路径：%n%n\\server\share | 盘符不是卷标 | 见 Key 所指文件或资源字典 |
| Installer/Messages/ReadyMemoUserInfo | zh-HK: 使用者資訊 | 与项目香港繁体用语及标签标点一致 | 见 Key 所指文件或资源字典 |
| Installer/Messages/WizardUserInfo | zh-HK: 使用者資訊 | 与项目香港繁体用语一致 | 见 Key 所指文件或资源字典 |
| Launcher/ExecutableMissing | en-US: iPhoneMirror.Driver.exe was not found next to this launcher. | 独立 CMD 无法加载语言字典，故障时显示简体、繁体和英文回退；UTF-8/CRLF 防止乱码 | 见 Key 所指文件或资源字典 |
| Launcher/OperationIncomplete | en-US: Operation did not complete. Exit code: %EXIT_CODE% | 独立启动器异常结果补齐三语，保留退出代码变量 | 见 Key 所指文件或资源字典 |
| Launcher/Title | en-US: iPhone/iPad Remove All Drivers | 窗口标题保留产品名，避免暗示删除所有设备驱动；原设备范围不变 | 见 Key 所指文件或资源字典 |

## 静态未发现引用的资源

以下是保守的字面引用扫描结果，可能包含动态拼接、外部窗口或预留入口；没有据此删除资源。

- App：218 项。`AboutToolTip`, `ActualFrameRate`, `ActualResolution`, `ActualStream`, `AppSubtitle`, `ApplyReceiverName`, `AutomationStateRunning`, `AutomationStateStarting`, `BluetoothLandscapeMouseLeft90`, `BluetoothLandscapeMouseLeft90Reverse`, `BluetoothLandscapeMouseRight90`, `BluetoothLandscapeMouseRight90Reverse`, `CaptureDriverSafetyBlocked`, `CaptureErrorFormat`, `CaptureFailureDetailsFormat`, `CaptureFailureStatusFormat`, `CaptureNoPingRecovery`, `CaptureUsbConfigurationRecovery`, `ControlBindingNotFound`, `ControlWiredStartFailed`, `ControlWirelessStartFailed`, `DecoderPreferenceQueuedFormat`, `DecoderPreferenceSelectedFormat`, `DeveloperSurfaceOpenFailed`, `DeveloperToolsPreviewBadge`, `DeviceAlreadyMirroring`, `DeviceBindingAirPlayDescription`, `DeviceBindingBluetoothDescription`, `DeviceBindingStartAirPlay`, `DeviceBindingSubtitle`, `DeviceBindingWiredDescription`, `DriverManagerToolTip`, `IndependentWindowMute`, `MappingActionDoubleTap`, `MappingActionHoldUntilRelease`, `MappingActionLongPress`, `MappingActionSwipe`, `MappingActionSwipeDown`, `MappingActionSwipeLeft`, `MappingActionSwipeRight`, `MappingActionSwipeUp`, `MappingActionTap`, `MappingCaptureHelp`, `MappingCoordinateHelp`, `MappingDistance`, `MappingEndX`, `MappingEndY`, `MappingPickInside`, `MappingStateIdle`, `MappingStateKeyCaptured`, `MappingStateMappingReady`, `MappingStatePickingPosition`, `MappingStateWaitingForKey`, `MappingX`, `MappingY`, `MultiDeviceControlHint`, `NavCollapseDescription`, `NavExpandDescription`, `NavExpandToolTip`, `ObsTitleCopyFailedFormat`, `ObsWindowHelp`, `ObsWindowOpenFailedFormat`, `ObsWindowOpened`, `OpenObsWindow`, `PreviewLabel`, `ProjectionActions`, `ReverseControlDetails`, `ReverseControlStopFailureDetailFormat`, `SetupAppearance`, `SetupBluetoothFailed`, `SetupCheckAppearance`, `SetupCheckApplicationMode`, `SetupCheckPreferences`, `SetupCheckUseFeature`, `SetupConfigure`, `SetupConfigureAgain`, `SetupConfirmIdentity`, `SetupControlBluetooth`, `SetupControlFailed`, `SetupControlHintBluetooth`, `SetupControlHintUsb`, `SetupControlHintWireless`, `SetupControlUsb`, `SetupControlWireless`, `SetupDriverApple`, `SetupDriverAppleFailed`, `SetupDriverBusy`, `SetupDriverCancelled`, `SetupDriverChecking`, `SetupDriverDisconnected`, `SetupDriverDriverFailed`, `SetupDriverReDetection`, `SetupDriverRestart`, `SetupDriverResult`, `SetupDriverUsb`, `SetupHintAppearance`, `SetupHintApplicationMode`, `SetupHintBluetooth`, `SetupHintBluetoothIntroduction`, `SetupHintCompleted`, `SetupHintConnection`, `SetupHintControlIntroduction`, `SetupHintControlReadiness`, `SetupHintDeviceComplete`, `SetupHintDevices`, `SetupHintDisplay`, `SetupHintEnvironment`, `SetupHintMirrorConnection`, `SetupHintPreferences`, `SetupHintProfile`, `SetupHintReDetection`, `SetupHintUsage`, `SetupHintValidation`, `SetupHintWelcome`, `SetupHintWiredControl`, `SetupHintWiredDecoder`, `SetupHintWiredDisplay`, `SetupHintWiredFrameRate`, `SetupHintWireless`, `SetupHintWirelessBackend`, `SetupHintWirelessControl`, `SetupHintWirelessDisplay`, `SetupHintWirelessIntroduction`, `SetupInstall`, `SetupInstallConsent`, `SetupModeComplete`, `SetupModeHint`, `SetupModeLightweight`, `SetupModeTray`, `SetupRecommended`, `SetupSkipHintBluetooth`, `SetupSkipHintWireless`, `SetupSkipHintWirelessBackend`, `SetupSkipHintWirelessControl`, `SetupStageBasics`, `SetupStageDevices`, `SetupStageExperience`, `SetupStateCompleted`, `SetupStateIncomplete`, `SetupStateInvalid`, `SetupStateNotRequired`, `SetupStateUnknown`, `SetupSystemLanguage`, `SetupThemeDark`, `SetupThemeLight`, `SetupThemeSystem`, `SetupTitleAppearance`, `SetupTitleApplicationMode`, `SetupTitleBluetooth`, `SetupTitleBluetoothIntroduction`, `SetupTitleCompleted`, `SetupTitleConnection`, `SetupTitleDeviceComplete`, `SetupTitleDevices`, `SetupTitleDisplay`, `SetupTitleEnvironment`, `SetupTitleMirrorConnection`, `SetupTitlePreferences`, `SetupTitleProfile`, `SetupTitleReDetection`, `SetupTitleUsage`, `SetupTitleValidation`, `SetupTitleWelcome`, `SetupTitleWiredControl`, `SetupTitleWiredDecoder`, `SetupTitleWiredDisplay`, `SetupTitleWiredFrameRate`, `SetupTitleWireless`, `SetupTitleWirelessBackend`, `SetupTitleWirelessControl`, `SetupTitleWirelessDisplay`, `SetupTitleWirelessIntroduction`, `SetupUsageHintWiredOnly`, `SetupUsageHintWirelessOnly`, `SetupUsageWiredOnly`, `SetupUsageWirelessOnly`, `ShortcutSettings`, `ShortcutSettingsAllWindows`, `ShortcutSettingsFullScreen`, `ShortcutSettingsKeyboardShortcuts`, `ShortcutSettingsNextApp`, `ShortcutSettingsPreviousApp`, `ShortcutSettingsQuickNote`, `ShortcutSettingsReverseControl`, `ShortcutSettingsSearch`, `StopBluetoothControl`, `SwitchDeviceFailedFormat`, `SwitchingDeviceFormat`, `TouchBridgeStartFailed`, `UpdateDownloadFailedFormat`, `UsbModeDetailsToolTip`, `WindowTitle`, `WirelessProfileDisconnectConfirmFormat`, `WirelessProfileReconnectInstructionsFormat`, `WirelessResolutionTitle`, `WirelessRunningFormat`, `WizardActionHintDoubleTap`, `WizardActionHintHoldUntilRelease`, `WizardActionHintLongPress`, `WizardActionHintSwipe`, `WizardActionHintTap`, `WizardHintAction`, `WizardHintConfirmation`, `WizardHintGesture`, `WizardHintKey`, `WizardHintParameters`, `WizardHintPosition`, `WizardStepAction`, `WizardStepConfirmation`, `WizardStepKey`, `WizardStepParameters`, `WizardStepPosition`, `WizardTitleAction`, `WizardTitleConfirmation`, `WizardTitleGesture`, `WizardTitleKey`, `WizardTitleParameters`, `WizardTitlePosition`
- DriverInstaller：9 项。`AppleDownloadUnavailable`, `AppleSupportDownloadProgress`, `AppleSupportDownloadProgressUnknown`, `AppleSupportInstallTimeout`, `AppleSupportInstallingStore`, `ConnectIphone`, `DriverCleanupScriptMissing`, `ElevatedProcessTimeout`, `NoSelection`

## 完整性检查

- XML、Key、空值、占位符、文件过滤器、动态状态资源及脚本哈希：0 项错误。
- 安装器使用本地固定版本 Inno Setup 语言包叠加项目覆盖项核对；未修改上游语言包。
- 换行保留语义分段，不要求不同语言标点和句法逐字相同。
- 同时核对位置/命名占位符、printf 占位符以及安装器参数。
- Installer language files unavailable: C:\Users\Ray\Documents\iphoneMirror\work\tools\inno-setup\Languages\ChineseSimplified.isl, C:\Users\Ray\Documents\iphoneMirror\work\tools\inno-setup\Languages\ChineseTraditional.isl, C:\Users\Ray\Documents\iphoneMirror\work\tools\inno-setup\Default.isl, C:\Users\Ray\Documents\iphoneMirror\work\tools\inno-setup\Languages\Japanese.isl

台湾新增语言的构建、运行时格式化、语言切换及 UI 布局验证见 [LOCALIZATION-TAIWAN.md](LOCALIZATION-TAIWAN.md)；早期三语审查见 [LOCALIZATION-VALIDATION.md](LOCALIZATION-VALIDATION.md)。

## 扫描文件清单

- `src/App/Animations/WindowDragBehavior.cs`
- `src/App/App.xaml`
- `src/App/App.xaml.cs`
- `src/App/Automation/AutomationApiHost.cs`
- `src/App/Automation/AutomationOpenApi.cs`
- `src/App/Controls/AdaptiveToolbar.cs`
- `src/App/Controls/NativePreviewHost.cs`
- `src/App/Controls/NativeTouchInput.cs`
- `src/App/Controls/PreviewAttachmentCoordinator.cs`
- `src/App/Controls/ThemedSymbolIcon.cs`
- `src/App/Controls/WorkspaceRevealPanel.cs`
- `src/App/Interop/NativeCore.cs`
- `src/App/Interop/NativeCursor.cs`
- `src/App/Localization/LocalizationService.cs`
- `src/App/Localization/LocalizedText.cs`
- `src/App/Localization/Strings.en-US.xaml`
- `src/App/Localization/Strings.ja-JP.xaml`
- `src/App/Localization/Strings.zh-CN.xaml`
- `src/App/Localization/Strings.zh-HK.xaml`
- `src/App/Localization/Strings.zh-TW.xaml`
- `src/App/MainWindow.AdaptiveLayout.cs`
- `src/App/MainWindow.Automation.cs`
- `src/App/MainWindow.AutomationManagement.cs`
- `src/App/MainWindow.ClipboardShortcuts.cs`
- `src/App/MainWindow.CompactLaunch.cs`
- `src/App/MainWindow.FirstRun.cs`
- `src/App/MainWindow.KeyboardFocus.cs`
- `src/App/MainWindow.KeyboardHookRecovery.cs`
- `src/App/MainWindow.KeyboardInputMode.cs`
- `src/App/MainWindow.KeyboardMapping.cs`
- `src/App/MainWindow.KeyboardRouting.cs`
- `src/App/MainWindow.MappingOverlay.cs`
- `src/App/MainWindow.MultiTouch.cs`
- `src/App/MainWindow.RemoteTextInput.cs`
- `src/App/MainWindow.Shortcuts.cs`
- `src/App/MainWindow.Tray.cs`
- `src/App/MainWindow.WorkspaceTransitions.cs`
- `src/App/MainWindow.xaml`
- `src/App/MainWindow.xaml.cs`
- `src/App/Models/DeviceCaptureState.cs`
- `src/App/Models/DeviceCornerProfile.cs`
- `src/App/Models/DeviceVideoPreferences.cs`
- `src/App/Models/DeviceViewModel.cs`
- `src/App/Services/AppIdentity.cs`
- `src/App/Services/AppleDisplayCatalog.cs`
- `src/App/Services/AppleProductNames.cs`
- `src/App/Services/AppLog.cs`
- `src/App/Services/AspectRatioWindowController.cs`
- `src/App/Services/Automation/AutomationContracts.cs`
- `src/App/Services/Automation/AutomationOwnership.cs`
- `src/App/Services/Automation/AutomationService.cs`
- `src/App/Services/Automation/AutomationSettings.cs`
- `src/App/Services/Automation/DeviceInputService.cs`
- `src/App/Services/BluetoothClientInfo.cs`
- `src/App/Services/BluetoothClientRouteTable.cs`
- `src/App/Services/BluetoothControlNoticePolicy.cs`
- `src/App/Services/BluetoothHidMouseService.cs`
- `src/App/Services/BluetoothHidProtocol.cs`
- `src/App/Services/BluetoothMouseOrientationMapper.cs`
- `src/App/Services/BluetoothMouseReportCoalescer.cs`
- `src/App/Services/BonjourServiceStarter.cs`
- `src/App/Services/BossKeyWindowVisibility.cs`
- `src/App/Services/CaptureErrorGuidance.cs`
- `src/App/Services/CaptureMuxEndpointLease.cs`
- `src/App/Services/CaptureShutdownCoordinator.cs`
- `src/App/Services/ClipboardSyncState.cs`
- `src/App/Services/ClipboardTextReader.cs`
- `src/App/Services/CompactLaunchChannel.cs`
- `src/App/Services/CompactLaunchOptions.cs`
- `src/App/Services/ControlStatusService.cs`
- `src/App/Services/CoreDeviceTouchProtocol.cs`
- `src/App/Services/DeviceBindingManager.cs`
- `src/App/Services/DeviceControlSession.cs`
- `src/App/Services/DeviceCornerProfileResolver.cs`
- `src/App/Services/DeviceIdentityResolver.cs`
- `src/App/Services/DeviceKeyMap.cs`
- `src/App/Services/DeviceSessionManager.cs`
- `src/App/Services/DiagnosticLogger.cs`
- `src/App/Services/DirectUsbInputBridge.Automation.cs`
- `src/App/Services/DirectUsbInputBridge.cs`
- `src/App/Services/DriverManagerLauncher.cs`
- `src/App/Services/FirstRunDriverClient.cs`
- `src/App/Services/FirstRunSetupState.cs`
- `src/App/Services/HlsMediaPlaybackBridge.cs`
- `src/App/Services/IndependentWindowAudioPolicy.cs`
- `src/App/Services/IPhoneFilterDriverService.cs`
- `src/App/Services/KeyboardInputRouter.cs`
- `src/App/Services/KeyboardInputRouter.Events.cs`
- `src/App/Services/KeyboardMapping.cs`
- `src/App/Services/KeyboardMappingCapture.cs`
- `src/App/Services/KeyboardMappingExecutor.cs`
- `src/App/Services/KeyboardMappingFocusGuard.cs`
- `src/App/Services/KeyboardMappingHoldState.cs`
- `src/App/Services/KeyboardMappingKeys.cs`
- `src/App/Services/KeyboardMappingKeyState.cs`
- `src/App/Services/KeyboardMappingWindowsKey.cs`
- `src/App/Services/KeyboardMappingWizardState.cs`
- `src/App/Services/KeyboardShortcut.cs`
- `src/App/Services/KeyboardShortcutRecognizer.cs`
- `src/App/Services/MappingPreviewSurface.cs`
- `src/App/Services/MediaCastAudioDecoder.cs`
- `src/App/Services/MediaCastEventGate.cs`
- `src/App/Services/MediaCastPlaybackControls.cs`
- `src/App/Services/MediaCastReceiverController.cs`
- `src/App/Services/MediaOutputCoordinator.cs`
- `src/App/Services/MediaOutputMicrophone.cs`
- `src/App/Services/MediaOutputService.cs`
- `src/App/Services/MediaRecoveryBackoff.cs`
- `src/App/Services/MediaSourceClassifier.cs`
- `src/App/Services/MultiDevicePreviewManager.cs`
- `src/App/Services/NativeLogTailReader.cs`
- `src/App/Services/OwnedBridgeProcess.cs`
- `src/App/Services/PendingRecordingStore.cs`
- `src/App/Services/PreviewCoordinateMapper.cs`
- `src/App/Services/ProtectedContentStatus.cs`
- `src/App/Services/RawMouseDeltaTracker.cs`
- `src/App/Services/ReverseControlInputRouter.cs`
- `src/App/Services/RuntimeBinaryIntegrity.cs`
- `src/App/Services/ScreenshotService.cs`
- `src/App/Services/SetupAssessment.cs`
- `src/App/Services/SetupAssessmentSession.cs`
- `src/App/Services/SetupCheckRuntime.cs`
- `src/App/Services/SingleFlightOperation.cs`
- `src/App/Services/SingleInstanceCoordinator.cs`
- `src/App/Services/StableDeviceSelection.cs`
- `src/App/Services/StartupDiagnostics.cs`
- `src/App/Services/ThemeService.cs`
- `src/App/Services/TrayIconService.cs`
- `src/App/Services/UsbDeviceRefreshPolicy.cs`
- `src/App/Services/UsbMuxResumeContext.cs`
- `src/App/Services/UsbRestoreRecoveryTracker.cs`
- `src/App/Services/UsbTouchBridgeHost.cs`
- `src/App/Services/UxPlayComponent.cs`
- `src/App/Services/VirtualCameraService.cs`
- `src/App/Services/WifiSyncInsertionTracker.cs`
- `src/App/Services/WindowsAutoPlayGuard.cs`
- `src/App/Services/WirelessReceiverController.cs`
- `src/App/Services/WirelessReceiverService.cs`
- `src/App/Services/WirelessStallRecoveryTracker.cs`
- `src/App/tools/updater/Apply-ZipUpdate.ps1`
- `src/App/Updater/GitHubReleaseClient.cs`
- `src/App/Updater/LocalizedReleaseNotes.cs`
- `src/App/Updater/MarkdownFlowDocumentRenderer.cs`
- `src/App/Updater/ReleaseParser.cs`
- `src/App/Updater/SemanticVersion.cs`
- `src/App/Updater/UpdateInstallerLauncher.cs`
- `src/App/Updater/UpdateSettingsStore.cs`
- `src/App/Updater/VersionManager.cs`
- `src/App/ViewModels/MainViewModel.Automation.cs`
- `src/App/ViewModels/MainViewModel.AutomationManagement.cs`
- `src/App/ViewModels/MainViewModel.cs`
- `src/App/ViewModels/MainViewModel.FirstRun.cs`
- `src/App/ViewModels/MainViewModel.KeyboardInput.cs`
- `src/App/ViewModels/MainViewModel.KeyboardMapping.cs`
- `src/App/ViewModels/MainViewModel.MultiControl.cs`
- `src/App/ViewModels/RelayCommand.cs`
- `src/App/Windows/AboutWindow.xaml`
- `src/App/Windows/AboutWindow.xaml.cs`
- `src/App/Windows/AdvancedSettingsWindow.xaml`
- `src/App/Windows/AdvancedSettingsWindow.xaml.cs`
- `src/App/Windows/AirPlayDeviceSelectionWindow.xaml`
- `src/App/Windows/AirPlayDeviceSelectionWindow.xaml.cs`
- `src/App/Windows/AppPromptWindow.xaml`
- `src/App/Windows/AppPromptWindow.xaml.cs`
- `src/App/Windows/BluetoothClientBindingWindow.xaml`
- `src/App/Windows/BluetoothClientBindingWindow.xaml.cs`
- `src/App/Windows/BluetoothConnectionWindow.xaml`
- `src/App/Windows/BluetoothConnectionWindow.xaml.cs`
- `src/App/Windows/BluetoothControlNoticeWindow.xaml`
- `src/App/Windows/BluetoothControlNoticeWindow.xaml.cs`
- `src/App/Windows/CaptureRecoveryWindow.xaml`
- `src/App/Windows/CaptureRecoveryWindow.xaml.cs`
- `src/App/Windows/CaptureStatusNoticeWindow.xaml`
- `src/App/Windows/CaptureStatusNoticeWindow.xaml.cs`
- `src/App/Windows/ComponentDownloadWindow.xaml`
- `src/App/Windows/ComponentDownloadWindow.xaml.cs`
- `src/App/Windows/DeveloperToolsWindow.Automation.cs`
- `src/App/Windows/DeveloperToolsWindow.xaml`
- `src/App/Windows/DeveloperToolsWindow.xaml.cs`
- `src/App/Windows/DeviceBindingWindow.xaml`
- `src/App/Windows/DeviceBindingWindow.xaml.cs`
- `src/App/Windows/FirstRunSetupWindow.Assessment.cs`
- `src/App/Windows/FirstRunSetupWindow.Choices.cs`
- `src/App/Windows/FirstRunSetupWindow.Flow.cs`
- `src/App/Windows/FirstRunSetupWindow.Symbols.cs`
- `src/App/Windows/FirstRunSetupWindow.Tools.cs`
- `src/App/Windows/FirstRunSetupWindow.xaml`
- `src/App/Windows/FirstRunSetupWindow.xaml.cs`
- `src/App/Windows/ImageSettingsWindow.xaml`
- `src/App/Windows/ImageSettingsWindow.xaml.cs`
- `src/App/Windows/InstanceConflictWindow.xaml`
- `src/App/Windows/InstanceConflictWindow.xaml.cs`
- `src/App/Windows/KeyboardMappingEditorWindow.xaml`
- `src/App/Windows/KeyboardMappingEditorWindow.xaml.cs`
- `src/App/Windows/KeyboardMappingOverlayWindow.cs`
- `src/App/Windows/KeyboardMappingWindow.xaml`
- `src/App/Windows/KeyboardMappingWindow.xaml.cs`
- `src/App/Windows/MappingWizard/ActionSelectionStep.xaml`
- `src/App/Windows/MappingWizard/ActionSelectionStep.xaml.cs`
- `src/App/Windows/MappingWizard/ConfirmationStep.xaml`
- `src/App/Windows/MappingWizard/ConfirmationStep.xaml.cs`
- `src/App/Windows/MappingWizard/KeySelectionStep.xaml`
- `src/App/Windows/MappingWizard/KeySelectionStep.xaml.cs`
- `src/App/Windows/MappingWizard/ParameterStep.xaml`
- `src/App/Windows/MappingWizard/ParameterStep.xaml.cs`
- `src/App/Windows/MappingWizard/PositionStep.xaml`
- `src/App/Windows/MappingWizard/PositionStep.xaml.cs`
- `src/App/Windows/MappingWizard/WizardPageTransition.cs`
- `src/App/Windows/MediaOutputSettingsWindow.xaml`
- `src/App/Windows/MediaOutputSettingsWindow.xaml.cs`
- `src/App/Windows/NativePreviewWindow.cs`
- `src/App/Windows/ProjectionSettingsWindow.xaml`
- `src/App/Windows/ProjectionSettingsWindow.xaml.cs`
- `src/App/Windows/ProtectedContentNoticeWindow.xaml`
- `src/App/Windows/ProtectedContentNoticeWindow.xaml.cs`
- `src/App/Windows/ProtectedContentOverlayWindow.cs`
- `src/App/Windows/ReverseControlStatusWindow.xaml`
- `src/App/Windows/ReverseControlStatusWindow.xaml.cs`
- `src/App/Windows/ShortcutSettingsWindow.xaml`
- `src/App/Windows/ShortcutSettingsWindow.xaml.cs`
- `src/App/Windows/StartupErrorWindow.xaml`
- `src/App/Windows/StartupErrorWindow.xaml.cs`
- `src/App/Windows/TextInputWindow.xaml`
- `src/App/Windows/TextInputWindow.xaml.cs`
- `src/App/Windows/TrayPanelWindow.xaml`
- `src/App/Windows/TrayPanelWindow.xaml.cs`
- `src/App/Windows/UpdateWindow.xaml`
- `src/App/Windows/UpdateWindow.xaml.cs`
- `src/App/Windows/UsbProjectionModeInfoWindow.xaml`
- `src/App/Windows/UsbProjectionModeInfoWindow.xaml.cs`
- `src/App/Windows/WindowStyleSettingsWindow.xaml`
- `src/App/Windows/WindowStyleSettingsWindow.xaml.cs`
- `src/App.Logic.Tests/ClipboardSyncTests.cs`
- `src/App.Logic.Tests/ComponentDownloadNetworkTests.cs`
- `src/App.Logic.Tests/DotnetTestSmoke.cs`
- `src/App.Logic.Tests/IssueFixMediaTests.cs`
- `src/App.Logic.Tests/MediaOutputCoordinatorTests.cs`
- `src/App.Logic.Tests/MediaOutputTestInterop.cs`
- `src/App.Logic.Tests/Program.cs`
- `src/App.Logic.Tests/ReviewFixRegressionTests.cs`
- `src/App.Logic.Tests/UpdaterHandoffTests.cs`
- `src/App.Logic.Tests/UxPlayComponentTests.cs`
- `src/App.Runtime.Tests/AdaptiveLayoutAudit.cs`
- `src/App.Runtime.Tests/AdaptiveToolbarTests.cs`
- `src/App.Runtime.Tests/AutomationApiTests.cs`
- `src/App.Runtime.Tests/AutomationLifecycleTests.cs`
- `src/App.Runtime.Tests/AutomationManagementTests.cs`
- `src/App.Runtime.Tests/BinderWorkflowTests.cs`
- `src/App.Runtime.Tests/BluetoothInputToggleTests.cs`
- `src/App.Runtime.Tests/BridgeProcessLifecycleTests.cs`
- `src/App.Runtime.Tests/CaptureReviewRegressionTests.cs`
- `src/App.Runtime.Tests/ClipboardSyncRegressionTests.cs`
- `src/App.Runtime.Tests/CloseToTrayTests.cs`
- `src/App.Runtime.Tests/ComponentDownloadTests.cs`
- `src/App.Runtime.Tests/ComponentRuntimeTests.cs`
- `src/App.Runtime.Tests/ControlBindingTests.cs`
- `src/App.Runtime.Tests/ControlErrorPresentationTests.cs`
- `src/App.Runtime.Tests/ControlHandshakeAuditTests.cs`
- `src/App.Runtime.Tests/ControlStateAudit.cs`
- `src/App.Runtime.Tests/CursorRegressionTests.cs`
- `src/App.Runtime.Tests/DdiStartupTests.cs`
- `src/App.Runtime.Tests/DeviceControlLiveTests.cs`
- `src/App.Runtime.Tests/DotnetTestSmoke.cs`
- `src/App.Runtime.Tests/DriverComboBoxTests.cs`
- `src/App.Runtime.Tests/DriverUiConsistencyAudit.cs`
- `src/App.Runtime.Tests/FirstRunSetupTests.cs`
- `src/App.Runtime.Tests/FirstRunSetupUsabilityTests.cs`
- `src/App.Runtime.Tests/FivePointLiveTests.cs`
- `src/App.Runtime.Tests/FivePointTouchTests.cs`
- `src/App.Runtime.Tests/FullScreenKeyGuardTests.cs`
- `src/App.Runtime.Tests/IndependentBluetoothPointerTests.cs`
- `src/App.Runtime.Tests/InteractionRegressionTests.cs`
- `src/App.Runtime.Tests/KeyboardCaptureRecoveryTests.cs`
- `src/App.Runtime.Tests/KeyboardClipboardLiveTests.cs`
- `src/App.Runtime.Tests/KeyboardFocusTests.cs`
- `src/App.Runtime.Tests/KeyboardHookRecoveryTests.cs`
- `src/App.Runtime.Tests/KeyboardMappingHoldTests.cs`
- `src/App.Runtime.Tests/KeyboardMappingInteractionTests.cs`
- `src/App.Runtime.Tests/KeyboardMappingLiveTest.cs`
- `src/App.Runtime.Tests/KeyboardMappingRegressionTests.cs`
- `src/App.Runtime.Tests/KeyboardMappingTests.cs`
- `src/App.Runtime.Tests/KeyboardMappingWizardRegressionTests.cs`
- `src/App.Runtime.Tests/KeyboardMappingWizardTests.cs`
- `src/App.Runtime.Tests/KeyboardOwnershipLiveTests.cs`
- `src/App.Runtime.Tests/KeyboardOwnershipTests.cs`
- `src/App.Runtime.Tests/KeyboardReconnectTests.cs`
- `src/App.Runtime.Tests/KeyboardRouterDispatchTests.cs`
- `src/App.Runtime.Tests/KeyboardRouterTests.cs`
- `src/App.Runtime.Tests/KeyboardTransportTests.cs`
- `src/App.Runtime.Tests/LanguageDisplayAudit.cs`
- `src/App.Runtime.Tests/LocalizationAuditTests.cs`
- `src/App.Runtime.Tests/LogicReviewRegressionTests.cs`
- `src/App.Runtime.Tests/MainPreviewPointerTests.cs`
- `src/App.Runtime.Tests/MediaReviewRegressionTests.cs`
- `src/App.Runtime.Tests/MultiDeviceControlTests.cs`
- `src/App.Runtime.Tests/MultiDeviceInputIsolationTests.cs`
- `src/App.Runtime.Tests/ParallelOutputTests.cs`
- `src/App.Runtime.Tests/PreviewContextMenuTests.cs`
- `src/App.Runtime.Tests/PreviewShellUiAudit.cs`
- `src/App.Runtime.Tests/PreviewStyleTests.cs`
- `src/App.Runtime.Tests/Program.cs`
- `src/App.Runtime.Tests/RemoteTextInputTests.cs`
- `src/App.Runtime.Tests/ReverseControlCountdownTests.cs`
- `src/App.Runtime.Tests/RoundedWindowAudit.cs`
- `src/App.Runtime.Tests/SetupAssessmentTests.cs`
- `src/App.Runtime.Tests/SetupToolsTests.cs`
- `src/App.Runtime.Tests/ShortcutRegressionTests.cs`
- `src/App.Runtime.Tests/TaiwanLocalizationTests.cs`
- `src/App.Runtime.Tests/ThemeContentAudit.cs`
- `src/App.Runtime.Tests/TrayModeTests.cs`
- `src/App.Runtime.Tests/TrayRegressionTests.cs`
- `src/App.Runtime.Tests/TrayStartupThemeTests.cs`
- `src/App.Runtime.Tests/UiAuditFixTests.cs`
- `src/App.Runtime.Tests/UiConsistencyAudit.cs`
- `src/App.Runtime.Tests/UiPerformanceAudit.cs`
- `src/App.Runtime.Tests/UpdaterElevationRegressionTests.cs`
- `src/App.Runtime.Tests/UpdaterWindowRegressionTests.cs`
- `src/App.Runtime.Tests/UxPlayLifecycleTests.cs`
- `src/App.Runtime.Tests/VirtualCameraRegressionTests.cs`
- `src/App.Runtime.Tests/WiredControlLiveCountdownTest.cs`
- `src/App.Runtime.Tests/WirelessRecoveryLiveTests.cs`
- `src/App.Runtime.Tests/WorkspacePerformanceAudit.cs`
- `src/App.Runtime.Tests/WorkspaceRegressionTests.cs`
- `src/App.Runtime.Tests/WorkspaceRevealGeometryTests.cs`
- `src/App.Runtime.Tests/WorkspaceRevealTests.cs`
- `src/Core/include/iPhoneMirror/CoreApi.h`
- `src/Core/resources/iPhoneMirror.Core.rc`
- `src/Core/src/Audio/WasapiRenderer.cpp`
- `src/Core/src/Audio/WasapiRenderer.h`
- `src/Core/src/Capture/CaptureSession.cpp`
- `src/Core/src/Capture/CaptureSession.h`
- `src/Core/src/Capture/DecoderSwitchCoordinator.h`
- `src/Core/src/Capture/ICaptureSession.h`
- `src/Core/src/Capture/UsbConfigurationRestorePolicy.h`
- `src/Core/src/Capture/UsbDisplaySize.h`
- `src/Core/src/Capture/UsbOrientationMonitor.cpp`
- `src/Core/src/Capture/UsbOrientationMonitor.h`
- `src/Core/src/Capture/WirelessCaptureSession.cpp`
- `src/Core/src/Capture/WirelessCaptureSession.h`
- `src/Core/src/Capture/WirelessReceiverHub.cpp`
- `src/Core/src/Capture/WirelessReceiverHub.h`
- `src/Core/src/CoreApi.cpp`
- `src/Core/src/Device/AppleUsbDiscovery.cpp`
- `src/Core/src/Device/AppleUsbDiscovery.h`
- `src/Core/src/Device/DeviceManager.cpp`
- `src/Core/src/Device/DeviceManager.h`
- `src/Core/src/Logging.cpp`
- `src/Core/src/Logging.h`
- `src/Core/src/Media/BundledH264Decoder.cpp`
- `src/Core/src/Media/BundledH264Decoder.h`
- `src/Core/src/Media/CoreMedia.cpp`
- `src/Core/src/Media/CoreMedia.h`
- `src/Core/src/Media/H264.cpp`
- `src/Core/src/Media/H264.h`
- `src/Core/src/Media/MediaFoundationDecoder.cpp`
- `src/Core/src/Media/MediaFoundationDecoder.h`
- `src/Core/src/Protocol/Plist.cpp`
- `src/Core/src/Protocol/Plist.h`
- `src/Core/src/Protocol/QuickTimePacket.cpp`
- `src/Core/src/Protocol/QuickTimePacket.h`
- `src/Core/src/Protocol/QuickTimeSession.cpp`
- `src/Core/src/Protocol/QuickTimeSession.h`
- `src/Core/src/Renderer/D3D11PreviewRenderer.cpp`
- `src/Core/src/Renderer/D3D11PreviewRenderer.h`
- `src/Core/src/Renderer/OutputModeState.h`
- `src/Core/src/Transport/AppleUsbIdentityCache.h`
- `src/Core/src/Transport/LibUsb0Readiness.h`
- `src/Core/src/Transport/LibUsb0Transport.cpp`
- `src/Core/src/Transport/LibUsb0Transport.h`
- `src/Core/src/Transport/QtUsbTransport.cpp`
- `src/Core/src/Transport/QtUsbTransport.h`
- `src/Core/src/Transport/Socket.cpp`
- `src/Core/src/Transport/Socket.h`
- `src/Core/src/Transport/UsbInterfaceTransitionPolicy.h`
- `src/Core/src/Transport/UsbMuxClient.cpp`
- `src/Core/src/Transport/UsbMuxClient.h`
- `src/Core/tests/Avc444Fixture.h`
- `src/Core/tests/CoreTests.cpp`
- `src/Core/tests/LibUsb0ActivationTests.cpp`
- `src/Core/tests/OutputModeStateTests.cpp`
- `src/Core/tests/PreviewOpacitySmoke.cpp`
- `src/Core/tests/PreviewStaticFrameSmoke.cpp`
- `src/Core/tests/QtUsbTransportTests.cpp`
- `src/Core/tests/UsbConfigurationRestorePolicyTests.cpp`
- `src/Core/tests/UsbConfigurationSwitchIdentityTests.cpp`
- `src/Core/tests/UsbDeviceReconnectTests.cpp`
- `src/Core/tests/WasapiUnderrunSmoke.cpp`
- `src/Core/tools/LibUsb0Probe.cpp`
- `src/Core/tools/PipelineSwitchProbe.cpp`
- `src/Core/tools/UsbConfigurationSwitch.cpp`
- `src/Core/tools/UsbDeviceReconnect.cpp`
- `src/Core/tools/UsbDeviceReconnect.h`
- `src/DriverInstaller/App.xaml`
- `src/DriverInstaller/App.xaml.cs`
- `src/DriverInstaller/GlobalUsings.cs`
- `src/DriverInstaller/Localization/Strings.en-US.xaml`
- `src/DriverInstaller/Localization/Strings.ja-JP.xaml`
- `src/DriverInstaller/Localization/Strings.zh-CN.xaml`
- `src/DriverInstaller/Localization/Strings.zh-HK.xaml`
- `src/DriverInstaller/Localization/Strings.zh-TW.xaml`
- `src/DriverInstaller/MainWindow.xaml`
- `src/DriverInstaller/MainWindow.xaml.cs`
- `src/DriverInstaller/Models/DriverModels.cs`
- `src/DriverInstaller/Properties/AssemblyInfo.cs`
- `src/DriverInstaller/Services/AppleDeviceMetadataReader.cs`
- `src/DriverInstaller/Services/AppleMuxSupportProbe.cs`
- `src/DriverInstaller/Services/AppleProductNames.cs`
- `src/DriverInstaller/Services/AppleSoftwareUpdateCatalog.cs`
- `src/DriverInstaller/Services/AppleSupportInstaller.cs`
- `src/DriverInstaller/Services/DeviceCatalog.cs`
- `src/DriverInstaller/Services/DriverCleanupHost.cs`
- `src/DriverInstaller/Services/DriverConstants.cs`
- `src/DriverInstaller/Services/DriverElevation.Bootstrap.ps1`
- `src/DriverInstaller/Services/DriverElevationBootstrap.cs`
- `src/DriverInstaller/Services/DriverLocalization.cs`
- `src/DriverInstaller/Services/DriverLogger.cs`
- `src/DriverInstaller/Services/DriverOperationClient.cs`
- `src/DriverInstaller/Services/DriverOperationSafety.cs`
- `src/DriverInstaller/Services/DriverPayload.cs`
- `src/DriverInstaller/Services/DriverThemeService.cs`
- `src/DriverInstaller/Services/ElevatedDriverHost.cs`
- `src/DriverInstaller/Services/FirstRunDriverHost.cs`
- `src/DriverInstaller/Services/ParentDriverChange.cs`
- `src/DriverInstaller/Services/ParentDriverNative.cs`
- `src/DriverInstaller/Services/ParentDriverPolicy.cs`
- `src/DriverInstaller/Windows/DeviceTrustWindow.xaml`
- `src/DriverInstaller/Windows/DeviceTrustWindow.xaml.cs`
- `src/DriverInstaller/Windows/FailureHelpWindow.xaml`
- `src/DriverInstaller/Windows/FailureHelpWindow.xaml.cs`
- `src/DriverInstaller/Windows/ParentDriverWindow.xaml`
- `src/DriverInstaller/Windows/ParentDriverWindow.xaml.cs`
- `src/DriverInstaller/Windows/PromptWindow.xaml`
- `src/DriverInstaller/Windows/PromptWindow.xaml.cs`
- `src/DriverInstaller/Windows/RequiredActionWindow.xaml`
- `src/DriverInstaller/Windows/RequiredActionWindow.xaml.cs`
- `src/DriverInstaller.Tests/AppleMuxSupportTests.cs`
- `src/DriverInstaller.Tests/DriverFailureTests.cs`
- `src/DriverInstaller.Tests/ParentDriverTests.cs`
- `src/DriverInstaller.Tests/Program.cs`
- `src/Shared/Devices/AppleDisplayCatalog.generated.h`
- `src/Shared/Networking/SegmentedHttpDownloader.cs`
- `src/Shared/Security/ElevationPathLock.cs`
- `src/SharedUI/Animations/ModernAnimations.xaml`
- `src/SharedUI/Animations/PageTransition.cs`
- `src/SharedUI/Animations/RevealTransition.cs`
- `src/SharedUI/Animations/SurfaceMotion.cs`
- `src/SharedUI/Controls/Buttons.xaml`
- `src/SharedUI/Controls/ComboBoxTextLayout.cs`
- `src/SharedUI/Controls/DialogKeyboard.cs`
- `src/SharedUI/Controls/DialogViewport.cs`
- `src/SharedUI/Controls/Inputs.xaml`
- `src/SharedUI/Controls/ModernButton.cs`
- `src/SharedUI/Controls/ModernCard.cs`
- `src/SharedUI/Controls/ModernControls.xaml`
- `src/SharedUI/Controls/ModernDialog.cs`
- `src/SharedUI/Controls/RoundedWindow.cs`
- `src/SharedUI/Controls/StatusAppearance.cs`
- `src/SharedUI/Services/AccessibilityAppearance.cs`
- `src/SharedUI/Services/WindowWorkAreaController.cs`
- `src/SharedUI/Themes/DarkTheme.xaml`
- `src/SharedUI/Themes/DesignTokens.xaml`
- `src/SharedUI/Themes/LightTheme.xaml`
- `src/UxPlayHost/tests/UxPlayHostFixture.cpp`
- `src/UxPlayHost/tests/UxPlayHostSmoke.cpp`
- `src/UxPlayHost/UxPlayHost.cpp`
- `src/VirtualCamera/include/iPhoneMirror/VirtualCameraApi.h`
- `src/VirtualCamera/src/ComServer.cpp`
- `src/VirtualCamera/src/FrameExchange.cpp`
- `src/VirtualCamera/src/FrameExchange.h`
- `src/VirtualCamera/src/MediaSource.cpp`
- `src/VirtualCamera/src/MediaSource.h`
- `src/VirtualCamera/src/MediaSourceActivate.cpp`
- `src/VirtualCamera/src/MediaSourceActivate.h`
- `src/VirtualCamera/src/ModuleState.h`
- `src/VirtualCamera/src/VirtualCameraControl.cpp`
- `src/VirtualCamera/src/VirtualCameraShared.h`
- `src/VirtualCamera/tests/MediaSourceActivateTests.cpp`
- `src/VirtualCamera/tests/VirtualCameraComponentTests.cpp`
- `src/VirtualCamera/tools/VirtualCameraAdmin.cpp`
- `src/VirtualCamera/tools/VirtualCameraSignalPublisher.cpp`
- `src/VirtualCamera/tools/VirtualCameraSystemProbe.cpp`
- `src/WirelessHost/DlnaRenderer.cpp`
- `src/WirelessHost/DlnaRenderer.h`
- `src/WirelessHost/DnsSdAdvertisementPolicy.h`
- `src/WirelessHost/DnsSdRegistrationPolicy.h`
- `src/WirelessHost/DnsSdShim.cpp`
- `src/WirelessHost/HostCommon.h`
- `src/WirelessHost/HttpUrl.h`
- `src/WirelessHost/IpcProtocol.h`
- `src/WirelessHost/tests/DnsSdRegistrationPolicyTests.cpp`
- `src/WirelessHost/tests/IpcWriterTests.cpp`
- `src/WirelessHost/tests/WirelessHostPreflightSmoke.cpp`
- `src/WirelessHost/tests/WirelessHostSmoke.cpp`
- `src/WirelessHost/tests/WirelessHostStub.cpp`
- `src/WirelessHost/tests/WirelessReceiverProtocolSmoke.cpp`
- `src/WirelessHost/WirelessHost.cpp`
- `scripts/airplay_channel_smoke.cpp`
- `scripts/airplay_media_control_smoke.ps1`
- `scripts/AppleSupportPackage.ps1`
- `scripts/aspect_ratio_smoke.ps1`
- `scripts/audit_component_payloads.py`
- `scripts/audit_localization.py`
- `scripts/audit_taiwan_content.py`
- `scripts/audit_ui.py`
- `scripts/build_airplay_ffmpeg.ps1`
- `scripts/build_airplay_receiver.ps1`
- `scripts/build_compact_ffmpeg.ps1`
- `scripts/build_icon.py`
- `scripts/build_installer.ps1`
- `scripts/CompactBuildRecord.ps1`
- `scripts/DdiBundle.ps1`
- `scripts/diagnose.py`
- `scripts/generate_apple_mobile_capture_pids.ps1`
- `scripts/gui_smoke.ps1`
- `scripts/hls_recovery_server.py`
- `scripts/install_airplay_runtime.ps1`
- `scripts/localization_gui_smoke.ps1`
- `scripts/media_cast_integrated_smoke.ps1`
- `scripts/multi_device_capture_switch_smoke.ps1`
- `scripts/multi_device_selection_smoke.ps1`
- `scripts/package_release.ps1`
- `scripts/package_uxplay_component.ps1`
- `scripts/prepare_compact_ffmpeg.ps1`
- `scripts/prepare_ddi.py`
- `scripts/prepare_ffmpeg.ps1`
- `scripts/prepare_inno_setup.ps1`
- `scripts/prepare_libusb0_runtime.ps1`
- `scripts/prepare_uxplay.ps1`
- `scripts/prepare_vc_runtime.ps1`
- `scripts/remove_selected_iphone_drivers.ps1`
- `scripts/repair_apple_wifi_usbmux.ps1`
- `scripts/reset_driver_test_environment.ps1`
- `scripts/single_device_capture_restart_smoke.ps1`
- `scripts/Test-PasteboardIosOriginated.py`
- `scripts/Test-PasteboardUia.ps1`
- `scripts/Test-WiredControlUia.ps1`
- `scripts/Test-WiredRecoveryDevice.ps1`
- `scripts/test_airplay_ffmpeg.ps1`
- `scripts/test_airplay_upstream.ps1`
- `scripts/test_apple_support_package.ps1`
- `scripts/test_cleanup_localization.ps1`
- `scripts/test_compact_ffmpeg.ps1`
- `scripts/test_control_lifecycle.ps1`
- `scripts/test_driver_cleanup_safety.ps1`
- `scripts/test_install_airplay_runtime.ps1`
- `scripts/test_installer.ps1`
- `scripts/test_usb_bridge_build_source.ps1`
- `scripts/test_uxplay_media.ps1`
- `scripts/test_vc_runtime_version.ps1`
- `scripts/ui_visual_smoke.ps1`
- `scripts/update_apple_display_catalog.py`
- `scripts/usb-bridge-recipe/build.ps1`
- `scripts/usb-bridge-recipe/hooks/hook-usb.py`
- `scripts/UsbBridgeBuildSource.ps1`
- `scripts/UsbTouchBridgeRuntime.ps1`
- `scripts/VcRuntimeVersion.ps1`
- `scripts/verify_localization.ps1`
- `scripts/verify_localization_surfaces.ps1`
- `scripts/verify_uxplay_publication.ps1`
- `scripts/window_chrome_smoke.ps1`
- `scripts/window_close_cleanup_smoke.ps1`
- `scripts/wireless_receiver_smoke.ps1`
- `tools/BluetoothHidStress/BluetoothClientInfoStub.cs`
- `tools/BluetoothHidStress/Program.cs`
- `tools/bridge_runtime_check.py`
- `tools/capture_ipc_apis.py`
- `tools/capture_original_frame_rpc.py`
- `tools/capture_process_writes.py`
- `tools/capture_socket_io.py`
- `tools/capture_winsock_frames.py`
- `tools/coredevice_touch_bridge.py`
- `tools/ddi_support.py`
- `tools/dtx_devicehub_probe.py`
- `tools/enable_wifi_sync.py`
- `tools/five_point_touch_page.py`
- `tools/inspect_hid_session.py`
- `tools/iostouch/__init__.py`
- `tools/iostouch/qt/__init__.py`
- `tools/iostouch/qt/muxbridge.py`
- `tools/iostouch/qt/usb.py`
- `tools/iostouch/qt/usbmux_usb.py`
- `tools/iostouch/qt/usbmuxd_server.py`
- `tools/keyboard_live_screenshot.py`
- `tools/mdns_discovery.py`
- `tools/probe_dtservicehub.py`
- `tools/probe_dtservicehub_rsd.py`
- `tools/probe_dtx_channel.py`
- `tools/probe_dtx_screenshot.py`
- `tools/probe_rsd_services.py`
- `tools/probe_tcp_coredevice.py`
- `tools/probe_universalhid.py`
- `tools/probe_universalhid_send.py`
- `tools/screen_orientation.py`
- `tools/srs-lab/app.js`
- `tools/srs-lab/Enable-DockerPrerequisites.ps1`
- `tools/srs-lab/index.html`
- `tools/srs-lab/localize.js`
- `tools/srs-lab/Publish-TestSignal.ps1`
- `tools/srs-lab/Start-SrsLab.ps1`
- `tools/srs-test/Start-SrsTest.ps1`
- `tools/srs-test/Stop-SrsTest.ps1`
- `tools/srs-test/web/index.html`
- `tools/srs-test/web/localize.js`
- `tools/usb_mouse_demo.py`
- `tools/usb_touch_bridge.py`
- `tools/usb_touch_console.py`
- `tools/UsbTouchDemo/Program.cs`
- `installer/DesktopShell.iss`
- `installer/iPhoneMirror.iss`
- `Launch-Recovery-Build.cmd`
- `Remove-Selected-iPhone-Drivers.cmd`
