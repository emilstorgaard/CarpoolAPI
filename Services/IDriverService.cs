using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;

namespace CarpoolAPI.Services
{
    public interface IDriverService
    {
        Task<List<Driver>> GetDrivers();
        Task<Driver?> GetDriver(Guid id);
        Task<bool?> AddDriverAsync(DriverDto driverDto);
        Task<bool?> UpdateDriver(Guid id, DriverDto driverDto);
        Task<bool?> DeleteDriverAsync(Guid id);
    }
}