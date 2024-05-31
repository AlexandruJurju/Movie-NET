using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IReviewService
{
    Task<IEnumerable<Review>> FindAllReviewsAsync();
    Task<Result<Review>> FindReviewByIdAsync(int userId, int movieId);
    Task<Result> DeleteReviewAsync(int userId, int movieId);
    Task<Review> SaveReviewAsync(Review review);
    Task<Result<List<Review>>> FindReviewsOfUserAsync(int userId);
    Task<Result<Review>> FindReviewOfUserForMovieAsync(int userId, int movieId);
}