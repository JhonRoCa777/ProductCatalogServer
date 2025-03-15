using ProductCatalog.Infrastructure.Config;
using ProductCatalog.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext
builder.Services.AddDbContextServiceConfig(builder.Configuration);

// Agregar Filters
builder.Services.AddFilterServiceConfig();

// Agregar Inyección de Dependencias
builder.Services.AddDependencyInjectionServiceConfig();

// Agregar Controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
