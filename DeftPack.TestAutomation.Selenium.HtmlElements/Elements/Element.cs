using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements
{
    public class Element : IElement
    {
        public string Id
        {
            get { return ProxyObject.GetAttribute("id"); }
        }
        public IEnumerable<string> Classes
        {
            get { return ProxyObject.GetAttribute("class").Split(' '); }
        }
        public bool IsVisible
        {
            get { return ProxyObject.Displayed; }
        }

        public IWebElement ProxyObject { get; set; }
    }
}
