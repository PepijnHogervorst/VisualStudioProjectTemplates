using Serilog;
using System.IO;

namespace WpfUI.Services.Initialization;
internal class InitializeLogger
{
    /// <summary>
    /// Initializes the logger to write to wrolling file - minimum level warning
    /// </summary>
    internal static void Initialize()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.File(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cremer/OPC/Logs/log.txt"),
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3} {Message:lj}{NewLine}  {Properties:j}{NewLine}  {Exception}]",
                rollingInterval: RollingInterval.Month,
                rollOnFileSizeLimit: true,
                fileSizeLimitBytes: 1000000,
                retainedFileCountLimit: 12)
            .CreateLogger();
    }
}
