using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Core.Domain.Licenses.Repositories;

namespace LicenseManager.Services.Licenses
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;

        public LicenseService(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<License> GetAsync(Guid id)
            => await _licenseRepository.GetAsync(id);

        public async Task CreateAsync(Guid id, Guid customerId, string ip, string hwid, string key)
            => await _licenseRepository.CreateAsync(new License(id, customerId, ip, hwid, key));
    }
}