using System;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Identity.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<User> GetByUserNameAsync(string userName);
        Task<bool> IsEmailUnique(string email);
        Task<bool> IsUserNameUnique(string userName);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}