using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs
{
    [HtmlInput(InputTypes.Checkbox)]
    public class CheckBox : Element
    {
        internal CheckBox(IWebElement proxyObject) : base(proxyObject) { }

        public bool IsSelected
        {
            get { return ProxyObject.Selected; }
        }

        public void SetState(bool isChecked)
        {
            if (IsSelected != isChecked)
                ProxyObject.Click();
        }

        public void Toggle()
        {
            ProxyObject.Click();
        }
    }
}
