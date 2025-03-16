using ProductCatalog.Domain.Model.ProductDetailModel;
using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Application.Ports.Output
{
    public interface IProductRepository
    {
        Product Find();

        Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync();

        Task<List<ProductWithoutProductDetailsDTO>> FindAllAsync();

        void Save(Product Product);

        void Delete(long ProductID);

        Task<List<ProductDetailWithoutProductDTO>> FindProductDetailsAsync(ProductWithoutProductDetailsDTO Product);
    }
}
