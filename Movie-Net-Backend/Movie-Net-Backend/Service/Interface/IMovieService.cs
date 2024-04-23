using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IMovieService
{
    IEnumerable<Movie> FindAllMovies();
    Result<Movie> FindMovieById(int movieId);
    Result DeleteMovie(int movieId);
    Result UpdateMovie(int movieId, Movie updatedMovie);
    Result<Movie> SaveMovie(Movie movie);
    Result AddGenreToMovie(int movieId, int genreId);
    Result<ICollection<Genre>> GetGenresOfMovie(int movieId);
    Result RemoveGenreFromMovie(int movieId, int genreId);
    Result<IEnumerable<MovieActor>> GetActorsOfMovie(int movieId);
    Result RemoveActorFromMovie(int movieId, int actorId);
    Result AddActorToMovie(MovieActor movieActor);
}