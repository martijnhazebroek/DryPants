using System;
using DryPants.Core;
using DryPants.Test.Extensions;
using Xunit;

namespace DryPants.Test.Core
{
    public class PeriodTests
    {

        public class ConstructorExtensionsTests : PeriodExtensionsTests
        {
            [Fact]
            public void StartDatePastEndDate_ThrowsInvalidOperationException()
            {
                Assert.Throws(typeof(InvalidOperationException), () =>
                {
                    try
                    {
                        // ReSharper disable ObjectCreationAsStatement
                        new Period(new DateTime(2010, 1, 1), new DateTime(2009, 1, 1));
                        // ReSharper restore ObjectCreationAsStatement
                    }
                    catch (InvalidOperationException ex)
                    {
                        Assert.Equal("The start date of a period can not be past the end date.", ex.Message);
                        throw;
                    }
                });
            }
        }

        public class EquatableExtensionsTests : PeriodExtensionsTests
        {
            [Fact]
            public void Period_EqualsSamePeriod()
            {
                var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));

                Assert.True(period.Equals(period));
                Assert.True(((object)period).Equals(period));
                Assert.Equal(period.GetHashCode(), period.GetHashCode());
            }

            [Fact]
            public void Period_EqualsEqualPeriod()
            {
                var firstPeriod = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));
                var secondPeriod = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));

                Assert.True(firstPeriod.Equals(secondPeriod));
                Assert.True(((object)firstPeriod).Equals(secondPeriod));
                Assert.Equal(firstPeriod.GetHashCode(), secondPeriod.GetHashCode());
                Assert.True(firstPeriod == secondPeriod);
            }

            [Fact]
            public void Period_DoesNotEqualDifferentPeriod()
            {
                var firstPeriod = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));
                var secondPeriod = new Period(new DateTime(2009, 1, 1), new DateTime(2010, 1, 31));

                Assert.False(firstPeriod.Equals(secondPeriod));
                Assert.False(((object)firstPeriod).Equals(secondPeriod));
                Assert.False(firstPeriod.Equals(new object()));
                Assert.NotEqual(firstPeriod.GetHashCode(), secondPeriod.GetHashCode());
                Assert.True(firstPeriod != secondPeriod);
            }
        }
    }
}