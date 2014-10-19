using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Describing the details of a test action/function so it is easier to understand the intention 
    /// and human readable outputs can be generated both about the aim and the result
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TestActionDescriptionAttribute : Attribute, ITestActionDescription
    {

        /// <summary>
        /// Summarizing the user flow which would be covered by the test action
        /// </summary>
        public string ActionSummary { get; set; }

        /// <summary>
        /// Describes the desired out come. This also helps decide if an action is out-dated 
        /// </summary>
        public string ExpectedResult { get; set; }

        /// <summary>
        /// The message that would be displayed upon successful test action execution. 
        /// It could contain a placeholder ({0}) for the extra message so that is displayed as well.
        /// </summary>
        public string SuccessMessage { get; set; }

        private string _failedMessage;
        /// <summary>
        /// The message that would be displayed upon failed test action execution. 
        /// It could contain a placeholder ({0}) for the error message so that is displayed as well.
        /// The default value is: "Error happened: {0}"
        /// </summary>
        public string FailedMessage
        {
            get { return string.IsNullOrEmpty(_failedMessage) ? "Error happened: {0}" : _failedMessage; }
            set { _failedMessage = value; }
        }
    }
}