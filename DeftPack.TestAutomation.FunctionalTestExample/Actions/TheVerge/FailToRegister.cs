using DeftPack.TestAutomation.Assertion;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.FunctionalTestExample.Models;
using DeftPack.TestAutomation.FunctionalTestExample.Views.TheVerge;

namespace DeftPack.TestAutomation.FunctionalTestExample.Actions.TheVerge
{
    [TestActionDescription(
        ActionSummary = "Go to user options and try to register with invalid details",
        ExpectedResult = "Validation error message displayed",
        SuccessMessage = "The registration error messages successfully displayed")]
    public class FailToRegister : TestAction
    {
        private readonly SiteBase _googleTopic;
        private readonly LoginPopUp _login;
        private readonly RegisterPopUp _register;
        private readonly RegisterModel _registerModel;

        public FailToRegister(
            SiteBase googleTopic, 
            LoginPopUp login, 
            RegisterPopUp register,
            RegisterModel registerModel)
        {
            _googleTopic = googleTopic;
            _login = login;
            _register = register;
            _registerModel = registerModel;
        }

        public override void Evaluate()
        {
            PatientAssert.IsTrue(() => _googleTopic.IsLoaded);
            _googleTopic.UserLink.Click();
            PatientAssert.IsTrue(() => _login.IsLoaded);
            _login.RegisterLink.Click();
            PatientAssert.IsTrue(() => _register.IsLoaded);
            _register.UserNameInput.Enter(_registerModel.UserName);
            _register.PasswordInput.Enter(_registerModel.Password);
            _register.EmailAddressInput.Enter(_registerModel.EmailAddress);
            _register.NewsLetter.Toggle();
            PatientAssert.IsTrue(() => _register.UserNameValidationMessage.IsVisible);
            PatientAssert.IsTrue(() => _register.PasswordValidationMessage.IsVisible);
            PatientAssert.IsTrue(() => _register.EmailAddressValidationMessage.IsVisible);
        }
    }
}
