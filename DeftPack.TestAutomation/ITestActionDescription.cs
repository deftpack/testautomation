namespace DeftPack.TestAutomation
{
    public interface ITestActionDescription
    {
        string ActionSummary { get; set; }
        string ExpectedResult { get; set; }
        string SuccessMessage { get; set; }
        string FailedMessage { get; set; }
    }
}
