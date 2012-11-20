using DryPants.Core;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;
using Calendar = DryPants.Core.Calendar;

namespace DryPants.Test.Core
{
    [UsedImplicitly]
    internal class CalendarTests
    {
        #region Days

        [TestClass]
        public class DaysInCurrentYearTests : CalendarTest
        {
            [TestMethod]
            public void NoLeapYear_365DaysInYear()
            {
                SystemTime.Now = () => new DateTime(2011, 1, 1);
                Assert.AreEqual(365, Calendar.DaysInCurrentYear);
            }

            [TestMethod]
            public void LeapYear_366DaysInYear()
            {
                SystemTime.Now = () => new DateTime(2012, 1, 1);
                Assert.AreEqual(366, Calendar.DaysInCurrentYear);
            }
        }

        [TestClass]
        public class NextWorkdayTests : CalendarTest
        {
            [TestMethod]
            public void SundayNoHolidays_NextWorkdayIsMonday()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 11);
                Assert.AreEqual(DayOfWeek.Monday, Calendar.NextWorkday.DayOfWeek);
            }

            [TestMethod]
            public void SaturdayNoHolidays_NextWorkdayIsMonday()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 10);
                Assert.AreEqual(DayOfWeek.Monday, Calendar.NextWorkday.DayOfWeek);
            }

            [TestMethod]
            public void MondayNoHolidays_NextWorkdayIsTuesday()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 12);
                Assert.AreEqual(DayOfWeek.Tuesday, Calendar.NextWorkday.DayOfWeek);
            }
        }

        [TestClass]
        public class PreviousWorkdayTests : CalendarTest
        {
            [TestMethod]
            public void SundayNoHolidays_PreviousWorkdayIsFriday()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 11);
                Assert.AreEqual(DayOfWeek.Friday, Calendar.PreviousWorkday.DayOfWeek);
            }

            [TestMethod]
            public void SaturdayNoHolidays_PreviousWorkdayIsFriday()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 10);
                Assert.AreEqual(DayOfWeek.Friday, Calendar.PreviousWorkday.DayOfWeek);
            }

            [TestMethod]
            public void TuesdayNoHolidays_NextWorkdayIsWednesday()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 13);
                Assert.AreEqual(DayOfWeek.Wednesday, Calendar.NextWorkday.DayOfWeek);
            }
        }

        [TestClass]
        public class TomorrowTests : CalendarTest
        {
            [TestMethod]
            public void DayMethodWasImplemented_Tomorrow_Is1DayLater()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 11);
                Assert.AreEqual(new DateTime(2012, 11, 12), Calendar.Tomorrow);
            }
        }

        [TestClass]
        public class YesterdayTests : CalendarTest
        {
            [TestMethod]
            public void DayMethodWasImplemented_Yesterday_Is1DayEarlier()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 11);
                Assert.AreEqual(new DateTime(2012, 11, 10), Calendar.Yesterday);
            }
        }

        #endregion

        #region Weeks

        [TestClass]
        public class NextWeekTests : CalendarTest
        {
            [TestMethod]
            public void DayMethodWasImplemented_NextWeek_Is7DaysLater()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 12);
                TimeSpan timeDiff = Calendar.NextWeek - SystemTime.Now();
                Assert.AreEqual(7, timeDiff.Days);
            }
        }

        [TestClass]
        public class PreviousWeekTests : CalendarTest
        {
            [TestMethod]
            public void DayMethodWasImplemented_PreviousWeek_Is7DaysEarlier()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 12);
                TimeSpan timeDiff = Calendar.PreviousWeek - SystemTime.Now();
                Assert.AreEqual(-7, timeDiff.Days);
            }
        }

        [TestClass]
        public class WeekNumberTests : CalendarTest
        {
            [TestMethod]
            public void FirstJanuaryOfYear2012_WeekNumberIs1()
            {
                SystemTime.Now = () => new DateTime(2012, 1, 1);
                Assert.AreEqual(1, Calendar.WeekNumber);
            }

            [TestMethod]
            public void SecondJanuaryOfYear2012_WeekNumberIs1()
            {
                SystemTime.Now = () => new DateTime(2012, 1, 2);
                Assert.AreEqual(1, Calendar.WeekNumber);
            }

            [TestMethod]
            public void LastDayOfYear2012_WeekNumberIs53()
            {
                SystemTime.Now = () => new DateTime(2012, 12, 31);
                Assert.AreEqual(53, Calendar.WeekNumber);
            }

            [TestMethod]
            public void LastDayOfYear2005_WeekNumberIs53()
            {
                SystemTime.Now = () => new DateTime(2005, 12, 31);
                Assert.AreEqual(53, Calendar.WeekNumber);
            }

            [TestMethod]
            public void DayMethodWasImplemented_WeekNumberIs46()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 11);
                Assert.AreEqual(46, Calendar.WeekNumber);
            }
        }

        #endregion

        #region Month

        [TestClass]
        public class DaysInCurrentMonthTests : CalendarTest
        {
            [TestMethod]
            public void November_DaysInMonth_Is30Days()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 1);
                Assert.AreEqual(30, Calendar.DaysInCurrentMonth);
            }

            [TestMethod]
            public void October_DaysInMonth_Is31Days()
            {
                SystemTime.Now = () => new DateTime(2012, 10, 1);
                Assert.AreEqual(31, Calendar.DaysInCurrentMonth);
            }

            [TestMethod]
            public void FebruaryLeapyear_DaysInMonth_Is29Days()
            {
                SystemTime.Now = () => new DateTime(2012, 2, 1);
                Assert.AreEqual(29, Calendar.DaysInCurrentMonth);
            }

            [TestMethod]
            public void FebruaryNoLeapyear_DaysInMonth_Is28Days()
            {
                SystemTime.Now = () => new DateTime(2011, 2, 1);
                Assert.AreEqual(28, Calendar.DaysInCurrentMonth);
            }
        }

        [TestClass]
        public class NextMonthTests : CalendarTest
        {
            [TestMethod]
            public void DayMethodWasImplemented_NextMonth_Is30DaysLater()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 12);
                TimeSpan timeDiff = Calendar.NextMonth - SystemTime.Now();
                Assert.AreEqual(30, timeDiff.Days);
            }
        }

        [TestClass]
        public class PreviousMonthTests : CalendarTest
        {
            [TestMethod]
            public void DayMethodWasImplemented_PreviousMonth_Is31DaysEarlier()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 12);
                TimeSpan timeDiff = Calendar.PreviousMonth - SystemTime.Now();
                Assert.AreEqual(-31, timeDiff.Days);
            }
        }

        #endregion

        #region Year

        [TestClass]
        public class LeapYearTests : CalendarTest
        {
            [TestMethod]
            public void NoLeapYear_ReturnsFalse()
            {
                SystemTime.Now = () => new DateTime(2011, 1, 1);
                Assert.IsFalse(Calendar.CurrentYearIsLeapYear);
            }

            [TestMethod]
            public void LeapYear_ReturnsTrue()
            {
                SystemTime.Now = () => new DateTime(2012, 1, 1);
                Assert.IsTrue(Calendar.CurrentYearIsLeapYear);
            }
        }

        #endregion
    }

    internal class CalendarTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            SystemTime.Now = () => DateTime.Now;
        }
    }
}