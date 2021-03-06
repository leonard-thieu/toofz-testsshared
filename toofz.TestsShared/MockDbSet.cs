﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Moq;

namespace toofz.TestsShared
{
    // https://msdn.microsoft.com/library/dn314429.aspx
    public sealed class MockDbSet<TEntity> : Mock<DbSet<TEntity>>
         where TEntity : class
    {
        public static DbSet<TEntity> Of()
        {
            var mock = new MockDbSet<TEntity>();

            return mock.Object;
        }

        public MockDbSet(IEnumerable<TEntity> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var queryable = data.AsQueryable();

            var asIDbAsyncEnumerable = As<IDbAsyncEnumerable<TEntity>>();
            asIDbAsyncEnumerable
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<TEntity>(queryable.GetEnumerator()));

            var asIQueryable = As<IQueryable<TEntity>>();
            asIQueryable.Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<TEntity>(queryable.Provider));
            asIQueryable.Setup(m => m.Expression).Returns(queryable.Expression);
            asIQueryable.Setup(m => m.ElementType).Returns(queryable.ElementType);
            asIQueryable.Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            Setup(m => m.AsNoTracking()).Returns(Object);
            Setup(m => m.Include(It.IsAny<string>())).Returns(Object);
        }

        public MockDbSet(params TEntity[] entities) : this((IEnumerable<TEntity>)entities) { }
    }
}
