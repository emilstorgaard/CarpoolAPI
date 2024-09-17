using CarpoolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly StatService _statService;

        public StatsController(StatService statService)
        {
            _statService = statService;
        }

        [HttpGet("Driver/{id:guid}")]
        public async Task<IActionResult> GetDriverStats(Guid id)
        {
            var driverStats = await _statService.GetDriverStatsAsync(id);
            if (driverStats == null) return NotFound();

            return Ok(driverStats);
        }

        [HttpGet("Drivers")]
        public async Task<IActionResult> GetDriversStats()
        {
            var driversStats = await _statService.GetDriversStatsAsync();
            if (driversStats == null) return NotFound();

            return Ok(driversStats);
        }

        [HttpGet("Total")]
        public async Task<IActionResult> GetTotalStats()
        {
            var totalStats = await _statService.GetTotalStatsAsync();
            if (totalStats == null) return NotFound();

            return Ok(totalStats);
        }
    }
}
