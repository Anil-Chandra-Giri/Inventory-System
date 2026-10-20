using inventorySystem.Dtos.Categories;
using inventorySystem.Model;
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

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            return Ok(await _svc.GetAllCategories());
        }


        [HttpDelete("DeleteRole")]
        public async Task<ActionResult> DeleteRole(string categoryName)
        {
            return Ok(await _svc.DeleteCategory(categoryName));
        }
    }
}
