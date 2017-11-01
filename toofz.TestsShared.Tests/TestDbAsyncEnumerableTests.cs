using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace toofz.TestsShared.Tests
{
    public class TestDbAsyncEnumerableTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });

                // Act
                var enumerable = new TestDbAsyncEnumerable<double>(expression);

                // Assert
                Assert.IsType<TestDbAsyncEnumerable<double>>(enumerable);
            }
        }

        public class GetAsyncEnumeratorMethod
        {
            [Fact]
            public void ReturnsAsyncEnumerator()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });
                var enumerable = new TestDbAsyncEnumerable<double>(expression);

                // Act
                var asyncEnumerator = enumerable.GetAsyncEnumerator();

                // Assert
                Assert.IsAssignableFrom<IDbAsyncEnumerator<double>>(asyncEnumerator);
            }
        }

        public class IDbAsyncEnumerable_GetAsyncEnumeratorMethod
        {
            [Fact]
            public void ReturnsAsyncEnumerator()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });
                var enumerable = new TestDbAsyncEnumerable<double>(expression);
                var asyncEnumerable = (IDbAsyncEnumerable)enumerable;

                // Act
                var asyncEnumerator = asyncEnumerable.GetAsyncEnumerator();

                // Assert
                Assert.IsAssignableFrom<IDbAsyncEnumerator>(asyncEnumerator);
            }
        }

        public class IQueryable_ProviderProperty
        {
            [Fact]
            public void ReturnsProvider()
            {
                // Arrange
                var expression = Expression.Constant(new[] { 5.5 });
                var enumerable = new TestDbAsyncEnumerable<double>(expression);
                var queryable = (IQueryable)enumerable;

                // Act
                var provider = queryable.Provider;

                // Assert
                Assert.IsAssignableFrom<IQueryProvider>(provider);
            }
        }
    }
}
