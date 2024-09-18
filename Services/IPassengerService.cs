using CarpoolAPI.Models.Entities;

namespace CarpoolAPI.Services
{
    public interface IPassengerService
    {
        Task<List<Passenger>> GetPassengers(Guid tripId);
    }
}