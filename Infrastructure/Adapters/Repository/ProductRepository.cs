using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Ports.Output;
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

        public async Task<bool> DeleteAsync(long ProductID)
        {
            var Response = await _Context.ProductEntity.FindAsync(ProductID);

            _Context.ProductEntity.Remove(Response!);

            await _Context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync()
        {
            var Response = await _Context.ProductEntity
                                        .Include(p => p.ProductDetails)
                                        .ToListAsync();

            return _Mapper.Map<List<ProductWithProductDetailsDTO>>(Response);
        }

        public async Task<List<CredentialDTO>> FindAllAsync()
        {
            var Response = await _Context.ProductEntity
                                        .ToListAsync();

            return _Mapper.Map<List<CredentialDTO>>(Response);
        }

        public async Task<ProductWithProductDetailsDTO> FindWithProductDetailsAsync(long ProductID)
        {
            var Response = await _Context.ProductEntity
                                        .Include(p => p.ProductDetails)
                                        .FirstOrDefaultAsync(p => p.ID == ProductID);

            return _Mapper.Map<ProductWithProductDetailsDTO>(Response);
        }

        public async Task<CredentialDTO> CreateAsync(ProductRequestDTO Product)
        {
            var Response = _Mapper.Map<ProductEntity>(Product);

            await _Context.ProductEntity.AddAsync(Response);
            await _Context.SaveChangesAsync();

            return _Mapper.Map<CredentialDTO>(Response);
        }

        public async Task<CredentialDTO> UpdateAsync(long ProductID, ProductRequestDTO Product)
        {
            var Response = await _Context.ProductEntity.FindAsync(ProductID);

            Response!.Name = Product.Name;
            Response.Description = Product.Description;
            Response.Price = Product.Price;
            Response.Stock = Product.Stock;

            await _Context.SaveChangesAsync();

            return _Mapper.Map<CredentialDTO>(Response);
        }
    }
}
