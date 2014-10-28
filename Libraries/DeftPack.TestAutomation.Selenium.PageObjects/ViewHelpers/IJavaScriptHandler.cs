using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    /// <summary>
    /// Manages the JavaScript related operations 
    /// </summary>
    internal interface IJavaScriptHandler
    {
        /// <summary>
        /// All the errors on the page
        /// </summary>
        IEnumerable<string> ErrorMessages { get; }

        /// <summary>
        /// Readiness of the page
        /// </summary>
        bool IsPageReady { get; }
    }
}