using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pragmatic.TDD.Common.Tests.TimeManagerTests
{
    [TestClass]
    public class UtcNow
    {
        private TimeManager _timeManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _timeManager = new TimeManager();
        }

        [TestMethod]
        public void ItReturnsUtcNow()
        {
            // Arrange
            // Act
            var result = _timeManager.UtcNow;

            // Assert
            Assert.AreEqual(DateTime.UtcNow, result);
        }
    }
}
