using System;
using DryPants.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Core
{
    [TestClass]
    public class SystemTimeTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            SystemTime.Now = () => DateTime.Now;
        }

        [TestMethod]
        public void DefaultNow_ReturnsDateTimeNow()
        {
            Assert.AreEqual(DateTime.Now.ToString("yyyyMMddhhmmss"), SystemTime.Now().ToString("yyyyMMddhhmmss"));
        }

        [TestMethod]
        public void DefaultToday_ReturnsDateTimeToday()
        {
            Assert.AreEqual(DateTime.Today, SystemTime.Today());
        }
    }
}