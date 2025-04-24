using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductCatalog.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "ID", "CreatedAt", "Email", "Password", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "admin123", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "client@gmail.com", "client123", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1L, "Laptop potente para videojuegos", "Laptop Gamer", 1500.00m, 10 },
                    { 2L, "Teléfono de alta gama con gran cámara", "Smartphone Pro", 1200.00m, 15 },
                    { 3L, "Reloj inteligente con monitor de salud", "Smartwatch X", 250.00m, 20 },
                    { 4L, "Auriculares con cancelación de ruido", "Auriculares Bluetooth", 180.00m, 30 },
                    { 5L, "Monitor UHD para diseño y juegos", "Monitor 4K", 500.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ID", "Info", "ProductID", "Type" },
                values: new object[,]
                {
                    { 1L, "ASUS ROG", 1L, "Marca" },
                    { 2L, "15.6 pulgadas", 1L, "Tamaño de Pantalla" },
                    { 3L, "1TB SSD", 1L, "Almacenamiento" },
                    { 4L, "Apple", 2L, "Marca" },
                    { 5L, "8GB", 2L, "RAM" },
                    { 6L, "256GB", 2L, "Almacenamiento" },
                    { 7L, "Samsung", 3L, "Marca" },
                    { 8L, "48 horas", 3L, "Batería" },
                    { 9L, "5ATM", 3L, "Resistencia al agua" },
                    { 10L, "Sony", 4L, "Marca" },
                    { 11L, "Activa", 4L, "Cancelación de ruido" },
                    { 12L, "30 horas", 4L, "Duración de batería" },
                    { 13L, "LG", 5L, "Marca" },
                    { 14L, "27 pulgadas", 5L, "Tamaño" },
                    { 15L, "144Hz", 5L, "Frecuencia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductID",
                table: "ProductDetails",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
