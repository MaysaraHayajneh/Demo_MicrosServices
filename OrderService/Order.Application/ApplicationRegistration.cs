using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Contracts.Markers;
using System.Reflection;

namespace Order.Application
{
	public static class ApplicationRegistration
	{
		private readonly static Assembly currentAssembly = Assembly.GetExecutingAssembly();
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			return services
				.RegisterMapster()
				.RegisterFluentValidation()
				.RegisterServices();
		}

		#region Mapster
		private static IServiceCollection RegisterMapster(this IServiceCollection services)
		{
			var config = TypeAdapterConfig.GlobalSettings;
			config.Scan(currentAssembly);
			services.AddSingleton(config);
			return services;
		}
		#endregion

		#region FluentValidation
		private static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
		{
			return services.AddValidatorsFromAssembly(currentAssembly);
		}

		#endregion

		#region Services
		private static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			var implementationTypes = currentAssembly.GetTypes()
					.Where(t =>
					(t.IsClass && !t.IsAbstract && !t.IsSealed)
						&&
					 (typeof(IScope).IsAssignableFrom(t) || typeof(ISingleTon).IsAssignableFrom(t)
					 || typeof(ITransient).IsAssignableFrom(t))
					);

			foreach (var implementationType in implementationTypes)
			{
				if (typeof(IScope).IsAssignableFrom(implementationType))
				{
					var serviceType = implementationType.GetInterfaces()
						.FirstOrDefault(i => i != typeof(IScope) && i.Name.EndsWith("Service"));

					if (serviceType is null) continue;

					services.AddScoped(serviceType, implementationType);
				}
				else if (typeof(ISingleTon).IsAssignableFrom(implementationType))
				{
					var serviceType = implementationType.GetInterfaces()
						.FirstOrDefault(i => i != typeof(ISingleTon) && i.Name.EndsWith("Service"));

					if (serviceType is null) continue;

					services.AddSingleton(serviceType, implementationType);
				}
				else if (typeof(ITransient).IsAssignableFrom(implementationType))
				{
					var serviceType = implementationType.GetInterfaces()
						.FirstOrDefault(i => i != typeof(ITransient) && i.Name.EndsWith("Service"));

					if (serviceType is null) continue;

					services.AddTransient(serviceType, implementationType);
				}
			}
			return services;
		}
		#endregion
	}
}
