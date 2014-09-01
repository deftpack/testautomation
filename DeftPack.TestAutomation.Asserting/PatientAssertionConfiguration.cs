using System.Configuration;

namespace DeftPack.TestAutomation.Assertion
{
    public class PatientAssertionConfiguration : ConfigurationSection
    {
        public const string SectionName = "PatientAssertionConfiguration";

        [ConfigurationProperty("numberOfTries", IsRequired = false, DefaultValue = 10)]
        public int NumberOfTries
        {
            get { return (int)this["numberOfTries"]; }
            set { this["numberOfTries"] = value; }
        }

        [ConfigurationProperty("millisecondsBetweenTries", IsRequired = false, DefaultValue = 500)]
        public int MillisecondsBetweenTries
        {
            get { return (int)this["millisecondsBetweenTries"]; }
            set { this["millisecondsBetweenTries"] = value; }
        }

        public static PatientAssertionConfiguration Config
        {
            get { return (PatientAssertionConfiguration) ConfigurationManager.GetSection(SectionName) ?? new PatientAssertionConfiguration(); }
        }
    }
}
