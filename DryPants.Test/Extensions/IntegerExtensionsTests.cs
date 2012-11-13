using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DryPants.Extensions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    public class IntegerExtensionsTests
    {
        [TestClass]
        public class DaysTests
        {
            [TestMethod]
            public void PositiveNumberOfDays_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(10, 0, 0, 0), 10.Days());
            }

            [TestMethod]
            public void NegativeNumberOfDays_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(-10, 0, 0, 0), -10.Days());
            }
        }

        [TestClass]
        public class DownToTests
        {
            [TestMethod]
            public void Range10To1_ReturnsArrayRange10To1()
            {
                var expected = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

                int[] actual = 10.DownTo(1);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RangeMinus1To1_ReturnsArrayMinus1()
            {
                var expected = new[] {-1};

                int[] actual = (-1).DownTo(1);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RangeMinus1ToMinus10_ReturnsArrayRangeMinus1ToMinus10()
            {
                var expected = new[] {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10};

                int[] actual = (-1).DownTo(-10);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RangeMinus1ToMinus10_DownToWithAction_ExecutesActionWithCorrectInput()
            {
                var expected = new[] {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10};

                var actual = new List<int>();
                (-1).DownTo(-10, actual.Add);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RangeMinus1ToMinus10_DownToWithAction_ReturnsMinusOne()
            {
                Assert.AreEqual(-1, (-1).DownTo(-10, i => { }));
            }

            [TestMethod]
            public void RangeMinus10ToMinus1_ReturnsArrayMinus10()
            {
                var expected = new[] {-10};

                int[] actual = (-10).DownTo(-1);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class HoursTests
        {
            [TestMethod]
            public void PositiveNumberOfHours_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(0, 10, 0, 0), 10.Hours());
            }

            [TestMethod]
            public void NegativeNumberOfHours_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(0, -10, 0, 0), -10.Hours());
            }
        }

        [TestClass]
        public class IsEvenTests
        {
            [TestMethod]
            public void Ten_IsEven()
            {
                Assert.IsTrue(10.IsEven());
            }

            [TestMethod]
            public void MinusTen_IsEven()
            {
                Assert.IsTrue((-10).IsEven());
            }

            [TestMethod]
            public void One_IsNotEven()
            {
                Assert.IsFalse(1.IsEven());
            }

            [TestMethod]
            public void MinusOne_IsNotEven()
            {
                Assert.IsFalse((-1).IsEven());
            }
        }

        [TestClass]
        public class IsOddTests
        {
            [TestMethod]
            public void Ten_IsNotOdd()
            {
                Assert.IsFalse(10.IsOdd());
            }

            [TestMethod]
            public void MinusTen_IsNotOdd()
            {
                Assert.IsFalse((-10).IsOdd());
            }

            [TestMethod]
            public void One_IsOdd()
            {
                Assert.IsTrue(1.IsOdd());
            }

            [TestMethod]
            public void MinusOne_IsOdd()
            {
                Assert.IsTrue((-1).IsOdd());
            }
        }

        [TestClass]
        public class MinutesTests
        {
            [TestMethod]
            public void PositiveNumberOfMinutes_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(0, 0, 10, 0), 10.Minutes());
            }

            [TestMethod]
            public void NegativeNumberOfMinutes_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(0, 0, -10, 0), -10.Minutes());
            }
        }

        [TestClass]
        public class SecondsTests
        {
            [TestMethod]
            public void PositiveNumberOfSeconds_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(0, 0, 0, 10), 10.Seconds());
            }

            [TestMethod]
            public void NegativeNumberOfSeconds_ReturnsValidTimeSpan()
            {
                Assert.AreEqual(new TimeSpan(0, 0, 0, -10), -10.Seconds());
            }
        }

        [TestClass]
        public class TimesTests
        {
            [TestMethod]
            public void PositiveNumberOfTimes_ExecutesActionGivenTimes()
            {
                var expected = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

                var actual = new Collection<int>();
                10.Times(actual.Add);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void PositiveNumberOfTimes_ReturnsSameNumberAsReturnValue()
            {
                const int numberOfTimes = 10;

                Assert.AreEqual(numberOfTimes, numberOfTimes.Times(t => { }));
            }

            [TestMethod]
            public void NegativeNumberOfTimes_ExecutesActionZeroTimes()
            {
                bool executed = false;

                (-1).Times(t => executed = true);

                Assert.IsFalse(executed);
            }

            [TestMethod]
            public void NegativeNumberOfTimes_ReturnsZeroAsReturnValue()
            {
                const int numberOfTimes = -10;

                Assert.AreEqual(0, numberOfTimes.Times(t => { }));
            }
        }

        [TestClass]
        public class UpToTests
        {
            [TestMethod]
            public void Range1To10_ReturnsArrayRange1To10()
            {
                var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

                int[] actual = 1.UpTo(10);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RangMinus10ToMinus1_ReturnsArrayRangeMinus10ToMinus1()
            {
                var expected = new[] {-10, -9, -8, -7, -6, -5, -4, -3, -2, -1};

                int[] actual = (-10).UpTo(-1);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RangMinus1ToMinus10_ReturnsArrayMinus1()
            {
                var expected = new[] {-1};

                int[] actual = (-1).UpTo(-10);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Range1ToMinus1_ReturnsArray1()
            {
                var expected = new[] {1};

                int[] actual = 1.UpTo(-1);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void PositiveNumberOfTimes_ExecutesActionGivenTimes()
            {
                var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

                var actual = new Collection<int>();
                1.UpTo(10, actual.Add);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void PositiveNumberOfTimes_ReturnsStartAsReturnValue()
            {
                Assert.AreEqual(10, 10.UpTo(1, t => { }));
            }
        }
    }
}