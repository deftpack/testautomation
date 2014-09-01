using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs
{
    [HtmlInput(InputTypes.Number)]
    [HtmlInput(InputTypes.Range)]
    [HtmlInput(InputTypes.Date)]
    [HtmlInput(InputTypes.Week)]
    [HtmlInput(InputTypes.Month)]
    [HtmlInput(InputTypes.Time)]
    [HtmlInput(InputTypes.DateTime)]
    public class NumberInput : Element
    {
        public NumberInput(IWebElement proxyObject) : base(proxyObject) { }

        public int Value
        {
            get { return Int32.Parse(ProxyObject.Text); }
            set { ProxyObject.SendKeys(value.ToString()); }
        }
    }
}
