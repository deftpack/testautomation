using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.TheVerge
{
    [CheckUrl("theverge.com")]
    public class SiteBase : View
    {
        public Link UserLink
        {
            get { return Elements.Query<Link>(x => x.WithHtmlAttribute("data-chorus-auth", "login")); }
        }
    }
}
