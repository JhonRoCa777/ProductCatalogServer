﻿using Microsoft.EntityFrameworkCore;
using ProductCatalog.Infrastructure.Seed;

namespace ProductCatalog.Infrastructure.Adapters.Entity
{
    public class ProductCatalogDBContext : DbContext
    {
        public ProductCatalogDBContext(DbContextOptions<ProductCatalogDBContext> options) : base(options) { }

        public DbSet<CredentialEntity> CredentialEntity { get; set; }

        public DbSet<ProductEntity> ProductEntity { get; set; }

        public DbSet<ProductDetailEntity> ProductDetailEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Conexión
            base.OnModelCreating(builder);

            // Aplicar Seeds
            CredentialEntitySeed.Seed(builder);
            ProductEntitySeed.Seed(builder);
        }
    }
}
