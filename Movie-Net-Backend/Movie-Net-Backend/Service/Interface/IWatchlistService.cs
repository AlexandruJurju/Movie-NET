using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IWatchlistService
{
    Result AddMovieToWatchlist(int userId, int movieId);
    Result RemoveMovieFromWatchlist(int userId, int movieId);
    Result<List<Movie>> FindWatchlistOfUser(int userId);
}