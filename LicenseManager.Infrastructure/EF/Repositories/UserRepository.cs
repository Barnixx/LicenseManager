using System;
using System.Linq;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Identity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LicenseManager.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlServerRepository<User> _repository;

        public UserRepository(ISqlServerRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<User> GetAsync(string email)
            => await _repository.GetAsync(u => u.Email == email.ToLowerInvariant());

        public async Task<User> GetByUserNameAsync(string userName)
            => await _repository.GetAsync(u => u.UserName == userName);

        public async Task<bool> IsEmailUnique(string email)
            => await _repository.ExistsAsync(u => u.Email == email.ToLowerInvariant()) == false;

        public async Task<bool> IsUserNameUnique(string userName)
            => await _repository.ExistsAsync(u => u.UserName == userName.ToLowerInvariant()) == false;

        public async Task CreateAsync(User user)
            => await _repository.CreateAsync(user);

        public async Task UpdateAsync(User user)
            => await _repository.UpdateAsync(user);


    }
}