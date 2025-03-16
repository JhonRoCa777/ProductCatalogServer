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
            CreateMap<ProductEntity, ProductWithoutProductDetailsDTO>();

            CreateMap<ProductEntity, ProductWithProductDetailsDTO>()
                .ForMember(dest => dest.ProductDetails, opt => opt.MapFrom(src => src.ProductDetails));

            CreateMap<ProductDetailEntity, ProductDetailWithoutProductDTO>();
        }
    }
}
