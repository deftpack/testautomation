namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public abstract class TestFunction<TModel> : TestAction where TModel : class
    {
        public TModel Model { get; protected set; }

        public sealed override void Evaluate()
        {
            Model = CreateModel();
        }

        public abstract TModel CreateModel();
    }
}