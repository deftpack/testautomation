using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorPageExtensions
    {
        internal static bool IsPageReady(this IJavaScriptExecutor executor)
        {
            return executor.IsDocumentReady() && executor.IsAjaxFinished();
        }

        internal static bool IsDocumentReady(this IJavaScriptExecutor executor)
        {
            return executor.GetJsObject<string>("document.readyState").Equals("complete");
        }

        internal static bool IsAjaxFinished(this IJavaScriptExecutor executor)
        {
            return executor.GetJsObject<bool>("window.SeleniumTesting.IsAjaxFinished()").Equals(true);
        }
    }
}
