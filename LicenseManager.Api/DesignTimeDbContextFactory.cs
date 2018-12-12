using System.IO;
using LicenseManager.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LicenseManager.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LicenseManagerContext>
    {


        public LicenseManagerContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<LicenseManagerContext>();
            var connectionString = configuration.GetConnectionString("SqlServer");
            builder.UseSqlServer(connectionString);
            return new LicenseManagerContext(builder.Options);
        }
    }
}