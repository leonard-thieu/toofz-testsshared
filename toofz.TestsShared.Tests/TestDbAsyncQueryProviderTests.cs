using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace toofz.TestsShared.Tests
{
    public class TestDbAsyncQueryProviderTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var inner = Mock.Of<IQueryProvider>();

                // Act
                var provider = new TestDbAsyncQueryProvider<double>(inner);

                // Assert
                Assert.IsType<TestDbAsyncQueryProvider<double>>(provider);
            }
        }

        public class CreateQueryMethod
        {
            [Fact]
            public void ReturnsQuery()
            {
                // Arrange
                var inner = Mock.Of<IQueryProvider>();
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);

                // Act
                var query = provider.CreateQuery(expression);

                // Assert
                Assert.IsAssignableFrom<IQueryable>(query);
            }
        }

        public class CreateQueryMethod_TElement
        {
            [Fact]
            public void ReturnsQuery()
            {
                // Arrange
                var inner = Mock.Of<IQueryProvider>();
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);

                // Act
                var query = provider.CreateQuery<double>(expression);

                // Assert
                Assert.IsAssignableFrom<IQueryable<double>>(query);
            }
        }

        public class ExecuteMethod
        {
            [Fact]
            public void ReturnsResult()
            {
                // Arrange
                var mockInner = new Mock<IQueryProvider>();
                mockInner.Setup(i => i.Execute(It.IsAny<Expression>())).Returns(5.5);
                var inner = mockInner.Object;
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);

                // Act
                var result = provider.Execute(expression);

                // Assert
                Assert.Equal(5.5, result);
            }
        }

        public class ExecuteMethod_TResult
        {
            [Fact]
            public void ReturnsResult()
            {
                // Arrange
                var mockInner = new Mock<IQueryProvider>();
                mockInner.Setup(i => i.Execute<double>(It.IsAny<Expression>())).Returns(5.5);
                var inner = mockInner.Object;
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);

                // Act
                var result = provider.Execute<double>(expression);

                // Assert
                Assert.Equal(5.5, result);
            }
        }

        public class ExecuteAsyncMethod
        {
            [Fact]
            public async Task ReturnsResult()
            {
                // Arrange
                var mockInner = new Mock<IQueryProvider>();
                mockInner.Setup(i => i.Execute(It.IsAny<Expression>())).Returns(5.5);
                var inner = mockInner.Object;
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);
                var cancellationToken = CancellationToken.None;

                // Act
                var result = await provider.ExecuteAsync(expression, cancellationToken);

                // Assert
                Assert.Equal(5.5, result);
            }
        }

        public class ExecuteAsyncMethod_TResult
        {
            [Fact]
            public async Task ReturnsResult()
            {
                // Arrange
                var mockInner = new Mock<IQueryProvider>();
                mockInner.Setup(i => i.Execute<double>(It.IsAny<Expression>())).Returns(5.5);
                var inner = mockInner.Object;
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);
                var cancellationToken = CancellationToken.None;

                // Act
                var result = await provider.ExecuteAsync<double>(expression, cancellationToken);

                // Assert
                Assert.Equal(5.5, result);
            }
        }
    }
}
