using System;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Licenses.Repositories
{
    public interface ILicenseRepository : IRepository
    {
        Task<License> GetAsync(Guid id);
        Task CreateAsync(License license);
    }
}