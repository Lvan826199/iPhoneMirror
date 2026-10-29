using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using IPhoneMirror.App;
using IPhoneMirror.App.Services;
using IPhoneMirror.App.Updater;
using IPhoneMirror.App.ViewModels;
using IPhoneMirror.App.Windows;
using IPhoneMirror.UI.Services;

namespace IPhoneMirror.App.Runtime.Tests;

internal static partial class Program
{
    private static int RunUiAccessibilityAudit(string output)
    {
        Directory.CreateDirectory(output);
        var app = new App { IsUiPreviewMode = true, ShutdownMode = ShutdownMode.OnExplicitShutdown };
        app.InitializeComponent();
        var owner = CreateWorkspaceTestWindow(app, includeNativePreview: false);
        var vm = (MainViewModel)owner.DataContext;
        var results = new List<object>();
        var failures = new List<string>();
        var environment = new
        {
            os = Environment.OSVersion.VersionString,
            systemHighContrast = SystemParameters.HighContrast,
            systemClientAreaAnimation = SystemParameters.ClientAreaAnimation,
            virtualScreen = new { SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenTop,
                SystemParameters.VirtualScreenWidth, SystemParameters.VirtualScreenHeight },
            workArea = SystemParameters.WorkArea.ToString(),
            ownerDpi = VisualTreeHelper.GetDpi(owner).DpiScaleX,
        };
        try
        {
            foreach (var culture in SupportedUiCultures.All)
            foreach (var theme in new[] { AppTheme.Light, AppTheme.Dark })
            foreach (var darkContrast in new[] { false, true })
            {
                var id = $"{culture}-{theme}-{(darkContrast ? "black" : "white")}";
                FirstRunSetupWindow? window = null;
                ResourceDictionary? palette = null;
                try
                {
                    SetAuditCulture(culture); ThemeService.Apply(theme);
                    AccessibilityAppearance.Apply(app, 2, true);
                    var background = darkContrast ? Brushes.Black : Brushes.White;
                    var foreground = darkContrast ? Brushes.White : Brushes.Black;
                    palette = new ResourceDictionary
                    {
                        ["DialogSurfaceBrush"] = background, ["TextBrush"] = foreground,
                        ["MutedTextBrush"] = foreground,
                    };
                    app.Resources.MergedDictionaries.Add(palette);
                    var store = new FirstRunSetupStore(Path.Combine(output, "unused-preview-checkpoint.json"));
                    window = new FirstRunSetupWindow(vm, store, previewOnly: true) { Owner = owner };
                    window.Show(); AdvanceDispatcher(TimeSpan.FromMilliseconds(100)); window.UpdateLayout();
                    var surface = (Border)window.Template.FindName("RoundedWindowSurface", window);
                    InteractionAssert(ReferenceEquals(surface.Background, background) && ReferenceEquals(window.Foreground, foreground),
                        "The actual setup shell masks the contrast surface or text: " + id);
                    var heading = (TextBlock)window.FindName("Heading");
                    InteractionAssert(heading.FontSize >= 36 && heading.FontSize <= 48,
                        "Actual welcome title must enlarge without overwhelming the page: " + id);
                    var next = (Button)window.FindName("Next");
                    next.BringIntoView(); AdvanceDispatcher(TimeSpan.FromMilliseconds(50));
                    next.Focus(); window.UpdateLayout();
                    InteractionAssert(next.IsKeyboardFocused, "Setup navigation is not keyboard reachable: " + id);
                    var bounds = next.TransformToAncestor(window).TransformBounds(new Rect(next.RenderSize));
                    InteractionAssert(bounds.Top >= 0 && bounds.Bottom <= window.ActualHeight + 1,
                        "Setup keyboard action remains clipped after BringIntoView: " + id);
                    var peer = UIElementAutomationPeer.CreatePeerForElement(next)!;
                    InteractionAssert(!string.IsNullOrWhiteSpace(peer.GetName()) && peer.GetPattern(PatternInterface.Invoke) is IInvokeProvider,
                        "Setup Next is missing its UI Automation name or invoke pattern: " + id);
                    InteractionAssert(next.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous)) &&
                        Keyboard.FocusedElement is not null && !next.IsKeyboardFocused,
                        "Setup keyboard traversal is trapped: " + id);
                    var close = Visuals(window).OfType<Button>().Single(button =>
                        System.Windows.Automation.AutomationProperties.GetName(button) == (string)app.FindResource("Close"));
                    var closePeer = UIElementAutomationPeer.CreatePeerForElement(close)!;
                    ((IInvokeProvider)closePeer.GetPattern(PatternInterface.Invoke)!).Invoke();
                    AdvanceDispatcher(TimeSpan.FromMilliseconds(50));
                    InteractionAssert(window.IsVisible && ((Border)window.FindName("ExitPanel")).IsVisible,
                        "UI Automation close discarded setup progress without confirmation: " + id);
                    if (culture == "ja-JP") SaveWindowRender(window, Path.Combine(output, id + ".png"));
                    results.Add(new { culture, theme = theme.ToString(), contrast = darkContrast ? "black" : "white",
                        textScale = 2, actualHeadingSize = heading.FontSize, nextAutomationName = peer.GetName(),
                        keyboardTraversal = true, closeConfirmation = true });
                }
                catch (Exception error) { failures.Add(id + ": " + error.GetBaseException().Message); }
                finally
                {
                    if (window is not null)
                    {
                        typeof(FirstRunSetupWindow).GetField("_allowClose", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(window, true);
                        window.Close();
                    }
                    if (palette is not null) app.Resources.MergedDictionaries.Remove(palette);
                }
            }
        }
        finally
        {
            File.WriteAllText(Path.Combine(output, "results.json"), JsonSerializer.Serialize(new
            {
                environment, expectedCombinations = 20, actualCombinations = results.Count, results, failures,
                limits = new[] { "Contrast palettes are injected without changing Windows settings.",
                    "UI Automation provider and keyboard tests do not certify audible Narrator output.",
                    "Actual multi-monitor DPI transitions require multiple monitors with different DPI." },
            }, new JsonSerializerOptions { WriteIndented = true }));
            CloseWorkspaceTestWindow(owner); app.Shutdown();
        }
        foreach (var failure in failures) Console.Error.WriteLine(failure);
        Console.WriteLine($"UI accessibility: {results.Count}/20 actual setup shells, {failures.Count} failures; inverse palettes, 200% title, keyboard traversal, UIA names/invoke and safe close.");
        return failures.Count == 0 && results.Count == 20 ? 0 : 1;
    }
}
