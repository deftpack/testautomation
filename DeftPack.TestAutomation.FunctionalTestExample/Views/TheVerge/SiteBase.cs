using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;

namespace DeftPack.TestAutomation.FunctionalTestExample.Views.TheVerge
{
    [CheckViewUrl("theverge.com")]
    public class SiteBase : View
    {
        public Link UserLink
        {
            get { return QueryElement<Link>(x => x.WithHtmlAttribute("data-chorus-auth", "login")); }
        }
    }
}
