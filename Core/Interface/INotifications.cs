namespace YourApp.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetNotificationsByUserIdAsync(int userId);
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task AddNotificationAsync(Notification notification);
        Task MarkAsReadAsync(int notificationId);
    }
}
