using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;

namespace DeftPack.TestAutomation.Examples.Functional.Views.Google
{
    [CheckViewUrl("google", "q=")]
    public class SearchResults : View
    {
        public Link FirstResult
        {
            get { return QueryElement<Link>(x => x.First().ChildOf(Element("li").WithCssClass("g").First())); }
        }
    }
}
