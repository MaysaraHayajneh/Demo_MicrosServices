using Order.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Order.Infustructure.Persistence.Context;
using Order.Application.Contracts.Messaging;
using Order.Infustructure.Messaging;

namespace Order.Infustructure.Persistence
{
    public static class DependencyInjection
    {
        #region Persistence
        public static IServiceCollection RegisterPersistence(IServiceCollection services, string connectionString)
        {
            if (connectionString is null) throw new Exception($"Connection String Is Missing For Assembly {Assembly.GetExecutingAssembly().FullName}");

            services.AddDbContext<OrderDbContext>((DbContextOptionsBuilder opt) =>
            {
                opt.UseSqlServer(connectionString, (SqlServerDbContextOptionsBuilder sqlOpt) =>
                {
                    sqlOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);

                });

            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        #endregion

        #region Messaging Services
        public static IServiceCollection RegisterMessagingServices(IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, MassTransientEventPublisher>();

            return services;
        }

        #endregion
    }
}
