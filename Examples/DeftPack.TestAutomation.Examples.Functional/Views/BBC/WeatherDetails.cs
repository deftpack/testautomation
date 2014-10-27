using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.BBC
{
    [CheckUrl("bbc.co.uk", "weather", "day")]
    public class WeatherDetails : View
    {
        public Label Sunset
        {
            get
            {
                return Elements.Query<Label>(
                    x => x.WithCssClass("sunset").ChildOf(Elements.Tag("div").WithCssClass("sunrise-sunset")));
            }
        }

        public Label Sunrise
        {
            get
            {
                return Elements.Query<Label>(
                    x => x.WithCssClass("sunrise").ChildOf(Elements.Tag("div").WithCssClass("sunrise-sunset")));
            }
        }
    }
}
