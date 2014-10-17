using DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public class ElementProvider : IElementProvider
    {
        private readonly ISelectorBuilderFactory _selectorBuilderFactory;
        private readonly IElementFactory _elementFactory;
        private readonly IJavaScriptExecutor _executor;

        public ElementProvider(
            ISelectorBuilderFactory selectorBuilderFactory,
            IJavaScriptExecutor executor,
            IElementFactory elementFactory)
        {
            _executor = executor;
            _selectorBuilderFactory = selectorBuilderFactory;
            _elementFactory = elementFactory;

            _executor.InitilaizejQuery();
        }

        public ISelectorBuilder Any
        {
            get { return SelectorBuilder.Any; }
        }

        public ISelectorBuilder Tag(string tagName)
        {
            return new SelectorBuilder(tagName);
        }

        public TElement Query<TElement>(Func<ISelectorBuilder> builderFunc) where TElement : Element
        {
            return _elementFactory.Create<TElement>(_executor.jQueryElement(builderFunc().Build()));
        }

        public TElement Query<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
            where TElement : Element
        {
            var selector = string.Join(", ",
                _selectorBuilderFactory.Create<TElement>(builderFunc).Select(x => x.Build()));
            return _elementFactory.Create<TElement>(_executor.jQueryElement(selector));
        }
    }
}
