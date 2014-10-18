using System;
using System.Configuration;
using System.IO;

namespace DeftPack.TestAutomation.Reporting
{
    public class ReporterConfiguration : ConfigurationSection
    {
        public const string SectionName = "ReporterConfiguration";

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

        public static ReporterConfiguration Config
        {
            get { return (ReporterConfiguration)ConfigurationManager.GetSection(SectionName) ?? new ReporterConfiguration(); }
        }
    }
}
