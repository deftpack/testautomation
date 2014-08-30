using System.Collections.Generic;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions
{
    internal static class WebDriverErrorHandlingExtensions
    {
        internal static void InitilaizeJavaScriptErrorHarvester(this IWebDriver webDriver)
        {
            webDriver.LoadJavaScriptLibray("DeftPack.TestAutomation.Selenium.PageObjects.ClientSideHelpers.ErrorHarvester.js");
        }

        internal static IEnumerable<string> GetJavaScriptErrorMessages(this IWebDriver webDriver)
        {
            return webDriver.GetJsObject<IEnumerable<string>>("window.SeleniumTesting.JavaScriptErrors");
        }
    }
}
