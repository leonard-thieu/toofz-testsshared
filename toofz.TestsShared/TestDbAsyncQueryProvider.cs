using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace toofz.TestsShared
{
    sealed class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        internal TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            this.inner = inner;
        }

        readonly IQueryProvider inner;

        public IQueryable CreateQuery(Expression expression) => new TestDbAsyncEnumerable<TEntity>(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new TestDbAsyncEnumerable<TElement>(expression);

        public object Execute(Expression expression) => inner.Execute(expression);

        public TResult Execute<TResult>(Expression expression) => inner.Execute<TResult>(expression);

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute(expression));

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute<TResult>(expression));

        sealed class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
        {
            public TestDbAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }

            public TestDbAsyncEnumerable(Expression expression) : base(expression) { }

            public IDbAsyncEnumerator<T> GetAsyncEnumerator() => new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

            IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() => GetAsyncEnumerator();

            IQueryProvider IQueryable.Provider => new TestDbAsyncQueryProvider<T>(this);
        }
    }
}
