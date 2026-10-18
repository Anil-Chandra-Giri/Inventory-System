using inventorySystem.Dtos.Movements;

namespace inventorySystem.Services
{
    public interface IStockMovementService
    {
        Task<List<MovementAnalysisDto>> GetMovementAnalysis(DateTime startDate, DateTime endDate);
        Task<List<StockMovementDetailDto>> GetMovementDetails(string productCode, DateTime startDate, DateTime endDate);
    }
}
