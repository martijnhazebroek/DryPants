using DryPants.Extensions;
using DryPants.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DryPants.Test.Extensions
{
    public class DateTimeExtensionsTests
    {
        [TestClass]
        public class GetDaysInMonthTests
        {
            [TestMethod]
            public void NormalYearFebruary_Returns28Days()
            {
                Assert.AreEqual(28, new DateTime(2010, 2, 1).GetDaysInMonth());
            }

            [TestMethod]
            public void LeapYearFebruary_Returns29Days()
            {
                Assert.AreEqual(29, new DateTime(2012, 2, 1).GetDaysInMonth());
            }
        }

        [TestClass]
        public class GetDaysInYearTests
        {
            [TestMethod]
            public void NormalYear_Returns365Days()
            {
                Assert.AreEqual(365, new DateTime(2010, 1, 1).GetDaysInYear());
            } 
            
            [TestMethod]
            public void LeapYear_Returns366Days()
            {
                Assert.AreEqual(366, new DateTime(2012, 1, 1).GetDaysInYear());
            }
        }

        [TestClass]
        public class BeforeTests
        {
            [TestMethod]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysBefore_Returns10DaysBeforeGivenDate()
            {
                var givenDate = new DateTime(2012, 12, 13, 1, 2, 3);
                var timeSpanTenDays = new TimeSpan(10, 0, 0, 0);
                
                DateTime actual = timeSpanTenDays.Before(givenDate);
                var expected = new DateTime(2012, 12, 3, 1, 2, 3);

                Assert.AreEqual(expected, actual);
            }
        }
        
        [TestClass]
        public class AfterTests
        {
            [TestMethod]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysAfter_Returns10DaysAfterGivenDate()
            {
                var givenDate = new DateTime(2012, 12, 13, 1, 2, 3);
                var timeSpanTenDays = new TimeSpan(10, 0, 0, 0);

                DateTime actual = timeSpanTenDays.After(givenDate);
                var expected = new DateTime(2012, 12, 23, 1, 2, 3);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class AgoTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                SystemTime.Now = () => new DateTime(2012, 12, 31, 1, 2, 3);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                SystemTime.Now = () => DateTime.Now;
            }

            [TestMethod]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysAgo_ReturnsDateTimeNowMinus10Days()
            {
                Assert.AreEqual(new DateTime(2012, 12, 21, 1, 2, 3), 10.Days().Ago());
            }
        }
        
        [TestClass]
        public class FromNowTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                SystemTime.Now = () => new DateTime(2012, 12, 31, 1, 2, 3);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                SystemTime.Now = () => DateTime.Now;
            }

            [TestMethod]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysFromNow_ReturnsDateTimePlus10Days()
            {
                Assert.AreEqual(new DateTime(2013, 1, 10, 1, 2, 3), 10.Days().FromNow());
            }
        }
    }
}
