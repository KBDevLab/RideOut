using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Infrastructure.Data.Interface
{
public interface IRideoutRepository
{
    Task<IEnumerable<Rideouts>> GetAllRideOutsAsync();
    Task<Rideouts> GetRideOutByIdAsync(int rideOutId);
    Task AddRideOutAsync(Rideouts rideOut);
    Task UpdateRideOutAsync(Rideouts rideOut);
    Task <bool>DeleteRideoutAsync(int rideOutId);
}
}