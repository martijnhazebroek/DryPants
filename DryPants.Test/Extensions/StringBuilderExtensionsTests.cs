using System.Text;
using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class StringBuilderExtensionsTests
    {
        
        public class AppendIfTests
        {
            private StringBuilder _sut;

            public AppendIfTests()
            {
                _sut = new StringBuilder();
            }

            [Fact]
            public void PredicateIsTrue_AppendIf_AppendsTextToStringBuilder()
            {
                const bool somePredicate = true;

                StringBuilder builder = _sut.AppendIf(somePredicate, "Text was added.");

                Assert.Equal("Text was added.", builder.ToString());
            }

            [Fact]
            public void PredicateIsFalse_AppendIf_DoesNotAppendTextToStringBuilder()
            {
                const bool somePredicate = false;

                StringBuilder builder = _sut.AppendIf(somePredicate, "Text was added.");

                Assert.Equal("", builder.ToString());
            }

            [Fact]
            public void PredicateIsTrue_AppendFormatIf_AppendsTextToStringBuilder()
            {
                const bool somePredicate = true;
                const string format = "The predicate provided was {0}.";

                StringBuilder builder = _sut.AppendFormatIf(somePredicate, format, somePredicate.ToString());

                Assert.Equal("The predicate provided was True.", builder.ToString());
            }

            [Fact]
            public void PredicateIsFalse_AppendFormatIf_DoesNotAppendTextToStringBuilder()
            {
                const bool somePredicate = false;
                const string format = "The predicate provided was {0}.";

                StringBuilder builder = _sut.AppendFormatIf(somePredicate, format, somePredicate.ToString());

                Assert.Equal("", builder.ToString());
            }  
            
            [Fact]
            public void MultipleAppendIfs_AllTextsWithValidPredicatesAreAppendedToStringBuilder()
            {
                const int number = -2;

                StringBuilder builder = _sut.AppendFormatIf(number >= 0, "{0} is an ", number)
                                            .AppendFormatIf(number < 0, "Minus {0} is an ", number * -1)
                                            .AppendIf(number%2 == 0, "even")
                                            .AppendIf(number%2 != 0, "odd")
                                            .Append(" number.");

                Assert.Equal("Minus 2 is an even number.", builder.ToString());
            }
        }
    }
}