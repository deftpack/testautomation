using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestActionDescriptionAttribute : Attribute, ITestActionDescription
    {
        public string StepDescription { get; set; }
        public string ExpectedResult { get; set; }
        public string SuccessMessage { get; set; }
        public string FailedMessage { get; set; }
    }
}