using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Moq;

namespace toofz.TestsShared
{
    public static class MockHelper
    {
        public static Mock<DbSet<TEntity>> MockSet<TEntity>(IEnumerable<TEntity> data) where TEntity : class
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), $"{nameof(data)} is null.");

            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IDbAsyncEnumerable<TEntity>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<TEntity>(queryable.GetEnumerator()));

            var mockQueryable = mockSet.As<IQueryable<TEntity>>();
            mockQueryable.Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<TEntity>(queryable.Provider));
            mockQueryable.Setup(m => m.Expression).Returns(queryable.Expression);
            mockQueryable.Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockQueryable.Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockSet;
        }

        public static Mock<DbSet<TEntity>> MockSet<TEntity>(params TEntity[] entities) where TEntity : class
        {
            return MockSet((IEnumerable<TEntity>)entities);
        }
    }
}