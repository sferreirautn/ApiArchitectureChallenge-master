using Infrastructure.Profiles;

namespace CargoProduceApi.Middleware
{
    public static class Mapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                //Aquí van todos los profiles del AutoMapper
                  typeof(ClientProfile)
                );
            return services;
        }
    }
}
