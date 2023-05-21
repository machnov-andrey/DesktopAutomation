using Newtonsoft.Json.Linq;

namespace DesktopAutomation.Tests.Utils
{
    public static class TestDataManager
    {
        private const string PathToTestData = @"Utils\testData.json";

        private static readonly JObject TestData;

        static TestDataManager()
        {
            TestData = JObject.Parse(File.ReadAllText(PathToTestData));
        }

        public static string Text => GetValue<string>("text");
        public static string Spacing => GetValue<string>("spacing");

        private static T GetValue<T>(string key)
        {
            return TestData.Value<T>(key) ?? throw new Exception($"Не нашлось значения в конфиге для ключа '{key}'");
        }
    }
}
