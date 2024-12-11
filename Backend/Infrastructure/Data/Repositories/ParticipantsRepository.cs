using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Infrastructure.Repositories
{
    public class ParticipantsRepository : IParticipantsRepository
    {
        private readonly RideOutDbContext _ctx;

        public ParticipantsRepository(RideOutDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Participants> AddAsync(Participants participant)
        {
            _ctx.Participants.Add(participant);
            await _ctx.SaveChangesAsync();
            return participant;
        }

        public async Task<Participants> GetByIdAsync(int participantId)
        {
            return await _ctx.Participants
                .Include(p => p.Rideout)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Participantid == participantId);
        }

        public async Task<IEnumerable<Participants>> GetParticipantsByRideOutIdAsync(int rideOutId)
        {
            return await _ctx.Participants
                .Where(p => p.Rideoutid == rideOutId)
                .ToListAsync();
        }

        public async Task<Participants> UpdateParticipantAsync(int participantId, Participants participant)
        {
            _ctx.Participants.Update(participant);
            await _ctx.SaveChangesAsync();
            return participant;
        }

        public async Task<bool> DeleteAsync(int participantId)
        {
            var participant = await GetByIdAsync(participantId);
            if (participant != null)
            {
                _ctx.Participants.Remove(participant);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
