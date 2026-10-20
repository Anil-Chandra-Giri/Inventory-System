using inventorySystem.Dtos.Categories;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface ICategoryService
    {
        Task<Category> Create(CreateCategoryDto dto);
        Task<List<Category>> GetAllCategories();
        Task<Category> DeleteCategory(string categoryName );
    }
}
