using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IReviewService
{
    IEnumerable<Review> FindAllReviews();
    Result<Review> GetReviewById(int id);
    Result DeleteReview(int id);
    Review SaveReview(Review review);
}