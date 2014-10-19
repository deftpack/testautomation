﻿using Autofac;
using DeftPack.TestAutomation.Functional.DependencyInjection;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.Reporting;
using DeftPack.TestAutomation.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;

namespace DeftPack.TestAutomation.Functional.Framework
{
    /// <summary>
    /// Base class for the test classes which uses the functional framework
    /// </summary>
    public abstract class AutomationTestSuite
    {
        #region Private Utilities
        private ILifetimeScope _scope;

        private IIndexReporter IndexReporter
        {
            get { return _scope.Resolve<IIndexReporter>(); }
        }

        private ITestScreenshotSaver ScreenshotSaver { get; set; }

        private ITestEvaluator Evaluator
        {
            get { return _scope.Resolve<ITestEvaluator>(); }
        }

        private ITestReporter TestReporter
        {
            get { return _scope.Resolve<ITestReporter>(new NamedParameter("testSummary", TestSummary)); }
        }
        #endregion

        #region Test Methods (Setup and TearDown)
        /// <summary>
        /// Setup method that is executed before each test
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _scope = TestFramework.Container.BeginLifetimeScope();
            ScreenshotSaver = new TestScreenshotSaver(
                _scope.Resolve<IWebDriver>(),
                _scope.Resolve<ReporterSetting>().RootFolderFullPath);
            TestReporter.Finished += IndexReporter.HandleFinishedTestReport;
            TestReporter.Finished += ScreenshotSaver.HandleFinishedTestReport;
        }

        /// <summary>
        /// Tear Down method that is executed after each test
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }
        #endregion

        #region Protected Properties and Functions
        /// <summary>
        /// Returns the meta information about the given test
        /// </summary>
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

        /// <summary>
        /// Navigate to the given address
        /// </summary>
        /// <param name="url">Web URL to navigate to</param>
        protected void StartAtUrl(string url)
        {
            _scope.Resolve<IWebDriver>().NavigateToUrl(url);
        }

        /// <summary>
        /// Opens a new browser window and leaves the open ones untouched.
        /// </summary>
        /// <returns>Selenium Web Driver instance for the new window</returns>
        protected IWebDriver OpenNewBrowser()
        {
            return TestFramework.Container.Resolve<WebDriverFactory>().Default;
        }

        /// <summary>
        /// Executes a test action 
        /// </summary>
        /// <typeparam name="TAction">Type of the test action to be executed</typeparam>
        /// <param name="parameters">Constructor parameters for the test action, excluding the views</param>
        protected void Evaluate<TAction>(params object[] parameters) where TAction : TestAction
        {
            var action = _scope.Resolve<TestActionFactory>().Create<TAction>(parameters);
            Evaluator.Evaluate(action);
        }

        /// <summary>
        /// Executes a test function 
        /// </summary>
        /// <typeparam name="TAction">Type of the test function to be executed</typeparam>
        /// <typeparam name="TModel">Type of the model returned by the test function</typeparam>
        /// <param name="parameters">Constructor parameters for the test function, excluding the views</param>
        /// <returns>The model generated by the test function</returns>
        protected TModel Evaluate<TAction, TModel>(params object[] parameters)
            where TAction : TestFunction<TModel>
            where TModel : class
        {
            var action = _scope.Resolve<TestActionFactory>().Create<TAction>(parameters);
            Evaluator.Evaluate(action);
            return action.Model;
        }
        #endregion
    }
}
