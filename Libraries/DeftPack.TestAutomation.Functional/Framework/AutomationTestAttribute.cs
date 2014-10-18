using NUnit.Framework;
using System;

namespace DeftPack.TestAutomation.Functional.Framework
{
    /// <summary>
    /// Basic information about the test itself. Extending the NUnit Test attribute with description.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AutomationTestAttribute : TestAttribute, ITestSummary
    {
        public string Name { get; private set; }

        public AutomationTestAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
