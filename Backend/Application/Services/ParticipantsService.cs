using Rideout.Application.Interface;
using Rideout.Application.DTOs;
using Rideout.Application.Mappers;
using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Interface;
using AutoMapper;

namespace Rideout.Application.Services
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly IParticipantsRepository _repository;
        private readonly IMapper _mapper;
        public ParticipantsService(IParticipantsRepository participantRepository, IMapper mapper)
        {
            _repository = participantRepository;
            _mapper = mapper;
        }

        public async Task<ParticipantsDto> AddAsync(ParticipantsDto participantDTO)
        {
            var participant = _mapper.Map<Participants>(participantDTO);  
            var createdParticipant = await _repository.AddAsync(participant);  
            return _mapper.Map<ParticipantsDto>(createdParticipant); 
        }

        public async Task<ParticipantsDto> GetParticipantByIdAsync(int participantId)
        {
            var participant = await _repository.GetByIdAsync(participantId);

            return _mapper.Map<ParticipantsDto>(participant);
        }


        public async Task<ParticipantsDto> UpdateParticipantAsync(int participantId, ParticipantsDto participant)
        {

 
                var currentParticipant = await _repository.GetByIdAsync(participantId);
                _mapper.Map(participant, currentParticipant);
                _repository.UpdateParticipantAsync(participantId, currentParticipant);
                
                return participant;
        }

        public async Task<bool> RemoveParticipantAsync(int participantId)
        {
            return await _repository.DeleteAsync(participantId);
        }
    }
}
