using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IGenreService
{
    IEnumerable<Genre> GetAllGenres();
    Result<Genre> GetGenreById(int id);
    Result DeleteGenre(int id);
    Result UpdateGenre(int id, Genre updatedGenre);
    Result<Genre> SaveGenre(Genre genre);
    Result<ICollection<Movie>> GetMoviesWithGenre(int genreId);
}