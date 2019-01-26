using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Types;
using LicenseManager.Infrastructure.Types;

namespace LicenseManager.Infrastructure.EF
{
    public interface ISqlServerRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IPagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
            TQuery query) where TQuery : IPagedQuery;
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(IEnumerable<TEntity> entities);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}