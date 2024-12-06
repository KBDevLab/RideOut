using Rideout.Domain.Models;

namespace Rideout.Application.Interface
{
    public interface INotificationService
    {
        Task<List<Notifications>> GetNotificationsByUserIdAsync(int userId);
        Task<Notifications> GetNotificationByIdAsync(int notificationId);
        Task AddNotificationAsync(Notifications notification);
        Task MarkAsReadAsync(int notificationId);
    }
}
