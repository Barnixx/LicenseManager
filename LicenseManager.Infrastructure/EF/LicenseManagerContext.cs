using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Licenses;
using Microsoft.EntityFrameworkCore;

namespace LicenseManager.Infrastructure.EF
{
    /*Commands line to use migration:
     dotnet ef migrations add [name] -s ../LicenseManager.Api/ -- verbose
     dotnet ef database update -s ../LicenseManager.Api/ --verbose
     */
    public class LicenseManagerContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<License> Licenses{ get; set; }
        public DbSet<Address> Addresses{ get; set; }

        public LicenseManagerContext(DbContextOptions<LicenseManagerContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new {u.Email, u.UserName})
                .IsUnique();
        }
    }
    
}