using Microsoft.EntityFrameworkCore;
using ProductCatalog.Infrastructure.Adapters.Out.Entity;

namespace ProductCatalog.Infrastructure.Adapters.Out.Seed
{
    public class ProductEntitySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Insertar 5 productos
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { ID = 1, Name = "Laptop Gamer", Description = "Laptop potente para videojuegos", Price = 1500.00m, Stock = 10 },
                new ProductEntity { ID = 2, Name = "Smartphone Pro", Description = "Teléfono de alta gama con gran cámara", Price = 1200.00m, Stock = 15 },
                new ProductEntity { ID = 3, Name = "Smartwatch X", Description = "Reloj inteligente con monitor de salud", Price = 250.00m, Stock = 20 },
                new ProductEntity { ID = 4, Name = "Auriculares Bluetooth", Description = "Auriculares con cancelación de ruido", Price = 180.00m, Stock = 30 },
                new ProductEntity { ID = 5, Name = "Monitor 4K", Description = "Monitor UHD para diseño y juegos", Price = 500.00m }
            );

            // Insertar 3 detalles para cada producto
            modelBuilder.Entity<ProductDetailEntity>().HasData(
                // Detalles de la Laptop Gamer
                new ProductDetailEntity { ID = 1, Type = "Marca", Info = "ASUS ROG", ProductID = 1 },
                new ProductDetailEntity { ID = 2, Type = "Tamaño de Pantalla", Info = "15.6 pulgadas", ProductID = 1 },
                new ProductDetailEntity { ID = 3, Type = "Almacenamiento", Info = "1TB SSD", ProductID = 1 },

                // Detalles del Smartphone Pro
                new ProductDetailEntity { ID = 4, Type = "Marca", Info = "Apple", ProductID = 2 },
                new ProductDetailEntity { ID = 5, Type = "RAM", Info = "8GB", ProductID = 2 },
                new ProductDetailEntity { ID = 6, Type = "Almacenamiento", Info = "256GB", ProductID = 2 },

                // Detalles del Smartwatch X
                new ProductDetailEntity { ID = 7, Type = "Marca", Info = "Samsung", ProductID = 3 },
                new ProductDetailEntity { ID = 8, Type = "Batería", Info = "48 horas", ProductID = 3 },
                new ProductDetailEntity { ID = 9, Type = "Resistencia al agua", Info = "5ATM", ProductID = 3 },

                // Detalles de los Auriculares Bluetooth
                new ProductDetailEntity { ID = 10, Type = "Marca", Info = "Sony", ProductID = 4 },
                new ProductDetailEntity { ID = 11, Type = "Cancelación de ruido", Info = "Activa", ProductID = 4 },
                new ProductDetailEntity { ID = 12, Type = "Duración de batería", Info = "30 horas", ProductID = 4 },

                // Detalles del Monitor 4K
                new ProductDetailEntity { ID = 13, Type = "Marca", Info = "LG", ProductID = 5 },
                new ProductDetailEntity { ID = 14, Type = "Tamaño", Info = "27 pulgadas", ProductID = 5 },
                new ProductDetailEntity { ID = 15, Type = "Frecuencia", Info = "144Hz", ProductID = 5 }
            );
        }
    }
}
