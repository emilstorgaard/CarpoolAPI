using CarpoolAPI.Data;
using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Services
{
    public class TripService : ITripService
    {
        public readonly ApplicationDbContext _dbContext;

        public TripService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Trip>> GetTrips()
        {
            return await _dbContext.Trips.ToListAsync();
        }

        public async Task<Trip?> GetTrip(Guid id)
        {
            return await _dbContext.Trips.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool?> AddTripAsync(TripDto tripDto)
        {
            if (tripDto == null) return null;

            var trip = new Trip
            {
                UserId = tripDto.UserId,
                Distance = tripDto.Distance,
                IsCarpool = tripDto.IsCarpool,
                StartDate = tripDto.StartDate,
                StopDate = tripDto.StopDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.Trips.AddAsync(trip);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateTrip(Guid id, TripDto tripDto)
        {
            var trip = await _dbContext.Trips.FirstOrDefaultAsync(t => t.Id == id);
            if (trip == null) return null;

            trip.UserId = tripDto.UserId;
            trip.Distance = tripDto.Distance;
            trip.StartDate = tripDto.StartDate;
            trip.StopDate = tripDto.StopDate;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> DeleteTripAsync(Guid id)
        {
            var trip = await _dbContext.Trips.FirstOrDefaultAsync(t => t.Id == id);
            if (trip == null) return null;

            _dbContext.Trips.Remove(trip);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
