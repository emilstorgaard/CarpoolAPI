using CarpoolAPI.Data;
using CarpoolAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Services
{
    public class StatService : IStatService
    {
        public readonly ApplicationDbContext _dbContext;

        public StatService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DriverStatsDto?> GetDriverStatsAsync(Guid id)
        {
            var driverStats = await _dbContext.Drives
                .Where(d => d.DriverId == id)
                .GroupBy(d => new { d.DriverId, d.Driver.Name })
                .Select(g => new DriverStatsDto
                {
                    DriverId = g.Key.DriverId,
                    DriverName = g.Key.Name,
                    TotalDrives = g.Count(),
                    TotalDistance = g.Sum(d => d.Distance)
                })
                .FirstOrDefaultAsync();

            return driverStats;
        }

        public async Task<List<DriverStatsDto>> GetDriversStatsAsync()
        {
            var driverStats = await _dbContext.Drivers
                .GroupJoin(
                    _dbContext.Drives,
                    user => user.Id,
                    drive => drive.DriverId,
                    (user, drives) => new DriverStatsDto
                    {
                        DriverId = user.Id,
                        DriverName = user.Name,
                        TotalDrives = drives.Count(),
                        TotalDistance = drives.Sum(d => d.Distance)
                    })
                .ToListAsync();

            return driverStats;
        }

        public async Task<TotalStatsDto> GetTotalStatsAsync()
        {
            var totalDrives = await _dbContext.Drives.CountAsync();
            var totalDistance = await _dbContext.Drives.SumAsync(d => d.Distance);
            var totalDrivers = await _dbContext.Drivers.CountAsync();

            var totalStats = new TotalStatsDto
            {
                TotalDrives = totalDrives,
                TotalDistance = totalDistance,
                TotalDrivers = totalDrivers
            };

            return totalStats;
        }
    }
}
