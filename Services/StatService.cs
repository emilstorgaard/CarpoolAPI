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

        public async Task<UserStatsDto?> GetUserStatsAsync(Guid id)
        {
            var userWithTrips = await _dbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    User = u,
                    Trips = _dbContext.Trips.Where(trip => trip.UserId == u.Id).ToList()
                })
                .FirstOrDefaultAsync();

            if (userWithTrips == null) return null;

            var userStats = new UserStatsDto
            {
                UserId = userWithTrips.User.Id,
                UserName = userWithTrips.User.Name,
                TotalTrips = userWithTrips.Trips.Count,
                TotalDistance = userWithTrips.Trips.Sum(trip => trip.Distance),

                TotalTime = userWithTrips.Trips.Any()
                    ? new TimeSpan(userWithTrips.Trips.Sum(trip => (trip.StopDate - trip.StartDate).Ticks))
                    : TimeSpan.Zero
            };

            return userStats;
        }

        public async Task<List<UserStatsDto>> GetUsersStatsAsync()
        {
            var usersWithTrips = await _dbContext.Users
                .Select(user => new
                {
                    User = user,
                    Trips = _dbContext.Trips.Where(trip => trip.UserId == user.Id).ToList()
                })
                .ToListAsync();

            var userStats = usersWithTrips.Select(u => new UserStatsDto
            {
                UserId = u.User.Id,
                UserName = u.User.Name,
                TotalTrips = u.Trips.Count,
                TotalDistance = u.Trips.Sum(trip => trip.Distance),

                TotalTime = u.Trips.Any()
                    ? new TimeSpan(u.Trips.Sum(trip => (trip.StopDate - trip.StartDate).Ticks))
                    : TimeSpan.Zero
            }).ToList();

            return userStats;
        }

        public async Task<TotalStatsDto> GetTotalStatsAsync()
        {
            var trips = await _dbContext.Trips.ToListAsync();

            var totalTrips = trips.Count();
            var totalDistance = trips.Sum(d => d.Distance);
            var totalUsers = await _dbContext.Users.CountAsync();

            TimeSpan totalTime = TimeSpan.Zero;
            foreach (var trip in trips)
            {
                totalTime += trip.StopDate - trip.StartDate;
            }

            var totalStats = new TotalStatsDto
            {
                TotalTrips = totalTrips,
                TotalDistance = totalDistance,
                TotalUsers = totalUsers,
                TotalTime = totalTime
            };

            return totalStats;
        }
    }
}
