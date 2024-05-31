using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class WatchlistService(AppDbContext appDbContext, IMovieService movieService, IUserService userService) : IWatchlistService
{
    public async Task<Result> AddMovieToWatchlistAsync(int userId, int movieId)
    {
        var userResult = await userService.FindUserByIdAsync(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movieResult = await movieService.FindMovieByIdAsync(movieId);
        if (movieResult.IsFailed) return movieResult.ToResult();

        var user = userResult.Value;
        var movie = movieResult.Value;

        user.Movies.Add(movie);
        await appDbContext.SaveChangesAsync();

        return Result.Ok();
    }

    public async Task<Result> RemoveMovieFromWatchlistAsync(int userId, int movieId)
    {
        var userResult = await userService.FindUserByIdAsync(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movieResult = await movieService.FindMovieByIdAsync(movieId);
        if (movieResult.IsFailed) return movieResult.ToResult();

        var user = userResult.Value;
        var movie = movieResult.Value;

        user.Movies.Remove(movie);
        await appDbContext.SaveChangesAsync();

        return Result.Ok();
    }

    public async Task<Result<List<Movie>>> FindWatchlistOfUserAsync(int userId)
    {
        var userResult = await userService.FindUserByIdAsync(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movies = userResult.Value.Movies.ToList();

        return Result.Ok(movies);
    }
}