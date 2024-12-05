using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Config;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Infrastructure.Data.Repositories
{
public class RideoutRepository : IRideoutRepository
{
    private readonly RideOutDbContext _context;

    public RideoutRepository(RideOutDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Rideouts>> GetAllRideOutsAsync()
    {
        return await _context.Rideouts.ToListAsync();
    }

    public async Task<Rideouts> GetRideOutByIdAsync(int rideOutId)
    {
        return await _context.Rideouts.FindAsync(rideOutId);
    }

    public async Task AddRideOutAsync(Rideouts rideOut)
    {
        _context.Rideouts.Add(rideOut);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRideOutAsync(Rideouts rideOut)
    {
        _context.Entry(rideOut).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteRideoutAsync(int rideOutId)
    {
        var rideOut = await _context.Rideouts.FindAsync(rideOutId);
        if (rideOut == null) return false;

        _context.Rideouts.Remove(rideOut);
        await _context.SaveChangesAsync();
        return true;
    }
}
}