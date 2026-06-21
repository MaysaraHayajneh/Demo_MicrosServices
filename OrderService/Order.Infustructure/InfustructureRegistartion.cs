using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infustructure.Persistence;

namespace Order.Infustructure
{
	public static class InfustructureRegistartion
	{
		public static IServiceCollection AddInfustructreServices(this IServiceCollection services, IConfiguration configuration)
		{
			DependencyInjection.RegisterPersistence(services, configuration.GetConnectionString("DefaultConnection")!);

			return services;
		}
	}
}

