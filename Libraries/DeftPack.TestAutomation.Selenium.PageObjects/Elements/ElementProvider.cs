using DeftPack.TestAutomation.Selenium.PageObjects.ExecutorExtensions;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// Gets elements with the underlying client side helpers
    /// </summary>
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

        /// <summary>
        /// Returns a selector builder without tag specified
        /// </summary>
        public ISelectorBuilder Any
        {
            get { return SelectorBuilder.Any; }
        }

        /// <summary>
        /// Creates a selector builder for a given tag
        /// </summary>
        /// <param name="tagName">Tag to be specified in the selector</param>
        /// <returns>Selector builder instance</returns>
        public ISelectorBuilder Tag(string tagName)
        {
            return new SelectorBuilder(tagName);
        }

        /// <summary>
        /// Querying for an element with a given selector
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="builderFunc">Selector builder creator expression</param>
        /// <returns>Instance of an element</returns>
        public TElement Query<TElement>(Func<ISelectorBuilder> builderFunc) where TElement : Element
        {
            return _elementFactory.Create<TElement>(_executor.jQueryElement(builderFunc().Build()));
        }

        /// <summary>
        /// Querying for an element with a given selector
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="builderFunc">Selector building method chained expression</param>
        /// <returns>Instance of an element</returns>
        public TElement Query<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
            where TElement : Element
        {
            var selector = string.Join(", ",
                _selectorBuilderFactory.Create<TElement>(builderFunc).Select(x => x.Build()));
            return _elementFactory.Create<TElement>(_executor.jQueryElement(selector));
        }
    }
}
