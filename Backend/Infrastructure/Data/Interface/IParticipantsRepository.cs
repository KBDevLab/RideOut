using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Infrastructure.Data.Interface
{
    public interface IParticipantsRepository
    {
        Task<Participants> AddAsync(Participants participant);
        Task<Participants> GetByIdAsync(int participantId);
        Task<IEnumerable<Participants>> GetParticipantsByRideOutIdAsync(int rideOutId);
        Task<Participants> UpdateParticipantAsync(int participantId, Participants participant);
        Task<bool> DeleteAsync(int participantId);
    }
}
