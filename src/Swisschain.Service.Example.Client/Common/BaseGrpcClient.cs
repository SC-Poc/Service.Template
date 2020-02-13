using System;
using System.Net.Http;
using Grpc.Net.Client;

namespace Swisschain.Service.Example.Client.Common
{
    public class BaseGrpcClient : IDisposable
    {
        protected GrpcChannel Channel { get; }

        public BaseGrpcClient(string serverGrpcUrl)
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var httpClient = new HttpClient(httpClientHandler);

            Channel = GrpcChannel.ForAddress(serverGrpcUrl, new GrpcChannelOptions { HttpClient = httpClient });
        }

        public void Dispose()
        {
            Channel?.Dispose();
        }
    }
}