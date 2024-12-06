using Microsoft.AspNetCore.Mvc;
using Rideout.Application.DTOs;
using Rideout.Application.Interface;
using Rideout.Infrastructure.Data.Interface; 
using Rideout.Domain.Models;

namespace Rideout.API.Controllers
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
        public async Task<IActionResult> AddParticipant(ParticipantsDto participantDTO)
        {
            var createdParticipant = await _participantService.AddAsync(participantDTO);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(int id, [FromBody] ParticipantsDto participant)
        {
            var updatedParticipant = await _participantService.UpdateParticipantAsync(id, participant);
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
