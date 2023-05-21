using DesktopAutomation.Core.Elements;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DesktopAutomation.Tests.Screens
{
    public class ExitSaveScreen : BaseScreen
    {
        public ExitSaveScreen(WinAppDriverUtil webDriver) : base(new Button(By.Name("Нет"),
            "Кнопка 'Нет'", webDriver), "Форма при выходе", webDriver)
        { }

        public void ClickNo()
        {
            BaseElement.Click();
        }
    }
}
