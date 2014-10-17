using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers
{
    public class UrlChecker : IUrlChecker
    {
        private readonly IWebDriver _webDriver;

        public UrlChecker(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool MatchUrl(params string[] urlParts)
        {
            return urlParts.All(x => _webDriver.Url.Contains(x));
        }

        public bool MatchUrl<TPage>() where TPage : View
        {
            return MatchUrl(typeof(TPage));
        }

        public bool MatchUrl(Type pageType)
        {
            var loadedAttribute = pageType.GetCustomAttribute<CheckUrlAttribute>();
            return loadedAttribute == null || MatchUrl(loadedAttribute.UrlParts.ToArray());
        }
    }
}
