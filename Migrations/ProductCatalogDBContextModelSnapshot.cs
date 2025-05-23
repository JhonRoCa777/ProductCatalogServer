﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductCatalog.Infrastructure.Adapters.Entity;

#nullable disable

namespace ProductCatalog.Migrations
{
    [DbContext(typeof(ProductCatalogDBContext))]
    partial class ProductCatalogDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductCatalog.Infrastructure.Adapters.Entity.CredentialEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            Password = "admin123",
                            Role = 0,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "client@gmail.com",
                            Password = "client123",
                            Role = 1,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ProductCatalog.Infrastructure.Adapters.Entity.ProductDetailEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Info = "ASUS ROG",
                            ProductID = 1L,
                            Type = "Marca"
                        },
                        new
                        {
                            ID = 2L,
                            Info = "15.6 pulgadas",
                            ProductID = 1L,
                            Type = "Tamaño de Pantalla"
                        },
                        new
                        {
                            ID = 3L,
                            Info = "1TB SSD",
                            ProductID = 1L,
                            Type = "Almacenamiento"
                        },
                        new
                        {
                            ID = 4L,
                            Info = "Apple",
                            ProductID = 2L,
                            Type = "Marca"
                        },
                        new
                        {
                            ID = 5L,
                            Info = "8GB",
                            ProductID = 2L,
                            Type = "RAM"
                        },
                        new
                        {
                            ID = 6L,
                            Info = "256GB",
                            ProductID = 2L,
                            Type = "Almacenamiento"
                        },
                        new
                        {
                            ID = 7L,
                            Info = "Samsung",
                            ProductID = 3L,
                            Type = "Marca"
                        },
                        new
                        {
                            ID = 8L,
                            Info = "48 horas",
                            ProductID = 3L,
                            Type = "Batería"
                        },
                        new
                        {
                            ID = 9L,
                            Info = "5ATM",
                            ProductID = 3L,
                            Type = "Resistencia al agua"
                        },
                        new
                        {
                            ID = 10L,
                            Info = "Sony",
                            ProductID = 4L,
                            Type = "Marca"
                        },
                        new
                        {
                            ID = 11L,
                            Info = "Activa",
                            ProductID = 4L,
                            Type = "Cancelación de ruido"
                        },
                        new
                        {
                            ID = 12L,
                            Info = "30 horas",
                            ProductID = 4L,
                            Type = "Duración de batería"
                        },
                        new
                        {
                            ID = 13L,
                            Info = "LG",
                            ProductID = 5L,
                            Type = "Marca"
                        },
                        new
                        {
                            ID = 14L,
                            Info = "27 pulgadas",
                            ProductID = 5L,
                            Type = "Tamaño"
                        },
                        new
                        {
                            ID = 15L,
                            Info = "144Hz",
                            ProductID = 5L,
                            Type = "Frecuencia"
                        });
                });

            modelBuilder.Entity("ProductCatalog.Infrastructure.Adapters.Entity.ProductEntity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Description = "Laptop potente para videojuegos",
                            Name = "Laptop Gamer",
                            Price = 1500.00m,
                            Stock = 10
                        },
                        new
                        {
                            ID = 2L,
                            Description = "Teléfono de alta gama con gran cámara",
                            Name = "Smartphone Pro",
                            Price = 1200.00m,
                            Stock = 15
                        },
                        new
                        {
                            ID = 3L,
                            Description = "Reloj inteligente con monitor de salud",
                            Name = "Smartwatch X",
                            Price = 250.00m,
                            Stock = 20
                        },
                        new
                        {
                            ID = 4L,
                            Description = "Auriculares con cancelación de ruido",
                            Name = "Auriculares Bluetooth",
                            Price = 180.00m,
                            Stock = 30
                        },
                        new
                        {
                            ID = 5L,
                            Description = "Monitor UHD para diseño y juegos",
                            Name = "Monitor 4K",
                            Price = 500.00m,
                            Stock = 0
                        });
                });

            modelBuilder.Entity("ProductCatalog.Infrastructure.Adapters.Entity.ProductDetailEntity", b =>
                {
                    b.HasOne("ProductCatalog.Infrastructure.Adapters.Entity.ProductEntity", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductCatalog.Infrastructure.Adapters.Entity.ProductEntity", b =>
                {
                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
