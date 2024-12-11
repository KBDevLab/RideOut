using Rideout.Application.DTOs;
using Rideout.Domain.Models;
using System.Collections.Generic;
using AutoMapper;

namespace  Rideout.Application.Mapper
{
public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<Users, UsersDto>();
        CreateMap<UsersDto, Users>()
            .ForMember(dest => dest.Createdat, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Updatedat, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
}

