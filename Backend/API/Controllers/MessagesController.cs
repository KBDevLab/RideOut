using Microsoft.AspNetCore.Mvc;
using Rideout.Application.DTOs;
using Rideout.Application.Interface;
using Rideout.Infrastructure.Data.Interface; 
using Rideout.Domain.Models;
using Rideout.Domain.Interface;

namespace Rideout.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _messageService;

        public MessagesController(IMessagesService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(MessagesDto messageDTO)
        {
            var createdMessages = await _messageService.CreateMessageAsync(messageDTO);
            return CreatedAtAction(nameof(GetMessageById), new { id = createdMessages.Messageid }, createdMessages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessages(int id, [FromBody] MessagesDto message)
        {
            var updatedMessages = await _messageService.UpdateMessageAsync(id, message);
            if (updatedMessages == null)
            {
                return NotFound();
            }
            return Ok(updatedMessages);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMessages(int id)
        {
            var success = await _messageService.DeleteMessageAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
