using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Domain.Model.ProductModel;

namespace ProductCatalog.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet("full")]
        public async Task<IActionResult> FindAllWithProductDetailsAsync()
            => Ok(await _ProductService.FindAllWithProductDetailsAsync());

        [HttpGet]
        public async Task<IActionResult> FindAllAsync()
            => Ok(await _ProductService.FindAllAsync());

        [HttpGet("details/{ProductID}")]
        public async Task<IActionResult> FindProductDetailsAsync(long ProductID)
            => Ok(await _ProductService.FindProductDetailsAsync(ProductID));

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] ProductRequestDTO Product)
            => Ok(await _ProductService.CreateAsync(Product));

        [HttpPut("{ProductID}")]
        public async Task<IActionResult> UpdateAsync(long ProductID, [FromBody] ProductRequestDTO Product)
         => Ok(await _ProductService.UpdateAsync(ProductID, Product));

        [HttpDelete("{ProductID}")]
        public async Task<IActionResult> DeleteAsync(long ProductID)
            => Ok(await _ProductService.DeleteAsync(ProductID));
    }
}
