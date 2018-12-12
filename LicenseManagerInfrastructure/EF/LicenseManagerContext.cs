using System;
using LicenseManagerCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagerInfrastructure.EF
{
    /*Commands line to use migration:
     dotnet ef migrations add [name] -s ../LicenseManagerApi/ -- verbose
     dotnet ef database update -s ../LicenseManagerApi/ --verbose
     */
    public class LicenseManagerContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails{ get; set; }
        public DbSet<License> Licenses{ get; set; }

        public LicenseManagerContext(DbContextOptions<LicenseManagerContext> options) : base(options)
        {
            
        }
    }
    
}