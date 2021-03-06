﻿using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using OpenQA.Selenium;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Elements
{
    /// <summary>
    /// HTML: input [file]
    /// </summary>
    [HtmlInput(InputTypes.File)]
    public class FileUploader : Element, IUploader
    {
        public FileUploader(IWebElement proxyObject) : base(proxyObject) { }

        public string Path { get; private set; }
        public void Upload(string path)
        {
            Path = path;
            ProxyObject.SendKeys(path);
        }
    }
}
