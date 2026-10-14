using inventorySystem.Dtos.Products;
using inventorySystem.Model;

namespace inventorySystem.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(CreateProductDto product, IFormFile? productImage);
    }
}
