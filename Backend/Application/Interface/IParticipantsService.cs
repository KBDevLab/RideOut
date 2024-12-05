using Rideout.Application.DTOs;

namespace Rideout.Application.Interface

{
    public interface IParticipantsService
    {
        Task<ParticipantsDTO> AddParticipantAsync(ParticipantsDTO participantDTO);
        Task<ParticipantsDTO> GetParticipantByIdAsync(int participantId);
        Task<IEnumerable<ParticipantsDTO>> GetParticipantsByRideOutIdAsync(int rideOutId);
        Task<ParticipantsDTO> UpdateParticipantStatusAsync(int participantId, string status);
        Task<bool> RemoveParticipantAsync(int participantId);
    }
}
