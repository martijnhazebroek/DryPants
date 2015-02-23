using System;
using System.Runtime.Serialization;
using DryPants.Exceptions;
using Xunit;

namespace DryPants.Test.Exceptions
{
    public class DryExceptionTests
    {
        #region Tests

        [Fact]
        public void ConstructorWithMessage_ExceptionMessageCorrectlyFormatted()
        {
            var exception = new ExceptionDummy("Car with id -1 could not be found.");

            Assert.Equal("Car with id -1 could not be found.", exception.Message);
        }

        [Fact]
        public void ConstructorWithMessageAndPropertySource_ExceptionMessageCorrectlyFormatted()
        {
            var propertySource = new { Entity = "Car", Id = -1 };

            var exception = new ExceptionDummy("{Entity} with id {Id} could not be found.", propertySource);

            Assert.Equal("Car with id -1 could not be found.", exception.Message);
        }

        [Fact]
        public void ConstructorWithMessageAndPropertySourceAndInnerException_ExceptionMessageCorrectlyFormatted()
        {
            var propertySource = new { Entity = "Car", Id = -1 };
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("{Entity} with id {Id} could not be found.",
                                               propertySource,
                                               innerException);

            Assert.Equal("Car with id -1 could not be found.", exception.Message);
        }

        [Fact]
        public void ConstructorWithMessageAndInnerException_InnerExceptionPreserved()
        {
            var propertySource = new { Entity = "Car", Id = -1 };
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("{Entity} with id {Id} could not be found.",
                                               propertySource,
                                               innerException);

            Assert.Equal("InnerExceptionMessage", exception.InnerException.Message);
        }

        [Fact]
        public void ConstructorWithMessageAndPropertySourceAndInnerException_ExceptionMessageCorrect()
        {
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("Car with id -1 could not be found.",
                                               innerException);

            Assert.Equal("Car with id -1 could not be found.", exception.Message);
        }

        [Fact]
        public void ConstructorWithMessageAndPropertySourceAndInnerException_InnerExceptionPreserved()
        {
            var innerException = new Exception("InnerExceptionMessage");

            var exception = new ExceptionDummy("Car with id -1 could not be found.",
                                               innerException);

            Assert.Equal("InnerExceptionMessage", exception.InnerException.Message);
        }

        [Fact]
        public void DefaultConstructor_ReturnsDefaultMessage()
        {
            var exception = new ExceptionDummy();
            Assert.Equal("Exception of type 'DryPants.Test.Exceptions.DryExceptionTests+ExceptionDummy' was thrown.", exception.Message);
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