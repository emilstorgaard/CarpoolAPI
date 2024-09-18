using CarpoolAPI.Data;
using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolAPI.Services
{
    public class UserService : IUserService
    {
        public readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUser(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool?> AddUserAsync(UserDto userDto)
        {
            if (userDto == null) return null;

            var user = new User
            {
                Name = userDto.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateUser(Guid id, UserDto userDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(d => d.Id == id);
            if (user == null) return null;

            user.Name = userDto.Name;
            user.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> DeleteUserAsync(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
