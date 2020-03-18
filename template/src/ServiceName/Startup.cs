using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceName.Common.AppFeatureExample;
using ServiceName.Common.Configuration;
using ServiceName.Common.HostedServices;
using ServiceName.Common.Persistence;
using ServiceName.GrpcServices;
using Swisschain.Sdk.Server.Common;

namespace ServiceName
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            base.ConfigureServicesExt(services);

            services.AddPersistence(Config.Db.ConnectionString);
            services.AddAppFeatureExample();
            
            services.AddMassTransit(x =>
            {
                // TODO: Register commands recipient endpoints. It's just an example.
                EndpointConvention.Map<ExecuteSomething>(new Uri("queue:swisschain-product-name-swisschain-service-name-something-execution"));

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(this.Config.RabbitMq.HostUrl, host =>
                    {
                        host.Username(this.Config.RabbitMq.Username);
                        host.Password(this.Config.RabbitMq.Password);
                    });

                    cfg.SetLoggerFactory(provider.GetRequiredService<ILoggerFactory>());
                }));

                services.AddSingleton<IHostedService, BusHost>();
            });
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

            endpoints.MapGrpcService<MonitoringService>();
        }
    }
}
