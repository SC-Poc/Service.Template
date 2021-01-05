using System;
using Grpc.Net.Client;
using Swisschain.SwisschainProductName.ServiceName.ApiContract;

namespace Swisschain.SwisschainProductName.ServiceName.ApiClient
{
    public class ServiceNameClient : IServiceNameClient, IDisposable
    {
        private readonly GrpcChannel _channel;

        public ServiceNameClient(string serverGrpcUrl)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            _channel = GrpcChannel.ForAddress(serverGrpcUrl);

            Monitoring = new Monitoring.MonitoringClient(_channel);
        }

        public Monitoring.MonitoringClient Monitoring { get; }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
