using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Views;

namespace DeftPack.TestAutomation.Examples.Functional.Views.Google
{
    [CheckViewUrl("google", "q=")]
    public class SearchResults : View
    {
        public Link FirstResult
        {
            get { return Query<Link>(x => x.First().ChildOf(Tag("li").WithCssClass("g").First())); }
        }
    }
}
