using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Service.Interface;
using Movie = Movie_Net_Backend.Model.Movie;

namespace Movie_Net_Backend.Service;

public class WatchlistService : IWatchlistService
{
    private readonly AppDbContext _appDbContext;
    private readonly IMovieService _movieService;
    private readonly IUserService _userService;

    public WatchlistService(AppDbContext appDbContext, IMovieService movieService, IUserService userService)
    {
        _appDbContext = appDbContext;
        _movieService = movieService;
        _userService = userService;
    }

    public Result AddMovieToWatchlist(int userId, int movieId)
    {
        var userResult = _userService.FindUserById(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movieResult = _movieService.FindMovieById(movieId);
        if (movieResult.IsFailed) return movieResult.ToResult();

        var user = userResult.Value;
        var movie = movieResult.Value;

        user.Movies.Add(movie);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }

    public Result RemoveMovieFromWatchlist(int userId, int movieId)
    {
        var userResult = _userService.FindUserById(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movieResult = _movieService.FindMovieById(movieId);
        if (movieResult.IsFailed) return movieResult.ToResult();

        var user = userResult.Value;
        var movie = movieResult.Value;

        user.Movies.Remove(movie);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }

    public Result<List<Movie>> FindWatchlistOfUser(int userId)
    {
        var userResult = _userService.FindUserById(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        var movies = userResult.Value.Movies.ToList();

        return Result.Ok(movies);
    }
}