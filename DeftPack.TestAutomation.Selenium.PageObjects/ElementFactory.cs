using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Media;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    internal class ElementFactory
    {
        public Element Create(IWebElement webElement)
        {
            return new Label(webElement);
        }
    }
}
