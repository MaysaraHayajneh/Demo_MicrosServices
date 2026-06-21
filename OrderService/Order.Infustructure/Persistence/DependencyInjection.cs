using Order.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Order.Infustructure.Persistence.Context;

namespace Order.Infustructure.Persistence
{
	public static class DependencyInjection
	{
		#region Persistence
		public static IServiceCollection RegisterPersistence(IServiceCollection services, string connectionString)
		{
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
	}
}
