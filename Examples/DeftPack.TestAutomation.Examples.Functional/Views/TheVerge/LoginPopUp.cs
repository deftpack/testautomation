using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.TheVerge
{
    public class LoginPopUp : View
    {
        public TextBox UserNameInput
        {
            get { return Elements.Query<TextBox>(x => x.WithHtmlAttribute("name", "username")); }
        }
        public TextBox PasswordInput
        {
            get { return Elements.Query<TextBox>(x => x.WithHtmlAttribute("name", "password")); }
        }
        public CheckBox RememberMe
        {
            get { return Elements.Query<CheckBox>(x => x.WithId("remember_me")); }
        }
        public Button LogInButton
        {
            get { return Elements.Query<Button>(x => x.WithHtmlAttribute("value", "Log in")); }
        }
        public Link RegisterLink
        {
            get { return Elements.Query<Link>(x => x.WithHtmlAttribute("data-chorus-auth-goto", "register")); }
        }
        [DynamicElement]
        public Label LoginErrorMessage
        {
            get { return Elements.Query<Label>(x => x.WithCssClass("error").ChildOf(Elements.Any.WithId("chorus-auth-password"))); }
        }
    }
}
