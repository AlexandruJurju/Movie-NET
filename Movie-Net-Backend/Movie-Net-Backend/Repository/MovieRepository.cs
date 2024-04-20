using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Repository.Interfaces;

namespace Movie_Net_Backend.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _appDbContext;

    public MovieRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _appDbContext.Movies.ToList();
    }

    public Movie? GetMovieById(int id)
    {
        return _appDbContext.Movies.FirstOrDefault(m => m.Id == id);
    }

    public void DeleteMovie(Movie movie)
    {
        _appDbContext.Movies.Remove(movie);
        _appDbContext.SaveChanges();
    }

    public void UpdateMovie(Movie movie)
    {
        _appDbContext.Movies.Update(movie);
        _appDbContext.SaveChanges();
    }
    
    public void SaveMovie(Movie movie)
    {
        _appDbContext.Movies.Add(movie);
        _appDbContext.SaveChanges();
    }

    public void AddGenreToMovie(Movie movie, Genre genre)
    {
        
    }
    
}