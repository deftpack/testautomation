using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using DeftPack.TestAutomation.Selenium.PageObjects.Views;

namespace DeftPack.TestAutomation.Examples.Functional.Views.Google
{
    [CheckViewUrl("google")]
    public class Welcome : View
    {
        public TextBox SearchBar
        {
            get { return Query<TextBox>(x => x.WithId("gbqfq").Visible()); }
        }
        public Button SearchButton
        {
            get { return Query<Button>(x => x.WithId("gbqfba").Visible()); }
        }

        [DynamicElement]
        public Button SmallSearchButton
        {
            get { return Query<Button>(x => x.WithId("gbqfb").Visible()); }
        }
    }
}
