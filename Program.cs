using ProductCatalog.Infrastructure.Config;
using ProductCatalog.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext
builder.Services.AddDbContextServiceConfig(builder.Configuration);

// Agregar Mappers
builder.Services.AddAutoMapperConfig();

// Agregar Filters
builder.Services.AddFilterServiceConfig();

// Agregar Inyección de Dependencias
builder.Services.AddDependencyInjectionServiceConfig();

// Agregar Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

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
