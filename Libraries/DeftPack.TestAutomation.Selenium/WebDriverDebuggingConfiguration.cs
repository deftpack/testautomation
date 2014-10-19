using System.Configuration;

namespace DeftPack.TestAutomation.Selenium
{
    /// <summary>
    /// Configuration for debugging the web driver execution
    /// </summary>
    public class WebDriverDebuggingConfiguration : ConfigurationElement
    {
        /// <summary>
        /// The port where remote debugging console could be accessed (you can use it at 127.0.0.1:PORT)
        /// </summary>
        [ConfigurationProperty("port", DefaultValue = 0, IsRequired = false)]
        public int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }

        /// <summary>
        /// The location where the log file should be saved by the web driver
        /// </summary>
        [ConfigurationProperty("logFileFullPath", DefaultValue = "", IsRequired = false)]
        public string LogFileFullPath
        {
            get { return (string)this["logFileFullPath"]; }
            set { this["logFileFullPath"] = value; }
        }
    }
}
