using Rideout.Application.Interface;
using Rideout.Application.DTOs;
using Rideout.Application.Mappers;
using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Interface;
using AutoMapper;

namespace Rideout.Application.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository _repository;
        private readonly IMapper _mapper;
        public MessagesService(IMessagesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MessagesDto> CreateMessageAsync(MessagesDto messageDTO)
        {
            var message = _mapper.Map<Messages>(messageDTO);  
            var createdMessage = await _repository.CreateMessageAsync(message);  
            return _mapper.Map<MessagesDto>(createdMessage); 
        }

        public async Task<MessagesDto> GetMessageByIdAsync(int messageId)
        {
            var message = await _repository.GetMessageByIdAsync(messageId);

            return _mapper.Map<MessagesDto>(message);
        }


        public async Task<MessagesDto> UpdateMessageAsync(int messageId, MessagesDto message)
        {
 
                var currentMessage = await _repository.GetMessageByIdAsync(messageId);
                _mapper.Map(message, currentMessage);
                _repository.UpdateMessageAsync(messageId, currentMessage);
                
                return message;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            return await _repository.DeleteMessageAsync(messageId);
        }
    }
}
