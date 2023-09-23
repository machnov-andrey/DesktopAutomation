using DesktopAutomation.Core.Elements;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Tests.Screens
{
    public class StartScreen : BaseScreen
    {
        public Button CreateButton => new(By.ClassName("KPromeNewTabButton"), "Кнопка для создания новой вкладки", WebDriver);

        public StartScreen(WinAppDriverUtil webDriver) : base(new Button(By.ClassName(
            "KHyperionSpace::KFileMgrAreaLeftWidget"), "Левый навигационный бар", webDriver), 
            "Стартовая страница", webDriver)
        { }
    }
}
