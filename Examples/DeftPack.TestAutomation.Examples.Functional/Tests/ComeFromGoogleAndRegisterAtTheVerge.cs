using DeftPack.TestAutomation.Examples.Functional.Actions.Google;
using DeftPack.TestAutomation.Examples.Functional.Actions.TheVerge;
using DeftPack.TestAutomation.Examples.Functional.Models;
using DeftPack.TestAutomation.Functional.Framework;

namespace DeftPack.TestAutomation.Examples.Functional.Tests
{
    public class ComeFromGoogleAndRegisterAtTheVerge : AutomationTestSuite
    {
        [AutomationTest("Fail To Register", "Test register user journey coming from Google")]
        public void FailToRegister()
        {
            StartAtUrl("https://www.google.co.uk/?gws_rd=ssl");
            Evaluate<Search>("The Verge Google");
            Evaluate<GoToFirst>("Google News | The Verge");
            Evaluate<FailToRegister>(new RegisterModel { EmailAddress = "test1234", Password = "1234", UserName = "test" });
        }
    }
}
