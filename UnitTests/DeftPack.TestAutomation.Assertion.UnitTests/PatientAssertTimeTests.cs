
using NUnit.Framework;
using System.Diagnostics;

namespace DeftPack.TestAutomation.Assertion.UnitTests
{
    [TestFixture]
    [Ignore]
    public class PatientAssertTimeTests
    {
        private int _waitTimeSum;

        [SetUp]
        public void SetUp()
        {
            var config = PatientAssertionConfiguration.Config;
            _waitTimeSum = (config.NumberOfTries - 1) * config.MillisecondsBetweenTries;
        }

        [Test]
        public void IsTrueTimeTest()
        {
            var watch = new Stopwatch();
            watch.Start();
            Assert.Throws<AssertionException>(() => PatientAssert.IsTrue(() => false));
            Assert.That(watch.ElapsedMilliseconds > _waitTimeSum);
        }

        [Test]
        public void IsFalseTimeTest()
        {
            var watch = new Stopwatch();
            watch.Start();
            Assert.Throws<AssertionException>(() => PatientAssert.IsFalse(() => true));
            Assert.That(watch.ElapsedMilliseconds > _waitTimeSum);
        }

        [Test]
        public void AreEqualTimeTest()
        {
            var watch = new Stopwatch();
            watch.Start();
            Assert.Throws<AssertionException>(() => PatientAssert.AreEqual(() => 1, 2));
            Assert.That(watch.ElapsedMilliseconds > _waitTimeSum);
        }

        [Test]
        public void ThatTimeTest()
        {
            var watch = new Stopwatch();
            watch.Start();
            Assert.Throws<AssertionException>(() => PatientAssert.That(() => 1, Is.TypeOf<string>()));
            Assert.That(watch.ElapsedMilliseconds > _waitTimeSum);
        }
    }
}
