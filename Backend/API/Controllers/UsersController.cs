using Microsoft.AspNetCore.Mvc;
using Rideout.Application.Interface;
using Rideout.Application.DTOs;
using System.Threading.Tasks;

namespace Rideout.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // Get user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // Create a new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsersDTO UsersDTO)
        {
            if (UsersDTO == null)
                return BadRequest();
            var createdUser = await _userService.CreateUserAsync(UsersDTO);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserID }, createdUser);
        }

        // Update user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersDTO UsersDTO)
        {
            if (UsersDTO == null || id != UsersDTO.UserID)
                return BadRequest();
            var updatedUser = await _userService.UpdateUserAsync(UsersDTO);
            if (updatedUser == null)
                return NotFound();
            return NoContent();
        }

        // Delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isDeleted = await _userService.DeleteUserAsync(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }
    }
}
