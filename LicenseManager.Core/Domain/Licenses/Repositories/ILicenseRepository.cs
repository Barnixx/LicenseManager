using System;
using System.Threading.Tasks;
using LicenseManager.Core.Types;

namespace LicenseManager.Core.Domain.Licenses.Repositories
{
    public interface ILicenseRepository : IRepository
    {
        Task<License> GetAsync(Guid id);
        Task<License> GetAsync(Guid id, Guid customerId);
        Task<IPagedResult<License>> BrowseAsync(Guid customerId, IPagedQuery query);
        Task CreateAsync(License license);
        Task UpdateAsync(License license);
    }
}