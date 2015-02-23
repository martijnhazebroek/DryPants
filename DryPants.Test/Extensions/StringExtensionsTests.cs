using System.Collections.ObjectModel;
using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class StringExtensionsTests
    {
        
        public class EachLineTests
        {
            [Fact]
            public void StringTwoNewLineChars_AddEachLineToCollection_CollecionContainsThreeExpectedLines()
            {
                const string input = "Lorem Ipsum\nSecond line\nThird line.";
                var expected = new[] {"Lorem Ipsum", "Second line", "Third line."};

                var actual = new Collection<string>();
                input.EachLine(actual.Add);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void StringOneCarriageReturnAndOneNewLineChar_AddEachLineToCollection_CollecionContainsThreeExpectedLines()
            {
                const string input = "Lorem Ipsum\rSecond line\nThird line.";
                var expected = new[] {"Lorem Ipsum", "Second line", "Third line."};

                var actual = new Collection<string>();
                input.EachLine(actual.Add);

                Assert.Equal(expected, actual);
            }
        }
        public class FormatNamedTests
        {
            [Fact]
            public void StringWithTwoPlaceHolders_FormatWithAnonymousObject_ReturnsExpectedString()
            {
                const string input =
                    "Just a simple test, because the actual code is written and tested by {Firstname} {Surname}.";

                const string expected =
                    "Just a simple test, because the actual code is written and tested by Henri Wiechers.";
                string actual = input.FormatNamed(new {Firstname = "Henri", Surname = "Wiechers"});

                Assert.Equal(expected, actual);
            }
        }
        public class FormatParamsTests
        {
            [Fact]
            public void StringWithTwoPlaceHolders_FormatWithTwoParams_ReturnsExpectedString()
            {
                const string input = "Just a simple test, because the actual code is written and tested by {0} {1}.";

                const string expected =
                    "Just a simple test, because the actual code is written and tested by Microsoft teammembers.";
                string actual = input.FormatParams("Microsoft", "teammembers");

                Assert.Equal(expected, actual);
            }
        }
    }
}