using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table
{
    [HtmlTag("tr")]
    public class TableRow : Element
    {
        internal TableRow(IWebElement proxyObject, IEnumerable<TableCell> cells)
            : base(proxyObject)
        {
            Cells = cells;
        }

        public IEnumerable<TableCell> Cells { get; private set; }
    }
}
