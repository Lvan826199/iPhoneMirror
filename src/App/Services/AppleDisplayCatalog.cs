using System.IO;
using System.Text.Json;

namespace IPhoneMirror.App.Services;

internal sealed record AppleDisplaySpecification(
    string Name, string Family, IReadOnlyList<string> Identifiers,
    uint Width, uint Height, string AppleSpecUrl)
{
    internal uint LongEdge => Math.Max(Width, Height);
}

// Both native and managed tables are generated/read from the same checked-in
// source. Reading device metadata never requires internet access at runtime.
internal static class AppleDisplayCatalog
{
    internal static IReadOnlyList<AppleDisplaySpecification> Products { get; } = Load();
    private static readonly IReadOnlyDictionary<string, AppleDisplaySpecification> ByIdentifier =
        Products.SelectMany(product => product.Identifiers.Select(id => (id, product)))
            .ToDictionary(entry => entry.id, entry => entry.product, StringComparer.Ordinal);

    internal static AppleDisplaySpecification? Find(string? productType) =>
        productType is not null && ByIdentifier.TryGetValue(productType, out var product) ? product : null;

    private static IReadOnlyList<AppleDisplaySpecification> Load()
    {
        using var stream = typeof(AppleDisplayCatalog).Assembly.GetManifestResourceStream(
            "IPhoneMirror.App.Devices.AppleDisplayCatalog.json")
            ?? throw new InvalidDataException("Apple display catalog resource is missing.");
        using var document = JsonDocument.Parse(stream);
        if (document.RootElement.GetProperty("schema").GetInt32() != 1)
            throw new InvalidDataException("Unsupported Apple display catalog schema.");
        var products = document.RootElement.GetProperty("products").EnumerateArray().Select(row =>
            new AppleDisplaySpecification(row.GetProperty("name").GetString()!,
                row.GetProperty("family").GetString()!,
                Array.AsReadOnly(row.GetProperty("identifiers").EnumerateArray().Select(id => id.GetString()!).ToArray()),
                row.GetProperty("width").GetUInt32(), row.GetProperty("height").GetUInt32(),
                row.GetProperty("appleSpecUrl").GetString()!)).ToArray();
        if (products.Any(product => product.Width < 320 || product.Width > product.Height || product.Height > 8192))
            throw new InvalidDataException("Invalid Apple display catalog dimensions.");
        return Array.AsReadOnly(products);
    }
}
