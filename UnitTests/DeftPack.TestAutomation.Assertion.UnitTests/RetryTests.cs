using Moq;
using NUnit.Framework;
using System;

namespace DeftPack.TestAutomation.Assertion.UnitTests
{
    public class RetryTests
    {
        private const int WaitTime = 100;
        private const int MaxTry = 10;
        private int _waitCount;
        private int _invokationCount;
        private readonly Mock<IWaitProvider> _waitProviderMock = new Mock<IWaitProvider>();

        [SetUp]
        public void SetUp()
        {
            _waitCount = 0;
            _invokationCount = 0;
            _waitProviderMock.Setup(m => m.Wait(It.IsAny<int>())).Callback(() => _waitCount++);
        }

        [Test]
        public void ShouldReturnImmediately()
        {
            var retry = new Retry(_waitProviderMock.Object);
            retry.RetryAction<Exception>(() => ++_invokationCount, MaxTry, WaitTime);
            Assert.AreEqual(_waitCount, 0);
            Assert.AreEqual(_invokationCount, 1);
        }

        [Test]
        public void ShouldReturnAfterCoupleOfTries()
        {
            const int treshold = 3;
            var retry = new Retry(_waitProviderMock.Object);
            retry.RetryAction<Exception>(() =>
            {
                if (++_invokationCount < treshold)
                {
                    throw new Exception();
                }
            }, MaxTry, WaitTime);
            Assert.AreEqual(_waitCount, treshold - 1);
            Assert.AreEqual(_invokationCount, treshold);
        }

        [Test]
        public void ShouldThrowAfterGivenTries()
        {
            var retry = new Retry(_waitProviderMock.Object);
            Assert.Throws<Exception>(() =>
                retry.RetryAction<Exception>(() =>
                {
                    ++_invokationCount;
                    throw new Exception();
                }, MaxTry, WaitTime));
            Assert.AreEqual(_waitCount, MaxTry - 1);
            Assert.AreEqual(_invokationCount, MaxTry);
        }

        [Test]
        public void ShouldThrowSystemErrorImmediately()
        {
            var retry = new Retry(_waitProviderMock.Object);
            Assert.Throws<ArgumentException>(() =>
                retry.RetryAction<AssertionException>(() =>
                {
                    ++_invokationCount;
                    throw new ArgumentException();
                }, MaxTry, WaitTime));
            Assert.AreEqual(_waitCount, 0);
            Assert.AreEqual(_invokationCount, 1);
        }
    }
}
