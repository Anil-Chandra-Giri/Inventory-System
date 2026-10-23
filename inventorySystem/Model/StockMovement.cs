using inventorySystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace inventorySystem.Model
{
    public class StockMovement
    {
        [Key] public string MovementID { get; set; } = string.Empty;
        [Required]public MovementType MovementType { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SoldPrice { get; set; }
        [Required] public int UnitChange { get; set; }
        public string? Reference { get; set; }
        public DateTime ChangeDate { get; set; }

        [Required] public Guid ProductID { get; set; }
        public Product? Product { get; set; }

    }
}
