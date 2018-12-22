using System.Reflection;
using Autofac;
using LicenseManager.Core.Repository;

namespace LicenseManager.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<>()
        }
    }
}