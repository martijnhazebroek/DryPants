using System;
using DryPants.Core;
using JetBrains.Annotations;
using Xunit;

namespace DryPants.Test.Core
{
    [UsedImplicitly]
    internal class CalendarTests
    {
        #region Days

        public class DaysInCurrentYearTests
        {
            [Fact]
            public void NoLeapYear_365DaysInYear()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2011, 1, 1);
                    Assert.Equal(365, Calendar.DaysInCurrentYear);
                }
            }

            [Fact]
            public void LeapYear_366DaysInYear()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 1, 1);
                    Assert.Equal(366, Calendar.DaysInCurrentYear);
                }
            }
        }

        public class NextWorkdayTests
        {
            [Fact]
            public void SundayNoHolidays_NextWorkdayIsMonday()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 11);
                    Assert.Equal(DayOfWeek.Monday, Calendar.NextWorkday.DayOfWeek);
                }
            }

            [Fact]
            public void SaturdayNoHolidays_NextWorkdayIsMonday()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 10);
                    Assert.Equal(DayOfWeek.Monday, Calendar.NextWorkday.DayOfWeek);
                }
            }

            [Fact]
            public void MondayNoHolidays_NextWorkdayIsTuesday()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 12);
                    Assert.Equal(DayOfWeek.Tuesday, Calendar.NextWorkday.DayOfWeek);
                }
            }
        }

        public class PreviousWorkdayTests
        {
            [Fact]
            public void SundayNoHolidays_PreviousWorkdayIsFriday()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 11);
                    Assert.Equal(DayOfWeek.Friday, Calendar.PreviousWorkday.DayOfWeek);
                }
            }

            [Fact]
            public void SaturdayNoHolidays_PreviousWorkdayIsFriday()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 10);
                    Assert.Equal(DayOfWeek.Friday, Calendar.PreviousWorkday.DayOfWeek);
                }
            }

            [Fact]
            public void TuesdayNoHolidays_NextWorkdayIsWednesday()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 13);
                    Assert.Equal(DayOfWeek.Wednesday, Calendar.NextWorkday.DayOfWeek);
                }
            }
        }

        public class TomorrowTests
        {
            [Fact]
            public void DayMethodWasImplemented_Tomorrow_Is1DayLater()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 11);
                    Assert.Equal(new DateTime(2012, 11, 12), Calendar.Tomorrow);
                }
            }
        }

        public class YesterdayTests
        {
            [Fact]
            public void DayMethodWasImplemented_Yesterday_Is1DayEarlier()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 11);
                    Assert.Equal(new DateTime(2012, 11, 10), Calendar.Yesterday);
                }
            }
        }

        #endregion

        #region Weeks

        public class NextWeekTests
        {
            [Fact]
            public void DayMethodWasImplemented_NextWeek_Is7DaysLater()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 12);
                    TimeSpan timeDiff = Calendar.NextWeek - SystemTime.Now();
                    Assert.Equal(7, timeDiff.Days);
                }
            }
        }

        public class PreviousWeekTests
        {
            [Fact]
            public void DayMethodWasImplemented_PreviousWeek_Is7DaysEarlier()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 12);
                    TimeSpan timeDiff = Calendar.PreviousWeek - SystemTime.Now();
                    Assert.Equal(-7, timeDiff.Days);
                }
            }
        }

        public class WeekNumberTests
        {
            [Fact]
            public void FirstJanuaryOfYear2012_WeekNumberIs1()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 1, 1);
                    Assert.Equal(1, Calendar.WeekNumber);
                }
            }

            [Fact]
            public void SecondJanuaryOfYear2012_WeekNumberIs1()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 1, 2);
                    Assert.Equal(1, Calendar.WeekNumber);
                }
            }

            [Fact]
            public void LastDayOfYear2012_WeekNumberIs53()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 12, 31);
                    Assert.Equal(53, Calendar.WeekNumber);
                }
            }

            [Fact]
            public void LastDayOfYear2005_WeekNumberIs53()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2005, 12, 31);
                    Assert.Equal(53, Calendar.WeekNumber);
                }
            }

            [Fact]
            public void DayMethodWasImplemented_WeekNumberIs46()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 11);
                    Assert.Equal(46, Calendar.WeekNumber);
                }
            }
        }

        #endregion

        #region Month

        public class DaysInCurrentMonthTests
        {
            [Fact]
            public void November_DaysInMonth_Is30Days()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 1);
                    Assert.Equal(30, Calendar.DaysInCurrentMonth);
                }
            }

            [Fact]
            public void October_DaysInMonth_Is31Days()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 10, 1);
                    Assert.Equal(31, Calendar.DaysInCurrentMonth);
                }
            }

            [Fact]
            public void FebruaryLeapyear_DaysInMonth_Is29Days()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 2, 1);
                    Assert.Equal(29, Calendar.DaysInCurrentMonth);
                }
            }

            [Fact]
            public void FebruaryNoLeapyear_DaysInMonth_Is28Days()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2011, 2, 1);
                    Assert.Equal(28, Calendar.DaysInCurrentMonth);
                }
            }
        }

        public class NextMonthTests
        {
            [Fact]
            public void DayMethodWasImplemented_NextMonth_Is30DaysLater()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 12);
                    TimeSpan timeDiff = Calendar.NextMonth - SystemTime.Now();
                    Assert.Equal(30, timeDiff.Days);
                }
            }
        }

        public class PreviousMonthTests
        {
            [Fact]
            public void DayMethodWasImplemented_PreviousMonth_Is31DaysEarlier()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 11, 12);
                    TimeSpan timeDiff = Calendar.PreviousMonth - SystemTime.Now();
                    Assert.Equal(-31, timeDiff.Days);
                }
            }
        }

        #endregion

        #region Year

        public class LeapYearTests
        {
            [Fact]
            public void NoLeapYear_ReturnsFalse()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2011, 1, 1);
                    Assert.False(Calendar.CurrentYearIsLeapYear);
                }
            }

            [Fact]
            public void LeapYear_ReturnsTrue()
            {
                using (new SystemTimeScope())
                {
                    SystemTime.Now = () => new DateTime(2012, 1, 1);
                    Assert.True(Calendar.CurrentYearIsLeapYear);
                }
            }
        }

        #endregion
    }
}