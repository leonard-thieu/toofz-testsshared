// https://gist.github.com/SeanFeldman/f0d4dde66b537896ed388331e00b1d88
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace toofz.TestsShared
{
    // Start/stop azure storage emulator from code:
    // http://stackoverflow.com/questions/7547567/how-to-start-azure-storage-emulator-from-within-a-program
    [ExcludeFromCodeCoverage]
    public static class AzureStorageEmulatorManager
    {
        const string AzureStorageEmulatorPath = @"C:\Program Files (x86)\Microsoft SDKs\Azure\Storage Emulator\AzureStorageEmulator.exe";
        const string Win7ProcessName = "WAStorageEmulator";
        const string Win8ProcessName = "WASTOR~1";
        const string Win10ProcessName = "AzureStorageEmulator";

        static readonly ProcessStartInfo startStorageEmulator = new ProcessStartInfo
        {
            FileName = AzureStorageEmulatorPath,
            Arguments = "start",
            UseShellExecute = false,
        };

        static readonly ProcessStartInfo stopStorageEmulator = new ProcessStartInfo
        {
            FileName = AzureStorageEmulatorPath,
            Arguments = "stop",
            UseShellExecute = false,
        };

        static Process GetProcess()
        {
            return Process.GetProcessesByName(Win7ProcessName).FirstOrDefault() ??
                   Process.GetProcessesByName(Win8ProcessName).FirstOrDefault() ??
                   Process.GetProcessesByName(Win10ProcessName).FirstOrDefault();
        }

        /// <summary>
        /// Gets a value indicating if Azure Storage Emulator is started.
        /// </summary>
        /// <returns>
        /// true, if Azure Storage Emulator is started; otherwise, false.
        /// </returns>
        public static bool IsStarted() => GetProcess() != null;

        /// <summary>
        /// Starts Azure Storage Emulator if it is not already started.
        /// </summary>
        public static void Start()
        {
            if (IsStarted()) { return; }

            using (var process = Process.Start(startStorageEmulator))
            {
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Stops Azure Storage Emulator.
        /// </summary>
        public static void Stop()
        {
            if (!IsStarted()) { return; }

            using (var process = Process.Start(stopStorageEmulator))
            {
                process.WaitForExit();
            }
        }
    }
}