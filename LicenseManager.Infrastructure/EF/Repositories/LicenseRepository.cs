using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Core.Domain.Licenses.Repositories;

namespace LicenseManager.Infrastructure.EF.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly ISqlServerRepository<License> _repository;

        public LicenseRepository(ISqlServerRepository<License> repository)
        {
            _repository = repository;
        }

        public async Task<License> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<License> GetAsync(Guid id, Guid customerId)
            => await _repository.GetAsync(license => license.Id == id && license.CustomerId == customerId);
        
        public async Task CreateAsync(License license)
            => await _repository.CreateAsync(license);

        public async Task UpdateAsync(License license)
            => await _repository.UpdateAsync(license);
    }
}