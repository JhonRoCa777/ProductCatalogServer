using FluentValidation;
using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Domain.CustomeException;
using ProductCatalog.Domain.Model.ProductDetailModel;
using ProductCatalog.Domain.Model.ProductModel;
using ProductCatalog.Infrastructure.Adapters.Repository;

namespace ProductCatalog.Application.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private readonly IValidator<ProductRequestDTO> _Validator;

        public ProductService(IProductRepository ProductRepository, IValidator<ProductRequestDTO> Validator)
        {
            _ProductRepository = ProductRepository;
            _Validator = Validator;
        }

        public async Task<ProductDTO> CreateAsync(ProductRequestDTO Product)
        {
            var ValidationResult = await _Validator.ValidateAsync(Product);

            if (!ValidationResult.IsValid)
                throw new ValidationException(ValidationResult.Errors);

            return await _ProductRepository.CreateAsync(Product);
        }

        public async Task<bool> DeleteAsync(long ProductID)
        {
            var response = await _ProductRepository.FindWithProductDetailsAsync(ProductID);

            if (response == null)
                throw new ProductDetailNotFoundCustomeException();

            return await _ProductRepository.DeleteAsync(ProductID);
        }

        public async Task<List<ProductWithProductDetailsDTO>> FindAllWithProductDetailsAsync()
        {
            return await _ProductRepository.FindAllWithProductDetailsAsync();
        }

        public async Task<List<ProductDTO>> FindAllAsync()
        {
            return await _ProductRepository.FindAllAsync();
        }

        public async Task<List<ProductDetailDTO>> FindProductDetailsAsync(long ProductID)
        {
            var response = await _ProductRepository.FindWithProductDetailsAsync(ProductID);

            if(response == null)
                throw new ProductNotFoundCustomeException();

            return response.ProductDetails;
        }

        public async Task<ProductDTO> UpdateAsync(long ProductID, ProductRequestDTO Product)
        {
            var ValidationResult = await _Validator.ValidateAsync(Product);

            if (!ValidationResult.IsValid)
                throw new ValidationException(ValidationResult.Errors);

            var response = await _ProductRepository.FindWithProductDetailsAsync(ProductID);

            if (response == null)
                throw new ProductNotFoundCustomeException();

            return await _ProductRepository.UpdateAsync(ProductID, Product);
        }
    }
}
