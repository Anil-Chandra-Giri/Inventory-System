using inventorySystem.Dtos.StockReport;

namespace inventorySystem.Services
{
    public interface IStockReport
    {
        Task<List<StockReportDto>> AllStockReport();
        Task<StockReportDto> StockReport(string productCode);
    }
}
