using DesktopAutomation.Core.Elements;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Tests.Screens
{
    public abstract class BaseScreen
    {
        protected BaseElement BaseElement { get; private set; }
        protected string ScreenName { get; private set; }
        protected WinAppDriverUtil WebDriver { get; private set; }
        protected Button WPSOfficeButton => new(By.ClassName("KPromeTab"), "Кнопка 'WPS Office'", WebDriver);

        public BaseScreen(BaseElement baseElement, string screenName, WinAppDriverUtil webDriver)
        {
            BaseElement = baseElement;
            ScreenName = screenName;
            WebDriver = webDriver;
        }

        public bool IsScreenOpened()
        {
            return BaseElement.IsEnabled();
        }

        public bool WaitForPageOpened()
        {
            return BaseElement.WaitForEnabled();
        }
    }
}
