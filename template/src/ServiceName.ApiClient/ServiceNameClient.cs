using Swisschain.SwisschainProductName.ServiceName.ApiClient.Common;
using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public class ServiceNameClient : BaseGrpcClient, IServiceNameClient
    {
        public ServiceNameClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
    }
}
