using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Addresses;
using LicenseManager.Core.Domain.Addresses.Repositories;

namespace LicenseManager.Infrastructure.EF.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private readonly ISqlServerRepository<Address> _repository;

        public AddressRepository(ISqlServerRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<Address> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<Address>> FindByCustomerAsync(Guid id)
            => await _repository.FindAsync(a => a.CustomerId == id);

        public async Task CreateAsync(Address address)
            => await _repository.CreateAsync(address);

        public async Task UpdateAsync(Address address)
            => await _repository.UpdateAsync(address);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}