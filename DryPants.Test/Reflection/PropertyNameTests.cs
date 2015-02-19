using System;
using DryPants.Reflection;
using DryPants.Resources;
using Xunit;

namespace DryPants.Test.Reflection
{
    
    public class PropertyNameTests
    {
        [Fact]
        public void For_ReturnsValidResult_WhenExpressionIsValidMemberExpression()
        {
            var testClass = new TestClass();
            Assert.Equal("StringProp", PropertyName.For(() => testClass.StringProp));
        }
        
        [Fact]
        public void For_ThrowsException_WhenInstanceIsNull()
        {
            Assert.Throws<InvalidPropertyExpressionException>(() => PropertyName.For(() => (TestClass)null));
        }
    }

    public class TestClass
    {
        public string StringProp { get; set; }
    }
}