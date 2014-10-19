using System;
using System.Configuration;
using System.IO;

namespace DeftPack.TestAutomation.Reporting
{
    /// <summary>
    /// Configuration section for the reporters
    /// </summary>
    public class ReporterConfiguration : ConfigurationSection
    {
        public const string SectionName = "ReporterConfiguration";

        /// <summary>
        /// Title to display on each report
        /// Default value: the executing application Name
        /// </summary>
        [ConfigurationProperty("title", DefaultValue = "", IsRequired = false)]
        public string Title
        {
            get
            {
                var title = (string)this["title"];
                return string.IsNullOrWhiteSpace(title) ? AppDomain.CurrentDomain.SetupInformation.ApplicationName : title;
            }
            set { this["title"] = value; }
        }

        /// <summary>
        /// Root location where the reports should be saved
        /// Default value: under the executing application location in a folder called "reports" 
        /// </summary>
        [ConfigurationProperty("location", DefaultValue = "", IsRequired = false)]
        public string Location
        {
            get
            {
                var location = (string)this["location"];
                return string.IsNullOrWhiteSpace(location)
                    ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reports")
                    : location;
            }
            set { this["location"] = value; }
        }

        /// <summary>
        /// Get the section from the application or web configuration file
        /// </summary>
        public static ReporterConfiguration Config
        {
            get { return (ReporterConfiguration)ConfigurationManager.GetSection(SectionName) ?? new ReporterConfiguration(); }
        }
    }
}
