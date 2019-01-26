using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Licenses;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<License>()
                .HasIndex(l => new {l.Id, l.CustomerId})
                .IsUnique();
            
            modelBuilder.Entity<RefreshToken>()
                .HasIndex(t => new {t.Id, t.Token, t.UserId})
                .IsUnique();

        }
    }
    
}