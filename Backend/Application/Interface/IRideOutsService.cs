using RideOut.Domain.Models;

namespace RideOut.Domain.Interface
{
    public interface IParticipantService
    {
        Task<Participants> GetByIdAsync(int participantId);
        Task<IEnumerable<Participants>> GetByRideOutIdAsync(int rideOutId);
        Task<IEnumerable<Participants>> GetByUserIdAsync(int userId);
        Task AddAsync(Participants Participants);
        Task UpdateAsync(Participants Participants);
        Task DeleteAsync(int participantId);
        Task<bool> IsUserRegisteredForRideOutAsync(int userId, int rideOutId);
    }
}
