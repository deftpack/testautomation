using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions
{
    internal static class ExecutorPageExtensions
    {
        /// <summary>
        /// Checks if the calls are finished and the document is ready
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        /// <returns>Returns true if the page is ready</returns>
        internal static bool IsPageReady(this IJavaScriptExecutor executor)
        {
            return executor.IsDocumentReady() && executor.IsAjaxFinished();
        }

        /// <summary>
        /// Checks if the DOM is ready
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        /// <returns>Returns true if DOM is constructed</returns>
        internal static bool IsDocumentReady(this IJavaScriptExecutor executor)
        {
            return executor.GetJsObject<string>("document.readyState").Equals("complete");
        }

        /// <summary>
        /// Checks if the AJAX calls (done with jQuery) are finished
        /// </summary>
        /// <param name="executor">The executor to be used</param>
        /// <returns>Returns true if AJAX calls are finished</returns>
        internal static bool IsAjaxFinished(this IJavaScriptExecutor executor)
        {
            return executor.GetJsObject<bool>("window.SeleniumTesting.IsAjaxFinished()").Equals(true);
        }
    }
}
