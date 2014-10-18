using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers;
using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public class ViewFactory : IViewFactory
    {
        public TView Create<TView>(IWebDriver webDriver) where TView : View
        {
            return (TView)Create(typeof(TView), webDriver);
        }

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
