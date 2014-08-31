using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public class TestEvaluator : ITestEvaluator
    {
        private readonly ITestReporter _testReporter;

        public TestEvaluator(ITestReporter testReporter)
        {
            _testReporter = testReporter;
        }

        public void Evaluate<T>(T evaluable) where T : TestAction
        {
            try
            {
                evaluable.Evaluate();
                Report<T>(true, evaluable.ExtraMessage);
            }
            catch (Exception e)
            {
                Report<T>(false, e.Message);
                throw;
            }
        }

        private void Report<T>(bool isSuccess, string extraMessage)
        {
            var description = GetDescription<T>();
            var message = isSuccess ? description.SuccessMessage : description.FailedMessage;
            if (extraMessage != null) message = string.Format(message, extraMessage);

            _testReporter.ReportStep(
                    description.ActionSummary,
                    description.ExpectedResult,
                    message,
                    isSuccess);
        }

        private ITestActionDescription GetDescription<T>()
        {
            var targetType = typeof(T);
            var attributeType = typeof(TestActionDescriptionAttribute);

            var description = (TestActionDescriptionAttribute)Attribute.GetCustomAttribute(targetType, attributeType);


            if (description == null)
                throw new MissingExpectedAttributeException(targetType, attributeType);


            return description;
        }
    }
}