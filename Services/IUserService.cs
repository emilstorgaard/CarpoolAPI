using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Models.Entities;

namespace CarpoolAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUser(Guid id);
        Task<bool?> AddUserAsync(UserDto userDto);
        Task<bool?> UpdateUser(Guid id, UserDto userDto);
        Task<bool?> DeleteUserAsync(Guid id);
    }
}