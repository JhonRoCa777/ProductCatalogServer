using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Domain.Model.ProductModel
{
    public record CredentialDTO
    (
        long ID,
        string Name,
        string Description,
        decimal Price,
        int Stock
    );

    public record ProductWithProductDetailsDTO
    (
        long ID,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        List<ProductDetailDTO> ProductDetails
    );

    public record ProductRequestDTO
    (
        long? ID,
        string Name,
        string Description,
        decimal Price,
        int Stock
    );
}
