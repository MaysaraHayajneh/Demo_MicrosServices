using Infustructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infustructure
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

