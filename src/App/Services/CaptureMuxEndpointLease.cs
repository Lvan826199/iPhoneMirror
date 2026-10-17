using System.Globalization;

namespace IPhoneMirror.App.Services;

// A child-owned broker can be shared by the read-only native orientation
// helper. Only clear the exact value this owner published.
internal sealed class CaptureMuxEndpointLease : IDisposable
{
    private readonly object _gate = new();
    private string? _key;
    private string? _address;

    internal static string? KeyFor(string? udid)
    {
        var identity = udid?.Replace("-", "").ToUpperInvariant();
        return string.IsNullOrEmpty(identity) || identity.Any(c => !char.IsAsciiHexDigit(c))
            ? null : "IPHONE_MIRROR_CAPTURE_MUX_" + identity;
    }

    internal bool Publish(string? udid, string? address)
    {
        var key = KeyFor(udid);
        const string prefix = "127.0.0.1:";
        if (key is null || address is null || !address.StartsWith(prefix, StringComparison.Ordinal) ||
            !uint.TryParse(address.AsSpan(prefix.Length), NumberStyles.None, CultureInfo.InvariantCulture,
                out var port) || port is 0 or > 65535) return false;
        lock (_gate)
        {
            Clear();
            Environment.SetEnvironmentVariable(key, address);
            _key = key;
            _address = address;
        }
        return true;
    }

    private void Clear()
    {
        if (_key is not null && Environment.GetEnvironmentVariable(_key) == _address)
            Environment.SetEnvironmentVariable(_key, null);
        _key = _address = null;
    }
    public void Dispose() { lock (_gate) Clear(); }
}
