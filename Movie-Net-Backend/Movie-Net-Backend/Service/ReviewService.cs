using FluentResults;
using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class ReviewService(AppDbContext appDbContext, IUserService userService, IMovieService movieService) : IReviewService
{
    private readonly AppDbContext _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

    public async Task<IEnumerable<Review>> FindAllReviewsAsync()
    {
        return await _appDbContext.Reviews.ToListAsync();
    }

    public async Task<Result<Review>> FindReviewByIdAsync(int userId, int movieId)
    {
        var review = await _appDbContext.Reviews.FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == movieId);

        if (review == null) return Result.Fail($"Review not found");

        return Result.Ok(review);
    }

    public async Task<Result> DeleteReviewAsync(int userId, int movieId)
    {
        var review = await _appDbContext.Reviews.FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == movieId);

        if (review == null) return Result.Fail($"Review not found");

        _appDbContext.Reviews.Remove(review);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Review> SaveReviewAsync(Review review)
    {
        var reviewResult = await FindReviewByIdAsync(review.UserId, review.MovieId);

        // update existing review
        if (!reviewResult.IsFailed)
        {
            var existingReview = reviewResult.Value;
            existingReview.Text = review.Text;
            existingReview.Score = review.Score;
            await _appDbContext.SaveChangesAsync();
            return existingReview;
        }

        await _appDbContext.Reviews.AddAsync(review);
        await _appDbContext.SaveChangesAsync();
        return review;
    }

    public async Task<Result<List<Review>>> FindReviewsOfUserAsync(int userId)
    {
        var userResult = await userService.FindUserByIdAsync(userId);

        if (userResult.IsFailed) return userResult.ToResult();

        return userResult.Value.Reviews.ToList();
    }

    public async Task<Result<Review>> FindReviewOfUserForMovieAsync(int userId, int movieId)
    {
        var userResult = await userService.FindUserByIdAsync(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movieResult = await movieService.FindMovieByIdAsync(movieId);
        if (movieResult.IsFailed) return movieResult.ToResult();

        var result = await _appDbContext.Reviews.FirstOrDefaultAsync(review => review.UserId == userId && review.MovieId == movieId);
        if (result == null) return Result.Fail($"Movie {movieId} has no review for user {userId}");

        return Result.Ok(result);
    }
}