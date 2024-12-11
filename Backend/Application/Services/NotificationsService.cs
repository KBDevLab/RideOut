using Rideout.Application.Interface;
using Rideout.Application.DTOs;
using Rideout.Domain.Models; // Ensure this namespace includes the `Notifications` domain model
using Rideout.Domain.Interface;
using Rideout.Infrastructure.Data.Interface;
using AutoMapper;

namespace Rideout.Application.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly INotificationsRepository _repository;
        private readonly IMapper _mapper;

        public NotificationsService(INotificationsRepository notificationRepository, IMapper mapper)
        {
            _repository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<NotificationsDto> CreateNotificationAsync(NotificationsDto notificationDto)
        {
            var notification = _mapper.Map<Notifications>(notificationDto);  
            var createdNotification = await _repository.CreateNotificationAsync(notification);  
            return _mapper.Map<NotificationsDto>(createdNotification); 
        }

        public async Task<NotificationsDto> GetNotificationByIdAsync(int notificationId)
        {
            var notification = await _repository.GetNotificationByIdAsync(notificationId);
            if (notification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationId} not found.");

            return _mapper.Map<NotificationsDto>(notification);
        }

        // public async Task<IEnumerable<NotificationsDto>> GetNotificationsByUserIdAsync(int userId)
        // {
        //     var notifications = await _repository.GetNotificationByUserIdAsync(userId);  
        //     return _mapper.Map<IEnumerable<NotificationsDto>>(notifications);
        // }

        public async Task<NotificationsDto> UpdateNotificationAsync(int notificationId, NotificationsDto notificationDto)
        {
            var existingNotification = await _repository.GetNotificationByIdAsync(notificationId);
            if (existingNotification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationId} not found.");

            _mapper.Map(notificationDto, existingNotification);  
            var updatedNotification = await _repository.UpdateNotificationAsync(existingNotification);
            return _mapper.Map<NotificationsDto>(updatedNotification);
        }

        public async Task<bool> DeleteNotificationAsync(int notificationId)
        {
            var notification = await _repository.GetNotificationByIdAsync(notificationId);
            if (notification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationId} not found.");

            return await _repository.DeleteNotificationAsync(notificationId);
        }
    }
}