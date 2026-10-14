using inventorySystem.Data;
using inventorySystem.Dtos.Stock;
using inventorySystem.Model;
using Microsoft.EntityFrameworkCore;

namespace inventorySystem.Services
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _db;
        public StockService(AppDbContext db) 
        {
            _db = db;
        }

        public async Task<StockMovementDto> StockIn(StockInDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Quantity must be greater than 0.");

            var product = await _db.Products
                .FirstOrDefaultAsync(p => p.ProductCode == dto.ProductCode)
                ?? throw new InvalidOperationException($"Product '{dto.ProductCode}' not found.");

            var movement = new StockMovement
            {
                MovementID = Guid.NewGuid().ToString(),
                MovementType = "IN",
                UnitChange = dto.Quantity,           
                CostPrice = dto.CostPrice,
                SoldPrice = 0,
                Reference = dto.Reference,
                ChangeDate = DateTime.UtcNow,
                ProductID = product.ProductID
            };

            _db.StockMovements.Add(movement);
            await _db.SaveChangesAsync();

            return ToDto(movement, product);
        }

        public async Task<StockMovementDto> StockOut(StockOutDto dto)
        {
            if (dto.Quantity <= 0)
                throw new InvalidOperationException("Quantity must be greater than 0.");

            var product = await _db.Products
                .FirstOrDefaultAsync(p => p.ProductCode == dto.ProductCode)
                ?? throw new InvalidOperationException($"Product '{dto.ProductCode}' not found.");

            var onHand = await _db.StockMovements
                .Where(m => m.ProductID == product.ProductID)
                .SumAsync(m => (int?)m.UnitChange) ?? 0;

            if (dto.Quantity > onHand)
                throw new InvalidOperationException(
                    $"Insufficient stock. On-hand: {onHand}, requested: {dto.Quantity}.");

            var lastCost = await _db.StockMovements
                .Where(m => m.ProductID == product.ProductID && m.MovementType == "IN")
                .OrderByDescending(m => m.ChangeDate)
                .Select(m => (decimal?)m.CostPrice)
                .FirstOrDefaultAsync() ?? 0;

            var movement = new StockMovement
            {
                MovementID = Guid.NewGuid().ToString(),
                MovementType = "OUT",
                UnitChange = -dto.Quantity,           
                CostPrice = lastCost,
                SoldPrice = dto.SoldPrice,
                Reference = dto.Reference,
                ChangeDate = DateTime.UtcNow,
                ProductID = product.ProductID
            };

            _db.StockMovements.Add(movement);
            await _db.SaveChangesAsync();

            return ToDto(movement, product);
        }

        private static StockMovementDto ToDto(StockMovement m, Product p) => new()
        {
            MovementID = m.MovementID,
            MovementType = m.MovementType,
            ProductID = m.ProductID,
            ProductCode = p.ProductCode,
            ProductName = p.ProductName,
            UnitChange = m.UnitChange,
            CostPrice = m.CostPrice,
            SoldPrice = m.SoldPrice,
            Reference = m.Reference,
            ChangeDate = m.ChangeDate
        };
    }
}
