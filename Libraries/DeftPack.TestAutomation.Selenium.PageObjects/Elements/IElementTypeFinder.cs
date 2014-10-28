using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// Looks up element types
    /// </summary>
    public interface IElementTypeFinder
    {
        /// <summary>
        /// Find a matching element type for a web element
        /// </summary>
        /// <param name="webElement">Web element to inspect</param>
        /// <returns>Element Type</returns>
        Type Find(IWebElement webElement);
    }
}