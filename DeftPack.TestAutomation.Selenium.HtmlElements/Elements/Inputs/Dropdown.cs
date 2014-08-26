using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Inputs
{
    [HtmlTag("select")]
    public class Dropdown : Element, ISelectable
    {
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
