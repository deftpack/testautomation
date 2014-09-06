using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestActionDescriptionAttribute : Attribute, ITestActionDescription
    {
        private string _failedMessage;
        public string ActionSummary { get; set; }
        public string ExpectedResult { get; set; }
        public string SuccessMessage { get; set; }

        public string FailedMessage
        {
            get { return string.IsNullOrEmpty(_failedMessage) ? "Error happened: {0}" : _failedMessage; }
            set { _failedMessage = value; }
        }
    }
}