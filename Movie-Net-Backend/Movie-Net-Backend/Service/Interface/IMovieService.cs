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
    Result AddGenreToMovie(int movieId, int genreId);
    Result<ICollection<Genre>> GetGenresOfMovie(int movieId);
    Result RemoveGenreFromMovie(int movieId, int genreId);
    Result<IEnumerable<MovieActor>> GetActorsOfMovie(int movieId);
    Result RemoveActorFromMovie(int movieId, int actorId);
    Result AddActorToMovie(MovieActor movieActor);
}