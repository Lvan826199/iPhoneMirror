using System.Reflection;
using System.Text.Json;
using IPhoneMirror.App.Services;

namespace IPhoneMirror.App.Runtime.Tests;

internal static partial class Program
{
    private static void RunControlHandshakeAuditTests()
    {
        var handle = typeof(DirectUsbInputBridge).GetMethod("HandleLine", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var fields = BindingFlags.NonPublic | BindingFlags.Instance;
        foreach (var wireless in new[] { false, true })
        foreach (var variant in new[] { "valid", "legacy-generation", "missing-protocol", "old-protocol",
                     "future-protocol", "string-protocol", "zero-generation", "negative-generation", "string-generation" })
        {
            var bridge = new DirectUsbInputBridge();
            typeof(DirectUsbInputBridge).GetField("_requestedUdid", fields)!.SetValue(bridge, "test-device");
            typeof(DirectUsbInputBridge).GetField("_requestedWireless", fields)!.SetValue(bridge, wireless);
            var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            typeof(DirectUsbInputBridge).GetField("_readySignal", fields)!.SetValue(bridge, ready);
            var payload = new Dictionary<string, object?>
            {
                ["event"] = "ready", ["protocol"] = 2, ["udid"] = "test-device",
                ["transport"] = wireless ? "wireless" : "usb", ["gateOpen"] = true,
                ["authMode"] = "direct", ["rateHz"] = 120, ["generation"] = 1,
            };
            switch (variant)
            {
                case "legacy-generation": payload.Remove("generation"); break;
                case "missing-protocol": payload.Remove("protocol"); break;
                case "old-protocol": payload["protocol"] = 1; break;
                case "future-protocol": payload["protocol"] = 3; break;
                case "string-protocol": payload["protocol"] = "2"; break;
                case "zero-generation": payload["generation"] = 0; break;
                case "negative-generation": payload["generation"] = -1; break;
                case "string-generation": payload["generation"] = "1"; break;
            }
            handle.Invoke(bridge, [JsonSerializer.Serialize(payload)]);
            var accepted = variant is "valid" or "legacy-generation";
            if (bridge.IsReady != accepted || bridge.GateOpen != accepted ||
                ready.Task.IsCompletedSuccessfully != accepted ||
                (!accepted && (bridge.LastErrorCode != "bridge_transport_mismatch" || !ready.Task.IsFaulted)))
                throw new InvalidOperationException($"Control handshake {wireless}/{variant} was classified incorrectly.");
            _ = ready.Task.Exception;
            bridge.DisposeAsync().AsTask().GetAwaiter().GetResult();
        }
        Console.WriteLine("Control handshake protocol and wire-generation checks passed (18 cases).");
    }
}
