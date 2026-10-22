using inventorySystem.Data;
using inventorySystem.Dtos.Stock;
using inventorySystem.Dtos.StockReport;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class StockReportService: IStockReport
    {
        private readonly AppDbContext _db;
        public StockReportService(AppDbContext db)
        {
            _db= db;
        }

        public async Task<List<StockReportDto>> AllStockReport()
        {
            var report = await _db.Products
            .Select(p => new StockReportDto
            {
                ProductId = p.ProductID,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                Unit = p.Unit.ToString(),
                MRP = p.MRP,
                CurrentStock = p.Movements.Sum(m => m.UnitChange)
            })
            .OrderBy(p => p.ProductName)
            .ToListAsync();

            return report;
        }

        public async Task<StockReportDto> StockReport(string productCode)
        {
            var report = await _db.Products
            .Where(p => p.ProductCode == productCode)
            .Select(p => new StockReportDto
            {
                ProductId = p.ProductID,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                Unit = p.Unit.ToString(),
                MRP = p.MRP,
                CurrentStock = p.Movements.Sum(m => m.UnitChange)
            })
            .FirstOrDefaultAsync();

            if (report == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            return report;
        }
    }
}
