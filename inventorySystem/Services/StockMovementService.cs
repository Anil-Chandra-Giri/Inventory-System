using inventorySystem.Data;
using inventorySystem.Dtos.Movements;
using inventorySystem.Enums;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class StockMovementService: IStockMovementService
    {
        private readonly AppDbContext _db;
        public StockMovementService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<MovementAnalysisDto>> GetMovementAnalysis(DateTime startDate, DateTime endDate)
        {
            var start = startDate.Date;
            var end = endDate.Date.AddDays(1).AddTicks(-1);

            return await _db.Products
                .Select(p => new MovementAnalysisDto
                {
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,

                    TotalStockIn = p.Movements
                        .Where(m => m.ChangeDate >= start && m.ChangeDate <= end && m.MovementType == MovementType.IN)
                        .Sum(m => (int?)m.UnitChange) ?? 0,

                    TotalStockOut = p.Movements
                        .Where(m => m.ChangeDate >= start && m.ChangeDate <= end && m.MovementType == MovementType.OUT)
                        .Sum(m => (int?)Math.Abs(m.UnitChange)) ?? 0
                })
                .Where(p => p.TotalStockIn > 0 || p.TotalStockOut > 0)
                .ToListAsync();
        
        }

        public async Task<List<StockMovementDetailDto>> GetMovementDetails(string productCode, DateTime startDate, DateTime endDate)
        {
            var start = startDate.Date;
            var end = endDate.Date.AddDays(1).AddTicks(-1);

            return await _db.StockMovements
                .Where(m=>m.Product!=null && m.Product.ProductCode == productCode && m.ChangeDate >= start && m.ChangeDate <= end)
                .OrderByDescending(m => m.ChangeDate)
                .Select(m => new StockMovementDetailDto
                {
                    ChangeDate = m.ChangeDate,
                    MovementType = m.MovementType,
                    UnitChange = m.UnitChange,
                    Reference = m.Reference
                })
                .ToListAsync();
        }
    }
}
