using Rideout.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Application.Interface
{
    public interface IMessagesService
    {
        Task<MessagesDto> GetMessageByIdAsync(int messageId);
        Task<MessagesDto> CreateMessageAsync(MessagesDto message);
        Task<MessagesDto> UpdateMessageAsync(int messageId, MessagesDto message);
        Task<bool> DeleteMessageAsync(int messageId);
        
    }
}
