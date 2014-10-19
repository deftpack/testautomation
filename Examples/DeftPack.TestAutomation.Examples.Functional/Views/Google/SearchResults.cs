using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.Google
{
    [CheckUrl("google", "q=")]
    public class SearchResults : View
    {
        public Link FirstResult
        {
            get { return Elements.Query<Link>(x => x.First().ChildOf(Elements.Tag("li").WithCssClass("g").First())); }
        }
    }
}
