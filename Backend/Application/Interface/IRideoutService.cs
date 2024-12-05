using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rideout.Application.DTOs;

namespace Rideout.Application.Interface
{
    public interface IRideoutService
    {
        Task<IEnumerable<RideOutDTO>> GetAllRideOutsAsync();
        Task<RideOutDTO> GetRideOutByIdAsync(int rideOutId);
        Task<RideOutDTO> CreateRideOutAsync(RideOutDTO rideOutDTO);
        Task<bool> UpdateRideOutAsync(int rideOutId, RideOutDTO rideOutDTO);
        Task<bool> DeleteRideOutAsync(int rideOutId);
    }
}