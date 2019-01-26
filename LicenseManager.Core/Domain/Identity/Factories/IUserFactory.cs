using System;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Identity.Factories
{
    public interface IUserFactory
    {
        Task<User> CreateAsync(Guid id, string email, string userName, string password, string role = Role.User);
    }
}