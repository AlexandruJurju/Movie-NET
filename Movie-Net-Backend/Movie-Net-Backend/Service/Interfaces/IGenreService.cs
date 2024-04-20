using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interfaces;

public interface IGenreService
{
    IEnumerable<Genre> GetAllGenres();
    Genre? GetGenreById(int genreId);
    void DeleteGenre(Genre genre);
    void UpdateGenre(Genre genre);
    void SaveGenre(Genre genre);
}