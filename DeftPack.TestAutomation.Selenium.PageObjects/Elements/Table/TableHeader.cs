using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table
{
    [HtmlTag("thead")]
    public class TableHeader : Element
    {
        internal TableHeader(IWebElement proxyObject, IEnumerable<TableRow> rows)
            : base(proxyObject)
        {
            Rows = rows;
        }

        public IEnumerable<TableRow> Rows { get; private set; }
    }
}
