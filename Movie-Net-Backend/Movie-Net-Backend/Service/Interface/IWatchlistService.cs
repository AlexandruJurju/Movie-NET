using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IWatchlistService
{
    Task<Result> AddMovieToWatchlistAsync(int userId, int movieId);
    Task<Result> RemoveMovieFromWatchlistAsync(int userId, int movieId);
    Task<Result<List<Movie>>> FindWatchlistOfUserAsync(int userId);
}