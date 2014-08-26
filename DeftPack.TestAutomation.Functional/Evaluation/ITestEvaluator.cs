namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public interface ITestEvaluator
    {
        ITestEvaluator Evaluate<T>(T evaluable) where T : TestAction;
    }
}