namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public interface ITestActionDescriptionProvider
    {
        ITestActionDescription GetDescription<TAction>() where TAction : TestAction;
    }
}