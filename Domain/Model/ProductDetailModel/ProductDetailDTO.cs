namespace ProductCatalog.Domain.Model.ProductDetailModel
{
    public record ProductDetailWithoutProductDTO
    (
        long ID,
        string Type,
        string Info,
        long ProductID
    );
}
