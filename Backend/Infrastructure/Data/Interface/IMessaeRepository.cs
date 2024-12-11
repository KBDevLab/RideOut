using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Infrastructure.Data.Interface
{
    public interface IMessagesRepository
    {
        Task<Messages> CreateMessageAsync(Messages participant);
        Task<IEnumerable<Messages>> GetAllMessages();
        Task<Messages> GetMessageByIdAsync(int participantId);
        Task<Messages> UpdateMessageAsync(int participantId, Messages participant);
        Task<bool> DeleteMessageAsync(int participantId);
    }
}
