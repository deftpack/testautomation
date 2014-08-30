using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Threading.Tasks;

namespace DeftPack.TestAutomation.Assertion
{
    public class PatientAssert
    {
        private static readonly int NumberOfTries = PatientAssertionConfiguration.Config.NumberOfTries;
        private static readonly int MillisecondsBetweenTries = PatientAssertionConfiguration.Config.MillisecondsBetweenTries;

        public static void That(object actual, IResolveConstraint expression)
        {
            try
            {
                Action retry = () =>
                        Retry.RetryAction<AssertionException>(() => Assert.That(actual, expression), NumberOfTries,
                            MillisecondsBetweenTries);
                Task.Factory.StartNew(retry).Wait();
            }
            catch (Exception exception)
            {
                var baseException = exception.GetBaseException();
                throw baseException is AssertionException ? baseException : exception;
            }
        }
    }
}
