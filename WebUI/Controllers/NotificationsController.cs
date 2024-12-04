using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideOut.Data;  // Your Dbctx namespace
using RideOut.Models; // Your Notification model namespace
using System.Linq;
using System.Threading.Tasks;

namespace RideOut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly RideOutDbContext _ctx;

        public NotificationsController(ApplicationDbctx ctx)
        {
            _ctx = ctx;
        }

        // GET: api/Notifications/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetUserNotifications(int userId)
        {
            var notifications = await _ctx.Notifications
                .Where(n => n.UserID == userId)
                .OrderByDescending(n => n.SentAt)
                .ToListAsync();

            if (notifications == null || notifications.Count == 0)
            {
                return NotFound("No notifications found for this user.");
            }

            return Ok(notifications);
        }

        // POST: api/Notifications
        [HttpPost]
        public async Task<ActionResult<Notification>> CreateNotification(Notification notification)
        {
            if (notification == null)
            {
                return BadRequest("Notification data is required.");
            }

            _ctx.Notifications.Add(notification);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction("GetUserNotifications", new { userId = notification.UserID }, notification);
        }

        // PUT: api/Notifications/mark-as-read/{notificationId}
        [HttpPut("mark-as-read/{notificationId}")]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var notification = await _ctx.Notifications.FindAsync(notificationId);

            if (notification == null)
            {
                return NotFound("Notification not found.");
            }

            notification.IsRead = true;
            _ctx.Entry(notification).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Notifications/{notificationId}
        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            var notification = await _ctx.Notifications.FindAsync(notificationId);

            if (notification == null)
            {
                return NotFound("Notification not found.");
            }

            _ctx.Notifications.Remove(notification);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
