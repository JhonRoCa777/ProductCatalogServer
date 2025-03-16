using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Domain.Model.ProductModel
{
    public record ProductWithoutProductDetailsDTO
    (
        long ID,
        string Name,
        string Description,
        float Price
    );

    public record ProductWithProductDetailsDTO
    (
        long ID,
        string Name,
        string Description,
        float Price,
        List<ProductDetailWithoutProductDTO> ProductDetails
    );
}
