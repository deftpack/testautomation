using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Media;
using DeftPack.TestAutomation.Selenium.PageObjects.MetaInformation;

namespace DeftPack.TestAutomation.Examples.Functional.Views.TheVerge
{
    public class RegisterPopUp : View
    {
        public TextBox UserNameInput
        {
            get { return Elements.Query<TextBox>(x => x.WithHtmlAttribute("name", "user[username]").WithCssClass("register-username")); }
        }
        public TextBox PasswordInput
        {
            get { return Elements.Query<TextBox>(x => x.WithHtmlAttribute("name", "user[password]")); }
        }
        public TextBox EmailAddressInput
        {
            get { return Elements.Query<TextBox>(x => x.WithHtmlAttribute("name", "user[email]").WithCssClass("register-email")); }
        }
        public CheckBox NewsLetter
        {
            get { return Elements.Query<CheckBox>(x => x.WithId("newsletter-subscribe").WithHtmlAttribute("name", "user[newsletter]")); }
        }
        public Button RegisterButton
        {
            get { return Elements.Query<Button>(x => x.WithHtmlAttribute("value", "Continue")); }
        }
        public Link LoginLink
        {
            get { return Elements.Query<Link>(x => x.WithHtmlAttribute("data-chorus-auth-goto", "login")); }
        }
        [DynamicElement]
        public Label UserNameValidationMessage
        {
            get { return Elements.Query<Label>(x => x.WithId("username")); }
        }
        [DynamicElement]
        public Label PasswordValidationMessage
        {
            get { return Elements.Query<Label>(x => x.WithId("password")); }
        }
        [DynamicElement]
        public Label EmailAddressValidationMessage
        {
            get { return Elements.Query<Label>(x => x.WithId("email")); }
        }
    }
}
