using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Addresses.Repositories
{
    public interface IAddressRepository : IRepository
    {
        Task<Address> GetAsync(Guid id);
        Task<IEnumerable<Address>> FindByCustomerAsync(Guid id);
        Task CreateAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(Guid id);
    }
}