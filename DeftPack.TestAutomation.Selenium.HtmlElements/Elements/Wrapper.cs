using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements
{
    public class Wrapper : Element, IContainer
    {
        public IEnumerable<IElement> ChildElements
        {
            get { return ProxyObject.FindElements(By.XPath("child::node()")).Select(x => new Element { ProxyObject = x }); }
        }

        public string GetText()
        {
            return string.Join(" ", ProxyObject.FindElements(By.XPath("child::text()")).Select(x => x.Text));
        }
    }
}
