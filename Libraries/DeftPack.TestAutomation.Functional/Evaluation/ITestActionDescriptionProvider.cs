namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Retrieves the test action meta information
    /// </summary>
    public interface ITestActionDescriptionProvider
    {
        /// <summary>
        /// Finds the test description for a given test action or function
        /// </summary>
        /// <typeparam name="TAction">Type of the test action or function to be inspected</typeparam>
        /// <returns>Test action/function description</returns>
        ITestActionDescription GetDescription<TAction>() where TAction : TestAction;
    }
}