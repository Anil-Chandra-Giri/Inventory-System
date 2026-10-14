using inventorySystem.Dtos.Categories;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface ICategoryService
    {
        Task<Category> Create(CreateCategoryDto dto);
    }
}
