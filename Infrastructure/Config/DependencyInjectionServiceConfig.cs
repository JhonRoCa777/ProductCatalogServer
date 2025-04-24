using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Application.Service;
using ProductCatalog.Infrastructure.Adapters.Repository;
using ProductCatalog.Infrastructure.Adapters.Utils;

namespace ProductCatalog.Infrastructure.Config
{
    public static class DependencyInjectionServiceConfig
    {
        public static IServiceCollection AddDependencyInjectionServiceConfig(this IServiceCollection services)
        {
            // Utils
            services.AddSingleton<JwtUtil>();
            services.AddSingleton<EncrypUtil>();

            // Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();

            // Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();

            return services;
        }
    }
}
