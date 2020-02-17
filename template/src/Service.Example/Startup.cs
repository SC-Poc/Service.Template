using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Swisschain.Sdk.Server.Common;
using Service.Example.Services;

namespace Service.Example
{
    public class Startup : SwisschainStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);

            endpoints.MapGrpcService<MonitoringService>();
        }
    }
}
