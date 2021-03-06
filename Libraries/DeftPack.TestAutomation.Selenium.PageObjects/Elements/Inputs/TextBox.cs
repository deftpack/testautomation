﻿using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: textarea and input [url, text, search, password, email]
    /// </summary>
    [HtmlTag("textarea")]
    [HtmlInput(InputTypes.Url)]
    [HtmlInput(InputTypes.Text)]
    [HtmlInput(InputTypes.Search)]
    [HtmlInput(InputTypes.Password)]
    [HtmlInput(InputTypes.Email)]
    public class TextBox : Element, IEditable
    {
        public TextBox(IWebElement proxyObject) : base(proxyObject) { }

        public void Enter(string text)
        {
            ProxyObject.SendKeys(text);
        }

        public string Text
        {
            get { return ProxyObject.Text; }
        }
    }
}
