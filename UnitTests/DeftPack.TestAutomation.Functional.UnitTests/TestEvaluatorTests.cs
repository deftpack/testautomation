using DeftPack.TestAutomation.Functional.Evaluation;
using Moq;
using NUnit.Framework;
using System;

namespace DeftPack.TestAutomation.Functional.UnitTests
{
    [TestFixture]
    public class TestEvaluatorTests
    {
        private ITestEvaluator _evaluator;
        private bool _testStatus;

        [SetUp]
        public void Setup()
        {
            var testReporterMock = new Mock<ITestReporter>();
            testReporterMock
                .Setup(x => x.ReportStep(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Callback<string, string, string, bool>((a, b, c, d) => _testStatus = d);

            var descriptionProviderMock = new Mock<ITestActionDescriptionProvider>();
            descriptionProviderMock
                .Setup(x => x.GetDescription<TestAction>())
                .Returns(new TestActionDescriptionAttribute());

            _evaluator = new TestEvaluator(descriptionProviderMock.Object, testReporterMock.Object);
        }

        [Test]
        public void Evaluate_SuccessfulTestStep_Reported()
        {
            var testAction = new Mock<TestAction>().Object;
            _evaluator.Evaluate(testAction);
            Assert.That(_testStatus, Is.True);
        }

        [Test]
        public void Evaluate_FailedTestStep_Reported_ExceptionReThrown()
        {
            var testActionMock = new Mock<TestAction>();
            testActionMock.Setup(x => x.Evaluate()).Throws<ArgumentException>();
            Assert.Throws<ArgumentException>(() => _evaluator.Evaluate(testActionMock.Object));
            Assert.That(_testStatus, Is.False);
        }
    }
}
