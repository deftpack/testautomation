using DeftPack.TestAutomation.Selenium.HtmlElements.Capabilities;
using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Media
{
    [HtmlTag("p")]
    [HtmlTag("h1")]
    [HtmlTag("h2")]
    [HtmlTag("h3")]
    [HtmlTag("h4")]
    [HtmlTag("h5")]
    [HtmlTag("h6")]
    [HtmlTag("span")]
    [HtmlTag("label")]
    [HtmlInput(InputTypes.Hidden)]
    public class Label : Element, ITextual
    {
        public string Text
        {
            get { return ProxyObject.Text; }
        }
    }
}
