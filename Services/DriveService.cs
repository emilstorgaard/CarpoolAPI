using CarpoolAPI.Data;
using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Services
{
    public class DriveService : IDriveService
    {
        public readonly ApplicationDbContext _dbContext;

        public DriveService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Drive>> GetDrives()
        {
            return await _dbContext.Drives.ToListAsync();
        }

        public async Task<Drive?> GetDrive(Guid id)
        {
            return await _dbContext.Drives.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool?> AddDriveAsync(DriveDto driveDto)
        {
            if (driveDto == null) return null;

            var drive = new Drive
            {
                DriverId = driveDto.DriverId,
                Distance = driveDto.Distance,
                Date = driveDto.Date,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.Drives.AddAsync(drive);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateDrive(Guid id, DriveDto driveDto)
        {
            var drive = await _dbContext.Drives.FirstOrDefaultAsync(d => d.Id == id);
            if (drive == null) return null;

            drive.DriverId = driveDto.DriverId;
            drive.Distance = driveDto.Distance;
            drive.Date = driveDto.Date;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> DeleteDriveAsync(Guid id)
        {
            var drive = await _dbContext.Drives.FirstOrDefaultAsync(u => u.Id == id);
            if (drive == null) return null;

            _dbContext.Drives.Remove(drive);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
