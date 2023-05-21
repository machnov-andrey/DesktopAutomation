using DesktopAutomation.Tests.Screens;
using DesktopAutomation.Tests.Utils;
using NUnit.Framework;

namespace DesktopAutomation.Tests.Tests
{
    public class WpsOfficeTests : BaseTest
    {
        [Test]
        public void FormatTest()
        {
            var startScreen = new StartScreen(WpsOfficeDriver);
            startScreen.WaitForPageOpened();
            startScreen.DocumentClick();

            var createDocumentScreen = new CreateDocumentScreen(WpsOfficeDriver);
            createDocumentScreen.WaitForPageOpened();
            createDocumentScreen.CreateEmptyDocument();

            var documentEditorScreen = new DocumentEditorScreen(WpsOfficeDriver);
            documentEditorScreen.WaitForPageOpened();
            documentEditorScreen.ClickEditor();

            for (var i = 0; i < 3; i++)
            {
                documentEditorScreen.SendText(TestDataManager.Text);
                documentEditorScreen.NewParagraph();
            }

            documentEditorScreen.SelectAll();
            documentEditorScreen.BoldButton.Click();
            documentEditorScreen.UnderLiningButton.Click();
            documentEditorScreen.LineSpacing.Click();

            documentEditorScreen.ClickMoreLineSpacing();
            documentEditorScreen.Alignment.Click();
            documentEditorScreen.Centered.Click();

            documentEditorScreen.Spacing.SelectAll();
            documentEditorScreen.SendText(TestDataManager.Spacing);

            documentEditorScreen.Confirm.Click();
        }
    }
}