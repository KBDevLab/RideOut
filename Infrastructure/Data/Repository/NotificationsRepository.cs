using RideOut.Domain.Entities;
using RideOut.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RideOut.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly RideOutDbContext _ctx;

        public NotificationRepository(ApplicationDbctx ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Notification>> GetNotificationsByUserIdAsync(int userId)
        {
            return await _ctx.Notifications
                                 .Where(n => n.UserID == userId)
                                 .OrderByDescending(n => n.SentAt)
                                 .ToListAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(int notificationId)
        {
            return await _ctx.Notifications
                                 .FirstOrDefaultAsync(n => n.NotificationID == notificationId);
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _ctx.Notifications.Add(notification);
            await _ctx.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await GetNotificationByIdAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
