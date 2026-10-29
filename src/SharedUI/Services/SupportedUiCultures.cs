namespace IPhoneMirror.UI.Services;

internal static class SupportedUiCultures
{
    internal static IReadOnlyList<string> All { get; } = Array.AsReadOnly(
        new[] { "zh-CN", "zh-HK", "zh-TW", "en-US", "ja-JP" });
}
