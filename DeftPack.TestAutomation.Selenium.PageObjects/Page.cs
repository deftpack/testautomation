using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public abstract class Page : IDisposable
    {
        protected IWebDriver WebDriver { get; private set; }
        private readonly SelectorBuilderFactory _selectorBuilderFactory;
        private readonly ElementFactory _elementFactory;

        protected Page(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            WebDriver.InitilaizejQuery();
            WebDriver.InitilaizeJavaScriptErrorHarvester();

            _elementFactory = new ElementFactory();
            _selectorBuilderFactory = new SelectorBuilderFactory();
        }

        public bool IsLoaded
        {
            get { return WebDriver.IsPageReady() && IsUrlMatching && AreElementsPresent; }
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
            get { return LoadedAttribute == null || WebDriver.Url.Contains(LoadedAttribute.UrlPart); }
        }

        private bool AreElementsPresent
        {
            get
            {
                return LoadedAttribute == null || !LoadedAttribute.IsStrict ||
                       GetType().GetProperties().All(x => x.GetValue(this) != null);
            }
        }

        private LoadedAttribute LoadedAttribute
        {
            get { return GetType().GetCustomAttribute<LoadedAttribute>(); }
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
