using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivesController : ControllerBase
    {
        private readonly DriveService _driveService;

        public DrivesController(DriveService driveService)
        {
            _driveService = driveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrives()
        {
            var drives = await _driveService.GetDrives();
            if (drives == null) return NotFound();

            return Ok(drives);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDrive(Guid id)
        {
            var drive = await _driveService.GetDrive(id);
            if (drive == null) return NotFound();

            return Ok(drive);
        }

        [HttpPost]
        public async Task<IActionResult> AddDrive(DriveDto driveDto)
        {
            var result = await _driveService.AddDriveAsync(driveDto);
            if ((bool)!result) return NotFound();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDrive(Guid id, DriveDto driveDto)
        {
            var result = await _driveService.UpdateDrive(id, driveDto);
            if (result == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDrive(Guid id)
        {
            var result = await _driveService.DeleteDriveAsync(id);
            if ((bool)!result) return NotFound();

            return Ok();
        }
    }
}
