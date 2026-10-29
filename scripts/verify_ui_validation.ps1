[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$RuntimeDirectory,
    [Parameter(Mandatory)][string]$OutputDirectory,
    [ValidateSet('errors', 'first-run', 'assessment', 'tray', 'tray-theme', 'mapping',
        'mapping-wizard', 'ui-performance', 'workspace-performance', 'workspace-layout',
        'workspace-regression', 'native-preview', 'resources', 'accessibility', 'scrollbars', 'balanced')]
    [string[]]$Check = @('errors', 'first-run', 'assessment', 'tray', 'tray-theme',
        'mapping', 'mapping-wizard', 'ui-performance', 'workspace-performance',
        'workspace-layout', 'workspace-regression', 'native-preview', 'resources', 'accessibility', 'scrollbars', 'balanced'),
    [ValidateSet('zh-CN','zh-HK','zh-TW','en-US','ja-JP')][string]$Culture,
    [ValidateRange(1, 2.25)][double]$TextScale = 1,
    [ValidateRange(30, 3600)][int]$TimeoutSeconds = 600
)
$ErrorActionPreference = 'Stop'
$runtime = [IO.Path]::GetFullPath($RuntimeDirectory)
$output = [IO.Path]::GetFullPath($OutputDirectory)
$executable = Join-Path $runtime 'IPhoneMirror.App.Runtime.Tests.exe'
if (-not (Test-Path -LiteralPath $executable -PathType Leaf)) { throw "Runtime tests missing: $executable" }
if (-not (Test-Path -LiteralPath (Join-Path $runtime 'iPhoneMirror.Core.dll') -PathType Leaf)) {
    throw "The real native Core payload is required: $runtime"
}
New-Item -ItemType Directory -Path $output -Force | Out-Null
$commands = @{
    'errors' = @('--control-error-presentation')
    'first-run' = @('--first-run-setup', (Join-Path $output 'first-run'))
    'assessment' = @('--setup-assessment', (Join-Path $output 'assessment'))
    'tray' = @('--tray-mode', (Join-Path $output 'tray'))
    'tray-theme' = @('--tray-startup-theme', (Join-Path $output 'tray-theme'))
    'mapping' = @('--keyboard-mapping', (Join-Path $output 'mapping'))
    'mapping-wizard' = @('--keyboard-mapping-wizard', (Join-Path $output 'mapping-wizard'))
    'ui-performance' = @('--ui-performance', (Join-Path $output 'ui-performance'))
    'workspace-performance' = @('--workspace-performance', (Join-Path $output 'workspace-performance'))
    'workspace-layout' = @('--ui-audit', (Join-Path $output 'workspace-layout'))
    'workspace-regression' = @('--workspace-regression')
    'native-preview' = @('--preview-shell-ui-audit', (Join-Path $output 'native-preview'))
    'resources' = @('--ui-resource-regressions', (Join-Path $output 'resources'))
    'accessibility' = @('--ui-accessibility-audit', (Join-Path $output 'accessibility'))
    'scrollbars' = @('--scrollbar-layout-audit', (Join-Path $output 'scrollbars'))
    'balanced' = @('--balanced-ui', (Join-Path $output 'balanced'))
}
if ($Culture) { $commands['workspace-layout'] += @('--culture', $Culture) }
$results = [Collections.Generic.List[object]]::new()
foreach ($name in $Check) {
    $start = [Diagnostics.ProcessStartInfo]::new($executable)
    $start.WorkingDirectory = (Get-Location).Path
    $start.UseShellExecute = $false
    $start.CreateNoWindow = $true
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    foreach ($argument in $commands[$name]) { $start.ArgumentList.Add($argument) }
    $start.Environment['IPHONE_MIRROR_UI_AUDIT_TEXT_SCALE'] = $TextScale.ToString([Globalization.CultureInfo]::InvariantCulture)
    $start.Environment['IPHONE_MIRROR_UI_AUDIT_QUICK'] = '0'
    # The tests exercise the injection rejection separately. SDK-added runtime
    # host overrides must not make the clean helper fixtures fail before testing.
    foreach ($key in @($start.Environment.Keys)) {
        if ($key -match '^(DOTNET_|COMPLUS_|COR_|CORECLR_|DEVPATH$|APPDOMAIN_MANAGER_|CLRConfigFile$)') {
            $start.Environment.Remove($key) | Out-Null
        }
    }
    Write-Host "Running $name"
    $timer = [Diagnostics.Stopwatch]::StartNew()
    $process = [Diagnostics.Process]::new()
    $process.StartInfo = $start
    $process.Start() | Out-Null
    $stdout = $process.StandardOutput.ReadToEndAsync()
    $stderr = $process.StandardError.ReadToEndAsync()
    $finished = $process.WaitForExit($TimeoutSeconds * 1000)
    if (-not $finished) { $process.Kill($true); $process.WaitForExit() }
    $log = $stdout.GetAwaiter().GetResult() + $stderr.GetAwaiter().GetResult()
    [IO.File]::WriteAllText((Join-Path $output "$name.log"), $log)
    $record = [pscustomobject]@{
        check = $name; arguments = $commands[$name]; exitCode = $process.ExitCode
        timedOut = -not $finished; passed = $finished -and $process.ExitCode -eq 0
        seconds = [Math]::Round($timer.Elapsed.TotalSeconds, 2)
        log = Join-Path $output "$name.log"
    }
    $results.Add($record)
    [IO.File]::WriteAllText((Join-Path $output 'results.json'),
        (ConvertTo-Json -InputObject @($results.ToArray()) -Depth 5))
    Write-Host "$name : passed=$($record.passed), exit=$($record.exitCode), seconds=$($record.seconds)"
    $process.Dispose()
}
if (@($results | Where-Object { -not $_.passed }).Count -gt 0) { exit 1 }
