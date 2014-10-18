using System;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public class TestEvaluator : ITestEvaluator
    {
        private readonly ITestActionDescriptionProvider _testActionDescriptionProvider;
        private readonly ITestReporter _testReporter;

        public TestEvaluator(
            ITestActionDescriptionProvider testActionDescriptionProvider,
            ITestReporter testReporter)
        {
            _testActionDescriptionProvider = testActionDescriptionProvider;
            _testReporter = testReporter;
        }

        public void Evaluate<TAction>(TAction testAction) where TAction : TestAction
        {
            try
            {
                testAction.Evaluate();
                Report<TAction>(true, testAction.ExtraMessage);
            }
            catch (Exception e)
            {
                Report<TAction>(false, e.Message);
                throw;
            }
        }

        private void Report<TAction>(bool isSuccess, string extraMessage) where TAction : TestAction
        {
            var description = _testActionDescriptionProvider.GetDescription<TAction>();
            var message = isSuccess ? description.SuccessMessage : description.FailedMessage;
            if (extraMessage != null) message = string.Format(message, extraMessage);

            _testReporter.ReportStep(
                    description.ActionSummary,
                    description.ExpectedResult,
                    message,
                    isSuccess);
        }
    }
}