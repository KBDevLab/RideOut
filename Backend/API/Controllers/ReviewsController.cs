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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewService;

        public ReviewsController(IReviewsService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReviewAsync(ReviewsDto reviewDTO)
        {
            var createdReviews = await _reviewService.CreateReviewAsync(reviewDTO);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReviews.Reviewid }, createdReviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReviews(int id, [FromBody] ReviewsDto review)
        {
            var updatedReviews = await _reviewService.UpdateReviewAsync(id, review);
            if (updatedReviews == null)
            {
                return NotFound();
            }
            return Ok(updatedReviews);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReviews(int id)
        {
            var success = await _reviewService.DeleteReviewAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
