using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideOut.Models;
using RideOut.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RideOut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly RideOutDbContext _ctx;

        public MessagesController(AppDbctx ctx)
        {
            _ctx = ctx;
        }

        // Get all messages for a specific ride-out
        [HttpGet("{rideOutId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(int rideOutId)
        {
            var messages = await _ctx.Messages
                .Where(m => m.RideOutID == rideOutId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();

            if (messages == null || !messages.Any())
            {
                return NotFound("No messages found for this ride-out.");
            }

            return Ok(messages);
        }

        // Get a specific message by its ID
        [HttpGet("message/{messageId}")]
        public async Task<ActionResult<Message>> GetMessage(int messageId)
        {
            var message = await _ctx.Messages
                .Include(m => m.SenderUser)  // Including sender user details (optional)
                .FirstOrDefaultAsync(m => m.MessageID == messageId);

            if (message == null)
            {
                return NotFound("Message not found.");
            }

            return Ok(message);
        }

        // Post a new message to a ride-out
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage([FromBody] Message message)
        {
            if (message == null)
            {
                return BadRequest("Message data is required.");
            }

            // You might want to validate if the user sending the message is authorized to post (e.g., if they are part of the ride-out)
            var rideOut = await _ctx.RideOuts.FindAsync(message.RideOutID);
            if (rideOut == null)
            {
                return NotFound("Ride-out not found.");
            }

            // Setting the SenderUserID to the logged-in user's ID (this should come from your authentication system)
            // For simplicity, using a placeholder user ID. Replace this with actual logic.
            message.SenderUserID = 1;  // Placeholder for current user's ID

            message.SentAt = DateTime.UtcNow;
            _ctx.Messages.Add(message);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessage), new { messageId = message.MessageID }, message);
        }

        // Delete a message
        [HttpDelete("message/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var message = await _ctx.Messages.FindAsync(messageId);
            if (message == null)
            {
                return NotFound("Message not found.");
            }

            _ctx.Messages.Remove(message);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        // Optional: Mark a message as read/unread (if you want to track this)
        [HttpPut("mark-read/{messageId}")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId)
        {
            var message = await _ctx.Messages.FindAsync(messageId);
            if (message == null)
            {
                return NotFound("Message not found.");
            }

            message.IsRead = true;
            _ctx.Messages.Update(message);
            await _ctx.SaveChangesAsync();

            return Ok(message);
        }
    }
}
