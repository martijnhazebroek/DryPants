using System;
using DryPants.Core;
using Xunit;

namespace DryPants.Test.Core
{
    public class SystemTimeTests
    {
        [Fact]
        public void DefaultNow_ReturnsDateTimeNow()
        {
            DateTime testValue = DateTime.Now;
            SystemTime.Now = () => testValue;

            Assert.Equal(testValue.ToString("yyyyMMddhhmmss"), SystemTime.Now().ToString("yyyyMMddhhmmss"));
        }

        [Fact]
        public void DefaultToday_ReturnsDateTimeToday()
        {
            Assert.Equal(DateTime.Today, SystemTime.Now().Date);
        }
    }
}