using System;
using DryPants.Exceptions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.ExceptionsTests
{
    [UsedImplicitly]
    internal class ThrowTests
    {
        [TestClass]
        public class ArgumentNullOrWhiteSpaceTests
        {
            // ReSharper disable ExpressionIsAlwaysNull

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentNull_ThrowsValidExceptionWithValidMessage()
            {
                const string input = null;

                try
                {
                    Throw.IfArgumentNullOrWhiteSpace("input", input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: input", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentWhiteSpace_ThrowsValidExceptionWithValidMessage()
            {
                const string input = " ";

                try
                {
                    Throw.IfArgumentNullOrWhiteSpace("input", input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: input", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentEmpty_ThrowsValidExceptionWithValidMessage()
            {
                const string input = "";

                try
                {
                    Throw.IfArgumentNullOrWhiteSpace("input", input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: input", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentNameNull_ThrowsValidExceptionWithValidMessage()
            {
                const string input = null;

                try
                {
                    Throw.IfArgumentNullOrWhiteSpace(null, input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: paramName", ex.Message);
                    throw;
                }
            }

            [TestMethod]
            public void ArgumentPropertyNotNullOrWhiteSpace_ThrowsNoException()
            {
                Throw.IfArgumentNullOrWhiteSpace("paramName", "text");

                // Assert: No Exception thrown.
            }

            // ReSharper restore ExpressionIsAlwaysNull
        }

        [TestClass]
        public class ArgumentNullTests
        {
            // ReSharper disable ExpressionIsAlwaysNull

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentNull_ExpressionForObjectName_ThrowsValidExceptionWithValidMessage()
            {
                TestDummy input = null;

                try
                {
                    Throw.IfArgumentNull(() => input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: input", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentPropertyNull_ExpressionForPropertyName_ThrowsValidExceptionWithValidMessage()
            {
                var input = new TestDummy();

                try
                {
                    Throw.IfArgumentNull(() => input.TestString);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: TestString", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (InvalidOperationException))]
            public void InvalidExpressionForPropertyName_ThrowsValidExceptionWithValidMessage()
            {
                try
                {
                    Throw.IfArgumentNull(() => (TestDummy) null); // argument name cannot be determined
                }
                catch (InvalidOperationException ex)
                {
                    Assert.AreEqual("The given expression does not point to a property or argument name.", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ExpressionNull_ThrowsValidExceptionWithValidMessage()
            {
                try
                {
                    Throw.IfArgumentNull<object>(null);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: expression", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentNull_ObjectNameAsString_ThrowsValidExceptionWithValidMessage()
            {
                TestDummy input = null;

                try
                {
                    Throw.IfArgumentNull("input", input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: input", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentNameNull_ThrowsValidExceptionWithValidMessage()
            {
                TestDummy input = null;

                try
                {
                    Throw.IfArgumentNull(null, input);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: paramName", ex.Message);
                    throw;
                }
            }

            [TestMethod, ExpectedException(typeof (ArgumentNullException))]
            public void ArgumentPropertyNull_PropertyNameAsString_ThrowsValidExceptionWithValidMessage()
            {
                var input = new TestDummy();

                try
                {
                    Throw.IfArgumentNull("TestString", input.TestString);
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("Value cannot be null.\r\nParameter name: TestString", ex.Message);
                    throw;
                }
            }

            [TestMethod]
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
    }
}