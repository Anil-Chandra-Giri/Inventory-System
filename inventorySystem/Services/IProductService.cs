using inventorySystem.Dtos.Products;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(CreateProductDto product, IFormFile? productImage);
        Task<Product> UpdateProduct(string productcode, UpdateProductDto Dto);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(string productcode);
    }
}
