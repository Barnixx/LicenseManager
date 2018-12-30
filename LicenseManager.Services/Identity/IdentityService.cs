using System;
using System.Linq;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Identity.Factories;
using LicenseManager.Core.Domain.Identity.Repositories;
using LicenseManager.Core.Domain.Identity.Services;
using LicenseManager.Infrastructure.Authentication;
using LicenseManager.Services.Dispatchers;

namespace LicenseManager.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
        private readonly IHasher _hasher;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IEventDispatcher _eventDispatcher;

        public IdentityService(IUserRepository userRepository, 
            IUserFactory userFactory, 
            IHasher hasher, 
            IRefreshTokenRepository refreshTokenRepository, 
            IEventDispatcher eventDispatcher, 
            IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
            _hasher = hasher;
            _refreshTokenRepository = refreshTokenRepository;
            _eventDispatcher = eventDispatcher;
            _jwtHandler = jwtHandler;
        }

        public async Task SignUpAsync(Guid id, string email, string userName, string password, string role)
        {
            var user = await _userFactory.CreateAsync(id, email, userName, password, role);
            await _userRepository.CreateAsync(user);
            await _eventDispatcher.DispatchAsync(user.Events.ToArray());
        }

        public async Task<IdentityToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null || !_hasher.IsValid(user, password))
            {
                throw new ServiceException("invalid_credentials", "Invalid credentials");
            }

            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            var token = _hasher.Create(user, user.Id.ToString("N"), "=", "+", "\\");
            await _refreshTokenRepository.CreateAsync(new RefreshToken(user, token));

            user.Login();
            _userRepository.UpdateAsync(user);

            return new IdentityToken
            {
                AccessToken = jwt.AccessToken,
                Expires = jwt.Expires,
                RefreshToken = token,
                Role = user.Role,
                UserId = user.Id
            };
        }

        public async Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                // ReSharper disable once HeapView.BoxingAllocation
                throw new ServiceException("user_not_found", message: $"User: '{userId}' was not found.");
            }
            
            if(!_hasher.IsValid(user, currentPassword))
            {
                throw new ServiceException("invalid_current_password", "Invalid current password");
            }
            
            SetPassword(user, newPassword);
            await _userRepository.UpdateAsync(user);
        }

        private void SetPassword(User user, string password)
        {
            var passwordHash = _hasher.Create(user, password);
            user.SetPasswordHash(passwordHash);
        }
    }
}