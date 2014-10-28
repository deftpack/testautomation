namespace DeftPack.TestAutomation
{
    /// <summary>
    /// Reporter for the test suites. It generates summary about the whole test run.
    /// </summary>
    public interface IIndexReporter : System.IDisposable
    {
        /// <summary>
        /// Add a record about a test execution once it is finished
        /// </summary>
        /// <param name="t">Event Raiser</param>
        /// <param name="args">Event Arguments</param>
        void HandleFinishedTestReport(ITestReporter t, TestReporterFinishedEventArgs args);
    }
}