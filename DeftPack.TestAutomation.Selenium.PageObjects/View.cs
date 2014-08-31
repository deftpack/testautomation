using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public abstract class View : IDisposable
    {
        protected IWebDriver WebDriver
        {
            get { return _webDriver; }
        }

        private readonly SelectorBuilderFactory _selectorBuilderFactory;
        private readonly ElementFactory _elementFactory;
        private IWebDriver _webDriver;

        protected View()
        {
            _elementFactory = new ElementFactory();
            _selectorBuilderFactory = new SelectorBuilderFactory();
        }

        internal void SetWebDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.InitilaizejQuery();
            _webDriver.InitilaizeJavaScriptErrorHarvester();
        }

        public bool IsLoaded
        {
            get { return WebDriver.IsPageReady() && IsUrlMatching && AreElementsPresent; }
        }


        public bool IsRedirectedTo<TPage>() where TPage : View
        {
            var loadedAttribute = typeof(TPage).GetCustomAttribute<CheckViewUrlAttribute>();
            return MatchUrl(loadedAttribute.UrlParts);
        }

        public bool IsRedirectedTo(params string[] url)
        {
            return MatchUrl(url);
        }

        public string JavaScriptErrors
        {
            get
            {
                var messages = WebDriver.GetJavaScriptErrorMessages().ToArray();
                return messages.Any() ? string.Join(Environment.NewLine, messages) : null;
            }
        }

        protected ISelectorBuilder Any
        {
            get { return SelectorBuilder.Any; }
        }

        protected ISelectorBuilder Element(string tagName)
        {
            return new SelectorBuilder(tagName);
        }

        protected TElement QueryElement<TElement>(Func<ISelectorBuilder> builderFunc) where TElement : Element
        {
            return _elementFactory.Create<TElement>(WebDriver, builderFunc().Selector);
        }

        protected TElement QueryElement<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc) where TElement : Element
        {
            var selector = string.Join(", ", _selectorBuilderFactory.Create<TElement>(builderFunc).Select(x => x.Selector));
            return _elementFactory.Create<TElement>(WebDriver, selector);
        }

        private bool IsUrlMatching
        {
            get { return CheckViewUrlAttribute == null || MatchUrl(CheckViewUrlAttribute.UrlParts); }
        }

        private bool AreElementsPresent
        {
            get
            {
                return GetType().GetProperties()
                    .Where(p => p.GetCustomAttribute<DynamicElementAttribute>() == null)
                    .All(x => x.GetValue(this) != null);
            }
        }

        private bool MatchUrl(IEnumerable<string> urlParts)
        {
            return urlParts.All(x => WebDriver.Url.Contains(x));
        }

        private CheckViewUrlAttribute CheckViewUrlAttribute
        {
            get { return GetType().GetCustomAttribute<CheckViewUrlAttribute>(); }
        }

        public void Dispose()
        {
            var errors = JavaScriptErrors;

            if (errors != null)
            {
                Console.WriteLine(errors);
                Debug.WriteLine(errors);
            }
        }
    }
}
