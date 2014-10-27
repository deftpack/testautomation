using DeftPack.TestAutomation.Examples.Functional.Actions.BBC;
using DeftPack.TestAutomation.Functional.Framework;

namespace DeftPack.TestAutomation.Examples.Functional.Tests
{
    public class CheckWeatherDetailsAtBBC : AutomationTestSuite
    {
        [AutomationTest("Today's Weather Details", "Check if all the weather details are displayed for Today")]
        public void TodaysWeatherDetails()
        {
            StartAtUrl("http://www.bbc.co.uk");
            Evaluate<ReadTodaysSunriseAndSunset>();
        }
    }
}
