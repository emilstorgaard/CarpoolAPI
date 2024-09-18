using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly TripService _tripService;

        public TripsController(TripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripService.GetTrips();
            if (trips == null) return NotFound();

            return Ok(trips);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTrip(Guid id)
        {
            var trip = await _tripService.GetTrip(id);
            if (trip == null) return NotFound();

            return Ok(trip);
        }

        [HttpGet("User/{userId:guid}")]
        public async Task<IActionResult> GetTripsByUserId(Guid userId)
        {
            var trip = await _tripService.GetTripsByUser(userId);
            if (trip == null) return NotFound();

            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrip(TripDto tripDto)
        {
            var result = await _tripService.AddTripAsync(tripDto);
            if ((bool)!result) return NotFound();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTrip(Guid id, TripDto tripDto)
        {
            var result = await _tripService.UpdateTrip(id, tripDto);
            if (result == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTrip(Guid id)
        {
            var result = await _tripService.DeleteTripAsync(id);
            if ((bool)!result) return NotFound();

            return Ok();
        }
    }
}
