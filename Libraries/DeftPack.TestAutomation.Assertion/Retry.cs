using System;
using System.Threading;

namespace DeftPack.TestAutomation.Assertion
{
    internal class Retry
    {
        public static void RetryAction<TException>(Action action, int numRetries, int millisecondsBeforeRetry)
            where TException : Exception
        {
            var tries = 0;

            do
            {
                try
                {
                    action();
                    return;
                }
                catch (TException)
                {
                    if (numRetries <= tries) throw;
                }
                catch (NullReferenceException)
                {
                    if (numRetries <= tries) throw;
                }
                finally
                {
                    Thread.Sleep(millisecondsBeforeRetry);
                }
            } while (numRetries > tries++);
        }
    }
}
