using DeftPack.TestAutomation.Assertion;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.FunctionalTestExample.Views.Google;
using DeftPack.TestAutomation.FunctionalTestExample.Views.TheVerge;
using NUnit.Framework;

namespace DeftPack.TestAutomation.FunctionalTestExample.Actions.Google
{
    [TestActionDescription(
        ActionSummary = "Get from Goggle's search result page to first result's page",
        ExpectedResult = "Succesfully redirected to the external page",
        SuccessMessage = "Clicking on the '{0}' link redirect was succesful")]
    public class GoToFirst : TestAction
    {
        private readonly SearchResults _searchResultsPage;
        private readonly string _expectedLinkText;

        public GoToFirst(SearchResults searchResultsPage, string expectedLinkText)
        {
            _searchResultsPage = searchResultsPage;
            _expectedLinkText = expectedLinkText;
        }

        public override void Evaluate()
        {
            PatientAssert.That(_searchResultsPage.IsLoaded, Is.True);
            PatientAssert.That(_searchResultsPage.FirstResult.Text, Is.EqualTo(_expectedLinkText));
            _searchResultsPage.FirstResult.Click();
            PatientAssert.That(_searchResultsPage.IsRedirectedTo<SiteBase>(), Is.True);
        }
    }
}
