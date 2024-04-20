using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IMovieService
{
    IEnumerable<Movie> GetAllMovies();
    Movie GetMovieById(int id);
    void DeleteMovie(int id);
    void UpdateMovie(int id, Movie updatedMovie);
    void SaveMovie(Movie movie);
    void AddGenreToMovie(int movieId, int genreId);
    ICollection<Genre> GetGenresOfMovie(int movieId);
    void RemoveGenreFromMovie(int movieId, int genreId);
}