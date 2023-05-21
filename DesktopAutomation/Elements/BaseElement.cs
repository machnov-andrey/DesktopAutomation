using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Core.Elements
{
    public abstract class BaseElement
    {
        protected string Name { get; }
        protected By Locator { get; }

        private WinAppDriverUtil WebDriver;

        public BaseElement(By locator, string name, WinAppDriverUtil webDriver)
        {
            Name = name;
            Locator = locator;
            WebDriver = webDriver;
        }

        protected IWebElement FindElement()
        {
            LoggerUtil.Info($"Ищем элемент '{Name}'");
            WaitUtil.Wait(ConfigManager.SpecialWait);
            return WebDriver.FindElement(Locator);
        }

        public void Click()
        {
            LoggerUtil.Info($"Кликаем по элементу '{Name}'");
            FindElement().Click();
        }

        public void SendKeys(string text)
        {
            LoggerUtil.Info($"Отправляем в элемент '{Name}' следующий текст: '{text}'");
            FindElement().SendKeys(text);
        }

        public bool IsEnabled()
        {
            LoggerUtil.Info($"Проверяем доступность элемента '{Name}'");
            return bool.Parse(FindElement().GetAttribute("IsEnabled"));
        }

        public void GoToElementTopLeftCorner()
        {
            WebDriver.GetActions().MoveToElement(FindElement(), 0, 0).Build().Perform();
        }

        public bool WaitForEnabled()
        {
            var interval = ConfigManager.Interval;
            var timeout = ConfigManager.Timeout;
            var count = timeout / interval;

            for (var i = 0; i < count; i++)
            {
                if (IsEnabled())
                {
                    return true;
                }
                else
                {
                    WaitUtil.Wait(interval);
                }
            }

            return false;
        }
    }
}
