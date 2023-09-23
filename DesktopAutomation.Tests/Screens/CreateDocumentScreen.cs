using DesktopAutomation.Core.Elements;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace DesktopAutomation.Tests.Screens
{
    public class CreateDocumentScreen : BaseScreen
    {
        private int EmptyDocumentX = 450;
        private int EmptyDocumentY = 400;   

        public CreateDocumentScreen(WinAppDriverUtil webDriver) : base(new Button(By.ClassName("KPromeNewDocsTab"), "Кнопка 'Мои шаблоны'",
            webDriver), "Экран 'Создать'", webDriver)
        { }

        public void CreateEmptyDocument()
        {
            WPSOfficeButton.GoToElementTopLeftCorner();
            ActionsUtil.MoveByOffset(WebDriver, EmptyDocumentX, EmptyDocumentY);
            ActionsUtil.Click(WebDriver);
        }
    }
}
