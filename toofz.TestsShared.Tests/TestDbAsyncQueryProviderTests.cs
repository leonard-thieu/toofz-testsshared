using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace toofz.TestsShared.Tests
{
    internal class TestDbAsyncQueryProviderTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var inner = Mock.Of<IQueryProvider>();

                // Act
                var provider = new TestDbAsyncQueryProvider<double>(inner);

                // Assert
                Assert.IsInstanceOfType(provider, typeof(TestDbAsyncQueryProvider<double>));
            }
        }

        [TestClass]
        public class CreateQueryMethod
        {
            [TestMethod]
            public void ReturnsQuery()
            {
                // Arrange
                var inner = Mock.Of<IQueryProvider>();
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);

                // Act
                var query = provider.CreateQuery(expression);

                // Assert
                Assert.IsInstanceOfType(query, typeof(IQueryable));
            }
        }

        [TestClass]
        public class CreateQueryMethod_TElement
        {
            [TestMethod]
            public void ReturnsQuery()
            {
                // Arrange
                var inner = Mock.Of<IQueryProvider>();
                var provider = new TestDbAsyncQueryProvider<double>(inner);
                var expression = Expression.Constant(5.5);

                // Act
                var query = provider.CreateQuery<double>(expression);

                // Assert
                Assert.IsInstanceOfType(query, typeof(IQueryable<double>));
            }
        }

        [TestClass]
        public class ExecuteMethod
        {
            [TestMethod]
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
                Assert.AreEqual(5.5, result);
            }
        }

        [TestClass]
        public class ExecuteMethod_TResult
        {
            [TestMethod]
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
                Assert.AreEqual(5.5, result);
            }
        }

        [TestClass]
        public class ExecuteAsyncMethod
        {
            [TestMethod]
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
                Assert.AreEqual(5.5, result);
            }
        }

        [TestClass]
        public class ExecuteAsyncMethod_TResult
        {
            [TestMethod]
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
                Assert.AreEqual(5.5, result);
            }
        }
    }
}
