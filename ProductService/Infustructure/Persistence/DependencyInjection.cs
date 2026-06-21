using Order.Application.Contracts.Persistence;
using Infustructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infustructure.Persistence
{
	public static class DependencyInjection
	{
		#region Persistence
		public static IServiceCollection RegisterPersistence(IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ProductDbContext>((DbContextOptionsBuilder opt) =>
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
