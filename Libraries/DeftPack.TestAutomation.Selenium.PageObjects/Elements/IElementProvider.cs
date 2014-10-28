using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// Gets elements
    /// </summary>
    public interface IElementProvider
    {
        /// <summary>
        /// Returns a selector builder without tag specified
        /// </summary>
        ISelectorBuilder Any { get; }

        /// <summary>
        /// Creates a selector builder for a given tag
        /// </summary>
        /// <param name="tagName">Tag to be specified in the selector</param>
        /// <returns>Selector builder instance</returns>
        ISelectorBuilder Tag(string tagName);

        /// <summary>
        /// Querying for an element with a given selector
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="builderFunc">Selector builder creator expression</param>
        /// <returns>Instance of an element</returns>
        TElement Query<TElement>(Func<ISelectorBuilder> builderFunc) where TElement : Element;

        /// <summary>
        /// Querying for an element with a given selector
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="builderFunc">Selector building method chained expression</param>
        /// <returns>Instance of an element</returns>
        TElement Query<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc) where TElement : Element;
    }
}