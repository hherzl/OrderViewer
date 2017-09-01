using System;
using System.Linq;

namespace OrderViewer.Core.DataLayer.Repositories
{
    public static class RepositoryExtensions
    {
        public static IQueryable<TEntity> Paging<TEntity>(this IQueryable<TEntity> query, Int32 pageSize, Int32 pageNumber) where TEntity : class
            => query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
