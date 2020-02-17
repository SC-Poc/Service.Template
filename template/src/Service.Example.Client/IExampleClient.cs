using Service.Example.Protos;

namespace Service.Example.Client
{
    public interface IExampleClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}