using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Views
{
    public abstract class ElementProvider
    {
        internal IWebDriver _webDriver;
        private readonly SelectorBuilderFactory _selectorBuilderFactory = new SelectorBuilderFactory();
        private readonly IElementFactory _elementFactory = new ElementFactory(new ElementTypeFinder());

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
            return _elementFactory.Create<TElement>(_webDriver.jQueryElement(builderFunc().Selector));
        }

        protected TElement QueryElement<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
            where TElement : Element
        {
            var selector = string.Join(", ",
                _selectorBuilderFactory.Create<TElement>(builderFunc).Select(x => x.Selector));
            return _elementFactory.Create<TElement>(_webDriver.jQueryElement(selector));
        }
    }
}
