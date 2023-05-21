namespace DesktopAutomation.Core.Utils
{
    public static class ActionsUtil
    {
        public static void MoveByOffset(WinAppDriverUtil webDriver, int offsetX, int offestY)
        {
            webDriver.GetActions().MoveByOffset(offsetX, offestY).Build().Perform();
        }

        public static void Click(WinAppDriverUtil webDriver)
        {
            webDriver.GetActions().Click().Build().Perform();
        }
    }
}
