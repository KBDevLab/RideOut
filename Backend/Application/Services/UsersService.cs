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

        public async Task<IEnumerable<UsersDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllUsersAsync();  
            return _mapper.Map<IEnumerable<UsersDto>>(users);    
        }

        public async Task<UsersDto> GetUserByIdAsync(int userId)
        {
            var user = await _repository.GetUserByIdAsync(userId);  
            return _mapper.Map<UsersDto>(user);  
        }

        public async Task<UsersDto> CreateUserAsync(UsersDto userDto)
        {
            var user = _mapper.Map<Users>(userDto);  
            var createdUser = await _repository.CreateUserAsync(user);  
            return _mapper.Map<UsersDto>(createdUser);  
        }

        public async Task<UsersDto> UpdateUserAsync(UsersDto userDto)
        {
            var user = _mapper.Map<Users>(userDto);  
            await _repository.UpdateUserAsync(user);  

            return _mapper.Map<UsersDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _repository.DeleteUserAsync(userId); 
        }
    }
}