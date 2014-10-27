using DeftPack.TestAutomation.Assertion;
using DeftPack.TestAutomation.Examples.Functional.Views.BBC;
using DeftPack.TestAutomation.Functional.Evaluation;

namespace DeftPack.TestAutomation.Examples.Functional.Actions.BBC
{
    [TestActionDescription(
        ActionSummary = "",
        ExpectedResult = "",
        SuccessMessage = "",
        FailedMessage = "")]
    public class ReadTodaysSunriseAndSunset : TestAction
    {
        private readonly Welcome _welcomeView;
        private readonly Weather _weatherView;
        private readonly WeatherDetails _weatherDetailsView;

        public ReadTodaysSunriseAndSunset(
            Welcome welcomeView,
            Weather weatherView,
            WeatherDetails weatherDetailsView)
        {
            _welcomeView = welcomeView;
            _weatherView = weatherView;
            _weatherDetailsView = weatherDetailsView;
        }

        public override void Evaluate()
        {
            PatientAssert.IsTrue(() => _welcomeView.IsLoaded);
            _welcomeView.WeatherLink.Click();
            PatientAssert.IsTrue(() => _weatherView.IsLoaded);
            _weatherView.TodayLink.Click();
            PatientAssert.IsTrue(() => _weatherDetailsView.IsLoaded);
        }

        public override string ExtraMessage
        {
            get { return string.Format("{0}|{1}", _weatherDetailsView.Sunrise.Text, _weatherDetailsView.Sunset.Text); }
        }
    }
}
