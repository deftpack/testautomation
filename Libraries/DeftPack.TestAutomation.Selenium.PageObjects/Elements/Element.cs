using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    public abstract class Element : IElement
    {
        protected readonly IWebElement ProxyObject;

        protected Element(IWebElement proxyObject)
        {
            ProxyObject = proxyObject;
        }

        public string TagName
        {
            get { return ProxyObject.TagName; }
        }

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
    }
}
