using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Common.Configuration;
using ServiceName.Common.Domain.AppFeatureExample;
using ServiceName.Common.Persistence;
using ServiceName.Worker.Messaging;
using Swisschain.Extensions.EfCore;
using Swisschain.Sdk.Server.Common;

namespace ServiceName.Worker
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
                .AddHttpClient()
                .AddPersistence(Config.Db.ConnectionString)
                .AddEfCoreDbMigration(options =>
                {
                    options.UseDbContextFactory(factory =>
                    {
                        var builder = factory.GetRequiredService<DbContextOptionsBuilder<DatabaseContext>>();
                        var context = new DatabaseContext(builder.Options);
                        return context;
                    });
                })
                .AddAppFeatureExample()
                .AddMessaging(Config.RabbitMq);
        }
    }
}
