using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: thead
    /// </summary>
    [HtmlTag("thead")]
    public class TableHeader : Element
    {
        public TableHeader(IWebElement proxyObject, IEnumerable<TableRow> rows)
            : base(proxyObject)
        {
            Rows = rows;
        }

        public IEnumerable<TableRow> Rows { get; private set; }
    }
}
