using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using IPhoneMirror.App;
using IPhoneMirror.App.Interop;

namespace IPhoneMirror.App.Runtime.Tests;

internal static partial class Program
{
    // Explicit hardware entry point; no fault injection or synthetic Ready state.
    private static int RunLiveCaptureValidation(string udid, string output)
    {
        Directory.CreateDirectory(output);
        var app = new App { IsUiPreviewMode = true, ShutdownMode = ShutdownMode.OnExplicitShutdown };
        app.InitializeComponent();
        var results = new List<object>();
        var completedCycles = 0;
        string? failure = null;
        try
        {
            using var core = new NativeCore();
            for (var cycle = 1; cycle <= 2; cycle++)
            {
                var start = core.StartCapture(udid, playAudio: false);
                if (!start.Success) throw new InvalidOperationException(start.Message);
                try
                {
                    var timer = Stopwatch.StartNew();
                    NativeCaptureStatus status;
                    do
                    {
                        Thread.Sleep(250); status = core.GetCaptureStatus();
                        if (status.State == CaptureState.Error) throw new InvalidOperationException(status.Message);
                    } while ((status.State != CaptureState.Streaming || status.VideoFrames < 5) && timer.Elapsed < TimeSpan.FromSeconds(90));
                    InteractionAssert(status.State == CaptureState.Streaming && status.VideoFrames >= 5,
                        "Live capture did not receive decoded video.");
                    var readySeconds = timer.Elapsed.TotalSeconds;
                    var frames = status.VideoFrames;
                    Thread.Sleep(5000);
                    status = core.GetCaptureStatus();
                    InteractionAssert(status.State == CaptureState.Streaming && status.VideoFrames > frames,
                        "Live capture stopped advancing frames.");
                    var frame = core.GetLatestVideoFrame();
                    InteractionAssert(frame is { Width: > 0, Height: > 0 } && frame.Pixels.Length >= frame.Stride * frame.Height,
                        "Live decoded frame readback is incomplete.");
                    results.Add(new { cycle, readySeconds, width = status.Width, height = status.Height,
                        fps = status.Fps, frames = status.VideoFrames, audioPackets = status.AudioPackets,
                        readbackBytes = frame!.Pixels.Length });
                    Console.WriteLine($"USB capture cycle {cycle}: {status.Width}x{status.Height}, frames={status.VideoFrames}, audio={status.AudioPackets}, ready={readySeconds:F2}s.");
                }
                finally { core.StopCapture(); }
                InteractionAssert(core.GetCaptureStatus().State is CaptureState.Stopped or CaptureState.Idle,
                    "Capture cleanup did not settle before restart.");
                completedCycles++;
            }
            return 0;
        }
        catch (Exception error)
        {
            failure = error.GetBaseException().Message;
            throw;
        }
        finally
        {
            File.WriteAllText(Path.Combine(output, "capture-results.json"), JsonSerializer.Serialize(
                new { expectedCycles = 2, actualCycles = completedCycles,
                    passed = completedCycles == 2 && failure is null, failure, results },
                new JsonSerializerOptions { WriteIndented = true }));
            app.Shutdown();
        }
    }
}
