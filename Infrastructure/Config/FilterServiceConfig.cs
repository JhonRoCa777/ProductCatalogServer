using ProductCatalog.Infrastructure.Filter;

namespace ProductCatalog.Infrastructure.Config
{
    public static class FilterServiceConfig
    {
        public static IServiceCollection AddFilterServiceConfig(this IServiceCollection services)
        {
            services.AddScoped<ProductExistsFilter>();
            return services;
        }
    }
}
