using ProductCatalog.Application.Ports.Out;
using ProductCatalog.Domain.Model;
using ProductCatalog.Infrastructure.Adapters.Out.Entity;

namespace ProductCatalog.Infrastructure.Adapters.OutPut
{
    public class ProductPersistanceEF : IProductPersistance
    {

        public async void Delete(long ProductID)
        {
            var ProductEntityFound = await _Context.ProductEntity.FindAsync(ProductID);
            _Context.ProductEntity.Remove(ProductEntityFound!);
        }

        public Product Find()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Save(Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
