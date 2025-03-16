using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Infrastructure.Filter;

namespace ProductCatalog.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ProductExistsFilter))]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _Mapper;
        public ProductController(IProductService ProductService, IMapper Mapper)
        {
            _ProductService = ProductService;
            _Mapper = Mapper;
        }

        [HttpGet("/full")]
        public async Task<IActionResult> FindAllWithProductDetailsAsync()
        {
            return Ok(await _ProductService.FindAllWithProductDetailsAsync());
        }

        [HttpGet("/")]
        public async Task<IActionResult> FindAllAsync()
        {
            return Ok(await _ProductService.FindAllAsync());
        }

        [HttpDelete("{ProductID}")]
        public IActionResult DeleteByID (long ProductID)
        {
            _ProductService.Delete(ProductID);
            return Ok("Producto Eliminado Correctamente");
        }
    }
}
