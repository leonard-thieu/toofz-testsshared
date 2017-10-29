using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared.Tests
{
    internal class TestDbAsyncEnumerableTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });

                // Act
                var enumerable = new TestDbAsyncEnumerable<double>(expression);

                // Assert
                Assert.IsInstanceOfType(enumerable, typeof(TestDbAsyncEnumerable<double>));
            }
        }

        [TestClass]
        public class GetAsyncEnumeratorMethod
        {
            [TestMethod]
            public void ReturnsAsyncEnumerator()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });
                var enumerable = new TestDbAsyncEnumerable<double>(expression);

                // Act
                var asyncEnumerator = enumerable.GetAsyncEnumerator();

                // Assert
                Assert.IsInstanceOfType(asyncEnumerator, typeof(IDbAsyncEnumerator<double>));
            }
        }

        [TestClass]
        public class IDbAsyncEnumerable_GetAsyncEnumeratorMethod
        {
            [TestMethod]
            public void ReturnsAsyncEnumerator()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });
                var enumerable = new TestDbAsyncEnumerable<double>(expression);
                var asyncEnumerable = (IDbAsyncEnumerable)enumerable;

                // Act
                var asyncEnumerator = asyncEnumerable.GetAsyncEnumerator();

                // Assert
                Assert.IsInstanceOfType(asyncEnumerator, typeof(IDbAsyncEnumerator));
            }
        }

        [TestClass]
        public class IQueryable_ProviderProperty
        {
            [TestMethod]
            public void ReturnsProvider()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });
                var enumerable = new TestDbAsyncEnumerable<double>(expression);
                var queryable = (IQueryable)enumerable;

                // Act
                var provider = queryable.Provider;

                // Assert
                Assert.IsInstanceOfType(provider, typeof(IQueryProvider));
            }
        }
    }
}
