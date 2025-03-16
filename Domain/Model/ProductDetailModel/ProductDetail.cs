using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Domain.Model.ProductDetailModel

{
    public sealed class ProductDetail
    {
        public long ID { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Info { get; set; } = string.Empty;

        public long ProductID { get; set; }

        public Product? Product { get; set; }
    }
}
