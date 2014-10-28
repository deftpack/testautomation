using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// Create elements from the web elements
    /// </summary>
    public interface IElementFactory
    {
        /// <summary>
        /// Create element with the given type
        /// </summary>
        /// <typeparam name="TElement">Type of the element to be created</typeparam>
        /// <param name="webElement">The original web element which going to be wrapped</param>
        /// <returns>Instance of an element</returns>
        TElement Create<TElement>(IWebElement webElement) where TElement : Element;
    }
}