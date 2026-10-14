using inventorySystem.Dtos.Stock;

namespace inventorySystem.Services
{
    public interface IStockService
    {
        Task<StockMovementDto> StockIn(StockInDto dto);
        Task<StockMovementDto> StockOut(StockOutDto dto);
    }
}
