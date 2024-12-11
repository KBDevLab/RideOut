using Rideout.Application.Interface;
using Rideout.Application.DTOs;
using Rideout.Application.Mappers;
using Rideout.Domain.Models;
using Rideout.Domain.Interface;
using Rideout.Infrastructure.Data.Interface;
using AutoMapper;

namespace Rideout.Application.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IReviewsRepository _repository;
        private readonly IMapper _mapper;
        public ReviewsService(IReviewsRepository reviewRepository, IMapper mapper)
        {
            _repository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewsDto> CreateReviewAsync(ReviewsDto reviewDTO)
        {
            var review = _mapper.Map<Reviews>(reviewDTO);  
            var createdReview = await _repository.CreateReviewAsync(review);  
            return _mapper.Map<ReviewsDto>(createdReview); 
        }

        public async Task<ReviewsDto> GetReviewByIdAsync(int reviewId)
        {
            var review = await _repository.GetReviewByIdAsync(reviewId);

            return _mapper.Map<ReviewsDto>(review);
        }




        public async Task<ReviewsDto> UpdateReviewAsync(int reviewId, ReviewsDto review)
        {

 
                var currentReview = await _repository.GetReviewByIdAsync(reviewId);
                _mapper.Map(review, currentReview);
                _repository.UpdateReviewAsync(reviewId, currentReview);
                return review;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            return await _repository.DeleteReviewAsync(reviewId);
        }
    }
}
