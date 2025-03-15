using ProductCatalog.Application.Ports.In;
using ProductCatalog.Application.Ports.Out;
using ProductCatalog.Application.Service;
using ProductCatalog.Infrastructure.Adapters.OutPut;

namespace ProductCatalog.Infrastructure.Config
{
    public static class DependencyInjectionServiceConfig
    {
        public static IServiceCollection AddDependencyInjectionServiceConfig(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IProductService, ProductService>();

            //Repository
            services.AddScoped<IProductPersistance, ProductPersistanceEF>();
            return services;
        }
    }
}
