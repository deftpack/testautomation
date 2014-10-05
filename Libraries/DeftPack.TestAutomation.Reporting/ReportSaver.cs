using System.IO;

namespace DeftPack.TestAutomation.Reporting
{
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
