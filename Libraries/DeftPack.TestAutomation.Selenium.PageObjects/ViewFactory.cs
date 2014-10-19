using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers;
using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    /// <summary>
    /// Factory class for views
    /// </summary>
    public class ViewFactory : IViewFactory
    {
        /// <summary>
        /// Creates a given type of view
        /// </summary>
        /// <typeparam name="TView">Type of the view to be created</typeparam>
        /// <param name="webDriver">The web driver to be injected</param>
        /// <returns>A view</returns>
        public TView Create<TView>(IWebDriver webDriver) where TView : View
        {
            return (TView)Create(typeof(TView), webDriver);
        }

        /// <summary>
        /// Creates a given type of view
        /// </summary>
        /// <param name="viewType">Type of the view to be created</param>
        /// <param name="webDriver">The web driver to be injected</param>
        /// <returns>A view</returns>
        public object Create(Type viewType, IWebDriver webDriver)
        {
            var view = Activator.CreateInstance(viewType);
            ((View)view).ElementProvider = new ElementProvider(
                new SelectorBuilderFactory(),
                (IJavaScriptExecutor)webDriver,
                new ElementFactory(new ElementTypeFinder()));
            ((View)view).JavaScriptHandler = new JavaScriptHandler((IJavaScriptExecutor)webDriver);
            ((View)view).UrlChecker = new UrlChecker(webDriver);
            return view;
        }
    }
}
