using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IMovieService
{
    IEnumerable<Movie> GetAllMovies();
    Result<Movie> GetMovieById(int id);
    Result DeleteMovie(int id);
    Result UpdateMovie(int id, Movie updatedMovie);
    Result<Movie> SaveMovie(Movie movie);
    Result AddGenreToMovie(int movieId, int genreId);
    Result<ICollection<Genre>> GetGenresOfMovie(int movieId);
    Result RemoveGenreFromMovie(int movieId, int genreId);
}