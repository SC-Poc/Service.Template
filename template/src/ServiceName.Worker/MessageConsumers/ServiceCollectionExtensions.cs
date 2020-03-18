using Microsoft.Extensions.DependencyInjection;

namespace ServiceName.Worker.MessageConsumers
{
    // TODO: Just an example
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageConsumers(this IServiceCollection services)
        {
            services.AddTransient<ExecuteSomethingConsumer>();

            return services;
        }
    }
}
