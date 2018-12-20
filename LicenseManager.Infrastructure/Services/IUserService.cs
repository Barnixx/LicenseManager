using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Infrastructure.Commands.Users;

namespace LicenseManager.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task RegisterAsync(string username, string email, string password);
    }
}