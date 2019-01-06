using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Core.Domain.Licenses.Repositories;
using LicenseManager.Core.Types;
using LicenseManager.Infrastructure.Types;

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

        public async Task<IPagedResult<License>> BrowseAsync(Guid customerId, IPagedQuery query)
            => await _repository.BrowseAsync(license => license.CustomerId == customerId, query);
        
        public async Task CreateAsync(License license)
            => await _repository.CreateAsync(license);

        public async Task UpdateAsync(License license)
            => await _repository.UpdateAsync(license);
    }
}