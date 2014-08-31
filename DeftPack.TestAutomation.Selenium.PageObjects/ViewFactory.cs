using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
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
