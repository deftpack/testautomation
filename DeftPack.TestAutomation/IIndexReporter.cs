namespace DeftPack.TestAutomation
{
    public interface IIndexReporter : System.IDisposable
    {
        void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args);
    }
}