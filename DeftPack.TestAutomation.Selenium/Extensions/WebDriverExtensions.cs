using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DeftPack.TestAutomation.Selenium.Extensions
{
    public static class WebDriverExtensions
    {
        private static readonly int Timeout = WebDriverConfiguration.Config.DefaultDriverWaitSeconds;

        /// <summary>
        /// This method is used to Navigate to a specific URL
        /// </summary>
        public static void NavigateToUrl(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        ///  To verifies if an Object is Displayed on a Page. It uses Object's XPath Property to identify
        /// </summary>
        public static bool VerifyObjectDisplayed(this IWebDriver webDriver, string objectXPath)
        {
            var objectLoaded = GetObject(webDriver, objectXPath);
            return objectLoaded != null && objectLoaded.Displayed;
        }

        /// <summary>
        /// This method verifies if a particular text is present within the screen
        /// </summary>
        public static void VerifyText(this IWebDriver webDriver, string objectXPath, string expectedText)
        {
            var objectLoaded = GetObject(webDriver, objectXPath);

            if (objectLoaded == null)
                throw new TextNotFoundException(expectedText);
            if (objectLoaded.Text != expectedText)
                throw new TextNotFoundException(expectedText, objectLoaded.Text);
        }

        /// <summary>
        /// This method verifies that a particular object is not displayed on the screen
        /// </summary>   
        public static bool VerifyObjectNotLoaded(this IWebDriver webDriver, string objectXPath)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(Timeout));
                wait.Until(element => element.FindElement(By.XPath(objectXPath)));
                
            }
            catch
            {
                return true;
            }

            return false;
        }

        public static string SwitchToNewWindow(this IWebDriver webDriver)
        {
            var parentWindow = webDriver.CurrentWindowHandle;
            List<string> handles = webDriver.WindowHandles.ToList<string>();
            webDriver.SwitchTo().Window(handles.Last());
            return parentWindow;
        }

        public static void SwitchToParentWindow(this IWebDriver webDriver, string parentWindow)
        {
            webDriver.SwitchTo().Window(parentWindow);
        }

        private static IWebElement GetObject(IWebDriver webDriver, string objectXPath)
        {
            IWebElement objectLoaded = null;

            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(Timeout));
                objectLoaded = wait.Until(element => element.FindElement(By.XPath(objectXPath)));
            }
            catch (WebDriverTimeoutException wdte)
            {
                if (wdte.InnerException != null)
                    throw wdte.InnerException;
            }

            return objectLoaded;
        }
    }
}
