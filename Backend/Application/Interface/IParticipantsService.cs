using Rideout.Application.DTOs;
using Rideout.Domain.Models;

namespace Rideout.Application.Interface

{
    public interface IParticipantsService
    {
        Task<ParticipantsDto> AddAsync(ParticipantsDto participantDTO);
        Task<ParticipantsDto> GetParticipantByIdAsync(int participantId);
        Task<ParticipantsDto> UpdateParticipantAsync(int participantId, ParticipantsDto participant);
        Task<bool> RemoveParticipantAsync(int participantId);
    }
}
