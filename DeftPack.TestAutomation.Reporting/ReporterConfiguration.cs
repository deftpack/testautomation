using System.Configuration;

namespace DeftPack.TestAutomation.Reporting
{
    public class ReporterConfiguration : ConfigurationSection
    {
        public const string SectionName = "ReporterConfiguration";

        [ConfigurationProperty("title", IsRequired = true)]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }

        [ConfigurationProperty("location", IsRequired = true)]
        public string Location
        {
            get { return (string)this["location"]; }
            set { this["location"] = value; }
        }

        public static ReporterConfiguration Config
        {
            get { return (ReporterConfiguration)ConfigurationManager.GetSection(SectionName); }
        }
    }
}
