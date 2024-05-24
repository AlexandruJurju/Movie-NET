using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IReviewService
{
    IEnumerable<Review> FindAllReviews();
    Result<Review> FindReviewById(int userId, int movieId);
    Result DeleteReview(int userId, int movieId);
    Review SaveReview(Review review);
    Result<List<Review>> FindReviewsOfUser(int userId);
}