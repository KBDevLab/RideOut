using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rideout.Domain.Models;
using Rideout.Domain.Interface;
using Rideout.Infrastructure.Data.Config;
using Rideout.Infrastructure.Data.Interface;

namespace Rideout.Infrastructure.Data.Repositories
{
public class ReviewsRepository : IReviewsRepository
{
    private readonly RideOutDbContext _context;

    public ReviewsRepository(RideOutDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Reviews> GetReviewByIdAsync(int reviewId)
    {
        
        return await _context.Reviews.FindAsync(reviewId);
    }

    public async Task<Reviews> CreateReviewAsync(Reviews review)
    {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
    }

    public async Task<Reviews> UpdateReviewAsync(int reviewId, Reviews review)
    {
        _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return review;
    }

    public async Task<bool> DeleteReviewAsync(int reviewId)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null) return false;

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return true;
    }
}
}