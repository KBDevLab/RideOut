using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rideout.Domain.Models;
using Rideout.Application.DTOs;
using Rideout.Application.Interface;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Application.Services
{
public class RideoutService : IRideoutService
{
    private readonly IRideoutRepository _repository;
    private readonly IMapper _mapper;

    public RideoutService(IRideoutRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RideoutDto>> GetAllRideOutsAsync()
    {
        var rideOuts = await _repository.GetAllRideOutsAsync();
        return _mapper.Map<IEnumerable<RideoutDto>>(rideOuts);
    }

    public async Task<RideoutDto> GetRideOutByIdAsync(int rideOutId)
    {
        var rideOut = await _repository.GetRideOutByIdAsync(rideOutId);
        if (rideOut == null) return null; 
        return _mapper.Map<RideoutDto>(rideOut);
    }

    public async Task<RideoutDto> CreateRideOutAsync(RideoutDto rideOutCreateDTO)
    {
        var rideOut = _mapper.Map<Rideouts>(rideOutCreateDTO);
        await _repository.AddRideOutAsync(rideOut);
        return _mapper.Map<RideoutDto>(rideOut);
    }

    public async Task<bool> UpdateRideOutAsync(int rideOutId, RideoutDto rideOutDTO)
    {
        var existingRideOut = await _repository.GetRideOutByIdAsync(rideOutId);
        if (existingRideOut == null) return false;

        _mapper.Map(rideOutDTO, existingRideOut);
        await _repository.UpdateRideOutAsync(existingRideOut);
        return true;
    }

    public async Task<bool> DeleteRideOutAsync(int rideOutId)
    {
        return await _repository.DeleteRideoutAsync(rideOutId);
    }
}
}