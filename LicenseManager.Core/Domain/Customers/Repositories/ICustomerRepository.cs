using System;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Customers.Repositories
{
    public interface ICustomerRepository : IRepository
    {
        Task<Customers.Customer> GetAsync(Guid id);
        Task CreateAsync(Customers.Customer customer);
        Task UpdateAsync(Customers.Customer customer);
    }
}