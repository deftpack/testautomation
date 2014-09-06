namespace DeftPack.TestAutomation
{
    public interface ITestScreenshotSaver
    {
        void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args);
    }
}