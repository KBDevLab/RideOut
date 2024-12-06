using Rideout.Domain.Models;
using Rideout.Application.DTOs;
using AutoMapper;

namespace  Rideot.Application.Mapper
{
public class RideoutProfile : Profile
{
    public RideoutProfile()
    {
        CreateMap<Rideouts, RideoutDto>();
        CreateMap<RideoutDto, Rideouts>()
            .ForMember(dest => dest.Createdat, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Updatedat, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
}