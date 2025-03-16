using ProductCatalog.Infrastructure.Adapters.Mapper;

namespace ProductCatalog.Infrastructure.Config
{
    public static class AutoMapperServiceConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileMapper));
            return services;
        }
    }
}
