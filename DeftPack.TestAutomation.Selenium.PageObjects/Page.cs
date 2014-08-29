using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public abstract class Page
    {
        private readonly IWebDriver _webDriver;
        private readonly SelectorBuilderFactory _selectorBuilderFactory;
        private readonly ElementFactory _elementFactory;

        protected Page(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.InitilaizejQuery();
            _elementFactory = new ElementFactory();
            _selectorBuilderFactory = new SelectorBuilderFactory();
        }

        protected ISelectorBuilder Any {
            get { return SelectorBuilder.Any; }
        }

        protected TElement QueryElement<TElement>(Func<ISelectorBuilder> builderFunc) where TElement : Element
        {
            return _elementFactory.Create<TElement>(_webDriver, builderFunc().Selector);
        }

        protected TElement QueryElement<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc) where TElement : Element
        {
            var selector = string.Join(", ",_selectorBuilderFactory.Create<TElement>(builderFunc).Select(x => x.Selector));
            return _elementFactory.Create<TElement>(_webDriver, selector);
        }
    }
}
