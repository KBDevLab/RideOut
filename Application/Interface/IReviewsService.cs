using RideOut.Domain.Models;


namespace RideOut.Domain.Interface
{

    public interface IReviewService
    {
        Task<IEnumerable<Reviews>> GetReviewsByRideOutIdAsync(int rideOutId);
        Task<Reviews> GetReviewByIdAsync(int reviewId);
        Task<Reviews> AddReviewAsync(Reviews review);
        Task<Reviews> UpdateReviewAsync(Reviews review);
        Task DeleteReviewAsync(int reviewId);
    }
}