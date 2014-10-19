using NUnit.Framework;
using System;

namespace DeftPack.TestAutomation.Functional.Framework
{
    /// <summary>
    /// Extending the NUnit Test attribute with some extra description. 
    /// It is required for each test in an automation test suite.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AutomationTestAttribute : TestAttribute, ITestSummary
    {
        /// <summary>
        /// Human readable name of the test
        /// </summary>
        public string Name { get; private set; }

        public AutomationTestAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
