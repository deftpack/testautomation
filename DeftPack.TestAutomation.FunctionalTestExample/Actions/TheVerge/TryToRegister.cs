using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.FunctionalTestExample.Views.TheVerge;

namespace DeftPack.TestAutomation.FunctionalTestExample.Actions.TheVerge
{
    public class TryToRegister : TestAction
    {
        private readonly SiteBase _googleTopic;
        private readonly LoginPopUp _login;
        private readonly RegisterPopUp _register;

        public TryToRegister(SiteBase googleTopic, LoginPopUp login, RegisterPopUp register)
        {
            _googleTopic = googleTopic;
            _login = login;
            _register = register;
        }

        public override void Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}
