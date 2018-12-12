using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseManagerCore.Domain;
using LicenseManagerCore.Repository;
using LicenseManagerInfrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagerInfrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LicenseManagerContext _context;

        public UserRepository(LicenseManagerContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id) 
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);


        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();
    }
}