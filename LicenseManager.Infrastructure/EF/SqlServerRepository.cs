using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Types;
using LicenseManager.Infrastructure.Types;
using Microsoft.EntityFrameworkCore;

namespace LicenseManager.Infrastructure.EF
{
    public class SqlServerRepository<TEntity> : ISqlServerRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly LicenseManagerContext Context;

        public SqlServerRepository(LicenseManagerContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await GetAsync(e => e.Id == id);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);


        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<IPagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery query)
            where TQuery : PagedQuery
            => await Context.Set<TEntity>().Where(predicate).PaginateAsync(query);

        public async Task CreateAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().AnyAsync(predicate);
    }
}