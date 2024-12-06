using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Interface;
using Rideout.Infrastructure.Data.Config;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rideout.Infrastructure.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly RideOutDbContext _context;  

        public UsersRepository(RideOutDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync(); 
        }

        public async Task<Users> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);  
        }

        public async Task<Users> CreateUserAsync(Users user)
        {
            _context.Users.Add(user);  
            await _context.SaveChangesAsync();  
            return user;  
        }

        public async Task UpdateUserAsync(Users user)
        {
            _context.Users.Update(user);  
            await _context.SaveChangesAsync();  
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);  
            if (user == null)
                return false;  

            _context.Users.Remove(user);  
            await _context.SaveChangesAsync();  
            return true;  
        }
    }
}