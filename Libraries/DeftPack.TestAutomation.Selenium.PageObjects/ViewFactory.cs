using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Selectors;
using DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers;
using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public class ViewFactory
    {
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
