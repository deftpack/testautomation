using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    /// <summary>
    /// URL related checks
    /// </summary>
    internal interface IUrlChecker
    {
        /// <summary>
        /// Checks if the URL contains all the expected parts
        /// </summary>
        /// <param name="urlParts">String bits to look for</param>
        /// <returns>Returns true if the URL is correct</returns>
        bool MatchUrl(params string[] urlParts);

        /// <summary>
        /// Checks if the URL contains all the expected parts
        /// </summary>
        /// <typeparam name="TPage">Type of the view should be matched against</typeparam>
        /// <returns>Returns true if the URL is correct</returns>
        bool MatchUrl<TPage>() where TPage : View;

        /// <summary>
        /// Checks if the URL contains all the expected parts
        /// </summary>
        /// <param name="pageType">Type of the view should be matched against</param>
        /// <returns>Returns true if the URL is correct</returns>
        bool MatchUrl(Type pageType);
    }
}