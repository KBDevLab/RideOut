using Rideout.Application.Services;
using Rideout.Application.DTOs;
using Rideout.Domain.Interface;
using Rideout.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Rideout.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RideOutsController : ControllerBase
    {
        private readonly IRideoutService _rideOutService;

        public RideOutsController(IRideoutService rideOutService)
        {
            _rideOutService = rideOutService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RideOutDTO>>> GetRideOuts()
        {
            var rideOuts = await _rideOutService.GetAllRideOutsAsync();
            return Ok(rideOuts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RideOutDTO>> GetRideOut(int id)
        {
            var rideOut = await _rideOutService.GetRideOutByIdAsync(id);
            if (rideOut == null)
            {
                return NotFound();
            }
            return Ok(rideOut);
        }

        [HttpPost]
        public async Task<ActionResult<RideOutDTO>> CreateRideOut(RideOutDTO rideOutDto)
        {
            var createdRideOut = await _rideOutService.CreateRideOutAsync(rideOutDto);
            return CreatedAtAction(nameof(GetRideOut), new { id = createdRideOut.RideOutID }, createdRideOut);
        }
    }

}