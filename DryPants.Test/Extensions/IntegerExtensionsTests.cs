using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DryPants.Extensions;
using JetBrains.Annotations;
using Xunit;


namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    public class IntegerExtensionsTests
    {
        
        public class DaysTests
        {
            [Fact]
            public void PositiveNumberOfDays_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(10, 0, 0, 0), 10.Days());
            }

            [Fact]
            public void NegativeNumberOfDays_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(-10, 0, 0, 0), -10.Days());
            }
        }

        public class DownToTests
        {
            [Fact]
            public void Range10To1_ReturnsArrayRange10To1()
            {
                var expected = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

                int[] actual = 10.DownTo(1);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void RangeMinus1To1_ReturnsArrayMinus1()
            {
                var expected = new[] {-1};

                int[] actual = (-1).DownTo(1);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void RangeMinus1ToMinus10_ReturnsArrayRangeMinus1ToMinus10()
            {
                var expected = new[] {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10};

                int[] actual = (-1).DownTo(-10);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void RangeMinus1ToMinus10_DownToWithAction_ExecutesActionWithCorrectInput()
            {
                var expected = new[] {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10};

                var actual = new List<int>();
                (-1).DownTo(-10, actual.Add);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void RangeMinus1ToMinus10_DownToWithAction_ReturnsMinusOne()
            {
                Assert.Equal(-1, (-1).DownTo(-10, i => { }));
            }

            [Fact]
            public void RangeMinus10ToMinus1_ReturnsArrayMinus10()
            {
                var expected = new[] {-10};

                int[] actual = (-10).DownTo(-1);

                Assert.Equal(expected, actual);
            }
        }
        public class HoursTests
        {
            [Fact]
            public void PositiveNumberOfHours_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(0, 10, 0, 0), 10.Hours());
            }

            [Fact]
            public void NegativeNumberOfHours_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(0, -10, 0, 0), -10.Hours());
            }
        }
        public class IsEvenTests
        {
            [Fact]
            public void Ten_IsEven()
            {
                Assert.True(10.IsEven());
            }

            [Fact]
            public void MinusTen_IsEven()
            {
                Assert.True((-10).IsEven());
            }

            [Fact]
            public void One_IsNotEven()
            {
                Assert.False(1.IsEven());
            }

            [Fact]
            public void MinusOne_IsNotEven()
            {
                Assert.False((-1).IsEven());
            }
        }
        public class IsOddTests
        {
            [Fact]
            public void Ten_IsNotOdd()
            {
                Assert.False(10.IsOdd());
            }

            [Fact]
            public void MinusTen_IsNotOdd()
            {
                Assert.False((-10).IsOdd());
            }

            [Fact]
            public void One_IsOdd()
            {
                Assert.True(1.IsOdd());
            }

            [Fact]
            public void MinusOne_IsOdd()
            {
                Assert.True((-1).IsOdd());
            }
        }
        public class MinutesTests
        {
            [Fact]
            public void PositiveNumberOfMinutes_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(0, 0, 10, 0), 10.Minutes());
            }

            [Fact]
            public void NegativeNumberOfMinutes_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(0, 0, -10, 0), -10.Minutes());
            }
        }
        public class SecondsTests
        {
            [Fact]
            public void PositiveNumberOfSeconds_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(0, 0, 0, 10), 10.Seconds());
            }

            [Fact]
            public void NegativeNumberOfSeconds_ReturnsValidTimeSpan()
            {
                Assert.Equal(new TimeSpan(0, 0, 0, -10), -10.Seconds());
            }
        }
        public class TimesTests
        {
            [Fact]
            public void PositiveNumberOfTimes_ExecutesActionGivenTimes()
            {
                var expected = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

                var actual = new Collection<int>();
                10.Times(actual.Add);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void PositiveNumberOfTimes_ReturnsSameNumberAsReturnValue()
            {
                const int numberOfTimes = 10;

                Assert.Equal(numberOfTimes, numberOfTimes.Times(t => { }));
            }

            [Fact]
            public void NegativeNumberOfTimes_ExecutesActionZeroTimes()
            {
                bool executed = false;

                (-1).Times(t => executed = true);

                Assert.False(executed);
            }

            [Fact]
            public void NegativeNumberOfTimes_ReturnsZeroAsReturnValue()
            {
                const int numberOfTimes = -10;

                Assert.Equal(0, numberOfTimes.Times(t => { }));
            }
        }
        public class UpToTests
        {
            [Fact]
            public void Range1To10_ReturnsArrayRange1To10()
            {
                var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

                int[] actual = 1.UpTo(10);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void RangMinus10ToMinus1_ReturnsArrayRangeMinus10ToMinus1()
            {
                var expected = new[] {-10, -9, -8, -7, -6, -5, -4, -3, -2, -1};

                int[] actual = (-10).UpTo(-1);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void RangMinus1ToMinus10_ReturnsArrayMinus1()
            {
                var expected = new[] {-1};

                int[] actual = (-1).UpTo(-10);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void Range1ToMinus1_ReturnsArray1()
            {
                var expected = new[] {1};

                int[] actual = 1.UpTo(-1);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void PositiveNumberOfTimes_ExecutesActionGivenTimes()
            {
                var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

                var actual = new Collection<int>();
                1.UpTo(10, actual.Add);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void PositiveNumberOfTimes_ReturnsStartAsReturnValue()
            {
                Assert.Equal(10, 10.UpTo(1, t => { }));
            }
        }
    }
}