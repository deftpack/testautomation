﻿using DeftPack.TestAutomation.Selenium.PageObjects.Capabilities;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs
{
    [HtmlInput(InputTypes.File)]
    public class FileUploader : Element, IUploader
    {
        internal FileUploader(IWebElement proxyObject) : base(proxyObject) { }

        public string Path { get; private set; }
        public void Upload(string path)
        {
            Path = path;
            ProxyObject.SendKeys(path);
        }
    }
}
