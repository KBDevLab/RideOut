using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideOut.Models;
using RideOut.Data;  // Replace with your actual namespace for Dbctx
using System.Threading.Tasks;
using System.Linq;

namespace RideOut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RideOutDbContext _ctx;  // Your Dbctx class

        public UsersController(YourDbctx ctx)
        {
            _ctx = ctx;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _ctx.Users.ToListAsync();
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _ctx.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // Basic validation (can be extended as needed)
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
            {
                return BadRequest("Name and Email are required.");
            }

            // Add user to DB
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            _ctx.Entry(user).State = EntityState.Modified;

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _ctx.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if a user exists
        private bool UserExists(int id)
        {
            return _ctx.Users.Any(e => e.UserID == id);
        }
    }
}
