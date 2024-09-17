using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;

namespace CarpoolAPI.Services
{
    public interface IDriveService
    {
        Task<List<Drive>> GetDrives();
        Task<Drive?> GetDrive(Guid id);
        Task<bool?> AddDriveAsync(DriveDto driveDto);
        Task<bool?> DeleteDriveAsync(Guid id);
        Task<bool?> UpdateDrive(Guid id, DriveDto driveDto);
    }
}