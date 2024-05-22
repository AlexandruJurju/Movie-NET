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

    public Result<Review> GetReviewById(int id)
    {
        var review = _appDbContext.Reviews.FirstOrDefault(r => r.Id == id);

        if (review == null) return Result.Fail($"Review with id {id} not found");

        return Result.Ok(review);
    }

    public Result DeleteReview(int id)
    {
        var review = _appDbContext.Reviews.FirstOrDefault(r => r.Id == id);

        if (review == null) return Result.Fail($"Review with id {id} not found");

        _appDbContext.Reviews.Remove(review);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Review SaveReview(Review review)
    {
        _appDbContext.Reviews.Add(review);
        _appDbContext.SaveChanges();
        return review;
    }
}