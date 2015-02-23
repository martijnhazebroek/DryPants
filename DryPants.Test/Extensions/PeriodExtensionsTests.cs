using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using DryPants.Core;
using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class PeriodExtensionsTests
    {
        public PeriodExtensionsTests()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public class EachMonthExtensions : PeriodExtensionsTests
        {
            [Fact]
            public void SingleDay_PeriodOfSingleDay()
            {
                var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 1));
                var expected = new[] { "01/01/2010 - 01/01/2010" };

                AssertPeriodBasedOnToStrings(period, expected);
            }

            [Fact]
            public void SingleMonth_PeriodOfTwoFullMonths()
            {
                var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 1, 31));
                var expected = new[] {"01/01/2010 - 01/31/2010"};

                AssertPeriodBasedOnToStrings(period, expected);
            }

            [Fact]
            public void TwoMonths_PeriodOfTwoFullMonths()
            {
                var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 2, 28));
                var expected = new[]
                                   {
                                       "01/01/2010 - 01/31/2010",
                                       "02/01/2010 - 02/28/2010"
                                   };

                AssertPeriodBasedOnToStrings(period, expected);
            }

            [Fact]
            public void TwoAndHalfMonth_PeriodsOfOneFullAndOnePartialMonth()
            {
                var expected = new[]
                                   {
                                       "01/01/2010 - 01/31/2010",
                                       "02/01/2010 - 02/14/2010"
                                   };

                var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 2, 14));

                AssertPeriodBasedOnToStrings(period, expected);
            }

            [Fact]
            public void TwoMonthsLeapYear_PeriodOfTwoFullMonths()
            {
                var period = new Period(new DateTime(2012, 1, 1), new DateTime(2012, 2, 29));
                var expected = new[]
                                   {
                                       "01/01/2012 - 01/31/2012",
                                       "02/01/2012 - 02/29/2012"
                                   };

                AssertPeriodBasedOnToStrings(period, expected);
            }

            [Fact]
            public void ThreeMonthsLastMonthOneSingleDay_PeriodOfTwoFullMonthsAndOneSingleDay()
            {
                var period = new Period(new DateTime(2012, 1, 1), new DateTime(2012, 3, 1));
                var expected = new[]
                                   {
                                       "01/01/2012 - 01/31/2012",
                                       "02/01/2012 - 02/29/2012",
                                       "03/01/2012 - 03/01/2012"
                                   };

                AssertPeriodBasedOnToStrings(period, expected);
            }

            private static void AssertPeriodBasedOnToStrings(Period period, IEnumerable<string> expectedToStringCollection)
            {
                var actual = new List<string>();
                period.EachMonth(monthPeriod => actual.Add(monthPeriod.ToString()));

                Assert.Equal(expectedToStringCollection.ToList(), actual);
            }
        }
    }
}