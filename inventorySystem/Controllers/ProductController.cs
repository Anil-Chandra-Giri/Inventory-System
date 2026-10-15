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

        [HttpPost("CreateProduct")]

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

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<ProductDto>> Update(string id, UpdateProductDto dto)
        {
            try
            {
                var updated = await _productService.UpdateProduct(id, dto);
                return updated is null ? NotFound() : Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
           return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            var p = await _productService.GetProduct(id);
            return p is null ? NotFound() : Ok(p);
        }
    }
}
