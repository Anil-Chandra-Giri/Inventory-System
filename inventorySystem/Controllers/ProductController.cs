using inventorySystem.Dtos.Products;
using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Product")]

        public async Task<IActionResult> CreateProduct ([FromForm] CreateProductDto dto, [FromForm] IFormFile? ProductImage)
        {
            try
            {
                var product = await _productService.CreateProduct(dto, ProductImage);
                return Ok(product);
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
