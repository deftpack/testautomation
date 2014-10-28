using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    /// <summary>
    /// Factory for views
    /// </summary>
    public interface IViewFactory
    {
        /// <summary>
        /// Creates a given type of view
        /// </summary>
        /// <typeparam name="TView">Type of the view to be created</typeparam>
        /// <param name="webDriver">The web driver to be injected</param>
        /// <returns>A view</returns>
        TView Create<TView>(IWebDriver webDriver) where TView : View;

        /// <summary>
        /// Creates a given type of view
        /// </summary>
        /// <param name="viewType">Type of the view to be created</param>
        /// <param name="webDriver">The web driver to be injected</param>
        /// <returns>A view</returns>
        object Create(Type viewType, IWebDriver webDriver);
    }
}