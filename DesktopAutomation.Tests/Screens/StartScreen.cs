using DesktopAutomation.Core.Elements;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Tests.Screens
{
    public class StartScreen : BaseScreen
    {
        public StartScreen(WinAppDriverUtil webDriver) : base(new Button(By.XPath(
            "//Group/Group/Group[2]/Group/Group[3]/Custom/Group/Group[1]/Group/Group/Group[1]/Group/Group/Group/Group[1]"),
            "Кнопка 'Документ'", webDriver), "Стартовая страница", webDriver)
        { }

        public void DocumentClick()
        {
            BaseElement.WaitForEnabled();
            BaseElement.Click();
        }
    }
}
