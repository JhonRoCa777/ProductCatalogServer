using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Ports.In;
using ProductCatalog.Infrastructure.Filter;

namespace ProductCatalog.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ProductExistsFilter))]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpDelete("{ProductID}")]
        public IActionResult DeleteByID (long ProductID)
        {
            _ProductService.Delete(ProductID);
            return Ok("Producto Eliminado Correctamente");
        }
    }
}
