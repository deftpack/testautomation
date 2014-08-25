namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public interface ITestAction
    {
        bool Evaluate();
        string ExtraMessage { get; }
    }
}