using System;
using System.Globalization;
using System.Threading;
using DryPants.Core;
using DryPants.Extensions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    internal class DateTimeExtensionsTests
    {
        [TestClass]
        public class AfterTests : DateTimeExtensionsTest
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
        public class AgoTests : DateTimeExtensionsTest
        {
            [TestMethod]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysAgo_ReturnsDateTimeNowMinus10Days()
            {
                SystemTime.Now = () => new DateTime(2012, 12, 31, 1, 2, 3);
                Assert.AreEqual(new DateTime(2012, 12, 21, 1, 2, 3), new TimeSpan(10, 0, 0, 0).Ago());
            }
        }

        [TestClass]
        public class BeforeTests : DateTimeExtensionsTest
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
        public class FirstDayOfMonthTests : DateTimeExtensionsTest
        {
            [TestMethod]
            public void MidNovemberYear2012_FirstDayOfMonth_Returns1November2012()
            {
                Assert.AreEqual(new DateTime(2012, 11, 1), new DateTime(2012, 11, 11).FirstDayOfMonth());
            }

            [TestMethod]
            public void FirstOfNovemberYear2012_FirstDayOfMonth_Returns1November2012()
            {
                Assert.AreEqual(new DateTime(2012, 11, 1), new DateTime(2012, 11, 1).FirstDayOfMonth());
            }
        }

        [TestClass]
        public class FirstDayOfWeekTests : DateTimeExtensionsTest
        {
            [TestMethod]
            public void RegularWednesday_ReturnsExpectedDayOfWeek()
            {
                Assert.AreEqual(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
                                new DateTime(2012, 11, 13).FirstDayOfWeek().DayOfWeek);
            }

            [TestMethod]
            public void RegularWednesday_ReturnsExpectedDate()
            {
                Assert.AreEqual(new DateTime(2012, 11, 11), new DateTime(2012, 11, 13).FirstDayOfWeek());
            }
        }

        [TestClass]
        public class FromNowTests : DateTimeExtensionsTest
        {
            [TestMethod]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysFromNow_ReturnsDateTimePlus10Days()
            {
                SystemTime.Now = () => new DateTime(2012, 12, 31, 1, 2, 3);
                Assert.AreEqual(new DateTime(2013, 1, 10, 1, 2, 3), new TimeSpan(10, 0, 0, 0).FromNow());
            }
        }

        [TestClass]
        public class GetDaysInMonthTests : DateTimeExtensionsTest
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
        public class GetDaysInYearTests : DateTimeExtensionsTest
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
        public class LastDayOfMonthTests : DateTimeExtensionsTest
        {
            [TestMethod]
            public void MidNovemberYear2012_LastDayOfMonth_Returns30November2012()
            {
                Assert.AreEqual(new DateTime(2012, 11, 30), new DateTime(2012, 11, 11).LastDayOfMonth());
            }

            [TestMethod]
            public void FirstOfNovemberYear2012_LastDayOfMonth_Returns30November2012()
            {
                Assert.AreEqual(new DateTime(2012, 11, 30), new DateTime(2012, 11, 1).LastDayOfMonth());
            }

            [TestMethod]
            public void FirstOfOctoberYear2012_LastDayOfMonth_Returns30October2012()
            {
                Assert.AreEqual(new DateTime(2012, 10, 31), new DateTime(2012, 10, 31).LastDayOfMonth());
            }
        }

        [TestClass]
        public class ToAgeTests : DateTimeExtensionsTest
        {
            private readonly DateTime _birthdayHarePants = new DateTime(1985, 10, 24);

            [TestMethod]
            public void DayMethodWasImplemented_IWas27YearsOld()
            {
                SystemTime.Now = () => new DateTime(2012, 11, 12);
                Assert.AreEqual(27, _birthdayHarePants.ToAge());
            }

            [TestMethod]
            public void OnMyBirthday_IWas27YearsOld()
            {
                SystemTime.Now = () => new DateTime(2012, 10, 24);
                Assert.AreEqual(27, _birthdayHarePants.ToAge());
            }

            [TestMethod]
            public void YearMethodWasImplemented_OneSecondBeforeMyBirthday_IWas26YearsOld()
            {
                SystemTime.Now = () => new DateTime(2012, 9, 23, 23, 59, 59);
                Assert.AreEqual(26, _birthdayHarePants.ToAge());
            }

            [TestMethod]
            public void InMyMothersWomb_IWasZeroYearsOld()
            {
                SystemTime.Now = () => new DateTime(1985, 10, 23);
                Assert.AreEqual(0, _birthdayHarePants.ToAge());
            }

            [TestMethod]
            public void NotEvenInThePicture_IWasZeroYearsOld()
            {
                SystemTime.Now = () => new DateTime(1967, 1, 2);
                Assert.AreEqual(0, _birthdayHarePants.ToAge());
            }
        }
    }

    internal class DateTimeExtensionsTest
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