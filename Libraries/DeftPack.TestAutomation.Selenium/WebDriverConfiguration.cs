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

        [ConfigurationProperty("userAgent", DefaultValue = "", IsRequired = false)]
        public string UserAgent
        {
            get { return (string)this["userAgent"]; }
            set { this["userAgent"] = value; }
        }

        [ConfigurationProperty("debugging", DefaultValue = null, IsRequired = false)]
        public WebDriverDebuggingConfiguration Debugging
        {
            get { return (WebDriverDebuggingConfiguration)this["debugging"]; }
            set { this["debugging"] = value; }
        }

        public static WebDriverConfiguration Config
        {
            get { return (WebDriverConfiguration)ConfigurationManager.GetSection(SectionName) ?? new WebDriverConfiguration(); }
        }
    }
}
