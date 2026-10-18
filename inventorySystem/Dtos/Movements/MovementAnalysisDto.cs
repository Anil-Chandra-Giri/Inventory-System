namespace inventorySystem.Dtos.Movements
{
    public class MovementAnalysisDto
    {
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int TotalStockIn { get; set; }
        public int TotalStockOut { get; set; }
        public int NetChange => TotalStockIn - TotalStockOut;
    }

    public class StockMovementDetailDto
    {
        public DateTime ChangeDate { get; set; }
        public string MovementType { get; set; } = string.Empty;
        public int UnitChange { get; set; }
        public string? Reference { get; set; }
    }
}
