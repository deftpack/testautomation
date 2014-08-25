using System;
using System.IO;

namespace DeftPack.TestAutomation.Reporting
{
    public class ReporterSetting
    {
        private const string DateTimeFormat = "ddMMyyyy_HHmmss";

        public DateTime StartTime { get; private set; }
        public string RootFolderFullPath { get; private set; }
        public string Title { get; private set; }

        public ReporterSetting(DateTime startTime, ReporterConfiguration configuration)
        {
            StartTime = startTime;
            Title = configuration.Title;
            var testRootFolderName = string.Format("{0}_{1}", configuration.Title, startTime.ToString(DateTimeFormat));
            RootFolderFullPath = Path.Combine(configuration.Location, testRootFolderName);
        }
    }
}
