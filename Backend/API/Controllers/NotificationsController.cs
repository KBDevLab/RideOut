using Microsoft.AspNetCore.Mvc;
using Rideout.Application.DTOs;
using Rideout.Application.Interface;
using Rideout.Infrastructure.Data.Interface; 
using Rideout.Domain.Models;
using Rideout.Domain.Interface;

namespace Rideout.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _notificationService;

        public NotificationsController(INotificationsService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationAsync(NotificationsDto notificationDTO)
        {
            var createdNotifications = await _notificationService.CreateNotificationAsync(notificationDTO);
            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotifications.Notificationid }, createdNotifications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotifications(int id, [FromBody] NotificationsDto notification)
        {
            var updatedNotifications = await _notificationService.UpdateNotificationAsync(id, notification);
            if (updatedNotifications == null)
            {
                return NotFound();
            }
            return Ok(updatedNotifications);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveNotifications(int id)
        {
            var success = await _notificationService.DeleteNotificationAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
