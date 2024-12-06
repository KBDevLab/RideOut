using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rideout.Application.DTOs;

namespace Rideout.Application.Interface
{
    public interface IRideoutService
    {
        Task<IEnumerable<RideoutDto>> GetAllRideOutsAsync();
        Task<RideoutDto> GetRideOutByIdAsync(int rideOutId);
        Task<RideoutDto> CreateRideOutAsync(RideoutDto rideOutDTO);
        Task<bool> UpdateRideOutAsync(int rideOutId, RideoutDto rideOutDTO);
        Task<bool> DeleteRideOutAsync(int rideOutId);
    }
}