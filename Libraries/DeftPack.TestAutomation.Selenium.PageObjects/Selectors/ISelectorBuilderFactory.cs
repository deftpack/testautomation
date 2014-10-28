using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using System;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Selectors
{
    /// <summary>
    /// Factory class for selector builders
    /// </summary>
    public interface ISelectorBuilderFactory
    {
        /// <summary>
        /// Creates selector builders for the given element type
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <returns>Enumeration of selector builders</returns>
        IEnumerable<ISelectorBuilder> Create<TElement>() where TElement : Element;

        /// <summary>
        /// Creates selector builders for the given element type
        /// </summary>
        /// <typeparam name="TElement">Type of the element</typeparam>
        /// <param name="builderFunc">Selector builder expression to be applied on each builder</param>
        /// <returns>Enumeration of selector builders</returns>
        IEnumerable<ISelectorBuilder> Create<TElement>(Func<ISelectorBuilder, ISelectorBuilder> builderFunc)
            where TElement : Element;
    }
}