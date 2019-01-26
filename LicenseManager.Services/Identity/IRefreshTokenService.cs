using System;
using System.Threading.Tasks;
using LicenseManager.Infrastructure.Authentication;

namespace LicenseManager.Services.Identity
{
    public interface IRefreshTokenService : IService
    {
        Task CreateAsync(Guid userId);
        Task<IdentityToken> CreateAccessTokenAsync(string token);
        Task RevokeAsync(string refreshToken, Guid userId);
    }
}