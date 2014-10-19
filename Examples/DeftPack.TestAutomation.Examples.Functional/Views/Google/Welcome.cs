using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.Google
{
    [CheckUrl("google")]
    public class Welcome : View
    {
        public TextBox SearchBar
        {
            get { return Elements.Query<TextBox>(x => x.WithId("gbqfq").Visible()); }
        }
        public Button SearchButton
        {
            get { return Elements.Query<Button>(x => x.WithId("gbqfba").Visible()); }
        }

        [DynamicElement]
        public Button SmallSearchButton
        {
            get { return Elements.Query<Button>(x => x.WithId("gbqfb").Visible()); }
        }
    }
}
