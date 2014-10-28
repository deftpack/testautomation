using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    /// <summary>
    /// URL related checks
    /// </summary>
    internal class UrlChecker : IUrlChecker
    {
        private readonly IWebDriver _webDriver;

        public UrlChecker(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /// <summary>
        /// Checks if the URL contains all the expected parts
        /// </summary>
        /// <param name="urlParts">String bits to look for</param>
        /// <returns>Returns true if the URL is correct</returns>
        public bool MatchUrl(params string[] urlParts)
        {
            return urlParts.All(x => _webDriver.Url.Contains(x));
        }

        /// <summary>
        /// Checks if the URL contains all the expected parts
        /// </summary>
        /// <typeparam name="TPage">Type of the view should be matched against</typeparam>
        /// <returns>Returns true if the URL is correct</returns>
        public bool MatchUrl<TPage>() where TPage : View
        {
            return MatchUrl(typeof(TPage));
        }

        /// <summary>
        /// Checks if the URL contains all the expected parts
        /// </summary>
        /// <param name="pageType">Type of the view should be matched against</param>
        /// <returns>Returns true if the URL is correct</returns>
        public bool MatchUrl(Type pageType)
        {
            var loadedAttribute = pageType.GetCustomAttribute<CheckUrlAttribute>();
            return loadedAttribute == null || MatchUrl(loadedAttribute.UrlParts.ToArray());
        }
    }
}
