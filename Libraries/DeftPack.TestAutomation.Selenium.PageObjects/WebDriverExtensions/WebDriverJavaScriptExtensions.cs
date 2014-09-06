﻿using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions
{
    internal static class WebDriverJavaScriptExtensions
    {
        private static object GetJsObject(this IWebDriver webDriver, string command)
        {
            return ((IJavaScriptExecutor)webDriver).ExecuteScript(string.Format(@"return {0};", command));
        }

        internal static TReturned GetJsObject<TReturned>(this IWebDriver webDriver, string command)
        {
            return (TReturned)webDriver.GetJsObject(command);
        }

        internal static void LoadJavaScriptLibray(this IWebDriver webDriver, string fileName)
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript(LoadContent(fileName));
        }

        private static string LoadContent(string fileName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}