using ProductCatalog.Domain.Model;
using System.Numerics;

namespace ProductCatalog.Application.Ports.Out
{
    public interface IProductPersistance
    {
        List<Product> FindAll();

        List<Product> FindAllWithoutDetails();

        void Save(Product Product);

        void Delete(long ProductID);

        List<ProductDetail> GetProductDetails(long ProductID);
    }
}
