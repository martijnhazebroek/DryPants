using System.Collections.ObjectModel;
using DryPants.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
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
            public void StringOneCarriageReturnAndOneNewLineChar_AddEachLineToCollection_CollecionContainsThreeExpectedLines()
            {
                const string input = "Lorem Ipsum\rSecond line\nThird line.";
                var expected = new[] {"Lorem Ipsum", "Second line", "Third line."};

                var actual = new Collection<string>();
                input.EachLine(actual.Add);

                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
