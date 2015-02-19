using System;
using System.Globalization;
using System.Threading;
using DryPants.Core;
using DryPants.Extensions;
using DryPants.Test.Core;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class DateTimeExtensionsTests
    {
        public class AfterTests
        {
            [Fact]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysAfter_Returns10DaysAfterGivenDate()
            {
                var givenDate = new DateTime(2012, 12, 13, 1, 2, 3);
                var timeSpanTenDays = new TimeSpan(10, 0, 0, 0);

                DateTime actual = timeSpanTenDays.After(givenDate);
                var expected = new DateTime(2012, 12, 23, 1, 2, 3);

                Assert.Equal(expected, actual);
            }
        }
        public class AgoTests
        {
            [Fact]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysAgo_ReturnsDateTimeNowMinus10Days()
            {
                Assert.Equal(new DateTime(2012, 12, 21, 1, 2, 3), new TimeSpan(10, 0, 0, 0).Ago(new DateTime(2012, 12, 31, 1, 2, 3)));
            }
        }
        public class BeforeTests
        {
            [Fact]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysBefore_Returns10DaysBeforeGivenDate()
            {
                var givenDate = new DateTime(2012, 12, 13, 1, 2, 3);
                var timeSpanTenDays = new TimeSpan(10, 0, 0, 0);

                DateTime actual = timeSpanTenDays.Before(givenDate);
                var expected = new DateTime(2012, 12, 3, 1, 2, 3);

                Assert.Equal(expected, actual);
            }
        }
        public class FirstDayOfMonthTests
        {
            [Fact]
            public void MidNovemberYear2012_FirstDayOfMonth_Returns1November2012()
            {
                Assert.Equal(new DateTime(2012, 11, 1), new DateTime(2012, 11, 11).FirstDayOfMonth());
            }

            [Fact]
            public void FirstOfNovemberYear2012_FirstDayOfMonth_Returns1November2012()
            {
                Assert.Equal(new DateTime(2012, 11, 1), new DateTime(2012, 11, 1).FirstDayOfMonth());
            }
        }
        public class FirstDayOfWeekTests
        {
            [Fact]
            public void RegularWednesday_ReturnsExpectedDayOfWeek()
            {
                using (new ThreadCultureScope(Thread.CurrentThread.CurrentCulture))
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                    Assert.Equal(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
                        new DateTime(2012, 11, 13).FirstDayOfWeek().DayOfWeek);
                }
            }

            [Fact]
            public void RegularWednesday_ReturnsExpectedDate()
            {
                using (new ThreadCultureScope(Thread.CurrentThread.CurrentCulture))
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                    Assert.Equal(new DateTime(2012, 11, 11), new DateTime(2012, 11, 13).FirstDayOfWeek());
                }
            }
        }
        public class FromNowTests
        {
            [Fact]
            public void DateTimeWithHoursMinutesAndSeconds_10DaysFromNow_ReturnsDateTimePlus10Days()
            {
                Assert.Equal(new DateTime(2013, 1, 10, 1, 2, 3), new TimeSpan(10, 0, 0, 0).FromNow(new DateTime(2012, 12, 31, 1, 2, 3)));
            }
        }

        public class GetDaysInMonthTests
        {
            [Fact]
            public void NormalYearFebruary_Returns28Days()
            {
                Assert.Equal(28, new DateTime(2010, 2, 1).GetDaysInMonth());
            }

            [Fact]
            public void LeapYearFebruary_Returns29Days()
            {
                Assert.Equal(29, new DateTime(2012, 2, 1).GetDaysInMonth());
            }
        }
        public class GetDaysInYearTests
        {
            [Fact]
            public void NormalYear_Returns365Days()
            {
                Assert.Equal(365, new DateTime(2010, 1, 1).GetDaysInYear());
            }

            [Fact]
            public void LeapYear_Returns366Days()
            {
                Assert.Equal(366, new DateTime(2012, 1, 1).GetDaysInYear());
            }
        }
        public class LastDayOfMonthTests
        {
            [Fact]
            public void MidNovemberYear2012_LastDayOfMonth_ReturnsThirtyNovember2012()
            {
                Assert.Equal(new DateTime(2012, 11, 30), new DateTime(2012, 11, 11).LastDayOfMonth());
            }

            [Fact]
            public void FirstOfNovemberYear2012_LastDayOfMonth_ReturnsThirtyNovember2012()
            {
                Assert.Equal(new DateTime(2012, 11, 30), new DateTime(2012, 11, 1).LastDayOfMonth());
            }

            [Fact]
            public void FirstOfOctoberYear2012_LastDayOfMonth_ReturnsThirtyOctober2012()
            {
                Assert.Equal(new DateTime(2012, 10, 31), new DateTime(2012, 10, 31).LastDayOfMonth());
            }
        }
        public class IsLastDayOfMonthTests
        {
            [Fact]
            public void IsLastDayOfMonth_ReturnsTrue_WhenSourceIsThirtyOctober2012()
            {
                Assert.True(new DateTime(2012, 10, 31).IsLastDayOfMonth());
            }

            [Fact]
            public void IsLastDayOfMonth_ReturnsTrue_WhenSourceIsTwentyNineFebrOnLeapYear()
            {
                Assert.True(new DateTime(2012, 2, 29).IsLastDayOfMonth());
            }

            [Fact]
            public void IsLastDayOfMonth_ReturnsFalse_WhenSourceIsTwentyEightFebrOnLeapYear()
            {
                Assert.False(new DateTime(2012, 2, 28).IsLastDayOfMonth());
            }
        }
        public class ToAgeTests
        {
            private readonly DateTime _birthdayHarePants = new DateTime(1985, 10, 24);

            [Fact]
            public void DayMethodWasImplemented_IWas27YearsOld()
            {
                Assert.Equal(27, _birthdayHarePants.ToAge(new DateTime(2012, 11, 12)));
            }

            [Fact]
            public void OnMyBirthday_IWas27YearsOld()
            {
                Assert.Equal(27, _birthdayHarePants.ToAge(new DateTime(2012, 10, 24)));
            }

            [Fact]
            public void YearMethodWasImplemented_OneSecondBeforeMyBirthday_IWas26YearsOld()
            {
                Assert.Equal(26, _birthdayHarePants.ToAge(new DateTime(2012, 9, 23, 23, 59, 59)));
            }

            [Fact]
            public void InMyMothersWomb_IWasZeroYearsOld()
            {
                Assert.Equal(0, _birthdayHarePants.ToAge(new DateTime(1985, 10, 23)));
            }

            [Fact]
            public void NotEvenInThePicture_IWasZeroYearsOld()
            {
                Assert.Equal(0, _birthdayHarePants.ToAge(new DateTime(1967, 1, 2)));
            }
        }
        public class MinMaxTests
        {
            [Fact]
            public void TwoDateTimes_Min_ReturnsMinDate()
            {
                var min = new DateTime(2013, 3, 1);
                var max = new DateTime(2013, 4, 1);

                DateTime actual = DateTimeExtensions.Min(min, max);

                Assert.Equal(min, actual);
            }

            [Fact]
            public void TwoDateTimes_Max_ReturnsMaxDate()
            {
                var min = new DateTime(2013, 3, 1);
                var max = new DateTime(2013, 4, 1);

                DateTime actual = DateTimeExtensions.Max(min, max);

                Assert.Equal(max, actual);
            }
        }
    }
}