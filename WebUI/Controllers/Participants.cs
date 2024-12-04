using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideOut.Data; 
using RideOut.Models; 
using System.Threading.Tasks;

namespace RideOut.Controllers
{
 [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly RideOutDbContext _ctx;

        public ParticipantsController(AppDbctx ctx)
        {
            _ctx = ctx;
        }

        // GET: api/Participants/5
        [HttpGet("{rideOutId}")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipantsForRideOut(int rideOutId)
        {
            var participants = await _ctx.Participants
                                             .Include(p => p.User)  // Eager load User data for each participant
                                             .Where(p => p.RideOutID == rideOutId)
                                             .ToListAsync();

            if (participants == null || participants.Count == 0)
            {
                return NotFound();
            }

            return participants;
        }

        // POST: api/Participants
        [HttpPost]
        public async Task<ActionResult<Participant>> CreateParticipant(Participant participant)
        {
            if (participant == null)
            {
                return BadRequest("Invalid participant data.");
            }

            // Set the joined timestamp
            participant.JoinedAt = DateTime.UtcNow;

            _ctx.Participants.Add(participant);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction("GetParticipantsForRideOut", new { rideOutId = participant.RideOutID }, participant);
        }

        // PUT: api/Participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(int id, Participant participant)
        {
            if (id != participant.ParticipantID)
            {
                return BadRequest();
            }

            _ctx.Entry(participant).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _ctx.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _ctx.Participants.Remove(participant);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
