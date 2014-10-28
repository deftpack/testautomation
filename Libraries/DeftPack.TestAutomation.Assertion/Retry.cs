using System;

namespace DeftPack.TestAutomation.Assertion
{
    /// <summary>
    /// This class helps to retry actions which in interim could fail.
    /// For instance if you want to open a connection to a remote application
    /// or server but it is not warmed-up yet, and the connection times out,
    /// this class will try to re-open and omit exceptions in a grace period.   
    /// </summary>
    internal class Retry
    {
        private readonly IWaitProvider _waitProvider;

        public Retry(IWaitProvider waitProvider)
        {
            _waitProvider = waitProvider;
        }

        /// <summary>
        /// Execute a method and if it throws exception retry the execution for given times 
        /// </summary>
        /// <typeparam name="TException">Type of the exception which should be ignored before it gives up</typeparam>
        /// <param name="action">The method to be executed</param>
        /// <param name="numRetries">How many times it should try before giving up</param>
        /// <param name="millisecondsBeforeRetry">How long it should wait between tries</param>
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
