using FluentValidation;
using ProductCatalog.Application.Ports.Output;
using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Infrastructure.Validators
{
    public class ProductDetailRequestValidator : AbstractValidator<ProductDetailRequestDTO>
    {
        private readonly IProductRepository _ProductRepository;

        public ProductDetailRequestValidator(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;

            int MaxLength_Type = 60;

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MaximumLength(MaxLength_Type).WithMessage($"No puede tener más de {MaxLength_Type} caracteres");

            int MaxLength_Info = 255;

            RuleFor(p => p.Info)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MaximumLength(MaxLength_Info).WithMessage($"No puede tener más de {MaxLength_Info} caracteres");

            RuleFor(p => p.ProductID)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MustAsync(ProductExists).WithMessage("El ProductID NO Registrado");
        }

        private async Task<bool> ProductExists(long ProductId, CancellationToken cancellationToken)
        {
            var Response = await _ProductRepository.FindWithProductDetailsAsync(ProductId);

            if (Response == null) return false;

            return true;
        }
    }
}
