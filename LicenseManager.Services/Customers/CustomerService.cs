using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Customers.Repositories;
using LicenseManager.Core.Types;
using LicenseManager.Services.Customers.DTOs;
using LicenseManager.Services.Customers.Queries;

namespace LicenseManager.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return customer == null
                ? null
                : new CustomerDto
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    CreatedAt = customer.CreatedAt
                };
        }

        public Task<IPagedResult<CustomerDto>> BrowseAsync(BrowseCustomers query)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Guid id, string email)
            => await _customerRepository.CreateAsync(new Customer(id, email));

        public async Task CompleteAsync(Guid id, string firstName, string lastName)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer.Completed)
            {
                throw new ServiceException("customer_already_completed", 
                    $"Customer account was already completed for user: '{id.ToString()}.");
            }

            customer.Complete(firstName, lastName);
            await _customerRepository.UpdateAsync(customer);
        }

    }
}