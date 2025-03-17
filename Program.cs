using ProductCatalog.Infrastructure.Config;
using ProductCatalog.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Agrega DbContext
builder.Services.AddDbContextServiceConfig(builder.Configuration);

// Agregar Validaciones
builder.Services.AddValidatorServiceConfig();

// Agrega Mappers
builder.Services.AddAutoMapperConfig();

// Agrega Inyección de Dependencias
builder.Services.AddDependencyInjectionServiceConfig();

// Agrega Otros servicios
builder.Services.AddOthersServiceConfig();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Usar CORS en la aplicación
app.UseCors("AllowAll");

// Agregar Middlewares
app.UseMiddleware<HandlerGlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
