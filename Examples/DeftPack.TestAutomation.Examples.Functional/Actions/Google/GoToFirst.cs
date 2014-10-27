using DeftPack.TestAutomation.Assertion;
using DeftPack.TestAutomation.Examples.Functional.Views.Google;
using DeftPack.TestAutomation.Examples.Functional.Views.TheVerge;
using DeftPack.TestAutomation.Functional.Evaluation;

namespace DeftPack.TestAutomation.Examples.Functional.Actions.Google
{
    [TestActionDescription(
        ActionSummary = "Get from Goggle's search result page to the first result's page",
        ExpectedResult = "Successfully redirected to the external page",
        SuccessMessage = "Clicking on the '{0}' link redirect was successful")]
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
            PatientAssert.IsTrue(() => _searchResultsPage.IsLoaded);
            PatientAssert.AreEqual(() => _searchResultsPage.FirstResult.Text, _expectedLinkText);
            _searchResultsPage.FirstResult.Click();
            PatientAssert.IsTrue(() => _searchResultsPage.IsRedirectedTo<SiteBase>());
        }

        public override string ExtraMessage
        {
            get { return _expectedLinkText; }
        }
    }
}
