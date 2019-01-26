using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Core.Types;
using LicenseManager.Services.Licenses.DTOs;
using LicenseManager.Services.Licenses.Queries;

namespace LicenseManager.Services.Licenses
{
    public interface ILicenseService : IService
    {
        Task<LicenseDto> GetAsync(Guid id);
        Task<License> GetAsync(Guid id, Guid customerId);
        Task<IPagedResult<LicenseDto>> BrowseAsync(Guid customerId, BrowseLicenses query);
        Task CreateAsync(Guid commandId, Guid commandCustomerId, string commandIp, string commandHwid, string commandKey);
        Task UpdateAsync(License license);
    }
}