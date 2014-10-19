using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: button and input [button, reset, submit, image]
    /// </summary>
    [HtmlTag("button")]
    [HtmlInput(InputTypes.Button)]
    [HtmlInput(InputTypes.Reset)]
    [HtmlInput(InputTypes.Submit)]
    [HtmlInput(InputTypes.Image)]
    public class Button : Element, IClickable, ITextual
    {
        public Button(IWebElement proxyObject) : base(proxyObject) { }

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
