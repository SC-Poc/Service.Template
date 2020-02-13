using Swisschain.Service.Example.Client.Common;
using Swisschain.Service.Example.Protos;

namespace Swisschain.Service.Example.Client
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