using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Common.Configuration;
using ServiceName.Common.Domain.AppFeatureExample;
using ServiceName.Common.Persistence;
using ServiceName.GrpcServices;
using ServiceName.Messaging;
using Swisschain.Extensions.EfCore;
using Swisschain.Sdk.Server.Common;

namespace ServiceName
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            base.ConfigureServicesExt(services);

            services
                .AddPersistence(Config.Db.ConnectionString)
                .AddAppFeatureExample()
                .AddEfCoreDbValidation(options =>
                {
                    options.UseDbContextFactory(factory =>
                    {
                        var builder = factory.GetRequiredService<DbContextOptionsBuilder<DatabaseContext>>();
                        var context = new DatabaseContext(builder.Options);
                        return context;
                    });
                })
                .AddMessaging(Config.RabbitMq);
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

            endpoints.MapGrpcService<MonitoringService>();
        }
    }
}
