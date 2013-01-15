using System;
using DryPants.Reflection;
using DryPants.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Reflection
{
    [TestClass]
    public class PropertyNameTests
    {
        [TestMethod]
        public void For_ReturnsValidResult_WhenExpressionIsValidMemberExpression()
        {
            var testClass = new TestClass();
            Assert.AreEqual("StringProp", PropertyName.For(() => testClass.StringProp));
        }
        
        [TestMethod, ExpectedException(typeof(InvalidPropertyExpressionException))]
        public void For_ThrowsException_WhenInstanceIsNull()
        {
            try
            {
                PropertyName.For(() => (TestClass)null); 
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("The given expression does not point to a property or argument name.", ex.Message);
                throw;
            }
        }
    }

    public class TestClass
    {
        public string StringProp { get; set; }
    }
}