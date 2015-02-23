using System;
using DryPants.Extensions;
using Xunit;

namespace DryPants.Test.Extensions
{
    public class EnumerableExtensionsTests
    {
        public class HasCount
        {
            [Fact]
            public void ArgumentOutOfRange_Throws()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => "".CountAtLeast(-1));
            } 

            [Fact]
            public void EmptyString_HasAtLeast_Zero_Items()
            {
                Assert.True("".CountAtLeast(0));
            }

            [Fact]
            public void Hello_HasAtleast_Five_Items()
            {
                Assert.True("Hello".CountAtLeast(5));
            }

            [Fact]
            public void Hello_HasAtleast_Four_Items()
            {
                Assert.True("Hello".CountAtLeast(5));
            }

            [Fact]
            public void EmptyString_DoesNotHaveAtLeast_One_Item()
            {
                Assert.False("".CountAtLeast(1));
            }

            [Fact]
            public void Hello_DoestNotHaveAtLeast_Six_Items()
            {
                Assert.False("Hello".CountAtLeast(6));
            }
        }
    }
}