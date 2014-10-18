
using System.Threading;

namespace DeftPack.TestAutomation.Assertion
{
    /// <summary>
    /// This class implements the internal waiting mechanism 
    /// </summary>
    internal class WaitProvider : IWaitProvider
    {
        /// <summary>
        /// Hold up the execution chain
        /// </summary>
        /// <param name="amount">Number of milliseconds the waiting should happen</param>
        public void Wait(int amount)
        {
            Thread.Sleep(amount);
        }
    }
}
