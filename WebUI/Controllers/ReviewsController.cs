using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideOut.Data;
using RideOut.Models;

namespace RideOut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext ctx;

        public ReviewsController(ApplicationDbctx ctx)
        {
            _ctx = ctx;
        }

        // GET: api/Reviews/{rideOutId}
        [HttpGet("{rideOutId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByRideOut(int rideOutId)
        {
            var reviews = await _ctx.Reviews
                                        .Where(r => r.RideOutID == rideOutId)
                                        .Include(r => r.User)
                                        .ToListAsync();

            if (reviews == null || reviews.Count == 0)
            {
                return NotFound(new { message = "No reviews found for this RideOut." });
            }

            return Ok(reviews);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            // Validation: Ensure rating is between 1 and 5
            if (review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest(new { message = "Rating must be between 1 and 5." });
            }

            // Add the review to the database
            review.ReviewedAt = DateTime.UtcNow;
            _ctx.Reviews.Add(review);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewsByRideOut), new { rideOutId = review.RideOutID }, review);
        }

        // PUT: api/Reviews/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ReviewID)
            {
                return BadRequest(new { message = "Review ID mismatch." });
            }

            // Validation: Ensure rating is between 1 and 5
            if (review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest(new { message = "Rating must be between 1 and 5." });
            }

            _ctx.Entry(review).State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_ctx.Reviews.Any(e => e.ReviewID == id))
                {
                    return NotFound(new { message = "Review not found." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Reviews/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _ctx.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound(new { message = "Review not found." });
            }

            _ctx.Reviews.Remove(review);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
