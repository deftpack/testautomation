namespace DeftPack.TestAutomation
{
    /// <summary>
    /// Report saving utility
    /// </summary>
    public interface IReportSaver
    {
        /// <summary>
        /// Save the report content to the given location
        /// </summary>
        /// <param name="testName">Name of test. It will be also the name of the file</param>
        /// <param name="reportContent">The actual content that will be saved to the file</param>
        void Save(string testName, string reportContent);
    }
}