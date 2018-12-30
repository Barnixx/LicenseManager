using System.Reflection;
using Autofac;
using LicenseManager.Core;
using LicenseManager.Core.Domain;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Identity;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Infrastructure.EF;
using Address = LicenseManager.Core.Domain.Addresses.Address;

namespace LicenseManager.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.AddSqlServerRepository<User>();
           builder.AddSqlServerRepository<RefreshToken>();
           builder.AddSqlServerRepository<Customer>();
           builder.AddSqlServerRepository<License>();
           builder.AddSqlServerRepository<Address>();
            
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            //Register assembly type
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()//
                .InstancePerLifetimeScope(); //Life time per request HTTP
        }
    }
}