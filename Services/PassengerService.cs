using CarpoolAPI.Data;
using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Services
{
    public class PassengerService : IPassengerService
    {
        public readonly ApplicationDbContext _dbContext;

        public PassengerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Passenger>> GetPassengers(Guid tripId)
        {
            return await _dbContext.Passengers.Where(p => p.TripId == tripId).ToListAsync();
        }

        public async Task<bool?> AddPassengersAsync(List<PassengerDto> passengersDto)
        {
            if (passengersDto == null) return null;

            foreach (var passengerDto in passengersDto)
            {
                var trip = await _dbContext.Trips.FindAsync(passengerDto.TripId);
                if (trip == null) return false;

                if (passengerDto.UserId == trip.UserId) continue;

                var passenger = new Passenger
                {
                    UserId = passengerDto.UserId,
                    TripId = passengerDto.TripId
                };

                await _dbContext.Passengers.AddAsync(passenger);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> DeletePassengerAsync(Guid id)
        {
            var passenger = await _dbContext.Passengers.FirstOrDefaultAsync(p => p.Id == id);
            if (passenger == null) return null;

            _dbContext.Passengers.Remove(passenger);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
