using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.BBC
{
    [CheckUrl("bbc.co.uk", "weather")]
    public class Weather : View
    {
        public Link TodayLink
        {
            get
            {
                return Elements.Query<Link>(x => x.ChildOf(Elements.Tag("li").WithCssClass("daily__day-tab").ChildOf(
                      Elements.Tag("ul").WithCssClass("daily")).First()));
            }
        }

        public Link TomorrorLink
        {
            get
            {
                return Elements.Query<Link>(x => x.ChildOf(Elements.Tag("li").WithCssClass("daily__day-tab").ChildOf(
                      Elements.Tag("ul").WithCssClass("daily")).InSequence(1)));
            }
        }
        public Link DayAfterTomorrowLink
        {
            get
            {
                return Elements.Query<Link>(x => x.ChildOf(Elements.Tag("li").WithCssClass("daily__day-tab").ChildOf(
                      Elements.Tag("ul").WithCssClass("daily")).InSequence(2)));
            }
        }
        public Link ThreeDayFromNowLink
        {
            get
            {
                return Elements.Query<Link>(x => x.ChildOf(Elements.Tag("li").WithCssClass("daily__day-tab").ChildOf(
                      Elements.Tag("ul").WithCssClass("daily")).InSequence(3)));
            }
        }
        public Link FourDaysFromNowLink
        {
            get
            {
                return Elements.Query<Link>(x => x.ChildOf(Elements.Tag("li").WithCssClass("daily__day-tab").ChildOf(
                      Elements.Tag("ul").WithCssClass("daily")).InSequence(4)));
            }
        }
    }
}
