namespace DeftPack.TestAutomation
{
    /// <summary>
    /// Reporter class for each individual test
    /// </summary>
    public interface ITestReporter : System.IDisposable
    {
        event TestReporterFinishedHandler Finished;

        /// <summary>
        /// Generate a record a test step
        /// </summary>
        /// <param name="stepName">Name of the test step</param>
        /// <param name="expectedResult">The expected outcome of the given test step</param>
        /// <param name="actualResult">The actual outcome of the step</param>
        /// <param name="status">Status of the step. If passed true, if failed false.</param>
        void ReportStep(string stepName, string expectedResult, string actualResult, bool status);
    }
}