using System.Collections.ObjectModel;
using DryPants.Extensions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    public class StringExtensionsTests
    {
        [TestClass]
        public class EachLineTests
        {
            [TestMethod]
            public void StringTwoNewLineChars_AddEachLineToCollection_CollecionContainsThreeExpectedLines()
            {
                const string input = "Lorem Ipsum\nSecond line\nThird line.";
                var expected = new[] {"Lorem Ipsum", "Second line", "Third line."};

                var actual = new Collection<string>();
                input.EachLine(actual.Add);

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void
                StringOneCarriageReturnAndOneNewLineChar_AddEachLineToCollection_CollecionContainsThreeExpectedLines()
            {
                const string input = "Lorem Ipsum\rSecond line\nThird line.";
                var expected = new[] {"Lorem Ipsum", "Second line", "Third line."};

                var actual = new Collection<string>();
                input.EachLine(actual.Add);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class FormatNamedTests
        {
            [TestMethod]
            public void StringWithTwoPlaceHolders_FormatWithAnonymousObject_ReturnsExpectedString()
            {
                const string input =
                    "Just a simple test, because the actual code is written and tested by {Firstname} {Surname}.";

                const string expected =
                    "Just a simple test, because the actual code is written and tested by Henri Wiechers.";
                string actual = input.FormatNamed(new {Firstname = "Henri", Surname = "Wiechers"});

                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class FormatParamsTests
        {
            [TestMethod]
            public void StringWithTwoPlaceHolders_FormatWithTwoParams_ReturnsExpectedString()
            {
                const string input = "Just a simple test, because the actual code is written and tested by {0} {1}.";

                const string expected =
                    "Just a simple test, because the actual code is written and tested by Microsoft teammembers.";
                string actual = input.FormatParams("Microsoft", "teammembers");

                Assert.AreEqual(expected, actual);
            }
        }
    }
}