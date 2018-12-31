using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Identity.Repositories;
using LicenseManager.Core.Domain.Identity.Services;
using LicenseManager.Infrastructure.Authentication;

namespace LicenseManager.Services.Identity
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IHasher _hasher;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, IJwtHandler jwtHandler, IHasher hasher)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _hasher = hasher;
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new ServiceException("user_not_found", $"User: '{userId.ToString()}' was not found.");
            }

            var token = _hasher.Create(user, userId.ToString("N"), "=", "+", "\\", "/", "?");
            await _refreshTokenRepository.CreateAsync(new RefreshToken(user, token));
        }

        public async Task<IdentityToken> CreateAccessTokenAsync(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if (refreshToken == null)
            {
                throw new ServiceException("refresh_token_not_found", $"Refresh token was not found.");
            }

            if (refreshToken.Revoked)
            {
                throw new ServiceException("refresh_token_not_revoked", $"Refresh token: '{refreshToken.Id.ToString()}' was revoked");
            }

            var user = await _userRepository.GetAsync(refreshToken.UserId);
            if (user == null)
            {
                throw new ServiceException("user_not_found", $"User: '{refreshToken.UserId.ToString()}' was not found.");
            }

            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

            return new IdentityToken
            {
                AccessToken = jwt.AccessToken,
                Expires = jwt.Expires,
                RefreshToken = refreshToken.Token,
                Role = user.Role,
                UserId = user.Id
            };
        }

        public async Task RevokeAsync(string token, Guid userId)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if (refreshToken == null || refreshToken.UserId != userId)
            {
                throw new ServiceException("refresh_token_not_revoked", $"Refresh token was not found.");
            }

            refreshToken.Revoke();
            await _refreshTokenRepository.UpdateAsync(refreshToken);
        }
    }
}