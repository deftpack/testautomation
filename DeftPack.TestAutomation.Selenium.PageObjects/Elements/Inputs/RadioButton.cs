using DeftPack.TestAutomation.Selenium.PageObjects.Capabilities;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs
{
    [HtmlInput(InputTypes.Radio)]
    public class RadioButton : Element, ITextual
    {
        internal RadioButton(IWebElement proxyObject) : base(proxyObject) { }

        public bool IsSelected
        {
            get { return ProxyObject.Selected; }
        }

        public string Group
        {
            get { return ProxyObject.GetAttribute("name"); }
        }

        public void Select()
        {
            ProxyObject.Click();
        }

        public string Text
        {
            get { return ProxyObject.Text; }
        }
    }
}
