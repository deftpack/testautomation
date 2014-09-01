using DeftPack.TestAutomation.Functional.Framework;
using DeftPack.TestAutomation.FunctionalTestExample.Models;

namespace DeftPack.TestAutomation.FunctionalTestExample.Tests
{
    public class ComeFromGoogleAndRegister : AutomationTestSuite
    {
        [AutomationTest("Fail To Register", "Test register user journey coming from Google")]
        public void FailToRegister()
        {
            StartAtUrl("https://www.google.co.uk/?gws_rd=ssl");
            Evaluate<Actions.Google.Search>("The Verge Google");
            Evaluate<Actions.Google.GoToFirst>("Google News | The Verge");
            Evaluate<Actions.TheVerge.FailToRegister>(new RegisterModel { EmailAddress = "test1234", Password = "1234", UserName = "test"});
        }
    }
}
