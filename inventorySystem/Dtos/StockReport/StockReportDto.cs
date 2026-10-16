namespace inventorySystem.Dtos.StockReport
{
    public class StockReportDto
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal MRP { get; set; }

        public int CurrentStock { get; set; }

        public decimal TotalStockValueAtMRP => CurrentStock * MRP;
        public bool IsLowStock => CurrentStock < 10; 
    }
}
