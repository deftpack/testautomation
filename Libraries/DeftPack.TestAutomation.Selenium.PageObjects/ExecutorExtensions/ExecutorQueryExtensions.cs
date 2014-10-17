using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorQueryExtensions
    {
        internal static void InitilaizejQuery(this IJavaScriptExecutor executor)
        {
            executor.LoadJavaScriptLibray(
                "DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions.ClientSideHelpers.jQueryLoader.js");
        }

        internal static IWebElement jQueryElement(this IJavaScriptExecutor executor, string selector)
        {
            return executor.GetJsObject<IWebElement>(string.Format("window.SeleniumTesting.QueryElement('{0}').get(0)", selector));
        }
    }
}
