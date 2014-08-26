using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Activators
{
    [HtmlTag("button")]
    [HtmlInput(InputTypes.Button)]
    [HtmlInput(InputTypes.Reset)]
    [HtmlInput(InputTypes.Submit)]
    [HtmlInput(InputTypes.Image)]
    public class Button : Element, IClickable, ITextual
    {
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
