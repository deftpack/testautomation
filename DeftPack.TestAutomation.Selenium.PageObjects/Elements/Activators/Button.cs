using DeftPack.TestAutomation.Selenium.PageObjects.Capabilities;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators
{
    [HtmlTag("button")]
    [HtmlInput(InputTypes.Button)]
    [HtmlInput(InputTypes.Reset)]
    [HtmlInput(InputTypes.Submit)]
    [HtmlInput(InputTypes.Image)]
    public class Button : Element, IClickable, ITextual
    {
        internal Button(IWebElement proxyObject) : base(proxyObject) { }

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
