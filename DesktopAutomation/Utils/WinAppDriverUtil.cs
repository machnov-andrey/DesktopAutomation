using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace DesktopAutomation.Core.Utils
{
    public class WinAppDriverUtil
    {
        private RemoteWebDriver RemoteWebDriver;

        public WinAppDriverUtil(string url, Dictionary<string, string> options)
        {
            var desktopCapabilities = new AppiumOptions();

            foreach (var option in options)
            {
                desktopCapabilities.AddAdditionalCapability(option.Key, option.Value);
            }

            RemoteWebDriver = new RemoteWebDriver(new Uri(url), desktopCapabilities);
        }

        public IWebElement FindElement(By locator)
        {
            return RemoteWebDriver.FindElement(locator);
        }

        public void Close()
        {
            RemoteWebDriver.Close();
        }

        public void Quit()
        {
            RemoteWebDriver.Quit();
        }
        
        public Actions GetActions()
        {
            return new Actions(RemoteWebDriver);
        }
    }
}
