using RideOut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideOut.Domain.Interface
{
    public interface IMessageService
    {
        Task<IEnumerable<Messages>> GetMessagesByRideOutIdAsync(int rideOutId);
        Task<Messages> GetMessageByIdAsync(int messageId);
        Task<Messages> AddMessageAsync(Messages message);
        Task<bool> DeleteMessageAsync(int messageId);
        Task<bool> UpdateMessageAsync(Messages message);
    }
}
