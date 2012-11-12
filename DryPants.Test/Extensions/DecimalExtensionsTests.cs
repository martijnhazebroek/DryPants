using DryPants.Extensions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    public class DecimalExtensionsTests
    {
        [TestClass]
        public class RoundDownTests
        {
            [TestMethod]
            public void PositiveNumber5DecimalPositionsEndingWith6_RoundDownTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(10.00045M, 10.000456M.RoundDown(5));
            }

            [TestMethod]
            public void PositiveNumber5DecimalPositionsEndingWith4_RoundDownTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(10.00045M, 10.000454M.RoundDown(5));
            }

            [TestMethod]
            public void PositiveNumber6DecimalPositionsEndingWith4_RoundDownTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(10.00045M, 10.0004546M.RoundDown(5));
            }

            [TestMethod]
            public void NegativeNumber6DecimalPositionsEndingWith6_RoundDownTo4DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(-10.0004M, -10.000456M.RoundDown(4));
            }
        }

        [TestClass]
        public class RoundUpTests
        {
            [TestMethod]
            public void PositiveNumber5DecimalPositionsEndingWith6_RoundUpTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(10.00046M, 10.000456M.RoundUp(5));
            }

            [TestMethod]
            public void PositiveNumber5DecimalPositionsEndingWith4_RoundUpTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(10.00046M, 10.000454M.RoundUp(5));
            }

            [TestMethod]
            public void PositiveNumber6DecimalPositionsEndingWith4_RoundUpTo5DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(10.00046M, 10.0004546M.RoundUp(5));
            }

            [TestMethod]
            public void NegativeNumber6DecimalPositionsEndingWith6_RoundUpTo4DecimalPositions_ReturnsValidDecimal()
            {
                Assert.AreEqual(-10.0005M, -10.000456M.RoundUp(4));
            }
        }
    }
}