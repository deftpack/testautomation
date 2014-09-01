using System;
using System.Configuration;

namespace DeftPack.TestAutomation.Selenium
{
    public class WebDriverConfiguration : ConfigurationSection
    {
        public const string SectionName = "WebDriverConfiguration";

        [ConfigurationProperty("driverLocation", DefaultValue = "", IsRequired = false)]
        public string DriverLocation
        {
            get
            {
                var driverLocation = (string)this["driverLocation"];
                return string.IsNullOrEmpty(driverLocation) ? AppDomain.CurrentDomain.BaseDirectory : driverLocation;
            }
            set { this["driverLocation"] = value; }
        }

        [ConfigurationProperty("defaultBrowser", DefaultValue = Browser.PhantomJS, IsRequired = false)]
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

        [ConfigurationProperty("debuggingPort", DefaultValue = 0, IsRequired = false)]
        public int DebuggingPort
        {
            get { return (int)this["debuggingPort"]; }
            set { this["debuggingPort"] = value; }
        }

        public static WebDriverConfiguration Config
        {
            get { return (WebDriverConfiguration) ConfigurationManager.GetSection(SectionName) ?? new WebDriverConfiguration(); }
        }
    }
}
