using System;
using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class EnumExtensionsTests
    {
        
        public class IsOneOfTests
        {
            [Fact]
            public void EnumValue_IsOneOfSelf()
            {
                Assert.True(ConsoleColor.Blue.IsOneOf(ConsoleColor.Blue));
            }

            [Fact]
            public void EnumValue_IsOneOfSelfAndOther()
            {
                Assert.True(ConsoleColor.Blue.IsOneOf(ConsoleColor.Blue, ConsoleColor.Red));
            }

            [Fact]
            public void EnumValue_IsNotOneOfOther()
            {
                Assert.False(ConsoleColor.Blue.IsOneOf(ConsoleColor.Red));
            }
        }
    }
}