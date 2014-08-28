using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Containers
{
    [HtmlTag("iframe")]
    [HtmlTag("frame")]
    public class Frame : Wrapper
    {
        internal Frame(IWebElement proxyObject, IEnumerable<IElement> childs) : base(proxyObject, childs) { }

        public string Source
        {
            get { return ProxyObject.GetAttribute("src"); }
        }
    }
}
