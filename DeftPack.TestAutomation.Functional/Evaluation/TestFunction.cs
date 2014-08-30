namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public abstract class TestFunction<TModel> : TestAction where TModel : class
    {
        public TModel Model { get; protected set; }

        public sealed override bool Evaluate()
        {
            Model = CreateModel();
            return Model != null;
        }

        public abstract TModel CreateModel();
    }
}