using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Infrastructure.Repositories
{
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly RideOutDbContext _ctx;

        public NotificationsRepository(RideOutDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Notifications>> GetAllNotifications()
        {
            return await _ctx.Notifications.ToListAsync(); 
        }

        public async Task<Notifications> CreateNotificationAsync(Notifications _notifications)
        {
            _ctx.Notifications.Add(_notifications);
            await _ctx.SaveChangesAsync();
            return _notifications;
        }

        public async Task<Notifications> GetNotificationByIdAsync(int _notificationsId)
        {
            return await _ctx.Notifications.FindAsync(_notificationsId);
        }

        public async Task<Notifications> UpdateNotificationAsync(Notifications _notifications)
        {
            _ctx.Notifications.Update(_notifications);
            await _ctx.SaveChangesAsync();
            return _notifications;
        }

        public async Task<bool> DeleteNotificationAsync(int _notificationsId)
        {
            var _notifications = await _ctx.Notifications.FindAsync(_notificationsId);
            if (_notifications != null)
            {
                _ctx.Notifications.Remove(_notifications);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
