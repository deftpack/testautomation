using System.Configuration;

namespace DeftPack.TestAutomation.Selenium
{
    public class WebDriverDebuggingConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("port", DefaultValue = 0, IsRequired = false)]
        public int Port
        {
            get { return (int)this["port"]; }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("logFileFullPath", DefaultValue = "", IsRequired = false)]
        public string LogFileFullPath
        {
            get { return (string)this["logFileFullPath"]; }
            set { this["logFileFullPath"] = value; }
        }
    }
}
