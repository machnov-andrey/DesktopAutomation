using Newtonsoft.Json.Linq;

namespace DesktopAutomation.Core.Utils
{
    public static class ConfigManager
    {
        private const string PathToConfig = @"Resources\settings.json";

        private static readonly JObject Config;

        static ConfigManager()
        {
            Config = JObject.Parse(File.ReadAllText(PathToConfig));
        }

        public static string PlatformName => GetValue<string>("platformName");
        public static string DeviceName => GetValue<string>("deviceName");
        public static string WpsOfficePath => GetValue<string>("wpsOfficePath");
        public static string DesktopPath => GetValue<string>("desktopPath");
        public static string Url => GetValue<string>("url");
        public static int StartAppTimeout => GetValue<int>("startAppTimeout");
        public static int SpecialWait => GetValue<int>("specialWait");
        public static int Timeout => GetValue<int>("timeout");
        public static int Interval => GetValue<int>("interval");

        private static T GetValue<T>(string key)
        {
            return Config.Value<T>(key) ?? throw new Exception($"Не нашлось значения в конфиге для ключа '{key}'");
        }
    }
}
