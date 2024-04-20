using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Repository.Interfaces;

namespace Movie_Net_Backend.Repository;

public class GenreRepository : IGenreRepository
{
    private readonly AppDbContext _appDbContext;

    public GenreRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        return _appDbContext.Genres.ToList();
    }

    public Genre? GetGenreById(int genreId)
    {
        return _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);
    }

    public void DeleteGenre(Genre genre)
    {
        _appDbContext.Genres.Remove(genre);
        _appDbContext.SaveChanges();
    }

    public void UpdateGenre(Genre genre)
    {
        _appDbContext.Genres.Update(genre);
        _appDbContext.SaveChanges();
    }

    public void SaveGenre(Genre genre)
    {
        _appDbContext.Genres.Add(genre);
        _appDbContext.SaveChanges();
    }
}