using DryPants.Core;
using DryPants.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;

namespace DryPants.Test.Core
{
    internal class PeriodTestss
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestClass]
        public class ConstructorExtensionsTests : PeriodExtensionsTests
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void StartDatePastEndDate_ThrowsInvalidOperationException()
            {
                try
                {
                    // ReSharper disable ObjectCreationAsStatement
                    new Period(new DateTime(2010, 1, 1), new DateTime(2009, 1, 1));
                    // ReSharper restore ObjectCreationAsStatement
                }
                catch (InvalidOperationException ex)
                {
                    Assert.AreEqual("The start date of a period can not be past the end date.", ex.Message);
                    throw;
                }
            }
        }

        [TestClass]
        public class EquatableExtensionsTests : PeriodExtensionsTests
        {
            [TestMethod]
            public void Period_EqualsSamePeriod()
            {
                var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));

                Assert.IsTrue(period.Equals(period));
                Assert.IsTrue(((object)period).Equals(period));
                Assert.AreEqual(period.GetHashCode(), period.GetHashCode());
                Assert.IsTrue(period == period);
            }

            [TestMethod]
            public void Period_EqualsEqualPeriod()
            {
                var firstPeriod = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));
                var secondPeriod = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));

                Assert.IsTrue(firstPeriod.Equals(secondPeriod));
                Assert.IsTrue(((object)firstPeriod).Equals(secondPeriod));
                Assert.AreEqual(firstPeriod.GetHashCode(), secondPeriod.GetHashCode());
                Assert.IsTrue(firstPeriod == secondPeriod);
            }

            [TestMethod]
            public void Period_DoesNotEqualDifferentPeriod()
            {
                var firstPeriod = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));
                var secondPeriod = new Period(new DateTime(2009, 1, 1), new DateTime(2010, 1, 31));

                Assert.IsFalse(firstPeriod.Equals(secondPeriod));
                Assert.IsFalse(((object)firstPeriod).Equals(secondPeriod));
                Assert.IsFalse(firstPeriod.Equals(new object()));
                Assert.AreNotEqual(firstPeriod.GetHashCode(), secondPeriod.GetHashCode());
                Assert.IsTrue(firstPeriod != secondPeriod);
            }
        }
    }
}