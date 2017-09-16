using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace toofz.TestsShared
{
    sealed class FakeDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            this.inner = inner;
        }

        readonly IQueryProvider inner;

        public IQueryable CreateQuery(Expression expression) => new FakeDbAsyncEnumerable<TEntity>(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new FakeDbAsyncEnumerable<TElement>(expression);

        public object Execute(Expression expression) => inner.Execute(expression);

        public TResult Execute<TResult>(Expression expression) => inner.Execute<TResult>(expression);

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute(expression));

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute<TResult>(expression));
    }
}
