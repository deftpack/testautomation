﻿using DeftPack.TestAutomation.Selenium.PageObjects;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Activators;
using DeftPack.TestAutomation.Selenium.PageObjects.Elements.Inputs;

namespace DeftPack.TestAutomation.FunctionalTestExample.Views.TheVerge
{
    public class RegisterPopUp : View
    {
        public TextBox UserNameInput
        {
            get { return QueryElement<TextBox>(x => x.WithHtmlAttribute("name", "user[username]").WithCssClass("register-username")); }
        }
        public TextBox PasswordInput
        {
            get { return QueryElement<TextBox>(x => x.WithHtmlAttribute("name", "user[password]")); }
        }
        public TextBox EmailAddressInput
        {
            get { return QueryElement<TextBox>(x => x.WithHtmlAttribute("name", "user[email]").WithCssClass("register-email")); }
        }
        public CheckBox NewsLetter
        {
            get { return QueryElement<CheckBox>(x => x.WithId("newsletter-subscribe").WithHtmlAttribute("name", "user[newsletter]")); }
        }
        public Button RegisterButton
        {
            get { return QueryElement<Button>(x => x.WithHtmlAttribute("value", "Continue")); }
        }
        public Link LoginLink
        {
            get { return QueryElement<Link>(x => x.WithHtmlAttribute("data-chorus-auth-goto", "login")); }
        }
    }
}
