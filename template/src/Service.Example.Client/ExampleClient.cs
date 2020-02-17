using Service.Example.Client.Common;
using Service.Example.Protos;

namespace Service.Example.Client
{
    public class ExampleClient : BaseGrpcClient, IExampleClient
    {
        public ExampleClient(string serverGrpcUrl) : base(serverGrpcUrl)
        {
            Monitoring = new Monitoring.MonitoringClient(Channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }
    }
}