using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions
{
    internal static class WebDriverQueryExtensions
    {
        internal static void InitilaizejQuery(this IWebDriver webDriver)
        {
            webDriver.LoadJavaScriptLibray("DeftPack.TestAutomation.Selenium.PageObjects.ClientSideHelpers.jQueryLoader.js");
        }

        internal static IWebElement jQueryElement(this IWebDriver webDriver, string selector)
        {
            return webDriver.GetJsObject<IWebElement>(string.Format("window.SeleniumTesting.QueryElement('{0}').get(0)", selector));
        }
    }
}
