namespace ShuffleBag.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public sealed class FisherYatesShuffleBagTests
    {
        [TestMethod]
        public void FisherYatesShuffleBag_Constructor()
        {
            // Act
            var result = new FisherYatesShuffleBag<int>(new[] { 0 });

            // Assert
            Assert.IsInstanceOfType(result, typeof(FisherYatesShuffleBag<int>));
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyShuffleBagException))]
        public void FisherYatesShuffleBag_Empty()
        {
            // Act
            new FisherYatesShuffleBag<int>(Enumerable.Empty<int>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FisherYatesShuffleBag_NullRandom()
        {
            // Act
            new FisherYatesShuffleBag<int>(new[] { 0 }, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FisherYatesShuffleBag_NullSource()
        {
            // Act
            new FisherYatesShuffleBag<int>(null);
        }

        [TestMethod]
        public void FisherYatesShuffleBag_SingleItem()
        {
            // Arrange
            var service = new FisherYatesShuffleBag<int>(new[] { 0 });

            // Act
            var result = service.Next();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FisherYatesShuffleBag_TwoItems()
        {
            // Arrange
            var random = new Mock<Random>(MockBehavior.Strict);
            random.SetupSequence(x => x.Next(It.IsAny<int>()))
                  .Returns(0)
                  .Returns(0);

            var service = new FisherYatesShuffleBag<int>(
                new[] { 0, 1 },
                random.Object);

            // Act
            var firstResult = service.Next();
            var secondResult = service.Next();

            // Assert
            Assert.AreEqual(0, firstResult);
            Assert.AreEqual(1, secondResult);
        }

        [TestMethod]
        public void FisherYatesShuffleBag_TwoItemsReversed()
        {
            // Arrange
            var random = new Mock<Random>(MockBehavior.Strict);
            random.SetupSequence(x => x.Next(It.IsAny<int>()))
                  .Returns(1)
                  .Returns(0);

            var service = new FisherYatesShuffleBag<int>(
                new[] { 0, 1 },
                random.Object);

            // Act
            var firstResult = service.Next();
            var secondResult = service.Next();

            // Assert
            Assert.AreEqual(1, firstResult);
            Assert.AreEqual(0, secondResult);
        }
    }
}
