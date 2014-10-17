using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public abstract class View : IDisposable
    {
        internal IElementProvider ElementProvider;
        internal IJavaScriptHandler JavaScriptHandler;
        internal IUrlChecker UrlChecker;

        protected IElementProvider Elements
        {
            get { return ElementProvider; }
        }

        public bool IsLoaded
        {
            get { return JavaScriptHandler.IsPageReady && UrlChecker.MatchUrl(GetType()) && AreElementsPresent; }
        }

        private bool AreElementsPresent
        {
            get
            {
                var nonDynamicElementProperties = GetType().GetProperties().Where(p =>
                    p.GetCustomAttribute<DynamicElementAttribute>() == null &&
                    p.PropertyType.IsSubclassOf(typeof(Element)));
                return nonDynamicElementProperties.All(x => x.GetValue(this) != null);
            }
        }

        public bool IsRedirectedTo<TPage>() where TPage : View
        {
            return UrlChecker.MatchUrl<TPage>();
        }

        public void Dispose()
        {
            var errors = JavaScriptHandler.ErrorMessages.ToList();
            if (!errors.Any()) return;
            var message = String.Join(Environment.NewLine, errors);
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }
    }
}
