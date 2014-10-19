using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;

namespace DeftPack.TestAutomation.Examples.Functional.Views.BBC
{
    public class Welcome : View
    {
        public Link WeatherLink
        {
            get
            {
                return Elements.Query<Link>(
                        x => x.WithText("Weather").ChildOf(Elements.Tag("div").WithCssClass("orb-nav-section")));
            }
        }
    }
}
