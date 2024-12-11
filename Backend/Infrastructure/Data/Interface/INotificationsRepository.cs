using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Infrastructure.Data.Interface
{
    public interface INotificationsRepository
    {
        Task<Notifications> CreateNotificationAsync(Notifications notification);
        Task<IEnumerable<Notifications>> GetAllNotifications();
        //Task<IEnumerable<Notifications>> GetNotificationsByUserIdAsync(int userId);
        Task<Notifications> GetNotificationByIdAsync(int notificationId);
        Task<Notifications> UpdateNotificationAsync(Notifications notification);
        Task<bool> DeleteNotificationAsync(int notificationId);
    }
}
