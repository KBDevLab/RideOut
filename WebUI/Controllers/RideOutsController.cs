using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideOut.Data;  
using RideOut.Models; 
using System.Threading.Tasks;

namespace RideOut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideOutsController : ControllerBase
    {
        private readonly RideOutDbContext _ctx;  // Assuming RideOutDbctx is your database ctx

        public RideOutsController(RideOutDbctx ctx)
        {
            _ctx = ctx;
        }

        // GET: api/RideOuts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RideOut>>> GetRideOuts()
        {
            return await _ctx.RideOuts
                                 .Include(ride => ride.HostUser)  // Eager load HostUser for ride out
                                 .ToListAsync();
        }

        // GET: api/RideOuts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RideOut>> GetRideOut(int id)
        {
            var rideOut = await _ctx.RideOuts
                                         .Include(ride => ride.HostUser)  // Eager load HostUser for the ride out
                                         .FirstOrDefaultAsync(r => r.RideOutID == id);

            if (rideOut == null)
            {
                return NotFound();
            }

            return rideOut;
        }

        // POST: api/RideOuts
        [HttpPost]
        public async Task<ActionResult<RideOut>> CreateRideOut(RideOut rideOut)
        {
            // Validate the request data
            if (rideOut == null)
            {
                return BadRequest("Invalid ride out data.");
            }

            // Set creation and update timestamps
            rideOut.CreatedAt = DateTime.UtcNow;
            rideOut.UpdatedAt = DateTime.UtcNow;

            _ctx.RideOuts.Add(rideOut);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction("GetRideOut", new { id = rideOut.RideOutID }, rideOut);
        }

        // PUT: api/RideOuts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRideOut(int id, RideOut rideOut)
        {
            if (id != rideOut.RideOutID)
            {
                return BadRequest();
            }

            // Set the updated timestamp
            rideOut.UpdatedAt = DateTime.UtcNow;

            _ctx.Entry(rideOut).State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RideOutExists(id))
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

        // DELETE: api/RideOuts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRideOut(int id)
        {
            var rideOut = await _ctx.RideOuts.FindAsync(id);
            if (rideOut == null)
            {
                return NotFound();
            }

            _ctx.RideOuts.Remove(rideOut);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        private bool RideOutExists(int id)
        {
            return _ctx.RideOuts.Any(e => e.RideOutID == id);
        }
    }