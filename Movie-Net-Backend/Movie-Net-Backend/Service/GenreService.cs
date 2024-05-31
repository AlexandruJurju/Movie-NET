using FluentResults;
using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class GenreService(AppDbContext appDbContext) : IGenreService
{
    private readonly AppDbContext _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        return await _appDbContext.Genres.ToListAsync();
    }

    public async Task<Result<Genre>> GetGenreByIdAsync(int id)
    {
        var genre = await _appDbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre == null) return Result.Fail($"Genre with id {id} not found");

        return Result.Ok(genre);
    }

    public async Task<Result> DeleteGenreAsync(int id)
    {
        var genre = await _appDbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre == null) return Result.Fail($"Genre with id {id} not found");

        _appDbContext.Genres.Remove(genre);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateGenreAsync(int id, Genre updatedGenre)
    {
        var genre = await _appDbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre == null) return Result.Fail($"Genre with id {id} not found");

        genre.Name = updatedGenre.Name;
        _appDbContext.Genres.Update(genre);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Genre> SaveGenreAsync(Genre genre)
    {
        await _appDbContext.Genres.AddAsync(genre);
        await _appDbContext.SaveChangesAsync();
        return genre;
    }

    public async Task<Result<ICollection<Movie>>> GetMoviesWithGenreAsync(int genreId)
    {
        var genre = await _appDbContext.Genres
            .Include(g => g.Movies)
            .FirstOrDefaultAsync(g => g.Id == genreId);

        if (genre == null) return Result.Fail<ICollection<Movie>>(new Error("Genre not found"));

        return Result.Ok(genre.Movies);
    }
}