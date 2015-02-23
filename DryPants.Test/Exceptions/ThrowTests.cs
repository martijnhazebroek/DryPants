using System;
using DryPants.Exceptions;
using DryPants.Resources;
using Xunit;

namespace DryPants.Test.Exceptions
{
    public class ThrowTests
    {
        public class ArgumentNullOrWhiteSpace
        {
            // ReSharper disable ExpressionIsAlwaysNull

            [Fact]
            public void ArgumentNull_ThrowsValidExceptionWithValidMessage()
            {
                const string input = null;
                Action action = () => Throw.IfArgumentNullOrWhiteSpace("input", input);
                
                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: input");
            }

            [Fact]
            public void ArgumentWhiteSpace_ThrowsValidExceptionWithValidMessage()
            {
                const string input = " ";
                Action action = () => Throw.IfArgumentNullOrWhiteSpace("input", input);
                
                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: input");
            }

            [Fact]
            public void ArgumentEmpty_ThrowsValidExceptionWithValidMessage()
            {
                const string input = "";
                Action action = () => Throw.IfArgumentNullOrWhiteSpace("input", input);

                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: input");
            }

            [Fact]
            public void ArgumentNameNull_ThrowsValidExceptionWithValidMessage()
            {
                const string input = null;
                Action action = () => Throw.IfArgumentNullOrWhiteSpace(null, input);

                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: paramName");
            }

            [Fact]
            public void ArgumentPropertyNotNullOrWhiteSpace_ThrowsNoException()
            {
                Throw.IfArgumentNullOrWhiteSpace("paramName", "text");

                // Assert: No Exception thrown.
            }

            // ReSharper restore ExpressionIsAlwaysNull
        }
       
        public class ArgumentNull
        {
            // ReSharper disable ExpressionIsAlwaysNull

            [Fact]
            public void ArgumentNull_ExpressionForObjectName_ThrowsValidExceptionWithValidMessage()
            {
                TestDummy input = null;
                Action action = () => Throw.IfArgumentNull(() => input);

                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: input");
            }

            [Fact]
            public void ArgumentPropertyNull_ExpressionForPropertyName_ThrowsValidExceptionWithValidMessage()
            {
                var input = new TestDummy();
                Action action = () => Throw.IfArgumentNull(() => input.TestString);

                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: TestString");
            }

            [Fact]
            public void InvalidExpressionForPropertyName_ThrowsValidExceptionWithValidMessage()
            {
                Action action = () => Throw.IfArgumentNull(() => (TestDummy)null);

                AssertException<InvalidPropertyExpressionException>(action, "The given expression does not point to a property or argument name.");
            }

            [Fact]
            public void ExpressionNull_ThrowsValidExceptionWithValidMessage()
            {
                Action action = () => Throw.IfArgumentNull<object>(null);

                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: expression");
            }

            [Fact]
            public void ArgumentNull_ObjectNameAsString_ThrowsValidExceptionWithValidMessage()
            {
                TestDummy input = null;

                Action action = () => Throw.IfArgumentNull("input", input);
                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: input");
            }

            [Fact]
            public void ArgumentNameNull_ThrowsValidExceptionWithValidMessage()
            {
                TestDummy input = null;

                Action action = () => Throw.IfArgumentNull(null, input);
                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: paramName");
            }

            [Fact]
            public void ArgumentPropertyNull_PropertyNameAsString_ThrowsValidExceptionWithValidMessage()
            {
                var input = new TestDummy();

                Action action = () => Throw.IfArgumentNull("TestString", input.TestString);
                AssertException<ArgumentNullException>(action, "Value cannot be null.\r\nParameter name: TestString");
            }

            [Fact]
            public void ArgumentPropertyNotNull_ExpressionForPropertyName_ThrowsNoException()
            {
                var input = new TestDummy
                                {
                                    TestString = "Value"
                                };

                Throw.IfArgumentNull(() => input.TestString);

                // Assert: No Exception thrown.
            }

            // ReSharper restore ExpressionIsAlwaysNull
        }

        private class TestDummy
        {
            public string TestString { get; set; }
        }

        private static void AssertException<T>(Action action, string message)
        {
            Exception ex = Record.Exception(action);
            Assert.NotNull(ex);
            Assert.IsType<T>(ex);
            Assert.Equal(message, ex.Message);
        }
    }
}