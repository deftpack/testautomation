namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Executes test actions or functions and calls the reporter upon completion
    /// </summary>
    internal interface ITestEvaluator
    {
        /// <summary>
        /// Execute and report about the out come of the test action/function
        /// </summary>
        /// <typeparam name="TAction">Type of the test action/function to be executed</typeparam>
        /// <param name="testAction">Instance of the test action/function to be executed</param>
        void Evaluate<TAction>(TAction testAction) where TAction : TestAction;
    }
}