
using ProductCatalog.Domain.Model;
using ProductCatalog.Infrastructure.Adapters.Out.Entity;

namespace ProductCatalog.Infrastructure.Adapters.OutPut.Repository.ProductEntityRepository
{
    public interface IProductEntityRepository
    {
        Task<ProductEntity?> FindAsync(long ProductID);

        List<ProductEntity> FindAll();

        List<ProductEntity> FindAllWithoutDetails();

        void Save(ProductEntity Product);

        void Delete(ProductEntity Product);

        List<ProductDetailEntity> GetProductDetails(ProductEntity Product);
    }
}
