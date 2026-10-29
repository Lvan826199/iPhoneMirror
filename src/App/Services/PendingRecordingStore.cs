using System.IO;

namespace IPhoneMirror.App.Services;

internal static class PendingRecordingStore
{
    private const string PartialSuffix = ".partial.mp4";

    internal static string DefaultDirectory => Path.Combine(
        Path.GetTempPath(), "iPhoneMirror", "PendingRecordings");

    internal static string CreatePath()
    {
        Directory.CreateDirectory(DefaultDirectory);
        return Path.Combine(DefaultDirectory,
            $"iPhoneMirror_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid():N}.mp4");
    }

    internal static string CreateStagingPath(string completedPath)
    {
        var directory = Path.GetDirectoryName(completedPath);
        var name = Path.GetFileNameWithoutExtension(completedPath);
        if (string.IsNullOrWhiteSpace(directory) || string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A complete recording path is required.",
                nameof(completedPath));
        return Path.Combine(directory, name + PartialSuffix);
    }

    internal static async Task CopyAndDeleteAsync(string pendingPath, string savedPath)
    {
        // Windows must be able to delete the source after both streams close.
        await using (var source = new FileStream(pendingPath, FileMode.Open,
            FileAccess.Read, FileShare.Read, 1024 * 1024,
            FileOptions.Asynchronous | FileOptions.SequentialScan))
        await using (var destination = new FileStream(savedPath, FileMode.Create,
            FileAccess.Write, FileShare.None, 1024 * 1024, FileOptions.Asynchronous))
        {
            await source.CopyToAsync(destination);
            await destination.FlushAsync();
        }
        File.Delete(pendingPath);
        File.Delete(pendingPath + ".finalized");
    }

    internal static string PrepareStagingPath(string completedPath)
    {
        var staging = CreateStagingPath(completedPath);
        if (File.Exists(staging) && File.Exists(staging + ".finalized"))
            throw new IOException($"Save the retained recording before recording again: {staging}");
        File.Delete(staging + ".finalized");
        File.Delete(staging);
        return staging;
    }

    internal static string? ResolvePath(string? completedPath)
    {
        if (string.IsNullOrWhiteSpace(completedPath)) return null;
        var staging = CreateStagingPath(completedPath);
        if (File.Exists(staging) && File.Exists(staging + ".finalized")) return staging;
        return File.Exists(completedPath) ? completedPath : null;
    }

    internal static void PublishFinalized(string stagingPath, string destination)
    {
        // A marker distinguishes a fully muxed file from an interrupted MP4.
        // Keep it until the rename succeeds so a failed publish is recoverable.
        File.WriteAllText(stagingPath + ".finalized", string.Empty);
        File.Move(stagingPath, destination, overwrite: false);
        File.Delete(stagingPath + ".finalized");
    }

    internal static string? FindLatest(string? directory = null)
    {
        directory ??= DefaultDirectory;
        if (!Directory.Exists(directory)) return null;
        try
        {
            return new DirectoryInfo(directory)
                .EnumerateFiles("*.mp4", SearchOption.TopDirectoryOnly)
                .Where(file => file.Length > 0 &&
                    (!file.Name.EndsWith(PartialSuffix,
                        StringComparison.OrdinalIgnoreCase) ||
                     File.Exists(file.FullName + ".finalized")))
                .OrderByDescending(file => file.LastWriteTimeUtc)
                .Select(file => file.FullName)
                .FirstOrDefault();
        }
        catch (Exception error) when (error is IOException or
                                      UnauthorizedAccessException)
        {
            DiagnosticLogger.Exception("recording", "pending_recording_scan_failed",
                error, ("directory", Path.GetFileName(directory)));
            return null;
        }
    }
}
