using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Containers
{
    [HtmlTag("iframe")]
    public class Frame : Wrapper
    {
        public string Source
        {
            get { return ProxyObject.GetAttribute("src"); }
        }
    }
}
