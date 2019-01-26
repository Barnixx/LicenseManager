using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Customers.Repositories;

namespace LicenseManager.Infrastructure.EF.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlServerRepository<Customer> _repository;

        public CustomerRepository(ISqlServerRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task CreateAsync(Customer customer)
            => await _repository.CreateAsync(customer);

        public async Task UpdateAsync(Customer customer)
            => await _repository.UpdateAsync(customer);

    }
}