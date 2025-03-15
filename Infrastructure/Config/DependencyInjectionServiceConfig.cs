using ProductCatalog.Infrastructure.Filter;

namespace ProductCatalog.Infrastructure.Config
{
    public static class DependencyInjectionServiceConfig
    {
        public static IServiceCollection AddDependencyInjectionServiceConfig(this IServiceCollection services)
        {
            services.AddScoped<ProductExistsFilter>();
            return services;
        }
    }
}
