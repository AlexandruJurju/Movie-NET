using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IGenreService
{
    IEnumerable<Genre> GetAllGenres();
    Genre GetGenreById(int id);
    void DeleteGenre(int id);
    void UpdateGenre(int id, Genre updatedGenre);
    Genre SaveGenre(Genre genre);
    IEnumerable<Movie> GetMoviesWithGenre(int genreId);
}