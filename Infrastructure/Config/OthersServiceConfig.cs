using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Infrastructure.Validators;

namespace ProductCatalog.Infrastructure.Config
{
    public static class OthersServiceConfig
    {
        public static IServiceCollection AddOthersServiceConfig(this IServiceCollection services)
        {
            // Agrega Controllers Ignorando Referencias Circulares
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            // Se Remueve Validación Automática
            services.Configure<ApiBehaviorOptions>(options =>
                { options.SuppressModelStateInvalidFilter = true; }
            );

            return services;
        }
    }
}
