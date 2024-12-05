using Rideout.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Application.Interface
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersDTO>> GetAllUsersAsync();
        Task<UsersDTO> GetUserByIdAsync(int userId);
        Task<UsersDTO> CreateUserAsync(UsersDTO UsersDTO);
        Task<UsersDTO> UpdateUserAsync(UsersDTO UsersDTO);
        Task<bool> DeleteUserAsync(int userId);
    }
}
