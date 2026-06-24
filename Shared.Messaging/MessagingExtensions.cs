using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Shared.Messaging
{
    public static class MessagingExtensions
    {
        public static void AddRabbitMqMessaging(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
        {
            services.AddOptions<RabbitMqSettings>()
             .Bind(configuration.GetSection("RabbitMq"))
             .ValidateOnStart();

            services.AddMassTransit(x =>
            {
                if (assembly is not null) x.AddConsumers(assembly);

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    var settings = ctx.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                    cfg.Host(settings.Host, settings.VirtualHost, h =>
                    {
                        h.Username(settings.UserName);
                        h.Password(settings.Password);
                    });

                    if (assembly is not null) cfg.ConfigureEndpoints(ctx);

                });

                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("Dev", false));
            });

        }
    }
}
