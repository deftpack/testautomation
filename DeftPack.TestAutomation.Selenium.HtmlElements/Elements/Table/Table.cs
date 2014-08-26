using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Table
{
    [HtmlTag("table")]
    public class Table : Element
    {
        public TableHeader Header
        {
            get { return new TableHeader { ProxyObject = ProxyObject.FindElement(By.TagName("thead")) }; }
        }

        public TableBody Body
        {
            get { return new TableBody { ProxyObject = ProxyObject.FindElement(By.TagName("tbody")) }; }
        }

        public TableFooter Footer
        {
            get { return new TableFooter { ProxyObject = ProxyObject.FindElement(By.TagName("tfoot")) }; }
        }
    }
}
