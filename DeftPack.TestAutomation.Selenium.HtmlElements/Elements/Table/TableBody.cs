﻿using DeftPack.TestAutomation.Selenium.HtmlElements.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DeftPack.TestAutomation.Selenium.HtmlElements.Elements.Table
{
    [HtmlTag("tbody")]
    public class TableBody : Element
    {
        public IEnumerable<TableRow> Rows
        {
            get { return ProxyObject.FindElements(By.TagName("tr")).Select(x => new TableRow { ProxyObject = x }); }
        }
    }
}
