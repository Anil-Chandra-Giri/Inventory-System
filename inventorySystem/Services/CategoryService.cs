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

            var alreadyExists = await _db.Categories.FirstOrDefaultAsync(e => e.CategoryName == dto.CategoryName);
            if (alreadyExists != null)
            {
                throw new InvalidOperationException("Category Already Exists");
            }

            var category = new Category
            {
                CategoryCode = generator,
                CategoryName = dto.CategoryName,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
                IsActive = true,
            };

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.Where(c => c.IsActive).Select(c => new Category
            {
                CategoryCode= c.CategoryCode,
                CategoryName= c.CategoryName,
                CreatedOn= c.CreatedOn,
                LastUpdatedOn= c.LastUpdatedOn,
                IsActive= c.IsActive,
            }).ToListAsync();
        }

        public async Task<Category> DeleteCategory(string categoryName)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            category.IsActive = false;
            category.LastUpdatedOn = DateTime.Now;

            return category;
        }
    }
}
