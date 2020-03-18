using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public interface IServiceNameClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}
