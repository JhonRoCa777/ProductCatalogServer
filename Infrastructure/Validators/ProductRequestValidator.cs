using FluentValidation;
using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Infrastructure.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequestDTO>
    {
        public ProductRequestValidator()
        {
            int MaxLength_Name = 100;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MaximumLength(MaxLength_Name).WithMessage($"No puede tener más de {MaxLength_Name} caracteres");

            int MaxLength_Description = 255;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .MaximumLength(MaxLength_Description).WithMessage($"No puede tener más de {MaxLength_Description} caracteres");

            int GreaterThan_Price = 0;

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Campo Obligatorio")
                .GreaterThan(GreaterThan_Price).WithMessage($"Debe ser mayor a {GreaterThan_Price}");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("No puede ser Negativo");
        }
    }
}
