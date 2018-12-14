using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;

namespace LicenseManager.Core.Repository
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}