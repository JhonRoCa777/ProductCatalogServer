using Microsoft.EntityFrameworkCore;
using ProductCatalog.Infrastructure.Adapters.Out.Seed;

namespace ProductCatalog.Infrastructure.Adapters.Out.Entity
{
    public class ProductCatalogDBContext : DbContext
    {
        public ProductCatalogDBContext(DbContextOptions<ProductCatalogDBContext> options) : base(options) { }

        public DbSet<ProductEntity> ProductEntity { get; set; }
        public DbSet<ProductDetailEntity> ProductDetailEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Conexión
            base.OnModelCreating(builder);

            // Aplicar Seeds
            ProductEntitySeed.Seed(builder);
        }
    }
}
