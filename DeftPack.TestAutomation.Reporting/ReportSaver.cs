using System.IO;
using System.Reflection;

namespace DeftPack.TestAutomation.Reporting
{
    public class ReportSaver : IReportSaver
    {
        private readonly string _rootLocation;
        private const string ContentFolder = "Content";

        public ReportSaver(string rootLocation)
        {
            _rootLocation = rootLocation;

            if (!Directory.Exists(_rootLocation))
            {
                Directory.CreateDirectory(_rootLocation);
            }

            SaveContent("DeftPack.TestAutomation.Reporting.Style.report_theme.css", "report_theme.css");
        }

        public void Save(string testName, string reportContent)
        {
            var fileFullPath = Path.Combine(_rootLocation, string.Format("{0}.html", testName));

            using (var writer = new StreamWriter(fileFullPath))
            {
                writer.Write(reportContent);
            }
        }

        private void SaveContent(string resourceName, string fileName)
        {
            var contentDirectory = Path.Combine(_rootLocation, ContentFolder);
            var fileFullPath = Path.Combine(contentDirectory, fileName);

            if (!File.Exists(fileFullPath))
            {
                if (!Directory.Exists(contentDirectory))
                {
                    Directory.CreateDirectory(contentDirectory);
                }

                var data = LoadContent(resourceName);
                using (var writer = new StreamWriter(fileFullPath))
                {
                    writer.Write(data);
                }
            }
        }

        private string LoadContent(string contentName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(contentName);
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
