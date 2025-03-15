using ProductCatalog.Domain.Model;
using ProductCatalog.Infrastructure.Adapters.Out.Entity;

namespace ProductCatalog.Infrastructure.Adapters.OutPut.Repository.ProductEntityRepository
{
    public class ProductEntityRepository : IProductEntityRepository
    {
        private readonly ProductCatalogDBContext _Context;

        public ProductEntityRepository(ProductCatalogDBContext Context)
        {
            _Context = Context;
        }

        public void Delete(ProductEntity ProductEntity)
        {
            _Context.ProductEntity.Remove(ProductEntity);
        }

        public async Task<ProductEntity?> FindAsync(long ProductID)
        {
            return await _Context.ProductEntity.FindAsync(ProductID);
        }

        public List<ProductEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductEntity> FindAllWithoutDetails()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailEntity> GetProductDetails(ProductEntity Product)
        {
            throw new NotImplementedException();
        }

        public void Save(ProductEntity Product)
        {
            throw new NotImplementedException();
        }
    }
}
