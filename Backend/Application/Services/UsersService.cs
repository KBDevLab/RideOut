using Rideout.Application.DTOs;
using Rideout.Application.Interface;
using Rideout.Domain.Models;
using Rideout.Infrastructure.Data.Interface;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rideout.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;  
        private readonly IMapper _mapper;              

        public UsersService(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsersDTO>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllUsersAsync();  
            return _mapper.Map<IEnumerable<UsersDTO>>(users);    
        }

        public async Task<UsersDTO> GetUserByIdAsync(int userId)
        {
            var user = await _repository.GetUserByIdAsync(userId);  
            return _mapper.Map<UsersDTO>(user);  
        }

        public async Task<UsersDTO> CreateUserAsync(UsersDTO userDto)
        {
            var user = _mapper.Map<Users>(userDto);  
            var createdUser = await _repository.CreateUserAsync(user);  
            return _mapper.Map<UsersDTO>(createdUser);  
        }

        public async Task<UsersDTO> UpdateUserAsync(UsersDTO userDto)
        {
            var user = _mapper.Map<Users>(userDto);  
            await _repository.UpdateUserAsync(user);  

            return _mapper.Map<UsersDTO>(user);;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _repository.DeleteUserAsync(userId); 
        }
    }
}