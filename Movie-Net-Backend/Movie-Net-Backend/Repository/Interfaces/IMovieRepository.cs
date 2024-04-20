using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Repository.Interfaces;

public interface IMovieRepository
{
    IEnumerable<Movie> GetAllMovies();
    void SaveMovie(Movie movie);
    Movie? GetMovieById(int id);
    void DeleteMovie(Movie movie);
    void UpdateMovie(Movie movie);
    ICollection<Genre> GetGenresOfMovie(int movieId);
    void RemoveGenreFromMovie(Movie movie, Genre genre);
}