using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Table
{
    [HtmlTag("tr")]
    public class TableRow : Element
    {
        public IEnumerable<TableCell> Cells
        {
            get
            {
                var tds = ProxyObject.FindElements(By.TagName("td"));
                var ths = ProxyObject.FindElements(By.TagName("th"));
                return tds.Union(ths).Select(x => new TableCell { ProxyObject = x });
            }
        }
    }
}
