using System;
using System.Threading.Tasks;
using LicenseManager.Infrastructure.Authentication;

namespace LicenseManager.Services.Identity
{
    public interface IIdentityService : IService
    {
        Task SignUpAsync(Guid id, string email, string userName, string password, string role = "user");
        Task<IdentityToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
    }
}