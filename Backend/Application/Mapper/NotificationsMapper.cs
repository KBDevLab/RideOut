using Rideout.Application.DTOs;
using Rideout.Domain.Models;
using System.Collections.Generic;
using AutoMapper;

namespace  Rideout.Application.Mapper
{
public class NotificationsProfile : Profile
{
    public NotificationsProfile()
    {
        CreateMap<Notifications, NotificationsDto>();
        CreateMap<NotificationsDto, Notifications>();
    }
}
}

