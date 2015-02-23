using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Core
{
    public class PercentageTests
    {
        public class Of
        {
            [Fact]
            public void Ten_Percent_Of_Hundred_Equals_Ten()
            {
                Assert.Equal(10, 10.Percent().Of(100));
            }
        }

        public class IncreaseOf
        {
            [Fact]
            public void A_Ten_Procent_Increase_Of_Hundred_Equals_HundredAndTen()
            {
                Assert.Equal(110, 10.Percent().IncreaseOf(100));
            }
            
            [Fact]
            public void Twenty_Years_Of_Compound_Interest_On_TwentyFive_Bucks_Equals_FiftyFive_Bucks()
            {
                decimal bucks = 25;
                20.Times(_ => bucks = 4.Percent().IncreaseOf(bucks));

                Assert.Equal(55, bucks.RoundUp(0));
            }
        }

        public class DecreaseOf
        {
            [Fact]
            public void A_Ten_Procent_Decrease_Of_Hundred_Equals_Ninety()
            {
                Assert.Equal(90, 10.Percent().DecreaseOf(100));
            }
        }

        public class PercentageOf
        {
            [Fact]
            public void Five_Is_One_Percent_Of_Five_Hundred()
            {
                Assert.Equal(1.Percent(), 5.IsPercentageOf(500));
            }
        }

    }
}