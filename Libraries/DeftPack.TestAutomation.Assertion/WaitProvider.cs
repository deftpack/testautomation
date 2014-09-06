
using System.Threading;

namespace DeftPack.TestAutomation.Assertion
{
    public class WaitProvider : IWaitProvider
    {
        public void Wait(int amount)
        {
            Thread.Sleep(amount);
        }
    }
}
