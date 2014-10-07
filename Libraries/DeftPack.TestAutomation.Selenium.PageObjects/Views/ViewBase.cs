using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using DeftPack.TestAutomation.Selenium.PageObjects.WebDriverExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeftPack.TestAutomation.Selenium.PageObjects.Views
{
    public abstract class ViewBase : ElementProvider
    {
        public bool IsLoaded
        {
            get { return _webDriver.IsPageReady() && IsUrlMatching && AreElementsPresent; }
        }

        private bool IsUrlMatching
        {
            get
            {
                var checkViewUrlAttribute = GetType().GetCustomAttribute<CheckViewUrlAttribute>();
                return checkViewUrlAttribute == null || MatchUrl(checkViewUrlAttribute.UrlParts);
            }
        }

        private bool AreElementsPresent
        {
            get
            {
                var nonDynamicElementProperties = GetType().GetProperties().Where(p =>
                    p.GetCustomAttribute<DynamicElementAttribute>() == null && p.PropertyType.IsSubclassOf(typeof(Element)));
                return nonDynamicElementProperties.All(x => x.GetValue(this) != null);
            }
        }

        internal bool MatchUrl(IEnumerable<string> urlParts)
        {
            return urlParts.All(x => _webDriver.Url.Contains(x));
        }
    }
}
