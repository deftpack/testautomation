namespace DeftPack.TestAutomation.Assertion
{
    /// <summary>
    /// Waiting mechanism provider
    /// </summary>
    internal interface IWaitProvider
    {
        /// <summary>
        /// Hold up the execution chain
        /// </summary>
        /// <param name="amount">Number of milliseconds the waiting should happen</param>
        void Wait(int amount);
    }
}