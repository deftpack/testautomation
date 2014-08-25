namespace DeftPack.TestAutomation
{
    public interface ITestActionDescription
    {
        string StepDescription { get; set; }
        string ExpectedResult { get; set; }
        string SuccessMessage { get; set; }
        string FailedMessage { get; set; }
    }
}
