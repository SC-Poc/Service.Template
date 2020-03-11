using Example.Protos;

namespace Example.Client
{
    public interface IExampleClient
    {
        Monitoring.MonitoringClient Monitoring { get; }
    }
}
