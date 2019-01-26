using System;
using System.Threading.Tasks;
using LicenseManager.Services.Customers.DTOs;
using LicenseManager.Core.Types;
using LicenseManager.Services.Customers.Queries;

namespace LicenseManager.Services.Customers
{
    public interface ICustomerService : IService
    {
        Task<CustomerDto> GetAsync(Guid id);
        Task<IPagedResult<CustomerDto>> BrowseAsync(BrowseCustomers query);
        Task CreateAsync(Guid id, string email);
        Task CompleteAsync(Guid id, string firstName, string lastName);
    }
}