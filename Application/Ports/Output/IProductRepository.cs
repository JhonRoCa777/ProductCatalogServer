using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Application.Ports.Output
{
    public interface IProductRepository
    {
        Task<ProductWithProductDetailsDTO> FindWithProductDetailsAsync(long ProductID);

        Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync();

        Task<List<CredentialDTO>> FindAllAsync();

        Task<CredentialDTO> CreateAsync(ProductRequestDTO Product);

        Task<CredentialDTO> UpdateAsync(long ProductID, ProductRequestDTO Product);

        Task<bool> DeleteAsync(long ProductID);
    }
}
