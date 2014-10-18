using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Threading.Tasks;

namespace DeftPack.TestAutomation.Assertion
{
    /// <summary>
    /// The purpose of this class is to do assertion in a so called patient mode.
    /// It means that expressions passed in rather than already evaluated values,
    /// and the assert will check multiple times if the value returned by the expression
    /// meets the requirement. It is useful when the resource is not necessarily immediately ready.
    /// </summary>
    public static class PatientAssert
    {
        private static readonly IWaitProvider WaitProvider = new WaitProvider();
        private static readonly int NumberOfTries = PatientAssertionConfiguration.Config.NumberOfTries;
        private static readonly int MillisecondsBetweenTries = PatientAssertionConfiguration.Config.MillisecondsBetweenTries;

        /// <summary>
        /// Checks if the values are equal. If not throws AssertionException.
        /// </summary>
        /// <param name="obj1">Method which returns the value that will be asserted</param>
        /// <param name="obj2">Static value the comparison happens against</param>
        public static void AreEqual(Func<object> obj1, object obj2)
        {
            That(obj1, Is.EqualTo(obj2));
        }

        /// <summary>
        /// Checks if the given Boolean is true. If not throws AssertionException.
        /// </summary>
        /// <param name="actual">Method which returns the value that will be asserted</param>
        public static void IsTrue(Func<object> actual)
        {
            That(actual, Is.True);
        }

        /// <summary>
        /// Checks if the given Boolean is false. If not throws AssertionException.
        /// </summary>
        /// <param name="actual">Method which returns the value that will be asserted</param>
        public static void IsFalse(Func<object> actual)
        {
            That(actual, Is.False);
        }

        /// <summary>
        /// Checks if the given object meets the constraints. If not throws AssertionException.
        /// </summary>
        /// <param name="actual">Method which returns the value that will be asserted</param>
        /// <param name="expression">NUnit constraint expression. For instance: Is.True</param>
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
