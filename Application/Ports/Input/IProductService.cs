using ProductCatalog.Domain.Model.ProductModel;
using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Application.Ports.Input
{
    public interface IProductService
    {
        Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync();

        Task<List<ProductWithoutProductDetailsDTO>> FindAllAsync();

        void Create(Product Product, List<ProductDetail> ProductDetails);

        void Update(long ProductID, Product Product, List<ProductDetail> ProductDetails);

        void Delete(long ProductID);

        Task<List<ProductDetailWithoutProductDTO>> FindProductDetailsAsync(ProductWithoutProductDetailsDTO Product);
    }
}
