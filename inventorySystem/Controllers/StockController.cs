using inventorySystem.Dtos.Stock;
using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
        [ApiController]
        [Route("api/stock")]
        public class StockController : ControllerBase
        {
            private readonly IStockService _svc;

            public StockController(IStockService svc) => _svc = svc;

            [HttpPost("in")]
            public async Task<ActionResult<StockMovementDto>> StockIn(StockInDto dto)
            {
                try
                {
                    var result = await _svc.StockIn(dto);
                    return Ok(result);
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(new { error = ex.Message });
                }
            }

            [HttpPost("out")]
            public async Task<ActionResult<StockMovementDto>> StockOut(StockOutDto dto)
            {
                try
                {
                    var result = await _svc.StockOut(dto);
                    return Ok(result);
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(new { error = ex.Message });
                }
            }

        }
}
