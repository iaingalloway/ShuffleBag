namespace ShuffleBag.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class EmptyShuffleBagExceptionTests
    {
        [TestMethod]
        public void EmptyShuffleBagException_Constructor()
        {
            // Act
            var result = new EmptyShuffleBagException();

            // Assert
            Assert.IsInstanceOfType(result, typeof(InvalidOperationException));
        }

        [TestMethod]
        public void EmptyShuffleBagException_InnerExceptionConstructor()
        {
            // Arrange
            var expectedMessage = "The shuffle bag must not be empty";
            var expectedInnerException = new Exception();

            // Act
            var result = new EmptyShuffleBagException(
                expectedMessage,
                expectedInnerException);

            // Assert
            Assert.IsInstanceOfType(result, typeof(InvalidOperationException));
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedInnerException, result.InnerException);
        }

        [TestMethod]
        public void EmptyShuffleBagException_MessageConstructor()
        {
            // Arrange
            var expected = "The shuffle bag must not be empty";

            // Act
            var result = new EmptyShuffleBagException(expected);

            // Assert
            Assert.IsInstanceOfType(result, typeof(InvalidOperationException));
            Assert.AreEqual(expected, result.Message);
        }
    }
}
