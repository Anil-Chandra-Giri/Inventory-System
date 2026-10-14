using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace inventorySystem.Model
{
    public class Product
    {
        [Key] public string ProductID { get; set; } = string.Empty;

        [Required] public string ProductCode { get; set; } = string.Empty;

        [Required] public string ProductName { get; set; } = string.Empty;

        public int Unit { get; set; }

        public decimal MRP { get; set; }
        public string? ProductImage { get; set; }

        [Required] public string CategoryID { get; set; } = string.Empty;
        [JsonIgnore] public Category? Category { get; set; }

        public ICollection<StockMovement> Movements { get; set;} = new List<StockMovement>();

    }
}
