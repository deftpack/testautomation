namespace DeftPack.TestAutomation
{
    /// <summary>
    /// Saves screenshot to the given location made on the active screen
    /// </summary>
    public interface ITestScreenshotSaver
    {
        /// <summary>
        /// Event handler for test reporter. When a test reporter finished, it creates and saves a screenshot.
        /// </summary>
        /// <param name="t">Test reporter</param>
        /// <param name="args">Finished test report arguments</param>
        void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args);
    }
}