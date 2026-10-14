using inventorySystem.Dtos.Categories;
using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _svc;

        public CategoriesController(ICategoryService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto dto)
        {
            var created = await _svc.Create(dto);
            return Ok("Category Created");
        }
    }
}
