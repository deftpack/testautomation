using System.Configuration;

namespace DeftPack.TestAutomation.Assertion
{
    /// <summary>
    /// Configuration section for the patient asserter
    /// </summary>
    public class PatientAssertionConfiguration : ConfigurationSection
    {
        public const string SectionName = "PatientAssertionConfiguration";

        /// <summary>
        /// How many times the asserter should try before it gives up
        /// </summary>
        [ConfigurationProperty("numberOfTries", IsRequired = false, DefaultValue = 10)]
        public int NumberOfTries
        {
            get { return (int)this["numberOfTries"]; }
            set { this["numberOfTries"] = value; }
        }

        /// <summary>
        /// How much the asserter should wait between the tries
        /// </summary>
        [ConfigurationProperty("millisecondsBetweenTries", IsRequired = false, DefaultValue = 500)]
        public int MillisecondsBetweenTries
        {
            get { return (int)this["millisecondsBetweenTries"]; }
            set { this["millisecondsBetweenTries"] = value; }
        }

        /// <summary>
        /// Reading the section from the application or web configuration file
        /// </summary>
        public static PatientAssertionConfiguration Config
        {
            get { return (PatientAssertionConfiguration)ConfigurationManager.GetSection(SectionName) ?? new PatientAssertionConfiguration(); }
        }
    }
}
