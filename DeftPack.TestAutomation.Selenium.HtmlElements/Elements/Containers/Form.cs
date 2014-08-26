using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Containers
{
    [HtmlTag("form")]
    public class Form : Wrapper
    {
        public string Action
        {
            get { return ProxyObject.GetAttribute("action"); }
        }
    }
}
