using RideOut.Domain.Models;
using RideOut.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RideOut.Infrastructure.Data.Config;
using RideOut.Infrastructure.Data.Interface;

namespace RideOut.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly RideOutDbContext _dbContext;

        public UsersRepository(RideOutDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<Users> GetByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<Users> AddAsync(Users user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateAsync(Users user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return false;
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
