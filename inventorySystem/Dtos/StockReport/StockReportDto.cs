namespace inventorySystem.Dtos.StockReport
{
    public class StockReportDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal MRP { get; set; }

        public int CurrentStock { get; set; }

        public decimal TotalStockValueAtMRP => CurrentStock * MRP;
        public bool IsLowStock => CurrentStock < 10; 
    }
}
