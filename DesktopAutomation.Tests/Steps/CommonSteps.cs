using DesktopAutomation.Core.Enums;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Tests.Steps
{
    public static class CommonSteps
    {
        public static WinAppDriverUtil LaunchWpsOffice(Dictionary<string, string> startOptions, Dictionary<string, string> desktopOptions,
            Dictionary<string, string> wpsOfficeOptions)
        {
            try
            {
                new WinAppDriverUtil(ConfigManager.Url, startOptions);
            }
            catch { }

            var desktopDriver = new WinAppDriverUtil(ConfigManager.Url, desktopOptions);

            WaitUtil.Wait(ConfigManager.StartAppTimeout);

            wpsOfficeOptions.Add(Options.AppTopLevelWindow, 
                int.Parse(desktopDriver.FindElement(By.Name("WPS Office")).GetAttribute("NativeWindowHandle")).ToString("X"));

            desktopDriver.Quit();

            return new WinAppDriverUtil(ConfigManager.Url, wpsOfficeOptions);
        }
    }
}
