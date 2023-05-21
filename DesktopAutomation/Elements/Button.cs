using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DesktopAutomation.Core.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, string name, WinAppDriverUtil driver) : base(locator, name, driver)
        {

        }
    }
}
