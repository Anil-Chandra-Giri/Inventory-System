using inventorySystem.Enums;

namespace inventorySystem.Dtos.Stock
{
    public class StockInDto
    {
        public string ProductCode { get; set; } = string.Empty;   
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public string? Reference { get; set; }                    
    }

    public class StockOutDto
    {
        public string ProductCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal SoldPrice { get; set; }
        public string? Reference { get; set; }                    
    }

    public class StockMovementDto
    {
        public string MovementID { get; set; } = string.Empty;
        public MovementType MovementType { get; set; } 
        public string ProductID { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int UnitChange { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SoldPrice { get; set; }
        public string? Reference { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}