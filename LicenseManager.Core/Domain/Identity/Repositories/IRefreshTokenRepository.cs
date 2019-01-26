using System;
using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Identity.Repositories
{
    public interface IRefreshTokenRepository : IRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task<RefreshToken> GetAsync(Guid userId);
        Task<bool> UserTokenExists(Guid userId);
        Task CreateAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
        Task DeleteAsync(Guid id);
    }
}