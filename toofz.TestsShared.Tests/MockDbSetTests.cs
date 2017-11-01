using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Xunit;

namespace toofz.TestsShared.Tests
{
    public class MockDbSetTests
    {
        public class OfMethod
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var mockObjects = MockDbSet<object>.Of();

                // Assert
                Assert.IsAssignableFrom<DbSet<object>>(mockObjects);
            }
        }

        public class Constructor_IEnumerable_TEntity
        {
            [Fact]
            public void DataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IEnumerable<object> data = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new MockDbSet<object>(data);
                });
            }

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var data = new List<object>();

                // Act
                var mockDbSet = new MockDbSet<object>(data);

                // Assert
                Assert.IsAssignableFrom<MockDbSet<object>>(mockDbSet);
            }
        }
        public class Constructor_Params_Array_TEntity
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var entity = new object();

                // Act
                var mockDbSet = new MockDbSet<object>(entity);

                // Assert
                Assert.IsAssignableFrom<MockDbSet<object>>(mockDbSet);
            }
        }

        public class IDbAsyncEnumerable_TEntity_GetAsyncEnumeratorMethod
        {
            [Fact]
            public void ReturnsAsyncEnumerator()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var asyncEnumerable = mockDbSet.As<IDbAsyncEnumerable<object>>().Object;

                // Act
                var asyncEnumerator = asyncEnumerable.GetAsyncEnumerator();

                // Assert
                Assert.NotNull(asyncEnumerator);
            }
        }

        public class IQueryable_TEntity_ProviderProperty
        {
            [Fact]
            public void ReturnsProvider()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var provider = queryable.Provider;

                // Assert
                Assert.NotNull(provider);
            }
        }

        public class IQueryable_TEntity_ExpressionProperty
        {
            [Fact]
            public void ReturnsExpression()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var expression = queryable.Expression;

                // Assert
                Assert.NotNull(expression);
            }
        }

        public class IQueryable_TEntity_ElementTypeProperty
        {
            [Fact]
            public void ReturnsElementType()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var elementType = queryable.ElementType;

                // Assert
                Assert.NotNull(elementType);
            }
        }

        public class IQueryable_TEntity_GetEnumeratorMethod
        {
            [Fact]
            public void ReturnsElementType()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var enumerator = queryable.GetEnumerator();

                // Assert
                Assert.NotNull(enumerator);
            }
        }

        public class AsNoTrackingMethod
        {
            [Fact]
            public void ReturnsDbSet()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var dbSet = mockDbSet.Object;

                // Act
                var dbSet2 = dbSet.AsNoTracking();

                // Assert
                Assert.IsAssignableFrom<DbSet<object>>(dbSet2);
            }
        }

        public class IncludeMethod
        {
            [Fact]
            public void ReturnsDbSet()
            {
                // Arrange
                var mockDbSet = new MockDbSet<string>();
                var dbSet = mockDbSet.Object;

                // Act
                var dbSet2 = dbSet.Include(d => d.Length);

                // Assert
                Assert.IsAssignableFrom<DbSet<string>>(dbSet2);
            }
        }
    }
}
