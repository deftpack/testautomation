using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface IElementTypeFinder
    {
        Type Find(IWebElement webElement);
    }
}