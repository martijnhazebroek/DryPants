using System;
using DryPants.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Core
{
    [TestClass]
    public class SystemTimeTests
    {
        [TestMethod]
        public void DefaultNow_ReturnsDateTimeNow()
        {
            Assert.AreEqual(DateTime.Now, SystemTime.Now());
        }

        [TestMethod]
        public void DefaultToday_ReturnsDateTimeToday()
        {
            Assert.AreEqual(DateTime.Today, SystemTime.Today());
        }
    }
}