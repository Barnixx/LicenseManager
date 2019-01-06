using System;
using System.Linq;
using System.Threading.Tasks;
using LicenseManager.Core.Types;
using LicenseManager.Infrastructure.Types;
using Microsoft.EntityFrameworkCore;

namespace LicenseManager.Infrastructure.EF
{
    public static class Pagination
    {
        public static async Task<IPagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, IPagedQuery query)
            => await collection.PaginateAsync(query.Page, query.Results);

        private static async Task<IPagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, int page = 1, int resultsPerPage = 10)
        {
            if (page <= 0)
            {
                page = 1;
            }

            if (resultsPerPage <= 0)
            {
                resultsPerPage = 10;
            }

            var isEmpty = await collection.AnyAsync() == false;
            if (isEmpty)
            {
                return PagedResult<T>.Empty;
            }

            var totalResults = await collection.CountAsync();
            var totalPages = (int) Math.Ceiling((decimal) totalResults / resultsPerPage);
            var data = await collection.Limit(page, resultsPerPage).ToListAsync();

            return PagedResult<T>.Create(data, page, resultsPerPage, totalPages, totalResults);
        }

        public static IQueryable<T> Limit<T>(this IQueryable<T> collection, int page = 1, int resultsPerPage = 10)
        {
            if (page <= 0)
                page = 1;
            
            if (resultsPerPage <= 0)
                resultsPerPage = 10;

            var skip = (page - 1) * resultsPerPage;
            var data = collection.Skip(skip)
                .Take(resultsPerPage);

            return data;
        }
    }
}