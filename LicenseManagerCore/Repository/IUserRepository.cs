using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagerCore.Domain;

namespace LicenseManagerCore.Repository
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}