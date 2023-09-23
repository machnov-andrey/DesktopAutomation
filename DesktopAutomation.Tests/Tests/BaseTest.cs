using DesktopAutomation.Core.Enums;
using DesktopAutomation.Core.Utils;
using DesktopAutomation.Tests.Screens;
using DesktopAutomation.Tests.Steps;
using NUnit.Framework;

namespace DesktopAutomation.Tests.Tests
{
    public class BaseTest
    {
        protected WinAppDriverUtil WpsOfficeDriver;

        private readonly Dictionary<string, string> DesktopOpions = new()
        {
            {Options.PlatformName, ConfigManager.PlatformName },
            {Options.DeviceName, ConfigManager.DeviceName },
            {Options.App, ConfigManager.DesktopPath }
        };

        private readonly Dictionary<string, string> WpsOfficeOptions = new()
        {
            {Options.DeviceName, ConfigManager.DeviceName },
        };

        [SetUp]
        public void SetUp()
        {
            WpsOfficeDriver = CommonSteps.LaunchWpsOffice(DesktopOpions, WpsOfficeOptions);
        }

        [TearDown]
        public void TearDown()
        {
            WaitUtil.Wait(ConfigManager.SpecialWait);
            WpsOfficeDriver.Close();

            new ExitSaveScreen(WpsOfficeDriver).ClickNo();

            WpsOfficeDriver.Quit();
        }
    }
}
