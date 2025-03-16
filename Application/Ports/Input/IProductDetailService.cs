using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Application.Ports.Input
{
    public interface IProductDetailService
    {
        Task<ProductDetailDTO> CreateAsync(ProductDetailRequestDTO ProductDetail);

        Task<ProductDetailDTO> UpdateAsync(long ProductDetailID, ProductDetailRequestDTO ProductDetail);

        Task<bool> DeleteAsync(long ProductDetailID);
    }
}
