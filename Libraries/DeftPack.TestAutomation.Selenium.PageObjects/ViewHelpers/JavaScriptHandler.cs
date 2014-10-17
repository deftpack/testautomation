using DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    public class JavaScriptHandler : IJavaScriptHandler
    {
        private readonly IJavaScriptExecutor _executor;

        public JavaScriptHandler(IJavaScriptExecutor executor)
        {
            _executor = executor;

            _executor.InitilaizeJavaScriptErrorHarvester();
        }

        public IEnumerable<string> ErrorMessages
        {
            get { return _executor.GetJavaScriptErrorMessages().ToArray(); }
        }

        public bool IsPageReady
        {
            get { return _executor.IsPageReady(); }
        }
    }
}
