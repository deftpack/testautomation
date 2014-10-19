using System;
using System.IO;

namespace DeftPack.TestAutomation.Reporting
{
    /// <summary>
    /// Settings for the reporters
    /// </summary>
    public class ReporterSetting
    {
        private const string DateTimeFormat = "ddMMyyyy_HHmmss";

        /// <summary>
        /// When the test execution started
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// The root folder where the reports should be saved
        /// </summary>
        public string RootFolderFullPath { get; private set; }

        /// <summary>
        /// The title that should be displayed on each report
        /// </summary>
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
