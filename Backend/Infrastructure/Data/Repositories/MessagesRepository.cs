using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Infrastructure.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly RideOutDbContext _ctx;

        public MessagesRepository(RideOutDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Messages>> GetAllMessages()
        {
            return await _ctx.Messages.ToListAsync(); 
        }

        public async Task<Messages> CreateMessageAsync(Messages _messages)
        {
            _ctx.Messages.Add(_messages);
            await _ctx.SaveChangesAsync();
            return _messages;
        }

        public async Task<Messages> GetMessageByIdAsync(int _messagesId)
        {
            return await _ctx.Messages.FindAsync(_messagesId);
        }

        public async Task<Messages> UpdateMessageAsync(int _messagesId, Messages _messages)
        {
            _ctx.Messages.Update(_messages);
            await _ctx.SaveChangesAsync();
            return _messages;
        }

        public async Task<bool> DeleteMessageAsync(int _messagesId)
        {
            var _messages = await _ctx.Messages.FindAsync(_messagesId);
            if (_messages != null)
            {
                _ctx.Messages.Remove(_messages);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
