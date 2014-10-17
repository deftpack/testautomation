using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorErrorHandlingExtensions
    {
        internal static void InitilaizeJavaScriptErrorHarvester(this IJavaScriptExecutor executor)
        {
            executor.LoadJavaScriptLibray(
                "DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions.ClientSideHelpers.ErrorHarvester.js");
        }

        internal static IEnumerable<string> GetJavaScriptErrorMessages(this IJavaScriptExecutor executor)
        {
            return executor.GetJsObject<IEnumerable<string>>("window.SeleniumTesting.JavaScriptErrors");
        }
    }
}
