using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace inventorySystem.Model
{
    public class Product
    {
        [Key] public Guid ProductID { get; set; }

        [Required] public string ProductCode { get; set; } = string.Empty;

        [Required] public string ProductName { get; set; } = string.Empty;

        public int Unit { get; set; }

        public decimal MRP { get; set; }
        public string? ProductImage { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }

        [Required] public Guid CategoryID { get; set; }
        [JsonIgnore] public Category? Category { get; set; }

        public Guid CreatedByUserID { get; set; }

       [JsonIgnore] public User? CreatedByUser { get; set; }

        public Guid? UpdatedByUserID { get; set; }
       [JsonIgnore] public User? UpdatedByUser { get; set; }

        public ICollection<StockMovement> Movements { get; set;} = new List<StockMovement>();

    }
}
