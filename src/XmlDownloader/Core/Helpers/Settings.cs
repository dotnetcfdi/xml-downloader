using System.Reflection;

namespace XmlDownloader.Core.Helpers
{
    public static class Settings
    {
        #region Props

        public static bool EnableRedundantPacketWriter { get; set; } = true;
        public static string PackageExtension { get; set; } = ".Zip";

        public static string PackagesDirectory { get; set; } =  Path.Combine(Environment.CurrentDirectory, @"\PackagesDirectory");
        public static string WorkDirectory { get; set; } = Path.Combine(Assembly.GetExecutingAssembly().Location, @"\WorkDirectory");

        public static string LogsDirectory { get; set; } =
            Path.Combine(Assembly.GetExecutingAssembly().Location, @"\XmlLogs");

        #endregion
    }
}