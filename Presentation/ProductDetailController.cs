using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Ports.Input;
using ProductCatalog.Domain.Model.ProductDetailModel;

namespace ProductCatalog.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDetailRequestDTO ProductDetail)
            => Ok(await _ProductDetailService.CreateAsync(ProductDetail));

        [HttpPut("{ProductDetailID}")]
        public async Task<IActionResult> UpdateAsync(long ProductDetailID, [FromBody] ProductDetailRequestDTO ProductDetail)
            => Ok(await _ProductDetailService.UpdateAsync(ProductDetailID, ProductDetail));

        [HttpDelete("{ProductDetailID}")]
        public async Task<IActionResult> DeleteAsync (long ProductDetailID)
            => Ok(await _ProductDetailService.DeleteAsync(ProductDetailID));
    }
}
