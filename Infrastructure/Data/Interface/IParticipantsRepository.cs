using RideOut.Domain.Models;

namespace RideOut.Infrastructure.Data.Interface
{
    public interface IParticipantsRepository
    {
        Task<Participants> AddAsync(Participants participant);
        Task<Participants> GetByIdAsync(int participantId);
        Task<IEnumerable<Participants>> GetParticipantsByRideOutIdAsync(int rideOutId);
        Task<Participants> UpdateAsync(Participants participant);
        Task<bool> DeleteAsync(int participantId);
    }
}
