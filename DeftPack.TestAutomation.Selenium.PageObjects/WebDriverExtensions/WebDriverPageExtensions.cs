using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions
{
    internal static class WebDriverPageExtensions
    {
        internal static bool IsPageReady(this IWebDriver webDriver)
        {
            return webDriver.IsDocumentReady() && webDriver.IsAjaxFinished();
        }

        internal static bool IsDocumentReady(this IWebDriver webDriver)
        {
            return webDriver.GetJsObject("document.readyState").Equals("complete");
        }

        internal static bool IsAjaxFinished(this IWebDriver webDriver)
        {
            return !webDriver.GetJsObject("window.jQuery").Equals("undefined") &&
                    webDriver.GetJsObject("window.jQuery.active").Equals("0");
        }
    }
}
