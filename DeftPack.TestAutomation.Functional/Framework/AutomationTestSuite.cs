using Autofac;
using DeftPack.TestAutomation.Functional.DependencyInjection;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;

namespace DeftPack.TestAutomation.Functional.Framework
{
    public abstract class AutomationTestSuite
    {
        private ILifetimeScope _scope;

        private IIndexReporter IndexReporter
        {
            get { return _scope.Resolve<IIndexReporter>(); }
        }

        private ITestScreenshotSaver ScreenshotSaver
        {
            get { return _scope.Resolve<ITestScreenshotSaver>(); }
        }

        private ITestEvaluator Evaluator
        {
            get { return _scope.Resolve<ITestEvaluator>(); }
        }

        private ITestReporter TestReporter
        {
            get { return _scope.Resolve<ITestReporter>(new NamedParameter("testSummary", TestSummary)); }
        }

        protected ITestSummary TestSummary
        {
            get
            {
                var type = GetType();
                var method = type.GetMethod(TestContext.CurrentContext.Test.Name);
                var attr = method.GetCustomAttribute<AutomationTestAttribute>();

                if (attr == null)
                    throw new MissingExpectedAttributeException(type, typeof(AutomationTestAttribute));

                return attr;
            }
        }

        #region Test Methods (Setup and TearDown)
        [SetUp]
        public void SetUp()
        {
            _scope = TestFramework.Container.BeginLifetimeScope();
            TestReporter.Finished += IndexReporter.HandleFinishedTestReport;
            TestReporter.Finished += ScreenshotSaver.HandleFinishedTestReport;
        }

        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }
        #endregion

        protected IWebDriver GetExtraWebDriver()
        {
            return TestFramework.Container.Resolve<WebDriverFactory>().Default;
        }

        protected void Evaluate<TAction>(params object[] parameters) where TAction : TestAction
        {
            var action = _scope.Resolve<TestActionFactory>().Create<TAction>(parameters);
            Evaluator.Evaluate(action);
        }

        protected TModel Evaluate<TAction, TModel>(params object[] parameters)
            where TAction : TestFunction<TModel>
            where TModel : class
        {
            var action = _scope.Resolve<TestActionFactory>().Create<TAction>(parameters);
            Evaluator.Evaluate(action);
            return action.Model;
        }
    }
}
