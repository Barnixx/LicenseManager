using System.Threading.Tasks;

namespace LicenseManager.Core.Domain.Identity.Repositories
{
    public interface IRefreshTokenRepository : IRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task CreateAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}