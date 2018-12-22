using System;
using System.Linq;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Identity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LicenseManager.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private readonly LicenseManagerContext _context;

        public UserRepository(LicenseManagerContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
            // ReSharper disable once HeapView.BoxingAllocation
            => await _context.Users.FindAsync(id);

        public async Task<User> GetAsync(string email)
            => await _context.Users.FindAsync(email);

        public async Task<User> GetByUserNameAsync(string userName)
            => await _context.Users.FindAsync(userName);

        public Task<bool> IsEmailUnique(string email)
            => _context.Users.First(x => x.Email == email).;

        public Task<bool> IsUserNameUnique(string userName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}