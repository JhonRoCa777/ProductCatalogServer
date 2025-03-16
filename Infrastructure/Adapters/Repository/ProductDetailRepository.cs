using AutoMapper;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Domain.Model.ProductDetailModel;
using ProductCatalog.Infrastructure.Adapters.Entity;

namespace ProductCatalog.Infrastructure.Adapters.Repository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly ProductCatalogDBContext _Context;
        private readonly IMapper _Mapper;

        public ProductDetailRepository(ProductCatalogDBContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }

        public async Task<bool> DeleteAsync(long ProductDetailID)
        {
            var Response = await _Context.ProductDetailEntity.FindAsync(ProductDetailID);

            _Context.ProductDetailEntity.Remove(Response!);

            await _Context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductDetailDTO> CreateAsync(ProductDetailRequestDTO ProductDetail)
        {
            var Response = _Mapper.Map<ProductDetailEntity>(ProductDetail);

            await _Context.ProductDetailEntity.AddAsync(Response);
            await _Context.SaveChangesAsync();

            return _Mapper.Map<ProductDetailDTO>(Response);
        }

        public async Task<ProductDetailDTO> UpdateAsync(long ProductDetailID, ProductDetailRequestDTO ProductDetail)
        {
            var Response = await _Context.ProductDetailEntity.FindAsync(ProductDetailID);

            Response!.Type = ProductDetail.Type;
            Response.Info = ProductDetail.Info;
            Response.ProductID = ProductDetail.ProductID;

            await _Context.SaveChangesAsync();

            return _Mapper.Map<ProductDetailDTO>(Response);
        }

        public async Task<ProductDetailDTO> FindAsync(long ProductDetailID)
        {
             var Response = await _Context.ProductDetailEntity.FindAsync(ProductDetailID);

            return _Mapper.Map<ProductDetailDTO>(Response);
        }
    }
}
