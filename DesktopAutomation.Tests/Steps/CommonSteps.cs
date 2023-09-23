using DesktopAutomation.Core.Enums;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;
using System.Diagnostics;

namespace DesktopAutomation.Tests.Steps
{
    public static class CommonSteps
    {
        public static WinAppDriverUtil LaunchWpsOffice(Dictionary<string, string> desktopOptions,
            Dictionary<string, string> wpsOfficeOptions)
        {
            Process.Start(ConfigManager.WpsOfficePath);

            var desktopDriver = new WinAppDriverUtil(ConfigManager.Url, desktopOptions);

            WaitUtil.Wait(ConfigManager.StartAppTimeout);

            wpsOfficeOptions.Add(Options.AppTopLevelWindow, 
                int.Parse(desktopDriver.FindElement(By.Name(ConfigManager.AppName))
                .GetAttribute(ConfigManager.NativeWindowHandleAttribute)).ToString("X"));

            desktopDriver.Quit();

            return new WinAppDriverUtil(ConfigManager.Url, wpsOfficeOptions);
        }
    }
}
