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

var app = builder.Build();

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
