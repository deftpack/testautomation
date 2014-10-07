using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Capabilities;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs
{
    [HtmlTag("select")]
    public class Dropdown : Element, ISelectable
    {
        public Dropdown(IWebElement proxyObject) : base(proxyObject) { }

        public IEnumerable<string> Options
        {
            get { return SelectElement.Options.Select(x => x.Text); }
        }

        public string Value
        {
            get { return SelectElement.SelectedOption.Text; }
            set { SelectElement.SelectByText(value); }
        }

        public void Select(int index)
        {
            SelectElement.SelectByIndex(index);
        }

        private SelectElement SelectElement
        {
            get { return new SelectElement(ProxyObject); }
        }
    }
}
