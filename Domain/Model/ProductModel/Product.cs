using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Domain.Model.ProductModel
{
    public sealed class Product
    {
        public long ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public List<ProductDetail>? ProductDetails { get; set; }
    }
}
