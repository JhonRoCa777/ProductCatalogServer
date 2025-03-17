using Microsoft.EntityFrameworkCore;
using ProductCatalog.Infrastructure.Adapters.Entity;

namespace ProductCatalog.Infrastructure.Config
{
    public static class DbContextServiceConfig
    {
        public static void AddDbContextServiceConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProductCatalogDBContext>(options =>
                options.UseSqlServer(connectionString)
                       .UseLazyLoadingProxies()
            );
        }
    }
}
