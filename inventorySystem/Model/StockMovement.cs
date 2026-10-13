using System.ComponentModel.DataAnnotations;

namespace inventorySystem.Model
{
    public class StockMovement
    {
        [Key] public string MovementID { get; set; } = string.Empty;
        [Required] public string MovementType { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public decimal SoldAt { get; set; }
        [Required] public string UnitChange { get; set; } = string.Empty;
        public string? Reference { get; set; }
        public DateTime ChangeDate { get; set; }

        [Required] public string ProductID { get; set; } = string.Empty;
        public Product? Product { get; set; }

    }
}
