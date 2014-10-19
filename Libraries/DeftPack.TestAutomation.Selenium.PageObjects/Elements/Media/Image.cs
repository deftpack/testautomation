using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: img
    /// </summary>
    [HtmlTag("img")]
    public class Image : Element
    {
        public Image(IWebElement proxyObject) : base(proxyObject) { }

        public string Source
        {
            get { return ProxyObject.GetAttribute("src"); }
        }
    }
}
