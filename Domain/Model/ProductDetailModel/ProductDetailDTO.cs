namespace ProductCatalog.Domain.Model.ProductDetailModel
{
    public record ProductDetailDTO
    (
        long ID,
        string Type,
        string Info,
        long ProductID
    );

    public record ProductDetailRequestDTO
    (
        long? ID,
        string Type,
        string Info,
        long ProductID
    );
}
