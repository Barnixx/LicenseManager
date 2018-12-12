using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagerCore.Domain;

namespace LicenseManager.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}