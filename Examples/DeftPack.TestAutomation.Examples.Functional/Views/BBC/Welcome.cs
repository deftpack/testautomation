using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.BBC
{
    [CheckUrl("bbc.co.uk")]
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
