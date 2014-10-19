using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: a
    /// </summary>
    [HtmlTag("a")]
    public class Link : Wrapper, IClickable, ITextual
    {
        public Link(IWebElement proxyObject, IEnumerable<IElement> childs) : base(proxyObject, childs) { }

        public void Click()
        {
            ProxyObject.Click();
        }

        public string Text
        {
            get { return ProxyObject.Text; }
        }
    }
}
