using DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Views
{
    public abstract class View : ViewBase, IDisposable
    {
        protected IWebDriver WebDriver
        {
            get { return _webDriver; }
        }

        internal void SetWebDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.InitilaizejQuery();
            _webDriver.InitilaizeJavaScriptErrorHarvester();
        }

        public bool IsRedirectedTo<TPage>() where TPage : View
        {
            var loadedAttribute = typeof(TPage).GetCustomAttribute<CheckViewUrlAttribute>();
            return MatchUrl(loadedAttribute.UrlParts);
        }

        public bool IsRedirectedTo(params string[] url)
        {
            return MatchUrl(url);
        }

        public string JavaScriptErrors
        {
            get
            {
                var messages = WebDriver.GetJavaScriptErrorMessages().ToArray();
                return messages.Any() ? string.Join(Environment.NewLine, messages) : null;
            }
        }

        public void Dispose()
        {
            var errors = JavaScriptErrors;
            if (errors != null)
            {
                Console.WriteLine(errors);
                Debug.WriteLine(errors);
            }
        }
    }
}
