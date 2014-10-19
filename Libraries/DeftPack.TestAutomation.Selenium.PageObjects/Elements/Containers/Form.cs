using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: form
    /// </summary>
    [HtmlTag("form")]
    public class Form : Wrapper
    {
        public Form(IWebElement proxyObject, IEnumerable<IElement> childs) : base(proxyObject, childs) { }

        public string Action
        {
            get { return ProxyObject.GetAttribute("action"); }
        }
    }
}
