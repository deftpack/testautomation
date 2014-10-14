using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Media;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;
using DeftPack.TestAutomation.Selenium.PageObjects.Views;

namespace DeftPack.TestAutomation.Examples.Functional.Views.TheVerge
{
    public class LoginPopUp : View
    {
        public TextBox UserNameInput
        {
            get { return Query<TextBox>(x => x.WithHtmlAttribute("name", "username")); }
        }
        public TextBox PasswordInput
        {
            get { return Query<TextBox>(x => x.WithHtmlAttribute("name", "password")); }
        }
        public CheckBox RememberMe
        {
            get { return Query<CheckBox>(x => x.WithId("remember_me")); }
        }
        public Button LogInButton
        {
            get { return Query<Button>(x => x.WithHtmlAttribute("value", "Log in")); }
        }
        public Link RegisterLink
        {
            get { return Query<Link>(x => x.WithHtmlAttribute("data-chorus-auth-goto", "register")); }
        }
        [DynamicElement]
        public Label LoginErrorMessage
        {
            get { return Query<Label>(x => x.WithCssClass("error").ChildOf(Any.WithId("chorus-auth-password"))); }
        }
    }
}
