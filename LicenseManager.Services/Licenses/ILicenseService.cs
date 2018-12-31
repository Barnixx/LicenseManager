using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Licenses;

namespace LicenseManager.Services.Licenses
{
    public interface ILicenseService : IService
    {
        Task<License> GetAsync(Guid id);
        Task CreateAsync(Guid id, Guid customerId, string ip, string hwid, string key);
    }
}