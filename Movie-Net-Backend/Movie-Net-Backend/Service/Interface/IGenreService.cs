using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAllGenresAsync();
    Task<Result<Genre>> GetGenreByIdAsync(int id);
    Task<Result> DeleteGenreAsync(int id);
    Task<Result> UpdateGenreAsync(int id, Genre updatedGenre);
    Task<Genre> SaveGenreAsync(Genre genre);
    Task<Result<ICollection<Movie>>> GetMoviesWithGenreAsync(int genreId);
}