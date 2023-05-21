namespace DesktopAutomation.Core.Enums
{
    public static class Options
    {
        public static Option PlatformName => new("platformName");
        public static Option App => new("app");
        public static Option DeviceName => new("deviceName");
        public static Option AppTopLevelWindow => new("appTopLevelWindow");
    }

    public class Option
    {
        private readonly string Value;

        public Option(string value)
        {
            Value = value;
        }

        public static implicit operator string(Option option)
        {
            return option.Value;
        }
    }
}
