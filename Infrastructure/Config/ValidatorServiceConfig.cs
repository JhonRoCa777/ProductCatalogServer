using FluentValidation;
using ProductCatalog.Infrastructure.Validators;

namespace ProductCatalog.Infrastructure.Config
{
    public static class ValidatorServiceConfig
    {
        public static IServiceCollection AddValidatorServiceConfig(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ProductRequestValidator>();
            return services;
        }
    }
}
