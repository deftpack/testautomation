namespace DeftPack.TestAutomation.Functional.Evaluation
{
    public abstract class TestAction
    {
        public abstract bool Evaluate();

        public virtual string ExtraMessage {
            get { return null; }
        }
    }
}