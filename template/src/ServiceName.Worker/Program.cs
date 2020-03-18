using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swisschain.Sdk.Server.Common;
using Swisschain.Sdk.Server.Loggin;

namespace ServiceName.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "SwisschainProductName ServiceName Worker";

            using (var loggerFactory = LogConfigurator.Configure("SwisschainProductName", ApplicationEnvironment.Config["SeqUrl"]))
            {
                var logger = loggerFactory.CreateLogger<Program>();

                try
                {
                    logger.LogInformation("Application is being started");

                    CreateHostBuilder(loggerFactory).Build().Run();

                    logger.LogInformation("Application has been stopped");
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Application has been terminated unexpectedly");
                }
            }
        }

        private static IHostBuilder CreateHostBuilder(ILoggerFactory loggerFactory) =>
            new HostBuilder()
                .SwisschainService<Startup>(options =>
                {
#if DEBUG
                    options.UsePorts(5100, 5101);
#endif
                    options.UseLoggerFactory(loggerFactory);
                    options.WithWebJsonConfigurationSource(ApplicationEnvironment.Config["RemoteSettingsUrl"]);
                });
    }
}
