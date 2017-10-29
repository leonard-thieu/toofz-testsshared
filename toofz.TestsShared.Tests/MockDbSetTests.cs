using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared.Tests
{
    internal class MockDbSetTests
    {
        [TestClass]
        public class OfMethod
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var mockObjects = MockDbSet<object>.Of();

                // Assert
                Assert.IsInstanceOfType(mockObjects, typeof(DbSet<object>));
            }
        }

        [TestClass]
        public class Constructor_IEnumerable_TEntity
        {
            [TestMethod]
            public void DataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IEnumerable<object> data = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new MockDbSet<object>(data);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var data = new List<object>();

                // Act
                var mockDbSet = new MockDbSet<object>(data);

                // Assert
                Assert.IsInstanceOfType(mockDbSet, typeof(MockDbSet<object>));
            }
        }

        [TestClass]
        public class Constructor_Params_Array_TEntity
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var entity = new object();

                // Act
                var mockDbSet = new MockDbSet<object>(entity);

                // Assert
                Assert.IsInstanceOfType(mockDbSet, typeof(MockDbSet<object>));
            }
        }

        [TestClass]
        public class IDbAsyncEnumerable_TEntity_GetAsyncEnumeratorMethod
        {
            [TestMethod]
            public void ReturnsAsyncEnumerator()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var asyncEnumerable = mockDbSet.As<IDbAsyncEnumerable<object>>().Object;

                // Act
                var asyncEnumerator = asyncEnumerable.GetAsyncEnumerator();

                // Assert
                Assert.IsNotNull(asyncEnumerator);
            }
        }

        [TestClass]
        public class IQueryable_TEntity_ProviderProperty
        {
            [TestMethod]
            public void ReturnsProvider()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var provider = queryable.Provider;

                // Assert
                Assert.IsNotNull(provider);
            }
        }

        [TestClass]
        public class IQueryable_TEntity_ExpressionProperty
        {
            [TestMethod]
            public void ReturnsExpression()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var expression = queryable.Expression;

                // Assert
                Assert.IsNotNull(expression);
            }
        }

        [TestClass]
        public class IQueryable_TEntity_ElementTypeProperty
        {
            [TestMethod]
            public void ReturnsElementType()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var elementType = queryable.ElementType;

                // Assert
                Assert.IsNotNull(elementType);
            }
        }

        [TestClass]
        public class IQueryable_TEntity_GetEnumeratorMethod
        {
            [TestMethod]
            public void ReturnsElementType()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var queryable = mockDbSet.As<IQueryable<object>>().Object;

                // Act
                var enumerator = queryable.GetEnumerator();

                // Assert
                Assert.IsNotNull(enumerator);
            }
        }

        [TestClass]
        public class AsNoTrackingMethod
        {
            [TestMethod]
            public void ReturnsDbSet()
            {
                // Arrange
                var mockDbSet = new MockDbSet<object>();
                var dbSet = mockDbSet.Object;

                // Act
                var dbSet2 = dbSet.AsNoTracking();

                // Assert
                Assert.IsInstanceOfType(dbSet2, typeof(DbSet<object>));
            }
        }

        [TestClass]
        public class IncludeMethod
        {
            [TestMethod]
            public void ReturnsDbSet()
            {
                // Arrange
                var mockDbSet = new MockDbSet<string>();
                var dbSet = mockDbSet.Object;

                // Act
                var dbSet2 = dbSet.Include(d => d.Length);

                // Assert
                Assert.IsInstanceOfType(dbSet2, typeof(DbSet<string>));
            }
        }
    }
}
