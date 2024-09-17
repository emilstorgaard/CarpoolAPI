using CarpoolAPI.Data;
using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Services
{
    public class DriverService : IDriverService
    {
        public readonly ApplicationDbContext _dbContext;

        public DriverService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Driver>> GetDrivers()
        {
            return await _dbContext.Drivers.ToListAsync();
        }

        public async Task<Driver?> GetDriver(Guid id)
        {
            return await _dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool?> AddDriverAsync(DriverDto driverDto)
        {
            if (driverDto == null) return null;

            var driver = new Driver
            {
                Name = driverDto.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.Drivers.AddAsync(driver);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateDriver(Guid id,DriverDto driverDto)
        {
            var driver = await _dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            if (driver == null) return null;

            driver.Name = driverDto.Name;
            driver.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> DeleteDriverAsync(Guid id)
        {
            var driver = await _dbContext.Drivers.FirstOrDefaultAsync(u => u.Id == id);
            if (driver == null) return null;

            _dbContext.Drivers.Remove(driver);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
