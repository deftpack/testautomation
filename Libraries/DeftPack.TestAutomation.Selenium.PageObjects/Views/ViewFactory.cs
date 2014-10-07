using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Views
{
    public class ViewFactory
    {
        public object Create(Type viewType, IWebDriver webDriver)
        {
            var view = Activator.CreateInstance(viewType);
            ((View)view).SetWebDriver(webDriver);
            return view;
        }
    }
}
