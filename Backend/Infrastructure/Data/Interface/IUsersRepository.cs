using Rideout.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Infrastructure.Data.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();  
        Task<Users> GetUserByIdAsync(int userId);     
        Task<Users> CreateUserAsync(Users user);       
        Task UpdateUserAsync(Users user);             
        Task<bool> DeleteUserAsync(int userId);      
    }
}