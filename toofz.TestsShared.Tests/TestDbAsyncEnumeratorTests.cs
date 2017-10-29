using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace toofz.TestsShared.Tests
{
    internal class TestDbAsyncEnumeratorTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var inner = Mock.Of<IEnumerator<double>>();

                // Act
                var enumerator = new TestDbAsyncEnumerator<double>(inner);

                // Assert
                Assert.IsInstanceOfType(enumerator, typeof(TestDbAsyncEnumerator<double>));
            }
        }

        [TestClass]
        public class CurrentProperty
        {
            [TestMethod]
            public void ReturnsCurrentElement()
            {
                // Arrange
                var mockInner = new Mock<IEnumerator<double>>();
                mockInner.SetupGet(i => i.Current).Returns(5.5);
                var inner = mockInner.Object;
                var enumerator = new TestDbAsyncEnumerator<double>(inner);

                // Act
                var current = enumerator.Current;

                // Assert
                Assert.AreEqual(5.5, current);
            }
        }

        [TestClass]
        public class IDbAsyncEnumerator_CurrentProperty
        {
            [TestMethod]
            public void ReturnsCurrentElement()
            {
                // Arrange
                var mockInner = new Mock<IEnumerator<double>>();
                mockInner.SetupGet(i => i.Current).Returns(5.5);
                var inner = mockInner.Object;
                var enumerator = new TestDbAsyncEnumerator<double>(inner);
                var asyncEnumerator = (IDbAsyncEnumerator)enumerator;

                // Act
                var current = asyncEnumerator.Current;

                // Assert
                Assert.AreEqual(5.5, current);
            }
        }

        [TestClass]
        public class MoveNextAsyncMethod
        {
            [TestMethod]
            public async Task CallsMoveNextOnInner()
            {
                // Arrange
                var mockInner = new Mock<IEnumerator<double>>();
                var inner = mockInner.Object;
                var enumerator = new TestDbAsyncEnumerator<double>(inner);
                var cancellationToken = CancellationToken.None;

                // Act
                await enumerator.MoveNextAsync(cancellationToken);

                // Assert
                mockInner.Verify(i => i.MoveNext(), Times.Once);
            }

            [TestMethod]
            public async Task ReturnsValueFromInnerMoveNext()
            {
                // Arrange
                var mockInner = new Mock<IEnumerator<double>>();
                mockInner.Setup(i => i.MoveNext()).Returns(true);
                var inner = mockInner.Object;
                var enumerator = new TestDbAsyncEnumerator<double>(inner);
                var cancellationToken = CancellationToken.None;

                // Act
                var moved = await enumerator.MoveNextAsync(cancellationToken);

                // Assert
                Assert.IsTrue(moved);
            }
        }

        [TestClass]
        public class DisposeMethod
        {
            [TestMethod]
            public void DisposesInner()
            {
                // Arrange
                var mockInner = new Mock<IEnumerator<double>>();
                var inner = mockInner.Object;
                var enumerator = new TestDbAsyncEnumerator<double>(inner);

                // Act
                enumerator.Dispose();

                // Assert
                mockInner.Verify(i => i.Dispose(), Times.Once);
            }
        }
    }
}
