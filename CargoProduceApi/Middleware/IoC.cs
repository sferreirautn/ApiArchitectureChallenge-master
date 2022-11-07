using Core.Interfaces;
using Core.ServiceModel;
using DataAccess.Interfaces;
using DataAccess.MapperModel;

namespace CargoProduceApi.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient(typeof(IClientMapper), typeof(ClientMapper));
            services.AddTransient(typeof(IClientService), typeof(ClientService));

            return services;
        }
    }
}
    