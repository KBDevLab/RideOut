using Rideout.Application.DTOs;
using Rideout.Domain.Models;
using System.Collections.Generic;

namespace Rideout.Application.Mappers
{
    public static class UsersMapper
    {
        public static UsersDTO ToUsersDTO(Users user)
        {
            return new UsersDTO
            {
                UserID = user.Userid,
                Name = user.Name,
                Email = user.Email,
                Location = user.Location,
                ProfilePicture = user.Profilepicture,
                Bio = user.Bio,
                CreatedAt = user.Createdat,
                UpdatedAt = user.Updatedat
            };
        }

        public static List<UsersDTO> ToUsersDTOList(IEnumerable<Users> users)
        {
            var UsersDTOs = new List<UsersDTO>();
            foreach (var user in users)
            {
                UsersDTOs.Add(ToUsersDTO(user));
            }
            return UsersDTOs;
        }

        public static Users ToUserEntity(UsersDTO UsersDTO)
        {
            return new Users
            {
                Userid = UsersDTO.UserID,
                Name = UsersDTO.Name,
                Email = UsersDTO.Email,
                Location = UsersDTO.Location,
                Profilepicture = UsersDTO.ProfilePicture,
                Bio = UsersDTO.Bio,
                Createdat = UsersDTO.CreatedAt,
                Updatedat = UsersDTO.UpdatedAt
            };
        }
    }
}

