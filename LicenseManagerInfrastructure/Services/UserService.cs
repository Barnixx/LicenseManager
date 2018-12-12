using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseManagerCore.Domain;
using LicenseManagerCore.Repository;
using LicenseManagerInfrastructure.EF;

namespace LicenseManagerInfrastructure.Services
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
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}