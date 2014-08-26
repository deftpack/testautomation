using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public class TestActionFactory
    {
        private readonly IWebDriver _webDriver;

        public TestActionFactory(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public TAction Create<TAction>(params object[] parameters) where TAction : TestAction
        {
            var pageTypes = GetPageTypesForAction<TAction>();
            var pages = pageTypes.Select(t => Activator.CreateInstance(t, _webDriver));
            return (TAction)Activator.CreateInstance(typeof(TAction), pages.Concat(parameters).ToArray());

        }

        private IEnumerable<Type> GetPageTypesForAction<TAction>()
        {
            return typeof(TAction).GetConstructors().Where(c => c.GetParameters().Any())
                    .SelectMany(x => x.GetParameters().Select(p => p.ParameterType))
                    .Where(t => t.IsSubclassOf(typeof(Page))).Distinct();
        }
    }
}
