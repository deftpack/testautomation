namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Extending the Test Action so it can return a model (gathered information that could be used in other test actions/functions)
    /// </summary>
    /// <typeparam name="TModel">Type of the model holding returned data</typeparam>
    public abstract class TestFunction<TModel> : TestAction where TModel : class
    {
        /// <summary>
        /// The model that is generated while evaluating the test function 
        /// </summary>
        public TModel Model { get; protected set; }

        public sealed override void Evaluate()
        {
            Model = CreateModel();
        }

        public abstract TModel CreateModel();
    }
}