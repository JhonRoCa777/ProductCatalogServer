using ProductCatalog.Domain.Model.ProductModel;
using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Application.Ports.Input
{
    public interface IProductService
    {
        Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync();

        Task<List<CredentialDTO>> FindAllAsync();

        Task<CredentialDTO> CreateAsync(ProductRequestDTO Product);

        Task<CredentialDTO> UpdateAsync(long ProductID, ProductRequestDTO Product);

        Task<bool> DeleteAsync(long ProductID);

        Task<List<ProductDetailDTO>> FindProductDetailsAsync(long ProductID);
    }
}
