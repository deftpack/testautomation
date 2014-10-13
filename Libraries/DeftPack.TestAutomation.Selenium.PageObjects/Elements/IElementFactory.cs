using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public interface IElementFactory
    {
        TElement Create<TElement>(IWebElement webElement) where TElement : Element;
    }
}