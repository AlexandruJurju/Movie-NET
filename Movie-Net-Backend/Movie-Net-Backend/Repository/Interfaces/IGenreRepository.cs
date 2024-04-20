using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Repository.Interfaces;

public interface IGenreRepository
{
    IEnumerable<Genre> GetAllGenres();
    Genre? GetGenreById(int genreId);
    void DeleteGenre(Genre genre);
    void UpdateGenre(Genre genre);
    void SaveGenre(Genre genre);
    IEnumerable<Movie> GetMoviesWithGenre(int genreId);
}