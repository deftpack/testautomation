using System;
using System.Configuration;
using System.Reflection;

namespace DeftPack.TestAutomation.Reporting
{
    public class ReporterConfiguration : ConfigurationSection
    {
        public const string SectionName = "ReporterConfiguration";

        [ConfigurationProperty("title", DefaultValue = "", IsRequired = false)]
        public string Title
        {
            get { return (string)this["title"] ?? Assembly.GetExecutingAssembly().GetName().Name; }
            set { this["title"] = value; }
        }

        [ConfigurationProperty("location", DefaultValue = "", IsRequired = false)]
        public string Location
        {
            get { return (string)this["location"] ?? AppDomain.CurrentDomain.BaseDirectory; }
            set { this["location"] = value; }
        }

        public static ReporterConfiguration Config
        {
            get
            {
                return (ReporterConfiguration)ConfigurationManager.GetSection(SectionName) ??
                       new ReporterConfiguration();
            }
        }
    }
}
