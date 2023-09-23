using DesktopAutomation.Core.Elements;
using DesktopAutomation.Core.Utils;
using OpenQA.Selenium;

namespace DesktopAutomation.Tests.Screens
{
    public class DocumentEditorScreen : BaseScreen
    {
        public Button BoldButton => new(By.XPath("//Group/Group/Group[2]/Group/Group[3]/Window/Group[3]/Group[1]/Group/Group/Custom/Group/Group/Group/Group/Group[3]/Group/Group[2]/Group[1]"), "Кнопка 'Полужирный'", WebDriver);
        public Button UnderLiningButton => new(By.XPath("//Group/Group/Group[2]/Group/Group[3]/Window/Group[3]/Group[1]/Group/Group/Custom/Group/Group/Group/Group/Group[3]/Group/Group[2]/Group[3]/Group[1]/Group"), "Кнопка 'Подчёркивание'", WebDriver);
        public Button LineSpacing => new(By.XPath("//Group/Group/Group[2]/Group/Group[3]/Window/Group[3]/Group[1]/Group/Group/Custom/Group/Group/Group/Group/Group[5]/Group/Group[3]/Group[1]/Group[6]"), "Кнопка 'Междустрочный интервал'", WebDriver);
        public Button Alignment => new(By.XPath("//Window[1]/Group[1]/Custom/Group/ComboBox[1]"), "Комбо-бокс 'Выравнивание'", WebDriver);
        public Button Centered => new(By.Name("По центру"), "Кнопка 'По центру'", WebDriver);
        public TextBox Spacing => new(By.Name("Sp_BeforePargraph"), "Текст-бокс 'Перед'", WebDriver);
        public Button Confirm => new(By.Name("Подтвердить"), "Кнопка 'Подтвердить'", WebDriver);

        private int MoreLiningSpacingX = 1120;
        private int MoreLiningSpacingY = 510;

        public DocumentEditorScreen(WinAppDriverUtil driver): base(new TextBox(By.ClassName("KxWpsView"), 
            "Поле для ввода текста", driver), "Редактор документа", driver)
        { }

        public void ClickEditor()
        {
            BaseElement.Click();
        }

        public void ClickMoreLineSpacing()
        {
            WPSOfficeButton.GoToElementTopLeftCorner();
            ActionsUtil.MoveByOffset(WebDriver, MoreLiningSpacingX, MoreLiningSpacingY);
            ActionsUtil.Click(WebDriver);
        }

        public void SendSpacing(string spacing)
        {
            Spacing.SendKeys(spacing);
        }

        public void SelectAll()
        {
            ((TextBox)BaseElement).SelectAll();
        }

        public void SendText(string text)
        {
            BaseElement.SendKeys(text);
        }

        public void NewParagraph()
        {
            BaseElement.SendKeys(Keys.Enter);
        }
    }
}
