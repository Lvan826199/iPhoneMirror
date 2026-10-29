using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using IPhoneMirror.App.Interop;
using IPhoneMirror.App.Services;

namespace IPhoneMirror.App.Runtime.Tests;

internal static partial class Program
{
    // Explicit hardware test. Uses the production USB session, BGRA readback,
    // publisher and registered Windows virtual camera, with no native substitutes.
    private static int RunVirtualCameraLiveValidation(string output, uint width,
        uint height, int seconds)
    {
        Directory.CreateDirectory(output);
        var app = new App { IsUiPreviewMode = true,
            ShutdownMode = ShutdownMode.OnExplicitShutdown };
        app.InitializeComponent();
        try
        {
            return RunVirtualCameraLiveValidationAsync(output, width, height,
                seconds).GetAwaiter().GetResult();
        }
        finally { app.Shutdown(); }
    }

    private static async Task<int> RunVirtualCameraLiveValidationAsync(
        string output, uint width, uint height, int seconds)
    {
        using var core = new NativeCore();
        var device = core.GetDevices(false).FirstOrDefault(device =>
            !string.IsNullOrWhiteSpace(device.Udid) &&
            device.ConnectionType != "AirPlay");
        if (string.IsNullOrWhiteSpace(device.Udid))
            throw new InvalidOperationException("No wired iPhone is available.");
        var created = core.CreateDeviceSession(device.Udid, 0, 0, 60,
            playAudio: false, volume: 0);
        if (!created.Success || created.Handle is null)
            throw new InvalidOperationException(created.Message);
        using var session = created.Handle;
        var observations = new List<object>();
        try
        {
            var ready = Stopwatch.StartNew();
            while (true)
            {
                var status = core.GetDeviceSessionStatus(session);
                if (status.State == CaptureState.Error)
                    throw new InvalidOperationException(status.Message);
                if (status.State == CaptureState.Streaming && status.VideoFrames > 5)
                {
                    Console.WriteLine($"Real USB capture ready: {status.Width}x{status.Height}, {status.Fps:F2} fps");
                    break;
                }
                if (ready.Elapsed > TimeSpan.FromSeconds(60))
                    throw new TimeoutException("Real USB capture did not become ready.");
                await Task.Delay(250).ConfigureAwait(false);
            }

            long reads = 0, timestampChanges = 0, pixelChanges = 0, readTicks = 0;
            long? previousTimestamp = null;
            ulong? previousPixels = null;
            await using var camera = new VirtualCameraService((handle, w, h) =>
            {
                var started = Stopwatch.GetTimestamp();
                var frame = core.GetDeviceOutputFrame(session, w, h);
                Interlocked.Add(ref readTicks, Stopwatch.GetTimestamp() - started);
                Interlocked.Increment(ref reads);
                if (frame is not null)
                {
                    if (previousTimestamp != frame.Timestamp100Ns)
                        Interlocked.Increment(ref timestampChanges);
                    previousTimestamp = frame.Timestamp100Ns;
                    // Measure actual source pixels as well as timestamps.
                    // A phone can advance its media clock while retaining the
                    // same picture. Sample the center, omitting status controls.
                    ulong fingerprint = 14695981039346656037UL;
                    for (var y = 104U; y + 104U < frame.Height; y += 8)
                    {
                        var row = checked((int)(y * frame.Stride));
                        for (var x = 8U; x + 8U < frame.Width; x += 8)
                        {
                            var pixel = row + checked((int)(x * 4));
                            fingerprint = unchecked((fingerprint ^ frame.Pixels[pixel]) * 1099511628211UL);
                            fingerprint = unchecked((fingerprint ^ frame.Pixels[pixel + 1]) * 1099511628211UL);
                            fingerprint = unchecked((fingerprint ^ frame.Pixels[pixel + 2]) * 1099511628211UL);
                        }
                    }
                    if (previousPixels != fingerprint) Interlocked.Increment(ref pixelChanges);
                    previousPixels = fingerprint;
                }
                return frame;
            }, _ => core.GetDeviceSessionLatestFrameTimestamp(session));
            camera.StatusChanged += (message, failed) =>
                Console.WriteLine($"Virtual camera: {message}, failed={failed}");
            await camera.StartAsync(session.RawHandle, width, height, 60,
                CancellationToken.None).ConfigureAwait(false);
            File.WriteAllText(Path.Combine(output, "camera-ready.json"),
                JsonSerializer.Serialize(new { width, height, fps = 60,
                    device = device.ProductType }));
            var clock = Stopwatch.StartNew();
            var interval = Stopwatch.StartNew();
            while (clock.Elapsed < TimeSpan.FromSeconds(seconds) &&
                   !File.Exists(Path.Combine(output, "stop")))
            {
                await Task.Delay(5000).ConfigureAwait(false);
                if (!camera.IsRunning)
                    throw new InvalidOperationException("The real virtual camera stopped early.");
                var status = core.GetDeviceSessionStatus(session);
                var elapsed = interval.Elapsed.TotalSeconds;
                var count = Interlocked.Exchange(ref reads, 0);
                var changed = Interlocked.Exchange(ref timestampChanges, 0);
                var pixelsChanged = Interlocked.Exchange(ref pixelChanges, 0);
                var ticks = Interlocked.Exchange(ref readTicks, 0);
                var observed = new {
                    seconds = Math.Round(clock.Elapsed.TotalSeconds, 2),
                    captureFps = Math.Round(status.Fps, 2),
                    captureFrames = status.VideoFrames,
                    readFps = Math.Round(count / elapsed, 2),
                    sourceTimestampFps = Math.Round(changed / elapsed, 2),
                    sourcePixelChangeFps = Math.Round(pixelsChanged / elapsed, 2),
                    averageReadMs = count == 0 ? 0 :
                        Math.Round(ticks * 1000.0 / Stopwatch.Frequency / count, 2)
                };
                interval.Restart();
                observations.Add(observed);
                Console.WriteLine(JsonSerializer.Serialize(observed));
                File.WriteAllText(Path.Combine(output, "capture-measurements.json"),
                    JsonSerializer.Serialize(observations,
                        new JsonSerializerOptions { WriteIndented = true }));
            }
            await camera.StopAsync().ConfigureAwait(false);
            return 0;
        }
        finally { core.StopDeviceSession(session); }
    }
}
