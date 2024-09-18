using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly PassengerService _passengerService;

        public PassengersController(PassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet("{tripId:guid}")]
        public async Task<IActionResult> GetPassengers(Guid tripId)
        {
            var passengers = await _passengerService.GetPassengers(tripId);
            if (passengers == null) return NotFound();

            return Ok(passengers);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassengers(List<PassengerDto> passengersDto)
        {
            var result = await _passengerService.AddPassengersAsync(passengersDto);
            if ((bool)!result) return NotFound();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePassenger(Guid id)
        {
            var result = await _passengerService.DeletePassengerAsync(id);
            if ((bool)!result) return NotFound();

            return Ok();
        }
    }
}
