using DeftPack.TestAutomation.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Factory class for test actions and functions
    /// </summary>
    public class TestActionFactory
    {
        private readonly IWebDriver _webDriver;
        private readonly ViewFactory _viewFactory;

        public TestActionFactory(IWebDriver webDriver, ViewFactory viewFactory)
        {
            _webDriver = webDriver;
            _viewFactory = viewFactory;
        }

        /// <summary>
        /// Creates an instance of a test action or function
        /// </summary>
        /// <typeparam name="TAction">Type of the test action or function to be created</typeparam>
        /// <param name="parameters">All the constructor parameters of the given test action/function excluding the views (those are resolved internally)</param>
        /// <returns>Instance of a test action or function</returns>
        public TAction Create<TAction>(params object[] parameters) where TAction : TestAction
        {
            var viewTypes = GetViewTypesForAction<TAction>();
            var views = viewTypes.Select(vt => _viewFactory.Create(vt, _webDriver));
            return (TAction)Activator.CreateInstance(typeof(TAction), views.Concat(parameters).ToArray());

        }

        /// <summary>
        /// Find all the dependent view types for a given test action or function
        /// </summary>
        /// <typeparam name="TAction">Type of the test action or function to be inspected</typeparam>
        /// <returns>Enumeration of a view types</returns>
        private IEnumerable<Type> GetViewTypesForAction<TAction>()
        {
            return typeof(TAction).GetConstructors().Where(c => c.GetParameters().Any())
                    .SelectMany(x => x.GetParameters().Select(p => p.ParameterType))
                    .Where(t => t.IsSubclassOf(typeof(View))).Distinct();
        }
    }
}
