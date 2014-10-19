using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using DeftPack.TestAutomation.Selenium.PageObjects.ViewHelpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    /// <summary>
    /// An abstraction to hold all the page objects
    /// </summary>
    public abstract class View : IDisposable
    {
        internal IElementProvider ElementProvider;
        internal IJavaScriptHandler JavaScriptHandler;
        internal IUrlChecker UrlChecker;

        /// <summary>
        /// A provider which gives access to the underlying elements 
        /// </summary>
        protected IElementProvider Elements
        {
            get { return ElementProvider; }
        }

        /// <summary>
        /// Checks if the view is fully loaded (DOM is ready, AJAX finished, all the elements present on the page and the URL matches)
        /// </summary>
        public bool IsLoaded
        {
            get { return JavaScriptHandler.IsPageReady && UrlChecker.MatchUrl(GetType()) && AreElementsPresent; }
        }

        /// <summary>
        /// Checks if the page has been redirected to the described view
        /// </summary>
        /// <typeparam name="TView">Type of the view</typeparam>
        /// <returns>Returns true if URL described for the view matches the active page</returns>
        public bool IsRedirectedTo<TView>() where TView : View
        {
            return UrlChecker.MatchUrl<TView>();
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
