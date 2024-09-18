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

        [HttpGet("User/{id:guid}")]
        public async Task<IActionResult> GetÚserStats(Guid id)
        {
            var userStats = await _statService.GetUserStatsAsync(id);
            if (userStats == null) return NotFound();

            return Ok(userStats);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsersStats()
        {
            var usersStats = await _statService.GetUsersStatsAsync();
            if (usersStats == null) return NotFound();

            return Ok(usersStats);
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
