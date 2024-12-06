using Rideout.Application.DTOs;
using Rideout.Domain.Models;
using System.Collections.Generic;
using AutoMapper;

namespace  Rideout.Application.Mapper
{
public class MessagesProfile : Profile
{
    public MessagesProfile()
    {
        CreateMap<Messages, MessagesDto>();
        CreateMap<MessagesDto, Messages>();
    }
}
}

