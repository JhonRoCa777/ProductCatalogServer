using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Domain.Model.ProductDetailModel;
using ProductCatalog.Domain.Model.ProductModel;
using ProductCatalog.Infrastructure.Adapters.Entity;

namespace ProductCatalog.Infrastructure.Adapters.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogDBContext _Context;
        private readonly IMapper _Mapper;

        public ProductRepository(ProductCatalogDBContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async void Delete(long ProductID)
        {
            throw new NotImplementedException();
        }

        public Product Find()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync()
        {
            var response = await _Context.ProductEntity
                                        .Include(p => p.ProductDetails)
                                        .ToListAsync();

            return _Mapper.Map<List<ProductWithProductDetailsDTO>>(response);
        }

        public async Task<List<ProductWithoutProductDetailsDTO>> FindAllAsync()
        {
            var response = await _Context.ProductEntity
                                        .ToListAsync();

            return _Mapper.Map<List<ProductWithoutProductDetailsDTO>>(response);
        }

        public async Task<List<ProductDetailWithoutProductDTO>> FindProductDetailsAsync(ProductWithoutProductDetailsDTO Product)
        {
            throw new NotImplementedException();
        }

        public void Save(Product Product)
        {
            throw new NotImplementedException();
        }
    }
}
