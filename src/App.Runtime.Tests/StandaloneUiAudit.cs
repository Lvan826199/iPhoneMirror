using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using IPhoneMirror.App;
using IPhoneMirror.App.Localization;
using IPhoneMirror.App.Services;
using IPhoneMirror.App.Updater;
using IPhoneMirror.App.Windows;
using IPhoneMirror.UI.Animations;
using IPhoneMirror.UI.Services;

namespace IPhoneMirror.App.Runtime.Tests;

internal static partial class Program
{
    private static void SetAuditCulture(string culture) => typeof(LocalizationService)
        .GetMethod("ApplyLanguage", BindingFlags.Static | BindingFlags.NonPublic)!
        .Invoke(null, [culture, false, false]);

    private static void CloseAuditWindow(Window window)
    {
        if (window is KeyboardMappingEditorWindow)
            window.GetType().GetField("_discard", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(window, true);
        window.Close();
    }

    // Maintained alongside the workspace matrix: independent windows and all
    // mapping pages can be audited even without the native media payload.
    private static int RunStandaloneUiAudit(string output, string? onlyCulture = null)
    {
        Directory.CreateDirectory(output);
        var app = new App { IsUiPreviewMode = true, ShutdownMode = ShutdownMode.OnExplicitShutdown };
        app.InitializeComponent();
        var owner = new Window { Style = null, Width = 200, Height = 100, ShowInTaskbar = false, Content = new Grid() };
        owner.Show(); app.MainWindow = owner;
        var results = new List<object>();
        var failures = new List<string>();
        var findings = new HashSet<string>();
        using var trace = new AuditTraceListener();
        PresentationTraceSources.DataBindingSource.Listeners.Add(trace);
        PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning;
        var cultures = onlyCulture is null ? SupportedUiCultures.All : new[] { onlyCulture };
        var themes = new[] { AppTheme.Light, AppTheme.Dark };
        var scales = new[] { 1d, 2d };
        var factories = new Dictionary<string, Func<Window>>
        {
            ["advanced-settings"] = () => new AdvancedSettingsWindow(1920, 1080, true),
            ["startup-error"] = () => new StartupErrorWindow(new DllNotFoundException("UI audit fixture"), @"C:\Audit\startup.log"),
            ["window-style"] = () => new WindowStyleSettingsWindow(1, _ => true, true, _ => true),
            ["component-download"] = () => new ComponentDownloadWindow(previewOnly: true),
        };
        foreach (var name in new[] { "AppPromptWindow", "CaptureRecoveryWindow", "BluetoothControlNoticeWindow", "BluetoothConnectionWindow",
                     "BluetoothClientBindingWindow", "AirPlayDeviceSelectionWindow", "TextInputWindow", "InstanceConflictWindow", "ProtectedContentNoticeWindow" })
        {
            var type = typeof(App).Assembly.GetType("IPhoneMirror.App.Windows." + name)!;
            factories[name] = () =>
            {
                type.GetMethod("ShowDeveloperPreview", BindingFlags.Static | BindingFlags.NonPublic, null, [typeof(Window)], null)!.Invoke(null, [owner]);
                return app.Windows.Cast<Window>().Last(w => w != owner && w.IsVisible);
            };
        }
        foreach (var step in Enum.GetValues<MappingWizardStep>())
            factories["keyboard-mapping-" + step] = () =>
            {
                var entry = new KeyboardMappingEntry { Key = new MappedKey(0x41, 30, false), Action = MappedTouchAction.LongPress };
                var window = new KeyboardMappingEditorWindow(entry, [], _ => null, _ => null, () => { }, (_, _) => null);
                while (window.Wizard.Current != step)
                    if (!window.Wizard.MoveNext()) throw new InvalidOperationException("Cannot reach mapping audit step: " + step);
                return window;
            };
        try
        {
            foreach (var culture in cultures)
            foreach (var theme in themes)
            foreach (var scale in scales)
            {
                SetAuditCulture(culture); ThemeService.Apply(theme);
                AccessibilityAppearance.Apply(app, scale, false);
                foreach (var (surface, create) in factories)
                {
                    var id = $"{culture}-{theme}-{scale}-{surface}";
                    try
                    {
                        var window = create();
                        if (!window.IsVisible) { window.Owner = owner; window.ShowInTaskbar = false; window.Show(); }
                        AdvanceDispatcher(TimeSpan.FromMilliseconds(240)); window.UpdateLayout();
                        if (window is AdvancedSettingsWindow)
                        {
                            foreach (var field in new[] { "WidthBox", "HeightBox" })
                            {
                                var input = (TextBox)window.FindName(field);
                                var viewport = Ancestors(input).OfType<ScrollViewer>().First();
                                var bounds = input.TransformToAncestor(viewport).TransformBounds(new Rect(input.RenderSize));
                                InteractionAssert(bounds.Top >= 0 && bounds.Bottom <= viewport.ActualHeight + 1,
                                    "Resolution input is below the initial viewport: " + id + "/" + field);
                            }
                            var widthInput = (TextBox)window.FindName("WidthBox");
                            var originalWidth = widthInput.Text;
                            widthInput.Text = "invalid";
                            Visuals(window).OfType<Button>().Single(button => button.IsDefault)
                                .RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            AdvanceDispatcher(TimeSpan.FromMilliseconds(30)); window.UpdateLayout();
                            var error = (TextBlock)window.FindName("ErrorText");
                            var errorViewport = Ancestors(error).OfType<ScrollViewer>().First();
                            var errorBounds = error.TransformToAncestor(errorViewport).TransformBounds(new Rect(error.RenderSize));
                            InteractionAssert(error.Text.Length > 0 && errorBounds.Top >= 0 && errorBounds.Bottom <= errorViewport.ActualHeight + 1,
                                "Resolution validation feedback is outside the visible viewport: " + id);
                            if (onlyCulture is not null)
                                SaveWindowRender(window, Path.Combine(output, id + "-invalid.png"));
                            widthInput.Text = originalWidth; error.Text = string.Empty;
                            errorViewport.ScrollToHome(); window.UpdateLayout();
                        }
                        if (window is BluetoothControlNoticeWindow && scale == 2)
                            InteractionAssert(window.ActualWidth >= 680,
                                "Enlarged Bluetooth instructions retained a narrow fixed width: " + id);
                        AuditAdaptiveLayout(window, id, findings);
                        AssertVisibleButtonsFit(window);
                        results.Add(new { culture, theme = theme.ToString(), textScale = scale, surface, window = window.GetType().Name,
                            width = window.ActualWidth, height = window.ActualHeight });
                        // Retain visual evidence for the longest script at enlarged text size.
                        if (onlyCulture is not null || culture == "ja-JP" && scale == 2)
                            SaveWindowRender(window, Path.Combine(output, id + ".png"));
                    }
                    catch (Exception error) { failures.Add(id + ": " + error.GetBaseException().Message); }
                    finally
                    {
                        foreach (var window in app.Windows.Cast<Window>().Where(w => w != owner).ToArray()) CloseAuditWindow(window);
                    }
                }
            }
        }
        finally
        {
            PresentationTraceSources.DataBindingSource.Listeners.Remove(trace);
            File.WriteAllText(Path.Combine(output, "standalone-results.json"), JsonSerializer.Serialize(new
            {
                cultures, themes = themes.Select(t => t.ToString()), textScales = scales, surfaces = factories.Keys,
                expectedCombinations = cultures.Count * themes.Length * scales.Length * factories.Count,
                actualCombinations = results.Count, results, failures, layoutFindings = findings, bindingErrors = trace.Messages,
                nativeCoverage = new[] {
                    new { surfaces = "FirstRunSetupWindow (all branches)", command = "--first-run-setup", prerequisite = "native Core payload" },
                    new { surfaces = "TrayPanelWindow", command = "--tray-mode", prerequisite = "native Core payload" },
                    new { surfaces = "MainWindow,DeviceBindingWindow,media output and control errors", command = "--ui-audit / --control-error-presentation", prerequisite = "native Core payload" },
                },
            }, new JsonSerializerOptions { WriteIndented = true }));
            owner.Close(); app.Shutdown();
        }
        foreach (var failure in failures.Concat(findings)) Console.Error.WriteLine(failure);
        Console.WriteLine($"Standalone UI: {results.Count} combinations, {failures.Count} failures, {findings.Count} layout findings, {trace.Messages.Count} binding diagnostics.");
        return failures.Count == 0 && findings.Count == 0 && trace.Messages.Count == 0 ? 0 : 1;
    }

}
