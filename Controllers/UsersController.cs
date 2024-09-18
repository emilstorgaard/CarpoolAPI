using CarpoolAPI.Models.Dtos;
using CarpoolAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            if (users == null) return NotFound();

            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            var result = await _userService.AddUserAsync(userDto);
            if ((bool)!result) return NotFound();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserDto userDto)
        {
            var result = await _userService.UpdateUser(id, userDto);
            if (result == null) return NotFound();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if ((bool)!result) return NotFound();

            return Ok();
        }
    }
}
