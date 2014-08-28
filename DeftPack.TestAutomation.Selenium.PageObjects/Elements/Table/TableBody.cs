using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table
{
    [HtmlTag("tbody")]
    public class TableBody : Element
    {
        internal TableBody(IWebElement proxyObject, IEnumerable<TableRow> rows)
            : base(proxyObject)
        {
            Rows = rows;
        }

        public IEnumerable<TableRow> Rows { get; private set; }
    }
}
