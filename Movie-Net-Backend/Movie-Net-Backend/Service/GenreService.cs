using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Exceptions;
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

    public Genre GetGenreById(int id)
    {
        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == id);
        if (genre == null)
        {
            throw new GenreNotFoundException("Genre not found");
        }

        return genre;
    }

    public void DeleteGenre(int id)
    {
        var genre = GetGenreById(id);
        _appDbContext.Genres.Remove(genre);
        _appDbContext.SaveChanges();
    }

    public void UpdateGenre(int id, Genre updatedGenre)
    {
        var existingGenre = GetGenreById(id);
        existingGenre.Name = updatedGenre.Name;
        _appDbContext.Genres.Update(existingGenre);
        _appDbContext.SaveChanges();
    }

    public Genre SaveGenre(Genre genre)
    {
        _appDbContext.Genres.Add(genre);
        _appDbContext.SaveChanges();
        return genre;
    }

    public IEnumerable<Movie> GetMoviesWithGenre(int genreId)
    {
        // use include for eager loading
        var genre = _appDbContext.Genres
            .Include(g => g.Movies)
            .FirstOrDefault(g => g.Id == genreId);

        if (genre == null)
        {
            throw new GenreNotFoundException($"Genre with id {genreId} not found");
        }

        return genre.Movies;
    }
}