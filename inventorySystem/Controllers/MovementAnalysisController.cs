using inventorySystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace inventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementAnalysisController : Controller
    {
        private readonly IStockMovementService _movementService;

        public MovementAnalysisController(IStockMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet("GetAnalysis")]
        public async Task<IActionResult> GetAnalysis([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var start = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var end = endDate ?? DateTime.Now;

            if (start > end)
                return BadRequest("Start date cannot be greater than end date.");

            var analysis = await _movementService.GetMovementAnalysis(start, end);
            return Ok(analysis);
        }

        [HttpGet("Getdetails")]
        public async Task<IActionResult> GetDetails(string productCode, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var start = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var end = endDate ?? DateTime.Now;

            var details = await _movementService.GetMovementDetails(productCode, start, end);
            return Ok(details);
        }
    }

}
