using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Media
{
    [HtmlTag("img")]
    public class Image : Element
    {
        internal Image(IWebElement proxyObject) : base(proxyObject) { }

        public string Source
        {
            get { return ProxyObject.GetAttribute("src"); }
        }
    }
}
