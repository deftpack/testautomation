using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Threading.Tasks;

namespace DeftPack.TestAutomation.Assertion
{
    public class PatientAssert
    {
        private static readonly IWaitProvider WaitProvider = new WaitProvider();
        private static readonly int NumberOfTries = PatientAssertionConfiguration.Config.NumberOfTries;
        private static readonly int MillisecondsBetweenTries = PatientAssertionConfiguration.Config.MillisecondsBetweenTries;

        public static void AreEqual(Func<object> obj1, object obj2)
        {
            That(obj1, Is.EqualTo(obj2));
        }

        public static void IsTrue(Func<object> actual)
        {
            That(actual, Is.True);
        }

        public static void IsFalse(Func<object> actual)
        {
            That(actual, Is.False);
        }

        public static void That(Func<object> actual, IResolveConstraint expression)
        {
            try
            {
                Action retry = () => new Retry(WaitProvider)
                    .RetryAction<AssertionException>(() => Assert.That(actual(), expression), NumberOfTries, MillisecondsBetweenTries);
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
