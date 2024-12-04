using RideOut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideOut.Infrastructure.Data.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int userId);
        Task<Users> AddAsync(Users user);
        Task<Users> UpdateAsync(Users user);
        Task<bool> DeleteAsync(int userId);
    }
}
