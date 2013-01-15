using System;
using System.Runtime.Serialization;
using DryPants.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.ExceptionsTests
{
    [TestClass]
    public class DryExceptionTests
    {
        #region Tests

        [TestMethod]
        public void ConstructorWithMessage_ExceptionMessageCorrectlyFormatted()
        {
            var exception = new ExceptionDummy("Car with id -1 could not be found.");

            Assert.AreEqual("Car with id -1 could not be found.", exception.Message);
        }

        [TestMethod]
        public void ConstructorWithMessageAndPropertySource_ExceptionMessageCorrectlyFormatted()
        {
            var propertySource = new { Entity = "Car", Id = -1 };

            var exception = new ExceptionDummy("{Entity} with id {Id} could not be found.", propertySource);

            Assert.AreEqual("Car with id -1 could not be found.", exception.Message);
        }    
        
        [TestMethod]
        public void ConstructorWithMessageAndPropertySourceAndInnerException_ExceptionMessageCorrectlyFormatted()
        {
            var propertySource = new { Entity = "Car", Id = -1 };
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("{Entity} with id {Id} could not be found.",
                                               propertySource,
                                               innerException);

            Assert.AreEqual("Car with id -1 could not be found.", exception.Message);
        }

        [TestMethod]
        public void ConstructorWithMessageAndInnerException_InnerExceptionPreserved()
        {
            var propertySource = new { Entity = "Car", Id = -1 };
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("{Entity} with id {Id} could not be found.",
                                               propertySource,
                                               innerException);

            Assert.AreEqual("InnerExceptionMessage", exception.InnerException.Message);
        }

        [TestMethod]
        public void ConstructorWithMessageAndPropertySourceAndInnerException_ExceptionMessageCorrect()
        {
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("Car with id -1 could not be found.",
                                               innerException);

            Assert.AreEqual("Car with id -1 could not be found.", exception.Message);
        }
    
        [TestMethod]
        public void ConstructorWithMessageAndPropertySourceAndInnerException_InnerExceptionPreserved()
        {
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("Car with id -1 could not be found.",
                                               innerException);

            Assert.AreEqual("InnerExceptionMessage", exception.InnerException.Message);
        }  
        
        [TestMethod]
        public void DefaultConstructor_ReturnsDefaultMessage()
        {
            var exception = new ExceptionDummy();
            Assert.AreEqual("Exception of type 'DryPants.Test.ExceptionsTests.DryExceptionTests+ExceptionDummy' was thrown.", exception.Message);
        }

        #endregion

        #region Dummies
        
        [Serializable]
        class ExceptionDummy : DryException
        {
            public ExceptionDummy()
            {
                
            }

            public ExceptionDummy(string message)
                : base(message)
            {
            }

            public ExceptionDummy(string message, object propertySource)
                : base(message, propertySource)
            {
            }

            public ExceptionDummy(string message, object propertySource, Exception innerException)
                : base(message, propertySource, innerException)
            {
            }

            public ExceptionDummy(string message, Exception innerException)
                : base(message, innerException)
            {
            }

            protected ExceptionDummy(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }

        #endregion
    }
}