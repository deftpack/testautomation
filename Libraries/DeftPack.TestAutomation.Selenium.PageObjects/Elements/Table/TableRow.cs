﻿using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: tr
    /// </summary>
    [HtmlTag("tr")]
    public class TableRow : Element
    {
        public TableRow(IWebElement proxyObject, IEnumerable<TableCell> cells)
            : base(proxyObject)
        {
            Cells = cells;
        }

        public IEnumerable<TableCell> Cells { get; private set; }
    }
}
