using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace toofz.TestsShared.Tests
{
    public class TestDbAsyncEnumeratorTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var inner = Mock.Of<IEnumerator<double>>();

                // Act
                var enumerator = new TestDbAsyncEnumerator<double>(inner);

                // Assert
                Assert.IsType<TestDbAsyncEnumerator<double>>(enumerator);
            }
        }

        public class CurrentProperty
        {
            [Fact]
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
                Assert.Equal(5.5, current);
            }
        }

        public class IDbAsyncEnumerator_CurrentProperty
        {
            [Fact]
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
                Assert.Equal(5.5, current);
            }
        }

        public class MoveNextAsyncMethod
        {
            [Fact]
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

            [Fact]
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
                Assert.True(moved);
            }
        }

        public class DisposeMethod
        {
            [Fact]
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
