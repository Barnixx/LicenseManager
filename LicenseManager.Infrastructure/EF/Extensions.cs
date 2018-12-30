using Autofac;
using LicenseManager.Core.Domain;

namespace LicenseManager.Infrastructure.EF
{
    public static class Extensions
    {
        public static void AddSqlServerRepository<TEntity>(this ContainerBuilder builder) where TEntity : class, IEntity
            => builder.Register(ctx => new SqlServerRepository<TEntity>(ctx.Resolve<LicenseManagerContext>()))
                .As<ISqlServerRepository<TEntity>>()
                .InstancePerLifetimeScope();
    }
}