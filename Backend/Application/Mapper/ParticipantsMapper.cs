using Rideout.Domain.Models;
using Rideout.Application.DTOs;
using AutoMapper;

namespace Rideout.Application.Mappers
{
public class ParticipantsProfile : Profile
{
    public ParticipantsProfile()
    {
        CreateMap<Participants, ParticipantsDto>();
        CreateMap<ParticipantsDto, Participants>();
    }
}
}
