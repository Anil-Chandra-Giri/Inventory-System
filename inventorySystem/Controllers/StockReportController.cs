using inventorySystem.Dtos.StockReport;
using inventorySystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Staff")]
    public class StockReportController : Controller
    {
        private readonly IStockReport _sr;
        public StockReportController(IStockReport sr)
        {
            _sr = sr;
        }

        [HttpGet("AllStocksReport")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var report =await _sr.AllStockReport();
                if (report == null)
                {
                    return NotFound("No product found");
                }

                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
           
        }

        [HttpGet("StockReport")]

        public async Task<IActionResult> GetReport(string productcode)
        {
            try
            {
                var report = await _sr.StockReport(productcode);
                if (report == null)
                {
                    return NotFound("No product found");
                }

                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

