using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriversController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var drivers = await _driverService.GetDrivers();
            if (drivers == null) return NotFound();

            return Ok(drivers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDriver(Guid id)
        {
            var driver = await _driverService.GetDriver(id);
            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(DriverDto driverDto)
        {
            var result = await _driverService.AddDriverAsync(driverDto);
            if ((bool)!result) return NotFound();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDriver(Guid id, DriverDto driverDto)
        {
            var result = await _driverService.UpdateDriver(id, driverDto);
            if (result == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid id)
        {
            var result = await _driverService.DeleteDriverAsync(id);
            if ((bool)!result) return NotFound();

            return Ok();
        }
    }
}
