using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: tbody
    /// </summary>
    [HtmlTag("tbody")]
    public class TableBody : Element
    {
        public TableBody(IWebElement proxyObject, IEnumerable<TableRow> rows)
            : base(proxyObject)
        {
            Rows = rows;
        }

        public IEnumerable<TableRow> Rows { get; private set; }
    }
}
