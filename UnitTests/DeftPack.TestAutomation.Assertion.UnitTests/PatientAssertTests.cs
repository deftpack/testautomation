
using NUnit.Framework;

namespace DeftPack.TestAutomation.Assertion.UnitTests
{
    [TestFixture]
    public class PatientAssertTests
    {
        [Test]
        public void IsTruePasses()
        {
            PatientAssert.IsTrue(() => true);
        }

        [Test]
        public void IsTrueFails()
        {
            Assert.Throws<AssertionException>(() => PatientAssert.IsTrue(() => false));
        }

        [Test]
        public void IsFalsePasses()
        {
            PatientAssert.IsFalse(() => false);
        }

        [Test]
        public void IsFalseFails()
        {
            Assert.Throws<AssertionException>(() => PatientAssert.IsFalse(() => true));
        }

        [Test]
        public void AreEqualPasses()
        {
            PatientAssert.AreEqual(() => 1, 1);
        }

        [Test]
        public void AreEqualFails()
        {
            Assert.Throws<AssertionException>(() => PatientAssert.AreEqual(() => 1, 2));
        }

        [Test]
        public void ThatPasses()
        {
            PatientAssert.That(() => 1, Is.TypeOf<int>());
        }

        [Test]
        public void ThatFails()
        {
            Assert.Throws<AssertionException>(() => PatientAssert.That(() => 1, Is.TypeOf<string>()));
        }
    }
}
