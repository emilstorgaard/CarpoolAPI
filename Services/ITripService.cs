using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;

namespace CarpoolAPI.Services
{
    public interface ITripService
    {
        Task<List<Trip>> GetTrips();
        Task<Trip?> GetTrip(Guid id);
        Task<bool?> AddTripAsync(TripDto tripDto);
        Task<bool?> DeleteTripAsync(Guid id);
        Task<bool?> UpdateTrip(Guid id, TripDto tripDto);
    }
}