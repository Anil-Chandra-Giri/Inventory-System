using Microsoft.AspNetCore.Http;

namespace inventorySystem.Dtos.Products
{
    public class ProductDto
    {
            public string ProductID { get; set; } = string.Empty;
            public string ProductCode { get; set; } = string.Empty;
            public string ProductName { get; set; } = string.Empty;
            public int Unit { get; set; }
            public decimal MRP { get; set; }
            public string? ProductImage { get; set; }
            public string CategoryID { get; set; } = string.Empty;
            public string CategoryName { get; set; } = string.Empty;
        }

        public class CreateProductDto
        {
            public string ProductName { get; set; } = string.Empty;
            public int Unit { get; set; }
            public decimal MRP { get; set; }
            public string CategoryName { get; set; } = string.Empty;
        }

        public class UpdateProductDto
        {
            public string ProductName { get; set; } = string.Empty;
            public int Unit { get; set; }
            public decimal MRP { get; set; }
            public string CategoryId { get; set; } = string.Empty;
        }
    
}
