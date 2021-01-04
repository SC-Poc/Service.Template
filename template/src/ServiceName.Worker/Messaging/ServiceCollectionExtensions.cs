using ServiceName.Common.Configuration;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Worker.Messaging.Consumers;
using Swisschain.Extensions.MassTransit;

namespace ServiceName.Worker.Messaging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, RabbitMqConfig rabbitMqConfig)
        {
            // TODO: Register consumers
            services.AddTransient<ExecuteSomethingConsumer>();

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

                    ConfigureReceivingEndpoints(cfg, context);
                });
            });

            services.AddMassTransitBusHost();

            return services;
        }

        private static void ConfigureReceivingEndpoints(IRabbitMqBusFactoryConfigurator configurator,
            IBusRegistrationContext context)
        {
            configurator.ReceiveEndpoint("swisschain-product-name-swisschain-service-name-something-execution",
                endpoint => { endpoint.Consumer(context.GetRequiredService<ExecuteSomethingConsumer>); });
        }
    }
}
