using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Core.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator, string name, WinAppDriverUtil driver) : base(locator, name, driver)
        {

        }
    }
}
