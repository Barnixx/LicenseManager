using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Licenses;
using Microsoft.EntityFrameworkCore;
using Address = LicenseManager.Core.Domain.Addresses.Address;

namespace LicenseManager.Infrastructure.EF
{
    /*Commands line to use migration:
     dotnet ef migrations add [name] -s ../LicenseManager.Api/ --verbose
     dotnet ef database update -s ../LicenseManager.Api/ --verbose
     */
    public class LicenseManagerContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public LicenseManagerContext(DbContextOptions<LicenseManagerContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new {u.Id, u.Email, u.UserName})
                .IsUnique();
            
            modelBuilder.Entity<Customer>()
                .HasIndex(c => new {c.Email, c.Id})
                .IsUnique();
            
            modelBuilder.Entity<Address>()
                .HasIndex(a => new {a.Id, a.CustomerId});
            modelBuilder.Ignore<Core.Domain.Customers.Address>();

        }
    }
    
}