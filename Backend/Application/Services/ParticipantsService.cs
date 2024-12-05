using Rideout.Application.Interface;
using Rideout.Application.DTOs;
using Rideout.Application.Mappers;
using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Application.Services
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly IParticipantsRepository _participantRepository;

        public ParticipantsService(IParticipantsRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<ParticipantsDTO> AddParticipantAsync(ParticipantsDTO participantDTO)
        {
            var participantEntity = ParticipantMapper.ToEntity(participantDTO);
            var addedParticipant = await _participantRepository.AddAsync(participantEntity);
            return ParticipantMapper.ToDTO(addedParticipant);
        }

        public async Task<ParticipantsDTO> GetParticipantByIdAsync(int participantId)
        {
            var participant = await _participantRepository.GetByIdAsync(participantId);
            return participant == null ? null : ParticipantMapper.ToDTO(participant);
        }

        public async Task<IEnumerable<ParticipantsDTO>> GetParticipantsByRideOutIdAsync(int rideOutId)
        {
            var participants = await _participantRepository.GetParticipantsByRideOutIdAsync(rideOutId);
            return participants.Select(ParticipantMapper.ToDTO);
        }

        public async Task<ParticipantsDTO> UpdateParticipantStatusAsync(int participantId, string status)
        {
            var participant = await _participantRepository.GetByIdAsync(participantId);
            if (participant != null)
            {
                participant.Status = status;
                var updatedParticipant = await _participantRepository.UpdateAsync(participant);
                return ParticipantMapper.ToDTO(updatedParticipant);
            }
            return null;
        }

        public async Task<bool> RemoveParticipantAsync(int participantId)
        {
            return await _participantRepository.DeleteAsync(participantId);
        }
    }
}
