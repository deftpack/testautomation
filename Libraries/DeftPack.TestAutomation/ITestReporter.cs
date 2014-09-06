namespace DeftPack.TestAutomation
{
    public interface ITestReporter : System.IDisposable
    {
        event TestReporterFinishedHandler Finished;
        void ReportStep(string stepName, string expectedResult, string actualResult, bool status);
    }
}