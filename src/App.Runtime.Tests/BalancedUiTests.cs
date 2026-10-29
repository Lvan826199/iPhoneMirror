using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IPhoneMirror.App;
using IPhoneMirror.App.Services;
using IPhoneMirror.App.Updater;
using IPhoneMirror.UI.Controls;
using IPhoneMirror.UI.Services;

namespace IPhoneMirror.App.Runtime.Tests;

internal static partial class Program
{
    private static int RunBalancedUiTests(string output)
    {
        Directory.CreateDirectory(output);
        var app = new App { IsUiPreviewMode = true, ShutdownMode = ShutdownMode.OnExplicitShutdown };
        app.InitializeComponent();
        var owner = CreateWorkspaceTestWindow(app, includeNativePreview: false);
        var open = typeof(MainWindow).GetMethod("OpenDeveloperSurface", BindingFlags.Instance | BindingFlags.NonPublic)!;
        var results = new List<object>();
        var findings = new HashSet<string>();
        try
        {
            foreach (var culture in SupportedUiCultures.All)
            foreach (var theme in new[] { AppTheme.Light, AppTheme.Dark })
            foreach (var scale in new[] { 1d, 2d })
            foreach (var surface in new[] { "shortcut-settings", "device-binding", "media-output", "about" })
            {
                SetAuditCulture(culture); ThemeService.Apply(theme); AccessibilityAppearance.Apply(app, scale, false);
                var id = $"{culture}-{theme}-{scale}-{surface}";
                Window? window = null;
                try
                {
                    open.Invoke(owner, [surface]);
                    window = app.Windows.Cast<Window>().Last(w => w != owner && w.IsVisible);
                    AdvanceDispatcher(TimeSpan.FromMilliseconds(100)); window.UpdateLayout();
                    var close = Visuals(window).OfType<Button>().Single(RoundedWindow.GetIsChromeCloseButton);
                    InteractionAssert(close.Parent is Grid { Name: "PART_WindowActions" }, "Close button is inside the scrolling page: " + id);
                    var before = close.TransformToAncestor(window).TransformBounds(new Rect(close.RenderSize));
                    foreach (var scroll in Visuals(window).OfType<ScrollViewer>().ToArray()) scroll.ScrollToEnd();
                    AdvanceDispatcher(TimeSpan.FromMilliseconds(25)); window.UpdateLayout();
                    var after = close.TransformToAncestor(window).TransformBounds(new Rect(close.RenderSize));
                    InteractionAssert(before == after && after.Top >= 20 && window.ActualWidth - after.Right >= 24,
                        "Scrolling moved the close action or pushed it against the frame: " + id);
                    AuditScrollBarLayout(window, id, findings);
                    var sizes = Visuals(window).OfType<TextBlock>().Where(t => t.IsVisible && !string.IsNullOrWhiteSpace(t.Text) &&
                        t.FontFamily.Source.IndexOf("Fluent", StringComparison.OrdinalIgnoreCase) < 0 &&
                        t.FontFamily.Source.IndexOf("MDL2", StringComparison.OrdinalIgnoreCase) < 0 &&
                        t.Text.Length > 1).Select(t => t.FontSize).ToArray();
                    InteractionAssert(sizes.Length > 0 && sizes.Min() >= 12 * scale && sizes.Max() <= (scale == 1 ? 32 : 48),
                        $"Visible text outside the intended size hierarchy: {id}, {sizes.DefaultIfEmpty().Min()}..{sizes.DefaultIfEmpty().Max()}");
                    InteractionAssert((double)app.FindResource("BodyFontSize") == 14 * scale &&
                        (double)app.FindResource("CaptionFontSize") == 12 * scale,
                        "Reading text no longer honors the full requested scale: " + id);
                    InteractionAssert((double)app.FindResource("DialogTitleFontSize") >= 1.25 * (double)app.FindResource("BodyFontSize"),
                        "Dialog heading lost its size hierarchy: " + id);
                    if (surface == "shortcut-settings" && scale == 2)
                    {
                        var row = Visuals(window).OfType<ResponsiveFieldRow>().First();
                        var label = (TextBlock)row.Children[0];
                        var editor = (TextBox)row.Children[1];
                        InteractionAssert(editor.TranslatePoint(new Point(), row).X > label.ActualWidth && label.FontWeight == FontWeights.Normal,
                            "Enlarged shortcut fields did not use available horizontal space: " + id);
                    }
                    if (surface == "media-output")
                    {
                        var description = Visuals(window).OfType<TextBlock>().Single(text =>
                            text.IsVisible && text.Text == (string)app.FindResource("RecordDescription"));
                        InteractionAssert(description.FontWeight == FontWeights.Normal,
                            "Tab heading weight leaked into reading text: " + id);
                    }
                    if (surface is "media-output" or "about")
                    {
                        var tabs = Visuals(window).OfType<TabControl>().First();
                        var headings = tabs.Items.Cast<TabItem>().ToArray();
                        InteractionAssert(headings.Max(tab => tab.ActualWidth) - headings.Min(tab => tab.ActualWidth) < 2 &&
                            headings.Sum(tab => tab.ActualWidth + tab.Margin.Left + tab.Margin.Right) >= tabs.ActualWidth - 10,
                            "Tab headings must fill the width evenly: " + id);
                    }
                    foreach (var scroll in Visuals(window).OfType<ScrollViewer>().ToArray()) scroll.ScrollToHome();
                    window.UpdateLayout();
                    if (culture == "zh-CN") SaveWindowRender(window, Path.Combine(output, id + ".png"));
                    results.Add(new { culture, theme = theme.ToString(), scale, surface,
                        minFontSize = sizes.Min(), maxFontSize = sizes.Max(), closeBounds = before.ToString(), closeStable = true });
                }
                catch (Exception error) { findings.Add(id + ": " + error.GetBaseException().Message); }
                finally { window?.Close(); }
            }
        }
        finally
        {
            File.WriteAllText(Path.Combine(output, "results.json"), JsonSerializer.Serialize(new
            { expectedCombinations = 80, actualCombinations = results.Count, results, findings }, new JsonSerializerOptions { WriteIndented = true }));
            CloseWorkspaceTestWindow(owner); app.Shutdown();
        }
        foreach (var finding in findings) Console.Error.WriteLine(finding);
        Console.WriteLine($"Balanced UI: {results.Count}/80 combinations, {findings.Count} findings; symmetric gutters, fixed close action and typography.");
        return findings.Count == 0 && results.Count == 80 ? 0 : 1;
    }
}
