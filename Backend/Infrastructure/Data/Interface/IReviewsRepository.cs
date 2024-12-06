using Rideout.Domain.Models;


namespace Rideout.Domain.Interface
{

    public interface IReviewsRepository
    {

        Task<Reviews> GetReviewByIdAsync(int reviewId);
        Task<Reviews> CreateReviewAsync(Reviews review);
        Task<Reviews> UpdateReviewAsync(int reviewId,Reviews review);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}