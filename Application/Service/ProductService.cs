using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Domain.Model.ProductDetailModel;
using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Application.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public void Create(Product Product, List<ProductDetail> ProductDetails)
        {
            throw new NotImplementedException();
        }

        public void Delete(long ProductID)
        {
            _ProductRepository.Delete(ProductID);
        }

        public async Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync()
        {
            return await _ProductRepository.FindAllWithProductDetailsAsync();
        }

        public async Task<List<ProductWithoutProductDetailsDTO>> FindAllAsync()
        {
            return await _ProductRepository.FindAllAsync();
        }

        public async Task<List<ProductDetailWithoutProductDTO>> FindProductDetailsAsync(ProductWithoutProductDetailsDTO Product)
        {
            return await _ProductRepository.FindProductDetailsAsync(Product);
        }

        public void Update(long ProductID, Product Product, List<ProductDetail> ProductDetails)
        {
            throw new NotImplementedException();
        }
    }
}
