using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: p, h1, h2, h3, h4, h5, h6, span, label and input [hidden]
    /// </summary>
    [HtmlTag("p")]
    [HtmlTag("h1")]
    [HtmlTag("h2")]
    [HtmlTag("h3")]
    [HtmlTag("h4")]
    [HtmlTag("h5")]
    [HtmlTag("h6")]
    [HtmlTag("span")]
    [HtmlTag("label")]
    [HtmlInput(InputTypes.Hidden)]
    public class Label : Element, ITextual
    {
        public Label(IWebElement proxyObject) : base(proxyObject) { }

        public string Text
        {
            get { return ProxyObject.Text; }
        }
    }
}
