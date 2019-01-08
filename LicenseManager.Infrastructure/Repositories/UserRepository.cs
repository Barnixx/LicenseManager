using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Infrastructure.EF;
using LicenseManagerCore.Domain;
using LicenseManagerCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace LicenseManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LicenseManagerContext _context;

        public UserRepository(LicenseManagerContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id) 
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);


        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();
    }
}