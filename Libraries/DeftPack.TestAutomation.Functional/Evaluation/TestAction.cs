namespace DeftPack.TestAutomation.Functional.Evaluation
{
    /// <summary>
    /// Base class for test abstraction. You can collect multiple test acts and asserts to create reusable test chunks.
    /// </summary>
    public abstract class TestAction
    {
        /// <summary>
        /// Test acts and asserts
        /// </summary>
        public abstract void Evaluate();

        /// <summary>
        /// Message part which is displayed for successful test action
        /// </summary>
        public virtual string ExtraMessage
        {
            get { return null; }
        }
    }
}