using Rideout.Application.DTOs;

namespace Rideout.Application.Interface
{
    public interface INotificationsService
    {
        //Task<IEnumerable<NotificationsDto>> GetNotificationsByUserIdAsync(int userId);
        Task<NotificationsDto> GetNotificationByIdAsync(int notificationId);
        Task<NotificationsDto> CreateNotificationAsync(NotificationsDto notification);
        Task<NotificationsDto> UpdateNotificationAsync(int notificationId, NotificationsDto notificationDto);
        Task<bool> DeleteNotificationAsync(int notificationId);
    }
}
