using FluentValidation;
using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Domain.CustomeException;
using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Application.Service
{
    public class ProductDetailService : IProductDetailService
    {
        private IProductDetailRepository _ProductDetailRepository;
        private readonly IValidator<ProductDetailRequestDTO> _Validator;

        public ProductDetailService(IProductDetailRepository ProductDetailRepository, IValidator<ProductDetailRequestDTO> Validator)
        {
            _ProductDetailRepository = ProductDetailRepository;
            _Validator = Validator;
        }

        public async Task<ProductDetailDTO> CreateAsync(ProductDetailRequestDTO ProductDetail)
        {
            var ValidationResult = await _Validator.ValidateAsync(ProductDetail);

            if(!ValidationResult.IsValid)
                throw new ValidationException(ValidationResult.Errors);

            return await _ProductDetailRepository.CreateAsync(ProductDetail);
        }

        public async Task<bool> DeleteAsync(long ProductDetailID)
        {
            var response = await _ProductDetailRepository.FindAsync(ProductDetailID);

            if(response == null)
                throw new ProductDetailNotFoundCustomeException();

            return await _ProductDetailRepository.DeleteAsync(ProductDetailID);
        }

        public async Task<ProductDetailDTO> UpdateAsync(long ProductDetailID, ProductDetailRequestDTO ProductDetail)
        {
            var ValidationResult = await _Validator.ValidateAsync(ProductDetail);

            if(!ValidationResult.IsValid)
                throw new ValidationException(ValidationResult.Errors);

            var response = await _ProductDetailRepository.FindAsync(ProductDetailID);

            if(response == null)
                throw new ProductDetailNotFoundCustomeException();

            return await _ProductDetailRepository.UpdateAsync(ProductDetailID, ProductDetail);
        }
    }
}
