using DeftPack.TestAutomation.Assertion;
using DeftPack.TestAutomation.Functional.Evaluation;
using DeftPack.TestAutomation.FunctionalTestExample.Views.Google;
using NUnit.Framework;

namespace DeftPack.TestAutomation.FunctionalTestExample.Actions.Google
{
    [TestActionDescription(
        ActionSummary = "Searching on Google's welcome page",
        ExpectedResult = "Getting redirected to the search result page",
        SuccessMessage = "Was able to search on word: {0}",
        FailedMessage = "Failed to search on google, error happened: {0}")]
    public class Search : TestAction
    {
        private readonly Welcome _welcomePage;
        private readonly string _textToSearch;

        public Search(Welcome welcomePage, string textToSearch)
        {
            _welcomePage = welcomePage;
            _textToSearch = textToSearch;
        }

        public override void Evaluate()
        {
            PatientAssert.That(_welcomePage.IsLoaded, Is.True);
            _welcomePage.SearchBar.Enter(_textToSearch);
            _welcomePage.SearchButton.Click();
            PatientAssert.That(_welcomePage.IsRedirectedTo<SearchResults>(), Is.True);
        }

        public override string ExtraMessage
        {
            get { return _textToSearch; }
        }
    }
}
