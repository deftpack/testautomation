using System;

namespace DeftPack.TestAutomation.Assertion
{
    public class Retry
    {
        private readonly IWaitProvider _waitProvider;

        public Retry(IWaitProvider waitProvider)
        {
            _waitProvider = waitProvider;
        }

        public void RetryAction<TException>(Action action, int numRetries, int millisecondsBeforeRetry)
            where TException : Exception
        {
            var tries = 0;

            do
            {
                tries++;

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

                _waitProvider.Wait(millisecondsBeforeRetry);

            } while (numRetries > tries);
        }
    }
}
