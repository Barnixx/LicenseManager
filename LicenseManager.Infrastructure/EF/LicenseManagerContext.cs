using LicenseManager.Core.Domain;
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
        public DbSet<UserDetails> UserDetails{ get; set; }
        public DbSet<License> Licenses{ get; set; }

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