using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table
{
    [HtmlTag("table")]
    public class Table : Element
    {
        public Table(IWebElement proxyObject, TableBody body, TableHeader header = null, TableFooter footer = null)
            : base(proxyObject)
        {
            Body = body;
            Header = header;
            Footer = footer;
        }

        public TableHeader Header { get; private set; }
        public TableBody Body { get; private set; }
        public TableFooter Footer{ get; private set; }
    }
}
