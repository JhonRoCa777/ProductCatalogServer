using AutoMapper;
using ProductCatalog.Domain.Model.ProductDetailModel;
using ProductCatalog.Domain.Model.ProductModel;
using ProductCatalog.Infrastructure.Adapters.Entity;

namespace ProductCatalog.Infrastructure.Adapters.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            // Product

            CreateMap<ProductRequestDTO, ProductEntity>();

            CreateMap<ProductEntity, ProductDTO>();

            CreateMap<ProductEntity, ProductWithProductDetailsDTO>()
                .ForMember(dest => dest.ProductDetails, opt => opt.MapFrom(src => src.ProductDetails));

            // ProductDetail

            CreateMap<ProductDetailEntity, ProductDetailDTO>();

            CreateMap<ProductDetailRequestDTO, ProductDetailEntity>();
        }
    }
}
