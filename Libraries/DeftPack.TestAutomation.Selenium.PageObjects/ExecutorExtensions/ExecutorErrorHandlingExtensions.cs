using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorErrorHandlingExtensions
    {
        /// <summary>
        /// Loads the client side helping library to the browsers memory
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        internal static void InitilaizeJavaScriptErrorHarvester(this IJavaScriptExecutor executor)
        {
            executor.LoadJavaScriptLibrary(
                "DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions.ClientSideHelpers.ErrorHarvester.js");
        }

        /// <summary>
        /// Fetches the client side errors
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        /// <returns>Enumeration of error messages</returns>
        internal static IEnumerable<string> GetJavaScriptErrorMessages(this IJavaScriptExecutor executor)
        {
            return executor.GetJsObject<IEnumerable<string>>("window.SeleniumTesting.JavaScriptErrors");
        }
    }
}
