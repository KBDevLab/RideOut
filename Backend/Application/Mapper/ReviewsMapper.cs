using Rideout.Application.DTOs;
using Rideout.Domain.Models;
using System.Collections.Generic;
using AutoMapper;

namespace  Rideout.Application.Mapper
{
public class ReviewsProfile : Profile
{
    public ReviewsProfile()
    {
        CreateMap<Reviews, ReviewsDto>();
        CreateMap<ReviewsDto, Reviews>();
    }
}
}

