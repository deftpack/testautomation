using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Views;

namespace DeftPack.TestAutomation.Examples.Functional.Views.TheVerge
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
