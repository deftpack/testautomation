﻿using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Containers
{
    [HtmlTag("form")]
    public class Form : Wrapper
    {
        internal Form(IWebElement proxyObject, IEnumerable<IElement> childs) : base(proxyObject, childs) { }

        public string Action
        {
            get { return ProxyObject.GetAttribute("action"); }
        }
    }
}