using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: input [checkbox]
    /// </summary>
    [HtmlInput(InputTypes.Checkbox)]
    public class CheckBox : Element
    {
        public CheckBox(IWebElement proxyObject) : base(proxyObject) { }

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
