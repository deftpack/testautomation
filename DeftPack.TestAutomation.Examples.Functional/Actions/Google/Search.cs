using DeftPack.TestAutomation.Assertion;
using DeftPack.TestAutomation.Examples.Functional.Views.Google;
using DeftPack.TestAutomation.Functional.Evaluation;

namespace DeftPack.TestAutomation.Examples.Functional.Actions.Google
{
    [TestActionDescription(
        ActionSummary = "Searching on Google's welcome page",
        ExpectedResult = "Getting redirected to the search result page",
        SuccessMessage = "Was able to search on word: {0}",
        FailedMessage = "Failed to search on Google, error happened: {0}")]
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
            PatientAssert.IsTrue(() => _welcomePage.IsLoaded);
            _welcomePage.SearchBar.Enter(_textToSearch);
            _welcomePage.SmallSearchButton.Click();
            PatientAssert.IsTrue(() => _welcomePage.IsRedirectedTo<SearchResults>());
        }

        public override string ExtraMessage
        {
            get { return _textToSearch; }
        }
    }
}
