using ProductCatalog.Domain.Model;
using System.Numerics;

namespace ProductCatalog.Application.Ports.In
{
    public interface IProductService
    {
        List<Product> FindAll();

        List<Product> FindAllWithoutDetails();

        void Create(Product Product, List<ProductDetail> ProductDetails);

        void Update(long ProductID, Product Product, List<ProductDetail> ProductDetails);

        void Delete(long ProductID);

        List<ProductDetail> GetProductDetails(long ProductID);
    }
}
