using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorQueryExtensions
    {
        /// <summary>
        /// Loads the client side helping library to the browsers memory
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        internal static void InitilaizejQuery(this IJavaScriptExecutor executor)
        {
            executor.LoadJavaScriptLibrary(
                "DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions.ClientSideHelpers.jQueryLoader.js");
        }

        /// <summary>
        /// Finds the first element matching the jQuery selector
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        /// <param name="selector">jQuery element selector</param>
        /// <returns>DOM object returned by the selector</returns>
        internal static IWebElement jQueryElement(this IJavaScriptExecutor executor, string selector)
        {
            return executor.GetJsObject<IWebElement>(string.Format("window.SeleniumTesting.QueryElement('{0}').get(0)", selector));
        }
    }
}
