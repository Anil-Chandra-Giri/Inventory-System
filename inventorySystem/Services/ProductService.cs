using inventorySystem.Data;
using inventorySystem.Dtos.Products;
using inventorySystem.Model;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateProduct(CreateProductDto product, IFormFile? productImage)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName == product.CategoryName);
            if (category == null)
            {
                throw new InvalidOperationException("Category Does not exist");
            }

            var existingproduct = await _db.Products.FirstOrDefaultAsync(p => p.ProductName == product.ProductName);
            if (existingproduct != null)
            {
                throw new InvalidOperationException("Product already exists");
            }

            string? imagePath = null;

            if (productImage != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");

                Directory.CreateDirectory(uploadsFolder);

                var fileName = Path.GetFileName(productImage.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await productImage.CopyToAsync(stream);

                imagePath = $"/uploads/products/{fileName}";
            }

            string categoryCode = category.CategoryName[..2].ToUpper();
            string productCode = product.ProductName[..2].ToUpper();

            int count = await _db.Products.CountAsync();

            string generatedCode = $"{categoryCode}-{productCode}-{(count + 1):D3}";

            var Product = new Product
            {
                ProductID = Guid.NewGuid().ToString(),
                ProductCode = generatedCode,
                ProductName = product.ProductName,
                ProductImage = imagePath,
                Unit = product.Unit,
                MRP = product.MRP,
                CategoryID = category.CategoryID,
                IsActive = true,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = DateTime.Now,
            };

            _db.Products.Add(Product);
            await _db.SaveChangesAsync();

            return Product;
        }

        public async Task<Product> UpdateProduct(string productcode, UpdateProductDto Dto)
        {
            var product = await _db.Products.Include(c => c.Category).FirstOrDefaultAsync(x => x.ProductCode == productcode);
            if (product == null || product.IsActive==false)
            {
                throw new InvalidOperationException("Product not found");
            }
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName == Dto.CategoryName);
            product.ProductName = Dto.ProductName;
            product.MRP = Dto.MRP;
            product.Unit = Dto.Unit;
            product.CategoryID = category.CategoryID;
            product.LastUpdatedOn = DateTime.Now;

            await _db.SaveChangesAsync();

            return product;
        }



        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.
            Where(p=>p.IsActive).Select(p => new Product
            {
                ProductID = p.ProductID,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                MRP = p.MRP,
                Unit = p.Unit,
                ProductImage = p.ProductImage,
                CategoryID = p.CategoryID,
                IsActive = p.IsActive,
                LastUpdatedOn = p.LastUpdatedOn,
            }).ToListAsync();
        }

        public async Task<Product> GetProduct(string productcode)
        {
            var product = _db.Products.Where(u=>u.ProductCode == productcode).FirstOrDefault();
            if (product == null || product.IsActive==false)
            {
                throw new InvalidOperationException($"{productcode} does not exist");
            }
            return product;
        }

        public async Task<Product> DeleteProduct(string productcode)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductCode== productcode);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            product.IsActive = false;
            product.LastUpdatedOn = DateTime.Now;
            await _db.SaveChangesAsync();
            return product;
        }
    }
}
