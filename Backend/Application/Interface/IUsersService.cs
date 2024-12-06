using Rideout.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Application.Interface
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersDto>> GetAllUsersAsync();
        Task<UsersDto> GetUserByIdAsync(int userId);
        Task<UsersDto> CreateUserAsync(UsersDto UsersDto);
        Task<UsersDto> UpdateUserAsync(UsersDto UsersDto);
        Task<bool> DeleteUserAsync(int userId);
    }
}
