using Rideout.Application.DTOs;


namespace Rideout.Application.Interface
{

    public interface IReviewsService
    {
        Task<ReviewsDto> GetReviewByIdAsync(int reviewId);
        Task<ReviewsDto> CreateReviewAsync(ReviewsDto review);
        Task<ReviewsDto> UpdateReviewAsync(int reviewId,ReviewsDto review);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}