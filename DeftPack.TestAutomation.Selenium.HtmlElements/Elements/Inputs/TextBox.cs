using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Inputs
{
    [HtmlTag("textarea")]
    [HtmlInput(InputTypes.Url)]
    [HtmlInput(InputTypes.Text)]
    [HtmlInput(InputTypes.Search)]
    [HtmlInput(InputTypes.Password)]
    [HtmlInput(InputTypes.Email)]
    public class TextBox : Element, IEditable
    {
        public void Enter(string text)
        {
            ProxyObject.SendKeys(text);
        }

        public string Text
        {
            get { return ProxyObject.Text; }
        }
    }
}
