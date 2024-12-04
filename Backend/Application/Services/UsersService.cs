using RideOut.Application.DTOs;
using RideOut.Application.Interface;
using RideOut.Domain.Models;
using RideOut.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using RideOut.Application.Mappers;
using RideOut.Infrastructure.Data.Interface;

namespace RideOut.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;

        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UsersDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var UsersDTOs = UsersMapper.ToUsersDTOList(users);
            return UsersDTOs;
        }

        public async Task<UsersDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;
            return UsersMapper.ToUsersDTO(user);
        }

        public async Task<UsersDTO> CreateUserAsync(UsersDTO UsersDTO)
        {
            var user = UsersMapper.ToUserEntity(UsersDTO);
            var createdUser = await _userRepository.AddAsync(user);
            return UsersMapper.ToUsersDTO(createdUser);
        }

        public async Task<UsersDTO> UpdateUserAsync(UsersDTO UsersDTO)
        {
            var user = UsersMapper.ToUserEntity(UsersDTO);
            var updatedUser = await _userRepository.UpdateAsync(user);
            return UsersMapper.ToUsersDTO(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var isDeleted = await _userRepository.DeleteAsync(userId);
            return isDeleted;
        }
    }
}
