using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    internal static class WebDriverQueryExtensions
    {
        internal static void InitilaizejQuery(this IWebDriver webDriver)
        {
            ((IJavaScriptExecutor)webDriver)
                .ExecuteScript(LoadContent("DeftPack.TestAutomation.Selenium.PageObjects.jQueryLoader.js"));
        }

        internal static IWebElement jQueryElement(this IWebDriver webDriver, string selector)
        {
            return jQueryElements(webDriver, selector).FirstOrDefault();
        }

        internal static IEnumerable<IWebElement> jQueryElements(this IWebDriver webDriver, string selector)
        {
            return (IEnumerable<IWebElement>)
                ((IJavaScriptExecutor)webDriver).ExecuteScript(string.Format(@"return $('{0}');", selector));
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
