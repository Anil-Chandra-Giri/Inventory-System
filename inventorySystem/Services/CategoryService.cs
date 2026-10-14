using inventorySystem.Data;
using inventorySystem.Dtos.Categories;
using inventorySystem.Model;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Category> Create(CreateCategoryDto dto)
        {
            int count = await _db.Categories.CountAsync();
            string generator = $"C{(count+1):D2}";
            var category = new Category
            {
                CategoryID = generator,
                CategoryName = dto.CategoryName
            };

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return category;
        }
    }
}
