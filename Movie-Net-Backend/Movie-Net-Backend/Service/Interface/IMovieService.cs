using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IMovieService
{
    Task<IEnumerable<Movie>> FindAllMoviesAsync();
    Task<Result<Movie>> FindMovieByIdAsync(int movieId);
    Task<Result> DeleteMovieAsync(int movieId);
    Task<Result> UpdateMovieAsync(int movieId, Movie updatedMovie);
    Task<Movie> SaveMovieAsync(Movie movie);
    Task<List<Movie>> FindMoviesWithGenreAsync(int genreId);
}