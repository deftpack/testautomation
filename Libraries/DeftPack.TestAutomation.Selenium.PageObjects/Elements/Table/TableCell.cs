using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Table
{
    [HtmlTag("td")]
    [HtmlTag("th")]
    public class TableCell : Wrapper
    {
        public TableCell(IWebElement proxyObject, IEnumerable<IElement> childs)
            : base(proxyObject, childs)
        {
        }
    }
}
