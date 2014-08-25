using System.Configuration;

namespace DeftPack.TestAutomation.Selenium
{
    public class WebDriverConfiguration : ConfigurationSection
    {
        public const string SectionName = "WebDriverConfiguration";

        [ConfigurationProperty("driverLocation", IsRequired = true)]
        public string DriverLocation
        {
            get { return (string)this["driverLocation"]; }
            set { this["driverLocation"] = value; }
        }

        [ConfigurationProperty("defaultBrowser", DefaultValue = Browser.Chrome, IsRequired = false)]
        public Browser DefaultBrowser
        {
            get { return (Browser)this["defaultBrowser"]; }
            set { this["defaultBrowser"] = value; }
        }

        [ConfigurationProperty("defaultDriverWaitSeconds", DefaultValue = 5, IsRequired = false)]
        public int DefaultDriverWaitSeconds
        {
            get { return (int)this["defaultDriverWaitSeconds"]; }
            set { this["defaultDriverWaitSeconds"] = value; }
        }

        public static WebDriverConfiguration Config
        {
            get { return (WebDriverConfiguration)ConfigurationManager.GetSection(SectionName); }
        }
    }
}
