using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class DecimalExtensionsTests
    {
        
        public class RoundDownTests
        {
            [Fact]
            public void PositiveNumber5DecimalPositionsEndingWith6_RoundDownTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(10.00045M, 10.000456M.RoundDown(5));
            }

            [Fact]
            public void PositiveNumber5DecimalPositionsEndingWith4_RoundDownTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(10.00045M, 10.000454M.RoundDown(5));
            }

            [Fact]
            public void PositiveNumber6DecimalPositionsEndingWith4_RoundDownTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(10.00045M, 10.0004546M.RoundDown(5));
            }

            [Fact]
            public void NegativeNumber6DecimalPositionsEndingWith6_RoundDownTo4DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(-10.0004M, -10.000456M.RoundDown(4));
            }
        }
        public class RoundUpTests
        {
            [Fact]
            public void PositiveNumber5DecimalPositionsEndingWith6_RoundUpTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(10.00046M, 10.000456M.RoundUp(5));
            }

            [Fact]
            public void PositiveNumber5DecimalPositionsEndingWith4_RoundUpTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(10.00046M, 10.000454M.RoundUp(5));
            }

            [Fact]
            public void PositiveNumber6DecimalPositionsEndingWith4_RoundUpTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(10.00046M, 10.0004546M.RoundUp(5));
            }

            [Fact]
            public void NegativeNumber6DecimalPositionsEndingWith6_RoundUpTo4DecimalPositions_ReturnsValidDecimal()
            {
                Assert.Equal(-10.0005M, -10.000456M.RoundUp(4));
            }
        }
    }
}