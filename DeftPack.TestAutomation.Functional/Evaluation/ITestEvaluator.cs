namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public interface ITestEvaluator
    {
        void Evaluate<T>(T evaluable) where T : TestAction;
    }
}