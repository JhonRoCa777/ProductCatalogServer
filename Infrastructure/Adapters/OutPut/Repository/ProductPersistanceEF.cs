using ProductCatalog.Application.Ports.Out;
using ProductCatalog.Domain.Model;
using ProductCatalog.Infrastructure.Adapters.Out.Entity;

namespace ProductCatalog.Infrastructure.Adapters.Out.Repository
{
    public class ProductPersistanceEF : IProductPersistance
    {
        private readonly ProductCatalogDBContext _Context;

        public ProductPersistanceEF(ProductCatalogDBContext Context)
        {
            _Context = Context;
        }
        public void Delete(long ProductID)
        {
            var ProductEntityFound = _Context.ProductEntity.Find(ProductID);

            if (ProductEntityFound != null)
            {
                _Context.ProductEntity.Remove(ProductEntityFound);
                _Context.SaveChangesAsync();
            }
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
