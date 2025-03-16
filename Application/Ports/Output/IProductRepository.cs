using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Application.Ports.Output
{
    public interface IProductRepository
    {
        Task<ProductWithProductDetailsDTO> FindWithProductDetailsAsync(long ProductID);

        Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync();

        Task<List<ProductDTO>> FindAllAsync();

        Task<ProductDTO> CreateAsync(ProductRequestDTO Product);

        Task<ProductDTO> UpdateAsync(long ProductID, ProductRequestDTO Product);

        Task<bool> DeleteAsync(long ProductID);
    }
}
