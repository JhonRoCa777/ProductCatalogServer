using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Application.Ports.Output
{
    public interface IProductDetailRepository
    {
        Task<ProductDetailDTO> FindAsync(long ProductDetailID);

        Task<ProductDetailDTO> CreateAsync(ProductDetailRequestDTO ProductDetail);

        Task<ProductDetailDTO> UpdateAsync(long ProductDetailID, ProductDetailRequestDTO ProductDetail);

        Task<bool> DeleteAsync(long ProductDetailID);
    }
}
