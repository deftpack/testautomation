using DeftPack.TestAutomation.Selenium.PageObjects.Views;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public class TestActionFactory
    {
        private readonly IWebDriver _webDriver;
        private readonly ViewFactory _viewFactory;

        public TestActionFactory(IWebDriver webDriver, ViewFactory viewFactory)
        {
            _webDriver = webDriver;
            _viewFactory = viewFactory;
        }

        public TAction Create<TAction>(params object[] parameters) where TAction : TestAction
        {
            var viewTypes = GetViewTypesForAction<TAction>();
            var views = viewTypes.Select(vt => _viewFactory.Create(vt, _webDriver));
            return (TAction)Activator.CreateInstance(typeof(TAction), views.Concat(parameters).ToArray());

        }

        private IEnumerable<Type> GetViewTypesForAction<TAction>()
        {
            return typeof(TAction).GetConstructors().Where(c => c.GetParameters().Any())
                    .SelectMany(x => x.GetParameters().Select(p => p.ParameterType))
                    .Where(t => t.IsSubclassOf(typeof(View))).Distinct();
        }
    }
}
