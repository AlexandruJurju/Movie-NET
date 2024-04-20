using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interfaces;

namespace Movie_Net_Backend.Service;

public class MovieService : IMovieService
{
    private readonly AppDbContext _appDbContext;

    public MovieService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _appDbContext.Movies.ToList();
    }

    public void SaveMovie(Movie movie)
    {
        _appDbContext.Movies.Add(movie);
        _appDbContext.SaveChanges();
    }
}