using System;
using System.Globalization;
using DryPants.Core;
using Xunit;
using Calendar = DryPants.Core.Calendar;

namespace DryPants.Test.Core
{
    public class CalendarTests
    {
        #region Days

        public class DaysInCurrentYearTests
        {
            [Fact]
            public void NoLeapYear_365DaysInYear()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2011, 1, 1));
                Assert.Equal(365, cal.DaysInCurrentYear);
            }

            [Fact]
            public void LeapYear_366DaysInYear()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 1, 1));
                Assert.Equal(366, cal.DaysInCurrentYear);
            }
        }

        public class NextWorkdayTests
        {
            [Fact]
            public void SundayNoHolidays_NextWorkdayIsMonday()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 11));
                Assert.Equal(DayOfWeek.Monday, cal.NextWorkday.DayOfWeek);
            }

            [Fact]
            public void SaturdayNoHolidays_NextWorkdayIsMonday()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 10));
                Assert.Equal(DayOfWeek.Monday, cal.NextWorkday.DayOfWeek);
            }

            [Fact]
            public void MondayNoHolidays_NextWorkdayIsTuesday()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 12));
                Assert.Equal(DayOfWeek.Tuesday, cal.NextWorkday.DayOfWeek);
            }
        }

        public class PreviousWorkdayTests
        {
            [Fact]
            public void SundayNoHolidays_PreviousWorkdayIsFriday()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 11));
                Assert.Equal(DayOfWeek.Friday, cal.PreviousWorkday.DayOfWeek);
            }

            [Fact]
            public void SaturdayNoHolidays_PreviousWorkdayIsFriday()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 10));
                Assert.Equal(DayOfWeek.Friday, cal.PreviousWorkday.DayOfWeek);
            }

            [Fact]
            public void TuesdayNoHolidays_NextWorkdayIsWednesday()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 13));
                Assert.Equal(DayOfWeek.Wednesday, cal.NextWorkday.DayOfWeek);
            }
        }

        public class TomorrowTests
        {
            [Fact]
            public void DayMethodWasImplemented_Tomorrow_Is1DayLater()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 11));
                Assert.Equal(new DateTime(2012, 11, 12), cal.Tomorrow);
            }
        }

        public class YesterdayTests
        {
            [Fact]
            public void DayMethodWasImplemented_Yesterday_Is1DayEarlier()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 11));
                Assert.Equal(new DateTime(2012, 11, 10), cal.Yesterday);
            }
        }

        #endregion

        #region Weeks

        public class NextWeekTests
        {
            [Fact]
            public void DayMethodWasImplemented_NextWeek_Is7DaysLater()
            {
                var dateNow = new DateTime(2012, 11, 12);
                var cal = new Calendar(CultureInfo.InvariantCulture, () => dateNow);
                TimeSpan timeDiff = cal.NextWeek - dateNow;

                Assert.Equal(7, timeDiff.Days);
            }
        }

        public class PreviousWeekTests
        {
            [Fact]
            public void DayMethodWasImplemented_PreviousWeek_Is7DaysEarlier()
            {
                var dateNow = new DateTime(2012, 11, 12);
                var cal = new Calendar(CultureInfo.InvariantCulture, () => dateNow);
                
                TimeSpan timeDiff = cal.PreviousWeek - dateNow;
                Assert.Equal(-7, timeDiff.Days);
            }
        }

        public class WeekNumberTests
        {
            [Fact]
            public void FirstJanuaryOfYear2012_WeekNumberIs1()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 1, 1));
                Assert.Equal(1, cal.WeekNumber);
            }

            [Fact]
            public void SecondJanuaryOfYear2012_WeekNumberIs1()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 1, 2));
                Assert.Equal(1, cal.WeekNumber);
            }

            [Fact]
            public void LastDayOfYear2012_WeekNumberIs53()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 12, 31));
                Assert.Equal(53, cal.WeekNumber);
            }

            [Fact]
            public void LastDayOfYear2005_WeekNumberIs53()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2005, 12, 31));
                Assert.Equal(53, cal.WeekNumber);
            }

            [Fact]
            public void DayMethodWasImplemented_WeekNumberIs46()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 11));
                Assert.Equal(46, cal.WeekNumber);

            }
        }

        #endregion

        #region Month

        public class DaysInCurrentMonthTests
        {
            [Fact]
            public void November_DaysInMonth_Is30Days()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 11, 11));
                Assert.Equal(30, cal.DaysInCurrentMonth);
            }

            [Fact]
            public void October_DaysInMonth_Is31Days()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 10, 1));
                Assert.Equal(31, cal.DaysInCurrentMonth);
            }

            [Fact]
            public void FebruaryLeapyear_DaysInMonth_Is29Days()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 2, 1));
                Assert.Equal(29, cal.DaysInCurrentMonth);
            }

            [Fact]
            public void FebruaryNoLeapyear_DaysInMonth_Is28Days()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2011, 2, 1));
                Assert.Equal(28, cal.DaysInCurrentMonth);
            }
        }

        public class NextMonthTests
        {
            [Fact]
            public void DayMethodWasImplemented_NextMonth_Is30DaysLater()
            {
                var dateNow = new DateTime(2012, 11, 12);
                var cal = new Calendar(CultureInfo.InvariantCulture, () => dateNow);

                TimeSpan timeDiff = cal.NextMonth - dateNow;
                Assert.Equal(30, timeDiff.Days);
            }
        }

        public class PreviousMonthTests
        {
            [Fact]
            public void DayMethodWasImplemented_PreviousMonth_Is31DaysEarlier()
            {

                var dateNow = new DateTime(2012, 11, 12);
                var cal = new Calendar(CultureInfo.InvariantCulture, () => dateNow);
                
                TimeSpan timeDiff = cal.PreviousMonth - dateNow;
                Assert.Equal(-31, timeDiff.Days);
            }
        }

        #endregion

        #region Year

        public class LeapYearTests
        {
            [Fact]
            public void NoLeapYear_ReturnsFalse()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2011, 1, 1));
                Assert.False(cal.CurrentYearIsLeapYear);
            }

            [Fact]
            public void LeapYear_ReturnsTrue()
            {
                var cal = new Calendar(CultureInfo.InvariantCulture, () => new DateTime(2012, 1, 1));
                Assert.True(cal.CurrentYearIsLeapYear);
            }
        }

        #endregion
    }
}