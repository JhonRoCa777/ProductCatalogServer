using ProductCatalog.Application.Ports.In;
using ProductCatalog.Application.Ports.Out;
using ProductCatalog.Domain.Model;
using System.Numerics;

namespace ProductCatalog.Application.Service
{
    public class ProductService : IProductService
    {
        private IProductPersistance _ProductPersistance;

        public ProductService(IProductPersistance ProductPersistance)
        {
            _ProductPersistance = ProductPersistance;
        }

        public void Create(Product Product, List<ProductDetail> ProductDetails)
        {
            throw new NotImplementedException();
        }

        public void Delete(long ProductID)
        {
            _ProductPersistance.Delete(ProductID);
        }

        public List<Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAllWithoutDetails()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetail> GetProductDetails(long ProductID)
        {
            return _ProductPersistance.GetProductDetails(ProductID);
        }

        public void Update(long ProductID, Product Product, List<ProductDetail> ProductDetails)
        {
            throw new NotImplementedException();
        }
    }
}
