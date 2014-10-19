using System.IO;

namespace DeftPack.TestAutomation.Reporting
{
    /// <summary>
    /// Report saving utility
    /// </summary>
    public class ReportSaver : IReportSaver
    {
        private readonly string _rootLocation;

        public ReportSaver(string rootLocation)
        {
            _rootLocation = rootLocation;

            if (!Directory.Exists(_rootLocation))
            {
                Directory.CreateDirectory(_rootLocation);
            }
        }

        /// <summary>
        /// Save the report content to the given location
        /// </summary>
        /// <param name="testName">Name of test. It will be also the name of the file</param>
        /// <param name="reportContent">The actual content that will be saved to the file</param>
        public void Save(string testName, string reportContent)
        {
            var fileFullPath = Path.Combine(_rootLocation, string.Format("{0}.html", testName));

            using (var writer = new StreamWriter(fileFullPath))
            {
                writer.Write(reportContent);
            }
        }
    }
}
