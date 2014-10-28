using DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    /// <summary>
    /// Manages the JavaScript related operations 
    /// </summary>
    internal class JavaScriptHandler : IJavaScriptHandler
    {
        private readonly IJavaScriptExecutor _executor;

        public JavaScriptHandler(IJavaScriptExecutor executor)
        {
            _executor = executor;

            _executor.InitilaizeJavaScriptErrorHarvester();
        }

        /// <summary>
        /// All the errors on the page
        /// </summary>
        public IEnumerable<string> ErrorMessages
        {
            get { return _executor.GetJavaScriptErrorMessages().ToArray(); }
        }

        /// <summary>
        /// Readiness of the page
        /// </summary>
        public bool IsPageReady
        {
            get { return _executor.IsPageReady(); }
        }
    }
}
