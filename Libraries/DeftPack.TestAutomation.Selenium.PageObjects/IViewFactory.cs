using System;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public interface IViewFactory
    {
        TView Create<TView>(IWebDriver webDriver) where TView : View;
        object Create(Type viewType, IWebDriver webDriver);
    }
}