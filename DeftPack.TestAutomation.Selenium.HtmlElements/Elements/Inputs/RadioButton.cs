using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Inputs
{
    [HtmlInput(InputTypes.Radio)]
    public class RadioButton : Element, ITextual
    {
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
