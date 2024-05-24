using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _appDbContext;

    public ReviewService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Review> FindAllReviews()
    {
        return _appDbContext.Reviews.ToList();
    }

    public Result<Review> FindReviewById(int userId, int movieId)
    {
        var review = _appDbContext.Reviews.FirstOrDefault(r => r.UserId == userId && r.MovieId == movieId);

        if (review == null) return Result.Fail($"Review not found");

        return Result.Ok(review);
    }

    public Result DeleteReview(int userId, int movieId)
    {
        var review = _appDbContext.Reviews.FirstOrDefault(r => r.UserId == userId && r.MovieId == movieId);

        if (review == null) return Result.Fail($"Review not found");

        _appDbContext.Reviews.Remove(review);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Review SaveReview(Review review)
    {
        var reviewResult = FindReviewById(review.UserId, review.MovieId);

        // update existing review
        if (!reviewResult.IsFailed)
        {
            var existingReview = reviewResult.Value;
            existingReview.Text = review.Text;
            existingReview.Score = review.Score;
            _appDbContext.SaveChanges();
            return existingReview;
        }

        _appDbContext.Reviews.Add(review);
        _appDbContext.SaveChanges();
        return review;
    }
}