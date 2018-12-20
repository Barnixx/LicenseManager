using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Repository;
using LicenseManager.Infrastructure.Commands.Users;

namespace LicenseManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task RegisterAsync(string username, string email, string password)
        {
            var user = new User(username, email, password);
            await _userRepository.AddAsync(user);
        }
    }
}