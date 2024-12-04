using Microsoft.AspNetCore.Mvc;
using RideOut.Application.DTOs;
using RideOut.Application.Interface;
using RideOut.Infrastructure.Data.Interface; 

namespace RideOut.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantsService _participantService;

        public ParticipantsController(IParticipantsService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipant(ParticipantsDTO participantDTO)
        {
            var createdParticipant = await _participantService.AddParticipantAsync(participantDTO);
            return CreatedAtAction(nameof(GetParticipantById), new { id = createdParticipant.ParticipantID }, createdParticipant);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }

        [HttpGet("rideout/{rideOutId}")]
        public async Task<IActionResult> GetParticipantsByRideOutId(int rideOutId)
        {
            var participants = await _participantService.GetParticipantsByRideOutIdAsync(rideOutId);
            return Ok(participants);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipantStatus(int id, [FromBody] string status)
        {
            var updatedParticipant = await _participantService.UpdateParticipantStatusAsync(id, status);
            if (updatedParticipant == null)
            {
                return NotFound();
            }
            return Ok(updatedParticipant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveParticipant(int id)
        {
            var success = await _participantService.RemoveParticipantAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
