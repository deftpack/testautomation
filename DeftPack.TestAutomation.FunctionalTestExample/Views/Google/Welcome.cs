using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs;

namespace DeftPack.TestAutomation.FunctionalTestExample.Views.Google
{
    [CheckViewUrl("google")]
    public class Welcome : View
    {
        public TextBox SearchBar
        {
            get { return QueryElement<TextBox>(x => x.WithId("gbqfq").Visible()); }
        }
        public Button SearchButton
        {
            get { return QueryElement<Button>(x => x.WithId("gbqfba").Visible()); }
        }
    }
}
