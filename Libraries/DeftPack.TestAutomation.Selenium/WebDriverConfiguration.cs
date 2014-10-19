using System;
using System.Configuration;

namespace DeftPack.TestAutomation.Selenium
{
    /// <summary>
    /// Configuration section for the web drivers
    /// </summary>
    public class WebDriverConfiguration : ConfigurationSection
    {
        public const string SectionName = "WebDriverConfiguration";

        /// <summary>
        /// The location where the browser binaries could be found
        /// Default value: under the executing application location
        /// </summary>
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

        /// <summary>
        /// Which browser should be used by default
        /// Default value: PhantomJS
        /// </summary>
        [ConfigurationProperty("defaultBrowser", DefaultValue = Browser.PhantomJS, IsRequired = false)]
        public Browser DefaultBrowser
        {
            get { return (Browser)this["defaultBrowser"]; }
            set { this["defaultBrowser"] = value; }
        }

        /// <summary>
        /// The user agent that should be used by the browser 
        /// </summary>
        [ConfigurationProperty("userAgent", DefaultValue = "", IsRequired = false)]
        public string UserAgent
        {
            get { return (string)this["userAgent"]; }
            set { this["userAgent"] = value; }
        }

        /// <summary>
        /// Debugging related configurations
        /// </summary>
        [ConfigurationProperty("debugging", DefaultValue = null, IsRequired = false)]
        public WebDriverDebuggingConfiguration Debugging
        {
            get { return (WebDriverDebuggingConfiguration)this["debugging"]; }
            set { this["debugging"] = value; }
        }

        /// <summary>
        /// Get the section from the application or web configuration file
        /// </summary>
        public static WebDriverConfiguration Config
        {
            get { return (WebDriverConfiguration)ConfigurationManager.GetSection(SectionName) ?? new WebDriverConfiguration(); }
        }
    }
}
