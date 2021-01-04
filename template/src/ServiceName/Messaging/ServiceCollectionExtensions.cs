using ServiceName.Common.Configuration;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Swisschain.Extensions.MassTransit;

namespace ServiceName.Messaging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, RabbitMqConfig rabbitMqConfig)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqConfig.HostUrl,
                        host =>
                        {
                            host.Username(rabbitMqConfig.Username);
                            host.Password(rabbitMqConfig.Password);
                        });

                    cfg.UseDefaultRetries(context);
                });
            });

            services.AddMassTransitBusHost();

            return services;
        }
    }
}
