using Swisschain.Service.Example.Protos;

namespace Swisschain.Service.Example.Client
{
    public interface IExampleClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}