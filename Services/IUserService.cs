using CarpoolAPI.Models.Dtos;

namespace CarpoolAPI.Services
{
    public interface IUserService
    {
        Task<bool?> AddUserAsync(UserDto userDto);
        Task<bool?> DeleteUserAsync(Guid id);
    }
}