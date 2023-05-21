using DesktopAutomation.Core.Enums;
using DesktopAutomation.Core.Utils;
using DesktopAutomation.Tests.Screens;
using DesktopAutomation.Tests.Steps;
using TechTalk.SpecFlow;

namespace DesktopAutomation.Tests.StepDefinitions
{
    [Binding]
    public class WpsOfficeStepDefinitions
    {
        protected WinAppDriverUtil WpsOfficeDriver;

        private readonly Dictionary<string, string> StartOptions = new()
        {
            {Options.PlatformName, ConfigManager.PlatformName },
            {Options.DeviceName, ConfigManager.DeviceName },
            {Options.App, ConfigManager.WpsOfficePath }
        };

        private readonly Dictionary<string, string> DesktopOpions = new()
        {
            {Options.PlatformName, ConfigManager.PlatformName },
            {Options.DeviceName, ConfigManager.DeviceName },
            {Options.App, ConfigManager.DesktopPath }
        };

        private readonly Dictionary<string, string> WpsOfficeOptions = new()
        {
            {Options.DeviceName, ConfigManager.DeviceName },
        };

        private StartScreen StartScreen;
        private CreateDocumentScreen CreateDocumentScreen;
        private DocumentEditorScreen DocumentEditorScreen;

        [When(@"I launch WPS Office")]
        public void ILaunchWpsOffice()
        {
            WpsOfficeDriver = CommonSteps.LaunchWpsOffice(StartOptions, DesktopOpions, WpsOfficeOptions);
            StartScreen = new StartScreen(WpsOfficeDriver);
            CreateDocumentScreen = new CreateDocumentScreen(WpsOfficeDriver);
            DocumentEditorScreen = new DocumentEditorScreen(WpsOfficeDriver);
        }

        [When(@"I want to create document")]
        public void IWantToCreateDocument()
        {
            StartScreen.DocumentClick();
        }

        [When(@"I choose empty document")]
        public void ChooseEmptyDocument()
        {
            CreateDocumentScreen.CreateEmptyDocument();
        }

        [When(@"I enter '(.*)' into editor '(.*)' times")]
        public void ISendTextIntoDocumentEditor(string text, int count)
        {
            DocumentEditorScreen.ClickEditor();

            for (var i = 0; i < count; i++)
            {
                DocumentEditorScreen.SendText(text);
                DocumentEditorScreen.NewParagraph();
            }
        }

        [When(@"I make all text bold and underlining")]
        public void IMakeAllTextBoldAndUnderLining()
        {
            DocumentEditorScreen.SelectAll();
            DocumentEditorScreen.BoldButton.Click();
            DocumentEditorScreen.UnderLiningButton.Click();
        }

        [When(@"I make center alignment and '(.*)' spacing")]
        public void IMakeCenterAlignmentAndSpacing(string spacing)
        {
            DocumentEditorScreen.LineSpacing.Click();
            DocumentEditorScreen.ClickMoreLineSpacing();
            DocumentEditorScreen.Alignment.Click();
            DocumentEditorScreen.Centered.Click();

            DocumentEditorScreen.Spacing.SelectAll();
            DocumentEditorScreen.SendText(spacing);

            DocumentEditorScreen.Confirm.Click();
        }

        [When(@"I close WPS Office")]
        public void ICloseWpsOffice()
        {
            WaitUtil.Wait(ConfigManager.SpecialWait);
            WpsOfficeDriver.Close();

            new ExitSaveScreen(WpsOfficeDriver).ClickNo();

            WpsOfficeDriver.Quit();
        }
    }
}
