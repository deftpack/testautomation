using NUnit.Framework;
using System;

namespace DeftPack.TestAutomation.Functional.Framework
{
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
