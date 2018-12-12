using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagerCore.Domain;

namespace LicenseManagerInfrastructure.Services
{
    public interface IUserService : IService
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}