using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Core.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name, WinAppDriverUtil driver) : base(locator, name, driver)
        {

        }

        public void SelectAll()
        {
            SendKeys(Keys.LeftControl + "A");
        }
    }
}
