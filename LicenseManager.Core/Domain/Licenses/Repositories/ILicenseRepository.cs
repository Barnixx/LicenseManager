using System;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Licenses.Repositories
{
    public interface ILicenseRepository : IRepository
    {
        Task<License> GetAsync(Guid id);
        Task<License> GetAsync(Guid id, Guid customerId);
        Task CreateAsync(License license);
        Task UpdateAsync(License license);
    }
}