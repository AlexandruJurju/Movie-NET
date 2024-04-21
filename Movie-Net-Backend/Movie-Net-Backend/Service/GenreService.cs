using FluentResults;
using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class GenreService : IGenreService
{
    private readonly AppDbContext _appDbContext;

    public GenreService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        return _appDbContext.Genres.ToList();
    }

    public Result<Genre> GetGenreById(int id)
    {
        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == id);

        if (genre == null)
        {
            return Result.Fail<Genre>(new Error("Genre not found"));
        }

        return Result.Ok(genre);
    }

    public Result DeleteGenre(int id)
    {
        var genreResult = GetGenreById(id);
        if (genreResult.IsFailed)
        {
            return genreResult.ToResult();
        }

        _appDbContext.Genres.Remove(genreResult.Value);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateGenre(int id, Genre updatedGenre)
    {
        var genreResult = GetGenreById(id);
        if (genreResult.IsFailed)
        {
            return genreResult.ToResult();
        }

        var existingGenre = genreResult.Value;
        existingGenre.Name = updatedGenre.Name;
        _appDbContext.Genres.Update(existingGenre);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Result<Genre> SaveGenre(Genre genre)
    {
        _appDbContext.Genres.Add(genre);
        _appDbContext.SaveChanges();
        return Result.Ok(genre);
    }

    public Result<ICollection<Movie>> GetMoviesWithGenre(int genreId)
    {
        // use include for eager loading
        var genre = _appDbContext.Genres
            .Include(g => g.Movies)
            .FirstOrDefault(g => g.Id == genreId);

        if (genre == null)
        {
            return Result.Fail<ICollection<Movie>>(new Error("Genre not found"));
        }

        return Result.Ok(genre.Movies);
    }
}
